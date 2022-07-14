using Stable.Core.Enums;
using Stable.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Business.Concrete.Responses.GetMyAccountDto
{
    public class GetMyAccountDto
    {
        public GetMyAccountDto()
        {
            this.Accounts = new List<AccountDto>();
        }
        public List<AccountDto> Accounts { get; set; }
    }
}
