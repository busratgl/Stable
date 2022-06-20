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
        public string PhoneNumber { get; set; }
        public decimal Balance { get; set; }
        public List<Email> Emails { get; set; }
        public List<Account> Accounts { get; set; }
        public List<AccountType> AccountTypes { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Password> Passwords { get; set; }
        public List<CorporateUser> CorporateUsers { get; set; }
        public List<IndividualUser> IndividualUsers { get; set; }

    }
}
