using MusicStore.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.MODEL.Entities
{
    public class Genre:BaseEntity
    {
        public Genre()
        {
            Albums = new HashSet<Album>();
        }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

    }
}
