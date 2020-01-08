using MusicStore.BLL.Abstract;
using MusicStore.MODEL.Entities;
using MusicStore.UI.MVC.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.UI.MVC.Areas.Admin.Controllers
{
    public class GenreController : Controller
    {
        IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public ActionResult Index()
        {
            return View(_genreService.GetAll());
        }
        public JsonResult Add(Genre genre)
        {
            try
            {
                _genreService.Insert(genre);
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult GetByID(int id)
        {
            Genre genre = _genreService.Get(id);

            if (genre != null)
            {
                GenreVM genreVM = new GenreVM()
                {
                    GenreID = genre.ID,
                    Name = genre.Name,
                    Description = genre.Description
                };
                return Json(genreVM, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Update(Genre cat)
        {
            _genreService.Update(cat);
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            _genreService.DeleteByID(id);
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

    }
}
