using System.Reflection;
using Tools.Cqs;
using Tools.Cqs.Commands;
using Tools.Cqs.Queries;

namespace DemoCqsWithDispatcher.Infrastructure
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHandlersAndDispatcher(this IServiceCollection services)
        {
            Assembly mainAssembly = Assembly.GetEntryAssembly()!;
            IEnumerable<Type> handlers = mainAssembly.GetTypes()
                .Union(mainAssembly.GetReferencedAssemblies().SelectMany(an => Assembly.Load(an).GetTypes()))
                .Where(t => t.GetInterfaces().Any(i => IsHandler(i)) && t.Name.EndsWith("Handler")).ToArray();

            foreach (Type type in handlers)
            {
                Type interfaceType = type.GetInterfaces().Single(IsHandler);
                services.AddScoped(interfaceType, type);
            }

            //Ajoute directement le Dispatcher
            services.AddScoped<IDispatcher, Dispatcher>();
            return services;
        }

        private static bool IsHandler(Type type)
        {
            if (!type.IsGenericType)
                return false;

            Type[] cqrsHandlers = { typeof(ICommandHandler<>), typeof(IQueryHandler<,>) };

            Type typeDefinition = type.GetGenericTypeDefinition();
            return cqrsHandlers.Contains(typeDefinition);
        }
    }
}
