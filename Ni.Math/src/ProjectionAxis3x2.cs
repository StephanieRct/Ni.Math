using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{

    /// <summary>
    /// Represent a shear of a 2d vector then a projection onto a Plane3.
    /// Transformation sequence: Projection3x1 * Shear2
    /// </summary>
    [Serializable]
    public struct ProjectionAxis3x2
    {
        public float3 xAxis;
        public float3 yAxis;
        public float3 this[float2 o] => xAxis * o.x + yAxis * o.y;
        public ProjectionAxis3x2(float3 xAxis, float3 yAxis)
        {
            this.xAxis = xAxis;
            this.yAxis = yAxis;
        }
        public ProjectionAxis2x3 Inverse => new ProjectionAxis2x3(xAxis, yAxis);
    }
}