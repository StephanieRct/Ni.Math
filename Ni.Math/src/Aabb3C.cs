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
    public struct Aabb3C : ITranslation3RW, IScale3RW,
        ITransform3<Aabb3C>,
        //IShearableTransformable3<Aabb3C, Obb3M>,
        IBox3<Aabb3C>,
        ITransformable3<Translation3, Aabb3C, Obb3T, Aabb3C, Aabb3C, Aabb3C, Obb3M, Aabb3C, Aabb3C>,
        IToNonUniformTransform3,
        IInvertible<Aabb3C>,
        IMultipliable<Translation3, Aabb3C>,
        IMultipliable<Rotation3Q, Obb3M>,
        IMultipliable<Scale1, Aabb3C>,
        IMultipliable<Scale3, Aabb3C>,
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
        IDividable<Translation3, Aabb3C>,
        IDividable<Rotation3Q, Obb3M>,
        IDividable<Scale1, Aabb3C>,
        IDividable<Scale3, Aabb3C>,
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
        public float3 center;
        public float3 extent;

        public Aabb3C(float3 center, float3 extent)
        {
            this.center = center;
            this.extent = extent;
        }

        public Aabb3C(Translation3 translation, Scale3 scale)
        {
            extent = scale.scale * .5f;
            center = translation.translation + extent;
        }
        public Aabb3C(LineSegment3 o)
        {
            var min = math.min(o.a, o.b);
            extent = (math.max(o.a, o.b) - min) * 0.5f;
            center = min + extent;
        }


        public Aabb3C(UnityBounds o)
        {
            extent = o.size * 0.5f;
            center = o.center;
        }

        public Aabb3C(UnityBoxCollider o)
        {
            extent = o.size * 0.5f;
            center = o.center;
        }

        public static readonly Aabb3C Identity = new Aabb3C(0.5f, 0.5f);
        public static readonly Aabb3C Origin = new Aabb3C(float3.zero, 0.5f);
        public static implicit operator Aabb3C(UnityBounds o) => new Aabb3C(o.center, o.extents);
        public static explicit operator Aabb3C(UnityBoxCollider o) => new Aabb3C(o.center, o.size * 0.5f);
        public static explicit operator Aabb3C(Aabb3M o) => new Aabb3C(o.center, o.extent);
        public static explicit operator Aabb3M(Aabb3C o) => new Aabb3M(o.min, o.max);
        public static explicit operator Aabb3C(Aabb3S o) => new Aabb3C(o.center, o.extent);
        public static explicit operator Aabb3S(Aabb3C o) => new Aabb3S(o.min, o.size);
        public static Aabb3C Translating(float3 translation) => new Aabb3C(translation, 1);
        public static Aabb3C Scaling(float scale) => new Aabb3C(0, scale);
        public static Aabb3C Scaling(float3 scale) => new Aabb3C(0, scale);
        public static Aabb3C TS(float3 translation, float scale) => new Aabb3C(translation + scale * 0.5f, scale * 0.5f);
        public static Aabb3C TS(float3 translation, float3 scale) => new Aabb3C(translation + scale * 0.5f, scale * 0.5f);

        public float3 min
        {
            get => center - extent;
            set => center = value + extent;
        } 

        public float3 max
        {
            get => center + extent;
            set => center = value - extent;
        }
    
        public float3 size
        {
            get => extent * 2;
            set
            {
                var min = this.min;
                extent = size * 0.5f;
                center = min + extent;
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
            set
            {
                var min = this.min;
                extent = value * 0.5f;
                center = min + extent;
            }
        }

        public Translation3 Translation3 { get => new Translation3(translation3); set => translation3 = value.translation; }
        public Scale3 Scale3 { get => new Scale3(scale3); set => scale3 = value.scale; }
        public float3 this[float3 t] => min + t * size;

        public override string ToString() => $"{nameof(Aabb3C)}(Cx:{center.x}, Cy:{center.y}, Cz:{center.z}, Ex:{extent.x}, Ey:{extent.y}, Ez:{extent.z})";

        public bool Equals(Aabb3C other) => NiMath.Equal(this, other);

        public bool NearEquals(Aabb3C other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Translation3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Rotation3Q other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Scale1 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Scale3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(RigidTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(UniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(NonUniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Matrix3x3Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Matrix4x4Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);

        public Aabb3C Inversed => NiMath.Inverse(this);
        public NonUniformTransform3 ToNonUniformTransform3 => new NonUniformTransform3(translation3, quaternion.identity, scale3);
        public Matrix4x4Transform3 ToMatrix4x4Transform3 => new Matrix4x4Transform3(translation3, float3x3.Scale(scale3));

        public Aabb3C Translated(float3 translation) => NiMath.Translate(translation, this);
        public Obb3T Rotated(quaternion rotation) => NiMath.Rotate(rotation, this);
        public Aabb3C Scaled(float scale) => NiMath.Scale(scale, this);
        public Aabb3C Scaled(float3 scale) => NiMath.Scale(scale, this);

        public Aabb3C Translate(float3 translation) => NiMath.Translate(this, translation);
        public Obb3M Rotate(quaternion rotation) => NiMath.Rotate(this, rotation);
        public Aabb3C Scale(float scale) => NiMath.Scale(this, scale);
        public Aabb3C Scale(float3 scale) => NiMath.Scale(this, scale);

        public Aabb3C Translated(Translation3 translation) => NiMath.Translate(translation, this);
        public Obb3T Rotated(Rotation3Q rotation) => NiMath.Rotate(rotation, this);
        public Aabb3C Scaled(Scale1 scale) => NiMath.Scale(scale, this);
        public Aabb3C Scaled(Scale3 scale) => NiMath.Scale(scale, this);

        public Aabb3C Translate(Translation3 translation) => NiMath.Translate(this, translation);
        public Obb3M Rotate(Rotation3Q rotation) => NiMath.Rotate(this, rotation);
        public Aabb3C Scale(Scale1 scale) => NiMath.Scale(this, scale);
        public Aabb3C Scale(Scale3 scale) => NiMath.Scale(this, scale);

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

        public Aabb3C Mul(Translation3 o) => NiMath.Mul(this, o);
        public Obb3M Mul(Rotation3Q o) => NiMath.Mul(this, o);
        public Aabb3C Mul(Scale1 o) => NiMath.Mul(this, o);
        public Aabb3C Mul(Scale3 o) => NiMath.Mul(this, o);
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
        public Aabb3C Div(Translation3 o) => NiMath.Div(this, o);
        public Obb3M Div(Rotation3Q o) => NiMath.Div(this, o);
        public Aabb3C Div(Scale1 o) => NiMath.Div(this, o);
        public Aabb3C Div(Scale3 o) => NiMath.Div(this, o);
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
        public static bool Equal(Aabb3C a, Aabb3C b) => math.all(a.center == b.center & a.extent == b.extent);

        public static bool NearEqual(Aabb3C a, Aabb3C b, float margin) => math.all(math.abs(a.center - b.center) <= margin & math.abs(a.extent - b.extent) <= margin);
        public static bool NearEqual(Aabb3C a, Translation3 b, float margin) => NearEqual(a.translation3, b.translation, margin) && NearEqual(a.scale3, (float3)1, margin);
        public static bool NearEqual(Aabb3C a, Rotation3Q b, float margin) => NearEqual(a, Mathematics.Aabb3C.Identity, margin) && NearEqual(b.rotation, quaternion.identity, margin);
        public static bool NearEqual(Aabb3C a, Scale1 b, float margin) => NearEqual(a.translation3, float3.zero, margin) && NearEqual(a.scale3, (float3)b.scale, margin);
        public static bool NearEqual(Aabb3C a, Scale3 b, float margin) => NearEqual(a.translation3, float3.zero, margin) && NearEqual(a.scale3, b.scale, margin);
        public static bool NearEqual(Aabb3C a, RigidTransform3 b, float margin) => NearEqual(a.translation3, b.translation, margin) && NearEqual(b.rotation, quaternion.identity, margin) && NearEqual(a.scale3, (float3)1, margin);
        public static bool NearEqual(Aabb3C a, UniformTransform3 b, float margin) => NearEqual(a.translation3, b.translation, margin) && NearEqual(b.rotation, quaternion.identity, margin) && NearEqual(a.scale3, (float3)b.scale, margin);
        public static bool NearEqual(Aabb3C a, NonUniformTransform3 b, float margin) => NearEqual(a.translation3, b.translation, margin) && NearEqual(b.rotation, quaternion.identity, margin) && NearEqual(a.scale3, (float3)b.scale, margin);
        public static bool NearEqual(Aabb3C a, Matrix3x3Transform3 b, float margin) => NearEqual(a.ToMatrix4x4Transform3, b, margin);
        public static bool NearEqual(Aabb3C a, Matrix4x4Transform3 b, float margin) => NearEqual(a.ToMatrix4x4Transform3, b, margin);

        public static Aabb3C Inverse(Aabb3C a)
        {
            var eI = math.rcp(a.extent);
            var extentI = 0.25f * eI;
            return new Aabb3C((1 - 2 * a.center) * extentI + 0.5f, extentI);
        }

        public static Aabb3C Translate(float3 translation, Aabb3C o) => Mul((Translation3)translation, o);
        public static Obb3T Rotate(quaternion rotation, Aabb3C o) => Mul((Rotation3Q)rotation, o);
        public static Aabb3C Scale(float scale, Aabb3C o) => Mul((Scale1)scale, o);
        public static Aabb3C Scale(float3 scale, Aabb3C o) => Mul((Scale3)scale, o);
        public static Aabb3C Translate(Aabb3C o, float3 translation) => Mul(o, (Translation3)translation);
        public static Obb3M Rotate(Aabb3C o, quaternion rotation) => Mul(o, (Rotation3Q)rotation);
        public static Aabb3C Scale(Aabb3C o, float scale) => Mul(o, (Scale1)scale);
        public static Aabb3C Scale(Aabb3C o, float3 scale) => Mul(o, (Scale3)scale);

        public static Aabb3C Translate(Translation3 translation, Aabb3C o) => Mul((Translation3)translation, o);
        public static Obb3T Rotate(Rotation3Q rotation, Aabb3C o) => Mul((Rotation3Q)rotation, o);
        public static Aabb3C Scale(Scale1 scale, Aabb3C o) => Mul((Scale1)scale, o);
        public static Aabb3C Scale(Scale3 scale, Aabb3C o) => Mul((Scale3)scale, o);
        public static Aabb3C Translate(Aabb3C o, Translation3 translation) => Mul(o, (Translation3)translation);
        public static Obb3M Rotate(Aabb3C o, Rotation3Q rotation) => Mul(o, (Rotation3Q)rotation);
        public static Aabb3C Scale(Aabb3C o, Scale1 scale) => Mul(o, (Scale1)scale);
        public static Aabb3C Scale(Aabb3C o, Scale3 scale) => Mul(o, (Scale3)scale);

        public static float3 Transform(Aabb3C a, float3 b) => a.min + a.size * b;
        public static Direction3 Transform(Aabb3C a, Direction3 b) => Direction3.Direction(Scale(a.scale3, b.vector));
        public static ProjectionAxis3x1 Transform(Aabb3C a, ProjectionAxis3x1 b) => new ProjectionAxis3x1(Scale(a.scale3, b.axis));
        public static ProjectionAxis1x3 Transform(Aabb3C a, ProjectionAxis1x3 b) => new ProjectionAxis1x3(Scale(a.scale3, b.axis));
        public static Ray3 Transform(Aabb3C a, Ray3 b) => Transform(a.Translation3, Transform(a.Scale3, b));
        public static float3 Untransform(Aabb3C a, float3 b) => (b - a.min) * math.rcp(a.size);
        public static Direction3 Untransform(Aabb3C a, Direction3 b) => Transform(Inverse(a), b);
        public static ProjectionAxis3x1 Untransform(Aabb3C a, ProjectionAxis3x1 b) => Transform(Inverse(a), b);
        public static ProjectionAxis1x3 Untransform(Aabb3C a, ProjectionAxis1x3 b) => Transform(Inverse(a), b);
        public static Ray3 Untransform(Aabb3C a, Ray3 b) => Transform(Inverse(a), b);

        public static Aabb3C Mul(Aabb3C a, Translation3 b) => new Aabb3C(a.Transform(b.translation) + a.extent, a.extent);
        public static Obb3M Mul(Aabb3C a, Rotation3Q b) => new Obb3M(Mul(a.ToMatrix4x4Transform3, b));
        public static Aabb3C Mul(Aabb3C a, Scale1 b) => Mathematics.Aabb3C.TS(a.translation3, a.scale3 * b.scale);
        public static Aabb3C Mul(Aabb3C a, Scale3 b) => Mathematics.Aabb3C.TS(a.translation3, a.scale3 * b.scale);
        public static Obb3M Mul(Aabb3C a, RigidTransform3 b) => new Obb3M(Mul(a.ToMatrix4x4Transform3, b));
        public static Obb3M Mul(Aabb3C a, UniformTransform3 b) => new Obb3M(Mul(a.ToMatrix4x4Transform3, b));
        public static Obb3M Mul(Aabb3C a, NonUniformTransform3 b) => new Obb3M(Mul(a.ToMatrix4x4Transform3, b));
        public static Obb3M Mul(Aabb3C a, Matrix3x3Transform3 b) => new Obb3M(Mul(a.ToMatrix4x4Transform3, b));
        public static Obb3M Mul(Aabb3C a, Matrix4x4Transform3 b) => new Obb3M(Mul(a.ToMatrix4x4Transform3, b));
        public static Aabb3M Mul(Aabb3C a, Aabb3M b) => Mul(a.Translation3, Mul(a.Scale3, b));
        public static Aabb3C Mul(Aabb3C a, Aabb3C b) => Mul(a.Translation3, Mul(a.Scale3, b));
        public static Aabb3S Mul(Aabb3C a, Aabb3S b) => Mul(a.Translation3, Mul(a.Scale3, b));
        public static Obb3M Mul(Aabb3C a, Obb3T b) => Mul(a.Translation3, Mul(a.Scale3, b));
        public static Obb3M Mul(Aabb3C a, Obb3M b) => Mul(a.Translation3, Mul(a.Scale3, b));
        public static Aabb3C Div(Aabb3C a, Translation3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Aabb3C a, Rotation3Q b) => Mul(Inverse(a), b);
        public static Aabb3C Div(Aabb3C a, Scale1 b) => Mul(Inverse(a), b);
        public static Aabb3C Div(Aabb3C a, Scale3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Aabb3C a, RigidTransform3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Aabb3C a, UniformTransform3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Aabb3C a, NonUniformTransform3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Aabb3C a, Matrix3x3Transform3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Aabb3C a, Matrix4x4Transform3 b) => Mul(Inverse(a), b);
        public static Aabb3M Div(Aabb3C a, Aabb3M b) => Mul(Inverse(a), b);
        public static Aabb3C Div(Aabb3C a, Aabb3C b) => Mul(Inverse(a), b);
        public static Aabb3S Div(Aabb3C a, Aabb3S b) => Mul(Inverse(a), b);
        public static Obb3M Div(Aabb3C a, Obb3T b) => Mul(Inverse(a), b);
        public static Obb3M Div(Aabb3C a, Obb3M b) => Mul(Inverse(a), b);

        public static Aabb3C Aabb3C(float3 center, float3 extent) => new Aabb3C(center, extent);
    }
}