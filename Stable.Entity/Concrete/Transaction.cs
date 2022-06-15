using Stable.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Entity.Concrete
{
    public class Transaction : EntityBase
    {
        public string Description { get; set; }
        public Account Account { get; set; }
        public long AccountId { get; set; }
    }
}
