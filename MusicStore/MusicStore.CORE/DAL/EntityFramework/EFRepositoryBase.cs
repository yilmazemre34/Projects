using MusicStore.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.CORE.DAL.EntityFramework
{
    public class EFRepositoryBase<TEntity, TContext> : IRepository<TEntity>
         where TEntity : BaseEntity, new()//BaseEntity abst classından kalıtım almış, boş ctoru olan
         where TContext : DbContext, new() //DbContext'ten kalıtım almış, boş ctoru olan
    {
        TContext ctx = EFSingletonContext<TContext>.Instance;
        public void Add(TEntity entity)
        {
            ctx.Entry(entity).State = EntityState.Added;
            ctx.SaveChanges();
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return ctx.Set<TEntity>().Where(filter).SingleOrDefault();
        }
        public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
            {
                return ctx.Set<TEntity>().ToList();
            }
            else
            {
                return ctx.Set<TEntity>().Where(filter).ToList();
            }
        }
        public void Remove(TEntity entity)
        {
            ctx.Entry(entity).State = EntityState.Deleted;
            ctx.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}
