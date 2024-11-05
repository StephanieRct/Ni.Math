using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    /// <summary>
    /// Represent a Projection and a Shear onto a Plane3 defined by 2 axis 
    /// vectors forming the U,V coordinates.
    ///    y
    ///    |     1 <--- V Axis Vector at V= 1, U= 0.
    ///    |    /
    ///    |   *  <--- Projected V value.
    ///    |  /  ` .
    ///    | /       ` .
    ///    |/           .* <--- 3d vector will project onto the 2 U, V axes.
    ///    0--------.-`-----------x
    ///     \   . `
    ///      *` <--- Projected U value.
    ///       \
    ///        \
    ///         1 <--- U Axis Vector at V= 0, U= 1.
    ///    
    /// Should be...
    /// 
    ///    y
    ///    |     1 <--- V Axis Vector at V= 1, U= 0.
    ///    |    /
    ///    |   *  <--- Projected V value.
    ///    |  / \ 
    ///    | /   \
    ///    |/     * <--- 3d vector will project onto the 2 U, V axes.
    ///    0-----/----------------x
    ///     \   /      
    ///      \ /       
    ///       *  <--- Projected U value.
    ///        \
    ///         1 <--- U Axis Vector at V= 0, U= 1.
    ///    
    /// </summary>
    [Serializable]
    public struct ProjectionAxis2x3
    {
        public float3 uAxis;
        public float3 vAxis;
        public float2 this[float3 o] => new float2(math.dot(o, uAxis), math.dot(o, vAxis));
        public ProjectionAxis2x3(float3 xAxis, float3 yAxis)
        {
            uAxis = xAxis;
            vAxis = yAxis;
        }
        public ProjectionAxis3x2 Inverse => new ProjectionAxis3x2(uAxis, vAxis);
    }
}