using Core.Entities;

namespace Entities
{
    public class AccountWithDepositDto:IDto
    {
        public int OwnerNumber { get; set; }
        public int Amount { get; set; }
    }
}