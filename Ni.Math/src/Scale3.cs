using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    /// <summary>
    /// Represent a non-uniform scale transform for 3d vectors
    /// </summary>
    [Serializable]
    public struct Scale3 : ITransform3, INonUniformScale3RW,
        IEquatable<Scale3>,
        ITransformable3<Scale3, NonUniformTransform3, NonUniformTransform3, Scale3, Scale3, NonUniformTransform3, Matrix3x3Transform3, Scale3, Scale3>,
        IToMatrix3x3Transform,
        IInvertible<Scale3>,
        ITransform<float3>,
        ITransform<Ray3>,
        IMultipliable<Translation3, NonUniformTransform3>,
        IMultipliable<Rotation3Q, Matrix3x3Transform3>,
        IMultipliable<Scale1, Scale3>,
        IMultipliable<Scale3>,
        IMultipliable<RigidTransform3, Matrix4x4Transform3>,
        IMultipliable<UniformTransform3, Matrix4x4Transform3>,
        IMultipliable<NonUniformTransform3, Matrix4x4Transform3>,
        IMultipliable<Matrix3x3Transform3>,
        IMultipliable<Matrix4x4Transform3>,
        IMultipliable<Aabb3M>,
        IMultipliable<Aabb3C>,
        IMultipliable<Aabb3S>,
        IMultipliable<Obb3T, Obb3M>,
        IMultipliable<Obb3M>,
        IDividable<Translation3, NonUniformTransform3>,
        IDividable<Rotation3Q, Matrix3x3Transform3>,
        IDividable<Scale1, Scale3>,
        IDividable<Scale3>,
        IDividable<RigidTransform3, Matrix4x4Transform3>,
        IDividable<UniformTransform3, Matrix4x4Transform3>,
        IDividable<NonUniformTransform3, Matrix4x4Transform3>,
        IDividable<Matrix3x3Transform3>,
        IDividable<Matrix4x4Transform3>,
        IDividable<Aabb3M>,
        IDividable<Aabb3C>,
        IDividable<Aabb3S>,
        IDividable<Obb3T, Obb3M>,
        IDividable<Obb3M>
    {
        public float3 scale;

        public Scale3(float3 nonUniformScale)
        {
            scale = nonUniformScale;
        }

        public static explicit operator float3(Scale3 o) => o.scale;
        public static explicit operator Scale3(float3 o) => new Scale3(o);

        public static explicit operator Scale3(Scale1 o) => new Scale3(o.scale);
        public static explicit operator Scale3(NonUniformTransform3 o) => new Scale3(o.scale);
        public static explicit operator Scale3(Matrix3x3Transform3 o) => new Scale3(o.scale3);
        public static explicit operator Scale3(Matrix4x4Transform3 o) => new Scale3(o.scale3);
        public static Scale3 operator * (Scale3 a, float b) => new Scale3(a.scale * b);

        public static readonly Scale3 Identity = new Scale3(1);
        public static Scale3 Scaling(float scale) => new Scale3(scale);
        public static Scale3 Scaling(float3 scale) => new Scale3(scale);

        Scale3 INonUniformScale3RW.Scale3 { get => this; set => this = value; }
        Scale3 INonUniformScale3.Scale3 => this;
        Scale3 INonUniformScale3W.Scale3 { set => this = value; }
        float3 INonUniformScale3RW.scale3 { get => scale; set => scale = value; }
        float3 INonUniformScale3.scale3 => scale;
        float3 INonUniformScale3W.scale3 { set => scale = value; }
        public float3 this[float3 o] => Transform(o);

        public override string ToString() => $"{nameof(Scale3)}({scale.x}, {scale.y}, {scale.z})";
        
        public bool Equals(Scale3 other) => NiMath.Equal(this, other);
        
        public bool NearEquals(Translation3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Rotation3Q other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Scale1 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Scale3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(RigidTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(UniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(NonUniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Matrix3x3Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Matrix4x4Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);

        public Matrix3x3Transform3 ToMatrix3x3Transform => float3x3.Scale(scale);
        public Matrix4x4Transform3 ToMatrix4x4Transform => float4x4.Scale(scale);
        public Scale3 Inversed => NiMath.Inverse(this);

        public NonUniformTransform3 Translated(float3 translation) => NiMath.Translate(translation, this);
        public NonUniformTransform3 Rotated(quaternion rotation) => NiMath.Rotate(rotation, this);
        public Scale3 Scaled(float scale) => NiMath.Scale(scale, this);
        public Scale3 Scaled(float3 scale) => NiMath.Scale(scale, this);

        public NonUniformTransform3 Translate(float3 translation) => NiMath.Translate(this, translation);
        public Matrix3x3Transform3 Rotate(quaternion rotation) => NiMath.Rotate(this, rotation);
        public Scale3 Scale(float scale) => NiMath.Scale(this, scale);
        public Scale3 Scale(float3 scale) => NiMath.Scale(this, scale);

        public NonUniformTransform3 Translated(Translation3 translation) => NiMath.Translate(translation, this);
        public NonUniformTransform3 Rotated(Rotation3Q rotation) => NiMath.Rotate(rotation, this);
        public Scale3 Scaled(Scale1 scale) => NiMath.Scale(scale, this);
        public Scale3 Scaled(Scale3 scale) => NiMath.Scale(scale, this);

        public NonUniformTransform3 Translate(Translation3 translation) => NiMath.Translate(this, translation);
        public Matrix3x3Transform3 Rotate(Rotation3Q rotation) => NiMath.Rotate(this, rotation);
        public Scale3 Scale(Scale1 scale) => NiMath.Scale(this, scale);
        public Scale3 Scale(Scale3 scale) => NiMath.Scale(this, scale);

        public float3 Transform(float3 position) => NiMath.Transform(this, position);
        public Ray3 Transform(Ray3 primitive) => NiMath.Transform(this, primitive);
        public float3 Untransform(float3 position) => NiMath.Untransform(this, position);
        public Ray3 Untransform(Ray3 primitive) => NiMath.Untransform(this, primitive);

        public NonUniformTransform3 Mul(Translation3 primitive) => NiMath.Mul(this, primitive);
        public Matrix3x3Transform3 Mul(Rotation3Q primitive) => NiMath.Mul(this, primitive);
        public Scale3 Mul(Scale1 primitive) => NiMath.Mul(this, primitive);
        public Scale3 Mul(Scale3 primitive) => NiMath.Mul(this, primitive);
        public Matrix4x4Transform3 Mul(RigidTransform3 primitive) => NiMath.Mul(this, primitive);
        public Matrix4x4Transform3 Mul(UniformTransform3 primitive) => NiMath.Mul(this, primitive);
        public Matrix4x4Transform3 Mul(NonUniformTransform3 primitive) => NiMath.Mul(this, primitive);
        public Matrix3x3Transform3 Mul(Matrix3x3Transform3 primitive) => NiMath.Mul(this, primitive);
        public Matrix4x4Transform3 Mul(Matrix4x4Transform3 primitive) => NiMath.Mul(this, primitive);
        public Aabb3M Mul(Aabb3M o) => NiMath.Mul(this, o);
        public Aabb3C Mul(Aabb3C o) => NiMath.Mul(this, o);
        public Aabb3S Mul(Aabb3S o) => NiMath.Mul(this, o);
        public Obb3M Mul(Obb3T o) => NiMath.Mul(this, o);
        public Obb3M Mul(Obb3M o) => NiMath.Mul(this, o);
        public NonUniformTransform3 Div(Translation3 primitive) => NiMath.Div(this, primitive);
        public Matrix3x3Transform3 Div(Rotation3Q primitive) => NiMath.Div(this, primitive);
        public Scale3 Div(Scale1 primitive) => NiMath.Div(this, primitive);
        public Scale3 Div(Scale3 primitive) => NiMath.Div(this, primitive);
        public Matrix4x4Transform3 Div(RigidTransform3 primitive) => NiMath.Div(this, primitive);
        public Matrix4x4Transform3 Div(UniformTransform3 primitive) => NiMath.Div(this, primitive);
        public Matrix4x4Transform3 Div(NonUniformTransform3 primitive) => NiMath.Div(this, primitive);
        public Matrix3x3Transform3 Div(Matrix3x3Transform3 primitive) => NiMath.Div(this, primitive);
        public Matrix4x4Transform3 Div(Matrix4x4Transform3 primitive) => NiMath.Div(this, primitive);
        public Aabb3M Div(Aabb3M o) => NiMath.Div(this, o);
        public Aabb3C Div(Aabb3C o) => NiMath.Div(this, o);
        public Aabb3S Div(Aabb3S o) => NiMath.Div(this, o);
        public Obb3M Div(Obb3T o) => NiMath.Div(this, o);
        public Obb3M Div(Obb3M o) => NiMath.Div(this, o);
    }

    public static partial class NiMath
    {
        public static bool Equal(Scale3 a, Scale3 b) => Equal(a.scale, b.scale);

        [Obsolete("Use NearEqualScale(float3, NonUniformScaleTransform) instead.")]
        public static void NearEqualScale(float a, Scale3 b, float margin) => throw new System.ArgumentException("NearEqualScale(float, NonUniformScaleTransform) is invalid. Use NearEqualScale(float3, NonUniformScaleTransform) instead.");
        [Obsolete("Use NearEqualScale(NonUniformScaleTransform, float3) instead.")]
        public static void NearEqualScale(Scale3 a, float b, float margin) => throw new System.ArgumentException("NearEqualScale(NonUniformScaleTransform, float) is invalid. Use NearEqualScale(NonUniformScaleTransform, float3) instead.");
        public static void NearEqualScale(float3 a, Scale3 b, float margin) => math.all(math.abs(a - b.scale) <= margin);
        public static void NearEqualScale(Scale3 a, float3 b, float margin) => math.all(math.abs(a.scale - b) <= margin);

        public static bool NearEqual(Scale3 a, Translation3 b, float margin) => NearEqual(a.scale, (float3)0, margin) && NearEqual(float3.zero, b.translation, margin);
        public static bool NearEqual(Scale3 a, Rotation3Q b, float margin) => NearEqual(a.scale, (float3)0, margin) && NearEqual(quaternion.identity, b.rotation, margin);
        public static bool NearEqual(Scale3 a, Scale1 b, float margin) => NearEqual(a.scale, (float3)b.scale, margin);
        public static bool NearEqual(Scale3 a, Scale3 b, float margin) => NearEqual(a.scale, b.scale, margin);
        public static bool NearEqual(Scale3 a, RigidTransform3 b, float margin) => NearEqual(float3.zero, b.translation, margin) && NearEqual(quaternion.identity, b.rotation, margin) && NearEqual(a.scale, float3.zero, margin);
        public static bool NearEqual(Scale3 a, UniformTransform3 b, float margin) => NearEqual(float3.zero, b.translation, margin) && NearEqual(quaternion.identity, b.rotation, margin) && NearEqual(a.scale, (float3)b.scale, margin);
        public static bool NearEqual(Scale3 a, NonUniformTransform3 b, float margin) => NearEqual(float3.zero, b.translation, margin) && NearEqual(quaternion.identity, b.rotation, margin) && NearEqual(a.scale, b.scale, margin);
        public static bool NearEqual(Scale3 a, Matrix3x3Transform3 b, float margin) => NearEqual(new Matrix3x3Transform3(a.scale), b, margin);
        public static bool NearEqual(Scale3 a, Matrix4x4Transform3 b, float margin) => NearEqual(a.ToMatrix4x4Transform, b, margin);

        public static Scale3 Inverse(Scale3 o) => new Scale3(math.rcp(o.scale));

        public static NonUniformTransform3 Translate(float3 translation, Scale3 o) => new NonUniformTransform3(translation, quaternion.identity, o.scale);
        public static NonUniformTransform3 Rotate(quaternion rotation, Scale3 o) => new NonUniformTransform3(float3.zero, rotation, o.scale);
        public static Scale3 Scale(float scale, Scale3 o) => new Scale3(scale* o.scale);
        public static Scale3 Scale(float3 scale, Scale3 o) => new Scale3(scale * o.scale);
        public static NonUniformTransform3 Translate(Scale3 o, float3 translation) => new NonUniformTransform3(o.scale * translation, quaternion.identity, o.scale);
        public static Matrix3x3Transform3 Rotate(Scale3 o, quaternion rotation) => math.mul(float3x3.Scale(o.scale), new float3x3(rotation));
        public static Scale3 Scale(Scale3 o, float scale) => new Scale3(o.scale * scale);
        public static Scale3 Scale(Scale3 o, float3 scale) => new Scale3(o.scale * scale);
        public static NonUniformTransform3 Translate(Translation3 translation, Scale3 o) => new NonUniformTransform3(translation.translation, quaternion.identity, o.scale);
        public static NonUniformTransform3 Rotate(Rotation3Q rotation, Scale3 o) => new NonUniformTransform3(float3.zero, rotation, o.scale);
        public static Scale3 Scale(Scale3 scale, Scale3 o) => new Scale3(scale.scale * o.scale);
        public static NonUniformTransform3 Translate(Scale3 o, Translation3 translation) => Translate(o, translation.translation);
        public static Matrix3x3Transform3 Rotate(Scale3 o, Rotation3Q rotation) => Rotate(o, rotation.rotation);
        public static float3 Transform(Scale3 a, float3 b) => a.scale * b;
        public static Ray3 Transform(Scale3 a, Ray3 b) => Scale(a.scale, b);
        public static float3 Untransform(Scale3 a, float3 b) => Inverse(a).scale * b;
        public static Ray3 Untransform(Scale3 a, Ray3 b) => Scale(Inverse(a).scale, b);

        public static NonUniformTransform3 Mul(Scale3 a, Translation3 b) => Translate(a, b.translation);
        public static Matrix3x3Transform3 Mul(Scale3 a, Rotation3Q b) => Rotate(a, b);
        public static Scale3 Mul(Scale3 a, Scale1 b) => Scale(a, b.scale);
        public static Scale3 Mul(Scale3 a, Scale3 b) => Scale(a, b.scale);
        public static Matrix4x4Transform3 Mul(Scale3 a, RigidTransform3 b) => Scale(a.scale, b);
        public static Matrix4x4Transform3 Mul(Scale3 a, UniformTransform3 b) => Scale(a.scale, b);
        public static Matrix4x4Transform3 Mul(Scale3 a, NonUniformTransform3 b) => Scale(a.scale, b);
        public static Matrix3x3Transform3 Mul(Scale3 a, Matrix3x3Transform3 b) => Scale(a.scale, b);
        public static Matrix4x4Transform3 Mul(Scale3 a, Matrix4x4Transform3 b) => Scale(a.scale, b);
        public static Aabb3M Mul(Scale3 a, Aabb3M b) => Mathematics.Aabb3M.TS(a.scale * b.translation3, a.scale * b.scale3);
        public static Aabb3C Mul(Scale3 a, Aabb3C b) => Mathematics.Aabb3C.TS(a.scale * b.translation3, a.scale * b.scale3);
        public static Aabb3S Mul(Scale3 a, Aabb3S b) => Mathematics.Aabb3S.TS(a.scale * b.translation3, a.scale * b.scale3);
        public static Obb3M Mul(Scale3 a, Obb3T b) => Mul(a, b.NonUniformTransform);
        public static Obb3M Mul(Scale3 a, Obb3M b) => Mul(a, b.ToMatrix4x4Transform);
        public static NonUniformTransform3 Div(Scale3 a, Translation3 b) => Translate(Inverse(a), b.translation);
        public static Matrix3x3Transform3 Div(Scale3 a, Rotation3Q b) => Rotate(Inverse(a), b);
        public static Scale3 Div(Scale3 a, Scale1 b) => Scale(Inverse(a), b.scale);
        public static Scale3 Div(Scale3 a, Scale3 b) => Scale(Inverse(a), b.scale);
        public static Matrix4x4Transform3 Div(Scale3 a, RigidTransform3 b) => Scale(Inverse(a).scale, b);
        public static Matrix4x4Transform3 Div(Scale3 a, UniformTransform3 b) => Scale(Inverse(a).scale, b);
        public static Matrix4x4Transform3 Div(Scale3 a, NonUniformTransform3 b) => Scale(Inverse(a).scale, b);
        public static Matrix3x3Transform3 Div(Scale3 a, Matrix3x3Transform3 b) => Scale(Inverse(a).scale, b);
        public static Matrix4x4Transform3 Div(Scale3 a, Matrix4x4Transform3 b) => Scale(Inverse(a).scale, b);
        public static Aabb3M Div(Scale3 a, Aabb3M b) => Mul(Inverse(a), b);
        public static Aabb3C Div(Scale3 a, Aabb3C b) => Mul(Inverse(a), b);
        public static Aabb3S Div(Scale3 a, Aabb3S b) => Mul(Inverse(a), b);
        public static Obb3M Div(Scale3 a, Obb3T b) => Mul(Inverse(a), b);
        public static Obb3M Div(Scale3 a, Obb3M b) => Mul(Inverse(a), b);

        public static Scale3 Scale(float3 scale) => new Scale3(scale);
    }
}