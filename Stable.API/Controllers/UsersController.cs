using Microsoft.AspNetCore.Mvc;
using Stable.API.Helpers;
using Stable.Business.Requests;
using Stable.Business.Responses;
using Stable.Core.Utilities.Results.Concrete;
using System.Threading;

namespace Stable.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost("register")]
        public Result Register([FromBody]UserRegisterRequest userRegisterRequest, CancellationToken cancellationToken)
        {
            return new Result(Core.Utilities.Results.ComplexTypes.Enums.ResultStatus.Success);
        }

        [HttpPost("login")]
        public DataResult<UserLoginDto> Login(CancellationToken cancellationToken)
        {

            var isExist = false;
            if(!isExist)
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
