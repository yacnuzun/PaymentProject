using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class InMemoryAccountDal: IAccountDal
    {
        List<Account> _accounts;

        public InMemoryAccountDal(List<Account> accounts)
        {
            _accounts = new List<Account>
            {
                new Account{AccountNumber = 1,AccountTypeId=1,OwnerId=1,CurrencyCodeId=1},
                new Account{AccountNumber = 2,AccountTypeId=2,OwnerId=2,CurrencyCodeId=1},
                new Account{AccountNumber = 3,AccountTypeId=2,OwnerId=1,CurrencyCodeId=1}

            };
        }

        public void Add(Account account)
        {
            _accounts.Add(account);
        }

        public void Delete(Account account)
        {
            var deleteToAccount=_accounts.SingleOrDefault(a=> a.AccountNumber == account.AccountNumber);
            _accounts.Remove(deleteToAccount);
        }

        public Account Get(int id)
        {
            return _accounts.SingleOrDefault(a=>a.AccountNumber==id);
        }

        public List<Account> GetAll()
        {
            return _accounts.ToList();
        }

        public List<Account> GetAllById(int id)
        {
            return _accounts.Where(a=>a.AccountNumber==id).ToList();
        }

        public void Update(Account account)
        {
            var accountToUpdate = _accounts.SingleOrDefault(a => a.AccountNumber == account.AccountNumber);
            accountToUpdate.OwnerId = account.OwnerId;
            accountToUpdate.AccountTypeId = account.AccountTypeId;
            accountToUpdate.CurrencyCodeId = account.CurrencyCodeId;
        }
    }
}
