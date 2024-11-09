using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    /// <summary>
    /// Represent the sequence of transformations: Translation * Rotation * NonUniformScale
    /// </summary>
    [Serializable]
    public struct NonUniformTransform3 : ITransform3<NonUniformTransform3>, IRotation3QRW, ITranslation3RW, IScale3RW,
        ITransformable3<NonUniformTransform3, NonUniformTransform3, NonUniformTransform3, NonUniformTransform3, Matrix4x4Transform3, NonUniformTransform3, Matrix4x4Transform3, NonUniformTransform3, NonUniformTransform3>,
        //IShearableTransformable3<NonUniformTransform3, Matrix4x4Transform3>,
        IInvertible<Matrix4x4Transform3>,
        IMultipliable<Translation3, NonUniformTransform3>,
        IMultipliable<Rotation3Q, Matrix4x4Transform3>,
        IMultipliable<Scale1, NonUniformTransform3>,
        IMultipliable<Scale3, NonUniformTransform3>,
        IMultipliable<RigidTransform3, Matrix4x4Transform3>,
        IMultipliable<UniformTransform3, Matrix4x4Transform3>,
        IMultipliable<NonUniformTransform3, Matrix4x4Transform3>,
        IMultipliable<Matrix3x3Transform3, Matrix4x4Transform3>,
        IMultipliable<Matrix4x4Transform3>,
        IMultipliable<Aabb3M, Obb3T>,
        IMultipliable<Aabb3C, Obb3T>,
        IMultipliable<Aabb3S, Obb3T>,
        IMultipliable<Obb3T, Obb3M>,
        IMultipliable<Obb3M>,
        IDividable<Translation3, Matrix4x4Transform3>,
        IDividable<Rotation3Q, Matrix4x4Transform3>,
        IDividable<Scale1, Matrix4x4Transform3>,
        IDividable<Scale3, Matrix4x4Transform3>,
        IDividable<RigidTransform3, Matrix4x4Transform3>,
        IDividable<UniformTransform3, Matrix4x4Transform3>,
        IDividable<NonUniformTransform3, Matrix4x4Transform3>,
        IDividable<Matrix3x3Transform3, Matrix4x4Transform3>,
        IDividable<Matrix4x4Transform3>,
        IDividable<Aabb3M, Obb3M>,
        IDividable<Aabb3C, Obb3M>,
        IDividable<Aabb3S, Obb3M>,
        IDividable<Obb3T, Obb3M>,
        IDividable<Obb3M, Obb3M>
    {
        public quaternion rotation;
        public float3 translation;
        public float3 scale;

        public NonUniformTransform3(float3 translation, quaternion rotation, float3 scale)
        {
            this.rotation = rotation;
            this.translation = translation;
            this.scale = scale;
        }

        public NonUniformTransform3(float3 translation, quaternion rotation)
        {
            this.rotation = rotation;
            this.translation = translation;
            scale = 1;
        }

        public NonUniformTransform3(quaternion rotation)
        {
            this.rotation = rotation;
            translation = 0;
            scale = 1;
        }

        public NonUniformTransform3(quaternion rotation, float3 scale)
        {
            this.rotation = rotation;
            translation = 0;
            this.scale = scale;
        }

        public NonUniformTransform3(Translation3 translation, Rotation3Q rotation, Scale3 scale)
        {
            this.rotation = rotation;
            this.translation = translation.translation;
            this.scale = scale.scale;
        }

        public NonUniformTransform3(Translation3 translation, Rotation3Q rotation)
        {
            this.rotation = rotation;
            this.translation = translation.translation;
            scale = 1;
        }

        public NonUniformTransform3(Translation3 translation, Scale3 scale)
        {
            rotation = quaternion.identity;
            this.translation = translation.translation;
            this.scale = scale.scale;
        }

        public NonUniformTransform3(Rotation3Q rotation, Scale3 scale)
        {
            this.rotation = rotation;
            translation = 0;
            this.scale = scale.scale;
        }

        public NonUniformTransform3(Translation3 translation)
        {
            rotation = quaternion.identity;
            this.translation = translation.translation;
            scale = 1;
        }

        public NonUniformTransform3(Rotation3Q rotation)
        {
            this.rotation = rotation;
            translation = 0;
            scale = 1;
        }

        public NonUniformTransform3(Scale3 scale)
        {
            rotation = quaternion.identity;
            translation = 0;
            this.scale = scale.scale;
        }

        public static explicit operator NonUniformTransform3(Translation3 o) => new NonUniformTransform3(o.translation, quaternion.identity, 1);
        public static explicit operator NonUniformTransform3(Rotation3Q o) => new NonUniformTransform3(float3.zero, o.rotation, 1);
        public static explicit operator NonUniformTransform3(Rotation3Euler o) => new NonUniformTransform3(float3.zero, o.rotation3, 1);
        public static explicit operator NonUniformTransform3(UniformTransform3 o) => new NonUniformTransform3(o.translation, o.rotation, o.scale);
        public static explicit operator NonUniformTransform3(RigidTransform3 o) => new NonUniformTransform3(o.translation, o.rotation, 1);
        public static explicit operator NonUniformTransform3(Matrix4x4Transform3 o) => new NonUniformTransform3(o.translation3, o.rotation3, o.scale3);
        public static explicit operator NonUniformTransform3(Matrix3x3Transform3 o) => new NonUniformTransform3(float3.zero, o.rotation3, o.scale3);

        public static readonly NonUniformTransform3 Identity = new NonUniformTransform3(float3.zero, quaternion.identity, 1);
        public static NonUniformTransform3 Translating(float3 translation) => new NonUniformTransform3(translation, quaternion.identity, 1);
        public static NonUniformTransform3 Rotating(quaternion rotation) => new NonUniformTransform3(float3.zero, rotation, 1);
        public static NonUniformTransform3 Scaling(float scale) => new NonUniformTransform3(float3.zero, quaternion.identity, scale);
        public static NonUniformTransform3 Scaling(float3 scale) => new NonUniformTransform3(float3.zero, quaternion.identity, scale);
        public static NonUniformTransform3 TRS(float3 translation, quaternion rotation, float scale) => new NonUniformTransform3(translation, rotation, scale);
        public static NonUniformTransform3 TRS(float3 translation, quaternion rotation, float3 scale) => new NonUniformTransform3(translation, rotation, scale);

        public Aabb3M TranslationScale
        {
            get => new Aabb3M(translation, scale);

            set
            {
                translation = value.translation3;
                scale = value.scale3;
            }
        }

        public RigidTransform3 TranslationRotation
        {
            get => new RigidTransform3(translation, rotation);
            set
            {
                translation = value.translation;
                rotation = value.rotation;
            }
        }

        public Matrix3x3Transform3 RotationScale
        {
            get => new Matrix3x3Transform3(rotation, scale);
            set
            {
                rotation = value.rotation3;
                scale = value.scale3;
            }
        }

        public float3 this[float3 o] => Transform(o);

        public Translation3 Translation3 { get => new Translation3(translation); set => translation = value.translation; }
        public Rotation3Q Rotation3 { get => new Rotation3Q(rotation); set => rotation = value.rotation; }
        public Scale3 Scale3 { get => new Scale3(scale); set => scale = value.scale; }
        float3 ITranslation3RW.translation3 { get => translation; set => translation = value; }
        float3 ITranslation3.translation3 => translation;
        float3 ITranslation3W.translation3 { set => translation = value; }
        quaternion IRotation3QRW.rotation3 { get => rotation; set => rotation = value; }
        quaternion IRotation3Q.rotation3 => rotation;
        quaternion IRotation3QW.rotation3 { set => rotation = value; }
        float3 IScale3RW.scale3 { get => scale; set => scale = value; }
        float3 IScale3.scale3 => scale;
        float3 IScale3W.scale3 { set => scale = value; }

        public override string ToString() => $"{nameof(NonUniformTransform3)}(Tx:{translation.x}, Ty:{translation.y}, Tz:{translation.z}, Rx:{rotation.value.x}, Ry:{rotation.value.y}, Rz:{rotation.value.z}, Rw:{rotation.value.w}, Sx:{scale.x}, Sy:{scale.y}, Sz:{scale.z})";
        
        public bool Equals(NonUniformTransform3 other) => NiMath.Equal(this, other);
        
        public bool NearEquals(Translation3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Rotation3Q other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Scale1 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Scale3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(RigidTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(UniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(NonUniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Matrix3x3Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Matrix4x4Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);

        public Matrix4x4Transform3 Inversed => NiMath.Inverse(this);
        public Matrix4x4Transform3 ToMatrix4x4Transform => float4x4.TRS(translation, rotation, scale);

        public NonUniformTransform3 Translated(float3 translation) => NiMath.Translate(translation, this);
        public NonUniformTransform3 Rotated(quaternion rotation) => NiMath.Rotate(rotation, this);
        public NonUniformTransform3 Scaled(float scale) => NiMath.Scale(scale, this);
        public Matrix4x4Transform3 Scaled(float3 scale) => NiMath.Scale(scale, this);

        public NonUniformTransform3 Translate(float3 translation) => NiMath.Translate(this, translation);
        public Matrix4x4Transform3 Rotate(quaternion rotation) => NiMath.Rotate(this, rotation);
        public NonUniformTransform3 Scale(float scale) => NiMath.Scale(this, scale);
        public NonUniformTransform3 Scale(float3 scale) => NiMath.Scale(this, scale);

        public NonUniformTransform3 Translated(Translation3 translation) => NiMath.Translate(translation, this);
        public NonUniformTransform3 Rotated(Rotation3Q rotation) => NiMath.Rotate(rotation, this);
        public NonUniformTransform3 Scaled(Scale1 scale) => NiMath.Scale(scale, this);
        public Matrix4x4Transform3 Scaled(Scale3 scale) => NiMath.Scale(scale, this);

        public NonUniformTransform3 Translate(Translation3 translation) => NiMath.Translate(this, translation);
        public Matrix4x4Transform3 Rotate(Rotation3Q rotation) => NiMath.Rotate(this, rotation);
        public NonUniformTransform3 Scale(Scale1 scale) => NiMath.Scale(this, scale);
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

        public NonUniformTransform3 Mul(Translation3 primitive) => NiMath.Mul(this, primitive);
        public Matrix4x4Transform3 Mul(Rotation3Q primitive) => NiMath.Mul(this, primitive);
        public NonUniformTransform3 Mul(Scale1 primitive) => NiMath.Mul(this, primitive);
        public NonUniformTransform3 Mul(Scale3 primitive) => NiMath.Mul(this, primitive);
        public Matrix4x4Transform3 Mul(RigidTransform3 primitive) => NiMath.Mul(this, primitive);
        public Matrix4x4Transform3 Mul(UniformTransform3 primitive) => NiMath.Mul(this, primitive);
        public Matrix4x4Transform3 Mul(NonUniformTransform3 primitive) => NiMath.Mul(this, primitive);
        public Matrix4x4Transform3 Mul(Matrix3x3Transform3 primitive) => NiMath.Mul(this, primitive);
        public Matrix4x4Transform3 Mul(Matrix4x4Transform3 primitive) => NiMath.Mul(this, primitive);
        public Obb3T Mul(Aabb3M o) => NiMath.Mul(this, o);
        public Obb3T Mul(Aabb3C o) => NiMath.Mul(this, o);
        public Obb3T Mul(Aabb3S o) => NiMath.Mul(this, o);
        public Obb3M Mul(Obb3T o) => NiMath.Mul(this, o);
        public Obb3M Mul(Obb3M o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Div(Translation3 primitive) => NiMath.Div(this, primitive);
        public Matrix4x4Transform3 Div(Rotation3Q primitive) => NiMath.Div(this, primitive);
        public Matrix4x4Transform3 Div(Scale1 primitive) => NiMath.Div(this, primitive);
        public Matrix4x4Transform3 Div(Scale3 primitive) => NiMath.Div(this, primitive);
        public Matrix4x4Transform3 Div(RigidTransform3 primitive) => NiMath.Div(this, primitive);
        public Matrix4x4Transform3 Div(UniformTransform3 primitive) => NiMath.Div(this, primitive);
        public Matrix4x4Transform3 Div(NonUniformTransform3 primitive) => NiMath.Div(this, primitive);
        public Matrix4x4Transform3 Div(Matrix3x3Transform3 primitive) => NiMath.Div(this, primitive);
        public Matrix4x4Transform3 Div(Matrix4x4Transform3 primitive) => NiMath.Div(this, primitive);
        public Obb3M Div(Aabb3M o) => NiMath.Div(this, o);
        public Obb3M Div(Aabb3C o) => NiMath.Div(this, o);
        public Obb3M Div(Aabb3S o) => NiMath.Div(this, o);
        public Obb3M Div(Obb3T o) => NiMath.Div(this, o);
        public Obb3M Div(Obb3M o) => NiMath.Div(this, o);
    }

    public static partial class NiMath
    {
        public static bool Equal(NonUniformTransform3 a, NonUniformTransform3 b) => Equal(a.translation, b.translation) && Equal(a.rotation, b.rotation) && Equal(a.scale, b.scale);

        public static bool NearEqual(NonUniformTransform3 a, Translation3 b, float margin) => NearEqual(a.translation, b.translation, margin) && NearEqual(a.rotation, quaternion.identity, margin) && NearEqual(a.scale, (float3)1, margin);
        public static bool NearEqual(NonUniformTransform3 a, Rotation3Q b, float margin) => NearEqual(a.translation, float3.zero, margin) && NearEqual(a.rotation, b.rotation, margin) && NearEqual(a.scale, (float3)1, margin);
        public static bool NearEqual(NonUniformTransform3 a, Scale1 b, float margin) => NearEqual(a.translation, float3.zero, margin) && NearEqual(a.rotation, quaternion.identity, margin) && NearEqual(a.scale, (float3)b.scale, margin);
        public static bool NearEqual(NonUniformTransform3 a, Scale3 b, float margin) => NearEqual(a.translation, float3.zero, margin) && NearEqual(a.rotation, quaternion.identity, margin) && NearEqual(a.scale, b.scale, margin);
        public static bool NearEqual(NonUniformTransform3 a, RigidTransform3 b, float margin) => NearEqual(a.translation, b.translation, margin) && NearEqual(a.rotation, b.rotation, margin) && NearEqual(a.scale, float3.zero, margin);
        public static bool NearEqual(NonUniformTransform3 a, UniformTransform3 b, float margin) => NearEqual(a.translation, b.translation, margin) && NearEqual(a.rotation, b.rotation, margin) && NearEqual(a.scale, (float3)b.scale, margin);
        public static bool NearEqual(NonUniformTransform3 a, NonUniformTransform3 b, float margin) => NearEqual(a.translation, b.translation, margin) && NearEqual(a.rotation, b.rotation, margin) && NearEqual(a.scale, b.scale, margin);
        public static bool NearEqual(NonUniformTransform3 a, Matrix3x3Transform3 b, float margin) => NearEqual(a.translation, float3.zero, margin) && NearEqual(new Matrix3x3Transform3(a.rotation, a.scale), b, margin);
        public static bool NearEqual(NonUniformTransform3 a, Matrix4x4Transform3 b, float margin) => NearEqual(a.ToMatrix4x4Transform, b, margin);

        public static Matrix4x4Transform3 Inverse(NonUniformTransform3 a) => math.inverse((Matrix4x4Transform3)a);

        public static float3 RotateVector(NonUniformTransform3 rotation, float3 vector) => RotateVector(rotation.rotation, vector);

        public static NonUniformTransform3 Translate(float3 translation, NonUniformTransform3 o) => new NonUniformTransform3(translation + o.translation, o.rotation, o.scale);
        public static NonUniformTransform3 Rotate(quaternion rotation, NonUniformTransform3 o) => new NonUniformTransform3(math.mul(rotation, o.translation), math.mul(rotation, o.rotation), o.scale);
        public static NonUniformTransform3 Scale(float scale, NonUniformTransform3 o) => new NonUniformTransform3(scale * o.translation, o.rotation, scale * o.scale);
        public static Matrix4x4Transform3 Scale(float3 scale, NonUniformTransform3 o) => math.mul(float4x4.Scale(scale), float4x4.TRS(o.translation, o.rotation, o.scale));
        public static NonUniformTransform3 Translate(NonUniformTransform3 o, float3 translation) => new NonUniformTransform3(o.translation + math.mul(o.rotation, translation * o.scale), o.rotation, o.scale);
        public static Matrix4x4Transform3 Rotate(NonUniformTransform3 o, quaternion rotation) => math.mul((Matrix4x4Transform3)o, new float4x4(rotation, float3.zero));
        public static NonUniformTransform3 Scale(NonUniformTransform3 o, float scale) => new NonUniformTransform3(o.translation, o.rotation, o.scale * scale);
        public static NonUniformTransform3 Scale(NonUniformTransform3 o, float3 scale) => new NonUniformTransform3(o.translation, o.rotation, o.scale * scale);
        public static NonUniformTransform3 Translate(Translation3 translation, NonUniformTransform3 o) => new NonUniformTransform3(translation.translation + o.translation, o.rotation, o.scale);
        public static NonUniformTransform3 Rotate(Rotation3Q rotation, NonUniformTransform3 o) => new NonUniformTransform3(math.mul(rotation, o.translation), math.mul(rotation, o.rotation), o.scale);
        public static NonUniformTransform3 Scale(Scale1 scale, NonUniformTransform3 o) => new NonUniformTransform3(scale.scale * o.translation, o.rotation, scale.scale * o.scale);
        public static Matrix4x4Transform3 Scale(Scale3 scale, NonUniformTransform3 o) => math.mul(float4x4.Scale(scale.scale), float4x4.TRS(o.translation, o.rotation, o.scale));
        public static NonUniformTransform3 Translate(NonUniformTransform3 o, Translation3 translation) => Translate(o, translation.translation);
        public static Matrix4x4Transform3 Rotate(NonUniformTransform3 o, Rotation3Q rotation) => Rotate(o, rotation.rotation);
        public static NonUniformTransform3 Scale(NonUniformTransform3 o, Scale1 scale) => Scale(o, scale.scale);
        public static NonUniformTransform3 Scale(NonUniformTransform3 o, Scale3 scale) => Scale(o, scale.scale);

        public static float3 Transform(NonUniformTransform3 a, float3 b) => Translate(a.translation, Rotate(a.rotation, Scale(a.scale, b)));
        public static Direction3 Transform(NonUniformTransform3 a, Direction3 b) => Direction3.Direction(Rotate(a.rotation, Scale(a.scale, b.vector)));
        public static ProjectionAxis3x1 Transform(NonUniformTransform3 a, ProjectionAxis3x1 b) => new ProjectionAxis3x1(Rotate(a.rotation, Scale(a.scale, b.axis)));
        public static ProjectionAxis1x3 Transform(NonUniformTransform3 a, ProjectionAxis1x3 b) => new ProjectionAxis1x3(Rotate(a.rotation, Scale(a.scale, b.axis)));
        public static Ray3 Transform(NonUniformTransform3 a, Ray3 b) => new Ray3(Transform(a, b.translation), Transform(a.Rotation3, Transform(a.Scale3, b.projectionAxis)));

        public static float3 Untransform(NonUniformTransform3 a, float3 b) => math.rcp(a.scale) * math.mul(Inverse(a.rotation), -a.translation + b);
        public static Direction3 Untransform(NonUniformTransform3 a, Direction3 b) => Direction3.Direction(math.rcp(a.scale) * Rotate(Inverse(a.rotation), b.vector));
        public static ProjectionAxis3x1 Untransform(NonUniformTransform3 a, ProjectionAxis3x1 b) => Transform(Inverse(a), b);
        public static ProjectionAxis1x3 Untransform(NonUniformTransform3 a, ProjectionAxis1x3 b) => Transform(Inverse(a), b);
        public static Ray3 Untransform(NonUniformTransform3 a, Ray3 b) => Transform(Inverse(a), b);

        public static NonUniformTransform3 Mul(NonUniformTransform3 a, Translation3 b) => Translate(a.translation, Rotate(a.rotation, Scale(a.scale, b)));
        public static Matrix4x4Transform3 Mul(NonUniformTransform3 a, Rotation3Q b) => Translate(a.translation, Rotate(a.rotation, Scale(a.scale, b)));
        public static NonUniformTransform3 Mul(NonUniformTransform3 a, Scale1 b) => Translate(a.translation, Rotate(a.rotation, Scale(a.scale, b)));
        public static NonUniformTransform3 Mul(NonUniformTransform3 a, Scale3 b) => Translate(a.translation, Rotate(a.rotation, Scale(a.scale, b)));
        public static Matrix4x4Transform3 Mul(NonUniformTransform3 a, RigidTransform3 b) => Translate(a.translation, Rotate(a.rotation, Scale(a.scale, b)));
        public static Matrix4x4Transform3 Mul(NonUniformTransform3 a, UniformTransform3 b) => Translate(a.translation, Rotate(a.rotation, Scale(a.scale, b)));
        public static Matrix4x4Transform3 Mul(NonUniformTransform3 a, NonUniformTransform3 b) => Translate(a.translation, Rotate(a.rotation, Scale(a.scale, b)));
        public static Matrix4x4Transform3 Mul(NonUniformTransform3 a, Matrix3x3Transform3 b) => Translate(a.translation, Rotate(a.rotation, Scale(a.scale, b)));
        public static Matrix4x4Transform3 Mul(NonUniformTransform3 a, Matrix4x4Transform3 b) => Translate(a.translation, Rotate(a.rotation, Scale(a.scale, b)));
        public static Obb3T Mul(NonUniformTransform3 a, Aabb3M b) => new NonUniformTransform3(Transform(a, b.translation3), a.rotation, a.scale * b.scale3); // Ta * Ra * S3a * Tb * S3b 
        public static Obb3T Mul(NonUniformTransform3 a, Aabb3C b) => new NonUniformTransform3(Transform(a, b.translation3), a.rotation, a.scale * b.scale3);
        public static Obb3T Mul(NonUniformTransform3 a, Aabb3S b) => new NonUniformTransform3(Transform(a, b.translation3), a.rotation, a.scale * b.scale3);
        public static Obb3M Mul(NonUniformTransform3 a, Obb3T b) => Mul(a, b.ToMatrix4x4Transform);
        public static Obb3M Mul(NonUniformTransform3 a, Obb3M b) => Mul(a, b.ToMatrix4x4Transform);

        public static Matrix4x4Transform3 Div(NonUniformTransform3 a, Translation3 b) => Scale(Inverse(a.Scale3).scale, Rotate(Inverse(a.rotation), Translate(-a.translation, b)));

        public static Matrix4x4Transform3 Div(NonUniformTransform3 a, Rotation3Q b)
        {
            // Scale(Inverse(a.ScaleNonUniformTransform).NonUniformScale, Rotate(Inverse(a.Rotation), Translate(-a.Translation, b)));
            var ri = Inverse(a.rotation);
            var si = Inverse(a.Scale3).scale;
            var sib = math.mul(float3x3.Scale(si), new float3x3(b.rotation));
            var risib = math.mul(new float3x3(ri), sib);
            return new float4x4(risib, Rotate(ri, si * -a.translation));
        }

        public static Matrix4x4Transform3 Div(NonUniformTransform3 a, Scale1 b)
        {
            // Scale(Inverse(a.ScaleNonUniformTransform).NonUniformScale, Rotate(Inverse(a.Rotation), Translate(-a.Translation, b)));
            var ri = Inverse(a.rotation);
            return Scale(Inverse(a.Scale3).scale, new NonUniformTransform3(Rotate(ri, -a.translation), ri, b.scale));
        }

        public static Matrix4x4Transform3 Div(NonUniformTransform3 a, Scale3 b)
        {
            // Scale(Inverse(a.ScaleNonUniformTransform).NonUniformScale, Rotate(Inverse(a.Rotation), Translate(-a.Translation, b)));
            var ri = Inverse(a.rotation);
            return Scale(Inverse(a.Scale3).scale, new NonUniformTransform3(Rotate(ri, -a.translation), ri, b.scale));
        }

        public static Matrix4x4Transform3 Div(NonUniformTransform3 a, RigidTransform3 b) => Scale(Inverse(a.Scale3).scale, Rotate(Inverse(a.rotation), Translate(-a.translation, b)));
        public static Matrix4x4Transform3 Div(NonUniformTransform3 a, UniformTransform3 b) => Scale(Inverse(a.Scale3).scale, Rotate(Inverse(a.rotation), Translate(-a.translation, b)));
        public static Matrix4x4Transform3 Div(NonUniformTransform3 a, NonUniformTransform3 b) => Scale(Inverse(a.Scale3).scale, Rotate(Inverse(a.rotation), Translate(-a.translation, b)));
        public static Matrix4x4Transform3 Div(NonUniformTransform3 a, Matrix3x3Transform3 b) => Scale(Inverse(a.Scale3).scale, Rotate(Inverse(a.rotation), Translate(-a.translation, b)));
        public static Matrix4x4Transform3 Div(NonUniformTransform3 a, Matrix4x4Transform3 b) => Scale(Inverse(a.Scale3).scale, Rotate(Inverse(a.rotation), Translate(-a.translation, b)));
        public static Obb3M Div(NonUniformTransform3 a, Aabb3M b) => Mul(Inverse(a), b);
        public static Obb3M Div(NonUniformTransform3 a, Aabb3C b) => Mul(Inverse(a), b);
        public static Obb3M Div(NonUniformTransform3 a, Aabb3S b) => Mul(Inverse(a), b);
        public static Obb3M Div(NonUniformTransform3 a, Obb3T b) => Mul(Inverse(a), b);
        public static Obb3M Div(NonUniformTransform3 a, Obb3M b) => Mul(Inverse(a), b);
    }
}