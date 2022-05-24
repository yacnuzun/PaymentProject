using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TransactionManager : ITransactionService
    {
        ITransactionDal _transactionDal;

        public TransactionManager(ITransactionDal transactionDal)
        {
            _transactionDal = transactionDal;
        }

        public IResult Deposit(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Transaction>> GetAll()
        {
            return new SuccessDataResult<List<Transaction>>(_transactionDal.GetAll());
        }
        public IDataResult<List<Transaction>> GetAllByOwnerId(int id)
        {
            
            return new SuccessDataResult<List<Transaction>>(_transactionDal.GetAllByOwnerId(id));
        }

        public IResult Payment(AccountPaymentDto accountPaymentDto)
        {
            _transactionDal.Payment(accountPaymentDto);
            return new SuccessResult("Success");
        }

        public IResult WithDraw(AccountWithDrawDto accountWithTransactionDto)
        {
            _transactionDal.WithDraw(accountWithTransactionDto);
            return new SuccessResult("Success");
        }
    }
}
