using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stable.Business.Abstract.Processes;
using Stable.Business.Concrete.Processes;
using Stable.Business.Concrete.Requests;
using Stable.Business.Concrete.Responses;
using Stable.Business.Concrete.Responses.GetMyAccountDto;
using Stable.Business.Requests;
using Stable.Core.Utilities.Results.Concrete;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Stable.API.Controllers
{

    public class UsersController : BaseController
    {
        private readonly IUserRegisterProcess _userRegisterProcess;
        private readonly IUserLoginProcess _userLoginProcess;
        private readonly IGetMyAccountProcess _getMyAccountProcess;

        public UsersController(IUserRegisterProcess userRegisterProcess, IUserLoginProcess userLoginProcess, IGetMyAccountProcess getMyAccountProcess)
        {
            _userRegisterProcess = userRegisterProcess;
            _userLoginProcess = userLoginProcess;
            _getMyAccountProcess = getMyAccountProcess;

        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<DataResult<UserRegisterDto>> Register([FromBody] UserRegisterRequest userRegisterRequest, CancellationToken cancellationToken)
        {
            var result = await _userRegisterProcess.ExecuteAsync(userRegisterRequest, cancellationToken);
            return new DataResult<UserRegisterDto>(Core.Utilities.Results.ComplexTypes.Enums.ResultStatus.Success, result);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<DataResult<UserLoginDto>> Login([FromBody] UserLoginRequest userLoginRequest, CancellationToken cancellationToken)
        {
            var result = await _userLoginProcess.ExecuteAsync(userLoginRequest, cancellationToken);
            return new DataResult<UserLoginDto>(Core.Utilities.Results.ComplexTypes.Enums.ResultStatus.Success, result);
        }


        [HttpGet("getMyAccount")]
        [Authorize]
        public async Task<DataResult<GetMyAccountDto>> GetMyAccount(CancellationToken cancellationToken)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = long.Parse(identity.Claims.FirstOrDefault(u => u.Type == "userId").Value);

            var getMyAccountRequest = new GetMyAccountRequest();
            getMyAccountRequest.UserId = userId;

            var result = await _getMyAccountProcess.ExecuteAsync(getMyAccountRequest, cancellationToken);
            return new DataResult<GetMyAccountDto>(Core.Utilities.Results.ComplexTypes.Enums.ResultStatus.Success, result);
        }
    }
}
