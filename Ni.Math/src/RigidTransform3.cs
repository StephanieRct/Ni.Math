using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    /// <summary>
    /// Represent the sequence of transformations: Translation * Rotation
    /// </summary>
    [Serializable]
    public struct RigidTransform3 : ITransform3<RigidTransform3>, IRotation3QRW, ITranslation3RW,
        ITransformable3<RigidTransform3, RigidTransform3, RigidTransform3, UniformTransform3, Matrix4x4Transform3, RigidTransform3, RigidTransform3, UniformTransform3, NonUniformTransform3>,
        //IShearableTransformable3<RigidTransform3, Matrix4x4Transform3>,
        IInvertible<RigidTransform3>,
        IMultipliable<Translation3, RigidTransform3>,
        IMultipliable<Rotation3Q, RigidTransform3>,
        IMultipliable<Scale1, UniformTransform3>,
        IMultipliable<Scale3, NonUniformTransform3>,
        IMultipliable<RigidTransform3>,
        IMultipliable<UniformTransform3>,
        IMultipliable<NonUniformTransform3>,
        IMultipliable<Matrix3x3Transform3, Matrix4x4Transform3>,
        IMultipliable<Matrix4x4Transform3>,
        IMultipliable<Aabb3M, Obb3T>,
        IMultipliable<Aabb3C, Obb3T>,
        IMultipliable<Aabb3S, Obb3T>,
        IMultipliable<Obb3T>,
        IMultipliable<Obb3M, Obb3M>,
        IDividable<Translation3, RigidTransform3>,
        IDividable<Rotation3Q, RigidTransform3>,
        IDividable<Scale1, UniformTransform3>,
        IDividable<Scale3, NonUniformTransform3>,
        IDividable<RigidTransform3>,
        IDividable<UniformTransform3>,
        IDividable<NonUniformTransform3>,
        IDividable<Matrix3x3Transform3, Matrix4x4Transform3>,
        IDividable<Matrix4x4Transform3>,
        IDividable<Aabb3M, Obb3T>,
        IDividable<Aabb3C, Obb3T>,
        IDividable<Aabb3S, Obb3T>,
        IDividable<Obb3T>,
        IDividable<Obb3M, Obb3M>
    {
        public quaternion rotation;
        public float3 translation;

        public RigidTransform3(float3 translation, quaternion rotation)
        {
            this.rotation = rotation;
            this.translation = translation;
        }

        public RigidTransform3(float3 translation)
        {
            rotation = quaternion.identity;
            this.translation = translation;
        }

        public RigidTransform3(quaternion rotation)
        {
            this.rotation = rotation;
            translation = float3.zero;
        }

        public RigidTransform3(Translation3 translation, Rotation3Q rotation)
        {
            this.rotation = rotation;
            this.translation = translation.translation;
        }

        public RigidTransform3(Translation3 translation)
        {
            rotation = quaternion.identity;
            this.translation = translation.translation;
        }

        public RigidTransform3(Rotation3Q rotation)
        {
            this.rotation = rotation;
            translation = float3.zero;
        }

        public static implicit operator Unity.Mathematics.RigidTransform(RigidTransform3 t) => new Unity.Mathematics.RigidTransform(t.rotation, t.translation);
        public static implicit operator RigidTransform3(Unity.Mathematics.RigidTransform t) => new RigidTransform3(t.pos, t.rot);

        public static explicit operator RigidTransform3(Translation3 o) => new RigidTransform3(o.translation, quaternion.identity);
        public static explicit operator RigidTransform3(Rotation3Q o) => new RigidTransform3(float3.zero, o.rotation);
        public static explicit operator RigidTransform3(Rotation3Euler o) => new RigidTransform3(float3.zero, o.rotation3);
        public static explicit operator RigidTransform3(NonUniformTransform3 o) => new RigidTransform3(o.translation, o.rotation);
        public static explicit operator RigidTransform3(Matrix3x3Transform3 o) => new RigidTransform3(float3.zero, o.rotation3);
        public static explicit operator RigidTransform3(Matrix4x4Transform3 o) => new RigidTransform3(o.translation3, o.rotation3);

        public static readonly RigidTransform3 Identity = new RigidTransform3(float3.zero, quaternion.identity);
        public static RigidTransform3 Translating(float3 translation) => new RigidTransform3(translation, quaternion.identity);
        public static RigidTransform3 Rotating(quaternion rotation) => new RigidTransform3(float3.zero, rotation);
        public static RigidTransform3 TR(float3 translation, quaternion rotation) => new RigidTransform3(translation, rotation);

        public Translation3 Translation3 { get => new Translation3(translation); set => translation = value.translation; }
        public Rotation3Q Rotation3 { get => new Rotation3Q(rotation); set => rotation = value.rotation; }
        public float3 this[float3 o] => Transform(o);
        float3 ITranslation3RW.translation3 { get => translation; set => translation = value; }
        float3 ITranslation3.translation3 => translation;
        float3 ITranslation3W.translation3 { set => translation = value; }
        quaternion IRotation3QRW.rotation3 { get => rotation; set => rotation = value; }
        quaternion IRotation3Q.rotation3 => rotation;
        quaternion IRotation3QW.rotation3 { set => rotation = value; }

        public override string ToString() => $"{nameof(RigidTransform3)}(Tx:{translation.x}, Ty:{translation.y}, Tz:{translation.z}, Rx:{rotation.value.x}, Ry:{rotation.value.y}, Rz:{rotation.value.z}, Rw:{rotation.value.w})";
        
        public bool Equals(RigidTransform3 other) => NiMath.Equal(this, other);
        
        public bool NearEquals(Translation3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Rotation3Q other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Scale1 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Scale3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(RigidTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(UniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(NonUniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Matrix3x3Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Matrix4x4Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);

        public RigidTransform3 Inversed => NiMath.Inverse(this);
        public Matrix4x4Transform3 ToMatrix4x4Transform3 => new float4x4(rotation, translation);

        public RigidTransform3 Translated(float3 translation) => NiMath.Translate(translation, this);
        public RigidTransform3 Rotated(quaternion rotation) => NiMath.Rotate(rotation, this);
        public UniformTransform3 Scaled(float scale) => NiMath.Scale(scale, this);
        public Matrix4x4Transform3 Scaled(float3 scale) => NiMath.Scale(scale, this);

        public RigidTransform3 Translate(float3 translation) => NiMath.Translate(this, translation);
        public RigidTransform3 Rotate(quaternion rotation) => NiMath.Rotate(this, rotation);
        public UniformTransform3 Scale(float scale) => NiMath.Scale(this, scale);
        public NonUniformTransform3 Scale(float3 scale) => NiMath.Scale(this, scale);

        public RigidTransform3 Translated(Translation3 translation) => NiMath.Translate(translation, this);
        public RigidTransform3 Rotated(Rotation3Q rotation) => NiMath.Rotate(rotation, this);
        public UniformTransform3 Scaled(Scale1 scale) => NiMath.Scale(scale, this);
        public Matrix4x4Transform3 Scaled(Scale3 scale) => NiMath.Scale(scale, this);

        public RigidTransform3 Translate(Translation3 translation) => NiMath.Translate(this, translation);
        public RigidTransform3 Rotate(Rotation3Q rotation) => NiMath.Rotate(this, rotation);
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

        public RigidTransform3 Mul(Translation3 primitive) => NiMath.Mul(this, primitive);
        public RigidTransform3 Mul(Rotation3Q primitive) => NiMath.Mul(this, primitive);
        public UniformTransform3 Mul(Scale1 primitive) => NiMath.Mul(this, primitive);
        public NonUniformTransform3 Mul(Scale3 primitive) => NiMath.Mul(this, primitive);
        public RigidTransform3 Mul(RigidTransform3 primitive) => NiMath.Mul(this, primitive);
        public UniformTransform3 Mul(UniformTransform3 primitive) => NiMath.Mul(this, primitive);
        public NonUniformTransform3 Mul(NonUniformTransform3 primitive) => NiMath.Mul(this, primitive);
        public Matrix4x4Transform3 Mul(Matrix3x3Transform3 primitive) => NiMath.Mul(this, primitive);
        public Matrix4x4Transform3 Mul(Matrix4x4Transform3 primitive) => NiMath.Mul(this, primitive);
        public Obb3T Mul(Aabb3M o) => NiMath.Mul(this, o);
        public Obb3T Mul(Aabb3C o) => NiMath.Mul(this, o);
        public Obb3T Mul(Aabb3S o) => NiMath.Mul(this, o);
        public Obb3T Mul(Obb3T o) => NiMath.Mul(this, o);
        public Obb3M Mul(Obb3M o) => NiMath.Mul(this, o);
        public RigidTransform3 Div(Translation3 primitive) => NiMath.Div(this, primitive);
        public RigidTransform3 Div(Rotation3Q primitive) => NiMath.Div(this, primitive);
        public UniformTransform3 Div(Scale1 primitive) => NiMath.Div(this, primitive);
        public NonUniformTransform3 Div(Scale3 primitive) => NiMath.Div(this, primitive);
        public RigidTransform3 Div(RigidTransform3 primitive) => NiMath.Div(this, primitive);
        public UniformTransform3 Div(UniformTransform3 primitive) => NiMath.Div(this, primitive);
        public NonUniformTransform3 Div(NonUniformTransform3 primitive) => NiMath.Div(this, primitive);
        public Matrix4x4Transform3 Div(Matrix3x3Transform3 primitive) => NiMath.Div(this, primitive);
        public Matrix4x4Transform3 Div(Matrix4x4Transform3 primitive) => NiMath.Div(this, primitive);
        public Obb3T Div(Aabb3M o) => NiMath.Div(this, o);
        public Obb3T Div(Aabb3C o) => NiMath.Div(this, o);
        public Obb3T Div(Aabb3S o) => NiMath.Div(this, o);
        public Obb3T Div(Obb3T o) => NiMath.Div(this, o);
        public Obb3M Div(Obb3M o) => NiMath.Div(this, o);
    }

    public static partial class NiMath
    {
        public static bool Equal(RigidTransform3 a, RigidTransform3 b) => Equal(a.translation, b.translation) && Equal(a.rotation, b.rotation);

        public static bool NearEqual(RigidTransform3 a, Translation3 b, float margin) => NearEqual(a.translation, b.translation, margin) && NearEqual(a.rotation, quaternion.identity, margin);
        public static bool NearEqual(RigidTransform3 a, Rotation3Q b, float margin) => NearEqual(a.translation, float3.zero, margin) && NearEqual(a.rotation, b.rotation, margin);
        public static bool NearEqual(RigidTransform3 a, Scale1 b, float margin) => NearEqual(a.translation, float3.zero, margin) && NearEqual(a.rotation, quaternion.identity, margin) && NearEqual(1, b.scale, margin);
        public static bool NearEqual(RigidTransform3 a, Scale3 b, float margin) => NearEqual(a.translation, float3.zero, margin) && NearEqual(a.rotation, quaternion.identity, margin) && NearEqual((float3)1, b.scale, margin);
        public static bool NearEqual(RigidTransform3 a, RigidTransform3 b, float margin) => NearEqual(a.translation, b.translation, margin) && NearEqual(a.rotation, b.rotation, margin);
        public static bool NearEqual(RigidTransform3 a, UniformTransform3 b, float margin) => NearEqual(a.translation, b.translation, margin) && NearEqual(a.rotation, b.rotation, margin) && NearEqual(1, b.scale, margin);
        public static bool NearEqual(RigidTransform3 a, NonUniformTransform3 b, float margin) => NearEqual(a.translation, b.translation, margin) && NearEqual(a.rotation, b.rotation, margin) && NearEqual(new float3(1), b.scale, margin);
        public static bool NearEqual(RigidTransform3 a, Matrix3x3Transform3 b, float margin) => NearEqual(a.translation, float3.zero, margin) && NearEqual(new Matrix3x3Transform3(a.rotation), b, margin);
        public static bool NearEqual(RigidTransform3 a, Matrix4x4Transform3 b, float margin) => NearEqual(a.ToMatrix4x4Transform3, b, margin);

        public static RigidTransform3 Inverse(RigidTransform3 o)
        {
            quaternion r = math.inverse(o.rotation);
            return new RigidTransform3(math.mul(r, -o.translation), r);
        }

        public static float3 RotateVector(RigidTransform3 rotation, float3 vector) => RotateVector(rotation.rotation, vector);

        public static RigidTransform3 Translate(float3 translation, RigidTransform3 o) => new RigidTransform3(translation + o.translation, o.rotation);
        public static RigidTransform3 Rotate(quaternion rotation, RigidTransform3 o) => new RigidTransform3(math.mul(rotation, o.translation), math.mul(rotation, o.rotation));
        public static UniformTransform3 Scale(float scale, RigidTransform3 o) => new UniformTransform3(scale * o.translation, o.rotation, scale);
        public static Matrix4x4Transform3 Scale(float3 scale, RigidTransform3 o) => math.mul(float4x4.Scale(scale), new float4x4(o.rotation, o.translation));
        public static RigidTransform3 Translate(RigidTransform3 o, float3 translation) => new RigidTransform3(o.translation + math.mul(o.rotation, translation), o.rotation);
        public static RigidTransform3 Rotate(RigidTransform3 o, quaternion rotation) => new RigidTransform3(o.translation, math.mul(o.rotation, rotation));
        public static UniformTransform3 Scale(RigidTransform3 o, float scale) => new UniformTransform3(o.translation, o.rotation, scale);
        public static NonUniformTransform3 Scale(RigidTransform3 o, float3 scale) => new NonUniformTransform3(o.translation, o.rotation, scale);

        public static RigidTransform3 Translate(Translation3 translation, RigidTransform3 o) => new RigidTransform3(translation.translation + o.translation, o.rotation);
        public static RigidTransform3 Rotate(Rotation3Q rotation, RigidTransform3 o) => new RigidTransform3(math.mul(rotation, o.translation), math.mul(rotation, o.rotation));
        public static UniformTransform3 Scale(Scale1 scale, RigidTransform3 o) => new UniformTransform3(scale.scale * o.translation, o.rotation, scale.scale);
        public static Matrix4x4Transform3 Scale(Scale3 scale, RigidTransform3 o) => math.mul(float4x4.Scale(scale.scale), new float4x4(o.rotation, o.translation));

        public static RigidTransform3 Translate(RigidTransform3 o, Translation3 translation) => Translate(o, translation.translation);
        public static RigidTransform3 Rotate(RigidTransform3 o, Rotation3Q rotation) => Rotate(o, rotation.rotation);
        public static UniformTransform3 Scale(RigidTransform3 o, Scale1 scale) => Scale(o, scale.scale);
        public static NonUniformTransform3 Scale(RigidTransform3 o, Scale3 scale) => Scale(o, scale.scale);

        public static float3 Transform(RigidTransform3 a, float3 b) => Translate(a.translation, Rotate(a.rotation, b));
        public static Direction3 Transform(RigidTransform3 a, Direction3 b) => new Direction3(Rotate(a.rotation, b.vector));
        public static ProjectionAxis3x1 Transform(RigidTransform3 a, ProjectionAxis3x1 b) => new ProjectionAxis3x1(Rotate(a.rotation, b.axis));
        public static ProjectionAxis1x3 Transform(RigidTransform3 a, ProjectionAxis1x3 b) => new ProjectionAxis1x3(Rotate(a.rotation, b.axis));
        public static Ray3 Transform(RigidTransform3 a, Ray3 b) => new Ray3(Transform(a, b.translation), Transform(a.Rotation3, b.projectionAxis));
        public static float3 Untransform(RigidTransform3 a, float3 b) => math.mul(Inverse(a.rotation), -a.translation + b);
        public static Direction3 Untransform(RigidTransform3 a, Direction3 b) => Transform(Inverse(a), b);
        public static ProjectionAxis3x1 Untransform(RigidTransform3 a, ProjectionAxis3x1 b) => Transform(Inverse(a), b);
        public static ProjectionAxis1x3 Untransform(RigidTransform3 a, ProjectionAxis1x3 b) => Transform(Inverse(a), b);
        public static Ray3 Untransform(RigidTransform3 a, Ray3 b) => Transform(Inverse(a), b);

        public static RigidTransform3 Mul(RigidTransform3 a, Translation3 b) => Translate(a.translation, Rotate(a.rotation, b));
        public static RigidTransform3 Mul(RigidTransform3 a, Rotation3Q b) => Translate(a.translation, Rotate(a.rotation, b));
        public static UniformTransform3 Mul(RigidTransform3 a, Scale1 b) => Translate(a.translation, Rotate(a.rotation, b));
        public static NonUniformTransform3 Mul(RigidTransform3 a, Scale3 b) => Translate(a.translation, Rotate(a.rotation, b));
        public static RigidTransform3 Mul(RigidTransform3 a, RigidTransform3 b) => Translate(a.translation, Rotate(a.rotation, b));
        public static UniformTransform3 Mul(RigidTransform3 a, UniformTransform3 b) => Translate(a.translation, Rotate(a.rotation, b));
        public static NonUniformTransform3 Mul(RigidTransform3 a, NonUniformTransform3 b) => Translate(a.translation, Rotate(a.rotation, b));
        public static Matrix4x4Transform3 Mul(RigidTransform3 a, Matrix3x3Transform3 b) => Translate(a.translation, Rotate(a.rotation, b));
        public static Matrix4x4Transform3 Mul(RigidTransform3 a, Matrix4x4Transform3 b) => Translate(a.translation, Rotate(a.rotation, b));
        public static Obb3T Mul(RigidTransform3 a, Aabb3M b) => new NonUniformTransform3(Transform(a, b.translation3), a.rotation, b.scale3); // Ta * Ra * S3a * Tb * S3b 
        public static Obb3T Mul(RigidTransform3 a, Aabb3C b) => new NonUniformTransform3(Transform(a, b.translation3), a.rotation, b.scale3);
        public static Obb3T Mul(RigidTransform3 a, Aabb3S b) => new NonUniformTransform3(Transform(a, b.translation3), a.rotation, b.scale3);
        public static Obb3T Mul(RigidTransform3 a, Obb3T b) => Mul(a, b.NonUniformTransform);
        public static Obb3M Mul(RigidTransform3 a, Obb3M b) => Mul(a, b.ToMatrix4x4Transform3);
        public static RigidTransform3 Div(RigidTransform3 a, Translation3 b) => Rotate(Inverse(a.rotation), Translate(-a.translation, b));
        public static RigidTransform3 Div(RigidTransform3 a, Rotation3Q b) => Rotate(Inverse(a.rotation), Translate(-a.translation, b));
        public static UniformTransform3 Div(RigidTransform3 a, Scale1 b) => Rotate(Inverse(a.rotation), Translate(-a.translation, b));
        public static NonUniformTransform3 Div(RigidTransform3 a, Scale3 b) => Rotate(Inverse(a.rotation), Translate(-a.translation, b));
        public static RigidTransform3 Div(RigidTransform3 a, RigidTransform3 b) => Rotate(Inverse(a.rotation), Translate(-a.translation, b));
        public static UniformTransform3 Div(RigidTransform3 a, UniformTransform3 b) => Rotate(Inverse(a.rotation), Translate(-a.translation, b));
        public static NonUniformTransform3 Div(RigidTransform3 a, NonUniformTransform3 b) => Rotate(Inverse(a.rotation), Translate(-a.translation, b));
        public static Matrix4x4Transform3 Div(RigidTransform3 a, Matrix3x3Transform3 b) => Rotate(Inverse(a.rotation), Translate(-a.translation, b));
        public static Matrix4x4Transform3 Div(RigidTransform3 a, Matrix4x4Transform3 b) => Rotate(Inverse(a.rotation), Translate(-a.translation, b));
        public static Obb3T Div(RigidTransform3 a, Aabb3M b) => Mul(Inverse(a), b);
        public static Obb3T Div(RigidTransform3 a, Aabb3C b) => Mul(Inverse(a), b);
        public static Obb3T Div(RigidTransform3 a, Aabb3S b) => Mul(Inverse(a), b);
        public static Obb3T Div(RigidTransform3 a, Obb3T b) => Mul(Inverse(a), b);
        public static Obb3M Div(RigidTransform3 a, Obb3M b) => Mul(Inverse(a), b);
    }
}