#if NIMATHEXPERIMENTAL
using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    /// <summary>
    /// Represent the projection onto a 3d axis vector from origin (0,0,0) to a float3 Vector value.
    /// The result 3d vector is the closest point along the axis vector to the input vector.
    ///    y
    ///    |     * <--- Axis Vector value
    ///    |    /
    ///    |   *. <--- 3d vector projected onto the axis
    ///    |  /   ` .
    ///    | /        ` * <--- 3d vector will project onto the axis
    ///    |/
    ///    *-----------x
    ///    
    /// </summary>
    [Serializable]
    public struct ProjectionAxis3x3
    {
        public float3 axis;
        public float3 this[float3 o]
        {
            get => math.dot(o, axis) / math.length(axis) * axis;
        }
        public ProjectionAxis3x3(float3 dir)
        {
            axis = dir;
        }
        public ProjectionAxis3x1 Inverse => new ProjectionAxis3x1(axis);
    }
}
#endif