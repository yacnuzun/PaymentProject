using Business.Abstract;
using Core.DataAccess.EntityFramework;
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
    public class AccountManager :IAccountService
    {
        IAccountDal _accountDal;
        public AccountManager(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }
        
        public IResult Add(Account account)
        {
            
            _accountDal.Add(account);
            return new SuccessResult("Başarılı");
        }

        public IDataResult<Account> Get(int id)
        {
            return new SuccessDataResult<Account>(_accountDal.Get(id));
        }

        public IDataResult<List<Account>> GetAll()
        {
            
            return new SuccessDataResult<List<Account>>(_accountDal.GetAll());
        }

    }
}
