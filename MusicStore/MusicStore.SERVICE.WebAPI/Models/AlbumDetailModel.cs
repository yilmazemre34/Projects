using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.SERVICE.WebAPI.Models
{
    public class AlbumDetailModel
    {
        public int AlbumID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string AlbumArtUrl { get; set; }
        public string Artist { get; set; }
        public string GenreName { get; set; }
    }
}