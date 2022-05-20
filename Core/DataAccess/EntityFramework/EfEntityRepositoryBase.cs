using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        List<TEntity> _entities;

        public EfEntityRepositoryBase(List<TEntity> entities)
        {
            _entities = entities;
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            
            _entities.Remove(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            
                return _entities.Set<TEntity>().SingleOrDefault(filter);
            
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext()) 
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            _entities.mod
        }
    }
}
