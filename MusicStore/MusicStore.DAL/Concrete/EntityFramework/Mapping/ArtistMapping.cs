using MusicStore.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.DAL.Concrete.EntityFramework.Mapping
{
    class ArtistMapping : EntityTypeConfiguration<Artist>
    {
        public ArtistMapping()
        {
            Property(x => x.FullName).HasMaxLength(250).IsRequired();
        }
    }
}
