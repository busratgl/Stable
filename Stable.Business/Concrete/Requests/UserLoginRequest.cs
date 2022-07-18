namespace Stable.Business.Concrete.Requests
{
    public class UserLoginRequest
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string RemoteIpAddress { get; set; }
    }
}
