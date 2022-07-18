using Stable.Core.Entities.Abstract;

namespace Stable.Entity.Concrete
{
    public class Balance : EntityBase
    {
        public decimal Amount { get; set; }
        public Account Account { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public long CurrencyTypeId { get; set; }
    }
}
