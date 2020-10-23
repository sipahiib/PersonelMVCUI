using PersonelMVCUI.Models.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace PersonelMVCUI.Controllers
{
    public class SecurityController : Controller
    {
        PersonelEntities db = new PersonelEntities();

        [AllowAnonymous] //global.asax dosyasına "GlobalFilters" satırı eklendi.
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Kullanici kullanici)
        {
            var validKullanici = db.Kullanici.FirstOrDefault(m => m.Ad == kullanici.Ad && m.Sifre == kullanici.Sifre);
            if (validKullanici != null)
            {
                FormsAuthentication.SetAuthCookie(validKullanici.Ad,false);
                return RedirectToAction("Index", "Departman");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz kullanıcı adı veya şifre";
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}