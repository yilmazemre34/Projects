using MusicStore.DAL.Abstract;
using MusicStore.DAL.Concrete.EntityFramework;
using MusicStore.MODEL.Entities;
using MusicStore.SERVICE.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicStore.SERVICE.WebAPI.Controllers
{
    public class AlbumController : ApiController
    {
        IAlbumDAL _albumDAL;

        public AlbumController()
        {
            _albumDAL = new AlbumRepository();
        }

        //Kullanıcıya tüm ürünleri getir
        public IHttpActionResult GetAlbums()
        {
            List<AlbumListModel> albums = new List<AlbumListModel>();        
            foreach (Album item in _albumDAL.GetAll(a => a.Discontinued == false))
            {
                albums.Add(new AlbumListModel()
                {
                    AlbumID = item.ID,
                    AlbumArtUrl = item.AlbumArtUrl,
                    Price = item.Price,
                    Title = item.Title
                });
            }

            return Json(albums);
        }
        //genreye göre getir
        public IHttpActionResult GetAlbums(int id)
        {
            List<AlbumListModel> albums = new List<AlbumListModel>();
            foreach (Album item in _albumDAL.GetAll(a => a.Discontinued == false && a.GenreID==id))
            {
                albums.Add(new AlbumListModel()
                {
                    AlbumID = item.ID,
                    AlbumArtUrl = item.AlbumArtUrl,
                    Price = item.Price,
                    Title = item.Title
                });
            }

            return Json(albums);
        }
        //eklenen 5 ürünü getir 
        public IHttpActionResult GetLastFiveAlbums()
        {
            List<AlbumListModel> albums = new List<AlbumListModel>();

            foreach (Album item in _albumDAL.GetAll(a => a.Discontinued == false).OrderByDescending(a=>a.CreatedDate).Take(5).ToList())
            {
                albums.Add(new AlbumListModel()
                {
                    AlbumID = item.ID,
                    AlbumArtUrl = item.AlbumArtUrl,
                    Price = item.Price,
                    Title = item.Title
                });
            }

            return Json(albums);
        }
        //indirimdekileri getir
        public IHttpActionResult GetDiscountAlbums()
        {
            List<AlbumListModel> albums = new List<AlbumListModel>();

            foreach (Album item in _albumDAL.GetAll(a => a.Discounted==true).ToList())
            {
                albums.Add(new AlbumListModel()
                {
                    AlbumID = item.ID,
                    AlbumArtUrl = item.AlbumArtUrl,
                    Price = item.Price,
                    Title = item.Title
                });
            }

            return Json(albums);
        }
        //ek ürün getir
        public IHttpActionResult Get(int id)
        {
            Album album = _albumDAL.Get(a => a.ID == id);

            if (album == null)
            {
                return NotFound();
            }

            AlbumListModel model = new AlbumListModel();
            model.AlbumID = album.ArtistID;
            model.Price = album.Price;
            model.Title = album.Title;
            return Json(model);
        }
        //Admine tüm ürünleri getir
        public IHttpActionResult GetAll()
        {
            List<AlbumListModel> albums = new List<AlbumListModel>();

            foreach (Album item in _albumDAL.GetAll())
            {
                albums.Add(new AlbumListModel()
                {
                    AlbumID = item.ID,
                    AlbumArtUrl = item.AlbumArtUrl,
                    Price = item.Price,
                    Title = item.Title
                });
            }

            return Json(albums);
        }
    }
}
