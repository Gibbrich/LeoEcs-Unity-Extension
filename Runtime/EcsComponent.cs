using System;

namespace Wargon.LeoEcsExtention.Unity
{
    [AttributeUsage(AttributeTargets.Struct)]
    public sealed class EcsComponentAttribute : Attribute
    {
        public EcsComponentAttribute(){}
    }
}
