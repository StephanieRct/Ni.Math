using Unity.Mathematics;

namespace Ni.Mathematics
{
    public static partial class NiMath
    {
        public static bool RaycastIdentity1(Ray3 ray, float maxDistance, out float t)
        {
            float3 tmin = -ray.origin / ray.direction;
            float3 tmax = (1 - ray.origin) / ray.direction;
            float3 sc = math.min(tmin, tmax);
            float3 sf = math.max(tmin, tmax);
            t = math.max(math.max(sc.x, sc.y), sc.z);
            float t1 = math.min(math.min(sf.x, sf.y), sf.z);
            if (t > t1 || t1 <= 0 || t > maxDistance)
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
            if (t > t1 || t1 <= 0 || t > maxDistance)
                return false;
            return true;
        }

        public static bool Raycast1(Ray3 ray, Aabb3S aabb, float maxDistance, out float t) => Raycast1(ray, (Aabb3M)aabb, maxDistance, out t);
        public static bool Raycast1(Ray3 ray, Aabb3C aabb, float maxDistance, out float t) => Raycast1(ray, (Aabb3M)aabb, maxDistance, out t);
        public static bool Raycast1<T>(Ray3 ray, T o, float maxDistance, out float t) where T : ITransform<Ray3> => RaycastIdentity1(o.Untransform(ray), maxDistance, out t);

    }
}