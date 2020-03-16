using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MbisSystem.Model.Model;

namespace deneme.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorize(Personel personelModel)
        {
                IsTakipEntities db = new IsTakipEntities();
            
                var userdetails = db.Personels.Where(x => x.username == personelModel.username && x.password == personelModel.password).FirstOrDefault();
                if (userdetails == null)
                {
                    personelModel.LogErrorMessage = "Hatalı kullanıcı adı veya şifre";
                    return View("Index", personelModel);
                }
                else
                {
                     Session["personelID"] = userdetails.PersonelID;
                     Session["personelAdi"] = userdetails.PersonelAd;
                    return RedirectToAction("Index", "Home");
                }

        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}