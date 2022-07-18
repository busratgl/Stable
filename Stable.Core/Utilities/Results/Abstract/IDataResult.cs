using Stable.Core.Utilities.Results.Abstract;

namespace Stable.Core.Utilities.Results
{
    public interface IDataResult<out T> : IResult
    {
        public T Data { get; }
    }
}
