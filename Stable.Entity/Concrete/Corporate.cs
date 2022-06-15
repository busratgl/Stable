using Stable.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Entity.Concrete
{
    public class Corporate : EntityBase
    {
        public long TaxNumber { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }

    }
}
