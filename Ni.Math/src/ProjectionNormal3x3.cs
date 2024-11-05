using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    /// <summary>
    /// Project 3d vector onto a plane around origin (0,0,0) defined by its Normal.
    /// Not invertible.
    /// </summary>
    [Serializable]
    public struct ProjectionNormal3x3
    {
        public float3 normal;
        // https://math.stackexchange.com/questions/100761/how-do-i-find-the-projection-of-a-point-onto-a-plane
        // NxOx-NyOy-NzOz / My^2+Ny^2+Nz^2.
        // dot(N, O) / dot(N,N)
        public float3 this[float3 o] => o + normal * math.dot(-normal, o) / math.dot(normal, normal);
        public ProjectionNormal3x3(float3 normal)
        {
            this.normal = normal;
        }
    }
}