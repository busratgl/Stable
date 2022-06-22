using Stable.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Business.Requests
{
    public class UserRegisterRequest
    {
        public long IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string AddressName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
        public string AccountName { get; set; }
        public long AccountTypeId { get; set; }
        public long CurrencyTypeId { get; set; }
        public string CorporateName { get; set; }
        public long TaxNumber { get; set; }

    }
}
