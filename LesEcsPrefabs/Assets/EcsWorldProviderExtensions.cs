using UnityEngine;
using Wargon.LeoEcsExtention.Unity;

namespace LesEcsPrefabs.Unity
{
    public static class EcsWorldProviderExtensions
    {
        public static void Instantiate<T>(
            this EcsWorldProvider worldProvider,
            T obj,
            Transform parent = null,
            Vector3? position = null,
            Quaternion? rotation = null
        ) where T : Component
        {
            T o;
            if (rotation.HasValue && position.HasValue)
            {
                if (parent)
                {
                    o = Object.Instantiate(obj, position.Value, rotation.Value, parent);
                }
                else
                {
                    o = Object.Instantiate(obj, position.Value, rotation.Value);
                }
            }
            else if (parent)
            {
                o = Object.Instantiate(obj, parent);
            }
            else
            {
                o = Object.Instantiate(obj);
            }

            var monoEntity = o.GetComponent<MonoEntity>();
            if (monoEntity)
            {
                monoEntity.ConvertToEntity();
            }
            else
            {
                var addedMonoEntity = o.gameObject.AddComponent<MonoEntity>();
                addedMonoEntity.worldProvider = worldProvider;
                addedMonoEntity.ConvertToEntity();
            }
        }
        
        public static void Instantiate(
            this EcsWorldProvider worldProvider,
            GameObject obj,
            Transform parent = null,
            Vector3? position = null,
            Quaternion? rotation = null
        )
        {
            GameObject o;
            if (rotation.HasValue && position.HasValue)
            {
                if (parent)
                {
                    o = Object.Instantiate(obj, position.Value, rotation.Value, parent);
                }
                else
                {
                    o = Object.Instantiate(obj, position.Value, rotation.Value);
                }
            }
            else if (parent)
            {
                o = Object.Instantiate(obj, parent);
            }
            else
            {
                o = Object.Instantiate(obj);
            }

            var monoEntity = o.GetComponent<MonoEntity>();
            if (monoEntity)
            {
                monoEntity.ConvertToEntity();
            }
            else
            {
                var addedMonoEntity = o.AddComponent<MonoEntity>();
                addedMonoEntity.worldProvider = worldProvider;
                addedMonoEntity.ConvertToEntity();
            }
        }
    }
}