using Core.Entities;

namespace Entities
{
    public class AccountWithDrawDto:IDto
    {
        public int OwnerNumber { get; set; }
        public int Amount { get; set; }
    }
}