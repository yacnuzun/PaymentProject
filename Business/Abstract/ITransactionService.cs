using Core.Utilities.Results;
using Entities;
using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITransactionService
    {
        IDataResult<List<Transaction>> GetAll();
        IDataResult<List<Transaction>> GetAllByOwnerId(int id);
        IResult Payment(AccountPaymentDto accountPaymentDto);
        IResult Deposit(Transaction transaction);
        IResult WithDraw(AccountWithDrawDto accountWithDrawDto);
    }
}
