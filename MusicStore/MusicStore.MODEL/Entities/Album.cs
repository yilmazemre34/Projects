using MusicStore.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.MODEL.Entities
{
    public class Album :BaseEntity
    {   
        public Album()
        {
            OrderDetails = new HashSet<OrderDetail>();
            Discontinued = false;
            Discounted = false;
        }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public short Stock { get; set; }
        public string AlbumArtUrl { get; set; }
        public bool Discontinued { get; set; }

        public bool Discounted { get; set; }

        public int ArtistID { get; set; }
        public int GenreID { get; set; }


        public virtual Artist Artist { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
