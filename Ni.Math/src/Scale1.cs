using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    /// <summary>
    /// Represent a uniform scale transform
    /// </summary>
    [Serializable]
    public struct Scale1 : ITransform3<Scale1>, IScale1RW,
        ITransformable3<Scale1, UniformTransform3, UniformTransform3, Scale1, Scale3>,
        //IShearableTransformable3<Scale1, Matrix3x3Transform3>,
        IToMatrix3x3Transform,
        IInvertible<Scale1>,
        IMultipliable<Translation3, UniformTransform3>,
        IMultipliable<Rotation3Q, UniformTransform3>,
        IMultipliable<Scale1>,
        IMultipliable<Scale3>,
        IMultipliable<RigidTransform3, UniformTransform3>,
        IMultipliable<UniformTransform3>,
        IMultipliable<NonUniformTransform3>,
        IMultipliable<Matrix3x3Transform3>,
        IMultipliable<Matrix4x4Transform3>,
        IMultipliable<Aabb3M>,
        IMultipliable<Aabb3C>,
        IMultipliable<Aabb3S>,
        IMultipliable<Obb3T>,
        IMultipliable<Obb3M>,
        IDividable<Translation3, UniformTransform3>,
        IDividable<Rotation3Q, UniformTransform3>,
        IDividable<Scale1>,
        IDividable<Scale3>,
        IDividable<RigidTransform3, UniformTransform3>,
        IDividable<UniformTransform3>,
        IDividable<NonUniformTransform3>,
        IDividable<Matrix3x3Transform3>,
        IDividable<Matrix4x4Transform3>,
        IDividable<Aabb3M>,
        IDividable<Aabb3C>,
        IDividable<Aabb3S>,
        IDividable<Obb3T>,
        IDividable<Obb3M>
    {
        public float scale;

        public Scale1(float uniformScale)
        {
            scale = uniformScale;
        }

        public static explicit operator float(Scale1 o) => o.scale;
        public static explicit operator Scale1(float o) => new Scale1(o);

        public static explicit operator Scale1(UniformTransform3 o) => new Scale1(o.scale);
        public static explicit operator Scale1(NonUniformTransform3 o) => new Scale1(o.scale.x);
        public static explicit operator Scale1(Matrix3x3Transform3 o) => new Scale1(o.scale3.x);
        public static explicit operator Scale1(Matrix4x4Transform3 o) => new Scale1(o.scale3.x);

        public static readonly Scale1 Identity = new Scale1(1);
        public static Scale1 Scaling(float uniformScale) => new Scale1(uniformScale);

        public float3 this[float3 o] => Transform(o);
        Scale1 IScale1RW.Scale1 { get => this; set => this = value; }
        Scale1 IScale1.Scale1 => this;
        Scale1 IScale1W.Scale1 { set => this = value; }
        float IScale1RW.scale1 { get => scale; set => scale = value; }
        float IScale1.scale1 => scale;
        float IScale1W.scale1 { set => scale = value; }

        public override string ToString() => $"{nameof(Scale1)}({scale})";
        
        public bool Equals(Scale1 other) => NiMath.Equal(this, other);
        
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
        public Scale1 Inversed => NiMath.Inverse(this);

        public UniformTransform3 Translated(float3 translation) => NiMath.Translate(translation, this);
        public UniformTransform3 Rotated(quaternion rotation) => NiMath.Rotate(rotation, this);
        public Scale1 Scaled(float scale) => NiMath.Scale(scale, this);
        public Scale3 Scaled(float3 scale) => NiMath.Scale(scale, this);

        public UniformTransform3 Translate(float3 translation) => NiMath.Translate(this, translation);
        public UniformTransform3 Rotate(quaternion rotation) => NiMath.Rotate(this, rotation);
        public Scale1 Scale(float scale) => NiMath.Scale(this, scale);
        public Scale3 Scale(float3 scale) => NiMath.Scale(this, scale);

        public UniformTransform3 Translated(Translation3 translation) => NiMath.Translate(translation, this);
        public UniformTransform3 Rotated(Rotation3Q rotation) => NiMath.Rotate(rotation, this);
        public Scale1 Scaled(Scale1 scale) => NiMath.Scale(scale, this);
        public Scale3 Scaled(Scale3 scale) => NiMath.Scale(scale, this);

        public UniformTransform3 Translate(Translation3 translation) => NiMath.Translate(this, translation);
        public UniformTransform3 Rotate(Rotation3Q rotation) => NiMath.Rotate(this, rotation);
        public Scale1 Scale(Scale1 scale) => NiMath.Scale(this, scale);
        public Scale3 Scale(Scale3 scale) => NiMath.Scale(this, scale);

        public float3 Transform(float3 o) => NiMath.Transform(this, o);
        public Direction3 Transform(Direction3 o) => o;
        public ProjectionAxis3x1 Transform(ProjectionAxis3x1 o) => NiMath.Transform(this, o);
        public ProjectionAxis1x3 Transform(ProjectionAxis1x3 o) => NiMath.Transform(this, o);
        public Ray3 Transform(Ray3 o) => NiMath.Transform(this, o);

        public float3 Untransform(float3 o) => NiMath.Untransform(this, o);
        public Direction3 Untransform(Direction3 o) => o;
        public ProjectionAxis3x1 Untransform(ProjectionAxis3x1 o) => NiMath.Untransform(this, o);
        public ProjectionAxis1x3 Untransform(ProjectionAxis1x3 o) => NiMath.Untransform(this, o);
        public Ray3 Untransform(Ray3 o) => NiMath.Untransform(this, o);

        public UniformTransform3 Mul(Translation3 primitive) => NiMath.Mul(this, primitive);
        public UniformTransform3 Mul(Rotation3Q primitive) => NiMath.Mul(this, primitive);
        public Scale1 Mul(Scale1 primitive) => NiMath.Mul(this, primitive);
        public Scale3 Mul(Scale3 primitive) => NiMath.Mul(this, primitive);
        public UniformTransform3 Mul(RigidTransform3 primitive) => NiMath.Mul(this, primitive);
        public UniformTransform3 Mul(UniformTransform3 primitive) => NiMath.Mul(this, primitive);
        public NonUniformTransform3 Mul(NonUniformTransform3 primitive) => NiMath.Mul(this, primitive);
        public Matrix3x3Transform3 Mul(Matrix3x3Transform3 primitive) => NiMath.Mul(this, primitive);
        public Matrix4x4Transform3 Mul(Matrix4x4Transform3 primitive) => NiMath.Mul(this, primitive);
        public Aabb3M Mul(Aabb3M o) => NiMath.Mul(this, o);
        public Aabb3C Mul(Aabb3C o) => NiMath.Mul(this, o);
        public Aabb3S Mul(Aabb3S o) => NiMath.Mul(this, o);
        public Obb3T Mul(Obb3T o) => NiMath.Mul(this, o);
        public Obb3M Mul(Obb3M o) => NiMath.Mul(this, o);
        public UniformTransform3 Div(Translation3 primitive) => NiMath.Div(this, primitive);
        public UniformTransform3 Div(Rotation3Q primitive) => NiMath.Div(this, primitive);
        public Scale1 Div(Scale1 primitive) => NiMath.Div(this, primitive);
        public Scale3 Div(Scale3 primitive) => NiMath.Div(this, primitive);
        public UniformTransform3 Div(RigidTransform3 primitive) => NiMath.Div(this, primitive);
        public UniformTransform3 Div(UniformTransform3 primitive) => NiMath.Div(this, primitive);
        public NonUniformTransform3 Div(NonUniformTransform3 primitive) => NiMath.Div(this, primitive);
        public Matrix3x3Transform3 Div(Matrix3x3Transform3 primitive) => NiMath.Div(this, primitive);
        public Matrix4x4Transform3 Div(Matrix4x4Transform3 primitive) => NiMath.Div(this, primitive);
        public Aabb3M Div(Aabb3M o) => NiMath.Div(this, o);
        public Aabb3C Div(Aabb3C o) => NiMath.Div(this, o);
        public Aabb3S Div(Aabb3S o) => NiMath.Div(this, o);
        public Obb3T Div(Obb3T o) => NiMath.Div(this, o);
        public Obb3M Div(Obb3M o) => NiMath.Div(this, o);
    }

    public static partial class NiMath
    {
        public static bool Equal(Scale1 a, Scale1 b) => Equal(a.scale, b.scale);

        public static bool NearEqualScale(float a, Scale1 b, float margin) => math.abs(a - b.scale) <= margin;
        public static bool NearEqualScale(Scale1 a, float b, float margin) => math.abs(a.scale - b) <= margin;
        [Obsolete("Use NearEqualScale(float, UniformScaleTransform) instead.")]
        public static void NearEqualScale(float3 a, Scale1 b, float margin) => throw new System.ArgumentException("NearEqualScale(float3, UniformScaleTransform) is invalid. Use NearEqualScale(float, UniformScaleTransform) instead.");
        [Obsolete("Use NearEqualScale(UniformScaleTransform, float) instead.")]
        public static void NearEqualScale(Scale1 a, float3 b, float margin) => throw new System.ArgumentException("NearEqualScale(UniformScaleTransform, float3) is invalid. Use NearEqualScale(UniformScaleTransform, float) instead.");

        public static bool NearEqual(Scale1 a, Translation3 b, float margin) => NearEqual(a.scale, 0, margin) && NearEqual(float3.zero, b.translation, margin);
        public static bool NearEqual(Scale1 a, Rotation3Q b, float margin) => NearEqual(a.scale, 0, margin) && NearEqual(quaternion.identity, b.rotation, margin);
        public static bool NearEqual(Scale1 a, Scale1 b, float margin) => NearEqual(a.scale, b.scale, margin);
        public static bool NearEqual(Scale1 a, Scale3 b, float margin) => NearEqual((float3)a.scale, b.scale, margin);
        public static bool NearEqual(Scale1 a, RigidTransform3 b, float margin) => NearEqual(float3.zero, b.translation, margin) && NearEqual(quaternion.identity, b.rotation, margin) && NearEqual(a.scale, 0, margin);
        public static bool NearEqual(Scale1 a, UniformTransform3 b, float margin) => NearEqual(float3.zero, b.translation, margin) && NearEqual(quaternion.identity, b.rotation, margin) && NearEqual(a.scale, b.scale, margin);
        public static bool NearEqual(Scale1 a, NonUniformTransform3 b, float margin) => NearEqual(float3.zero, b.translation, margin) && NearEqual(quaternion.identity, b.rotation, margin) && NearEqual((float3)a.scale, b.scale, margin);
        public static bool NearEqual(Scale1 a, Matrix3x3Transform3 b, float margin) => NearEqual(new Matrix3x3Transform3(a.scale), b, margin);
        public static bool NearEqual(Scale1 a, Matrix4x4Transform3 b, float margin) => NearEqual(a.ToMatrix4x4Transform, b, margin);

        public static Scale1 Inverse(Scale1 a) => new Scale1(math.rcp(a.scale));

        public static UniformTransform3 Translate(float3 translation, Scale1 o) => new UniformTransform3(translation, quaternion.identity, o.scale);
        public static UniformTransform3 Rotate(quaternion rotation, Scale1 o) => new UniformTransform3(float3.zero, rotation, o.scale);
        public static Scale1 Scale(float scale, Scale1 b) => new Scale1(scale* b.scale);
        public static Scale3 Scale(float3 scale, Scale1 o) => new Scale3(scale * o.scale);
        public static UniformTransform3 Translate(Scale1 o, float3 translation) => new UniformTransform3(o.scale * translation, quaternion.identity, o.scale);
        public static UniformTransform3 Rotate(Scale1 o, quaternion rotation) => new UniformTransform3(float3.zero, rotation, o.scale);
        public static Scale1 Scale(Scale1 o, float scale) => new Scale1(o.scale * scale);
        public static Scale3 Scale(Scale1 o, float3 scale) => new Scale3(o.scale * scale);

        public static UniformTransform3 Translate(Translation3 translation, Scale1 o) => new UniformTransform3(translation.translation, quaternion.identity, o.scale);
        public static UniformTransform3 Rotate(Rotation3Q rotation, Scale1 o) => new UniformTransform3(float3.zero, rotation, o.scale);
        public static Scale1 Scale(Scale1 scale, Scale1 b) => new Scale1(scale.scale * b.scale);
        public static Scale3 Scale(Scale3 scale, Scale1 o) => new Scale3(scale.scale * o.scale);

        public static UniformTransform3 Translate(Scale1 o, Translation3 translation) => Translate(o, translation.translation);
        public static UniformTransform3 Rotate(Scale1 o, Rotation3Q rotation) => Rotate(o, rotation.rotation);
        public static Scale3 Scale(Scale1 o, Scale3 scale) => Scale(o, scale.scale);

        public static float3 Transform(Scale1 a, float3 b) => a.scale * b;
        public static ProjectionAxis3x1 Transform(Scale1 a, ProjectionAxis3x1 b) => Scale(a.scale, b);
        public static ProjectionAxis1x3 Transform(Scale1 a, ProjectionAxis1x3 b) => Scale(a.scale, b);
        public static Ray3 Transform(Scale1 a, Ray3 b) => Scale(a.scale, b);
        public static float3 Untransform(Scale1 a, float3 b) => Inverse(a).scale * b;
        public static ProjectionAxis3x1 Untransform(Scale1 a, ProjectionAxis3x1 b) => Scale(Inverse(a).scale, b);
        public static ProjectionAxis1x3 Untransform(Scale1 a, ProjectionAxis1x3 b) => Scale(Inverse(a).scale, b);
        public static Ray3 Untransform(Scale1 a, Ray3 b) => Scale(Inverse(a).scale, b);

        public static UniformTransform3 Mul(Scale1 a, Translation3 b) => Translate(a, b.translation);
        public static UniformTransform3 Mul(Scale1 a, Rotation3Q b) => Rotate(a, b);
        public static Scale1 Mul(Scale1 a, Scale1 b) => Scale(a, b.scale);
        public static Scale3 Mul(Scale1 a, Scale3 b) => Scale(a, b.scale);
        public static UniformTransform3 Mul(Scale1 a, RigidTransform3 b) => Scale(a.scale, b);
        public static UniformTransform3 Mul(Scale1 a, UniformTransform3 b) => Scale(a.scale, b);
        public static NonUniformTransform3 Mul(Scale1 a, NonUniformTransform3 b) => Scale(a.scale, b);
        public static Matrix3x3Transform3 Mul(Scale1 a, Matrix3x3Transform3 b) => Scale(a.scale, b);
        public static Matrix4x4Transform3 Mul(Scale1 a, Matrix4x4Transform3 b) => Scale(a.scale, b);
        public static Aabb3M Mul(Scale1 a, Aabb3M b) => Mathematics.Aabb3M.TS(a.scale * b.translation3, a.scale * b.scale3);
        public static Aabb3C Mul(Scale1 a, Aabb3C b) => Mathematics.Aabb3C.TS(a.scale * b.translation3, a.scale * b.scale3);
        public static Aabb3S Mul(Scale1 a, Aabb3S b) => Mathematics.Aabb3S.TS(a.scale * b.translation3, a.scale * b.scale3);
        public static Obb3T Mul(Scale1 a, Obb3T b) => Mul(a, b.NonUniformTransform);
        public static Obb3M Mul(Scale1 a, Obb3M b) => Mul(a, b.ToMatrix4x4Transform);
        public static UniformTransform3 Div(Scale1 a, Translation3 b) => Translate(Inverse(a), b.translation);
        public static UniformTransform3 Div(Scale1 a, Rotation3Q b) => Rotate(Inverse(a), b);
        public static Scale1 Div(Scale1 a, Scale1 b) => Scale(Inverse(a), b.scale);
        public static Scale3 Div(Scale1 a, Scale3 b) => Scale(Inverse(a), b.scale);
        public static UniformTransform3 Div(Scale1 a, RigidTransform3 b) => Scale(Inverse(a).scale, b);
        public static UniformTransform3 Div(Scale1 a, UniformTransform3 b) => Scale(Inverse(a).scale, b);
        public static NonUniformTransform3 Div(Scale1 a, NonUniformTransform3 b) => Scale(Inverse(a).scale, b);
        public static Matrix3x3Transform3 Div(Scale1 a, Matrix3x3Transform3 b) => Scale(Inverse(a).scale, b);
        public static Matrix4x4Transform3 Div(Scale1 a, Matrix4x4Transform3 b) => Scale(Inverse(a).scale, b);
        public static Aabb3M Div(Scale1 a, Aabb3M b) => Mul(Inverse(a), b);
        public static Aabb3C Div(Scale1 a, Aabb3C b) => Mul(Inverse(a), b);
        public static Aabb3S Div(Scale1 a, Aabb3S b) => Mul(Inverse(a), b);
        public static Obb3T Div(Scale1 a, Obb3T b) => Mul(Inverse(a), b);
        public static Obb3M Div(Scale1 a, Obb3M b) => Mul(Inverse(a), b);

        public static Scale1 Scale(float scale) => new Scale1(scale);
    }
}