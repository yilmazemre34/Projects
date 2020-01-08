using MusicStore.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.CORE.DAL
{
    public interface IRepository<TEntity>
       where TEntity : BaseEntity        
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        //Predicate => boolean tipli metotlar saklar
        //Func => her tipte geriye dönen metotu saklar
        //Action => kullanılmıyor

        //db.Products.Where(filter)
        //db.Products.Where(name==name)
        ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
    }
}
