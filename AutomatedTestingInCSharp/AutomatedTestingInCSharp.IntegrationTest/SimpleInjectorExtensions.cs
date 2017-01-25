using System;
using System.Linq;
using SimpleInjector;

namespace AutomatedTestingInCSharp.IntegrationTest
{
    internal static class SimpleInjectorExtensions
    {
        internal static void RegisterAllFromAssemblyOf<T>(this Container container, Func<Type, bool> additionalCondition)
            where T : class
        {
            Action<Type> registerInterfaces =
                type =>
                    type.GetInterfaces().ToList().ForEach(interfaceType => Registrar(container, interfaceType, type));

            typeof(T).Assembly
                .GetExportedTypes()
                .Where(type => type.IsClass && !type.IsAbstract && !type.IsGenericType && !type.FullName.EndsWith("Map"))
                .Where(additionalCondition)
                .ToList()
                .ForEach(registerInterfaces);
        }

        private static void Registrar(Container container, Type interfaceType, Type type)
        {
            container.Register(interfaceType, type);
        }
    }
}
