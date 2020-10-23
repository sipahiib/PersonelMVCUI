using PersonelMVCUI.Models.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using PersonelMVCUI.ViewModels;

namespace PersonelMVCUI.Controllers
{
    [Authorize(Roles = "A,U")]
    public class PersonelController : Controller
    {
        PersonelEntities personelDb = new PersonelEntities();

        [OutputCache(Duration = 30)] //yani, 30sn içinde ben personel listesine tıklarsam, tekrar DB'ye gidip sorgu çekmesin, cache'ten okusun.
        public ActionResult Index()
        {
            // lazyloading yöntemidir. sayfayı her çağırdığımzda istek atar DB'ye. 
            //var model = personelDb.Personel.ToList(); 

            //eagerloading yöntemidir. tek sorgu atar DB'ye ve hepsini getirir.
            //bunu aktifleştirmek için, entity.edmx dosyasında, properties kısmında "lazyloadingEnabled=false" yapmak gerekiyor.
            var model = personelDb.Personel.Include(x => x.Departman).ToList();

            return View(model);
        }

        public ActionResult Yeni()
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = personelDb.Departman.ToList(),
                Personel = new Personel()
            };
            return View("PersonelForm", model);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Personel personel)
        {
            if (!ModelState.IsValid)
            {
                var model = new PersonelFormViewModel()
                {
                    Departmanlar = personelDb.Departman.ToList(),
                    Personel = personel
                };

                return View("PersonelForm", model);
            }

            if (personel.Id == 0) //ekleme
            {
                personelDb.Personel.Add(personel);
            }
            else //güncelleme
            {
                personelDb.Entry(personel).State = EntityState.Modified;
            }

            personelDb.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Guncelle(int id)
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = personelDb.Departman.ToList(),
                Personel = personelDb.Personel.Find(id)
            };

            return View("PersonelForm", model);
        }
        public ActionResult Sil(int id)
        {
            var silinecekPer = personelDb.Personel.Find(id);
            if (silinecekPer == null)
            {
                return HttpNotFound();
            }

            personelDb.Personel.Remove(silinecekPer);
            personelDb.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult PersonelListele(int id)
        {
            var model = personelDb.Personel.Where(m => m.DepartmanId == id).ToList();
            return PartialView(model);
        }
        public int? ToplamMaas()
        {
            return personelDb.Personel.Sum(m => m.Maas);
        }
    }
}