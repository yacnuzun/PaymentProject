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
    public class InMemoryTransactionDal :CashMemoryForTransaction<Transaction>,ITransactionDal
    {
        IAccountDal _accountDal;
        
        public InMemoryTransactionDal(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }

        public List<Transaction> CreateTransactionTable()
        {
            List<Transaction> _transactions = new List<Transaction>()
            {
                new Transaction(){TransactionId=1,TransactionDate=DateTime.Now,TransactionType=TransactionTypes.payment,SenderNumber=1,RecipientNumber=2,Amount=10},
                new Transaction(){TransactionId=2,TransactionDate=DateTime.Parse("5/1/2020"),TransactionType=TransactionTypes.withdraw,SenderNumber=1,RecipientNumber=1,Amount=20}
            };
            EntityListSet(_transactions);
            return  EntityList;
            
        }
        public bool TransactionIsNull(List<Transaction> transactions)
        {
            if (EntityList==null)
            {
                return true;
            }
            return false;
        }
        public void Add(Transaction transaction)
        {
            if (TransactionIsNull(EntityList) == true)
            {
                CreateTransactionTable();
            }
            EntityList.Add(transaction);
        }

        public void Delete(Transaction transaction)
        {
            if (TransactionIsNull(EntityList) == true)
            {
                CreateTransactionTable();
            }
            throw new NotImplementedException();
        }

        public Transaction Get(int id)
        {
            if (TransactionIsNull(EntityList) == true)
            {
                CreateTransactionTable();
            }
            return EntityList.Where(t=>t.TransactionId == id).SingleOrDefault();
        }

        public List<Transaction> GetAll()
        {
            if (TransactionIsNull(EntityList) ==true)
            {
                CreateTransactionTable();
            }
            return EntityList;
        }

        public List<Transaction> GetAllByOwnerId(int id)
        {
            if (TransactionIsNull(EntityList) == true)
            {
                CreateTransactionTable();
            }
            return EntityList.Where(t=>t.RecipientNumber == id || t.SenderNumber==id).ToList();
        }

        public void Update(int id)
        {
            if (TransactionIsNull(EntityList) == true)
            {
                CreateTransactionTable();
            }
            var payment= EntityList.Where(t=>t.RecipientNumber==id).FirstOrDefault();

        }


        public void Update(Transaction entity)
        {
            throw new NotImplementedException();
        }

        public void Payment(AccountPaymentDto accountPaymentDto)
        {
            Transaction transaction = new Transaction();
            Account account = new Account();
            if (TransactionIsNull(EntityList) == true)
            {
                CreateTransactionTable();
            }
            transaction.TransactionType = TransactionTypes.payment;
            transaction.RecipientNumber = accountPaymentDto.RecipientNumber;
            transaction.SenderNumber = accountPaymentDto.SenderNumber;
            transaction.Amount = accountPaymentDto.Amount;
            transaction.TransactionDate= DateTime.Now;
            EntityList.Add(transaction);
            List<Account> accountList=_accountDal.GetAll();
            account.Balance=accountList.Where(a=>a.AccountNumber==accountPaymentDto.SenderNumber).FirstOrDefault().Balance;
            account.AccountNumber = accountPaymentDto.SenderNumber;
            account.Balance = account.Balance - accountPaymentDto.Amount;
            _accountDal.Update(account);
            account.Balance = accountList.Where(a => a.AccountNumber == accountPaymentDto.RecipientNumber).FirstOrDefault().Balance;
            account.AccountNumber = accountPaymentDto.RecipientNumber;
            account.Balance = account.Balance + accountPaymentDto.Amount;
            _accountDal.Update(account);
        }

        public void WithDraw(AccountWithDrawDto accountWithDrawDto)
        {
            Transaction transaction = new Transaction();
            Account account = new Account();
            if (TransactionIsNull(EntityList) == true)
            {
                CreateTransactionTable();
            }
            transaction.TransactionType = TransactionTypes.withdraw;
            transaction.RecipientNumber = accountWithDrawDto.OwnerNumber;
            transaction.SenderNumber = accountWithDrawDto.OwnerNumber;
            transaction.Amount = accountWithDrawDto.Amount;
            transaction.TransactionDate = DateTime.Now;
            EntityList.Add(transaction);
            _accountDal.GetAll();
            account.AccountNumber = accountWithDrawDto.OwnerNumber;
            account.Balance = account.Balance - accountWithDrawDto.Amount;
            _accountDal.Update(account);
        }
        public void Deposit(AccountWithDepositDto accountWithDepositDto)
        {
            Transaction transaction = new Transaction();
            Account account = new Account();
            if (TransactionIsNull(EntityList) == true)
            {
                CreateTransactionTable();
            }
            transaction.TransactionType = TransactionTypes.withdraw;
            transaction.RecipientNumber = accountWithDepositDto.OwnerNumber;
            transaction.SenderNumber = accountWithDepositDto.OwnerNumber;
            transaction.Amount = accountWithDepositDto.Amount;
            transaction.TransactionDate = DateTime.Now;
            EntityList.Add(transaction);
            _accountDal.GetAll();
            account.AccountNumber = accountWithDepositDto.OwnerNumber;
            account.Balance = account.Balance + accountWithDepositDto.Amount;
            _accountDal.Update(account);
        }
    }
}
