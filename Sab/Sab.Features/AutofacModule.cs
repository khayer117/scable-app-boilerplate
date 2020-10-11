using Autofac;
using Sab.Infrastructure;
using Sab.ProductListing.Features.Processors;

namespace Sab.ProductListing.Features
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.Register<ProcessorA>();
            containerBuilder.Register<ProcessorB>();

            //containerBuilder.Register<ProcessorA>().As<IBatchProcessor>();
            //containerBuilder.Register<ProcessorB>().As<IBatchProcessor>();

            containerBuilder.Register<ServiceExecutor>();

        }
    }
}
