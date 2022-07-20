
using Stable.Core.Utilities.Results.Abstract;
using Stable.Core.Utilities.Results.ComplexTypes.Enums;
using System;

namespace Stable.Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }
        public Result(ResultStatus resultStatus, string message)
        {
            ResultStatus = resultStatus;
            Message = message;
        }

        public Result(ResultStatus resultStatus, string message, string errorCode)
        {
            ResultStatus = resultStatus;
            Message = message;
            ErrorCode = errorCode;

        }

        public Result(ResultStatus resultStatus, string message, Exception exception)
        {
            ResultStatus = resultStatus;
            Message = message;
            Exception = exception;
        }

        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }
        public string ErrorCode { get; set; }
    }
}
