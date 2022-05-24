using Core.DataAccess;
using Core.Entities;
using Entities;
using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ITransactionDal:IEntityRepository<Transaction>
    {
        void Deposit(AccountWithDepositDto accountWithDepositDto);
        List<Transaction> GetAllByOwnerId(int id);
        void Payment(AccountPaymentDto accountPaymentDto);
        void WithDraw(AccountWithDrawDto accountWithDrawDto);
    }
}
