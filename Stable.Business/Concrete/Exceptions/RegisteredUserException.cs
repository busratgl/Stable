namespace Stable.Business.Concrete.Exceptions
{
    public class RegisteredUserException : CustomBaseException
    {
        public RegisteredUserException(string message, string errorCode) : base(message, errorCode)
        {

        }
    }
}
