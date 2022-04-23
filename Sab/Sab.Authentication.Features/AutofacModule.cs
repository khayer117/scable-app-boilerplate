using Autofac;
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
        }
    }
}
