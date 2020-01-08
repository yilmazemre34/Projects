using MusicStore.BLL.Abstract;
using MusicStore.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        IGenreService _genreService;

        public HomeController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAlbums(List<AlbumListViewModel> albums)
        {
            if (albums == null)
            {
                ViewBag.Error = "Ürün Bulunamadı.";
                return PartialView("_AlbumPartial");
            }
            return PartialView("_AlbumPartial", albums);
        }       


        public ActionResult _GenrePartial()
        {
            return PartialView(_genreService.GetAll());
        }
    }
}