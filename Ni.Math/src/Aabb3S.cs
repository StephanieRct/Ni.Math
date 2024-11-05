using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    /// <summary>
    /// Represent the sequence of transformations: Translation * NonUniformScale
    /// </summary>
    [Serializable]
    public struct Aabb3S : ITransform3, ITranslation3RW, INonUniformScale3RW,
        IEquatable<Aabb3S>,
        INearEquatable<Aabb3S, float>,
        ITransformable3<Translation3, Aabb3S, Obb3T, Aabb3S, Aabb3S, Aabb3S, Obb3M, Aabb3S, Aabb3S>,
        IToNonUniformTransform3,
        IToMatrix4x4Transform,
        IInvertible<Aabb3S>,
        ITransform<float3>,
        ITransform<Ray3>,
        IMultipliable<Translation3, Aabb3S>,
        IMultipliable<Rotation3Q, Obb3M>,
        IMultipliable<Scale1, Aabb3S>,
        IMultipliable<Scale3, Aabb3S>,
        IMultipliable<RigidTransform3, Obb3M>,
        IMultipliable<UniformTransform3, Obb3M>,
        IMultipliable<NonUniformTransform3, Obb3M>,
        IMultipliable<Matrix3x3Transform3, Obb3M>,
        IMultipliable<Matrix4x4Transform3, Obb3M>,
        IMultipliable<Aabb3M>,
        IMultipliable<Aabb3C>,
        IMultipliable<Aabb3S>,
        IMultipliable<Obb3T, Obb3M>,
        IMultipliable<Obb3M>,
        IDividable<Translation3, Aabb3S>,
        IDividable<Rotation3Q, Obb3M>,
        IDividable<Scale1, Aabb3S>,
        IDividable<Scale3, Aabb3S>,
        IDividable<RigidTransform3, Obb3M>,
        IDividable<UniformTransform3, Obb3M>,
        IDividable<NonUniformTransform3, Obb3M>,
        IDividable<Matrix3x3Transform3, Obb3M>,
        IDividable<Matrix4x4Transform3, Obb3M>,
        IDividable<Aabb3M>,
        IDividable<Aabb3C>,
        IDividable<Aabb3S>,
        IDividable<Obb3T, Obb3M>,
        IDividable<Obb3M>
    {
        public float3 min;
        public float3 size;

        public Aabb3S(float3 min, float3 size)
        {
            this.min = min;
            this.size = size;
        }

        public Aabb3S(Translation3 translation, Scale3 scale)
        {
            min = translation.translation;
            size = scale.scale;
        }

        public static readonly Aabb3S Identity = new Aabb3S(float3.zero, 1);
        public static readonly Aabb3S Origin = new Aabb3S(-0.5f, 1);

        public static explicit operator Aabb3S(Aabb3M o) => new Aabb3S(o.min, o.size);
        public static explicit operator Aabb3M(Aabb3S o) => new Aabb3M(o.min, o.max);
        public static Aabb3S Translating(float3 translation) => new Aabb3S(translation, 1);
        public static Aabb3S Scaling(float scale) => new Aabb3S(0, scale);
        public static Aabb3S Scaling(float3 scale) => new Aabb3S(0, scale);
        public static Aabb3S TS(float3 translation, float scale) => new Aabb3S(translation, scale);
        public static Aabb3S TS(float3 translation, float3 scale) => new Aabb3S(translation, scale);

        public float3 max
        {
            get => min + size;
            set => size = value - min;
        }

        public float3 center 
        {
            get => min + size * 0.5f;
            set => min = value - size * 0.5f;
        }

        public float3 extent 
        {
            get => size * 0.5f;
            set
            {
                min = center - value;
                size = extent * 2;
            }
        }

        public float3 translation3
        {
            get => min;
            set => min = value;
        }

        public float3 scale3
        {
            get => size;
            set => size = value;
        }

        public Translation3 Translation3 { get => new Translation3(translation3); set => translation3 = value.translation; }
        public Scale3 Scale3 { get => new Scale3(scale3); set => scale3 = value.scale; }
        public float3 this[float3 t] => min + t * size;

        public override string ToString() => $"{nameof(Aabb3S)}(Minx:{min.x}, Miny:{min.y}, Minz:{min.z}, Sx:{size.x}, Sy:{size.y}, Sz:{size.z})";

        public bool Equals(Aabb3S other) => NiMath.Equal(this, other);

        public bool NearEquals(Aabb3S other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Translation3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Rotation3Q other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Scale1 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Scale3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(RigidTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(UniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(NonUniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Matrix3x3Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Matrix4x4Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);

        public Aabb3S Inversed => NiMath.Inverse(this);
        public NonUniformTransform3 ToNonUniformTransform3 => new NonUniformTransform3(translation3, quaternion.identity, scale3);
        public Matrix4x4Transform3 ToMatrix4x4Transform => new Matrix4x4Transform3(translation3, float3x3.Scale(scale3));

        public Aabb3S Translated(float3 translation) => NiMath.Translate(translation, this);
        public Obb3T Rotated(quaternion rotation) => NiMath.Rotate(rotation, this);
        public Aabb3S Scaled(float scale) => NiMath.Scale(scale, this);
        public Aabb3S Scaled(float3 scale) => NiMath.Scale(scale, this);

        public Aabb3S Translate(float3 translation) => NiMath.Translate(this, translation);
        public Obb3M Rotate(quaternion rotation) => NiMath.Rotate(this, rotation);
        public Aabb3S Scale(float scale) => NiMath.Scale(this, scale);
        public Aabb3S Scale(float3 scale) => NiMath.Scale(this, scale);

        public Aabb3S Translated(Translation3 translation) => NiMath.Translate(translation, this);
        public Obb3T Rotated(Rotation3Q rotation) => NiMath.Rotate(rotation, this);
        public Aabb3S Scaled(Scale1 scale) => NiMath.Scale(scale, this);
        public Aabb3S Scaled(Scale3 scale) => NiMath.Scale(scale, this);

        public Aabb3S Translate(Translation3 translation) => NiMath.Translate(this, translation);
        public Obb3M Rotate(Rotation3Q rotation) => NiMath.Rotate(this, rotation);
        public Aabb3S Scale(Scale1 scale) => NiMath.Scale(this, scale);
        public Aabb3S Scale(Scale3 scale) => NiMath.Scale(this, scale);

        public float3 Transform(float3 p) => NiMath.Transform(this, p);
        public Ray3 Transform(Ray3 p) => NiMath.Transform(this, p);
        public float3 Untransform(float3 p) => NiMath.Untransform(this, p);
        public Ray3 Untransform(Ray3 p) => NiMath.Untransform(this, p);

        public Aabb3S Mul(Translation3 o) => NiMath.Mul(this, o);
        public Obb3M Mul(Rotation3Q o) => NiMath.Mul(this, o);
        public Aabb3S Mul(Scale1 o) => NiMath.Mul(this, o);
        public Aabb3S Mul(Scale3 o) => NiMath.Mul(this, o);
        public Obb3M Mul(RigidTransform3 o) => NiMath.Mul(this, o);
        public Obb3M Mul(UniformTransform3 o) => NiMath.Mul(this, o);
        public Obb3M Mul(NonUniformTransform3 o) => NiMath.Mul(this, o);
        public Obb3M Mul(Matrix3x3Transform3 o) => NiMath.Mul(this, o);
        public Obb3M Mul(Matrix4x4Transform3 o) => NiMath.Mul(this, o);
        public Aabb3M Mul(Aabb3M o) => NiMath.Mul(this, o);
        public Aabb3C Mul(Aabb3C o) => NiMath.Mul(this, o);
        public Aabb3S Mul(Aabb3S o) => NiMath.Mul(this, o);
        public Obb3M Mul(Obb3T o) => NiMath.Mul(this, o);
        public Obb3M Mul(Obb3M o) => NiMath.Mul(this, o);
        public Aabb3S Div(Translation3 o) => NiMath.Div(this, o);
        public Obb3M Div(Rotation3Q o) => NiMath.Div(this, o);
        public Aabb3S Div(Scale1 o) => NiMath.Div(this, o);
        public Aabb3S Div(Scale3 o) => NiMath.Div(this, o);
        public Obb3M Div(RigidTransform3 o) => NiMath.Div(this, o);
        public Obb3M Div(UniformTransform3 o) => NiMath.Div(this, o);
        public Obb3M Div(NonUniformTransform3 o) => NiMath.Div(this, o);
        public Obb3M Div(Matrix3x3Transform3 o) => NiMath.Div(this, o);
        public Obb3M Div(Matrix4x4Transform3 o) => NiMath.Div(this, o);
        public Aabb3M Div(Aabb3M o) => NiMath.Div(this, o);
        public Aabb3C Div(Aabb3C o) => NiMath.Div(this, o);
        public Aabb3S Div(Aabb3S o) => NiMath.Div(this, o);
        public Obb3M Div(Obb3T o) => NiMath.Div(this, o);
        public Obb3M Div(Obb3M o) => NiMath.Div(this, o);
    }

    public static partial class NiMath
    {
        public static bool Equal(Aabb3S a, Aabb3S b) => math.all(a.min == b.min & a.size == b.size);

        public static bool NearEqual(Aabb3S a, Aabb3S b, float margin) => math.all(math.abs(a.min - b.min) <= margin & math.abs(a.size - b.size) <= margin);
        public static bool NearEqual(Aabb3S a, Translation3 b, float margin) => NearEqual(a.translation3, b.translation, margin) && NearEqual(a.scale3, (float3)1, margin);
        public static bool NearEqual(Aabb3S a, Rotation3Q b, float margin) => NearEqual(a, Mathematics.Aabb3S.Identity, margin) && NearEqual(b.rotation, quaternion.identity, margin);
        public static bool NearEqual(Aabb3S a, Scale1 b, float margin) => NearEqual(a.translation3, float3.zero, margin) && NearEqual(a.scale3, (float3)b.scale, margin);
        public static bool NearEqual(Aabb3S a, Scale3 b, float margin) => NearEqual(a.translation3, float3.zero, margin) && NearEqual(a.scale3, b.scale, margin);
        public static bool NearEqual(Aabb3S a, RigidTransform3 b, float margin) => NearEqual(a.translation3, b.translation, margin) && NearEqual(b.rotation, quaternion.identity, margin) && NearEqual(a.scale3, (float3)1, margin);
        public static bool NearEqual(Aabb3S a, UniformTransform3 b, float margin) => NearEqual(a.translation3, b.translation, margin) && NearEqual(b.rotation, quaternion.identity, margin) && NearEqual(a.scale3, (float3)b.scale, margin);
        public static bool NearEqual(Aabb3S a, NonUniformTransform3 b, float margin) => NearEqual(a.translation3, b.translation, margin) && NearEqual(b.rotation, quaternion.identity, margin) && NearEqual(a.scale3, (float3)b.scale, margin);
        public static bool NearEqual(Aabb3S a, Matrix3x3Transform3 b, float margin) => NearEqual(a.ToMatrix4x4Transform, b, margin);
        public static bool NearEqual(Aabb3S a, Matrix4x4Transform3 b, float margin) => NearEqual(a.ToMatrix4x4Transform, b, margin);

        public static Aabb3S Inverse(Aabb3S a)
        {
            //return new Aabb3S(-a.Min / a.Size, 1 / a.Size);
            var sI = math.rcp(a.size);
            var minI = sI * -a.min;
            return new Aabb3S(minI, sI);
        }

        public static Aabb3S Translate(float3 translation, Aabb3S o) => Mul((Translation3)translation, o);
        public static Obb3T Rotate(quaternion rotation, Aabb3S o) => Mul((Rotation3Q)rotation, o);
        public static Aabb3S Scale(float scale, Aabb3S o) => Mul((Scale1)scale, o);
        public static Aabb3S Scale(float3 scale, Aabb3S o) => Mul((Scale3)scale, o);
        public static Aabb3S Translate(Aabb3S o, float3 translation) => Mul(o, (Translation3)translation);
        public static Obb3M Rotate(Aabb3S o, quaternion rotation) => Mul(o, (Rotation3Q)rotation);
        public static Aabb3S Scale(Aabb3S o, float scale) => Mul(o, (Scale1)scale);
        public static Aabb3S Scale(Aabb3S o, float3 scale) => Mul(o, (Scale3)scale);

        public static Aabb3S Translate(Translation3 translation, Aabb3S o) => Mul((Translation3)translation, o);
        public static Obb3T Rotate(Rotation3Q rotation, Aabb3S o) => Mul((Rotation3Q)rotation, o);
        public static Aabb3S Scale(Scale1 scale, Aabb3S o) => Mul((Scale1)scale, o);
        public static Aabb3S Scale(Scale3 scale, Aabb3S o) => Mul((Scale3)scale, o);
        public static Aabb3S Translate(Aabb3S o, Translation3 translation) => Mul(o, (Translation3)translation);
        public static Obb3M Rotate(Aabb3S o, Rotation3Q rotation) => Mul(o, (Rotation3Q)rotation);
        public static Aabb3S Scale(Aabb3S o, Scale1 scale) => Mul(o, (Scale1)scale);
        public static Aabb3S Scale(Aabb3S o, Scale3 scale) => Mul(o, (Scale3)scale);

        public static float3 Transform(Aabb3S a, float3 p) => a.min + a.size * p;
        public static Ray3 Transform(Aabb3S a, Ray3 b) => Transform(a.Translation3, Transform(a.Scale3, b));
        public static float3 Untransform(Aabb3S a, float3 p) => (p - a.min) * math.rcp(a.size);
        public static Ray3 Untransform(Aabb3S a, Ray3 b) => Transform(Inverse(a), b);

        public static Aabb3S Mul(Aabb3S a, Translation3 b) => new Aabb3S(a.Transform(b.translation), a.size);
        public static Obb3M Mul(Aabb3S a, Rotation3Q b) => new Obb3M(Mul(a.ToMatrix4x4Transform, b));
        public static Aabb3S Mul(Aabb3S a, Scale1 b) => new Aabb3S(a.min, a.size * b.scale);
        public static Aabb3S Mul(Aabb3S a, Scale3 b) => new Aabb3S(a.min, a.size * b.scale);
        public static Obb3M Mul(Aabb3S a, RigidTransform3 b) => new Obb3M(Mul(a.ToMatrix4x4Transform, b));
        public static Obb3M Mul(Aabb3S a, UniformTransform3 b) => new Obb3M(Mul(a.ToMatrix4x4Transform, b));
        public static Obb3M Mul(Aabb3S a, NonUniformTransform3 b) => new Obb3M(Mul(a.ToMatrix4x4Transform, b));
        public static Obb3M Mul(Aabb3S a, Matrix3x3Transform3 b) => new Obb3M(Mul(a.ToMatrix4x4Transform, b));
        public static Obb3M Mul(Aabb3S a, Matrix4x4Transform3 b) => new Obb3M(Mul(a.ToMatrix4x4Transform, b));
        public static Aabb3M Mul(Aabb3S a, Aabb3M b) => Mul(a.Translation3, Mul(a.Scale3, b));
        public static Aabb3C Mul(Aabb3S a, Aabb3C b) => Mul(a.Translation3, Mul(a.Scale3, b));
        public static Aabb3S Mul(Aabb3S a, Aabb3S b) => Mul(a.Translation3, Mul(a.Scale3, b));
        public static Obb3M Mul(Aabb3S a, Obb3T b) => Mul(a.Translation3, Mul(a.Scale3, b));
        public static Obb3M Mul(Aabb3S a, Obb3M b) => Mul(a.Translation3, Mul(a.Scale3, b));
        public static Aabb3S Div(Aabb3S a, Translation3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Aabb3S a, Rotation3Q b) => Mul(Inverse(a), b);
        public static Aabb3S Div(Aabb3S a, Scale1 b) => Mul(Inverse(a), b);
        public static Aabb3S Div(Aabb3S a, Scale3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Aabb3S a, RigidTransform3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Aabb3S a, UniformTransform3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Aabb3S a, NonUniformTransform3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Aabb3S a, Matrix3x3Transform3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Aabb3S a, Matrix4x4Transform3 b) => Mul(Inverse(a), b);
        public static Aabb3M Div(Aabb3S a, Aabb3M b) => Mul(Inverse(a), b);
        public static Aabb3C Div(Aabb3S a, Aabb3C b) => Mul(Inverse(a), b);
        public static Aabb3S Div(Aabb3S a, Aabb3S b) => Mul(Inverse(a), b);
        public static Obb3M Div(Aabb3S a, Obb3T b) => Mul(Inverse(a), b);
        public static Obb3M Div(Aabb3S a, Obb3M b) => Mul(Inverse(a), b);

        //public static Aabb3S Mul(TranslationTransform3 a, Aabb3S b) => (Aabb3S)new Aabb3S(a.Transform(b.translation3), b.size);
        //public static Obb3T Mul(RotationQTransform3 a, Aabb3S b) => new Obb3T(new NonUniformTransform3(Rotate(a, b.translation3), a, b.scale3));
        //public static Aabb3S Mul(ScaleUniformTransform3 a, Aabb3S b) => new Aabb3S(a.scale * b.min, a.scale * b.size);
        //public static Aabb3S Mul(ScaleNonUniformTransform3 a, Aabb3S b) => new Aabb3S(a.scale * b.min, a.scale * b.size);
        //public static Obb3T Mul(RigidTransform3 a, Aabb3S b) => new Obb3T(new NonUniformTransform3(a.Transform(b.translation3), a.rotation, b.scale3));
        //public static Obb3T Mul(UniformTransform3 a, Aabb3S b) => new Obb3T(new NonUniformTransform3(a.Transform(b.translation3), a.rotation, b.scale3));
        //public static Obb3T Mul(NonUniformTransform3 a, Aabb3S b) => new Obb3T(new NonUniformTransform3(a.Transform(b.translation3), a.rotation, a.scale * b.scale3));
        //public static Obb3M Mul(Matrix3x3Transform3 a, Aabb3S b) => new Obb3M(Mul(a, b.ToMatrix4x4Transform));
        //public static Obb3M Mul(Matrix4x4Transform3 a, Aabb3S b) => new Obb3M(Mul(a, b.ToMatrix4x4Transform));

        //public static Aabb3S Div(TranslationTransform3 a, Aabb3S b) => Mul(Inverse(a), b);
        //public static Obb3T Div(RotationQTransform3 a, Aabb3S b) => Mul(Inverse(a), b);
        //public static Aabb3S Div(ScaleUniformTransform3 a, Aabb3S b) => Mul(Inverse(a), b);
        //public static Aabb3S Div(ScaleNonUniformTransform3 a, Aabb3S b) => Mul(Inverse(a), b);
        //public static Obb3T Div(RigidTransform3 a, Aabb3S b) => Mul(Inverse(a), b);
        //public static Obb3T Div(UniformTransform3 a, Aabb3S b) => Mul(Inverse(a), b);
        //public static Obb3M Div(NonUniformTransform3 a, Aabb3S b) => Mul(Inverse(a), b);
        //public static Obb3M Div(Matrix3x3Transform3 a, Aabb3S b) => Mul(Inverse(a), b);
        //public static Obb3M Div(Matrix4x4Transform3 a, Aabb3S b) => Mul(Inverse(a), b);

        public static Aabb3S Aabb3S(float3 min, float3 size) => new Aabb3S(min, size);
    }
}