using MusicStore.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.DAL.Concrete.EntityFramework.Mapping
{
    class OrderMapping:EntityTypeConfiguration<Order>
    {
        public OrderMapping()
        {
            Property(x => x.ShipAddress).HasMaxLength(350);
        }
    }
}
