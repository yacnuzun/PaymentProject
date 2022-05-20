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
    public class InMemoryAccountDal: EfEntityRepositoryBase<Account,PaymentProjectDbContext>, IEntityRepository<Account>
    {
        List<Account> _accounts;

        public InMemoryAccountDal(List<Account> accounts)
        {
            _accounts = new List<Account>
            {
                new Account{AccountNumber = 1,AccountTypeId=1}
            };
        }
    }
}
