using System;
using Unity.Mathematics;
using UnityEngine.Assertions;

namespace Ni.Mathematics
{
    /// <summary>
    /// Unit 3D vector.
    /// As a transform, it represent the projection onto a unit 3d vector which [0, 1] range is mapped from origin (0,0,0) to a float3 value.
    /// When transformed, it is only affected by rotations, non-uniform scales, and shears.
    /// The length of the vector is always 1 when the direction is valid
    /// An invalid Direction3 has a length not equal to 1
    /// Transformation : Projection3x1
    /// Input: float
    /// Output: float3
    /// 
    ///    y
    ///    |    1 <--- Projected scalar value at 1 is the Vector value
    ///    |   /
    ///    |  / <--- Vector, length == 1
    ///    | /
    ///    |/
    ///    0-----------x
    ///    ^--- Projected Scalar value at 0 is origin vector (0,0,0)
    /// </summary>
    public struct Direction3 : IRotation3QW,
        IEquatable<Direction3>,
        INearEquatable<Direction3>,
        INormalizable<Direction3>,
        IRotated<Direction3, quaternion>
    {
        public float3 vector;
        public Direction3(float3 vector)
        {
            this.vector = vector;
        }
        public static Direction3 Direction(float3 vector) => new Direction3(math.normalize(vector));
        public static Direction3 Direction(float3 from, float3 to) => new Direction3(math.normalize(to - from));

        public bool IsValid => math.abs(1 - math.lengthsq(vector)) < 0.001f;
        public Direction3 Normalized => new Direction3(math.normalize(vector));

        /// <summary>
        /// Set the axis to the rotated Z axis (0, 0, UniformScale).
        /// </summary>
        public quaternion rotation3 { set => vector = math.mul(value, new float3(0, 0, 1)); }
        public Rotation3Q Rotation3 { set => rotation3 = value.rotation; }
        public float3 this[float o] => vector * o;

        public bool Equals(Direction3 o) => math.all(vector == o.vector);
        public bool NearEquals(Direction3 o, float margin) => NiMath.NearEqual(vector, o.vector, margin);

        public Direction3 Rotated(quaternion rotation) => NiMath.Rotate(rotation, this);
        public ProjectionAxis3x1 Scaled(float scale) => NiMath.Scale(scale, this);
        public ProjectionAxis3x1 Scaled(float3 scale) => NiMath.Scale(scale, this);

        public float3 Transform(float o) => NiMath.Transform(this, o);
        public float Untransform(float3 o) => NiMath.Untransform(this, o);
    }

    public static partial class NiMath
    {
        public static bool Equal(Direction3 a, Direction3 b) => Equal(a.vector, b.vector);

        public static bool NearEqual(Direction3 a, Direction3 b, float margin) => NearEqual(a.vector, b.vector, margin);

        public static Direction3 Rotate(quaternion rotation, Direction3 o) => new Direction3(math.mul(rotation, o.vector));
        public static ProjectionAxis3x1 Scale(float scale, Direction3 o) => new ProjectionAxis3x1(scale * o.vector);
        public static ProjectionAxis3x1 Scale(float3 scale, Direction3 o) => new ProjectionAxis3x1(scale * o.vector);

        public static float3 Transform(Direction3 a, float b) => a.vector * b;
        public static float Untransform(Direction3 a, float3 b) => math.dot(b, a.vector);
    }
}