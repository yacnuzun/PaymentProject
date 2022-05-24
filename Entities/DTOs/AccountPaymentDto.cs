using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AccountPaymentDto:IDto
    {
        public int SenderNumber { get; set; }
        public int RecipientNumber { get; set; }
        public int Amount { get; set; }
    }
}