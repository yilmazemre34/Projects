using MusicStore.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.MODEL.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>(); 
        }
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipAddress { get; set; }

        //Mapping
        public virtual User UserDetail { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
