namespace Stable.Business.Concrete.Exceptions
{
    public class InsufficientBalanceException : CustomBaseException
    {
        public InsufficientBalanceException(string message, string errorCode) : base(message, errorCode)
        {

        }
    }
}
