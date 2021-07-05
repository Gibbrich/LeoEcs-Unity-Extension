using System;
using Leopotam.Ecs;
using UnityEngine;

namespace Wargon.LeoEcsExtention.Unity
{
    [CreateAssetMenu(menuName = "ECS/EcsWorldProvider", order = 0)]
    public class EcsWorldProvider : ScriptableObject
    {
        [NonSerialized]
        public EcsWorld world;

        private void OnEnable()
        {
            world = new EcsWorld();
        }

        public void CreateInstance<T>(
            T prefab,
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
                    o = Instantiate(prefab, position.Value, rotation.Value, parent);
                }
                else
                {
                    o = Instantiate(prefab, position.Value, rotation.Value);
                }
            }
            else if (parent)
            {
                o = Instantiate(prefab, parent);
            }
            else
            {
                o = Instantiate(prefab);
            }

            var monoEntity = o.GetComponent<MonoEntity>();
            if (monoEntity)
            {
                monoEntity.ConvertToEntity(world);
            }
            else
            {
                var addedMonoEntity = o.gameObject.AddComponent<MonoEntity>();
                addedMonoEntity.worldProvider = this;
                addedMonoEntity.ConvertToEntity(world);
            }
        }
        
        public void CreateInstance(
            GameObject prefab,
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
                    o = Instantiate(prefab, position.Value, rotation.Value, parent);
                }
                else
                {
                    o = Instantiate(prefab, position.Value, rotation.Value);
                }
            }
            else if (parent)
            {
                o = Instantiate(prefab, parent);
            }
            else
            {
                o = Instantiate(prefab);
            }

            var monoEntity = o.GetComponent<MonoEntity>();
            if (monoEntity)
            {
                monoEntity.ConvertToEntity(world);
            }
            else
            {
                var addedMonoEntity = o.AddComponent<MonoEntity>();
                addedMonoEntity.ConvertToEntity(world);
            }
        }

    }
}