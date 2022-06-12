using Stable.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Entity
{
    public class Corporate : EntityBase
    {
        public long TaxNumber { get; set; }
        public string Name { get; set; }

    }
}
