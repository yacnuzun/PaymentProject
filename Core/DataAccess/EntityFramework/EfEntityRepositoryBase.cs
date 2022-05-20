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
    public class EfEntityRepositoryBase<TEntity> 
        where TEntity : class, IEntity, new()
    {
        //List<TEntity> _entities;

        //public EfEntityRepositoryBase(List<TEntity> entities)
        //{
        //    _entities = entities;
        //}

        //public void Add(TEntity entity)
        //{
        //    _entities.Add(entity);
        //}

        //public void Delete(TEntity entity, Expression<Func<TEntity, bool>> filter)
        //{
        //    _entities.GroupBy<>
        //    _entities.Remove(entity);
        //}

        //public TEntity Get(Expression<Func<TEntity, bool>> filter)
        //{
            
        //        return _entities.SingleOrDefault(filter);
            
        //}

        //public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        //{
            
        //        return filter == null ? _entities.ToHashSet<TEntity>().ToList() : _entities.ToHashSet<TEntity>().FirstOrDefault(filter);
            
        //}

        //public void Update(TEntity entity)
        //{
        //    _entities.mod
        //}
    }
}
