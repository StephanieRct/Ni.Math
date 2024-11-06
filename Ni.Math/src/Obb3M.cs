using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    /// <summary>
    /// Represent the sequence of transformations: Translation * Rotation * Shear * NonUniformScale
    /// </summary>
    [Serializable]
    public struct Obb3M : ITransform3, ITranslation3RW, IRotation3QRW, INonUniformScale3RW,
        IEquatable<Obb3M>,
        INearEquatable<Obb3M, float>,
        ITransformable3<Translation3, Obb3M, Obb3M, Obb3M, Obb3M>,
        IToMatrix4x4Transform,
        IInvertible<Obb3M>,
        ITransform<float3>,
        ITransform<Ray3>,
        IMultipliable<Translation3, Obb3M>,
        IMultipliable<Rotation3Q, Obb3M>,
        IMultipliable<Scale1, Obb3M>,
        IMultipliable<Scale3, Obb3M>,
        IMultipliable<RigidTransform3, Obb3M>,
        IMultipliable<UniformTransform3, Obb3M>,
        IMultipliable<NonUniformTransform3, Obb3M>,
        IMultipliable<Matrix3x3Transform3, Obb3M>,
        IMultipliable<Matrix4x4Transform3, Obb3M>,
        IMultipliable<Aabb3M, Obb3M>,
        IMultipliable<Aabb3C, Obb3M>,
        IMultipliable<Aabb3S, Obb3M>,
        IMultipliable<Obb3T, Obb3M>,
        IMultipliable<Obb3M, Obb3M>,
        IDividable<Translation3, Obb3M>,
        IDividable<Rotation3Q, Obb3M>,
        IDividable<Scale1, Obb3M>,
        IDividable<Scale3, Obb3M>,
        IDividable<RigidTransform3, Obb3M>,
        IDividable<UniformTransform3, Obb3M>,
        IDividable<NonUniformTransform3, Obb3M>,
        IDividable<Matrix3x3Transform3, Obb3M>,
        IDividable<Matrix4x4Transform3, Obb3M>,
        IDividable<Aabb3M, Obb3M>,
        IDividable<Aabb3C, Obb3M>,
        IDividable<Aabb3S, Obb3M>,
        IDividable<Obb3T, Obb3M>,
        IDividable<Obb3M, Obb3M>
    {
        public Matrix4x4Transform3 Matrix4x4Transform;

        public Obb3M(float4x4 matrix) => Matrix4x4Transform = new Matrix4x4Transform3(matrix);
        public Obb3M(Matrix4x4Transform3 matrix4x4Transform) => Matrix4x4Transform = matrix4x4Transform;
        public Obb3M(float4 column0, float4 column1, float4 column2, float4 column3) => Matrix4x4Transform = new float4x4(column0, column1, column2, column3);
        public Obb3M(float3 translation, float3x3 rotationScale) => Matrix4x4Transform = new float4x4(rotationScale, translation);
        public Obb3M(float3 translation, quaternion rotation, float scale) => Matrix4x4Transform = float4x4.TRS(translation, rotation, scale);
        public Obb3M(float3 translation, quaternion rotation, float3 scale) => Matrix4x4Transform = float4x4.TRS(translation, rotation, scale);
        public Obb3M(float3 translation, quaternion rotation) => Matrix4x4Transform = new float4x4(rotation, translation);
        public Obb3M(float3 translation, float scale) => Matrix4x4Transform = float4x4.TRS(translation, quaternion.identity, scale);
        public Obb3M(float3 translation, float3 scale) => Matrix4x4Transform = float4x4.TRS(translation, quaternion.identity, scale);
        public Obb3M(quaternion rotation, float scale) => Matrix4x4Transform = float4x4.TRS(0, rotation, scale);
        public Obb3M(quaternion rotation, float3 scale) => Matrix4x4Transform = float4x4.TRS(0, rotation, scale);
        public Obb3M(quaternion rotation) => Matrix4x4Transform = new float4x4(rotation, float3.zero);
        public Obb3M(Translation3 translation, Matrix3x3Transform3 rotationScale) => Matrix4x4Transform = new float4x4(rotationScale, translation.translation);
        public Obb3M(Translation3 translation, Rotation3Q rotation, Scale1 scale) => Matrix4x4Transform = float4x4.TRS(translation.translation, rotation, scale.scale);
        public Obb3M(Translation3 translation, Rotation3Q rotation, Scale3 scale) => Matrix4x4Transform = float4x4.TRS(translation.translation, rotation, scale.scale);
        public Obb3M(Translation3 translation, Rotation3Q rotation) => Matrix4x4Transform = new float4x4(rotation, translation.translation);
        public Obb3M(Translation3 translation, Scale1 scale) => Matrix4x4Transform = float4x4.TRS(translation.translation, quaternion.identity, scale.scale);
        public Obb3M(Translation3 translation, Scale3 scale) => Matrix4x4Transform = float4x4.TRS(translation.translation, quaternion.identity, scale.scale);
        public Obb3M(Rotation3Q rotation, Scale1 scale) => Matrix4x4Transform = float4x4.TRS(0, rotation, scale.scale);
        public Obb3M(Rotation3Q rotation, Scale3 scale) => Matrix4x4Transform = float4x4.TRS(0, rotation, scale.scale);
        public Obb3M(Translation3 translation) => Matrix4x4Transform = float4x4.Translate(translation.translation);
        public Obb3M(Rotation3Q rotation) => Matrix4x4Transform = new float4x4(rotation, float3.zero);
        public Obb3M(Scale1 scale) => Matrix4x4Transform = float4x4.Scale(scale.scale);
        public Obb3M(Scale3 scale) => Matrix4x4Transform = float4x4.Scale(scale.scale);

        public static implicit operator float4x4(Obb3M o) => o.Matrix4x4Transform;
        public static implicit operator Obb3M(float4x4 o) => new Obb3M(o);
        public static implicit operator Matrix4x4Transform3(Obb3M o) => o.Matrix4x4Transform;
        public static implicit operator Obb3M(Matrix4x4Transform3 o) => new Obb3M(o);
        public static readonly Obb3M Identity = new Obb3M(Matrix4x4Transform3.Identity);
        public static readonly Obb3M Origin = new Obb3M(new float4x4(1.0f, 0.0f, 0.0f, -0.5f, 0.0f, 1.0f, 0.0f, -0.5f, 0.0f, 0.0f, 1.0f, -0.5f, 0.0f, 0.0f, 0.0f, 1.0f));
        public static Obb3M Translating(float3 translation) => new Matrix4x4Transform3(float4x4.Translate(translation));
        public static Obb3M Rotating(quaternion rotation) => new Matrix4x4Transform3(new float4x4(new float3x3(rotation), float3.zero));
        public static Obb3M Scaling(float scale) => new Matrix4x4Transform3(float4x4.Scale(scale));
        public static Obb3M Scaling(float3 scale) => new Matrix4x4Transform3(float4x4.Scale(scale));
        public static Obb3M TRS(float3 translation, quaternion rotation, float3 scale) => new Matrix4x4Transform3(float4x4.TRS(translation, rotation, scale));
        public float3 translation3
        {
            get => Matrix4x4Transform.translation3;
            set => Matrix4x4Transform.translation3 = value;
        }

        public quaternion rotation3
        {
            get => Matrix4x4Transform.rotation3;
            set => Matrix4x4Transform.rotation3 = value;
        }

        public float3 scale3
        {
            get => Matrix4x4Transform.scale3;
            set => Matrix4x4Transform.scale3 = value;
        }
        public Aabb3M TranslationScale { get => Matrix4x4Transform.TranslationScale; set => Matrix4x4Transform.TranslationScale = value; }
        public RigidTransform3 TranslationRotation { get => Matrix4x4Transform.TranslationRotation; set => Matrix4x4Transform.TranslationRotation = value; }
        public Matrix3x3Transform3 RotationScale { get => Matrix4x4Transform.RotationScale; set => Matrix4x4Transform.RotationScale = value; }
        public float3 this[float3 o] => Matrix4x4Transform.Transform(o);

        public Translation3 Translation3 { get => new Translation3(translation3); set => translation3 = value.translation; }
        public Rotation3Q Rotation3 { get => new Rotation3Q(rotation3); set => rotation3 = value.rotation; }
        public Scale3 Scale3 { get => new Scale3(scale3); set => scale3 = value.scale; }

        public override string ToString() => $"{nameof(Obb3M)}({Matrix4x4Transform.matrix.c0.x}, {Matrix4x4Transform.matrix.c1.x}, {Matrix4x4Transform.matrix.c2.x}, {Matrix4x4Transform.matrix.c3.x}, {Matrix4x4Transform.matrix.c0.y}, {Matrix4x4Transform.matrix.c1.y}, {Matrix4x4Transform.matrix.c2.y}, {Matrix4x4Transform.matrix.c3.y}, {Matrix4x4Transform.matrix.c0.z}, {Matrix4x4Transform.matrix.c1.z}, {Matrix4x4Transform.matrix.c2.z}, {Matrix4x4Transform.matrix.c3.z}, {Matrix4x4Transform.matrix.c0.w}, {Matrix4x4Transform.matrix.c1.w}, {Matrix4x4Transform.matrix.c2.w}, {Matrix4x4Transform.matrix.c3.w})";
        
        public bool Equals(Obb3M other) => NiMath.Equal(this, other);
        public bool NearEquals(Obb3M other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Translation3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Rotation3Q other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Scale1 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Scale3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(RigidTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(UniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(NonUniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Matrix3x3Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Matrix4x4Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);

        public Obb3M Inversed => NiMath.Inverse(this);
        public Matrix4x4Transform3 ToMatrix4x4Transform => Matrix4x4Transform;

        public Obb3M Translated(float3 translation) => NiMath.Translate(translation, this);
        public Obb3M Rotated(quaternion rotation) => NiMath.Rotate(rotation, this);
        public Obb3M Scaled(float scale) => NiMath.Scale(scale, this);
        public Obb3M Scaled(float3 scale) => NiMath.Scale(scale, this);

        public Obb3M Translate(float3 translation) => NiMath.Translate(this, translation);
        public Obb3M Rotate(quaternion rotation) => NiMath.Rotate(this, rotation);
        public Obb3M Scale(float scale) => NiMath.Scale(this, scale);
        public Obb3M Scale(float3 scale) => NiMath.Scale(this, scale);

        public Obb3M Translated(Translation3 translation) => NiMath.Translate(translation, this);
        public Obb3M Rotated(Rotation3Q rotation) => NiMath.Rotate(rotation, this);
        public Obb3M Scaled(Scale1 scale) => NiMath.Scale(scale, this);
        public Obb3M Scaled(Scale3 scale) => NiMath.Scale(scale, this);

        public Obb3M Translate(Translation3 translation) => NiMath.Translate(this, translation);
        public Obb3M Rotate(Rotation3Q rotation) => NiMath.Rotate(this, rotation);
        public Obb3M Scale(Scale1 scale) => NiMath.Scale(this, scale);
        public Obb3M Scale(Scale3 scale) => NiMath.Scale(this, scale);

        public float3 Transform(float3 o) => Matrix4x4Transform.Transform(o);
        public Ray3 Transform(Ray3 o) => Matrix4x4Transform.Transform(o);
        public float3 Untransform(float3 o) => Matrix4x4Transform.Untransform(o);
        public Ray3 Untransform(Ray3 o) => Matrix4x4Transform.Untransform(o);

        public Obb3M Mul(Translation3 o) => NiMath.Mul(this, o);
        public Obb3M Mul(Rotation3Q o) => NiMath.Mul(this, o);
        public Obb3M Mul(Scale1 o) => NiMath.Mul(this, o);
        public Obb3M Mul(Scale3 o) => NiMath.Mul(this, o);
        public Obb3M Mul(RigidTransform3 o) => NiMath.Mul(this, o);
        public Obb3M Mul(UniformTransform3 o) => NiMath.Mul(this, o);
        public Obb3M Mul(NonUniformTransform3 o) => NiMath.Mul(this, o);
        public Obb3M Mul(Matrix3x3Transform3 o) => NiMath.Mul(this, o);
        public Obb3M Mul(Matrix4x4Transform3 o) => NiMath.Mul(this, o);
        public Obb3M Mul(Aabb3M o) => NiMath.Mul(this, o);
        public Obb3M Mul(Aabb3C o) => NiMath.Mul(this, o);
        public Obb3M Mul(Aabb3S o) => NiMath.Mul(this, o);
        public Obb3M Mul(Obb3T o) => NiMath.Mul(this, o);
        public Obb3M Mul(Obb3M o) => NiMath.Mul(this, o);
        public Obb3M Div(Translation3 o) => NiMath.Div(this, o);
        public Obb3M Div(Rotation3Q o) => NiMath.Div(this, o);
        public Obb3M Div(Scale1 o) => NiMath.Div(this, o);
        public Obb3M Div(Scale3 o) => NiMath.Div(this, o);
        public Obb3M Div(RigidTransform3 o) => NiMath.Div(this, o);
        public Obb3M Div(UniformTransform3 o) => NiMath.Div(this, o);
        public Obb3M Div(NonUniformTransform3 o) => NiMath.Div(this, o);
        public Obb3M Div(Matrix3x3Transform3 o) => NiMath.Div(this, o);
        public Obb3M Div(Matrix4x4Transform3 o) => NiMath.Div(this, o);
        public Obb3M Div(Aabb3M o) => NiMath.Div(this, o);
        public Obb3M Div(Aabb3C o) => NiMath.Div(this, o);
        public Obb3M Div(Aabb3S o) => NiMath.Div(this, o);
        public Obb3M Div(Obb3T o) => NiMath.Div(this, o);
        public Obb3M Div(Obb3M o) => NiMath.Div(this, o);
    }

    public static partial class NiMath
    {
        public static bool Equal(Obb3M a, Obb3M b) => Equal(a.Matrix4x4Transform, b.Matrix4x4Transform);

        public static bool NearEqual(Obb3M a, Obb3M b, float margin) => NearEqual(a.Matrix4x4Transform, b.Matrix4x4Transform, margin);
        public static bool NearEqual(Obb3M a, Translation3 b, float margin) => NearEqual(a.Matrix4x4Transform, b, margin);
        public static bool NearEqual(Obb3M a, Rotation3Q b, float margin) => NearEqual(a.Matrix4x4Transform, b, margin);
        public static bool NearEqual(Obb3M a, Scale1 b, float margin) => NearEqual(a.Matrix4x4Transform, b, margin);
        public static bool NearEqual(Obb3M a, Scale3 b, float margin) => NearEqual(a.Matrix4x4Transform, b, margin);
        public static bool NearEqual(Obb3M a, RigidTransform3 b, float margin) => NearEqual(a.Matrix4x4Transform, b, margin);
        public static bool NearEqual(Obb3M a, UniformTransform3 b, float margin) => NearEqual(a.Matrix4x4Transform, b, margin);
        public static bool NearEqual(Obb3M a, NonUniformTransform3 b, float margin) => NearEqual(a.Matrix4x4Transform, b, margin);
        public static bool NearEqual(Obb3M a, Matrix3x3Transform3 b, float margin) => NearEqual(a.Matrix4x4Transform, b, margin);
        public static bool NearEqual(Obb3M a, Matrix4x4Transform3 b, float margin) => NearEqual(a.Matrix4x4Transform, b, margin);

        public static Obb3M Inverse(Obb3M a) => new Obb3M(a.Matrix4x4Transform.Inversed);

        public static float3 RotateVector(Obb3M rotation, float3 vector) => RotateVector(rotation.Matrix4x4Transform, vector);

        public static Obb3M Translate(float3 translation, Obb3M o) => new Obb3M(Translate(translation, o.Matrix4x4Transform));
        public static Obb3M Rotate(quaternion rotation, Obb3M o) => Mul((Rotation3Q)rotation, o);
        public static Obb3M Scale(float scale, Obb3M o) => new Obb3M(Scale(scale, o.Matrix4x4Transform));
        public static Obb3M Scale(float3 scale, Obb3M o) => new Obb3M(Scale(scale, o.Matrix4x4Transform));
        public static Obb3M Translate(Obb3M o, float3 translation) => Mul(o, (Translation3)translation);
        public static Obb3M Rotate(Obb3M o, quaternion rotation) => Mul(o, (Rotation3Q)rotation);
        public static Obb3M Scale(Obb3M o, float scale) => Mul(o, (Scale1)scale);
        public static Obb3M Scale(Obb3M o, float3 scale) => Mul(o, (Scale3)scale);

        public static Obb3M Translate(Translation3 translation, Obb3M o) => new Obb3M(Translate(translation, o.Matrix4x4Transform));
        public static Obb3M Rotate(Rotation3Q rotation, Obb3M o) => Mul((Rotation3Q)rotation, o);
        public static Obb3M Scale(Scale1 scale, Obb3M o) => new Obb3M(Scale(scale, o.Matrix4x4Transform));
        public static Obb3M Scale(Scale3 scale, Obb3M o) => new Obb3M(Scale(scale, o.Matrix4x4Transform));
        public static Obb3M Translate(Obb3M o, Translation3 translation) => Mul(o, (Translation3)translation);
        public static Obb3M Rotate(Obb3M o, Rotation3Q rotation) => Mul(o, (Rotation3Q)rotation);
        public static Obb3M Scale(Obb3M o, Scale1 scale) => Mul(o, (Scale1)scale);
        public static Obb3M Scale(Obb3M o, Scale3 scale) => Mul(o, (Scale3)scale);

        public static float3 Transform(Obb3M a, float3 b) => Transform(a.Matrix4x4Transform, b);
        public static Ray3 Transform(Obb3M a, Ray3 b) => Transform(a.Matrix4x4Transform, b);
        public static float3 Untransform(Obb3M a, float3 b) => Untransform(a.Matrix4x4Transform, b);
        public static Ray3 Untransform(Obb3M a, Ray3 b) => Untransform(a.Matrix4x4Transform, b);

        public static Obb3M Mul(Obb3M a, Translation3 b) => Mul(a.Matrix4x4Transform, b);
        public static Obb3M Mul(Obb3M a, Rotation3Q b) => Mul(a.Matrix4x4Transform, b);
        public static Obb3M Mul(Obb3M a, Scale1 b) => Mul(a.Matrix4x4Transform, b);
        public static Obb3M Mul(Obb3M a, Scale3 b) => Mul(a.Matrix4x4Transform, b);
        public static Obb3M Mul(Obb3M a, RigidTransform3 b) => Mul(a.Matrix4x4Transform, b);
        public static Obb3M Mul(Obb3M a, UniformTransform3 b) => Mul(a.Matrix4x4Transform, b);
        public static Obb3M Mul(Obb3M a, NonUniformTransform3 b) => Mul(a.Matrix4x4Transform, b);
        public static Obb3M Mul(Obb3M a, Matrix3x3Transform3 b) => Mul(a.Matrix4x4Transform, b);
        public static Obb3M Mul(Obb3M a, Matrix4x4Transform3 b) => Mul(a.Matrix4x4Transform, b);
        public static Obb3M Mul(Obb3M a, Aabb3M b) => Mul(a.Matrix4x4Transform, b);
        public static Obb3M Mul(Obb3M a, Aabb3C b) => Mul(a.Matrix4x4Transform, b);
        public static Obb3M Mul(Obb3M a, Aabb3S b) => Mul(a.Matrix4x4Transform, b);
        public static Obb3M Mul(Obb3M a, Obb3T b) => Mul(a.Matrix4x4Transform, b);
        public static Obb3M Mul(Obb3M a, Obb3M b) => Mul(a.Matrix4x4Transform, b);
        public static Obb3M Div(Obb3M a, Translation3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3M a, Rotation3Q b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3M a, Scale1 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3M a, Scale3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3M a, RigidTransform3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3M a, UniformTransform3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3M a, NonUniformTransform3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3M a, Matrix3x3Transform3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3M a, Matrix4x4Transform3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3M a, Aabb3M b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3M a, Aabb3C b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3M a, Aabb3S b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3M a, Obb3T b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3M a, Obb3M b) => Mul(Inverse(a), b);

        public static Obb3M Obb3M(Matrix4x4Transform3 matrix4x4Transform) => new Obb3M(matrix4x4Transform);
        public static Obb3M Obb3M(float3 translation, quaternion rotation, float3 scale) => new Obb3M(translation, rotation, scale);
    }
}