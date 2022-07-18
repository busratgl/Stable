using Autofac;
using Autofac.Extras.DynamicProxy;
using Stable.Business.Abstract.Processes;
using Stable.Business.Concrete.Processes;

namespace Stable.Business.Concrete.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoggingInterceptor>();

            builder.RegisterType<UserRegisterProcess>().As<IUserRegisterProcess>().InstancePerLifetimeScope();
            builder.RegisterType<UserLoginProcess>().As<IUserLoginProcess>().InstancePerLifetimeScope();

            builder.RegisterType<CurrencyExchangeRateProcess>()
                .As<ICurrencyExchangeRateProcess>().InstancePerLifetimeScope();

            builder.RegisterType<GetMyAccountProcess>().As<IGetMyAccountProcess>().InstancePerLifetimeScope()
                .EnableInterfaceInterceptors().InterceptedBy(typeof(LoggingInterceptor));

            builder.RegisterType<BuyingCurrencyProcess>().As<IBuyingCurrencyProcess>().InstancePerLifetimeScope();
            builder.RegisterType<CreateAccountProcess>().As<ICreateAccountProcess>().InstancePerLifetimeScope();
            builder.RegisterType<GetMyTransactionProcess>().As<IGetMyTransactionProcess>().InstancePerLifetimeScope();

        }
    }
}
