using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sab.Infrastructure
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var assemblies = AssembliesProvider.Instance.Assemblies.ToArray();

            builder.Register<Func<Type, object>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();
                return ctx.Resolve;
            });

            builder.RegisterClosingTypes(typeof(ICommandHandler<,>), assemblies).PreserveExistingDefaults();
            
            RegisterServices(builder);
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.Register<CommandBus>();
        }
    }
}
