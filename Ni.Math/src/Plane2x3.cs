using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    [Serializable]
    public struct Plane2x3
    {
        public float3 Translation;
        public ProjectionAxis2x3 Projection;
        // https://stackoverflow.com/questions/18663755/how-to-convert-a-3d-point-on-a-plane-to-uv-coordinates
    }
}