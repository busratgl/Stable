using Stable.Core.Entities.Abstract;

namespace Stable.Entity.Concrete
{
    public class UserIpAddress : EntityBase
    {
        public string RemoteIpAddress { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }
    }
}
