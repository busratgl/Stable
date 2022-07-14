using Stable.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Entity.Concrete
{
    public class UserIpAddress : EntityBase
    {
        public string RemoteIpAddress { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }
    }
}
