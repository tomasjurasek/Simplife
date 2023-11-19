using Simplife.Domain.Events;
using System.Reflection;

namespace Simplife.Core.Events
{
    internal class EventDispatcher
    {
        private static List<Type> _handlers = new();

        public static void Init()
        {
            InitHandlersFromAssembly();
        }

        private static void InitHandlersFromAssembly()
        {
            _handlers = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IEventHandler<>)))
                .ToList();
        }

        public static void Dispatch(IEvent @event)
        {
            foreach (var handlerType in _handlers)
            {
                if (CanHandleEvent(handlerType, @event))
                {
                    dynamic handler = Activator.CreateInstance(handlerType)!;
                    handler.Handle((dynamic)@event);
                }
            }
        }

        private static bool CanHandleEvent(Type handlerType, IEvent @event)
        {
            return handlerType.GetInterfaces()
                .Any(x => x.IsGenericType
                          && x.GetGenericTypeDefinition() == typeof(IEventHandler<>)
                          && x.GenericTypeArguments[0] == @event.GetType());
        }
    }
}
