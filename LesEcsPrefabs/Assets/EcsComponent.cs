using System;

namespace LesEcsPrefabs.Assets
{
    [AttributeUsage(AttributeTargets.Struct)]
    public sealed class EcsComponentAttribute : Attribute
    {
        public EcsComponentAttribute(){}
    }
}
