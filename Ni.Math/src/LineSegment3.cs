using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    [Serializable]
    public struct LineSegment3
    {
        public float3 a;
        public float3 b;
        public LineSegment3(float3 a, float3 b)
        {
            this.a = a;
            this.b = b;
        }

        public Aabb3M BoundingBox => new Aabb3M(this);
    }
}