using Autofac;
using Autofac.Builder;
using Autofac.Features.Scanning;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Sab.Infrastructure
{
    public static class ContainerBuilderExtensions
    {
        public static
            IRegistrationBuilder<TService, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            Register<TService>(this ContainerBuilder instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            return instance.RegisterType<TService>()
                .AsSelf()
                .AsImplementedInterfaces();
        }

        public static
            IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle>
            RegisterClosingTypes(this ContainerBuilder instance, Type type, params Assembly[] assemblies)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            return instance.RegisterAssemblyTypes(assemblies)
                .AsSelf()
                .AsClosedTypesOf(type)
                .AsImplementedInterfaces();
        }
    }
}
