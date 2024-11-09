using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    /// <summary>
    /// Represent a 3D shear transform 
    /// </summary>
    [Serializable]
    public partial struct ShearXY3 : IShear3RW,
        ITransform3<ShearXY3>,
        ITransformable3<ShearXY3, Matrix4x4Transform3, Matrix3x3Transform3, Matrix3x3Transform3, Matrix3x3Transform3>,
        //IShearableTransformable3<ShearXY3>,
        IToMatrix3x3Transform,
        IInvertible<ShearXY3>,
        IMultipliable<Translation3, Matrix4x4Transform3>,
        IMultipliable<Rotation3Q, Matrix3x3Transform3>,
        IMultipliable<Scale1, Matrix3x3Transform3>,
        IMultipliable<Scale3, Matrix3x3Transform3>,
        IMultipliable<RigidTransform3, Matrix4x4Transform3>,
        IMultipliable<UniformTransform3, Matrix4x4Transform3>,
        IMultipliable<NonUniformTransform3, Matrix4x4Transform3>,
        IMultipliable<Matrix3x3Transform3, Matrix3x3Transform3>,
        IMultipliable<Matrix4x4Transform3>,
        IMultipliable<Aabb3M, Obb3M>,
        IMultipliable<Aabb3C, Obb3M>,
        IMultipliable<Aabb3S, Obb3M>,
        IMultipliable<Obb3T, Obb3M>,
        IMultipliable<Obb3M, Obb3M>,
        IDividable<Translation3, Matrix4x4Transform3>,
        IDividable<Rotation3Q, Matrix3x3Transform3>,
        IDividable<Scale1, Matrix3x3Transform3>,
        IDividable<Scale3, Matrix3x3Transform3>,
        IDividable<RigidTransform3, Matrix4x4Transform3>,
        IDividable<UniformTransform3, Matrix4x4Transform3>,
        IDividable<NonUniformTransform3, Matrix4x4Transform3>,
        IDividable<Matrix3x3Transform3, Matrix3x3Transform3>,
        IDividable<Matrix4x4Transform3>,
        IDividable<Aabb3M, Obb3M>,
        IDividable<Aabb3C, Obb3M>,
        IDividable<Aabb3S, Obb3M>,
        IDividable<Obb3T, Obb3M>,
        IDividable<Obb3M, Obb3M>
    {
        public float3 shear;
        public ShearXY3(float3 shear)
        {
            this.shear = shear;
        }

        public static readonly ShearXY3 Identity = new ShearXY3(float3.zero);

        public float3 shear3 { get => shear3; set => shear3 = value; }
        public ShearXY3 Shear3 { get => new ShearXY3(shear3); set => shear3 = value.shear; }

        public Matrix3x3Transform3 ToMatrix3x3Transform => Matrix3x3Transform3.Shearing(shear);
        public Matrix4x4Transform3 ToMatrix4x4Transform => Matrix4x4Transform3.Shearing(shear);

        public bool Equals(ShearXY3 o) => math.all(shear == o.shear);
        public bool NearEquals(ShearXY3 o, float margin) => NiMath.NearEqual(this, o, margin);

        public ShearXY3 Inversed => NiMath.Inverse(this);


        public float3 Transform(float3 o) => NiMath.Transform(this, o);
        public float3 Untransform(float3 o) => NiMath.Untransform(this, o);
        public Direction3 Transform(Direction3 o) => NiMath.Transform(this, o);
        public Direction3 Untransform(Direction3 o) => NiMath.Untransform(this, o);
        public ProjectionAxis3x1 Transform(ProjectionAxis3x1 o) => NiMath.Transform(this, o);
        public ProjectionAxis3x1 Untransform(ProjectionAxis3x1 o) => NiMath.Untransform(this, o);
        public ProjectionAxis1x3 Transform(ProjectionAxis1x3 o) => NiMath.Transform(this, o);
        public ProjectionAxis1x3 Untransform(ProjectionAxis1x3 o) => NiMath.Untransform(this, o);
        public Ray3 Transform(Ray3 o) => NiMath.Transform(this, o);
        public Ray3 Untransform(Ray3 o) => NiMath.Untransform(this, o);

        public Matrix4x4Transform3 Translated(float3 translation) => NiMath.Translate(translation, this);
        public Matrix3x3Transform3 Rotated(quaternion rotation) => NiMath.Rotate(rotation, this);
        public Matrix3x3Transform3 Scaled(float scale) => NiMath.Scale(scale, this);
        public Matrix3x3Transform3 Scaled(float3 scale) => NiMath.Scale(scale, this);
        public Matrix4x4Transform3 Translate(float3 translation) => NiMath.Translate(this, translation);
        public Matrix3x3Transform3 Rotate(quaternion rotation) => NiMath.Rotate(this, rotation);
        public Matrix3x3Transform3 Scale(float scale) => NiMath.Scale(this, scale);
        public Matrix3x3Transform3 Scale(float3 scale) => NiMath.Scale(this, scale);
        public Matrix4x4Transform3 Translated(Translation3 translation) => NiMath.Translate(translation, this);
        public Matrix3x3Transform3 Rotated(Rotation3Q rotation) => NiMath.Rotate(rotation, this);
        public Matrix3x3Transform3 Scaled(Scale1 scale) => NiMath.Scale(scale, this);
        public Matrix3x3Transform3 Scaled(Scale3 scale) => NiMath.Scale(scale, this);
        public Matrix4x4Transform3 Translate(Translation3 translation) => NiMath.Translate(translation, this);
        public Matrix3x3Transform3 Rotate(Rotation3Q rotation) => NiMath.Rotate(rotation, this);
        public Matrix3x3Transform3 Scale(Scale1 scale) => NiMath.Scale(scale, this);
        public Matrix3x3Transform3 Scale(Scale3 scale) => NiMath.Scale(scale, this);

        public Matrix4x4Transform3 Mul(Translation3 o) => NiMath.Mul(this, o);
        public Matrix3x3Transform3 Mul(Rotation3Q o) => NiMath.Mul(this, o);
        public Matrix3x3Transform3 Mul(Scale1 o) => NiMath.Mul(this, o);
        public Matrix3x3Transform3 Mul(Scale3 o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Mul(RigidTransform3 o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Mul(UniformTransform3 o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Mul(NonUniformTransform3 o) => NiMath.Mul(this, o);
        public Matrix3x3Transform3 Mul(Matrix3x3Transform3 o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Mul(Matrix4x4Transform3 o) => NiMath.Mul(this, o);
        public Obb3M Mul(Aabb3M o) => NiMath.Mul(this, o);
        public Obb3M Mul(Aabb3C o) => NiMath.Mul(this, o);
        public Obb3M Mul(Aabb3S o) => NiMath.Mul(this, o);
        public Obb3M Mul(Obb3T o) => NiMath.Mul(this, o);
        public Obb3M Mul(Obb3M o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Div(Translation3 o) => NiMath.Div(this, o);
        public Matrix3x3Transform3 Div(Rotation3Q o) => NiMath.Div(this, o);
        public Matrix3x3Transform3 Div(Scale1 o) => NiMath.Div(this, o);
        public Matrix3x3Transform3 Div(Scale3 o) => NiMath.Div(this, o);
        public Matrix4x4Transform3 Div(RigidTransform3 o) => NiMath.Div(this, o);
        public Matrix4x4Transform3 Div(UniformTransform3 o) => NiMath.Div(this, o);
        public Matrix4x4Transform3 Div(NonUniformTransform3 o) => NiMath.Div(this, o);
        public Matrix3x3Transform3 Div(Matrix3x3Transform3 o) => NiMath.Div(this, o);
        public Matrix4x4Transform3 Div(Matrix4x4Transform3 o) => NiMath.Div(this, o);
        public Obb3M Div(Aabb3M o) => NiMath.Div(this, o);
        public Obb3M Div(Aabb3C o) => NiMath.Div(this, o);
        public Obb3M Div(Aabb3S o) => NiMath.Div(this, o);
        public Obb3M Div(Obb3T o) => NiMath.Div(this, o);
        public Obb3M Div(Obb3M o) => NiMath.Div(this, o);
    }

    public static partial class NiMath
    {
        public static bool NearEqual(ShearXY3 a, ShearXY3 b, float margin) => NearEqual(a.shear, b.shear, margin);
        public static ShearXY3 Inverse(ShearXY3 o) => new ShearXY3(-o.shear);
        public static float3 Transform(ShearXY3 a, float3 b) => new float3(b.x + a.shear.x * b.y + a.shear.y * b.z, b.y + a.shear.z * b.z, b.z);
        public static Direction3 Transform(ShearXY3 a, Direction3 b) => Direction3.Direction(Transform(a, b.vector));
        public static ProjectionAxis3x1 Transform(ShearXY3 a, ProjectionAxis3x1 b) => new ProjectionAxis3x1(Transform(a, b.axis));
        public static ProjectionAxis1x3 Transform(ShearXY3 a, ProjectionAxis1x3 b) => new ProjectionAxis1x3(Transform(a, b.axis));
        public static Ray3 Transform(ShearXY3 a, Ray3 b) => new Ray3(Transform(a, b.translation), Transform(a, b.Projection3x1).axis);
        public static float3 Untransform(ShearXY3 a, float3 b) => Transform(Inverse(a), b);
        public static Direction3 Untransform(ShearXY3 a, Direction3 b) => Transform(Inverse(a), b);
        public static ProjectionAxis3x1 Untransform(ShearXY3 a, ProjectionAxis3x1 b) => Transform(Inverse(a), b);
        public static ProjectionAxis1x3 Untransform(ShearXY3 a, ProjectionAxis1x3 b) => Transform(Inverse(a), b);
        public static Ray3 Untransform(ShearXY3 a, Ray3 b) => Transform(Inverse(a), b);
        public static Matrix4x4Transform3 Translate(float3 translation, ShearXY3 o) => new Matrix4x4Transform3(translation, o.ToMatrix3x3Transform);
        public static Matrix3x3Transform3 Rotate(quaternion rotation, ShearXY3 o) => new Matrix3x3Transform3(rotation, o);
        public static Matrix3x3Transform3 Scale(float scale, ShearXY3 o) => math.mul(float3x3.Scale(scale), o.ToMatrix3x3Transform);
        public static Matrix3x3Transform3 Scale(float3 scale, ShearXY3 o) => math.mul(float3x3.Scale(scale), o.ToMatrix3x3Transform);
        public static Matrix4x4Transform3 Translate(ShearXY3 o, float3 translation) => math.mul(o.ToMatrix4x4Transform, float4x4.Translate(translation));
        public static Matrix3x3Transform3 Rotate(ShearXY3 o, quaternion rotation) => math.mul(o.ToMatrix3x3Transform, new float3x3(rotation));
        public static Matrix3x3Transform3 Scale(ShearXY3 o, float scale) => math.mul(o.ToMatrix3x3Transform, float3x3.Scale(scale));
        public static Matrix3x3Transform3 Scale(ShearXY3 o, float3 scale) => math.mul(o.ToMatrix3x3Transform, float3x3.Scale(scale));
        public static Matrix4x4Transform3 Translate(ShearXY3 o, Translation3 translation) => math.mul(o.ToMatrix4x4Transform, translation.ToMatrix4x4Transform);
        public static Matrix3x3Transform3 Rotate(ShearXY3 o, Rotation3Q rotation) => math.mul(o.ToMatrix3x3Transform, rotation.ToMatrix3x3Transform);
        public static Matrix3x3Transform3 Scale(ShearXY3 o, Scale1 scale) => math.mul(o.ToMatrix3x3Transform, scale.ToMatrix3x3Transform);
        public static Matrix3x3Transform3 Scale(ShearXY3 o, Scale3 scale) => math.mul(o.ToMatrix3x3Transform, scale.ToMatrix3x3Transform);
        public static Matrix4x4Transform3 Translate(Translation3 translation, ShearXY3 o) => new Matrix4x4Transform3(translation, o.ToMatrix3x3Transform);
        public static Matrix3x3Transform3 Rotate(Rotation3Q rotation, ShearXY3 o) => new Matrix3x3Transform3(rotation, o);
        public static Matrix3x3Transform3 Scale(Scale1 scale, ShearXY3 o) => math.mul(scale.ToMatrix3x3Transform, o.ToMatrix3x3Transform);
        public static Matrix3x3Transform3 Scale(Scale3 scale, ShearXY3 o) => math.mul(scale.ToMatrix3x3Transform, o.ToMatrix3x3Transform);
        public static Matrix4x4Transform3 Mul(ShearXY3 a, Translation3 b) => Translate(a, b);
        public static Matrix3x3Transform3 Mul(ShearXY3 a, Rotation3Q b) => Rotate(a, b);
        public static Matrix3x3Transform3 Mul(ShearXY3 a, Scale1 b) => Scale(a, b);
        public static Matrix3x3Transform3 Mul(ShearXY3 a, Scale3 b) => Scale(a, b);
        public static Matrix4x4Transform3 Mul(ShearXY3 a, RigidTransform3 b) => math.mul(a.ToMatrix4x4Transform, b.ToMatrix4x4Transform);
        public static Matrix4x4Transform3 Mul(ShearXY3 a, UniformTransform3 b) => math.mul(a.ToMatrix4x4Transform, b.ToMatrix4x4Transform);
        public static Matrix4x4Transform3 Mul(ShearXY3 a, NonUniformTransform3 b) => math.mul(a.ToMatrix4x4Transform, b.ToMatrix4x4Transform);
        public static Matrix3x3Transform3 Mul(ShearXY3 a, Matrix3x3Transform3 b) => math.mul(a.ToMatrix3x3Transform, b.ToMatrix3x3Transform);
        public static Matrix4x4Transform3 Mul(ShearXY3 a, Matrix4x4Transform3 b) => math.mul(a.ToMatrix4x4Transform, b.ToMatrix4x4Transform);
        public static Obb3M Mul(ShearXY3 a, Aabb3M b) => math.mul(a.ToMatrix4x4Transform, b.ToMatrix4x4Transform);
        public static Obb3M Mul(ShearXY3 a, Aabb3C b) => math.mul(a.ToMatrix4x4Transform, b.ToMatrix4x4Transform);
        public static Obb3M Mul(ShearXY3 a, Aabb3S b) => math.mul(a.ToMatrix4x4Transform, b.ToMatrix4x4Transform);
        public static Obb3M Mul(ShearXY3 a, Obb3T b) => math.mul(a.ToMatrix4x4Transform, b.ToMatrix4x4Transform);
        public static Obb3M Mul(ShearXY3 a, Obb3M b) => math.mul(a.ToMatrix4x4Transform, b.ToMatrix4x4Transform);
        public static Matrix4x4Transform3 Div(ShearXY3 a, Translation3 b) => Mul(Inverse(a), b);
        public static Matrix3x3Transform3 Div(ShearXY3 a, Rotation3Q b) => Mul(Inverse(a), b);
        public static Matrix3x3Transform3 Div(ShearXY3 a, Scale1 b) => Mul(Inverse(a), b);
        public static Matrix3x3Transform3 Div(ShearXY3 a, Scale3 b) => Mul(Inverse(a), b);
        public static Matrix4x4Transform3 Div(ShearXY3 a, RigidTransform3 b) => Mul(Inverse(a), b);
        public static Matrix4x4Transform3 Div(ShearXY3 a, UniformTransform3 b) => Mul(Inverse(a), b);
        public static Matrix4x4Transform3 Div(ShearXY3 a, NonUniformTransform3 b) => Mul(Inverse(a), b);
        public static Matrix3x3Transform3 Div(ShearXY3 a, Matrix3x3Transform3 b) => Mul(Inverse(a), b);
        public static Matrix4x4Transform3 Div(ShearXY3 a, Matrix4x4Transform3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(ShearXY3 a, Aabb3M b) => Mul(Inverse(a), b);
        public static Obb3M Div(ShearXY3 a, Aabb3C b) => Mul(Inverse(a), b);
        public static Obb3M Div(ShearXY3 a, Aabb3S b) => Mul(Inverse(a), b);
        public static Obb3M Div(ShearXY3 a, Obb3T b) => Mul(Inverse(a), b);
        public static Obb3M Div(ShearXY3 a, Obb3M b) => Mul(Inverse(a), b);
    }
}