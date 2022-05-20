using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity
{
    public class AccountType:IEntity
    {
        [Key]
        public int AccountTypeId { get; set; }
        public string? AccountTypeName { get; set; }
    }
}
