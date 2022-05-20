using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity
{
    public class Account:IEntity
    {
        [Key]
        public int AccountNumber { get; set; }
        public int OwnerId { get; set; }
        public int CurrencyCodeId { get; set; }
        public int AccountTypeId { get; set; }
    }
}
