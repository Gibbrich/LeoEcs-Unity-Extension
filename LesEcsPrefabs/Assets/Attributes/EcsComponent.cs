using System;

namespace LesEcsPrefabs.Assets.Attributes
{
    [AttributeUsage(AttributeTargets.Struct)]
    public sealed class EcsComponentAttribute : Attribute
    {
        public EcsComponentAttribute(){}
    }
}
