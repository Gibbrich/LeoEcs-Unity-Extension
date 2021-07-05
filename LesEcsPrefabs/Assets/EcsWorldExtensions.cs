using Leopotam.Ecs;
using UnityEngine;
using Wargon.LeoEcsExtention.Unity;

namespace LesEcsPrefabs.Unity
{
    public static class EcsWorldExtensions
    {
        public static T Instantiate<T>(
            this EcsWorld world,
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
                monoEntity.ConvertToEntity(world);
            }
            else
            {
                o.gameObject.AddComponent<MonoEntity>().ConvertToEntity(world);
            }

            return o;
        }
        
        public static GameObject Instantiate(
            this EcsWorld world,
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
                monoEntity.ConvertToEntity(world);
            }
            else
            {
                o.AddComponent<MonoEntity>().ConvertToEntity(world);
            }

            return o;
        }
    }
}