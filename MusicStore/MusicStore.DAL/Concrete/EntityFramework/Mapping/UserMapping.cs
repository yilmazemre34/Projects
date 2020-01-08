using MusicStore.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.DAL.Concrete.EntityFramework.Mapping
{
    class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            Property(x => x.FirstName).HasMaxLength(75);
            Property(x => x.LastName).HasMaxLength(75);
            Property(x => x.Address).HasMaxLength(300);
            Property(x => x.Email).HasMaxLength(150);
            Property(x => x.Phone).HasMaxLength(18);
            Property(x => x.UserName).IsRequired().HasMaxLength(100);
            Property(x => x.Password).IsRequired();

        
            HasIndex(a => a.UserName).IsUnique();
        }
    }
}
