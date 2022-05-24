using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity
{
    public enum TransactionTypes
    {
        payment,
        deposit,
        withdraw
    }
    public class Transaction:IEntity
    {
        [Key]
        public int TransactionId { get; set; }
        public TransactionTypes TransactionType { get; set; }
        public int SenderNumber { get; set; }
        public int RecipientNumber { get; set; }
        public int Amount { get; set; }
        public DateTime TransactionDate { get; set; }

    }
}
