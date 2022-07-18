using Stable.Core.Entities.Abstract;
using System.Collections.Generic;

namespace Stable.Entity.Concrete
{
    public class CurrencyType : EntityBase
    {
        public string Name { get; set; }
        public List<Balance> Balances { get; set; }
    }
}
