using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity
{

    public enum accountype
    {
        bireysel,
        kurumsal,
    }
    public enum currencycode
    {
        TRY,
        USD,
        EUR,
    }
    public class Account:IEntity
    {
        public int AccountNumber { get; set; }
        public string OwnerName { get; set; }
        public int Balance { get; set; }
        public accountype accountype { get; set; }
        public currencycode currencycode { get; set; }
    }
}
