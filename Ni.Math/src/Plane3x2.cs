#if NIMATHEXPERIMENTAL
using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    [Serializable]
    public struct Plane3x2
    {
        public float3 Translation;
        public ProjectionAxis3x2 Projection;
        public float3 this[float2 uv] => Translation + Projection[uv];
    }
}
#endif