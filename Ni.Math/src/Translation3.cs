using System;
using Unity.Mathematics;
using UnityEngine;

namespace Ni.Mathematics
{
    /// <summary>
    /// Represent a translation transform for 3d vectors
    /// </summary>
    [Serializable]
    public partial struct Translation3 : ITranslation3RW,
        ITransformable3<Translation3, Translation3, RigidTransform3, UniformTransform3, NonUniformTransform3>,
        IEquatable<Translation3>,
        IInvertible<Translation3>,
        ITransform<float3>,
        ITransform<Ray3>,
        IMultipliable<Translation3>,
        IMultipliable<Rotation3Q, RigidTransform3>,
        IMultipliable<Scale1, UniformTransform3>,
        IMultipliable<Scale3, NonUniformTransform3>,
        IMultipliable<RigidTransform3>,
        IMultipliable<UniformTransform3>,
        IMultipliable<NonUniformTransform3>,
        IMultipliable<Matrix3x3Transform3, Matrix4x4Transform3>,
        IMultipliable<Matrix4x4Transform3>,
        IMultipliable<Aabb3M>,
        IMultipliable<Aabb3C>,
        IMultipliable<Aabb3S>,
        IMultipliable<Obb3T>,
        IMultipliable<Obb3M>,
        IMultipliable<ProjectionAxis3x1, Ray3>,
        IDividable<Translation3>,
        IDividable<Rotation3Q, RigidTransform3>,
        IDividable<Scale1, UniformTransform3>,
        IDividable<Scale3, NonUniformTransform3>,
        IDividable<RigidTransform3>,
        IDividable<UniformTransform3>,
        IDividable<NonUniformTransform3>,
        IDividable<Matrix3x3Transform3, Matrix4x4Transform3>,
        IDividable<Matrix4x4Transform3>,
        IDividable<Aabb3M>,
        IDividable<Aabb3C>,
        IDividable<Aabb3S>,
        IDividable<Obb3T>,
        IDividable<Obb3M>,
        IDividable<ProjectionAxis3x1, Ray3>
    {
        public float3 translation;

        public Translation3(float3 translation)
        {
            this.translation = translation;
        }

        public static explicit operator float3(Translation3 o) => o.translation;
        public static explicit operator Translation3(float3 o) => new Translation3(o);

        public static explicit operator Translation3(RigidTransform3 o) => new Translation3(o.translation);
        public static explicit operator Translation3(UniformTransform3 o) => new Translation3(o.translation);
        public static explicit operator Translation3(NonUniformTransform3 o) => new Translation3(o.translation);
        public static explicit operator Translation3(Matrix4x4Transform3 o) => new Translation3(o.matrix.c2.xyz);

        public static readonly Translation3 Identity = new Translation3(float3.zero);
        public static Translation3 Translating(float3 translation) => new Translation3(translation);

        public float3 this[float3 o] => Transform(o);
        Translation3 ITranslation3RW.Translation3 { get => this; set => this = value; }
        Translation3 ITranslation3.Translation3 => this;
        Translation3 ITranslation3W.Translation3 { set => this = value; }
        float3 ITranslation3RW.translation3 { get => translation; set => translation = value; }
        float3 ITranslation3.translation3 => translation;
        float3 ITranslation3W.translation3 { set => translation = value; }

        public override string ToString() => $"{nameof(Translation3)}({translation.x}, {translation.y}, {translation.z})";
        
        public bool Equals(Translation3 o) => NiMath.Equal(this, o);

        public bool NearEquals(Translation3 o, float margin) => NiMath.NearEqual(this, o, margin);
        public bool NearEquals(Rotation3Q o, float margin) => NiMath.NearEqual(this, o, margin);
        public bool NearEquals(Scale1 o, float margin) => NiMath.NearEqual(this, o, margin);
        public bool NearEquals(Scale3 o, float margin) => NiMath.NearEqual(this, o, margin);
        public bool NearEquals(RigidTransform3 o, float margin) => NiMath.NearEqual(this, o, margin);
        public bool NearEquals(UniformTransform3 o, float margin) => NiMath.NearEqual(this, o, margin);
        public bool NearEquals(NonUniformTransform3 o, float margin) => NiMath.NearEqual(this, o, margin);
        public bool NearEquals(Matrix3x3Transform3 o, float margin) => NiMath.NearEqual(this, o, margin);
        public bool NearEquals(Matrix4x4Transform3 o, float margin) => NiMath.NearEqual(this, o, margin);

        public Translation3 Inversed => NiMath.Inverse(this);
        public Matrix4x4Transform3 ToMatrix4x4Transform => float4x4.Translate(translation);

        public Translation3 Translated(float3 translation) => NiMath.Translate(translation, this);
        public RigidTransform3 Rotated(quaternion rotation) => NiMath.Rotate(rotation, this);
        public UniformTransform3 Scaled(float scale) => NiMath.Scale(scale, this);
        public NonUniformTransform3 Scaled(float3 scale) => NiMath.Scale(scale, this);

        public Translation3 Translate(float3 translation) => NiMath.Translate(this, translation);
        public RigidTransform3 Rotate(quaternion rotation) => NiMath.Rotate(this, rotation);
        public UniformTransform3 Scale(float scale) => NiMath.Scale(this, scale);
        public NonUniformTransform3 Scale(float3 scale) => NiMath.Scale(this, scale);

        public Translation3 Translated(Translation3 translation) => NiMath.Translate(translation, this);
        public RigidTransform3 Rotated(Rotation3Q rotation) => NiMath.Rotate(rotation, this);
        public UniformTransform3 Scaled(Scale1 scale) => NiMath.Scale(scale, this);
        public NonUniformTransform3 Scaled(Scale3  scale) => NiMath.Scale(scale, this);

        public Translation3 Translate(Translation3 translation) => NiMath.Translate(this, translation);
        public RigidTransform3 Rotate(Rotation3Q rotation) => NiMath.Rotate(this, rotation);
        public UniformTransform3 Scale(Scale1 scale) => NiMath.Scale(this, scale);
        public NonUniformTransform3 Scale(Scale3  scale) => NiMath.Scale(this, scale);

        public float3 Transform(float3 o) => NiMath.Transform(this, o);
        public Ray3 Transform(Ray3 o) => NiMath.Transform(this, o);

        public float3 Untransform(float3 o) => NiMath.Untransform(this, o);
        public Ray3 Untransform(Ray3 o) => NiMath.Untransform(this, o);

        public Translation3 Mul(Translation3 o) => NiMath.Mul(this, o);
        public RigidTransform3 Mul(Rotation3Q o) => NiMath.Mul(this, o);
        public UniformTransform3 Mul(Scale1 o) => NiMath.Mul(this, o);
        public NonUniformTransform3 Mul(Scale3 o) => NiMath.Mul(this, o);
        public RigidTransform3 Mul(RigidTransform3 o) => NiMath.Mul(this, o);
        public UniformTransform3 Mul(UniformTransform3 o) => NiMath.Mul(this, o);
        public NonUniformTransform3 Mul(NonUniformTransform3 o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Mul(Matrix3x3Transform3 o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Mul(Matrix4x4Transform3 o) => NiMath.Mul(this, o);
        public Aabb3M Mul(Aabb3M o) => NiMath.Mul(this, o);
        public Aabb3C Mul(Aabb3C o) => NiMath.Mul(this, o);
        public Aabb3S Mul(Aabb3S o) => NiMath.Mul(this, o);
        public Obb3T Mul(Obb3T o) => NiMath.Mul(this, o);
        public Obb3M Mul(Obb3M o) => NiMath.Mul(this, o);
        public Ray3 Mul(ProjectionAxis3x1 o) => NiMath.Mul(this, o);
        
        public Translation3 Div(Translation3 o) => NiMath.Div(this, o);
        public RigidTransform3 Div(Rotation3Q o) => NiMath.Div(this, o);
        public UniformTransform3 Div(Scale1 o) => NiMath.Div(this, o);
        public NonUniformTransform3 Div(Scale3 o) => NiMath.Div(this, o);
        public RigidTransform3 Div(RigidTransform3 o) => NiMath.Div(this, o);
        public UniformTransform3 Div(UniformTransform3 o) => NiMath.Div(this, o);
        public NonUniformTransform3 Div(NonUniformTransform3 o) => NiMath.Div(this, o);
        public Matrix4x4Transform3 Div(Matrix3x3Transform3 o) => NiMath.Div(this, o);
        public Matrix4x4Transform3 Div(Matrix4x4Transform3 o) => NiMath.Div(this, o);
        public Aabb3M Div(Aabb3M o) => NiMath.Div(this, o);
        public Aabb3C Div(Aabb3C o) => NiMath.Div(this, o);
        public Aabb3S Div(Aabb3S o) => NiMath.Div(this, o);
        public Obb3T Div(Obb3T o) => NiMath.Div(this, o);
        public Obb3M Div(Obb3M o) => NiMath.Div(this, o);
        public Ray3 Div(ProjectionAxis3x1 o) => NiMath.Div(this, o);
    }

    public static partial class NiMath
    {
        public static bool Equal(Translation3 a, Translation3 b) => Equal(a.translation, b.translation);

        public static bool NearEqualTranslation(float a, Translation3 b, float margin) => math.all(math.abs(new float3(a, 0, 0) - b.translation) <= margin);
        public static bool NearEqualTranslation(Translation3 a, float b, float margin) => math.all(math.abs(a.translation - new float3(b, 0, 0)) <= margin);
        public static bool NearEqualTranslation(float3 a, Translation3 b, float margin) => math.all(math.abs(a - b.translation) <= margin);
        public static bool NearEqualTranslation(Translation3 a, float3 b, float margin) => math.all(math.abs(a.translation - b) <= margin);
        
        [Obsolete]
        public static void NearEqual(Translation3 a, float b, float margin) => throw new System.ArgumentException("NearEqual(TranslationTransform, float) is ambitious. Call either NearEqualTranslation and NearEqualScale");
        public static bool NearEqual(Translation3 a, float3 b, float margin) => NearEqualTranslation(a, b, margin);
        public static bool NearEqual(Translation3 a, Translation3 b, float margin) => NearEqual(a.translation, b.translation, margin);
        public static bool NearEqual(Translation3 a, Rotation3Q b, float margin) => NearEqual(a.translation, float3.zero, margin) && NearEqual(quaternion.identity, b.rotation, margin);
        public static bool NearEqual(Translation3 a, Scale1 b, float margin) => NearEqual(a.translation, float3.zero, margin) && NearEqual(0, b.scale, margin);
        public static bool NearEqual(Translation3 a, Scale3 b, float margin) => NearEqual(a.translation, float3.zero, margin) && NearEqual(float3.zero, b.scale, margin);
        public static bool NearEqual(Translation3 a, RigidTransform3 b, float margin) => NearEqual(a.translation, b.translation, margin) && NearEqual(quaternion.identity, b.rotation, margin);
        public static bool NearEqual(Translation3 a, UniformTransform3 b, float margin) => NearEqual(a.translation, b.translation, margin) && NearEqual(quaternion.identity, b.rotation, margin) && NearEqual(1, b.scale, margin);
        public static bool NearEqual(Translation3 a, NonUniformTransform3 b, float margin) => NearEqual(a.translation, b.translation, margin) && NearEqual(quaternion.identity, b.rotation, margin) && NearEqual((float3)1, b.scale, margin);
        public static bool NearEqual(Translation3 a, Matrix3x3Transform3 b, float margin) => NearEqual(a.translation, float3.zero, margin) && NearEqual(float3x3.identity, b.matrix, margin);
        public static bool NearEqual(Translation3 a, Matrix4x4Transform3 b, float margin) => NearEqual(a.translation, b.translation3, margin) && NearEqual(a.ToMatrix4x4Transform, b, margin);

        public static Translation3 Inverse(Translation3 o) => new Translation3(-o.translation);

        public static Translation3 Translate(float3 translation, Translation3 o) => new Translation3(translation + o.translation);
        public static RigidTransform3 Rotate(quaternion rotation, Translation3 o) => new RigidTransform3(Rotate(rotation, o.translation), rotation);
        public static UniformTransform3 Scale(float scale, Translation3 o) => new UniformTransform3(scale * o.translation, quaternion.identity, scale);
        public static NonUniformTransform3 Scale(float3 scale, Translation3 o) => new NonUniformTransform3(scale * o.translation, quaternion.identity, scale);
        public static Translation3 Translate(Translation3 o, float3 translation) => new Translation3(o.translation + translation);
        public static RigidTransform3 Rotate(Translation3 o, quaternion rotation) => new RigidTransform3(o.translation, rotation);
        public static UniformTransform3 Scale(Translation3 o, float scale) => new UniformTransform3(o.translation, quaternion.identity, scale);
        public static NonUniformTransform3 Scale(Translation3 o, float3 scale) => new NonUniformTransform3(o.translation, quaternion.identity, scale);
        public static Translation3 Translate(Translation3 a, Translation3 b) => new Translation3(a.translation + b.translation);
        public static RigidTransform3 Rotate(Rotation3Q rotation, Translation3 o) => new RigidTransform3(Rotate(rotation, o.translation), rotation);
        public static UniformTransform3 Scale(Scale1 scale, Translation3 o) => new UniformTransform3(scale.scale * o.translation, quaternion.identity, scale.scale);
        public static NonUniformTransform3 Scale(Scale3 scale, Translation3 o) => new NonUniformTransform3(scale.scale * o.translation, quaternion.identity, scale.scale);
        public static RigidTransform3 Rotate(Translation3 o, Rotation3Q rotation) => Rotate(o, rotation.rotation);
        public static UniformTransform3 Scale(Translation3 o, Scale1 scale) => Scale(o, scale.scale);
        public static NonUniformTransform3 Scale(Translation3 o, Scale3 scale) => Scale(o, scale.scale);

        public static float3 Transform(Translation3 a, float3 b) => Translate(a.translation, b);
        public static Ray3 Transform(Translation3 a, Ray3 b) => Translate(a.translation, b);
        public static float3 Untransform(Translation3 a, float3 b) => Translate(-a.translation, b);
        public static Ray3 Untransform(Translation3 a, Ray3 b) => Translate(-a.translation, b);

        public static Translation3 Mul(Translation3 a, Translation3 b) => Translate(a, b);
        public static RigidTransform3 Mul(Translation3 a, Rotation3Q b) => Rotate(a, b);
        public static UniformTransform3 Mul(Translation3 a, Scale1 b) => Scale(a, b.scale);
        public static NonUniformTransform3 Mul(Translation3 a, Scale3 b) => Scale(a, b.scale);
        public static RigidTransform3 Mul(Translation3 a, RigidTransform3 b) => Translate(a.translation, b);
        public static UniformTransform3 Mul(Translation3 a, UniformTransform3 b) => Translate(a.translation, b);
        public static NonUniformTransform3 Mul(Translation3 a, NonUniformTransform3 b) => Translate(a.translation, b);
        public static Matrix4x4Transform3 Mul(Translation3 a, Matrix3x3Transform3 b) => new Matrix4x4Transform3(a.translation, b);
        public static Matrix4x4Transform3 Mul(Translation3 a, Matrix4x4Transform3 b) => Translate(a.translation, b);
        public static Aabb3M Mul(Translation3 a, Aabb3M b) => Mathematics.Aabb3M.TS(a.translation + b.translation3, b.scale3);
        public static Aabb3C Mul(Translation3 a, Aabb3C b) => Mathematics.Aabb3C.TS(a.translation + b.translation3, b.scale3);
        public static Aabb3S Mul(Translation3 a, Aabb3S b) => Mathematics.Aabb3S.TS(a.translation + b.translation3, b.scale3);
        public static Obb3T Mul(Translation3 a, Obb3T b) => Mul(a, b.NonUniformTransform);
        public static Obb3M Mul(Translation3 a, Obb3M b) => Mul(a, b.ToMatrix4x4Transform);
        public static Ray3 Mul(Translation3 a, ProjectionAxis3x1 b) => new Ray3(a, b);
        public static Translation3 Div(Translation3 a, Translation3 b) => Translate(Inverse(a), b);
        public static RigidTransform3 Div(Translation3 a, Rotation3Q b) => Rotate(Inverse(a), b);
        public static UniformTransform3 Div(Translation3 a, Scale1 b) => Scale(Inverse(a), b);
        public static NonUniformTransform3 Div(Translation3 a, Scale3 b) => Scale(Inverse(a), b);
        public static RigidTransform3 Div(Translation3 a, RigidTransform3 b) => Translate(-a.translation, b);
        public static UniformTransform3 Div(Translation3 a, UniformTransform3 b) => Translate(-a.translation, b);
        public static NonUniformTransform3 Div(Translation3 a, NonUniformTransform3 b) => Translate(-a.translation, b);
        public static Matrix4x4Transform3 Div(Translation3 a, Matrix3x3Transform3 b) => new Matrix4x4Transform3(-a.translation, b);
        public static Matrix4x4Transform3 Div(Translation3 a, Matrix4x4Transform3 b) => Translate(-a.translation, b);
        public static Aabb3M Div(Translation3 a, Aabb3M b) => Mul(Inverse(a), b);
        public static Aabb3C Div(Translation3 a, Aabb3C b) => Mul(Inverse(a), b);
        public static Aabb3S Div(Translation3 a, Aabb3S b) => Mul(Inverse(a), b);
        public static Obb3T Div(Translation3 a, Obb3T b) => Mul(Inverse(a), b);
        public static Obb3M Div(Translation3 a, Obb3M b) => Mul(Inverse(a), b);
        public static Ray3 Div(Translation3 a, ProjectionAxis3x1 b) => new Ray3(Inverse(a), b);

        public static Translation3 Translation(float3 translation) => new Translation3(translation);
    }

    public partial struct TranslationTransform1
    {
        public float translation;
        public TranslationTransform1(float translation) => this.translation = translation;

        public static Ray3 operator *(Ray3 a, TranslationTransform1 b) => NiMath.Mul(a, b);
    }
}