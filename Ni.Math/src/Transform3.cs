using System;
using UnityEngine;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    public interface ITranslation3 { float3 translation3 { get; } Translation3 Translation3 { get; } }
    public interface IRotation3Q { quaternion rotation3 { get; } Rotation3Q Rotation3 { get; } }
    public interface IRotation3E { float3 eulerRotation3 { get; } Rotation3Euler EulerRotation3 { get; } }
    public interface IScale1 { float scale1 { get; } Scale1 Scale1 { get; } }
    public interface IScale3 { float3 scale3 { get; } Scale3 Scale3 { get; } }
    public interface IShear3 { float3 shear3 { get; } ShearXY3 Shear3 { get; } }
    public interface ITranslation3W { float3 translation3 { set; } Translation3 Translation3 { set; } }
    public interface IRotation3QW { quaternion rotation3 { set; } Rotation3Q Rotation3 { set; } }
    public interface IRotation3EW { float3 eulerRotation3 { set; } Rotation3Euler EulerRotation3 { set; } }
    public interface IScale1W { float scale1 { set; } Scale1 Scale1 { set; } }
    public interface IScale3W { float3 scale3 { set; } Scale3 Scale3 { set; } }
    public interface IShear3W { float3 shear3 { set; } ShearXY3 Shear3 { set; } }
    public interface ITranslation3RW : ITranslation3, ITranslation3W { new float3 translation3 { get; set; } new Translation3 Translation3 { get; set; } }
    public interface IRotation3QRW : IRotation3Q, IRotation3QW { new quaternion rotation3 { get; set; } new Rotation3Q Rotation3 { get; set; } }
    public interface IRotation3ERW : IRotation3E, IRotation3EW { new float3 eulerRotation3 { get; set; } new Rotation3Euler EulerRotation3 { get; set; } }
    public interface IScale1RW : IScale1, IScale1W { new float scale1 { get; set; } new Scale1 Scale1 { get; set; } }
    public interface IScale3RW : IScale3, IScale3W { new float3 scale3 { get; set; } new Scale3 Scale3 { get; set; } }
    public interface IShear3RW : IShear3, IShear3W { new float3 shear3 { get; set; } new ShearXY3 Shear3 { get; set; } }

    public interface ITranslated<TPrime, TTranslation>
    {
        /// <summary>
        /// Add a translation after this transform.
        /// (Transformation order: Left to Right)
        /// </summary>
        TPrime Translated(TTranslation translation);
    }

    public interface IRotated<TPrime, TRotation>
    {
        /// <summary>
        /// Add a rotation after this transform.
        /// (Transformation order: Left to Right)
        /// </summary>
        TPrime Rotated(TRotation rotation);
    }

    public interface IScaled<TPrime, TScale>
    {
        /// <summary>
        /// Add a scale after this transform.
        /// (Transformation order: Left to Right)
        /// </summary>
        TPrime Scaled(TScale scale);
    }

    public interface ISheared<TPrime, TShear>
    {
        /// <summary>
        /// Add a shear after this transform.
        /// (Transformation order: Left to Right)
        /// </summary>
        TPrime Sheared(TShear shear);
    }

    public interface ITranslate<TPrime, TTranslation>
    {
        /// <summary>
        /// Add a translation before this transform.
        /// (Transformation order: Right to Left)
        /// </summary>
        TPrime Translate(TTranslation translation);
    }

    public interface IRotate<TPrime, TRotation>
    {
        /// <summary>
        /// Add a rotation before this transform.
        /// (Transformation order: Right to Left)
        /// </summary>
        TPrime Rotate(TRotation rotation);
    }

    public interface IScale<TPrime, TScale>
    {
        /// <summary>
        /// Add a scale before this transform.
        /// (Transformation order: Right to Left)
        /// </summary>
        TPrime Scale(TScale scale);
    }
    public interface IShear<TPrime, TShear>
    {
        /// <summary>
        /// Add a shear before this transform.
        /// (Transformation order: Right to Left)
        /// </summary>
        TPrime Shear(TShear shear);
    }

    /// <summary>
    /// TODO.
    /// ref: 
    /// https://stackoverflow.com/questions/18362043/shear-matrix-as-a-combination-of-basic-transformation
    /// https://caff.de/posts/4x4-matrix-decomposition/
    /// </summary>
    /// <typeparam name="TPrime"></typeparam>
    //public interface IShearing3
    //{
    //    float3 Shearing {get; set;}
    //}


    /// <summary>
    /// Has the possibility to transform / untransform a primitive.
    /// </summary>
    public interface ITransform<TOther> : ITransform<TOther, TOther>
    {
    }

    public interface ITransform<TOther, TPrime> : ITransform<TOther, TPrime, TOther>
    {
    }

    /// <summary>
    /// Has the possibility to transform / untransform from one primitive to another
    /// </summary>
    public interface ITransform<TOther, TTransformPrime, TUntransformPrime>
    {
        /// <summary>
        /// Perform this transform after an another.
        /// (Transformation order: Right to Left)
        /// </summary>
        TTransformPrime Transform(TOther o);

        /// <summary>
        /// Perform the reverse transformation after an another.
        /// (Transformation order: Right to Left)
        /// </summary>
        TUntransformPrime Untransform(TTransformPrime o);
    }

    public interface IToNonUniformTransform3
    {
        NonUniformTransform3 ToNonUniformTransform3 { get; }
    }

    public interface IToMatrix3x3Transform
    {
        Matrix3x3Transform3 ToMatrix3x3Transform3 { get; }
    }

    public interface IToMatrix4x4Transform
    {
        Matrix4x4Transform3 ToMatrix4x4Transform3 { get; }
    }

    public interface ITransform3Common :
        INearEquatable<Translation3>,
        INearEquatable<Rotation3Q>,
        INearEquatable<Scale1>,
        INearEquatable<Scale3>,
        INearEquatable<RigidTransform3>,
        INearEquatable<UniformTransform3>,
        INearEquatable<NonUniformTransform3>,
        INearEquatable<Matrix3x3Transform3>,
        INearEquatable<Matrix4x4Transform3>,
        IToMatrix4x4Transform
    {
    }


    /// <summary>
    /// 3D transform
    /// </summary>
    public interface ITransform3 :
        IToMatrix4x4Transform,
        ITransform<float3>,
        ITransform<Direction3>,
        ITransform<ProjectionAxis3x1>,
        ITransform<ProjectionAxis1x3>,
        ITransform<Ray3>
    {
    }

    public interface ITransform3<TSelf> : ITransform3,
        INearEquatable<TSelf>,
        IEquatable<TSelf>
    {
    }

    //public interface INonUniformTransform3 : ITransform3,
    //    ITransform<Direction3, ProjectionAxis3x1, ProjectionAxis3x1>
    //{
    //}

    //public interface INonUniformTransform3<TSelf> : INonUniformTransform3,
    //    INearEquatable<TSelf>,
    //    IEquatable<TSelf>
    //{
    //}

    public interface ITransformable3<TSelf, TTranslated, TRotated, TScaled1, TScaled3> : ITransformable3<TSelf, TTranslated, TRotated, TScaled1, TScaled3, TTranslated, TRotated, TScaled1, TScaled3>
    {

    }

    public interface ITransformable3<TSelf, TTranslated, TRotated, TScaled1, TScaled3, TTranslate, TRotate, TScale1, TScale3> :
        INearEquatable<TSelf>,
        ITranslated<TTranslated, float3>,
        IRotated<TRotated, quaternion>,
        IScaled<TScaled1, float>,
        IScaled<TScaled3, float3>,
        ITranslate<TTranslate, float3>,
        IRotate<TRotate, quaternion>,
        IScale<TScale1, float>,
        IScale<TScale3, float3>,
        ITranslated<TTranslated, Translation3>,
        IRotated<TRotated, Rotation3Q>,
        IScaled<TScaled1, Scale1>,
        IScaled<TScaled3, Scale3>,
        ITranslate<TTranslate, Translation3>,
        IRotate<TRotate, Rotation3Q>,
        IScale<TScale1, Scale1>,
        IScale<TScale3, Scale3>
    {
    }

    public interface IShearableTransformable3<TSelf> : IShearableTransformable3<TSelf, TSelf, TSelf>
    {
    }

    public interface IShearableTransformable3<TSelf, TSheared> : IShearableTransformable3<TSelf, TSheared, TSheared>
    {
    }

    public interface IShearableTransformable3<TSelf, TSheared, TShear> :
        INearEquatable<TSelf>,
        ISheared<TSheared, float3>,
        IShear<TShear, float3>,
        ISheared<TSheared, ShearXY3>,
        IShear<TShear, ShearXY3>
    {
    }
    public interface IBox3 : ITransform3
    {

    }
    public interface IBox3<TSelf> : IBox3, ITransform3<TSelf>
    {

    }

    public static partial class NiMath
    {
        public static bool Equal(float a, float b) => a == b;
        public static bool Equal(float2 a, float2 b) => math.all(a == b);
        public static bool Equal(float3 a, float3 b) => math.all(a == b);
        public static bool Equal(float4 a, float4 b) => math.all(a == b);
        public static bool Equal(quaternion a, quaternion b) => math.all(a.value == b.value);
        public static bool Equal(float3x3 a, float3x3 b) => math.all(a.c0 == b.c0 & a.c1 == b.c1 & a.c2 == b.c2);
        public static bool Equal(float4x4 a, float4x4 b) => math.all(a.c0 == b.c0 & a.c1 == b.c1 & a.c2 == b.c2 & a.c3 == b.c3);

        public static bool NearEqual(float a, float b, float margin) => math.abs(a - b) <= margin;
        public static bool NearEqual(float2 a, float2 b, float margin) => math.all(math.abs(a - b) <= margin);
        public static bool NearEqual(float3 a, float3 b, float margin) => math.all(math.abs(a - b) <= margin);
        public static bool NearEqual(float4 a, float4 b, float margin) => math.all(math.abs(a - b) <= margin);
        public static bool NearEqual(quaternion a, quaternion b, float margin) => math.all(math.abs(a.value - b.value) <= margin);
        public static bool NearEqual(float3x3 a, float3x3 b, float margin) => math.all(math.abs(a.c0 - b.c0) <= margin & math.abs(a.c1 - b.c1) <= margin & math.abs(a.c2 - b.c2) <= margin);
        public static bool NearEqual(float4x4 a, float4x4 b, float margin) => math.all(math.abs(a.c0 - b.c0) <= margin & math.abs(a.c1 - b.c1) <= margin & math.abs(a.c2 - b.c2) <= margin & math.abs(a.c3 - b.c3) <= margin);

        public static bool NearEqualTranslation(float a, float3 b, float margin) => math.all(math.abs(new float3(a, 0, 0) - b) <= margin);
        public static bool NearEqualTranslation(float3 a, float b, float margin) => math.all(math.abs(a - new float3(b, 0, 0)) <= margin);

        public static bool NearEqualScale(float a, float3 b, float margin) => math.all(math.abs(a - b) <= margin);
        public static bool NearEqualScale(float3 a, float b, float margin) => math.all(math.abs(a - b) <= margin);


        [Obsolete("Use either:\n\tNearEqual(float3, float3)\n\tNearEqualTranslation(float, float3)\n\tNearEqualScale(float, float3)")]
        public static void NearEqual(float a, float3 b, float margin) => throw new System.ArgumentException("NearEqual(float, float3) is ambitious. Call either NearEqualTranslation and NearEqualScale");
        [Obsolete("Use either:\n\tNearEqual(float3, float3)\n\tNearEqualTranslation(float3, float)\n\tNearEqualScale(float3, float)")]
        public static void NearEqual(float3 a, float b, float margin) => throw new System.ArgumentException("NearEqual(float3, float) is ambitious. Call either NearEqualTranslation and NearEqualScale");

        public static quaternion Inverse(quaternion rotation) => math.inverse(rotation);

        public static float3 RotateVector(quaternion rotation, float3 vector) => math.mul(rotation, vector);

        public static float3 Translate(float3 translation, float3 b) => translation + b;
        public static float3 Rotate(quaternion rotation, float3 b) => math.mul(rotation, b);
        public static float3 Scale(float scale, float3 o) => scale * o;
        public static float3 Scale(float3 scale, float3 o) => scale * o;

        public static float3 Transform(quaternion rotation, float3 o) => math.mul(rotation, o);
        public static float3 Transform(float3x3 transform, float3 o) => math.mul(transform, o);
        public static float3 Transform(float4x4 transform, float3 o) => math.transform(transform, o);

        public static Matrix4x4Transform3 GetLocalMatrix4x4Transform3(this Transform transform) => Matrix4x4Transform3.TRS(transform.localPosition, transform.localRotation, transform.localScale);

        public static float3 QuaternionToEulerXYZ(quaternion rotation)
        {
            // copied from https://discussions.unity.com/t/is-there-a-conversion-method-from-quaternion-to-euler/731052
            float4 q = rotation.value;
            double3 res;

            double sinr_cosp = +2.0 * (q.w * q.x + q.y * q.z);
            double cosr_cosp = +1.0 - 2.0 * (q.x * q.x + q.y * q.y);
            res.x = math.atan2(sinr_cosp, cosr_cosp);

            double sinp = +2.0 * (q.w * q.y - q.z * q.x);
            if (math.abs(sinp) >= 1)
            {
                res.y = math.PI / 2 * math.sign(sinp);
            }
            else
            {
                res.y = math.asin(sinp);
            }

            double siny_cosp = +2.0 * (q.w * q.z + q.x * q.y);
            double cosy_cosp = +1.0 - 2.0 * (q.y * q.y + q.z * q.z);
            res.z = math.atan2(siny_cosp, cosy_cosp);

            return (float3)res;
        }

        public static void SetLocal(this Transform transform, RigidTransform3 value)
        {
            transform.localRotation = value.rotation;
            transform.localPosition = value.translation;
        }

        public static void SetLocal(this Transform transform, UniformTransform3 value)
        {
            transform.localScale = new float3(value.scale);
            transform.localRotation = value.rotation;
            transform.localPosition = value.translation;
        }

        public static void SetLocal(this Transform transform, NonUniformTransform3 value)
        {
            transform.localScale = value.scale;
            transform.localRotation = value.rotation;
            transform.localPosition = value.translation;

        }
    }
}