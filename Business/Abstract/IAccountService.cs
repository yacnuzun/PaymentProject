using Core.Utilities.Results;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAccountService
    {
        IDataResult<List<Account>> GetAll();
        IDataResult<Account> Get(int id);
        IResult Add(Account account);
    }
}
