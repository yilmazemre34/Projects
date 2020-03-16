using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MbisSystem.Model.Model;
using deneme.Tools;

namespace MbisSystem.UI.Controllers
{

    public class HomeController : Controller
    {
        IsTakipEntities db = new IsTakipEntities();
    
        public ActionResult Index()
        {
            return View(db.Islers.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Isler isler)
        {
            bool sonuc = false;
            bool mail = false;
            string olusturanAdi = Session["personelAdi"].ToString();
            var olusturanperson = db.Personels.Where(x => x.PersonelAd == olusturanAdi).FirstOrDefault();
            isler.OlusturanIsim = olusturanAdi;
            isler.Olusturan = olusturanperson.PersonelID;
            sonuc = isatama.isata(isler);

            //mail için
            string maildetay = "İş Aciklama:" + isler.Aciklama + " Firma ismi:" + isler.Baslik;          
            var atananperson = db.Personels.Where(x => x.PersonelID == isler.Atanan).FirstOrDefault();
            string personelisim = atananperson.PersonelAd;
            string mailadresi = atananperson.mail;

            mail = MailGonder.IsAtamaMaili(personelisim,"3kturkey@gmail.com",maildetay);
                if (sonuc==true)
                {
                  return  RedirectToAction("Index");
                }
                else
                {
                  ModelState.AddModelError("", "İş oluşturulamadı.");
                }

            return View(isler);

        }



        public ActionResult Details(int Id=0)
        {
            Isler is1 = db.Islers.Find(Id);
            return View(is1);
        }

    }
}