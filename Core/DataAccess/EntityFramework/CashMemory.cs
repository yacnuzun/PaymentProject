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
    public class CashMemoryForTransaction<TEntity>
    {
        public List<TEntity> EntityList;


        public List<TEntity> EntityListSet(List<TEntity> entities)
        {
            return EntityList=entities;
        }
        public List<TEntity> EntityListGet()
        {
            return EntityList;
        }
    }
    public class CashMemoryForAccount<TEntity>
    {
        public List<TEntity> EntityList;


        public List<TEntity> EntityListSet(List<TEntity> entities)
        {
            return EntityList = entities;
        }
        public List<TEntity> EntityListGet()
        {
            return EntityList;
        }
    }
}
