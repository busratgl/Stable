using Stable.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Entity.Concrete
{
    public class Password : EntityBase
    {
        public string PasswordText { get; set; }
        public bool IsActivePassword { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }
    }
}
