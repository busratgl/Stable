using System.Collections.Generic;

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
