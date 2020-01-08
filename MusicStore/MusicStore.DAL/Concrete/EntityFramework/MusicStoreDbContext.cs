
using MusicStore.DAL.Concrete.EntityFramework.Mapping;
using MusicStore.MODEL.Entities;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.DAL.Concrete.EntityFramework
{
    public class MusicStoreDbContext:DbContext
    {
        public MusicStoreDbContext():base("server=.\\SQLEXPRESS; database=MusicStoreDB; uid=sa; pwd=123")
        {
            Database.SetInitializer<MusicStoreDbContext>(new MyStrategy());
          
        }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<User> UserDetails { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties().Where(a => a.PropertyType == typeof(DateTime)).Configure(a => a.HasColumnType("datetime2"));
            modelBuilder.Configurations.Add(new OrderDetailMapping());
            modelBuilder.Configurations.Add(new AlbumMapping());
            modelBuilder.Configurations.Add(new ArtistMapping());
            modelBuilder.Configurations.Add(new GenreMapping());
            modelBuilder.Configurations.Add(new OrderMapping());
            modelBuilder.Configurations.Add(new UserMapping());
        }
    }
}
