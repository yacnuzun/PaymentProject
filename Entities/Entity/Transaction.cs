using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity
{
    public class Transaction:IEntity
    {
        [Key]
        public int TransactionId { get; set; }
        public int TransactionTypeId { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public int Amount { get; set; }

    }
}
