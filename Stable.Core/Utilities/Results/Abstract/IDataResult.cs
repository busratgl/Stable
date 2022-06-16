using Stable.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Core.Utilities.Results
{
    public interface IDataResult<out T> : IResult
    {
        public T Data { get; } // new DataResult<Account> (ResultStatus.Success, account);
                               // new DataResult<IList<Account>>(ResultStatus.Success, accountList);
    }
}
