using Stable.Core.Entities.Abstract;

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
