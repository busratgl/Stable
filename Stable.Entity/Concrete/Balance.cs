using Stable.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Entity.Concrete
{
    public class Balance : EntityBase
    {
        public decimal Amount { get; set; }
        public Account Account { get; set; }
        public long AccountId { get; set; }
    }
}
