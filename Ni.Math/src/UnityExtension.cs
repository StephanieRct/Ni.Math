using Unity.Mathematics;
using UnityBounds = UnityEngine.Bounds;
using UnityBoxCollider = UnityEngine.BoxCollider;
using UnityTransform3 = UnityEngine.Transform;

namespace Ni.Mathematics
{
    public static partial class UnityExtension
    {
        public static Translation3 GetTranslation3(this UnityTransform3 transform) => new Translation3(transform.position);
        public static Rotation3Q GetRotation3(this UnityTransform3 transform) => new Rotation3Q(transform.rotation);
        public static Scale3 GetScale3(this UnityTransform3 transform) => new Scale3(transform.lossyScale);
        public static RigidTransform3 GetRigidTransform3(this UnityTransform3 transform) => new RigidTransform3(transform.position, transform.rotation);
        public static UniformTransform3 GetUniformTransform3(this UnityTransform3 transform) => new UniformTransform3(transform.position, transform.rotation, transform.lossyScale.x);
        public static NonUniformTransform3 GetNonUniformTransform3(this UnityTransform3 transform) => new NonUniformTransform3(transform.position, transform.rotation, transform.lossyScale);
        public static float4x4 GetFloat4x4(this UnityTransform3 transform) => float4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        public static Matrix4x4Transform3 GetMatrix4x4Transform3(this UnityTransform3 transform) => Matrix4x4Transform3.TRS(transform.position, transform.rotation, transform.lossyScale);

        public static Translation3 GetLocalTranslation3(this UnityTransform3 transform) => new Translation3(transform.localPosition);
        public static Rotation3Q GetLocalRotation3(this UnityTransform3 transform) => new Rotation3Q(transform.localRotation);
        public static Scale3 GetLocalScale3(this UnityTransform3 transform) => new Scale3(transform.localScale);
        public static RigidTransform3 GetLocalRigidTransform3(this UnityTransform3 transform) => new RigidTransform3(transform.localPosition, transform.localRotation);
        public static UniformTransform3 GetLocalUniformTransform3(this UnityTransform3 transform) => new UniformTransform3(transform.localPosition, transform.localRotation, transform.localScale.x);
        public static NonUniformTransform3 GetLocalNonUniformTransform3(this UnityTransform3 transform) => new NonUniformTransform3(transform.localPosition, transform.localRotation, transform.localScale);
        public static float4x4 GetLocalFloat4x4(this UnityTransform3 transform) => float4x4.TRS(transform.localPosition, transform.localRotation, transform.localScale);


        public static void SetWorldTranslation3(this UnityTransform3 transform, Translation3 o) => transform.position = o.translation;
        public static void SetWorldRotation3(this UnityTransform3 transform, Rotation3Q o) => transform.rotation = o.rotation;
        public static void SetWorldRigidTransform3(this UnityTransform3 transform, RigidTransform3 o) { transform.position = o.translation; transform.rotation = o.rotation; }
        public static void SetLocalTranslation3(this UnityTransform3 transform, Translation3 o) => transform.localPosition = o.translation;
        public static void SetLocalRotation3(this UnityTransform3 transform, Rotation3Q o) => transform.localRotation = o.rotation;
        public static void SetLocalScale3(this UnityTransform3 transform, Scale3 o) => transform.localScale = o.scale;
        public static void SetLocalRigidTransform3(this UnityTransform3 transform, RigidTransform3 o) { transform.localPosition = o.translation; transform.localRotation = o.rotation; }
        public static void SetLocalUniformTransform3(this UnityTransform3 transform, UniformTransform3 o) { transform.localPosition = o.translation; transform.localRotation = o.rotation; transform.localScale = (float3)o.scale; }
        public static void SetLocalNonUniformTransform3(this UnityTransform3 transform, NonUniformTransform3 o) { transform.localPosition = o.translation; transform.localRotation = o.rotation; transform.localScale = o.scale; }

        public static Aabb3M GetAabb3M(this UnityBounds bounds) => (Aabb3M)new Aabb3C(bounds.center, bounds.extents);
        public static Aabb3S GetAabb3S(this UnityBounds bounds) => (Aabb3S)new Aabb3C(bounds.center, bounds.extents);
        public static Aabb3C GetAabb3C(this UnityBounds bounds) => new Aabb3C(bounds.center, bounds.extents);
        public static Aabb3M GetLocalAabb3M(this UnityBoxCollider o) => GetAabb3M(o.bounds);
        public static Aabb3S GetLocalAabb3S(this UnityBoxCollider o) => GetAabb3S(o.bounds);
        public static Aabb3C GetLocalAabb3C(this UnityBoxCollider o) => GetAabb3C(o.bounds);
        public static Obb3T GetWorldObb3T(this UnityBoxCollider o) => NiMath.Mul(o.transform, GetAabb3C(o.bounds));


        public static void SetAabb3M(this UnityBounds a, Aabb3M b) => new UnityBounds(b.center, b.size);
        public static void SetAabb3S(this UnityBounds a, Aabb3S b) => new UnityBounds(b.center, b.size);
        public static void SetAabb3C(this UnityBounds a, Aabb3C b) => new UnityBounds(b.center, b.size);
        public static void SetLocalAabb3M(this UnityBoxCollider a, Aabb3M b) { a.center = b.center; a.size = b.size; }
        public static void SetLocalAabb3S(this UnityBoxCollider a, Aabb3S b) { a.center = b.center; a.size = b.size; }
        public static void SetLocalAabb3C(this UnityBoxCollider a, Aabb3C b) { a.center = b.center; a.size = b.size; }
        public static void SetWorldObb3T(this UnityBoxCollider a, Obb3T b) { a.transform.SetLocalRigidTransform3(b.TranslationRotation); a.SetLocalAabb3C(b.Aabb3C); }
    }
}