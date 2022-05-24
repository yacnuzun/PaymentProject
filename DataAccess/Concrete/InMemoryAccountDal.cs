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
    public class InMemoryAccountDal:CashMemoryForAccount<Account>,IAccountDal
    {

        
        private List<Account> CreateAccountTable()
        {

            List<Account> _accounts = new List<Account>
            {
                new Account{AccountNumber = 1,Balance=10,accountype=accountype.bireysel,currencycode=currencycode.TRY,OwnerName="Yalçın"},
                new Account{AccountNumber = 2,Balance=20,accountype=accountype.bireysel,currencycode=currencycode.USD,OwnerName="Selçuk"},
                new Account{AccountNumber = 3,Balance=30,accountype=accountype.kurumsal,currencycode=currencycode.EUR,OwnerName="Yalçın A.Ş."}

            };

            EntityListSet(_accounts);
            return EntityList;
        }

        private bool AccountTableIsNull(List<Account> accounts)
        {
            if (EntityListGet() != null)
            {
                return false;
            }
            return true;
        }
        public void Add(Account account)
        {
            if (AccountTableIsNull(EntityListGet()))
            {

                CreateAccountTable();
            }
            EntityList.Add(account);
        }

        public void Delete(Account account)
        {
            if (AccountTableIsNull(EntityListGet()))
            {

                CreateAccountTable();
            }
            var deleteToAccount = EntityListGet().SingleOrDefault(a=> a.AccountNumber == account.AccountNumber);
            EntityList.Remove(deleteToAccount);
        }

        public Account Get(int id)
        {
            if (AccountTableIsNull(EntityListGet()))
            {

                CreateAccountTable();
            }
            return EntityList.SingleOrDefault(a=>a.AccountNumber==id);
        }

        public List<Account> GetAll()
        {
            if (AccountTableIsNull(EntityList))
            {

                CreateAccountTable();
            }

            return EntityList;
        }

        

        public void Update(Account account)
        {
            if (AccountTableIsNull(EntityList))
            {

                CreateAccountTable();
            }
            var accountToUpdate = EntityList.SingleOrDefault(a => a.AccountNumber == account.AccountNumber);
            accountToUpdate.OwnerName = account.OwnerName;
            accountToUpdate.currencycode= account.currencycode;
            accountToUpdate.accountype= account.accountype;
            accountToUpdate.AccountNumber=account.AccountNumber;
            accountToUpdate.Balance= account.Balance;
            EntityList.Remove(account);
            EntityList.Add(accountToUpdate);
        }
    }
}
