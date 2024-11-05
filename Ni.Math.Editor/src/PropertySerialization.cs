using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Ni.Mathematics.Editor
{
    public static class PropertySerialization
    {
        static SerializedProperty Sub(SerializedProperty property, string name)
        {
            var sub = property.FindPropertyRelative(name);
            if (sub == null)
                Debug.LogError($"Could not find property named '{name}' under '{property.propertyPath}'");
            return sub;
        }

        static SerializedProperty SetSub(SerializedProperty property, string name)
        {
            var sub = property.FindPropertyRelative(name);
            if (sub == null)
                Debug.LogError($"Could not find property named '{name}' under '{property.propertyPath}'");
            return sub;
        }
        public static float2 SetFloat(SerializedProperty property, float value) => new float2(Sub(property, "x").floatValue, Sub(property, "y").floatValue);

        public static void SetFloat2(SerializedProperty property, float2 value)
        {
            SetSubFloat(property, "x", value.x);
            SetSubFloat(property, "y", value.y);
        }
        public static void SetFloat3(SerializedProperty property, float3 value)
        {
            SetSubFloat(property, "x", value.x);
            SetSubFloat(property, "y", value.y);
            SetSubFloat(property, "z", value.z);
        }
        public static void SetFloat4(SerializedProperty property, float4 value)
        {
            SetSubFloat(property, "x", value.x);
            SetSubFloat(property, "y", value.y);
            SetSubFloat(property, "z", value.z);
            SetSubFloat(property, "w", value.w);
        }
        public static void SetFloat3x3(SerializedProperty property, float3x3 value)
        {
            SetSubFloat3(property, "c0", value.c0);
            SetSubFloat3(property, "c1", value.c1);
            SetSubFloat3(property, "c2", value.c2);
        }
        public static void SetFloat4x4(SerializedProperty property, float4x4 value)
        {
            SetSubFloat4(property, "c0", value.c0);
            SetSubFloat4(property, "c1", value.c1);
            SetSubFloat4(property, "c2", value.c2);
            SetSubFloat4(property, "c3", value.c3);
        }
        public static void SetQuaternion(SerializedProperty property, quaternion value) => SetSubFloat4(property, "value", value.value);
        public static void SetTranslationTransform3(SerializedProperty property, Translation3 value) => SetSubFloat3(property, "translation", value.translation);
        public static void SetRotationQTransform3(SerializedProperty property, Rotation3Q value) => SetSubQuaternion(property, "rotation", value.rotation);
        public static void SetRotationEulerTransform3(SerializedProperty property, Rotation3Euler value) => SetSubFloat3(property, "rotation", value.rotation);
        public static void SetScaleUniformTransform3(SerializedProperty property, Scale1 value) => SetSubFloat(property, "scale", value.scale);
        public static void SetScaleNonUniformTransform3(SerializedProperty property, Scale3 value) => SetSubFloat3(property, "scale", value.scale);
        public static void SetRigidTransform3(SerializedProperty property, RigidTransform3 value) { SetSubFloat3(property, "translation", value.translation); SetSubQuaternion(property, "rotation", value.rotation); }
        public static void SetUniformTransform3(SerializedProperty property, UniformTransform3 value) { SetSubFloat3(property, "translation", value.translation); SetSubQuaternion(property, "rotation", value.rotation);  SetSubFloat(property, "scale", value.scale);}
        public static void SetNonUniformTransform3(SerializedProperty property, NonUniformTransform3 value) { SetSubFloat3(property, "translation", value.translation); SetSubQuaternion(property, "rotation", value.rotation); SetSubFloat3(property, "scale", value.scale); }
        public static void SetMatrix3x3Transform3(SerializedProperty property, Matrix3x3Transform3 value) => SetSubFloat3x3(property, "matrix", value.matrix);
        public static void SetMatrix4x4Transform3(SerializedProperty property, Matrix4x4Transform3 value) => SetSubFloat4x4(property, "matrix", value.matrix);
        public static void SetAabb3M(SerializedProperty property, Aabb3M value) { SetSubFloat3(property, "min", value.min); SetSubFloat3(property, "max", value.max); }
        public static void SetAabb3S(SerializedProperty property, Aabb3S value) { SetSubFloat3(property, "min", value.min); SetSubFloat3(property, "size", value.size); }
        public static void SetAabb3C(SerializedProperty property, Aabb3C value) { SetSubFloat3(property, "center", value.min); SetSubFloat3(property, "extent", value.extent); }
        public static void SetObb3T(SerializedProperty property, Obb3T value) => SetSubNonUniformTransform3(property, "NonUniformTransform", value.NonUniformTransform);
        public static void SetObb3M(SerializedProperty property, Obb3M value) => SetSubMatrix4x4Transform3(property, "Matrix4x4Transform", value.Matrix4x4Transform);


        public static void SetSubFloat(SerializedProperty property, string name, float value) => Sub(property, name).floatValue = value;
        public static void SetSubFloat2(SerializedProperty property, string name, float2 value) => SetFloat2(Sub(property, name), value);
        public static void SetSubFloat3(SerializedProperty property, string name, float3 value) => SetFloat3(Sub(property, name), value);
        public static void SetSubFloat4(SerializedProperty property, string name, float4 value) => SetFloat4(Sub(property, name), value);
        public static void SetSubFloat3x3(SerializedProperty property, string name, float3x3 value) => SetFloat3x3(Sub(property, name), value);
        public static void SetSubFloat4x4(SerializedProperty property, string name, float4x4 value) => SetFloat4x4(Sub(property, name), value);
        public static void SetSubQuaternion(SerializedProperty property, string name, quaternion  value) => SetQuaternion(Sub(property, name), value);
        public static void SetSubTranslationTransform3(SerializedProperty property, string name, Translation3  value) => SetTranslationTransform3(Sub(property, name), value);
        public static void SetSubRotationQTransform3(SerializedProperty property, string name, Rotation3Q  value) => SetRotationQTransform3(Sub(property, name), value);
        public static void SetSubRotationEulerTransform3(SerializedProperty property, string name, Rotation3Euler  value) => SetRotationEulerTransform3(Sub(property, name), value);
        public static void SetSubScaleUniformTransform3(SerializedProperty property, string name, Scale1  value) => SetScaleUniformTransform3(Sub(property, name), value);
        public static void SetSubScaleNonUniformTransform3(SerializedProperty property, string name, Scale3  value) => SetScaleNonUniformTransform3(Sub(property, name), value);
        public static void SetSubRigidTransform3(SerializedProperty property, string name, RigidTransform3  value) => SetRigidTransform3(Sub(property, name), value);
        public static void SetSubUniformTransform3(SerializedProperty property, string name, UniformTransform3  value) => SetUniformTransform3(Sub(property, name), value);
        public static void SetSubNonUniformTransform3(SerializedProperty property, string name, NonUniformTransform3  value) => SetNonUniformTransform3(Sub(property, name), value);
        public static void SetSubMatrix3x3Transform3(SerializedProperty property, string name, Matrix3x3Transform3  value) => SetMatrix3x3Transform3(Sub(property, name), value);
        public static void SetSubMatrix4x4Transform3(SerializedProperty property, string name, Matrix4x4Transform3  value) => SetMatrix4x4Transform3(Sub(property, name), value);
        public static void SetSubAabb3M(SerializedProperty property, string name, Aabb3M  value) => SetAabb3M(Sub(property, name), value);
        public static void SetSubAabb3S(SerializedProperty property, string name, Aabb3S  value) => SetAabb3S(Sub(property, name), value);
        public static void SetSubAabb3C(SerializedProperty property, string name, Aabb3C  value) => SetAabb3C(Sub(property, name), value);
        public static void SetSubObb3T(SerializedProperty property, string name, Obb3T  value) => SetObb3T(Sub(property, name), value);
        public static void SetSubObb3M(SerializedProperty property, string name, Obb3M value) => SetObb3M(Sub(property, name), value);
        



        public static float2 PropertyFloat2(SerializedProperty property) => new float2(Sub(property, "x").floatValue, Sub(property, "y").floatValue);
        public static float3 PropertyFloat3(SerializedProperty property) => new float3(Sub(property, "x").floatValue, Sub(property, "y").floatValue, Sub(property, "z").floatValue);
        public static float4 PropertyFloat4(SerializedProperty property) => new float4(Sub(property, "x").floatValue, Sub(property, "y").floatValue, Sub(property, "z").floatValue, Sub(property, "w").floatValue);
        public static float3x3 PropertyFloat3x3(SerializedProperty property) => new float3x3(SubFloat3(property, "c0"), SubFloat3(property, "c1"), SubFloat3(property, "c2"));
        public static float4x4 PropertyFloat4x4(SerializedProperty property) => new float4x4(SubFloat4(property, "c0"), SubFloat4(property, "c1"), SubFloat4(property, "c2"), SubFloat4(property, "c3"));
        public static quaternion PropertyQuaternion(SerializedProperty property) => new quaternion(SubFloat4(property, "value"));
        public static Translation3 PropertyToTranslationTransform3(SerializedProperty property) => new Translation3(SubFloat3(property, "translation"));
        public static Rotation3Q PropertyToRotationQTransform3(SerializedProperty property) => new Rotation3Q(SubQuaternion(property, "rotation"));
        public static Rotation3Euler PropertyToRotationEulerTransform3(SerializedProperty property) => new Rotation3Euler(SubFloat3(property, "rotation"));
        public static Scale1 PropertyToScaleUniformTransform3(SerializedProperty property) => new Scale1(SubFloat(property, "scale"));
        public static Scale3 PropertyToScaleNonUniformTransform3(SerializedProperty property) => new Scale3(SubFloat3(property, "scale"));
        public static RigidTransform3 PropertyToRigidTransform3(SerializedProperty property) => new RigidTransform3(SubFloat3(property, "translation"), SubQuaternion(property, "rotation"));
        public static UniformTransform3 PropertyToUniformTransform3(SerializedProperty property) => new UniformTransform3(SubFloat3(property, "translation"), SubQuaternion(property, "rotation"), SubFloat(property, "scale"));
        public static NonUniformTransform3 PropertyToNonUniformTransform3(SerializedProperty property) => new NonUniformTransform3(SubFloat3(property, "translation"), SubQuaternion(property, "rotation"), SubFloat3(property, "scale"));
        public static Matrix3x3Transform3 PropertyToMatrix3x3Transform3(SerializedProperty property) => new Matrix3x3Transform3(SubFloat3x3(property, "matrix"));
        public static Matrix4x4Transform3 PropertyToMatrix4x4Transform3(SerializedProperty property) => new Matrix4x4Transform3(SubFloat4x4(property, "matrix"));
        public static Aabb3M PropertyToAabb3M(SerializedProperty property) => new Aabb3M(SubFloat3(property, "min"), SubFloat3(property, "max"));
        public static Aabb3S PropertyToAabb3S(SerializedProperty property) => new Aabb3S(SubFloat3(property, "min"), SubFloat3(property, "size"));
        public static Aabb3C PropertyToAabb3C(SerializedProperty property) => new Aabb3C(SubFloat3(property, "center"), SubFloat3(property, "extent"));
        public static Obb3T PropertyToObb3T(SerializedProperty property) => new Obb3T(SubNonUniformTransform3(property, "NonUniformTransform"));
        public static Obb3M PropertyToObb3M(SerializedProperty property) => new Obb3M(SubMatrix4x4Transform3(property, "Matrix4x4Transform"));


        public static float SubFloat(SerializedProperty property, string name) => Sub(property, name).floatValue;
        public static float2 SubFloat2(SerializedProperty property, string name) => PropertyFloat2(Sub(property, name));
        public static float3 SubFloat3(SerializedProperty property, string name) => PropertyFloat3(Sub(property, name));
        public static float4 SubFloat4(SerializedProperty property, string name) => PropertyFloat4(Sub(property, name));
        public static float3x3 SubFloat3x3(SerializedProperty property, string name) => PropertyFloat3x3(Sub(property, name));
        public static float4x4 SubFloat4x4(SerializedProperty property, string name) => PropertyFloat4x4(Sub(property, name));
        public static quaternion SubQuaternion(SerializedProperty property, string name) => PropertyQuaternion(Sub(property, name));
        public static Translation3 SubTranslationTransform3(SerializedProperty property, string name) => PropertyToTranslationTransform3(Sub(property, name));
        public static Rotation3Q SubRotationQTransform3(SerializedProperty property, string name) => PropertyToRotationQTransform3(Sub(property, name));
        public static Rotation3Euler SubRotationEulerTransform3(SerializedProperty property, string name) => PropertyToRotationEulerTransform3(Sub(property, name));
        public static Scale1 SubScaleUniformTransform3(SerializedProperty property, string name) => PropertyToScaleUniformTransform3(Sub(property, name));
        public static Scale3 SubScaleNonUniformTransform3(SerializedProperty property, string name) => PropertyToScaleNonUniformTransform3(Sub(property, name));
        public static RigidTransform3 SubRigidTransform3(SerializedProperty property, string name) => PropertyToRigidTransform3(Sub(property, name));
        public static UniformTransform3 SubUniformTransform3(SerializedProperty property, string name) => PropertyToUniformTransform3(Sub(property, name));
        public static NonUniformTransform3 SubNonUniformTransform3(SerializedProperty property, string name) => PropertyToNonUniformTransform3(Sub(property, name));
        public static Matrix3x3Transform3 SubMatrix3x3Transform3(SerializedProperty property, string name) => PropertyToMatrix3x3Transform3(Sub(property, name));
        public static Matrix4x4Transform3 SubMatrix4x4Transform3(SerializedProperty property, string name) => PropertyToMatrix4x4Transform3(Sub(property, name));
        public static Aabb3M SubAabb3M(SerializedProperty property, string name) => PropertyToAabb3M(Sub(property, name));
        public static Aabb3S SubAabb3S(SerializedProperty property, string name) => PropertyToAabb3S(Sub(property, name));
        public static Aabb3C SubAabb3C(SerializedProperty property, string name) => PropertyToAabb3C(Sub(property, name));
        public static Obb3T SubObb3T(SerializedProperty property, string name) => PropertyToObb3T(Sub(property, name));
        public static Obb3M SubObb3M(SerializedProperty property, string name) => PropertyToObb3M(Sub(property, name));
    }

}