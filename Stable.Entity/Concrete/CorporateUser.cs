using Stable.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Entity.Concrete
{
    public class CorporateUser : EntityBase
    {
        public long TaxNumber { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }
    }
}
