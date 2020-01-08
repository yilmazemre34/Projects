using MusicStore.DAL.Abstract;
using MusicStore.DAL.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.BLL.IoC
{
    public class MusicStoreDALModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserDAL>().To<UserRepository>();
            Bind<IAlbumDAL>().To<AlbumRepository>();
            Bind<IArtistDAL>().To<ArtistReposiitory>();
            Bind<IGenreDAL>().To<GenreRepository>();
            Bind<IOrderDAL>().To<OrderRepository>();
        }
    }
}
