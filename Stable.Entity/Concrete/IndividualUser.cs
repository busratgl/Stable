using Stable.Core.Entities.Abstract;
using System;

namespace Stable.Entity.Concrete
{
    public class IndividualUser : EntityBase
    {
        public long IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }
    }
}
