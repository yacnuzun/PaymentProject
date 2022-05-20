using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AccountManager : IAccountService
    {
        IAccountDal _accountDal;

        public AccountManager(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }

        public IDataResult<List<Account>> GetAll()
        {
            return new SuccessDataResult<List<Account>>(_accountDal.GetAll());
        }
    }
}
