using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    /// <summary>
    /// Represent the projection onto the 3d axis vector which [0, 1] range is mapped from origin (0,0,0) to a float3 Vector value.
    /// Transformation sequence: Scale1 * Projection3x1
    /// Input: float
    /// Output: float3
    /// 
    ///    y
    ///    |    1 <--- Projected scalar value at 1 is the Vector value
    ///    |   /
    ///    |  / <--- Axis
    ///    | /
    ///    |/
    ///    0-----------x
    ///    ^--- Projected Scalar value at 0 is origin vector (0,0,0)
    /// </summary>
    [Serializable]
    public struct ProjectionAxis3x1 : IRotation3QW, IUniformScaleRW,
        IEquatable<ProjectionAxis3x1>,
        INearEquatable<ProjectionAxis3x1>,
        IRotated<ProjectionAxis3x1, quaternion>,
        IScaled<ProjectionAxis3x1, float>,
        IScaled<ProjectionAxis3x1, float3>,
        IScale<ProjectionAxis3x1, float>
    {
        public float3 axis;

        public ProjectionAxis3x1(float3 vector) { axis = vector; }

        public static ProjectionAxis3x1 Identity => new ProjectionAxis3x1(new float3(0, 0, 1));

        public ProjectionAxis1x3 Inverse => new ProjectionAxis1x3(axis);

        /// <summary>
        /// Set the axis to the rotated Z axis (0, 0, UniformScale).
        /// </summary>
        public quaternion rotation3 { set => axis = math.mul(value, new float3(0, 0, math.length(axis))); }
        public float scale1 { get => math.length(axis); set => axis *= value / math.length(axis); }
        public Rotation3Q Rotation3 { set => rotation3 = value.rotation; }
        public Scale1 Scale1 { get => new Scale1(scale1); set => scale1 = value.scale; }
        public ProjectionAxis3x1 Projection3x1 => new ProjectionAxis3x1(math.normalize(axis));
        public float3 this[float o] => axis * o;

        public bool Equals(ProjectionAxis3x1 o) => math.all(axis == o.axis);
        public bool NearEquals(ProjectionAxis3x1 o, float margin) => NiMath.NearEqual(axis, o.axis, margin);

        public ProjectionAxis3x1 Scaled(float scale) => NiMath.Scale(scale, this);
        public ProjectionAxis3x1 Scaled(float3 scale) => NiMath.Scale(scale, this);
        public ProjectionAxis3x1 Rotated(quaternion rotation) => NiMath.Rotate(rotation, this);

        public ProjectionAxis3x1 Scale(float scale) => NiMath.Scale(this, scale);

        public float3 Transform(float o) => NiMath.Transform(this, o);
        public float Untransform(float3 o)  => NiMath.Untransform(this, o);

    }

    public static partial class NiMath
    {
        public static bool Equal(ProjectionAxis3x1 a, ProjectionAxis3x1 b) => Equal(a.axis, b.axis);

        public static bool NearEqual(ProjectionAxis3x1 a, ProjectionAxis3x1 b, float margin) => NearEqual(a.axis, b.axis, margin);

        public static ProjectionAxis3x1 Rotate(quaternion rotation, ProjectionAxis3x1 o) => new ProjectionAxis3x1(math.mul(rotation, o.axis));
        public static ProjectionAxis3x1 Scale(float scale, ProjectionAxis3x1 o) => new ProjectionAxis3x1(scale * o.axis);
        public static ProjectionAxis3x1 Scale(float3 scale, ProjectionAxis3x1 o) => new ProjectionAxis3x1(scale * o.axis);
        public static ProjectionAxis3x1 Scale(ProjectionAxis3x1 o, float scale) => new ProjectionAxis3x1(o.axis * scale);
        public static float3 Transform(ProjectionAxis3x1 a, float b) => a.axis * b;
        public static float Untransform(ProjectionAxis3x1 a, float3 b) => math.dot(b, a.axis) / math.dot(a.axis, a.axis);
    }

}