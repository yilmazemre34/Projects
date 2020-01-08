using MusicStore.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.BLL.Abstract
{
    public interface IAlbumService :IBaseService<Album>
    {
        List<Album> GetAlbumsOfGenre(int genreID);

        List<Album> GetLastFiveAlbums();

        List<Album> GetDiscontinuedAlbums();
    }
}
