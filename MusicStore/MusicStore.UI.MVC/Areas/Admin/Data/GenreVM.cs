using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.UI.MVC.Areas.Admin.Data
{
    public class GenreVM
    {
        public int GenreID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}