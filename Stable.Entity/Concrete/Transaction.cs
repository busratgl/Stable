using Stable.Core.Entities.Abstract;

namespace Stable.Entity.Concrete
{
    public class Transaction : EntityBase
    {
        public string Description { get; set; }
        public Account Account { get; set; }
        public long AccountId { get; set; }
    }
}
