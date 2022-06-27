using Stable.Business.Abstract.Processes;
using Stable.Business.Concrete.Helpers;
using Stable.Business.Concrete.Requests;
using Stable.Business.Concrete.Responses;
using Stable.Business.Concrete.Responses.GetMyAccountDto;
using Stable.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stable.Business.Concrete.Processes
{
    public class GetMyAccountProcess : IGetMyAccountProcess
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMyAccountProcess(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetMyAccountDto> ExecuteAsync(GetMyAccountRequest getMyAccountRequest, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetAsync(u => u.Id == getMyAccountRequest.UserId && u.Accounts.Any(u => u.IsActiveAccount && u.Id == getMyAccountRequest.UserId));


            if (user.Accounts == null)
            {
                throw new Exception("Hesap bilgileriniz görüntülenememektedir.");
            }

            var result = new GetMyAccountDto();
            result.UserId = getMyAccountRequest.UserId;

            return result;


        }

       
    }
}


