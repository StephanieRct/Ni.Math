using System;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine.UIElements;

namespace Ni.Mathematics
{
    /// <summary>
    /// Represent the sequence of transformations: Translation * Rotation * Shear * NonUniformScale
    /// </summary>
    [Serializable]
    public struct Matrix4x4Transform3 : ITransform3, ITranslation3RW, IRotation3QRW, INonUniformScale3RW,
        ITransformable3<Translation3, Matrix4x4Transform3, Matrix4x4Transform3, Matrix4x4Transform3, Matrix4x4Transform3>,
        IEquatable<Matrix4x4Transform3>,
        IInvertible<Matrix4x4Transform3>,
        ITransform<float3>,
        ITransform<Ray3>,
        IMultipliable<Translation3, Matrix4x4Transform3>,
        IMultipliable<Rotation3Q, Matrix4x4Transform3>,
        IMultipliable<Scale1, Matrix4x4Transform3>,
        IMultipliable<Scale3, Matrix4x4Transform3>,
        IMultipliable<RigidTransform3, Matrix4x4Transform3>,
        IMultipliable<UniformTransform3, Matrix4x4Transform3>,
        IMultipliable<NonUniformTransform3, Matrix4x4Transform3>,
        IMultipliable<Matrix3x3Transform3, Matrix4x4Transform3>,
        IMultipliable<Matrix4x4Transform3>,
        IMultipliable<Aabb3M, Obb3M>,
        IMultipliable<Aabb3C, Obb3M>,
        IMultipliable<Aabb3S, Obb3M>,
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
        IDividable<Obb3M>
    {
        public float4x4 matrix;

        public Matrix4x4Transform3(float4x4 matrix) => this.matrix = matrix;
        public Matrix4x4Transform3(float4 column0, float4 column1, float4 column2, float4 column3) => matrix = new float4x4(column0, column1, column2, column3);
        public Matrix4x4Transform3(float3 translation, float3x3 rotationScale) => matrix = new float4x4(rotationScale, translation);
        public Matrix4x4Transform3(float3 translation, quaternion rotation, float scale) => matrix = float4x4.TRS(translation, rotation, scale);
        public Matrix4x4Transform3(float3 translation, quaternion rotation, float3 scale) => matrix = float4x4.TRS(translation, rotation, scale);
        public Matrix4x4Transform3(float3 translation, quaternion rotation) => matrix = new float4x4(rotation, translation);
        public Matrix4x4Transform3(float3 translation, float scale) => matrix = float4x4.TRS(translation, quaternion.identity, scale);
        public Matrix4x4Transform3(float3 translation, float3 scale) => matrix = float4x4.TRS(translation, quaternion.identity, scale);
        public Matrix4x4Transform3(quaternion rotation, float scale) => matrix = float4x4.TRS(0, rotation, scale);
        public Matrix4x4Transform3(quaternion rotation, float3 scale) => matrix = float4x4.TRS(0, rotation, scale);
        public Matrix4x4Transform3(quaternion rotation) => matrix = new float4x4(rotation, float3.zero);
        public Matrix4x4Transform3(Translation3 translation, Matrix3x3Transform3 rotationScale) => matrix = new float4x4(rotationScale, translation.translation);
        public Matrix4x4Transform3(Translation3 translation, Rotation3Q rotation, Scale1 scale) => matrix = float4x4.TRS(translation.translation, rotation, scale.scale);
        public Matrix4x4Transform3(Translation3 translation, Rotation3Q rotation, Scale3 scale) => matrix = float4x4.TRS(translation.translation, rotation, scale.scale);
        public Matrix4x4Transform3(Translation3 translation, Rotation3Q rotation) => matrix = new float4x4(rotation, translation.translation);
        public Matrix4x4Transform3(Translation3 translation, Scale1 scale) => matrix = float4x4.TRS(translation.translation, quaternion.identity, scale.scale);
        public Matrix4x4Transform3(Translation3 translation, Scale3 scale) => matrix = float4x4.TRS(translation.translation, quaternion.identity, scale.scale);
        public Matrix4x4Transform3(Rotation3Q rotation, Scale1 scale) => matrix = float4x4.TRS(0, rotation, scale.scale);
        public Matrix4x4Transform3(Rotation3Q rotation, Scale3 scale) => matrix = float4x4.TRS(0, rotation, scale.scale);
        public Matrix4x4Transform3(Translation3 translation) => matrix = float4x4.Translate(translation.translation);
        public Matrix4x4Transform3(Rotation3Q rotation) => matrix = new float4x4(rotation, float3.zero);
        public Matrix4x4Transform3(Scale1 scale) => matrix = float4x4.Scale(scale.scale);
        public Matrix4x4Transform3(Scale3 scale) => matrix = float4x4.Scale(scale.scale);

        public static implicit operator float4x4(Matrix4x4Transform3 o) => o.matrix;
        public static implicit operator Matrix4x4Transform3(float4x4 o) => new Matrix4x4Transform3(o);

        public static explicit operator Matrix4x4Transform3(Matrix3x3Transform3 o) => new float4x4(o, float3.zero);
        public static explicit operator Matrix4x4Transform3(NonUniformTransform3 o) => new Matrix4x4Transform3(o.translation, o.rotation, o.scale);
        public static explicit operator Matrix4x4Transform3(UniformTransform3 o) => new Matrix4x4Transform3(o.translation, o.rotation, o.scale);
        public static explicit operator Matrix4x4Transform3(RigidTransform3 o) => new Matrix4x4Transform3(o.translation, o.rotation, 1);
        public static explicit operator Matrix4x4Transform3(Translation3 o) => new Matrix4x4Transform3(o.translation, quaternion.identity, 1);
        public static explicit operator Matrix4x4Transform3(Rotation3Q o) => new Matrix4x4Transform3(float3.zero, o.rotation, 1);
        public static explicit operator Matrix4x4Transform3(Rotation3Euler o) => new Matrix4x4Transform3(float3.zero, o.rotation3, 1);

        public static readonly Matrix4x4Transform3 Identity = new Matrix4x4Transform3(float4x4.identity);
        public static Matrix4x4Transform3 Translating(float3 translation) => new Matrix4x4Transform3(float4x4.Translate(translation));
        public static Matrix4x4Transform3 Rotating(quaternion rotation) => new Matrix4x4Transform3(new float4x4(new float3x3(rotation), float3.zero));
        public static Matrix4x4Transform3 Scaling(float scale) => new Matrix4x4Transform3(float4x4.Scale(scale));
        public static Matrix4x4Transform3 Scaling(float3 scale) => new Matrix4x4Transform3(float4x4.Scale(scale));
        public static Matrix4x4Transform3 TRS(float3 translation, quaternion rotation, float3 scale) => new Matrix4x4Transform3(float4x4.TRS(translation, rotation, scale));

        public quaternion rotation3
        {
            get => new quaternion(matrix);
            set => matrix = float4x4.TRS(translation3, value, scale3);
        }

        public float3 translation3
        {
            get => matrix.c3.xyz;
            set => matrix.c3 = new float4(value, matrix.c3.w);
        }

        public float3 scale3
        {
            get => new float3(math.length(matrix.c0.xyz), math.length(matrix.c1.xyz), math.length(matrix.c2.xyz));
            set => matrix = new float4x4(
                new float4(value.x * math.length(matrix.c0.xyz) * matrix.c0.xyz, matrix.c0.w),
                new float4(value.y * math.length(matrix.c1.xyz) * matrix.c1.xyz, matrix.c1.w),
                new float4(value.z * math.length(matrix.c2.xyz) * matrix.c2.xyz, matrix.c2.w),
                matrix.c3);
        }

        public float4 Column0 => matrix.c0;
        public float4 Column1 => matrix.c1;
        public float4 Column2 => matrix.c2;
        public float4 Column3 => matrix.c3;

        public Aabb3M TranslationScale
        {
            get => new Aabb3M(translation3, scale3);

            set
            {
                translation3 = value.translation3;
                scale3 = value.scale3;
            }
        }

        public RigidTransform3 TranslationRotation 
        { 
            get => new RigidTransform3(translation3, rotation3); 
            set
            {
                translation3 = value.translation;
                rotation3 = value.rotation;
            }
        }

        public Matrix3x3Transform3 RotationScale
        {
            get => new Matrix3x3Transform3(matrix.c0.xyz, matrix.c1.xyz, matrix.c2.xyz);
            set
            {
                matrix.c0.xyz = value.matrix.c0;
                matrix.c1.xyz = value.matrix.c1;
                matrix.c2.xyz = value.matrix.c2;
            }
        }
        public float3 this[float3 o] => Transform(o);

        public Translation3 Translation3 { get => new Translation3(translation3); set => translation3 = value.translation; }
        public Rotation3Q Rotation3 { get => new Rotation3Q(rotation3); set => rotation3 = value.rotation; }
        public Scale3 Scale3 { get => new Scale3(scale3); set => scale3 = value.scale; }


        public override string ToString() => $"{nameof(Matrix4x4Transform3)}({matrix.c0.x}, {matrix.c1.x}, {matrix.c2.x}, {matrix.c3.x}, {matrix.c0.y}, {matrix.c1.y}, {matrix.c2.y}, {matrix.c3.y}, {matrix.c0.z}, {matrix.c1.z}, {matrix.c2.z}, {matrix.c3.z}, {matrix.c0.w}, {matrix.c1.w}, {matrix.c2.w}, {matrix.c3.w})";
        
        public bool Equals(Matrix4x4Transform3 other) => NiMath.Equal(this, other);
        
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
        public Matrix4x4Transform3 ToMatrix4x4Transform => this;

        public Matrix4x4Transform3 Translated(float3 translation) => NiMath.Translate(translation, this);
        public Matrix4x4Transform3 Rotated(quaternion rotation) => NiMath.Rotate(rotation, this);
        public Matrix4x4Transform3 Scaled(float scale) => NiMath.Scale(scale, this);
        public Matrix4x4Transform3 Scaled(float3 scale) => NiMath.Scale(scale, this);

        public Matrix4x4Transform3 Translate(float3 translation) => NiMath.Translate(this, translation);
        public Matrix4x4Transform3 Rotate(quaternion rotation) => NiMath.Rotate(this, rotation);
        public Matrix4x4Transform3 Scale(float scale) => NiMath.Scale(this, scale);
        public Matrix4x4Transform3 Scale(float3 scale) => NiMath.Scale(this, scale);

        public Matrix4x4Transform3 Translated(Translation3 translation) => NiMath.Translate(translation, this);
        public Matrix4x4Transform3 Rotated(Rotation3Q rotation) => NiMath.Rotate(rotation, this);
        public Matrix4x4Transform3 Scaled(Scale1 scale) => NiMath.Scale(scale, this);
        public Matrix4x4Transform3 Scaled(Scale3 scale) => NiMath.Scale(scale, this);

        public Matrix4x4Transform3 Translate(Translation3 translation) => NiMath.Translate(this, translation);
        public Matrix4x4Transform3 Rotate(Rotation3Q rotation) => NiMath.Rotate(this, rotation);
        public Matrix4x4Transform3 Scale(Scale1 scale) => NiMath.Scale(this, scale);
        public Matrix4x4Transform3 Scale(Scale3 scale) => NiMath.Scale(this, scale);

        public float3 Transform(float3 o) => NiMath.Transform(this, o);
        public Ray3 Transform(Ray3 o) => NiMath.Transform(this, o);
        public float3 Untransform(float3 o) => NiMath.Untransform(this, o);
        public Ray3 Untransform(Ray3 o) => NiMath.Untransform(this, o);

        public Matrix4x4Transform3 Mul(Translation3 o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Mul(Rotation3Q o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Mul(Scale1 o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Mul(Scale3 o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Mul(RigidTransform3 o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Mul(UniformTransform3 o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Mul(NonUniformTransform3 o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Mul(Matrix3x3Transform3 o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Mul(Matrix4x4Transform3 o) => NiMath.Mul(this, o);
        public Obb3M Mul(Aabb3M o) => NiMath.Mul(this, o);
        public Obb3M Mul(Aabb3C o) => NiMath.Mul(this, o);
        public Obb3M Mul(Aabb3S o) => NiMath.Mul(this, o);
        public Obb3M Mul(Obb3T o) => NiMath.Mul(this, o);
        public Obb3M Mul(Obb3M o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Div(Translation3 o) => NiMath.Div(this, o);
        public Matrix4x4Transform3 Div(Rotation3Q o) => NiMath.Div(this, o);
        public Matrix4x4Transform3 Div(Scale1 o) => NiMath.Div(this, o);
        public Matrix4x4Transform3 Div(Scale3 o) => NiMath.Div(this, o);
        public Matrix4x4Transform3 Div(RigidTransform3 o) => NiMath.Div(this, o);
        public Matrix4x4Transform3 Div(UniformTransform3 o) => NiMath.Div(this, o);
        public Matrix4x4Transform3 Div(NonUniformTransform3 o) => NiMath.Div(this, o);
        public Matrix4x4Transform3 Div(Matrix3x3Transform3 o) => NiMath.Div(this, o);
        public Matrix4x4Transform3 Div(Matrix4x4Transform3 o) => NiMath.Div(this, o);
        public Obb3M Div(Aabb3M o) => NiMath.Div(this, o);
        public Obb3M Div(Aabb3C o) => NiMath.Div(this, o);
        public Obb3M Div(Aabb3S o) => NiMath.Div(this, o);
        public Obb3M Div(Obb3T o) => NiMath.Div(this, o);
        public Obb3M Div(Obb3M o) => NiMath.Div(this, o);
    }

    public static partial class NiMath
    {
        public static bool Equal(Matrix4x4Transform3 a, Matrix4x4Transform3 b) => Equal(a.matrix, b.matrix);

        public static bool NearEqual(Matrix4x4Transform3 a, Translation3 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform, margin);
        public static bool NearEqual(Matrix4x4Transform3 a, Rotation3Q b, float margin) => NearEqual(a, b.ToMatrix4x4Transform, margin);
        public static bool NearEqual(Matrix4x4Transform3 a, Scale1 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform, margin);
        public static bool NearEqual(Matrix4x4Transform3 a, Scale3 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform, margin);
        public static bool NearEqual(Matrix4x4Transform3 a, RigidTransform3 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform, margin);
        public static bool NearEqual(Matrix4x4Transform3 a, UniformTransform3 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform, margin);
        public static bool NearEqual(Matrix4x4Transform3 a, NonUniformTransform3 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform, margin);
        public static bool NearEqual(Matrix4x4Transform3 a, Matrix3x3Transform3 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform, margin);
        public static bool NearEqual(Matrix4x4Transform3 a, Matrix4x4Transform3 b, float margin) => NearEqual(a.matrix, b.matrix, margin);

        public static Matrix4x4Transform3 Inverse(Matrix4x4Transform3 a) => math.inverse(a.matrix);

        public static float3 RotateVector(Matrix4x4Transform3 rotation, float3 vector) => math.rotate(rotation, vector);

        public static Matrix4x4Transform3 Translate(float3 translation, Matrix4x4Transform3 o) => new Matrix4x4Transform3(math.mul(float4x4.Translate(translation), o.matrix));
        public static Matrix4x4Transform3 Rotate(quaternion rotation, Matrix4x4Transform3 b) => new Matrix4x4Transform3(math.mul(new float4x4(rotation, float3.zero), b.matrix));
        public static Matrix4x4Transform3 Scale(float scale, Matrix4x4Transform3 b) => new Matrix4x4Transform3(math.mul(float4x4.Scale(scale), b.matrix));
        public static Matrix4x4Transform3 Scale(float3 scale, Matrix4x4Transform3 b) => new Matrix4x4Transform3(math.mul(float4x4.Scale(scale), b.matrix));
        public static Matrix4x4Transform3 Translate(Matrix4x4Transform3 o, float3 translation) => new float4x4(o.Column0, o.Column1, o.Column2, new float4(math.transform(o, translation), o.Column3.w));
        public static Matrix4x4Transform3 Rotate(Matrix4x4Transform3 o, quaternion rotation) => math.mul(o, new float4x4(rotation, float3.zero));
        public static Matrix4x4Transform3 Scale(Matrix4x4Transform3 o, float scale)
        {
            var scale4 = new float4(scale, scale, scale, 1);
            return new Matrix4x4Transform3(scale4 * o.Column0, scale4 * o.Column1, scale4 * o.Column2, o.Column3);
        }
        public static Matrix4x4Transform3 Scale(Matrix4x4Transform3 o, float3 scale) => new Matrix4x4Transform3(new float4(scale.x, scale.x, scale.x, 1) * o.Column0, new float4(scale.y, scale.y, scale.y, 1) * o.Column1, new float4(scale.z, scale.z, scale.z, 1) * o.Column2, o.Column3);

        public static Matrix4x4Transform3 Translate(Translation3 translation, Matrix4x4Transform3 o) => new Matrix4x4Transform3(math.mul(float4x4.Translate(translation.translation), o.matrix));
        public static Matrix4x4Transform3 Rotate(Rotation3Q rotation, Matrix4x4Transform3 b) => new Matrix4x4Transform3(math.mul(new float4x4(rotation, float3.zero), b.matrix));
        public static Matrix4x4Transform3 Scale(Scale1 scale, Matrix4x4Transform3 b) => new Matrix4x4Transform3(math.mul(float4x4.Scale(scale.scale), b.matrix));
        public static Matrix4x4Transform3 Scale(Scale3 scale, Matrix4x4Transform3 b) => new Matrix4x4Transform3(math.mul(float4x4.Scale(scale.scale), b.matrix));
        public static Matrix4x4Transform3 Translate(Matrix4x4Transform3 o, Translation3 translation) => Translate(o, translation.translation);
        public static Matrix4x4Transform3 Rotate(Matrix4x4Transform3 o, Rotation3Q rotation) => Rotate(o, rotation.rotation);
        public static Matrix4x4Transform3 Scale(Matrix4x4Transform3 o, Scale1 scale) => Scale(o, scale.scale);
        public static Matrix4x4Transform3 Scale(Matrix4x4Transform3 o, Scale3 scale) => Scale(o, scale.scale);


        public static float3 Transform(Matrix4x4Transform3 a, float3 b) => math.transform(a, b);
        public static Ray3 Transform(Matrix4x4Transform3 a, Ray3 b) => new Ray3(Transform(a, b.translation), RotateVector(a, b.projectionAxis));

        public static float3 Untransform(Matrix4x4Transform3 a, float3 b) => math.transform(math.inverse(a), b);
        public static Ray3 Untransform(Matrix4x4Transform3 a, Ray3 b) => Transform(Inverse(a), b);

        public static Matrix4x4Transform3 Mul(Matrix4x4Transform3 a, Translation3 b) => Translate(a, b);
        public static Matrix4x4Transform3 Mul(Matrix4x4Transform3 a, Rotation3Q b) => Rotate(a, b);
        public static Matrix4x4Transform3 Mul(Matrix4x4Transform3 a, Scale1 b) => Scale(a, b);
        public static Matrix4x4Transform3 Mul(Matrix4x4Transform3 a, Scale3 b) => Scale(a, b);
        public static Matrix4x4Transform3 Mul(Matrix4x4Transform3 a, RigidTransform3 b) => math.mul(a, b.ToMatrix4x4Transform);
        public static Matrix4x4Transform3 Mul(Matrix4x4Transform3 a, UniformTransform3 b) => math.mul(a, b.ToMatrix4x4Transform);
        public static Matrix4x4Transform3 Mul(Matrix4x4Transform3 a, NonUniformTransform3 b) => math.mul(a, b.ToMatrix4x4Transform);
        public static Matrix4x4Transform3 Mul(Matrix4x4Transform3 a, Matrix3x3Transform3 b) => math.mul(a, b.ToMatrix4x4Transform);
        public static Matrix4x4Transform3 Mul(Matrix4x4Transform3 a, Matrix4x4Transform3 b) => math.mul(a, b);
        public static Obb3M Mul(Matrix4x4Transform3 a, Aabb3M b) => math.mul(a, b.ToMatrix4x4Transform);
        public static Obb3M Mul(Matrix4x4Transform3 a, Aabb3C b) => math.mul(a, b.ToMatrix4x4Transform);
        public static Obb3M Mul(Matrix4x4Transform3 a, Aabb3S b) => math.mul(a, b.ToMatrix4x4Transform);
        public static Obb3M Mul(Matrix4x4Transform3 a, Obb3T b) => math.mul(a, b.ToMatrix4x4Transform);
        public static Obb3M Mul(Matrix4x4Transform3 a, Obb3M b) => math.mul(a, b.ToMatrix4x4Transform);
        public static Matrix4x4Transform3 Div(Matrix4x4Transform3 a, Translation3 b) => Mul(Inverse(a), b);
        public static Matrix4x4Transform3 Div(Matrix4x4Transform3 a, Rotation3Q b) => Mul(Inverse(a), b);
        public static Matrix4x4Transform3 Div(Matrix4x4Transform3 a, Scale1 b) => Mul(Inverse(a), b);
        public static Matrix4x4Transform3 Div(Matrix4x4Transform3 a, Scale3 b) => Mul(Inverse(a), b);
        public static Matrix4x4Transform3 Div(Matrix4x4Transform3 a, RigidTransform3 b) => Mul(Inverse(a), b);
        public static Matrix4x4Transform3 Div(Matrix4x4Transform3 a, UniformTransform3 b) => Mul(Inverse(a), b);
        public static Matrix4x4Transform3 Div(Matrix4x4Transform3 a, NonUniformTransform3 b) => Mul(Inverse(a), b);
        public static Matrix4x4Transform3 Div(Matrix4x4Transform3 a, Matrix3x3Transform3 b) => Mul(Inverse(a), b);
        public static Matrix4x4Transform3 Div(Matrix4x4Transform3 a, Matrix4x4Transform3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Matrix4x4Transform3 a, Aabb3M b) => Mul(Inverse(a), b);
        public static Obb3M Div(Matrix4x4Transform3 a, Aabb3C b) => Mul(Inverse(a), b);
        public static Obb3M Div(Matrix4x4Transform3 a, Aabb3S b) => Mul(Inverse(a), b);
        public static Obb3M Div(Matrix4x4Transform3 a, Obb3T b) => Mul(Inverse(a), b);
        public static Obb3M Div(Matrix4x4Transform3 a, Obb3M b) => Mul(Inverse(a), b);
    }
}