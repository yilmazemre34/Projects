using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MbisSystem.Model.Model;

namespace deneme.Controllers
{
    public class PersonelController : Controller
    {
        IsTakipEntities db = new IsTakipEntities();
        // GET: Personel
        public ActionResult Index()
        {
              return View(db.Personels.ToList());
        }

    }
}