using Castle.DynamicProxy;

namespace Stable.Business.Concrete.Autofac
{
    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            System.Diagnostics.Debug.WriteLine(invocation.Proxy + "Started");
            invocation.Proceed();
            System.Diagnostics.Debug.WriteLine(invocation.Proxy + "Finished");
        }
    }
}
