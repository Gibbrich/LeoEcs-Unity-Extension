using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Leopotam.Ecs;

namespace Wargon.LeoEcsExtention.Unity {
    public static class MonoConverter {
        private static EcsWorld world;
        public static bool HasWorld => world != null;
        private static MethodInfo getMethod;
        public static void Init(EcsWorld ecsWorld) 
        {
            world = ecsWorld;
            getMethod = typeof(EcsEntityExtensions).GetMethods().First(x => x.Name == "Get");
        }
        public static EcsWorld GetWorld()
        {
            return world;
        }

        public static void Execute(ref EcsEntity entity, List<object> components) {
            foreach (var component in components) {

                switch (component)
                {
                    //START

                    //END
                }

            }
        }
    }
}


