using Microsoft.AspNetCore.Mvc;
using Stable.API.Helpers;
using Stable.Business.Abstract.Processes;
using Stable.Business.Concrete.Processes;
using Stable.Business.Concrete.Responses;
using Stable.Business.Requests;
using Stable.Core.Utilities.Results.Concrete;
using System.Threading;
using System.Threading.Tasks;

namespace Stable.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRegisterProcess _userRegisterProcess;

        public UsersController(IUserRegisterProcess userRegisterProcess)
        {
            _userRegisterProcess = userRegisterProcess;

        }


        [HttpPost("register")]
        public async Task<DataResult<UserRegisterDto>> Register([FromBody] UserRegisterRequest userRegisterRequest, CancellationToken cancellationToken)
        {
            var result = await _userRegisterProcess.ExecuteAsync(userRegisterRequest, cancellationToken);
            return new DataResult<UserRegisterDto>(Core.Utilities.Results.ComplexTypes.Enums.ResultStatus.Success, result);
        }

        [HttpPost("login")]
        public DataResult<UserLoginDto> Login(CancellationToken cancellationToken)
        {

            var isExist = false;
            if (!isExist)
            {
                return new DataResult<UserLoginDto>(Core.Utilities.Results.ComplexTypes.Enums.ResultStatus.Error, null);
            }



            var token = TokenHelper.GenerateAccessToken();
            var userLoginDto = new UserLoginDto()
            {
                Token = token
            };

            return new DataResult<UserLoginDto>(Core.Utilities.Results.ComplexTypes.Enums.ResultStatus.Success, userLoginDto);



        }
    }
}
