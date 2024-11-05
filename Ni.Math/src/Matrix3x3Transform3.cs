using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    /// <summary>
    /// Represent the sequence of transformations: Rotation * Shear * NonUniformScale
    /// </summary>
    [Serializable]
    public struct Matrix3x3Transform3 : ITransform3, IRotation3QRW, INonUniformScale3RW,
        IEquatable<Matrix3x3Transform3>,
        ITransformable3<Matrix3x3Transform3, Matrix4x4Transform3, Matrix3x3Transform3, Matrix3x3Transform3, Matrix3x3Transform3>,
        IToMatrix3x3Transform,
        IInvertible<Matrix3x3Transform3>,
        ITransform<float3>,
        ITransform<Ray3>,
        IMultipliable<Translation3, Matrix4x4Transform3>,
        IMultipliable<Rotation3Q, Matrix3x3Transform3>,
        IMultipliable<Scale1, Matrix3x3Transform3>,
        IMultipliable<Scale3, Matrix3x3Transform3>,
        IMultipliable<RigidTransform3, Matrix4x4Transform3>,
        IMultipliable<UniformTransform3, Matrix4x4Transform3>,
        IMultipliable<NonUniformTransform3, Matrix4x4Transform3>,
        IMultipliable<Matrix3x3Transform3>,
        IMultipliable<Matrix4x4Transform3>,
        IMultipliable<Aabb3M, Obb3M>,
        IMultipliable<Aabb3C, Obb3M>,
        IMultipliable<Aabb3S, Obb3M>,
        IMultipliable<Obb3T, Obb3M>,
        IMultipliable<Obb3M>,
        IDividable<Translation3, Matrix4x4Transform3>,
        IDividable<Rotation3Q, Matrix3x3Transform3>,
        IDividable<Scale1, Matrix3x3Transform3>,
        IDividable<Scale3, Matrix3x3Transform3>,
        IDividable<RigidTransform3, Matrix4x4Transform3>,
        IDividable<UniformTransform3, Matrix4x4Transform3>,
        IDividable<NonUniformTransform3, Matrix4x4Transform3>,
        IDividable<Matrix3x3Transform3>,
        IDividable<Matrix4x4Transform3>,
        IDividable<Aabb3M, Obb3M>,
        IDividable<Aabb3C, Obb3M>,
        IDividable<Aabb3S, Obb3M>,
        IDividable<Obb3T, Obb3M>,
        IDividable<Obb3M>
    {
        public float3x3 matrix;

        public Matrix3x3Transform3(float3x3 matrix) => this.matrix = matrix;
        public Matrix3x3Transform3(float3 c0, float3 c1, float3 c2) => matrix = new float3x3(c0, c1, c2);
        public Matrix3x3Transform3(quaternion rotation) => matrix = new float3x3(rotation);
        public Matrix3x3Transform3(float scale) => matrix = float3x3.Scale(scale);
        public Matrix3x3Transform3(float3 scale) => matrix = float3x3.Scale(scale);
        public Matrix3x3Transform3(quaternion rotation, float scale) => matrix = math.mul(new float3x3(rotation), float3x3.Scale(scale));
        public Matrix3x3Transform3(quaternion rotation, float3 scale) => matrix = math.mul(new float3x3(rotation), float3x3.Scale(scale));
        public Matrix3x3Transform3(Rotation3Q rotation, Scale1 scale) => matrix = math.mul(new float3x3(rotation), float3x3.Scale(scale.scale));
        public Matrix3x3Transform3(Rotation3Q rotation, Scale3 scale) => matrix = math.mul(new float3x3(rotation), float3x3.Scale(scale.scale));
        public Matrix3x3Transform3(Rotation3Q rotation) => matrix = new float3x3(rotation);
        public Matrix3x3Transform3(Scale1 scale) => matrix = float3x3.Scale(scale.scale);
        public Matrix3x3Transform3(Scale3 scale) => matrix = float3x3.Scale(scale.scale);


        public static implicit operator float3x3(Matrix3x3Transform3 o) => o.matrix;
        public static implicit operator Matrix3x3Transform3(float3x3 o) => new Matrix3x3Transform3(o);

        public static explicit operator Matrix3x3Transform3(Rotation3Q o) => new Matrix3x3Transform3(o.rotation, 1);
        public static explicit operator Matrix3x3Transform3(Rotation3Euler o) => new Matrix3x3Transform3(o.rotation3, 1);

        public static readonly Matrix3x3Transform3 Identity = new Matrix3x3Transform3(float3x3.identity);

        public static Matrix3x3Transform3 Rotating(quaternion rotation) => new Matrix3x3Transform3(new float3x3(rotation));
        public static Matrix3x3Transform3 Scaling(float scale) => new Matrix3x3Transform3(float3x3.Scale(scale));
        public static Matrix3x3Transform3 Scaling(float3 scale) => new Matrix3x3Transform3(float3x3.Scale(scale));
        public static Matrix3x3Transform3 RS(quaternion rotation, float3 scale) => new Matrix3x3Transform3(rotation, scale);

        public quaternion rotation3
        {
            get => new quaternion(matrix);
            set => matrix = math.mul(new float3x3(value), float3x3.Scale(scale3));
        }

        public float3 scale3
        {
            get => new float3(math.length(matrix.c0.xyz), math.length(matrix.c1.xyz), math.length(matrix.c2.xyz));
            set => matrix = new float3x3(
                value.x * math.length(matrix.c0.xyz) * matrix.c0.xyz,
                value.y * math.length(matrix.c1.xyz) * matrix.c1.xyz,
                value.z * math.length(matrix.c2.xyz) * matrix.c2.xyz);
        }

        public float3 Column0 => matrix.c0;
        public float3 Column1 => matrix.c1;
        public float3 Column2 => matrix.c2;

        public Rotation3Q Rotation3 { get => new Rotation3Q(rotation3); set => rotation3 = value.rotation; }
        public Scale3 Scale3 { get => new Scale3(scale3); set => scale3 = value.scale; }
        public float3 this[float3 o] => Transform(o);

        public override string ToString() => $"{nameof(Matrix3x3Transform3)}({matrix.c0.x}, {matrix.c1.x}, {matrix.c2.x}, {matrix.c0.y}, {matrix.c1.y}, {matrix.c2.y}, {matrix.c0.z}, {matrix.c1.z}, {matrix.c2.z})";
        
        public bool Equals(Matrix3x3Transform3 other) => NiMath.Equal(this, other);
        
        public bool NearEquals(Translation3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Rotation3Q other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Scale1 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Scale3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(RigidTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(UniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(NonUniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Matrix3x3Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Matrix4x4Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);

        public Matrix3x3Transform3 ToMatrix3x3Transform => new float3x3(matrix);
        public Matrix4x4Transform3 ToMatrix4x4Transform => new float4x4(matrix, float3.zero);
        public Matrix3x3Transform3 Inversed => NiMath.Inverse(this);

        public Matrix4x4Transform3 Translated(float3 translation) => NiMath.Translate(translation, this);
        public Matrix3x3Transform3 Rotated(quaternion rotation) => NiMath.Rotate(rotation, this);
        public Matrix3x3Transform3 Scaled(float scale) => NiMath.Scale(scale, this);
        public Matrix3x3Transform3 Scaled(float3 scale) => NiMath.Scale(scale, this);

        public Matrix4x4Transform3 Translate(float3 translation) => NiMath.Translate(this, translation);
        public Matrix3x3Transform3 Rotate(quaternion rotation) => NiMath.Rotate(this, rotation);
        public Matrix3x3Transform3 Scale(float scale) => NiMath.Scale(this, scale);
        public Matrix3x3Transform3 Scale(float3 scale) => NiMath.Scale(this, scale);

        public Matrix4x4Transform3 Translated(Translation3 translation) => NiMath.Translate(translation, this);
        public Matrix3x3Transform3 Rotated(Rotation3Q rotation) => NiMath.Rotate(rotation, this);
        public Matrix3x3Transform3 Scaled(Scale1 scale) => NiMath.Scale(scale, this);
        public Matrix3x3Transform3 Scaled(Scale3 scale) => NiMath.Scale(scale, this);

        public Matrix4x4Transform3 Translate(Translation3 translation) => NiMath.Translate(this, translation);
        public Matrix3x3Transform3 Rotate(Rotation3Q rotation) => NiMath.Rotate(this, rotation);
        public Matrix3x3Transform3 Scale(Scale1 scale) => NiMath.Scale(this, scale);
        public Matrix3x3Transform3 Scale(Scale3 scale) => NiMath.Scale(this, scale);

        public float3 Transform(float3 o) => NiMath.Transform(this, o);
        public Ray3 Transform(Ray3 o) => NiMath.Transform(this, o);
        public float3 Untransform(float3 o) => NiMath.Untransform(this, o);
        public Ray3 Untransform(Ray3 o) => NiMath.Untransform(this, o);

        public Matrix4x4Transform3 Mul(Translation3 primitive) => NiMath.Mul(this, primitive);
        public Matrix3x3Transform3 Mul(Rotation3Q primitive) => NiMath.Mul(this, primitive);
        public Matrix3x3Transform3 Mul(Scale1 primitive) => NiMath.Mul(this, primitive);
        public Matrix3x3Transform3 Mul(Scale3 primitive) => NiMath.Mul(this, primitive);
        public Matrix4x4Transform3 Mul(RigidTransform3 primitive) => NiMath.Mul(this, primitive);
        public Matrix4x4Transform3 Mul(UniformTransform3 primitive) => NiMath.Mul(this, primitive);
        public Matrix4x4Transform3 Mul(NonUniformTransform3 primitive) => NiMath.Mul(this, primitive);
        public Matrix3x3Transform3 Mul(Matrix3x3Transform3 primitive) => NiMath.Mul(this, primitive);
        public Matrix4x4Transform3 Mul(Matrix4x4Transform3 primitive) => NiMath.Mul(this, primitive);
        public Obb3M Mul(Aabb3M o) => NiMath.Mul(this, o);
        public Obb3M Mul(Aabb3C o) => NiMath.Mul(this, o);
        public Obb3M Mul(Aabb3S o) => NiMath.Mul(this, o);
        public Obb3M Mul(Obb3T o) => NiMath.Mul(this, o);
        public Obb3M Mul(Obb3M o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Div(Translation3 primitive) => NiMath.Div(this, primitive);
        public Matrix3x3Transform3 Div(Rotation3Q primitive) => NiMath.Div(this, primitive);
        public Matrix3x3Transform3 Div(Scale1 primitive) => NiMath.Div(this, primitive);
        public Matrix3x3Transform3 Div(Scale3 primitive) => NiMath.Div(this, primitive);
        public Matrix4x4Transform3 Div(RigidTransform3 primitive) => NiMath.Div(this, primitive);
        public Matrix4x4Transform3 Div(UniformTransform3 primitive) => NiMath.Div(this, primitive);
        public Matrix4x4Transform3 Div(NonUniformTransform3 primitive) => NiMath.Div(this, primitive);
        public Matrix3x3Transform3 Div(Matrix3x3Transform3 primitive) => NiMath.Div(this, primitive);
        public Matrix4x4Transform3 Div(Matrix4x4Transform3 primitive) => NiMath.Div(this, primitive);
        public Obb3M Div(Aabb3M o) => NiMath.Div(this, o);
        public Obb3M Div(Aabb3C o) => NiMath.Div(this, o);
        public Obb3M Div(Aabb3S o) => NiMath.Div(this, o);
        public Obb3M Div(Obb3T o) => NiMath.Div(this, o);
        public Obb3M Div(Obb3M o) => NiMath.Div(this, o);
    }

    public static partial class NiMath
    {
        public static bool Equal(Matrix3x3Transform3 a, Matrix3x3Transform3 b) => Equal(a.matrix, b.matrix);

        public static bool NearEqual(Matrix3x3Transform3 a, Translation3 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform, margin);
        public static bool NearEqual(Matrix3x3Transform3 a, Rotation3Q b, float margin) => NearEqual(a, b.ToMatrix4x4Transform, margin);
        public static bool NearEqual(Matrix3x3Transform3 a, Scale1 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform, margin);
        public static bool NearEqual(Matrix3x3Transform3 a, Scale3 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform, margin);
        public static bool NearEqual(Matrix3x3Transform3 a, RigidTransform3 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform, margin);
        public static bool NearEqual(Matrix3x3Transform3 a, UniformTransform3 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform, margin);
        public static bool NearEqual(Matrix3x3Transform3 a, NonUniformTransform3 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform, margin);
        public static bool NearEqual(Matrix3x3Transform3 a, Matrix3x3Transform3 b, float margin) => NearEqual(a.matrix, b.matrix, margin);
        public static bool NearEqual(Matrix3x3Transform3 a, Matrix4x4Transform3 b, float margin) => NearEqual(a.matrix, b.matrix, margin);

        public static Matrix3x3Transform3 Inverse(Matrix3x3Transform3 a) => math.inverse(a.matrix);

        public static float3 RotateVector(Matrix3x3Transform3 rotation, float3 vector) => math.mul(rotation, vector);

        public static Matrix4x4Transform3 Translate(float3 translation, Matrix3x3Transform3 o) => new float4x4(o, translation);
        public static Matrix3x3Transform3 Rotate(quaternion rotation, Matrix3x3Transform3 b) => new Matrix3x3Transform3(math.mul(new float3x3(rotation), b.matrix));
        public static Matrix3x3Transform3 Scale(float scale, Matrix3x3Transform3 b) => new Matrix3x3Transform3(math.mul(float3x3.Scale(scale), b.matrix));
        public static Matrix3x3Transform3 Scale(float3 scale, Matrix3x3Transform3 b) => new Matrix3x3Transform3(math.mul(float3x3.Scale(scale), b.matrix));
        public static Matrix4x4Transform3 Translate(Matrix3x3Transform3 o, float3 translation) => new float4x4(o, math.mul(o, translation));
        public static Matrix3x3Transform3 Rotate(Matrix3x3Transform3 o, quaternion rotation) => math.mul(o, new float3x3(rotation));
        public static Matrix3x3Transform3 Scale(Matrix3x3Transform3 o, float scale) => new Matrix3x3Transform3(scale * o.Column0, scale * o.Column1, scale * o.Column2);
        public static Matrix3x3Transform3 Scale(Matrix3x3Transform3 o, float3 scale) => new Matrix3x3Transform3(scale.x * o.Column0, scale.y * o.Column1, scale.z * o.Column2);

        public static Matrix4x4Transform3 Translate(Translation3 translation, Matrix3x3Transform3 o) => new float4x4(o, translation.translation);
        public static Matrix3x3Transform3 Rotate(Rotation3Q rotation, Matrix3x3Transform3 b) => new Matrix3x3Transform3(math.mul(new float3x3(rotation), b.matrix));
        public static Matrix3x3Transform3 Scale(Scale1 scale, Matrix3x3Transform3 b) => new Matrix3x3Transform3(math.mul(float3x3.Scale(scale.scale), b.matrix));
        public static Matrix3x3Transform3 Scale(Scale3 scale, Matrix3x3Transform3 b) => new Matrix3x3Transform3(math.mul(float3x3.Scale(scale.scale), b.matrix));

        public static Matrix4x4Transform3 Translate(Matrix3x3Transform3 o, Translation3 translation) => Translate(o, translation.translation);
        public static Matrix3x3Transform3 Rotate(Matrix3x3Transform3 o, Rotation3Q rotation) => Rotate(o, rotation.rotation);
        public static Matrix3x3Transform3 Scale(Matrix3x3Transform3 o, Scale1 scale) => Scale(o, scale.scale);
        public static Matrix3x3Transform3 Scale(Matrix3x3Transform3 o, Scale3 scale) => Scale(o, scale.scale);

        public static float3 Transform(Matrix3x3Transform3 a, float3 b) => math.mul(a, b);
        public static Ray3 Transform(Matrix3x3Transform3 a, Ray3 b) => new Ray3(Transform(a, b.translation), RotateVector(a, b.projectionAxis));

        public static float3 Untransform(Matrix3x3Transform3 a, float3 b) => math.mul(Inverse(a), b);
        public static Ray3 Untransform(Matrix3x3Transform3 a, Ray3 b) => Transform(Inverse(a), b);

        public static Matrix4x4Transform3 Mul(Matrix3x3Transform3 a, Translation3 b) => Translate(a, b);
        public static Matrix3x3Transform3 Mul(Matrix3x3Transform3 a, Rotation3Q b) => Rotate(a, b);
        public static Matrix3x3Transform3 Mul(Matrix3x3Transform3 a, Scale1 b) => Scale(a, b);
        public static Matrix3x3Transform3 Mul(Matrix3x3Transform3 a, Scale3 b) => Scale(a, b);
        public static Matrix4x4Transform3 Mul(Matrix3x3Transform3 a, RigidTransform3 b) => math.mul(a.ToMatrix4x4Transform, b.ToMatrix4x4Transform);
        public static Matrix4x4Transform3 Mul(Matrix3x3Transform3 a, UniformTransform3 b) => math.mul(a.ToMatrix4x4Transform, b.ToMatrix4x4Transform);
        public static Matrix4x4Transform3 Mul(Matrix3x3Transform3 a, NonUniformTransform3 b) => math.mul(a.ToMatrix4x4Transform, b.ToMatrix4x4Transform);
        public static Matrix3x3Transform3 Mul(Matrix3x3Transform3 a, Matrix3x3Transform3 b) => math.mul(a, b);
        public static Matrix4x4Transform3 Mul(Matrix3x3Transform3 a, Matrix4x4Transform3 b) => math.mul(a.ToMatrix4x4Transform, b);
        public static Obb3M Mul(Matrix3x3Transform3 a, Aabb3M b) => Mul(a, b.ToMatrix4x4Transform);
        public static Obb3M Mul(Matrix3x3Transform3 a, Aabb3C b) => Mul(a, b.ToMatrix4x4Transform);
        public static Obb3M Mul(Matrix3x3Transform3 a, Aabb3S b) => Mul(a, b.ToMatrix4x4Transform);
        public static Obb3M Mul(Matrix3x3Transform3 a, Obb3T b) => Mul(a, b.ToMatrix4x4Transform);
        public static Obb3M Mul(Matrix3x3Transform3 a, Obb3M b) => Mul(a, b.ToMatrix4x4Transform);
        public static Matrix4x4Transform3 Div(Matrix3x3Transform3 a, Translation3 b) => Translate(Inverse(a), b);
        public static Matrix3x3Transform3 Div(Matrix3x3Transform3 a, Rotation3Q b) => Rotate(Inverse(a), b);
        public static Matrix3x3Transform3 Div(Matrix3x3Transform3 a, Scale1 b) => Scale(Inverse(a), b);
        public static Matrix3x3Transform3 Div(Matrix3x3Transform3 a, Scale3 b) => Scale(Inverse(a), b);
        public static Matrix4x4Transform3 Div(Matrix3x3Transform3 a, RigidTransform3 b) => math.mul(Inverse(a).ToMatrix4x4Transform, b.ToMatrix4x4Transform);
        public static Matrix4x4Transform3 Div(Matrix3x3Transform3 a, UniformTransform3 b) => math.mul(Inverse(a).ToMatrix4x4Transform, b.ToMatrix4x4Transform);
        public static Matrix4x4Transform3 Div(Matrix3x3Transform3 a, NonUniformTransform3 b) => math.mul(Inverse(a).ToMatrix4x4Transform, b.ToMatrix4x4Transform);
        public static Matrix3x3Transform3 Div(Matrix3x3Transform3 a, Matrix3x3Transform3 b) => math.mul(Inverse(a), b);
        public static Matrix4x4Transform3 Div(Matrix3x3Transform3 a, Matrix4x4Transform3 b) => math.mul(Inverse(a).ToMatrix4x4Transform, b);
        public static Obb3M Div(Matrix3x3Transform3 a, Aabb3M b) => Mul(Inverse(a), b);
        public static Obb3M Div(Matrix3x3Transform3 a, Aabb3C b) => Mul(Inverse(a), b);
        public static Obb3M Div(Matrix3x3Transform3 a, Aabb3S b) => Mul(Inverse(a), b);
        public static Obb3M Div(Matrix3x3Transform3 a, Obb3T b) => Mul(Inverse(a), b);
        public static Obb3M Div(Matrix3x3Transform3 a, Obb3M b) => Mul(Inverse(a), b);
    }
}