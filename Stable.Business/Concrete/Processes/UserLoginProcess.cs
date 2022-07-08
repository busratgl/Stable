using Stable.Business.Abstract.Caching;
using Stable.Business.Abstract.Processes;
using Stable.Business.Concrete.Helpers;
using Stable.Business.Concrete.Requests;
using Stable.Business.Concrete.Responses.UserLoginDto;
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
        private readonly ICacheService _cacheService;

        public UserLoginProcess(IUnitOfWork unitOfWork, ICacheService cacheService)
        {
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;
        }

        public async Task<UserLoginDto> ExecuteAsync(UserLoginRequest userLoginRequest, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetAsync(u => u.Emails.Any(u => u.IsActiveEmailAddress && u.EmailAddress == userLoginRequest.Email)
            && u.Passwords.Any(u => u.IsActivePassword && u.PasswordText == userLoginRequest.Password));

            if (user == null)
            {
                throw new Exception("Bu email adresine sahip kullanıcı sistemde kayıtlı değildir.");
            }

            var key = "UserLoginProcess:" + userLoginRequest.Email + userLoginRequest.Password;
            var isExist = await _cacheService.KeyExistAsync(key);

            if (isExist)
            {
                var cacheResult = await _cacheService.GetAsync<UserLoginDto>(key);
                return cacheResult;
            }

            var token = TokenHelper.GenerateAccessToken(user.Id);


            var result = new UserLoginDto()
            {

                Token = token,

            };

            await _cacheService.SetAsync(key, result);
            return result;
          

        }
    }
}
