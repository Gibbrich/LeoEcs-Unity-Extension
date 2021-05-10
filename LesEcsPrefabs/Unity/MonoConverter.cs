using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DefaultNamespace;
using Leopotam.Ecs;
using UnityEngine;

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