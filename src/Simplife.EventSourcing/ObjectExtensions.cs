using Simplife.Domain.Events;
using System.Reflection;

namespace Simplife.EventSourcing
{
    internal static class ObjectExtensions
    {
        public static void Apply(this object aggregate, IEvent @event)
        {
            var apply = GetApplyMethod(aggregate, @event);
            if (apply is null)
            {
                throw new ArgumentException("TODO");
            }

            apply!.Invoke(aggregate, new[] { @event });
        }

        private static MethodInfo? GetApplyMethod(object aggregate, IEvent @event) =>
            aggregate.GetType().GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(m => m.Name == "Apply")
                .SingleOrDefault(m => m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == @event.GetType());

    }
}
