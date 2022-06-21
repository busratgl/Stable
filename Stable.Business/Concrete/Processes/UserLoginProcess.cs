using Stable.Business.Abstract.Processes;
using Stable.Business.Concrete.Helpers;
using Stable.Business.Concrete.Requests;
using Stable.Business.Concrete.Responses;
using Stable.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stable.Business.Concrete.Processes
{
    public class UserLoginProcess : IUserLoginProcess
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserLoginProcess(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserLoginDto> ExecuteAsync(UserLoginRequest userLoginRequest, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetAsync(u => u.Emails.Any(d => d.IsActiveEmailAddress && d.EmailAddress == userLoginRequest.Email)
            && u.Passwords.Any(d => d.IsActivePassword && d.PasswordText == userLoginRequest.Password));

            if (user == null)
            {
                throw new Exception("Bu email adresine sahip kullanıcı sistemde kayıtlı değildir.");
            }

            var token = TokenHelper.GenerateAccessToken(user.Id);

            return new UserLoginDto()
            {
                Token = token,
            };
        }
    }
}
