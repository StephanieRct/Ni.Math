using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    [Serializable]
    public struct Plane3x3
    {
        public float3 Translation;
        public ProjectionNormal3x3 Projection;

        // https://math.stackexchange.com/questions/100761/how-do-i-find-the-projection-of-a-point-onto-a-plane
        // t= NxTx-NxOx + NyTy-NyOy + NzTz-NzOz
        //    ---------------------------------
        //              a2+b2+c2.
        // t= Nx(Tx-Ox) + Ny(Ty-Oy) + Nz(Tz-Oz)
        //    ---------------------------------
        //              a2+b2+c2.
        // t= dot(N, T - O) / dot(N, N)
        // r= (Ox + tNx, Oy + tNy, Oz + tNz)
        // r= O + t * N;
        // r= O + N * dot(N, T - O) / dot(N, N);
        // Combining:
        // r= Translation + Projection[o - Translation];
        // r= Translation + (o - Translation) + Normal * math.dot(-Normal, (o - Translation)) / math.dot(Normal, Normal);
        // r= o + Normal * math.dot(-Normal, (o - Translation)) / math.dot(Normal, Normal);
        // r= o + Normal * math.dot(Normal, Translation - o) / math.dot(Normal, Normal);
        // r= O + N * dot(N, T - O) / dot(N, N);
        public float3 this[float3 o] => o + Projection.normal * math.dot(Projection.normal, Translation - o) / math.dot(Projection.normal, Projection.normal); //Translation + Projection[o - Translation];
    }
}