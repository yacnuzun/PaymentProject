using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity
{
    public class Owner:IEntity
    {
        [Key]
        public int OwnerId { get; set; }
        public string? OwnerName { get; set; }

    }
}
