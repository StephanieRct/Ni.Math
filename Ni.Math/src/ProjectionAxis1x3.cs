using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    /// <summary>
    /// Represent the projection onto the 3d axis scalar ratio starting from origin (0,0,0) to a float3 Vector value.
    /// Transformation sequence: Scale1 * Projection1x3
    ///    y
    ///    |     1 <--- Projected scalar value at 1 is the Vector value
    ///    |    /
    ///    |   /.
    ///    |  /   ` .
    ///    | /        ` * <--- 3d vector will project onto the axis
    ///    |/
    ///    0-----------x
    ///    ^--- Projected Scalar value at 0 is (0,0,0)
    ///    
    /// </summary>
    [Serializable]
    public struct ProjectionAxis1x3 : IScale1RW,
        IScaled<ProjectionAxis1x3, float>,
        IScale<ProjectionAxis1x3, float>,
        IScale<ProjectionAxis1x3, float3>
    {
        public float3 axis;
        public ProjectionAxis1x3(float3 axis) => this.axis = axis;
        public static ProjectionAxis1x3 Identity => new ProjectionAxis1x3(new float3(0, 0, 1));
        public bool Equals(ProjectionAxis3x1 o) => math.all(axis == o.axis);
        public bool NearEquals(ProjectionAxis3x1 o, float margin) => NiMath.NearEqual(axis, o.axis, margin);
        public float this[float3 o] => math.dot(o, axis) / math.dot(axis, axis);
        public float scale1 { get => math.rcp(math.length(axis)); set => axis = axis / (math.length(axis) * value); }
        public Scale1 Scale1 { get => new Scale1(scale1); set => scale1 = value.scale; }
        public ProjectionAxis3x1 Inverse => new ProjectionAxis3x1(axis);

        public ProjectionAxis1x3 Rotated(quaternion rotation) => NiMath.Rotate(rotation, this);
        public ProjectionAxis1x3 Scaled(float o) => NiMath.Scale(o, this);
        public ProjectionAxis1x3 Scale(float o) => NiMath.Scale(this, o);
        public ProjectionAxis1x3 Scale(float3 o) => NiMath.Scale(this, o);

        public float Transform(float3 o) => NiMath.Transform(this, o);
        public float3 Untransform(float o) => NiMath.Untransform(this, o);
    }

    public static partial class NiMath
    {
        public static bool Equal(ProjectionAxis1x3 a, ProjectionAxis1x3 b) => Equal(a.axis, b.axis);
        public static bool NearEqual(ProjectionAxis1x3 a, ProjectionAxis1x3 b, float margin) => NearEqual(a.axis, b.axis, margin);

        public static ProjectionAxis1x3 Rotate(quaternion rotation, ProjectionAxis1x3 o) => new ProjectionAxis1x3(math.mul(rotation, o.axis));
        public static ProjectionAxis1x3 Scale(float a, ProjectionAxis1x3 b) => new ProjectionAxis1x3(b.axis / a);
        public static ProjectionAxis1x3 Scale(ProjectionAxis1x3 a, float b) => new ProjectionAxis1x3(a.axis / b);
        public static ProjectionAxis1x3 Scale(ProjectionAxis1x3 a, float3 b) => new ProjectionAxis1x3(a.axis / b);

        public static float Transform(ProjectionAxis1x3 a, float3 b) => math.dot(b, a.axis) / math.dot(a.axis, a.axis);
        public static float3 Untransform(ProjectionAxis1x3 a, float b) => a.axis * b;

    }
}