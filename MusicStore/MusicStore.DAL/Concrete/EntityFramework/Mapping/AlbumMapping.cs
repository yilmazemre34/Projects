using MusicStore.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.DAL.Concrete.EntityFramework.Mapping
{
    class AlbumMapping : EntityTypeConfiguration<Album>
    {
        public AlbumMapping()
        {
            Property(x => x.Title).HasMaxLength(150).IsRequired();
            Property(x => x.AlbumArtUrl).HasMaxLength(256);
            Property(x => x.Price).HasPrecision(5, 2);
        }
    }
}
