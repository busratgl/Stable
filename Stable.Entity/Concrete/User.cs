using Stable.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Entity.Concrete
{
    public class User : EntityBase
    {
        public User()
        {
            this.Emails = new List<Email>();
            this.Accounts = new List<Account>();
            this.Addresses = new List<Address>();
            this.Passwords = new List<Password>();
        }
        public string PhoneNumber { get; set; }
        public List<Email> Emails { get; set; }
        public List<Account> Accounts { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Password> Passwords { get; set; }
        public CorporateUser CorporateUser { get; set; }
        public IndividualUser IndividualUser { get; set; }

    }
}
