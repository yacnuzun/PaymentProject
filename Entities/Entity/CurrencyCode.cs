using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity
{
    public class CurrencyCode:IEntity
    {
        [Key]
        public int CurrencyCodeId { get; set; }
        public string? CurrencyCodeName { get; set; }
    }
}
