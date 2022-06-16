using Stable.Core.Utilities.Results.ComplexTypes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Core.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; } //ResultStatus.Success or ResultStatus.Error etc.
        public string Message { get; }
        public Exception Exception { get; }
    }
}
