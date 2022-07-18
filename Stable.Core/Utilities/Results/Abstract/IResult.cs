using Stable.Core.Utilities.Results.ComplexTypes.Enums;

namespace Stable.Core.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; }
        public string Message { get; }

    }
}
