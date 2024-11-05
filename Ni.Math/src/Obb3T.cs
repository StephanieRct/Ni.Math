using System;
using Unity.Mathematics;
using UnityEngine.UIElements;

namespace Ni.Mathematics
{
    /// <summary>
    /// Represent the sequence of transformations: Translation * Rotation * NonUniformScale
    /// </summary>
    [Serializable]
    public struct Obb3T : ITransform3, ITranslation3RW, IRotation3QRW, INonUniformScale3RW,
        IEquatable<Obb3T>,
        INearEquatable<Obb3T, float>,
        ITransformable3<Translation3, Obb3T, Obb3T, Obb3T, Obb3M, Obb3T, Obb3M, Obb3T, Obb3T>,
        IToNonUniformTransform3,
        IToMatrix4x4Transform,
        IInvertible<Obb3M>,
        ITransform<float3>,
        ITransform<Ray3>,
        IMultipliable<Translation3, Obb3T>,
        IMultipliable<Rotation3Q, Obb3M>,
        IMultipliable<Scale1, Obb3T>,
        IMultipliable<Scale3, Obb3T>,
        IMultipliable<RigidTransform3, Obb3M>,
        IMultipliable<UniformTransform3, Obb3M>,
        IMultipliable<NonUniformTransform3, Obb3M>,
        IMultipliable<Matrix3x3Transform3, Obb3M>,
        IMultipliable<Matrix4x4Transform3, Obb3M>,
        IMultipliable<Aabb3M, Obb3T>,
        IMultipliable<Aabb3C, Obb3T>,
        IMultipliable<Aabb3S, Obb3T>,
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
        public NonUniformTransform3 NonUniformTransform;

        public Obb3T(NonUniformTransform3 nonUniformTransform) => NonUniformTransform = nonUniformTransform;
        public Obb3T(float3 translation, quaternion rotation, float3 scale) => NonUniformTransform = new NonUniformTransform3(translation, rotation, scale);
        public Obb3T(float3 translation, quaternion rotation) => NonUniformTransform = new NonUniformTransform3(translation, rotation);
        public Obb3T(quaternion rotation) => NonUniformTransform = new NonUniformTransform3(rotation);
        public Obb3T(quaternion rotation, float3 scale) => NonUniformTransform = new NonUniformTransform3(rotation, scale);
        public Obb3T(Translation3 translation, Rotation3Q rotation, Scale3 scale) => NonUniformTransform = new NonUniformTransform3(translation, rotation, scale);
        public Obb3T(Translation3 translation, Rotation3Q rotation) => NonUniformTransform = new NonUniformTransform3(translation, rotation);
        public Obb3T(Translation3 translation, Scale3 scale) => NonUniformTransform = new NonUniformTransform3(translation, scale);
        public Obb3T(Rotation3Q rotation, Scale3 scale) => NonUniformTransform = new NonUniformTransform3(rotation, scale);
        public Obb3T(Translation3 translation) => NonUniformTransform = new NonUniformTransform3(translation);
        public Obb3T(Rotation3Q rotation) => NonUniformTransform = new NonUniformTransform3(rotation);
        public Obb3T(Scale3 scale) => NonUniformTransform = new NonUniformTransform3(scale);

        public static readonly Obb3T Identity = new Obb3T(NonUniformTransform3.Identity);
        public static readonly Obb3T Origin = new Obb3T(new NonUniformTransform3(-0.5f, quaternion.identity, 1));

        public static implicit operator NonUniformTransform3(Obb3T o) => o.NonUniformTransform;
        public static implicit operator Obb3T(NonUniformTransform3 o) => new Obb3T(o);
        public static Obb3T Translating(float3 translation) => new NonUniformTransform3(translation, quaternion.identity, 1);
        public static Obb3T Rotating(quaternion rotation) => new NonUniformTransform3(float3.zero, rotation, 1);
        public static Obb3T Scaling(float scale) => new NonUniformTransform3(float3.zero, quaternion.identity, scale);
        public static Obb3T Scaling(float3 scale) => new NonUniformTransform3(float3.zero, quaternion.identity, scale);
        public static Obb3T TRS(float3 translation, quaternion rotation, float scale) => new NonUniformTransform3(translation, rotation, scale);
        public static Obb3T TRS(float3 translation, quaternion rotation, float3 scale) => new NonUniformTransform3(translation, rotation, scale);

        public float3 translation3
        {
            get => NonUniformTransform.translation;
            set => NonUniformTransform.translation = value;
        }

        public quaternion rotation3
        {
            get => NonUniformTransform.rotation;
            set => NonUniformTransform.rotation = value;
        }

        public float3 scale3
        {
            get => NonUniformTransform.scale;
            set => NonUniformTransform.scale = value;
        }

        public Translation3 Translation3 { get => new Translation3(translation3); set => translation3 = value.translation; }
        public Rotation3Q Rotation3 { get => new Rotation3Q(rotation3); set => rotation3 = value.rotation; }
        public Scale3 Scale3 { get => new Scale3(scale3); set => scale3 = value.scale; }

        public Aabb3M Aabb3M
        {
            get => new Aabb3M(NonUniformTransform.translation, NonUniformTransform.scale);
            set
            {
                NonUniformTransform.translation = value.translation3;
                NonUniformTransform.scale = value.scale3;
            }
        }

        public override string ToString() => $"{nameof(Obb3T)}(Tx:{NonUniformTransform.translation.x}, Ty:{NonUniformTransform.translation.y}, Tz:{NonUniformTransform.translation.z}, Rx:{NonUniformTransform.rotation.value.x}, Ry:{NonUniformTransform.rotation.value.y}, Rz:{NonUniformTransform.rotation.value.z}, Rw:{NonUniformTransform.rotation.value.w}, Sx:{NonUniformTransform.scale.x}, Sy:{NonUniformTransform.scale.y}, Sz:{NonUniformTransform.scale.z})";
        
        public bool Equals(Obb3T other) => NiMath.Equal(this, other);

        public bool NearEquals(Obb3T other, float margin) => NiMath.NearEqual(this, other, margin);
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
        public NonUniformTransform3 ToNonUniformTransform3 => new NonUniformTransform3(translation3, quaternion.identity, scale3);
        public Matrix4x4Transform3 ToMatrix4x4Transform => NonUniformTransform.ToMatrix4x4Transform;

        public Obb3T Translated(float3 translation) => NiMath.Translate(translation, this);
        public Obb3T Rotated(quaternion rotation) => NiMath.Rotate(rotation, this);
        public Obb3T Scaled(float scale) => NiMath.Scale(scale, this);
        public Obb3M Scaled(float3 scale) => NiMath.Scale(scale, this);

        public Obb3T Translate(float3 translation) => NiMath.Translate(this, translation);
        public Obb3M Rotate(quaternion rotation) => NiMath.Rotate(this, rotation);
        public Obb3T Scale(float scale) => NiMath.Scale(this, scale);
        public Obb3T Scale(float3 scale) => NiMath.Scale(this, scale);

        public Obb3T Translated(Translation3 translation) => NiMath.Translate(translation, this);
        public Obb3T Rotated(Rotation3Q rotation) => NiMath.Rotate(rotation, this);
        public Obb3T Scaled(Scale1 scale) => NiMath.Scale(scale, this);
        public Obb3M Scaled(Scale3 scale) => NiMath.Scale(scale, this);

        public Obb3T Translate(Translation3 translation) => NiMath.Translate(this, translation);
        public Obb3M Rotate(Rotation3Q rotation) => NiMath.Rotate(this, rotation);
        public Obb3T Scale(Scale1 scale) => NiMath.Scale(this, scale);
        public Obb3T Scale(Scale3 scale) => NiMath.Scale(this, scale);

        public float3 Transform(float3 p) => NiMath.Transform(this, p);
        public Ray3 Transform(Ray3 p) => NiMath.Transform(this, p);
        public float3 Untransform(float3 p) => NiMath.Untransform(this, p);
        public Ray3 Untransform(Ray3 p) => NiMath.Untransform(this, p);

        public Obb3T Mul(Translation3 o) => NiMath.Mul(this, o);
        public Obb3M Mul(Rotation3Q o) => NiMath.Mul(this, o);
        public Obb3T Mul(Scale1 o) => NiMath.Mul(this, o);
        public Obb3T Mul(Scale3 o) => NiMath.Mul(this, o);
        public Obb3M Mul(RigidTransform3 o) => NiMath.Mul(this, o);
        public Obb3M Mul(UniformTransform3 o) => NiMath.Mul(this, o);
        public Obb3M Mul(NonUniformTransform3 o) => NiMath.Mul(this, o);
        public Obb3M Mul(Matrix3x3Transform3 o) => NiMath.Mul(this, o);
        public Obb3M Mul(Matrix4x4Transform3 o) => NiMath.Mul(this, o);
        public Obb3T Mul(Aabb3M o) => NiMath.Mul(this, o);
        public Obb3T Mul(Aabb3C o) => NiMath.Mul(this, o);
        public Obb3T Mul(Aabb3S o) => NiMath.Mul(this, o);
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
        public static bool Equal(Obb3T a, Obb3T b) => Equal(a.NonUniformTransform, b.NonUniformTransform);

        public static bool NearEqual(Obb3T a, Obb3T b, float margin) => NearEqual(a.NonUniformTransform, b.NonUniformTransform, margin);
        public static bool NearEqual(Obb3T a, Translation3 b, float margin) => NearEqual(a.translation3, b.translation, margin) && NearEqual(a.rotation3, quaternion.identity, margin) && NearEqual(a.scale3, (float3)1, margin);
        public static bool NearEqual(Obb3T a, Rotation3Q b, float margin) => NearEqual(a.translation3, float3.zero, margin) && NearEqual(a.rotation3, b.rotation, margin) && NearEqual(a.scale3, (float3)1, margin);
        public static bool NearEqual(Obb3T a, Scale1 b, float margin) => NearEqual(a.translation3, float3.zero, margin) && NearEqual(a.rotation3, quaternion.identity, margin) && NearEqual(a.scale3, (float3)b.scale, margin);
        public static bool NearEqual(Obb3T a, Scale3 b, float margin) => NearEqual(a.translation3, float3.zero, margin) && NearEqual(a.rotation3, quaternion.identity, margin) && NearEqual(a.scale3, b.scale, margin);
        public static bool NearEqual(Obb3T a, RigidTransform3 b, float margin) => NearEqual(a.translation3, b.translation, margin) && NearEqual(a.rotation3, b.rotation, margin) && NearEqual(a.scale3, float3.zero, margin);
        public static bool NearEqual(Obb3T a, UniformTransform3 b, float margin) => NearEqual(a.translation3, b.translation, margin) && NearEqual(a.rotation3, b.rotation, margin) && NearEqual(a.scale3, (float3)b.scale, margin);
        public static bool NearEqual(Obb3T a, NonUniformTransform3 b, float margin) => NearEqual(a.translation3, b.translation, margin) && NearEqual(a.rotation3, b.rotation, margin) && NearEqual(a.scale3, b.scale, margin);
        public static bool NearEqual(Obb3T a, Matrix3x3Transform3 b, float margin) => NearEqual(a.translation3, float3.zero, margin) && NearEqual(new Matrix3x3Transform3(a.rotation3, a.scale3), b, margin);
        public static bool NearEqual(Obb3T a, Matrix4x4Transform3 b, float margin) => NearEqual(a.ToMatrix4x4Transform, b, margin);

        public static Obb3M Inverse(Obb3T a) => new Obb3M(a.NonUniformTransform.Inversed);

        public static float3 RotateVector(Obb3T rotation, float3 vector) => RotateVector(rotation.NonUniformTransform, vector);

        public static Obb3T Translate(float3 translation, Obb3T o) => new Obb3T(Translate(translation, o.NonUniformTransform));
        public static Obb3T Rotate(quaternion rotation, Obb3T o) => Mul((Rotation3Q)rotation, o);
        public static Obb3T Scale(float scale, Obb3T o) => new Obb3T(Scale(scale, o.NonUniformTransform));
        public static Obb3M Scale(float3 scale, Obb3T o) => new Obb3M(Scale(scale, o.NonUniformTransform));
        public static Obb3T Translate(Obb3T o, float3 translation) => Mul(o, (Translation3)translation);
        public static Obb3M Rotate(Obb3T o, quaternion rotation) => Mul(o, (Rotation3Q)rotation);
        public static Obb3T Scale(Obb3T o, float scale) => Mul(o, (Scale1)scale);
        public static Obb3T Scale(Obb3T o, float3 scale) => Mul(o, (Scale3)scale);

        public static Obb3T Translate(Translation3 translation, Obb3T o) => new Obb3T(Translate(translation, o.NonUniformTransform));
        public static Obb3T Rotate(Rotation3Q rotation, Obb3T o) => Mul((Rotation3Q)rotation, o);
        public static Obb3T Scale(Scale1 scale, Obb3T o) => new Obb3T(Scale(scale, o.NonUniformTransform));
        public static Obb3M Scale(Scale3 scale, Obb3T o) => new Obb3M(Scale(scale, o.NonUniformTransform));
        public static Obb3T Translate(Obb3T o, Translation3 translation) => Mul(o, (Translation3)translation);
        public static Obb3M Rotate(Obb3T o, Rotation3Q rotation) => Mul(o, (Rotation3Q)rotation);
        public static Obb3T Scale(Obb3T o, Scale1 scale) => Mul(o, (Scale1)scale);
        public static Obb3T Scale(Obb3T o, Scale3 scale) => Mul(o, (Scale3)scale);

        public static float3 Transform(Obb3T a, float3 b) => Transform(a.NonUniformTransform, b);
        public static Ray3 Transform(Obb3T a, Ray3 b) => Transform(a.NonUniformTransform, b);
        public static float3 Untransform(Obb3T a, float3 b) => Untransform(a.NonUniformTransform, b);
        public static Ray3 Untransform(Obb3T a, Ray3 b) => Untransform(a.NonUniformTransform, b);

        public static Obb3T Mul(Obb3T a, Translation3 b) => Mul(a.NonUniformTransform, b);
        public static Obb3M Mul(Obb3T a, Rotation3Q b) => Mul(a.NonUniformTransform, b);
        public static Obb3T Mul(Obb3T a, Scale1 b) => Mul(a.NonUniformTransform, b);
        public static Obb3T Mul(Obb3T a, Scale3 b) => Mul(a.NonUniformTransform, b);
        public static Obb3M Mul(Obb3T a, RigidTransform3 b) => Mul(a.NonUniformTransform, b);
        public static Obb3M Mul(Obb3T a, UniformTransform3 b) => Mul(a.NonUniformTransform, b);
        public static Obb3M Mul(Obb3T a, NonUniformTransform3 b) => Mul(a.NonUniformTransform, b);
        public static Obb3M Mul(Obb3T a, Matrix3x3Transform3 b) => Mul(a.NonUniformTransform, b);
        public static Obb3M Mul(Obb3T a, Matrix4x4Transform3 b) => Mul(a.NonUniformTransform, b);
        public static Obb3T Mul(Obb3T a, Aabb3M b) => Mul(a.NonUniformTransform, b);
        public static Obb3T Mul(Obb3T a, Aabb3C b) => Mul(a.NonUniformTransform, b);
        public static Obb3T Mul(Obb3T a, Aabb3S b) => Mul(a.NonUniformTransform, b);
        public static Obb3M Mul(Obb3T a, Obb3T b) => Mul(a.NonUniformTransform, b);
        public static Obb3M Mul(Obb3T a, Obb3M b) => Mul(a.NonUniformTransform, b);
        public static Obb3M Div(Obb3T a, Translation3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3T a, Rotation3Q b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3T a, Scale1 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3T a, Scale3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3T a, RigidTransform3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3T a, UniformTransform3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3T a, NonUniformTransform3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3T a, Matrix3x3Transform3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3T a, Matrix4x4Transform3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3T a, Aabb3M b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3T a, Aabb3C b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3T a, Aabb3S b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3T a, Obb3T b) => Mul(Inverse(a), b);
        public static Obb3M Div(Obb3T a, Obb3M b) => Mul(Inverse(a), b);

        public static Obb3T Obb3T(NonUniformTransform3 nonUniformTransform) => new Obb3T(nonUniformTransform);
        public static Obb3T Obb3T(float3 translation, quaternion rotation, float3 scale) => new Obb3T(translation, rotation, scale);
    }
}