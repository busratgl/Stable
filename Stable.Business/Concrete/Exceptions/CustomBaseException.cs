using System;

namespace Stable.Business.Concrete.Exceptions
{
    public class CustomBaseException : Exception
    {
        public CustomBaseException(string message, string errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }

        public string ErrorCode { get; set; }
    }
}
