using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Leopotam.Ecs.UnityIntegration;

namespace Wargon.LeoEcsExtention.Unity
{
    [DisallowMultipleComponent]
    public class MonoEntity : MonoBehaviour
    {
        public EcsEntity entity;
        public EcsWorldProvider worldProvider;
        [HideInInspector] public int lastIndex = 0;
        [SerializeReference] public List<object> Components = new List<object>();
        public int ComponentsCount => Components.Count;
        public bool runTime;
        public bool destroyObject;
        public bool destroyComponent;
        private bool converted;

        private void Start()
        {
            ConvertToEntity();
        }

        public void ConvertToEntity()
        {
            if (converted) return;
            var world = worldProvider.world;
            entity = world.NewEntity();

            MonoConverter.Execute(ref entity, Components);
            
#if UNITY_EDITOR
            var ecsEntityObserver = gameObject.AddComponent<EcsEntityObserver>();
            ecsEntityObserver.Entity = entity;
            ecsEntityObserver.World = world;
#endif
            
            converted = true;
            if (destroyComponent) Destroy(this);
            if (destroyObject) Destroy(gameObject);
            runTime = true;
        }

        public void Add<T>(T component) where T : struct
        {
            entity.Replace(component);
        }

        private void OnDestroy()
        {
            if (!destroyObject && worldProvider.world.IsAlive())
            {
                entity.Destroy();
            }
        }

        public void DestroyWithoutEntity()
        {
            destroyObject = true;
            Destroy(this.gameObject);
        }
    }
}