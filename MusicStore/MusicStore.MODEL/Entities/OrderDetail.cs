using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.MODEL.Entities
{
    public class OrderDetail
    {
        public int OrderID { get; set; }
        public int AlbumID { get; set; }
        public short Quantity { get; set; }
        public double Discount { get; set; }
        public decimal Price { get; set; }

        public virtual Order Order { get; set; }
        public virtual Album Album { get; set; }
    }
}
