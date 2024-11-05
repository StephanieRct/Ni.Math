using System;
using UnityEngine;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    public interface ITranslation3 { float3 translation3 { get; } Translation3 Translation3 { get; } }
    public interface IRotation3Q { quaternion rotation3 { get; } Rotation3Q Rotation3 { get; } }
    public interface IRotation3E { float3 eulerRotation3 { get; } Rotation3Euler EulerRotation3 { get; } }
    public interface IUniformScale { float scale1 { get; } Scale1 Scale1 { get; } }
    public interface INonUniformScale3 { float3 scale3 { get; } Scale3 Scale3 { get; } }
    public interface ITranslation3W { float3 translation3 { set; } Translation3 Translation3 { set; } }
    public interface IRotation3QW { quaternion rotation3 { set; } Rotation3Q Rotation3 { set; } }
    public interface IRotation3EW { float3 eulerRotation3 { set; } Rotation3Euler EulerRotation3 { set; } }
    public interface IUniformScaleW { float scale1 { set; } Scale1 Scale1 { set; } }
    public interface INonUniformScale3W { float3 scale3 { set; } Scale3 Scale3 { set; } }
    public interface ITranslation3RW : ITranslation3, ITranslation3W { new float3 translation3 { get; set; } new Translation3 Translation3 { get; set; } }
    public interface IRotation3QRW : IRotation3Q, IRotation3QW { new quaternion rotation3 { get; set; } new Rotation3Q Rotation3 { get; set; } }
    public interface IRotation3ERW : IRotation3E, IRotation3EW { new float3 eulerRotation3 { get; set; } new Rotation3Euler EulerRotation3 { get; set; } }
    public interface IUniformScaleRW : IUniformScale, IUniformScaleW { new float scale1 { get; set; } new Scale1 Scale1 { get; set; } }
    public interface INonUniformScale3RW : INonUniformScale3, INonUniformScale3W { new float3 scale3 { get; set; } new Scale3 Scale3 { get; set; } }

    //public interface ITranslation3 { float3 GetTranslation3f(); TranslationTransform3 GetTranslation3(); }
    //public interface IRotation3Q { quaternion GetRotation3f(); RotationQTransform3 GetRotation3(); }
    //public interface IRotation3E { float3 GetEulerRotation3f(); RotationEulerTransform3 GetEulerRotation3(); }
    //public interface IUniformScale { float GetScale1f(); ScaleUniformTransform3 GetScale1(); }
    //public interface INonUniformScale3 { float3 GetScale3f(); ScaleNonUniformTransform3 GetScale3(); }
    //public interface ITranslation3W { void SetTranslation3f(float3 o); void SetTranslation3(TranslationTransform3 o); }
    //public interface IRotation3QW { void SetRotation3f(quaternion o); void SetRotation3(RotationQTransform3 o); }
    //public interface IRotation3EW { void SetRotationEuler3f(float3 o); void SetRotationEuler3(RotationEulerTransform3 o); }
    //public interface IUniformScaleW { void SetScale1f(float o); void SetScale1(ScaleUniformTransform3 o); }
    //public interface INonUniformScale3W { void SetScale3f(float3 o); void SetScale3(ScaleNonUniformTransform3 o); }
    //public interface ITranslation3RW : ITranslation3, ITranslation3W {  }
    //public interface IRotation3QRW : IRotation3Q, IRotation3QW {  }
    //public interface IRotation3ERW : IRotation3E, IRotation3EW {  }
    //public interface IUniformScaleRW : IUniformScale, IUniformScaleW {  }
    //public interface INonUniformScale3RW : INonUniformScale3, INonUniformScale3W {  }

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

    /// <summary>
    /// Has the possibility to transform / untransform from one primitive to another
    /// </summary>
    public interface ITransform<TOther, TPrime>
    {
        /// <summary>
        /// Perform this transform after an another.
        /// (Transformation order: Right to Left)
        /// </summary>
        TPrime Transform(TOther o);

        /// <summary>
        /// Perform the reverse transformation after an another.
        /// (Transformation order: Right to Left)
        /// </summary>
        TOther Untransform(TPrime o);
    }

    public interface IToNonUniformTransform3
    {
        NonUniformTransform3 ToNonUniformTransform3 { get; }
    }
    public interface IToMatrix3x3Transform
    {
        Matrix3x3Transform3 ToMatrix3x3Transform { get; }
    }

    public interface IToMatrix4x4Transform
    {
        Matrix4x4Transform3 ToMatrix4x4Transform { get; }
    }
    
    /// <summary>
    /// 3D transform
    /// </summary>
    public interface ITransform3 :
        INearEquatable<Translation3>,
        INearEquatable<Rotation3Q>,
        INearEquatable<Scale1>,
        INearEquatable<Scale3>,
        INearEquatable<RigidTransform3>,
        INearEquatable<UniformTransform3>,
        INearEquatable<NonUniformTransform3>,
        INearEquatable<Matrix3x3Transform3>,
        INearEquatable<Matrix4x4Transform3>,
        //INearEquatable<Aabb3M>,
        //INearEquatable<Aabb3S>,
        //INearEquatable<Aabb3C>,
        //INearEquatable<Obb3M>,
        //INearEquatable<Obb3T>,
        //INearEquatable<Obb3M3>,
        IToMatrix4x4Transform,
        ITransform<float3>
    {
    }
    public interface ITransformable3<T, TTranslated, TRotated, TScaled1, TScaled3> : ITransformable3<T, TTranslated, TRotated, TScaled1, TScaled3, TTranslated, TRotated, TScaled1, TScaled3>
    {

    }
    public interface ITransformable3<T, TTranslated, TRotated, TScaled1, TScaled3, TTranslate, TRotate, TScale1, TScale3> : ITransform3,
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

        public static RigidTransform3 ToRigidTransform(this Transform transform) => new RigidTransform3(transform.position, transform.rotation);
        public static UniformTransform3 ToUniformTransform(this Transform transform) => new UniformTransform3(transform.position, transform.rotation, transform.lossyScale.x);
        public static NonUniformTransform3 ToNonUniformTransform(this Transform transform) => new NonUniformTransform3(transform.position, transform.rotation, transform.lossyScale);
        public static float4x4 ToFloat4x4(this Transform transform) => float4x4.TRS(transform.position, transform.rotation, transform.lossyScale);

        public static RigidTransform3 LocalToRigidTransform(this Transform transform) => new RigidTransform3(transform.localPosition, transform.localRotation);
        public static UniformTransform3 LocalToUniformTransform(this Transform transform) => new UniformTransform3(transform.localPosition, transform.localRotation, transform.localScale.x);
        public static NonUniformTransform3 LocalToNonUniformTransform(this Transform transform) => new NonUniformTransform3(transform.localPosition, transform.localRotation, transform.localScale);
        public static float4x4 LocalToFloat4x4(this Transform transform) => float4x4.TRS(transform.localPosition, transform.localRotation, transform.localScale);

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