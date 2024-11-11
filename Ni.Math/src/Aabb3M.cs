using System;
using Unity.Mathematics;
using UnityBounds = UnityEngine.Bounds;
using UnityBoxCollider = UnityEngine.BoxCollider;

namespace Ni.Mathematics
{
    /// <summary>
    /// Represent the sequence of transformations: Translation * NonUniformScale
    /// </summary>
    [Serializable]
    public struct Aabb3M : ITranslation3RW, IScale3RW,
        ITransform3<Aabb3M>,
        //IShearableTransformable3<Aabb3M, Obb3M>,
        IBox3<Aabb3M>,
        ITransformable3<Translation3, Aabb3M, Obb3T, Aabb3M, Aabb3M, Aabb3M, Obb3M, Aabb3M, Aabb3M>,
        IToNonUniformTransform3,
        IInvertible<Aabb3M>,
        IMultipliable<Translation3, Aabb3M>,
        IMultipliable<Rotation3Q, Obb3M>,
        IMultipliable<Scale1, Aabb3M>,
        IMultipliable<Scale3, Aabb3M>,
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
        IDividable<Translation3, Aabb3M>,
        IDividable<Rotation3Q, Obb3M>,
        IDividable<Scale1, Aabb3M>,
        IDividable<Scale3, Aabb3M>,
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
        public float3 max;

        public Aabb3M(float3 min, float3 max)
        {
            this.min = min;
            this.max = max;
        }

        public Aabb3M(Translation3 translation, Scale3 scale)
        {
            min = translation.translation;
            max = min + scale.scale;
        }

        public Aabb3M(UnityBounds o)
        {
            min = o.min;
            max = o.max;
        }

        public Aabb3M(UnityBoxCollider o)
        {
            var extent = o.size * 0.5f;
            min = o.center - extent;
            max = o.center + extent;
        }

        public static readonly Aabb3M Identity = new Aabb3M(float3.zero, 1);
        public static readonly Aabb3M Origin = new Aabb3M(-0.5f, 0.5f);
        public static Aabb3M Translating(float3 translation) => new Aabb3M(translation, translation + 1);
        public static Aabb3M Scaling(float scale) => new Aabb3M(0, scale);
        public static Aabb3M Scaling(float3 scale) => new Aabb3M(0, scale);
        public static Aabb3M TS(float3 translation, float scale) => new Aabb3M(translation, translation + scale);
        public static Aabb3M TS(float3 translation, float3 scale) => new Aabb3M(translation, translation + scale);

        public float3 size
        {
            get => max - min;
            set => max = min + size;
        }

        public float3 center
        {
            get => (min + max) * 0.5f;
            set
            {
                var extent = this.extent;
                min = value - extent;
                max = value + extent;
            }
        } 

        public float3 extent
        {
            get => (max - min) * 0.5f;
            set
            {
                var center = this.center;
                min = center - extent;
                max = center + extent;
            }
        }

        public float3 translation3
        {
            get => min;
            set
            {
                max = value + size;
                min = value;
            }
        }

        public float3 scale3 
        { 
            get => size;
            set => max = min + value;
        }

        public Translation3 Translation3 { get => new Translation3(translation3); set => translation3 = value.translation; }
        public Scale3 Scale3 { get => new Scale3(scale3); set => scale3 = value.scale; }

        public float3 this[float3 t] => min + t * size;

        public override string ToString() => $"{nameof(Aabb3M)}(Minx:{min.x}, Miny:{min.y}, Minz:{min.z}, Maxx:{max.x}, Maxy:{max.y}, Maxz:{max.z})";

        public bool Equals(Aabb3M other) => NiMath.Equal(this, other);

        public bool NearEquals(Aabb3M other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Translation3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Rotation3Q other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Scale1 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Scale3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(RigidTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(UniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(NonUniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Matrix3x3Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Matrix4x4Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);

        public Aabb3M Inversed => NiMath.Inverse(this);
        public NonUniformTransform3 ToNonUniformTransform3 => new NonUniformTransform3(translation3, quaternion.identity, scale3);
        public Matrix4x4Transform3 ToMatrix4x4Transform3 => new Matrix4x4Transform3(translation3, float3x3.Scale(scale3));

        public Aabb3M Translated(float3 translation) => NiMath.Translate(translation, this);
        public Obb3T Rotated(quaternion rotation) => NiMath.Rotate(rotation, this);
        public Aabb3M Scaled(float scale) => NiMath.Scale(scale, this);
        public Aabb3M Scaled(float3 scale) => NiMath.Scale(scale, this);

        public Aabb3M Translate(float3 translation) => NiMath.Translate(this, translation);
        public Obb3M Rotate(quaternion rotation) => NiMath.Rotate(this, rotation);
        public Aabb3M Scale(float scale) => NiMath.Scale(this, scale);
        public Aabb3M Scale(float3 scale) => NiMath.Scale(this, scale);

        public Aabb3M Translated(Translation3 translation) => NiMath.Translate(translation, this);
        public Obb3T Rotated(Rotation3Q rotation) => NiMath.Rotate(rotation, this);
        public Aabb3M Scaled(Scale1 scale) => NiMath.Scale(scale, this);
        public Aabb3M Scaled(Scale3 scale) => NiMath.Scale(scale, this);

        public Aabb3M Translate(Translation3 translation) => NiMath.Translate(this, translation);
        public Obb3M Rotate(Rotation3Q rotation) => NiMath.Rotate(this, rotation);
        public Aabb3M Scale(Scale1 scale) => NiMath.Scale(this, scale);
        public Aabb3M Scale(Scale3 scale) => NiMath.Scale(this, scale);

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

        public Aabb3M Mul(Translation3 o) => NiMath.Mul(this, o);
        public Obb3M Mul(Rotation3Q o) => NiMath.Mul(this, o);
        public Aabb3M Mul(Scale1 o) => NiMath.Mul(this, o);
        public Aabb3M Mul(Scale3 o) => NiMath.Mul(this, o);
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
        public Aabb3M Div(Translation3 o) => NiMath.Div(this, o);
        public Obb3M Div(Rotation3Q o) => NiMath.Div(this, o);
        public Aabb3M Div(Scale1 o) => NiMath.Div(this, o);
        public Aabb3M Div(Scale3 o) => NiMath.Div(this, o);
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
        public static bool Equal(Aabb3M a, Aabb3M b) => math.all(a.min == b.min & a.max == b.max);
        public static bool NearEqual(Aabb3M a, Aabb3M b, float margin) => math.all(math.abs(a.min - b.min) <= margin & math.abs(a.max - b.max) <= margin);
        public static bool NearEqual(Aabb3M a, Translation3 b, float margin) => NearEqual(a.translation3, b.translation, margin) && NearEqual(a.scale3, (float3)1, margin);
        public static bool NearEqual(Aabb3M a, Rotation3Q b, float margin) => NearEqual(a, Mathematics.Aabb3M.Identity, margin) && NearEqual(b.rotation, quaternion.identity, margin);
        public static bool NearEqual(Aabb3M a, Scale1 b, float margin) => NearEqual(a.translation3, float3.zero, margin) && NearEqual(a.scale3, (float3)b.scale, margin);
        public static bool NearEqual(Aabb3M a, Scale3 b, float margin) => NearEqual(a.translation3, float3.zero, margin) && NearEqual(a.scale3, b.scale, margin);
        public static bool NearEqual(Aabb3M a, RigidTransform3 b, float margin) => NearEqual(a.translation3, b.translation, margin) && NearEqual(b.rotation, quaternion.identity, margin) && NearEqual(a.scale3, (float3)1, margin);
        public static bool NearEqual(Aabb3M a, UniformTransform3 b, float margin) => NearEqual(a.translation3, b.translation, margin) && NearEqual(b.rotation, quaternion.identity, margin) && NearEqual(a.scale3, (float3)b.scale, margin);
        public static bool NearEqual(Aabb3M a, NonUniformTransform3 b, float margin) => NearEqual(a.translation3, b.translation, margin) && NearEqual(b.rotation, quaternion.identity, margin) && NearEqual(a.scale3, (float3)b.scale, margin);
        public static bool NearEqual(Aabb3M a, Matrix3x3Transform3 b, float margin) => NearEqual(a.ToMatrix4x4Transform3, b, margin);
        public static bool NearEqual(Aabb3M a, Matrix4x4Transform3 b, float margin) => NearEqual(a.ToMatrix4x4Transform3, b, margin);

        public static Aabb3M Inverse(Aabb3M a)
        {
            //return new Aabb3M(-a.Min / a.Size, (1 - a.Min) / a.Size);
            var sI = math.rcp(a.size);
            var minI = sI * -a.min;
            return new Aabb3M(minI, sI + minI);
        }

        public static Aabb3M Translate(float3 translation, Aabb3M o) => Mul((Translation3)translation, o);
        public static Obb3T Rotate(quaternion rotation, Aabb3M o) => Mul((Rotation3Q)rotation, o);
        public static Aabb3M Scale(float scale, Aabb3M o) => Mul((Scale1)scale, o);
        public static Aabb3M Scale(float3 scale, Aabb3M o) => Mul((Scale3)scale, o);
        public static Aabb3M Translate(Aabb3M o, float3 translation) => Mul(o, (Translation3)translation);
        public static Obb3M Rotate(Aabb3M o, quaternion rotation) => Mul(o, (Rotation3Q)rotation);
        public static Aabb3M Scale(Aabb3M o, float scale) => Mul(o, (Scale1)scale);
        public static Aabb3M Scale(Aabb3M o, float3 scale) => Mul(o, (Scale3)scale);

        public static Aabb3M Translate(Translation3 translation, Aabb3M o) => Mul((Translation3)translation, o);
        public static Obb3T Rotate(Rotation3Q rotation, Aabb3M o) => Mul((Rotation3Q)rotation, o);
        public static Aabb3M Scale(Scale1 scale, Aabb3M o) => Mul((Scale1)scale, o);
        public static Aabb3M Scale(Scale3 scale, Aabb3M o) => Mul((Scale3)scale, o);
        public static Aabb3M Translate(Aabb3M o, Translation3 translation) => Mul(o, (Translation3)translation);
        public static Obb3M Rotate(Aabb3M o, Rotation3Q rotation) => Mul(o, (Rotation3Q)rotation);
        public static Aabb3M Scale(Aabb3M o, Scale1 scale) => Mul(o, (Scale1)scale);
        public static Aabb3M Scale(Aabb3M o, Scale3 scale) => Mul(o, (Scale3)scale);

        public static float3 Transform(Aabb3M a, float3 p) => a.min + a.size * p;
        public static Direction3 Transform(Aabb3M a, Direction3 b) => Direction3.Direction(Scale(a.scale3, b.vector));
        public static ProjectionAxis3x1 Transform(Aabb3M a, ProjectionAxis3x1 b) => new ProjectionAxis3x1(Scale(a.scale3, b.axis));
        public static ProjectionAxis1x3 Transform(Aabb3M a, ProjectionAxis1x3 b) => new ProjectionAxis1x3(Scale(a.scale3, b.axis));
        public static Ray3 Transform(Aabb3M a, Ray3 b) => Transform(a.Translation3, Transform(a.Scale3, b));
        public static float3 Untransform(Aabb3M a, float3 p) => (p - a.min) * math.rcp(a.size);
        public static Direction3 Untransform(Aabb3M a, Direction3 b) => Transform(Inverse(a), b);
        public static ProjectionAxis3x1 Untransform(Aabb3M a, ProjectionAxis3x1 b) => Transform(Inverse(a), b);
        public static ProjectionAxis1x3 Untransform(Aabb3M a, ProjectionAxis1x3 b) => Transform(Inverse(a), b);
        public static Ray3 Untransform(Aabb3M a, Ray3 b) => Transform(Inverse(a), b);

        public static Aabb3M Mul(Aabb3M a, Translation3 b) => (Aabb3M)new Aabb3S(a.Transform(b.translation), a.size);
        public static Obb3M Mul(Aabb3M a, Rotation3Q b) => new Obb3M(Mul(a.ToMatrix4x4Transform3, b));
        public static Aabb3M Mul(Aabb3M a, Scale1 b) => new Aabb3M(a.min, a.min + a.size * b.scale);
        public static Aabb3M Mul(Aabb3M a, Scale3 b) => new Aabb3M(a.min, a.min + a.size * b.scale);
        public static Obb3M Mul(Aabb3M a, RigidTransform3 b) => new Obb3M(Mul(a.ToMatrix4x4Transform3, b));
        public static Obb3M Mul(Aabb3M a, UniformTransform3 b) => new Obb3M(Mul(a.ToMatrix4x4Transform3, b));
        public static Obb3M Mul(Aabb3M a, NonUniformTransform3 b) => new Obb3M(Mul(a.ToMatrix4x4Transform3, b));
        public static Obb3M Mul(Aabb3M a, Matrix3x3Transform3 b) => new Obb3M(Mul(a.ToMatrix4x4Transform3, b));
        public static Obb3M Mul(Aabb3M a, Matrix4x4Transform3 b) => new Obb3M(Mul(a.ToMatrix4x4Transform3, b));
        public static Aabb3M Mul(Aabb3M a, Aabb3M b) => Mul(a.Translation3, Mul(a.Scale3, b));
        public static Aabb3C Mul(Aabb3M a, Aabb3C b) => Mul(a.Translation3, Mul(a.Scale3, b));
        public static Aabb3S Mul(Aabb3M a, Aabb3S b) => Mul(a.Translation3, Mul(a.Scale3, b));
        public static Obb3M Mul(Aabb3M a, Obb3T b) => Mul(a.Translation3, Mul(a.Scale3, b));
        public static Obb3M Mul(Aabb3M a, Obb3M b) => Mul(a.Translation3, Mul(a.Scale3, b));
        public static Aabb3M Div(Aabb3M a, Translation3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Aabb3M a, Rotation3Q b) => Mul(Inverse(a), b);
        public static Aabb3M Div(Aabb3M a, Scale1 b) => Mul(Inverse(a), b);
        public static Aabb3M Div(Aabb3M a, Scale3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Aabb3M a, RigidTransform3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Aabb3M a, UniformTransform3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Aabb3M a, NonUniformTransform3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Aabb3M a, Matrix3x3Transform3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Aabb3M a, Matrix4x4Transform3 b) => Mul(Inverse(a), b);
        public static Aabb3M Div(Aabb3M a, Aabb3M b) => Mul(Inverse(a), b);
        public static Aabb3C Div(Aabb3M a, Aabb3C b) => Mul(Inverse(a), b);
        public static Aabb3S Div(Aabb3M a, Aabb3S b) => Mul(Inverse(a), b);
        public static Obb3M Div(Aabb3M a, Obb3T b) => Mul(Inverse(a), b);
        public static Obb3M Div(Aabb3M a, Obb3M b) => Mul(Inverse(a), b);

        public static Aabb3M Aabb3M(float3 min, float3 max) => new Aabb3M(min, max);
    }
}