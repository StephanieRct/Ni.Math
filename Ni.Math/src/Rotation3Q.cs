using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    /// <summary>
    /// Represent a rotation transform for 3d vectors
    /// </summary>
    [Serializable]
    public partial struct Rotation3Q : ITransform3<Rotation3Q>, IRotation3QRW, IRotation3ERW,
        ITransformable3<Rotation3Q, RigidTransform3, Rotation3Q, UniformTransform3, Matrix3x3Transform3, RigidTransform3, Rotation3Q, UniformTransform3, NonUniformTransform3>,
        //IShearableTransformable3<Rotation3Q, Matrix3x3Transform3>,
        IInvertible<Rotation3Q>,
        IToMatrix3x3Transform,
        IMultipliable<Translation3, RigidTransform3>,
        IMultipliable<Rotation3Q>,
        IMultipliable<Scale1, UniformTransform3>,
        IMultipliable<Scale3, NonUniformTransform3>,
        IMultipliable<RigidTransform3>,
        IMultipliable<UniformTransform3>,
        IMultipliable<NonUniformTransform3>,
        IMultipliable<Matrix3x3Transform3>,
        IMultipliable<Matrix4x4Transform3>,
        IMultipliable<Aabb3M, Obb3T>,
        IMultipliable<Aabb3C, Obb3T>,
        IMultipliable<Aabb3S, Obb3T>,
        IMultipliable<Obb3T>,
        IMultipliable<Obb3M>,
        IDividable<Translation3, RigidTransform3>,
        IDividable<Rotation3Q>,
        IDividable<Scale1, UniformTransform3>,
        IDividable<Scale3, NonUniformTransform3>,
        IDividable<RigidTransform3>,
        IDividable<UniformTransform3>,
        IDividable<NonUniformTransform3>,
        IDividable<Matrix3x3Transform3>,
        IDividable<Matrix4x4Transform3>,
        IDividable<Aabb3M, Obb3T>,
        IDividable<Aabb3C, Obb3T>,
        IDividable<Aabb3S, Obb3T>,
        IDividable<Obb3T>,
        IDividable<Obb3M>
    {
        public quaternion rotation;

        public Rotation3Q(quaternion rotation)
        {
            this.rotation = rotation;
        }

        public static implicit operator quaternion(Rotation3Q o) => o.rotation;
        public static implicit operator Rotation3Q(quaternion o) => new Rotation3Q(o);

        public static explicit operator Rotation3Q(Rotation3Euler o) => new Rotation3Q(o.rotation3);
        public static explicit operator Rotation3Q(RigidTransform3 o) => new Rotation3Q(o.rotation);
        public static explicit operator Rotation3Q(UniformTransform3 o) => new Rotation3Q(o.rotation);
        public static explicit operator Rotation3Q(NonUniformTransform3 o) => new Rotation3Q(o.rotation);
        public static explicit operator Rotation3Q(Matrix3x3Transform3 o) => new Rotation3Q(o.rotation3);
        public static explicit operator Rotation3Q(Matrix4x4Transform3 o) => new Rotation3Q(o.rotation3);

        public static readonly Rotation3Q Identity = new Rotation3Q(quaternion.identity);
        public static Rotation3Q Rotating(quaternion rotation) => new Rotation3Q(rotation);

        public float3 this[float3 o] => Transform(o);
        public float3 eulerRotation3
        {
            get => NiMath.QuaternionToEulerXYZ(rotation);
            set => rotation = quaternion.EulerXYZ(value);
        }
        public Rotation3Euler EulerRotation3 { get => eulerRotation3; set => eulerRotation3 = value.rotation; }
        Rotation3Q IRotation3QRW.Rotation3 { get => this; set => this = value; }
        Rotation3Q IRotation3Q.Rotation3 => this;
        Rotation3Q IRotation3QW.Rotation3 { set => this = value; }
        quaternion IRotation3QRW.rotation3 { get => rotation; set => rotation = value; }
        quaternion IRotation3Q.rotation3 => rotation;
        quaternion IRotation3QW.rotation3 { set => rotation = value; }
        public override string ToString() => $"{nameof(Rotation3Q)}({rotation.value.x}, {rotation.value.y}, {rotation.value.z}, {rotation.value.w})";
        
        public bool Equals(Rotation3Q o) => NiMath.Equal(this, o);

        public bool NearEquals(Translation3 o, float margin) => NiMath.NearEqual(this, o, margin);
        public bool NearEquals(Rotation3Q o, float margin) => NiMath.NearEqual(this, o, margin);
        public bool NearEquals(Scale1 o, float margin) => NiMath.NearEqual(this, o, margin);
        public bool NearEquals(Scale3 o, float margin) => NiMath.NearEqual(this, o, margin);
        public bool NearEquals(RigidTransform3 o, float margin) => NiMath.NearEqual(this, o, margin);
        public bool NearEquals(UniformTransform3 o, float margin) => NiMath.NearEqual(this, o, margin);
        public bool NearEquals(NonUniformTransform3 o, float margin) => NiMath.NearEqual(this, o, margin);
        public bool NearEquals(Matrix3x3Transform3 o, float margin) => NiMath.NearEqual(this, o, margin);
        public bool NearEquals(Matrix4x4Transform3 o, float margin) => NiMath.NearEqual(this, o, margin);

        public Rotation3Q Inversed => NiMath.Inverse(this);
        public Matrix3x3Transform3 ToMatrix3x3Transform => new float3x3(rotation);
        public Matrix4x4Transform3 ToMatrix4x4Transform => new float4x4(rotation, float3.zero);


        public RigidTransform3 Translated(float3 translation) => NiMath.Translate(translation, this);
        public Rotation3Q Rotated(quaternion rotation) => NiMath.Rotate(rotation, this);
        public UniformTransform3 Scaled(float scale) => NiMath.Scale(scale, this);
        public Matrix3x3Transform3 Scaled(float3 scale) => NiMath.Scale(scale, this);

        public RigidTransform3 Translate(float3 translation) => NiMath.Translate(this, translation);
        public Rotation3Q Rotate(quaternion rotation) => NiMath.Rotate(this, rotation);
        public UniformTransform3 Scale(float scale) => NiMath.Scale(this, scale);
        public NonUniformTransform3 Scale(float3 scale) => NiMath.Scale(this, scale);

        public RigidTransform3 Translated(Translation3 translation) => NiMath.Translate(translation, this);
        public Rotation3Q Rotated(Rotation3Q rotation) => NiMath.Rotate(rotation, this);
        public UniformTransform3 Scaled(Scale1 scale) => NiMath.Scale(scale, this);
        public Matrix3x3Transform3 Scaled(Scale3 scale) => NiMath.Scale(scale, this);

        public RigidTransform3 Translate(Translation3 translation) => NiMath.Translate(this, translation);
        public Rotation3Q Rotate(Rotation3Q rotation) => NiMath.Rotate(this, rotation);
        public UniformTransform3 Scale(Scale1 scale) => NiMath.Scale(this, scale);
        public NonUniformTransform3 Scale(Scale3 scale) => NiMath.Scale(this, scale);

        public float3 Transform(float3 o) => NiMath.Transform(this, o);
        public Direction3 Transform(Direction3 o) => NiMath.Transform(this, o);
        public ProjectionAxis3x1 Transform(ProjectionAxis3x1 o) => NiMath.Transform(this, o);
        public ProjectionAxis1x3 Transform(ProjectionAxis1x3 o) => NiMath.Transform(this, o);
        public Ray3 Transform(Ray3 o) => NiMath.Transform(this, o);

        public float3 Untransform(float3 o) => NiMath.Untransform(this, o);
        public Direction3 Untransform(Direction3 o) => NiMath.Untransform(this, o);
        public ProjectionAxis3x1 Untransform(ProjectionAxis3x1 o) => NiMath.Untransform(this, o);
        public ProjectionAxis1x3 Untransform(ProjectionAxis1x3 o) => NiMath.Untransform(this, o);
        public Ray3 Untransform(Ray3 o) => NiMath.Untransform(this, o);

        public RigidTransform3 Mul(Translation3 o) => NiMath.Mul(this, o);
        public Rotation3Q Mul(Rotation3Q o) => NiMath.Mul(this, o);
        public UniformTransform3 Mul(Scale1 o) => NiMath.Mul(this, o);
        public NonUniformTransform3 Mul(Scale3 o) => NiMath.Mul(this, o);
        public RigidTransform3 Mul(RigidTransform3 o) => NiMath.Mul(this, o);
        public UniformTransform3 Mul(UniformTransform3 o) => NiMath.Mul(this, o);
        public NonUniformTransform3 Mul(NonUniformTransform3 o) => NiMath.Mul(this, o);
        public Matrix3x3Transform3 Mul(Matrix3x3Transform3 o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Mul(Matrix4x4Transform3 o) => NiMath.Mul(this, o);
        public Obb3T Mul(Aabb3M o) => NiMath.Mul(this, o);
        public Obb3T Mul(Aabb3C o) => NiMath.Mul(this, o);
        public Obb3T Mul(Aabb3S o) => NiMath.Mul(this, o);
        public Obb3T Mul(Obb3T o) => NiMath.Mul(this, o);
        public Obb3M Mul(Obb3M o) => NiMath.Mul(this, o);
        public RigidTransform3 Div(Translation3 o) => NiMath.Div(this, o);
        public Rotation3Q Div(Rotation3Q o) => NiMath.Div(this, o);
        public UniformTransform3 Div(Scale1 o) => NiMath.Div(this, o);
        public NonUniformTransform3 Div(Scale3 o) => NiMath.Div(this, o);
        public RigidTransform3 Div(RigidTransform3 o) => NiMath.Div(this, o);
        public UniformTransform3 Div(UniformTransform3 o) => NiMath.Div(this, o);
        public NonUniformTransform3 Div(NonUniformTransform3 o) => NiMath.Div(this, o);
        public Matrix3x3Transform3 Div(Matrix3x3Transform3 o) => NiMath.Div(this, o);
        public Matrix4x4Transform3 Div(Matrix4x4Transform3 o) => NiMath.Div(this, o);
        public Obb3T Div(Aabb3M o) => NiMath.Div(this, o);
        public Obb3T Div(Aabb3C o) => NiMath.Div(this, o);
        public Obb3T Div(Aabb3S o) => NiMath.Div(this, o);
        public Obb3T Div(Obb3T o) => NiMath.Div(this, o);
        public Obb3M Div(Obb3M o) => NiMath.Div(this, o);
    }

    public static partial class NiMath
    {
        public static bool Equal(Rotation3Q a, Rotation3Q b) => Equal(a.rotation, b.rotation);

        public static bool NearEqual(Rotation3Q a, Translation3 b, float margin) => NearEqual(a.rotation, quaternion.identity, margin) && NearEqual(float3.zero, b.translation, margin);
        public static bool NearEqual(Rotation3Q a, Rotation3Q b, float margin) => NearEqual(a.rotation, b.rotation, margin);
        public static bool NearEqual(Rotation3Q a, Scale1 b, float margin) => NearEqual(a.rotation, quaternion.identity, margin) && NearEqual(0, b.scale, margin);
        public static bool NearEqual(Rotation3Q a, Scale3 b, float margin) => NearEqual(a.rotation, quaternion.identity, margin) && NearEqual(float3.zero, b.scale, margin);
        public static bool NearEqual(Rotation3Q a, RigidTransform3 b, float margin) => NearEqual(float3.zero, b.translation, margin) && NearEqual(a.rotation, b.rotation, margin);
        public static bool NearEqual(Rotation3Q a, UniformTransform3 b, float margin) => NearEqual(float3.zero, b.translation, margin) && NearEqual(a.rotation, b.rotation, margin) && NearEqual(1, b.scale, margin);
        public static bool NearEqual(Rotation3Q a, NonUniformTransform3 b, float margin) => NearEqual(float3.zero, b.translation, margin) && NearEqual(a.rotation, b.rotation, margin) && NearEqual((float3)1, b.scale, margin);
        public static bool NearEqual(Rotation3Q a, Matrix3x3Transform3 b, float margin) => NearEqual(a.ToMatrix3x3Transform, b, margin);
        public static bool NearEqual(Rotation3Q a, Matrix4x4Transform3 b, float margin) => NearEqual(a.ToMatrix4x4Transform, b, margin);

        public static Rotation3Q Inverse(Rotation3Q o) => new Rotation3Q(math.inverse(o.rotation));

        public static RigidTransform3 Translate(float3 translation, Rotation3Q o) => new RigidTransform3(translation, o.rotation);
        public static Rotation3Q Rotate(quaternion rotation, Rotation3Q o) => new Rotation3Q(math.mul(rotation, o.rotation));
        public static UniformTransform3 Scale(float scale, Rotation3Q o) => new UniformTransform3(float3.zero, o.rotation, scale);
        public static Matrix3x3Transform3 Scale(float3 scale, Rotation3Q o) => math.mul(float3x3.Scale(scale), new float3x3(o.rotation));

        public static RigidTransform3 Translate(Rotation3Q o, float3 translation) => new RigidTransform3(math.mul(o.rotation, translation), o.rotation);
        public static Rotation3Q Rotate(Rotation3Q o, quaternion rotation) => new Rotation3Q(math.mul(o.rotation, rotation));
        public static UniformTransform3 Scale(Rotation3Q o, float scale) => new UniformTransform3(float3.zero, o.rotation, scale);
        public static NonUniformTransform3 Scale(Rotation3Q o, float3 scale) => new NonUniformTransform3(float3.zero, o.rotation, scale);

        public static RigidTransform3 Translate(Translation3 translation, Rotation3Q o) => new RigidTransform3(translation, o.rotation);
        public static Rotation3Q Rotate(Rotation3Q rotation, Rotation3Q o) => new Rotation3Q(math.mul(rotation, o.rotation));
        public static UniformTransform3 Scale(Scale1 scale, Rotation3Q o) => new UniformTransform3(float3.zero, o.rotation, scale.scale);
        public static Matrix3x3Transform3 Scale(Scale3 scale, Rotation3Q o) => math.mul(float3x3.Scale(scale.scale), new float3x3(o.rotation));
        public static RigidTransform3 Translate(Rotation3Q o, Translation3 translation) => Translate(o, translation.translation);
        public static UniformTransform3 Scale(Rotation3Q o, Scale1 scale) => Scale(o, scale.scale);
        public static NonUniformTransform3 Scale(Rotation3Q o, Scale3 scale) => Scale(o, scale.scale);

        public static float3 Transform(Rotation3Q a, float3 b) => math.rotate(a.rotation, b);
        public static Direction3 Transform(Rotation3Q a, Direction3 b) => Rotate(a.rotation, b);
        public static ProjectionAxis3x1 Transform(Rotation3Q a, ProjectionAxis3x1 b) => Rotate(a.rotation, b);
        public static ProjectionAxis1x3 Transform(Rotation3Q a, ProjectionAxis1x3 b) => Rotate(a.rotation, b);
        public static Ray3 Transform(Rotation3Q a, Ray3 b) => Rotate(a.rotation, b);
        public static float3 Untransform(Rotation3Q a, float3 b) => math.mul(Inverse(a).rotation, b);
        public static Direction3 Untransform(Rotation3Q a, Direction3 b) => Rotate(Inverse(a).rotation, b);
        public static ProjectionAxis3x1 Untransform(Rotation3Q a, ProjectionAxis3x1 b) => Rotate(Inverse(a).rotation, b);
        public static ProjectionAxis1x3 Untransform(Rotation3Q a, ProjectionAxis1x3 b) => Rotate(Inverse(a).rotation, b);
        public static Ray3 Untransform(Rotation3Q a, Ray3 b) => Rotate(Inverse(a).rotation, b);

        public static RigidTransform3 Mul(Rotation3Q a, Translation3 b) => Translate(a, b.translation);
        public static Rotation3Q Mul(Rotation3Q a, Rotation3Q b) => Rotate(a, b);
        public static UniformTransform3 Mul(Rotation3Q a, Scale1 b) => Scale(a, b.scale);
        public static NonUniformTransform3 Mul(Rotation3Q a, Scale3 b) => Scale(a, b.scale);
        public static RigidTransform3 Mul(Rotation3Q a, RigidTransform3 b) => Rotate(a.rotation, b);
        public static UniformTransform3 Mul(Rotation3Q a, UniformTransform3 b) => Rotate(a.rotation, b);
        public static NonUniformTransform3 Mul(Rotation3Q a, NonUniformTransform3 b) => Rotate(a.rotation, b);
        public static Matrix3x3Transform3 Mul(Rotation3Q a, Matrix3x3Transform3 b) => Rotate(a.rotation, b);
        public static Matrix4x4Transform3 Mul(Rotation3Q a, Matrix4x4Transform3 b) => Rotate(a.rotation, b);
        public static Obb3T Mul(Rotation3Q a, Aabb3M b) => new NonUniformTransform3(Transform(a, b.translation3), a, b.scale3);
        public static Obb3T Mul(Rotation3Q a, Aabb3C b) => new NonUniformTransform3(Transform(a, b.translation3), a, b.scale3);
        public static Obb3T Mul(Rotation3Q a, Aabb3S b) => new NonUniformTransform3(Transform(a, b.translation3), a, b.scale3);
        public static Obb3T Mul(Rotation3Q a, Obb3T b) => Mul(a, b.NonUniformTransform);
        public static Obb3M Mul(Rotation3Q a, Obb3M b) => Mul(a, b.ToMatrix4x4Transform);

        public static RigidTransform3 Div(Rotation3Q a, Translation3 b) => Translate(Inverse(a), b.translation);
        public static Rotation3Q Div(Rotation3Q a, Rotation3Q b) => Rotate(Inverse(a), b);
        public static UniformTransform3 Div(Rotation3Q a, Scale1 b) => Scale(Inverse(a), b.scale);
        public static NonUniformTransform3 Div(Rotation3Q a, Scale3 b) => Scale(Inverse(a), b.scale);
        public static RigidTransform3 Div(Rotation3Q a, RigidTransform3 b) => Rotate(Inverse(a).rotation, b);
        public static UniformTransform3 Div(Rotation3Q a, UniformTransform3 b) => Rotate(Inverse(a).rotation, b);
        public static NonUniformTransform3 Div(Rotation3Q a, NonUniformTransform3 b) => Rotate(Inverse(a).rotation, b);
        public static Matrix3x3Transform3 Div(Rotation3Q a, Matrix3x3Transform3 b) => Rotate(Inverse(a).rotation, b);
        public static Matrix4x4Transform3 Div(Rotation3Q a, Matrix4x4Transform3 b) => Rotate(Inverse(a).rotation, b);
        public static Obb3T Div(Rotation3Q a, Aabb3M b) => Mul(Inverse(a), b);
        public static Obb3T Div(Rotation3Q a, Aabb3C b) => Mul(Inverse(a), b);
        public static Obb3T Div(Rotation3Q a, Aabb3S b) => Mul(Inverse(a), b);
        public static Obb3T Div(Rotation3Q a, Obb3T b) => Mul(Inverse(a), b);
        public static Obb3M Div(Rotation3Q a, Obb3M b) => Mul(Inverse(a), b);

        public static Rotation3Q Rotation(quaternion rotation) => new Rotation3Q(rotation);
    }
}