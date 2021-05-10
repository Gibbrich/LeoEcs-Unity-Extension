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
    }
}