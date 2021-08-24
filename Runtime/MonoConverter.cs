using System.Collections.Generic;
using System.Reflection;
using Leopotam.Ecs;

namespace Wargon.LeoEcsExtention.Unity
{
    public static class MonoConverter
    {
        private static readonly MethodInfo addComponent = typeof(Extensions).GetMethod("Add");

        public static void Execute(ref EcsEntity entity, IEnumerable<object> components)
        {
            foreach (var component in components)
            {
                var addComponentGeneric = addComponent.MakeGenericMethod(component.GetType());
                addComponentGeneric.Invoke(null, new[] {entity, component});
            }
        }
    }
}