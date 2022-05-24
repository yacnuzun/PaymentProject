using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class InMemoryTransactionDal :CashMemory<Transaction>,ITransactionDal
    {
        IAccountDal _accountDal;

        public InMemoryTransactionDal(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }

        public void CreateTransactionTable()
        {
            List<Transaction> _transactions = new List<Transaction>()
            {
                new Transaction(){TransactionId=1,TransactionDate=DateTime.Now,TransactionType=TransactionTypes.payment,SenderNumber=1,RecipientNumber=2,Amount=10},
                new Transaction(){TransactionId=2,TransactionDate=DateTime.Parse("5/1/2020"),TransactionType=TransactionTypes.withdraw,SenderNumber=1,RecipientNumber=1,Amount=20}
            };
            EntityListSet(_transactions);
        }
        public bool TransactionIsNull(List<Transaction> transactions)
        {
            if (EntityListGet()==null)
            {
                return true;
            }
            return false;
        }
        public void Add(Transaction transaction)
        {
            if (TransactionIsNull(EntityListGet()) == true)
            {
                CreateTransactionTable();
            }
            EntityListGet().Add(transaction);
        }

        public void Delete(Transaction transaction)
        {
            if (TransactionIsNull(EntityListGet()) == true)
            {
                CreateTransactionTable();
            }
            throw new NotImplementedException();
        }

        public Transaction Get(int id)
        {
            if (TransactionIsNull(EntityListGet()) == true)
            {
                CreateTransactionTable();
            }
            return EntityListGet().Where(t=>t.TransactionId == id).SingleOrDefault();
        }

        public List<Transaction> GetAll()
        {
            if (TransactionIsNull(EntityListGet()) ==true)
            {
                CreateTransactionTable();
            }
            return EntityListGet().ToList();
        }

        public List<Transaction> GetAllByOwnerId(int id)
        {
            if (TransactionIsNull(EntityListGet()) == true)
            {
                CreateTransactionTable();
            }
            return EntityListGet().Where(t=>t.RecipientNumber == id || t.SenderNumber==id).ToList();
        }

        public void Update(int id)
        {
            if (TransactionIsNull(EntityListGet()) == true)
            {
                CreateTransactionTable();
            }
            var payment= EntityListGet().Where(t=>t.RecipientNumber==id).FirstOrDefault();

        }


        public void Update(Transaction entity)
        {
            throw new NotImplementedException();
        }

        public void Payment(AccountPaymentDto accountPaymentDto)
        {
            Transaction transaction = new Transaction();

            if (TransactionIsNull(EntityListGet()) == true)
            {
                CreateTransactionTable();
            }
            transaction.TransactionType = TransactionTypes.payment;
            transaction.RecipientNumber = accountPaymentDto.RecipientNumber;
            transaction.SenderNumber = accountPaymentDto.SenderNumber;
            transaction.Amount = accountPaymentDto.Amount;
            transaction.TransactionDate= DateTime.Now;
            EntityListGet().Add(transaction);
        }

        public void WithDraw(AccountWithDrawDto accountWithDrawDto)
        {
            Transaction transaction = new Transaction();
            Account account = new Account();
            if (TransactionIsNull(EntityListGet()) == true)
            {
                CreateTransactionTable();
            }
            transaction.TransactionType = TransactionTypes.withdraw;
            transaction.RecipientNumber = accountWithDrawDto.OwnerNumber;
            transaction.SenderNumber = accountWithDrawDto.OwnerNumber;
            transaction.Amount = accountWithDrawDto.Amount;
            transaction.TransactionDate = DateTime.Now;
            EntityListGet().Add(transaction);
            account.AccountNumber = accountWithDrawDto.OwnerNumber;
            account.Balance = account.Balance - accountWithDrawDto.Amount;
            _accountDal.Update(account);
        }
        public void Deposit(AccountWithDepositDto accountWithDepositDto)
        {

        }
    }
}
