using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    /// <summary>
    /// Represent the sequence of transformations: Translation * Rotation * UniformScale
    /// </summary>
    [Serializable]
    public struct UniformTransform3 : ITransform3, IRotation3QRW, ITranslation3RW, IUniformScaleRW,
        IEquatable<UniformTransform3>,
        ITransformable3<UniformTransform3, UniformTransform3, UniformTransform3, UniformTransform3, Matrix4x4Transform3, UniformTransform3, UniformTransform3, UniformTransform3, NonUniformTransform3>,
        IInvertible<UniformTransform3>,
        ITransform<float3>,
        ITransform<Ray3>,
        IMultipliable<Translation3, UniformTransform3>,
        IMultipliable<Rotation3Q, UniformTransform3>,
        IMultipliable<Scale1, UniformTransform3>,
        IMultipliable<Scale3, NonUniformTransform3>,
        IMultipliable<RigidTransform3, UniformTransform3>,
        IMultipliable<UniformTransform3>,
        IMultipliable<NonUniformTransform3>,
        IMultipliable<Matrix3x3Transform3, Matrix4x4Transform3>,
        IMultipliable<Matrix4x4Transform3>,
        IMultipliable<Aabb3M, Obb3T>,
        IMultipliable<Aabb3C, Obb3T>,
        IMultipliable<Aabb3S, Obb3T>,
        IMultipliable<Obb3T>,
        IMultipliable<Obb3M, Obb3M>,
        IDividable<Translation3, UniformTransform3>,
        IDividable<Rotation3Q, UniformTransform3>,
        IDividable<Scale1, UniformTransform3>,
        IDividable<Scale3, NonUniformTransform3>,
        IDividable<RigidTransform3, UniformTransform3>,
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
        public float scale;

        public UniformTransform3(float3 translation, quaternion rotation, float scale)
        {
            this.rotation = rotation;
            this.translation = translation;
            this.scale = scale;
        }

        public UniformTransform3(float3 translation, quaternion rotation)
        {
            this.rotation = rotation;
            this.translation = translation;
            scale = 1;
        }

        public UniformTransform3(quaternion rotation)
        {
            this.rotation = rotation;
            translation = 0;
            scale = 1;
        }

        public UniformTransform3(quaternion rotation, float scale)
        {
            this.rotation = rotation;
            translation = 0;
            this.scale = scale;
        }

        public UniformTransform3(Translation3 translation, Rotation3Q rotation, Scale1 scale)
        {
            this.rotation = rotation;
            this.translation = translation.translation;
            this.scale = scale.scale;
        }

        public UniformTransform3(Translation3 translation, Rotation3Q rotation)
        {
            this.rotation = rotation;
            this.translation = translation.translation;
            scale = 1;
        }

        public UniformTransform3(Translation3 translation, Scale1 scale)
        {
            rotation = quaternion.identity;
            this.translation = translation.translation;
            this.scale = scale.scale;
        }

        public UniformTransform3(Rotation3Q rotation, Scale1 scale)
        {
            this.rotation = rotation;
            translation = 0;
            this.scale = scale.scale;
        }

        public UniformTransform3(Translation3 translation)
        {
            rotation = quaternion.identity;
            this.translation = translation.translation;
            scale = 1;
        }

        public UniformTransform3(Rotation3Q rotation)
        {
            this.rotation = rotation;
            translation = 0;
            scale = 1;
        }

        public UniformTransform3(Scale1 scale)
        {
            rotation = quaternion.identity;
            translation = 0;
            this.scale = scale.scale;
        }

        public static explicit operator UniformTransform3(Translation3 o) => new UniformTransform3(o.translation, quaternion.identity, 1);
        public static explicit operator UniformTransform3(Rotation3Q o) => new UniformTransform3(float3.zero, o.rotation, 1);
        public static explicit operator UniformTransform3(Rotation3Euler o) => new UniformTransform3(float3.zero, o.rotation3, 1);
        public static explicit operator UniformTransform3(RigidTransform3 o) => new UniformTransform3(o.translation, o.rotation, 1);
        public static explicit operator UniformTransform3(NonUniformTransform3 o) => new UniformTransform3(o.translation, o.rotation, o.scale.x);
        public static explicit operator UniformTransform3(Matrix3x3Transform3 o) => new UniformTransform3(float3.zero, o.rotation3, o.scale3.x);
        public static explicit operator UniformTransform3(Matrix4x4Transform3 o) => new UniformTransform3(o.translation3, o.rotation3, o.scale3.x);

        public static readonly UniformTransform3 Identity = new UniformTransform3(float3.zero, quaternion.identity, 1);
        public static UniformTransform3 Translating(float3 translation) => new UniformTransform3(translation, quaternion.identity, 1);
        public static UniformTransform3 Rotating(quaternion rotation) => new UniformTransform3(float3.zero, rotation, 1);
        public static UniformTransform3 Scaling(float scale) => new UniformTransform3(float3.zero, quaternion.identity, scale);
        public static UniformTransform3 TRS(float3 translation, quaternion rotation, float scale) => new UniformTransform3(translation, rotation, scale);

        public float3 this[float3 o] => Transform(o);

        public Translation3 Translation3 { get => new Translation3(translation); set => translation = value.translation; }
        public Rotation3Q Rotation3 { get => new Rotation3Q(rotation); set => rotation = value.rotation; }
        public Scale1 Scale1 { get => new Scale1(scale); set => scale = value.scale; }
        float3 ITranslation3RW.translation3 { get => translation; set => translation = value; }
        float3 ITranslation3.translation3 => translation;
        float3 ITranslation3W.translation3 { set => translation = value; }
        quaternion IRotation3QRW.rotation3 { get => rotation; set => rotation = value; }
        quaternion IRotation3Q.rotation3 => rotation;
        quaternion IRotation3QW.rotation3 { set => rotation = value; }
        float IUniformScaleRW.scale1 { get => scale; set => scale = value; }
        float IUniformScale.scale1 => scale;
        float IUniformScaleW.scale1 { set => scale = value; }

        public override string ToString() => $"{nameof(UniformTransform3)}(Tx:{translation.x}, Ty:{translation.y}, Tz:{translation.z}, Rx:{rotation.value.x}, Ry:{rotation.value.y}, Rz:{rotation.value.z}, Rw:{rotation.value.w}, S:{scale})";
        
        public bool Equals(UniformTransform3 other) => NiMath.Equal(this, other);
        
        public bool NearEquals(Translation3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Rotation3Q other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Scale1 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Scale3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(RigidTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(UniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(NonUniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Matrix3x3Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Matrix4x4Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);

        public UniformTransform3 Inversed => NiMath.Inverse(this);
        public Matrix4x4Transform3 ToMatrix4x4Transform => float4x4.TRS(translation, rotation, scale);

        public UniformTransform3 Translated(float3 translation) => NiMath.Translate(translation, this);
        public UniformTransform3 Rotated(quaternion rotation) => NiMath.Rotate(rotation, this);
        public UniformTransform3 Scaled(float scale) => NiMath.Scale(scale, this);
        public Matrix4x4Transform3 Scaled(float3 scale) => NiMath.Scale(scale, this);

        public UniformTransform3 Translate(float3 translation) => NiMath.Translate(this, translation);
        public UniformTransform3 Rotate(quaternion rotation) => NiMath.Rotate(this, rotation);
        public UniformTransform3 Scale(float scale) => NiMath.Scale(this, scale);
        public NonUniformTransform3 Scale(float3 scale) => NiMath.Scale(this, scale);

        public UniformTransform3 Translated(Translation3 translation) => NiMath.Translate(translation, this);
        public UniformTransform3 Rotated(Rotation3Q rotation) => NiMath.Rotate(rotation, this);
        public UniformTransform3 Scaled(Scale1 scale) => NiMath.Scale(scale, this);
        public Matrix4x4Transform3 Scaled(Scale3 scale) => NiMath.Scale(scale, this);

        public UniformTransform3 Translate(Translation3 translation) => NiMath.Translate(this, translation);
        public UniformTransform3 Rotate(Rotation3Q rotation) => NiMath.Rotate(this, rotation);
        public UniformTransform3 Scale(Scale1 scale) => NiMath.Scale(this, scale);
        public NonUniformTransform3 Scale(Scale3 scale) => NiMath.Scale(this, scale);

        public float3 Transform(float3 o) => NiMath.Transform(this, o);
        public Ray3 Transform(Ray3 o) => NiMath.Transform(this, o);
        public float3 Untransform(float3 o) => NiMath.Untransform(this, o);
        public Ray3 Untransform(Ray3 o) => NiMath.Untransform(this, o);

        public UniformTransform3 Mul(Translation3 primitive) => NiMath.Mul(this, primitive);
        public UniformTransform3 Mul(Rotation3Q primitive) => NiMath.Mul(this, primitive);
        public UniformTransform3 Mul(Scale1 primitive) => NiMath.Mul(this, primitive);
        public NonUniformTransform3 Mul(Scale3 primitive) => NiMath.Mul(this, primitive);
        public UniformTransform3 Mul(RigidTransform3 primitive) => NiMath.Mul(this, primitive);
        public UniformTransform3 Mul(UniformTransform3 primitive) => NiMath.Mul(this, primitive);
        public NonUniformTransform3 Mul(NonUniformTransform3 primitive) => NiMath.Mul(this, primitive);
        public Matrix4x4Transform3 Mul(Matrix3x3Transform3 primitive) => NiMath.Mul(this, primitive);
        public Matrix4x4Transform3 Mul(Matrix4x4Transform3 primitive) => NiMath.Mul(this, primitive);
        public Obb3T Mul(Aabb3M o) => NiMath.Mul(this, o);
        public Obb3T Mul(Aabb3C o) => NiMath.Mul(this, o);
        public Obb3T Mul(Aabb3S o) => NiMath.Mul(this, o);
        public Obb3T Mul(Obb3T o) => NiMath.Mul(this, o);
        public Obb3M Mul(Obb3M o) => NiMath.Mul(this, o);
        public UniformTransform3 Div(Translation3 primitive) => NiMath.Div(this, primitive);
        public UniformTransform3 Div(Rotation3Q primitive) => NiMath.Div(this, primitive);
        public UniformTransform3 Div(Scale1 primitive) => NiMath.Div(this, primitive);
        public NonUniformTransform3 Div(Scale3 primitive) => NiMath.Div(this, primitive);
        public UniformTransform3 Div(RigidTransform3 primitive) => NiMath.Div(this, primitive);
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
        public static bool Equal(UniformTransform3 a, UniformTransform3 b) => Equal(a.translation, b.translation) && Equal(a.rotation, b.rotation) && Equal(a.scale, b.scale);

        public static bool NearEqual(UniformTransform3 a, Translation3 b, float margin) => NearEqual(a.translation, b.translation, margin) && NearEqual(a.rotation, quaternion.identity, margin) && NearEqual(a.scale, 1, margin);
        public static bool NearEqual(UniformTransform3 a, Rotation3Q b, float margin) => NearEqual(a.translation, float3.zero, margin) && NearEqual(a.rotation, b.rotation, margin) && NearEqual(a.scale, 1, margin);
        public static bool NearEqual(UniformTransform3 a, Scale1 b, float margin) => NearEqual(a.translation, float3.zero, margin) && NearEqual(a.rotation, quaternion.identity, margin) && NearEqual(a.scale, b.scale, margin);
        public static bool NearEqual(UniformTransform3 a, Scale3 b, float margin) => NearEqual(a.translation, float3.zero, margin) && NearEqual(a.rotation, quaternion.identity, margin) && NearEqual((float3)a.scale, b.scale, margin);
        public static bool NearEqual(UniformTransform3 a, RigidTransform3 b, float margin) => NearEqual(a.translation, b.translation, margin) && NearEqual(a.rotation, b.rotation, margin) && NearEqual(a.scale, 0, margin);
        public static bool NearEqual(UniformTransform3 a, UniformTransform3 b, float margin) => NearEqual(a.translation, b.translation, margin) && NearEqual(a.rotation, b.rotation, margin) && NearEqual(a.scale, b.scale, margin);
        public static bool NearEqual(UniformTransform3 a, NonUniformTransform3 b, float margin) => NearEqual(a.translation, b.translation, margin) && NearEqual(a.rotation, b.rotation, margin) && NearEqual((float3)a.scale, b.scale, margin);
        public static bool NearEqual(UniformTransform3 a, Matrix3x3Transform3 b, float margin) => NearEqual(a.translation, float3.zero, margin) && NearEqual(new Matrix3x3Transform3(a.rotation, a.scale), b, margin);
        public static bool NearEqual(UniformTransform3 a, Matrix4x4Transform3 b, float margin) => NearEqual(a.ToMatrix4x4Transform, b, margin);

        public static UniformTransform3 Inverse(UniformTransform3 a)
        {
            float s = math.rcp(a.scale);
            quaternion r = math.inverse(a.rotation);
            return new UniformTransform3(s * math.mul(r, -a.translation), r.value, s);
        }

        public static float3 RotateVector(UniformTransform3 rotation, float3 vector) => RotateVector(rotation.rotation, vector);

        public static UniformTransform3 Translate(float3 translation, UniformTransform3 o) => new UniformTransform3(translation + o.translation, o.rotation, o.scale);
        public static UniformTransform3 Rotate(quaternion rotation, UniformTransform3 b) => new UniformTransform3(math.mul(rotation, b.translation), math.mul(rotation, b.rotation), b.scale);
        public static UniformTransform3 Scale(float scale, UniformTransform3 b) => new UniformTransform3(scale * b.translation, b.rotation, scale * b.scale);
        public static Matrix4x4Transform3 Scale(float3 scale, UniformTransform3 o) => math.mul(float4x4.Scale(scale), float4x4.TRS(o.translation, o.rotation, o.scale));
        public static UniformTransform3 Translate(UniformTransform3 o, float3 translation) => new UniformTransform3(o.translation + math.mul(o.rotation, o.scale * translation), o.rotation, o.scale);
        public static UniformTransform3 Rotate(UniformTransform3 o, quaternion rotation) => new UniformTransform3(o.translation, math.mul(o.rotation, rotation), o.scale);
        public static UniformTransform3 Scale(UniformTransform3 o, float scale) => new UniformTransform3(o.translation, o.rotation, o.scale * scale);
        public static NonUniformTransform3 Scale(UniformTransform3 o, float3 scale) => new NonUniformTransform3(o.translation, o.rotation, o.scale * scale);
        public static UniformTransform3 Translate(Translation3 translation, UniformTransform3 o) => new UniformTransform3(translation.translation + o.translation, o.rotation, o.scale);
        public static UniformTransform3 Rotate(Rotation3Q rotation, UniformTransform3 b) => new UniformTransform3(math.mul(rotation, b.translation), math.mul(rotation, b.rotation), b.scale);
        public static UniformTransform3 Scale(Scale1 scale, UniformTransform3 b) => new UniformTransform3(scale.scale * b.translation, b.rotation, scale.scale * b.scale);
        public static Matrix4x4Transform3 Scale(Scale3 scale, UniformTransform3 o) => math.mul(float4x4.Scale(scale.scale), float4x4.TRS(o.translation, o.rotation, o.scale));
        public static UniformTransform3 Translate(UniformTransform3 o, Translation3 translation) => Translate(o, translation.translation);
        public static UniformTransform3 Rotate(UniformTransform3 o, Rotation3Q rotation) => Rotate(o, rotation.rotation);
        public static UniformTransform3 Scale(UniformTransform3 o, Scale1 scale) => Scale(o, scale.scale);
        public static NonUniformTransform3 Scale(UniformTransform3 o, Scale3 scale) => Scale(o, scale.scale);

        public static float3 Transform(UniformTransform3 a, float3 b) => Translate(a.translation, Rotate(a.rotation, Scale(a.scale, b)));
        public static Ray3 Transform(UniformTransform3 a, Ray3 b) => new Ray3(Transform(a, b.translation), Transform(a.Rotation3, Transform(a.Scale1, b.projectionAxis)));
        public static float3 Untransform(UniformTransform3 a, float3 b) => math.rcp(a.scale) * math.mul(Inverse(a.rotation), -a.translation + b);
        public static Ray3 Untransform(UniformTransform3 a, Ray3 b) => Transform(Inverse(a), b);

        public static UniformTransform3 Mul(UniformTransform3 a, Translation3 b) => Translate(a.translation, Rotate(a.rotation, Scale(a.scale, b)));
        public static UniformTransform3 Mul(UniformTransform3 a, Rotation3Q b) => Translate(a.translation, Rotate(a.rotation, Scale(a.scale, b)));
        public static UniformTransform3 Mul(UniformTransform3 a, Scale1 b) => Translate(a.translation, Rotate(a.rotation, Scale(a.scale, b)));
        public static NonUniformTransform3 Mul(UniformTransform3 a, Scale3 b) => Translate(a.translation, Rotate(a.rotation, Scale(a.scale, b)));
        public static UniformTransform3 Mul(UniformTransform3 a, RigidTransform3 b) => Translate(a.translation, Rotate(a.rotation, Scale(a.scale, b)));
        public static UniformTransform3 Mul(UniformTransform3 a, UniformTransform3 b) => Translate(a.translation, Rotate(a.rotation, Scale(a.scale, b)));
        public static NonUniformTransform3 Mul(UniformTransform3 a, NonUniformTransform3 b) => Translate(a.translation, Rotate(a.rotation, Scale(a.scale, b)));
        public static Matrix4x4Transform3 Mul(UniformTransform3 a, Matrix3x3Transform3 b) => Translate(a.translation, Rotate(a.rotation, Scale(a.scale, b)));
        public static Matrix4x4Transform3 Mul(UniformTransform3 a, Matrix4x4Transform3 b) => Translate(a.translation, Rotate(a.rotation, Scale(a.scale, b)));
        public static Obb3T Mul(UniformTransform3 a, Aabb3M b) => new NonUniformTransform3(Transform(a, b.translation3), a.rotation, a.scale * b.scale3); // Ta * Ra * S3a * Tb * S3b 
        public static Obb3T Mul(UniformTransform3 a, Aabb3C b) => new NonUniformTransform3(Transform(a, b.translation3), a.rotation, a.scale * b.scale3);
        public static Obb3T Mul(UniformTransform3 a, Aabb3S b) => new NonUniformTransform3(Transform(a, b.translation3), a.rotation, a.scale * b.scale3);
        public static Obb3T Mul(UniformTransform3 a, Obb3T b) => Mul(a, b.NonUniformTransform);
        public static Obb3M Mul(UniformTransform3 a, Obb3M b) => Mul(a, b.ToMatrix4x4Transform);
        public static UniformTransform3 Div(UniformTransform3 a, Translation3 b) => Scale(Inverse(a.Scale1).scale, Rotate(Inverse(a.rotation), Translate(-a.translation, b)));
        public static UniformTransform3 Div(UniformTransform3 a, Rotation3Q b) => Scale(Inverse(a.Scale1).scale, Rotate(Inverse(a.rotation), Translate(-a.translation, b)));
        public static UniformTransform3 Div(UniformTransform3 a, Scale1 b) => Scale(Inverse(a.Scale1).scale, Rotate(Inverse(a.rotation), Translate(-a.translation, b)));
        public static NonUniformTransform3 Div(UniformTransform3 a, Scale3 b) => Scale(Inverse(a.Scale1).scale, Rotate(Inverse(a.rotation), Translate(-a.translation, b)));
        public static UniformTransform3 Div(UniformTransform3 a, RigidTransform3 b) => Scale(Inverse(a.Scale1).scale, Rotate(Inverse(a.rotation), Translate(-a.translation, b)));
        public static UniformTransform3 Div(UniformTransform3 a, UniformTransform3 b) => Scale(Inverse(a.Scale1).scale, Rotate(Inverse(a.rotation), Translate(-a.translation, b)));
        public static NonUniformTransform3 Div(UniformTransform3 a, NonUniformTransform3 b) => Scale(Inverse(a.Scale1).scale, Rotate(Inverse(a.rotation), Translate(-a.translation, b)));
        public static Matrix4x4Transform3 Div(UniformTransform3 a, Matrix3x3Transform3 b) => Scale(Inverse(a.Scale1).scale, Rotate(Inverse(a.rotation), Translate(-a.translation, b)));
        public static Matrix4x4Transform3 Div(UniformTransform3 a, Matrix4x4Transform3 b) => Scale(Inverse(a.Scale1).scale, Rotate(Inverse(a.rotation), Translate(-a.translation, b)));
        public static Obb3T Div(UniformTransform3 a, Aabb3M b) => Mul(Inverse(a), b);
        public static Obb3T Div(UniformTransform3 a, Aabb3C b) => Mul(Inverse(a), b);
        public static Obb3T Div(UniformTransform3 a, Aabb3S b) => Mul(Inverse(a), b);
        public static Obb3T Div(UniformTransform3 a, Obb3T b) => Mul(Inverse(a), b);
        public static Obb3M Div(UniformTransform3 a, Obb3M b) => Mul(Inverse(a), b);
    }
}