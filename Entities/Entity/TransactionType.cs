using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity
{
    public class TransactionType:IEntity
    {
        [Key]
        public int TransactionTypeId { get; set; }
        public string? TransactionTypeName { get; set; }
    }
}
