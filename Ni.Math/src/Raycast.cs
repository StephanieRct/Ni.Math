using Unity.Mathematics;

namespace Ni.Mathematics
{
    public static partial class NiMath
    {
        // https://www.researchgate.net/publication/354065095_Fast_and_Robust_RayOBB_Intersection_Using_the_Lorentz_Transformation
        public static bool RaycastIdentity1(Ray3 ray, float maxDistance, out float t)
        {
            float3 tmin = -ray.origin / ray.direction;
            float3 tmax = (1 - ray.origin) / ray.direction;
            float3 sc = math.min(tmin, tmax);
            float3 sf = math.max(tmin, tmax);
            t = math.max(math.max(sc.x, sc.y), sc.z);
            float t1 = math.min(math.min(sf.x, sf.y), sf.z);
            if (t > t1 || t1 <= 0 || t > maxDistance) //if (!(t0 <= t1 && t1 > 0))
                return false;
            return true;
        }
        public static bool Raycast1(Ray3 ray, Aabb3M aabb, float maxDistance, out float t)
        {
            float3 tmin = (aabb.min - ray.origin) / ray.direction;
            float3 tmax = (aabb.max - ray.origin) / ray.direction;
            float3 sc = math.min(tmin, tmax);
            float3 sf = math.max(tmin, tmax);
            t = math.max(math.max(sc.x, sc.y), sc.z);
            float t1 = math.min(math.min(sf.x, sf.y), sf.z);
            if (t > t1 || t1 <= 0 || t > maxDistance) //if (!(t0 <= t1 && t1 > 0))
                return false;
            return true;
        }

        public static bool Raycast1(Ray3 ray, Aabb3S aabb, float maxDistance, out float t) => Raycast1(ray, (Aabb3M)aabb, maxDistance, out t);
        public static bool Raycast1(Ray3 ray, Aabb3C aabb, float maxDistance, out float t) => Raycast1(ray, (Aabb3M)aabb, maxDistance, out t);
        public static bool Raycast1<T>(Ray3 ray, T o, float maxDistance, out float t) where T : ITransform<Ray3> => RaycastIdentity1(o.Untransform(ray), maxDistance, out t);

        //public static bool RaycastT(Obb3TI obb, Ray3 ray, float maxDistance, out float t)
        //{
        //    var rayT = Transform(obb.InverseMatrix, ray);
        //    return RaycastT(rayT, Aabb3M.Unit, maxDistance, out t);

        //}
        //public static bool Raycast(Obb3TI primitive, Ray3 ray, float maxDistance, out float3 hit)
        //{
        //    if (RaycastT(primitive, ray, maxDistance, out var t))
        //    {
        //        hit = ray[t];
        //        return true;
        //    }
        //    hit = default;
        //    return false;

        //}
        //public static bool RaycastT(Obb3RI obb, Ray3 ray, float maxDistance, out float t)
        //{
        //    var rayT = Transform(obb.InverseRigidTransform, ray);
        //    return RaycastT(rayT, obb.Bound, maxDistance, out t);

        //}
        //public static bool Raycast(Obb3RI primitive, Ray3 ray, float maxDistance, out float3 hit)
        //{
        //    if (RaycastT(primitive, ray, maxDistance, out var t))
        //    {
        //        hit = ray[t];
        //        return true;
        //    }
        //    hit = default;
        //    return false;

        //}

    }
}