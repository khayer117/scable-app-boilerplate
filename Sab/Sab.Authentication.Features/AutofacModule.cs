using Autofac;
using Microsoft.AspNetCore.Authorization;
using Sab.Authentication.Features.Provider;
using Sab.Authentication.Features.Services;
using Sab.Infrastructure;

namespace Sab.Authentication.Features
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            //containerBuilder.Register<ProcessorA>();
            containerBuilder.Register<UserService>();
            containerBuilder.Register<UserInfoProvider>();

            //services.AddSingleton<IAuthorizationHandler, EmployeeWithMoreYearsHandler>();
            containerBuilder.RegisterType<SeniorEmployeeRequirementHandler>().As<IAuthorizationHandler>();
        }
    }
}
