using Castle.DynamicProxy;
using Stable.Business.Abstract.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Business.Concrete.Autofac
{
    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            System.Diagnostics.Debug.WriteLine(invocation.Proxy.ToString() + "Started");
            invocation.Proceed();
            System.Diagnostics.Debug.WriteLine(invocation.Proxy.ToString() + "Finished");
        }
    }
}
