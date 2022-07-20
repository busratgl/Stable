namespace Stable.Business.Concrete.Exceptions
{
    public class LoginException : CustomBaseException
    {
        public LoginException(string message, string errorCode) : base(message, errorCode)
        {

        }
    }
}
