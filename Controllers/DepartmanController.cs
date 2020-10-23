using PersonelMVCUI.Models.Entity;
using PersonelMVCUI.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace PersonelMVCUI.Controllers
{
    [Authorize(Roles = "A,U")]
    public class DepartmanController : Controller
    {
        PersonelEntities db = new PersonelEntities();

        //yetkisi olmayanlar giremesin diye web.config'e bunu ekledik. "<authentication mode="Forms"></authentication>"                 
        public ActionResult Index()
        {
            var model = db.Departman.ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult Yeni()
        {
            return View("DepartmanForm", new Departman()); //ModelState.IsValid true gelmesi için new kısmını eklemeliyiz.
        }

        [ValidateAntiForgeryToken] //bunu ekleyerek, dışardıdan gelenecek olan isteklere karşı koruma sağlar. 
        public ActionResult Kaydet(Departman departman)
        {
            if (!ModelState.IsValid)
            {
                return View("DepartmanForm");
            }

            MesajViewModel m = new MesajViewModel();

            if (departman.Id == 0)
            {
                db.Departman.Add(departman);
                m.Mesaj = departman.Ad + " başarıyla eklendi!";
            }
            else
            {
                var guncellenecekDep = db.Departman.Find(departman.Id);
                if (guncellenecekDep == null)
                {
                    return HttpNotFound();
                }
                guncellenecekDep.Ad = departman.Ad;
                m.Mesaj = departman.Ad + " başarıyla güncellendi!";
            }

            db.SaveChanges();

            m.Status = true;
            m.LinkText = "Departman Listesi";
            m.Url = "/Departman";
            //return RedirectToAction("Index", "Departman");
            return View("_Mesaj", m);
        }

        public ActionResult Guncelle(int id)
        {
            var guncellenecekDep = db.Departman.Find(id);
            if (guncellenecekDep == null)
            {
                return HttpNotFound();
            }
            return View("DepartmanForm", guncellenecekDep);
        }
        public ActionResult Sil(int id)
        {
            var silinecekDep = db.Departman.Find(id);
            if (silinecekDep == null)
            {
                return HttpNotFound();
            }
            db.Departman.Remove(silinecekDep);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}