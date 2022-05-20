using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class InMemoryCurencyTypeDal: EfEntityRepositoryBase<CurrencyCode>, IEntityRepository<CurrencyCode>
    {
    }
}
