using Unity.Mathematics;

namespace Ni.Mathematics
{

    public static partial class NiMath
    {
        struct Ray3IntersectBox3
        {
            public Ray3 Ray;
            public float MaxDistance;
            public bool Hit;
            public float3 tmin;
            public float3 tmax;
            public float3 mins;
            public float3 maxs;
            public float tIn;
            public float tOut;
            public Ray3IntersectBox3(Ray3 ray, float maxDistance)
            {
                Ray = ray;
                MaxDistance = maxDistance;
                tmin = -ray.origin / ray.direction;
                tmax = (1 - ray.origin) / ray.direction;
                mins = math.min(tmin, tmax);
                maxs = math.max(tmin, tmax);
                tIn = math.max(math.max(mins.x, mins.y), mins.z);
                tOut = math.min(math.min(maxs.x, maxs.y), maxs.z);
                Hit = (tIn < tOut && tOut >= 0 && tIn < maxDistance);
            }
            public Ray3IntersectBox3(Ray3 ray, float maxDistance, Aabb3M box)
            {
                Ray = ray;
                MaxDistance = maxDistance;
                tmin = (box.min - ray.origin) / ray.direction;
                tmax = (box.max - ray.origin) / ray.direction;
                mins = math.min(tmin, tmax);
                maxs = math.max(tmin, tmax);
                tIn = math.max(math.max(mins.x, mins.y), mins.z);
                tOut = math.min(math.min(maxs.x, maxs.y), maxs.z);
                Hit = (tIn < tOut && tOut >= 0 && tIn < maxDistance);
            }
            public Direction3 ComputeNormalIn() => new Direction3(-math.sign(Ray.direction) * math.step(mins.yzx, mins.xyz) * math.step(mins.zxy, mins.xyz));
            public Direction3 ComputeNormalOut() => new Direction3(math.sign(Ray.direction) * math.step(maxs.xyz, maxs.yzx) * math.step(maxs.xyz, maxs.zxy));
            //public Direction3 ComputeNormalOut() => new Direction3(-math.sign(Ray.direction) * math.step(maxs.yzx, maxs.xyz) * math.step(maxs.zxy, maxs.xyz));

        }

        public static bool IntersectBoxIdentity(Ray3 ray, float maxDistance, out float t)
        {
            var raycastBox = new Ray3IntersectBox3(ray, maxDistance);
            t = raycastBox.tIn;
            return raycastBox.Hit;
        }

        public static bool IntersectBoxIdentity(Ray3 ray, float maxDistance, out float tIn, out float tOut)
        {
            var raycastBox = new Ray3IntersectBox3(ray, maxDistance);
            tIn = raycastBox.tIn;
            tOut = raycastBox.tOut;
            return raycastBox.Hit;
        }

        public static bool IntersectBoxIdentity(Ray3 ray, float maxDistance, out float t, out Direction3 normal)
        {
            var raycastBox = new Ray3IntersectBox3(ray, maxDistance);
            t = raycastBox.tIn;
            normal = raycastBox.ComputeNormalIn();
            return raycastBox.Hit;
        }

        public static bool IntersectBoxIdentity(Ray3 ray, float maxDistance, out float tIn, out Direction3 normalIn, out float tOut, out Direction3 normalOut)
        {
            var raycastBox = new Ray3IntersectBox3(ray, maxDistance);
            tIn = raycastBox.tIn;
            tOut = raycastBox.tOut;
            normalIn = raycastBox.ComputeNormalIn();
            normalOut = raycastBox.ComputeNormalOut();
            return raycastBox.Hit;
        }

        public static bool IntersectBoxIdentity(Ray3 ray, float maxDistance, out float3 point)
        {
            var raycastBox = new Ray3IntersectBox3(ray, maxDistance);
            point = raycastBox.Hit ? ray[raycastBox.tIn] : default;
            return raycastBox.Hit;
        }

        public static bool IntersectBoxIdentity(Ray3 ray, float maxDistance, out LineSegment3 intersection)
        {
            var raycastBox = new Ray3IntersectBox3(ray, maxDistance);
            intersection = raycastBox.Hit ? new LineSegment3(ray[raycastBox.tIn], ray[raycastBox.tOut]) : default;
            return raycastBox.Hit;
        }

        public static bool IntersectBoxIdentity(Ray3 ray, float maxDistance, out Ray3 pointNormal)
        {
            var raycastBox = new Ray3IntersectBox3(ray, maxDistance);
            pointNormal = raycastBox.Hit ? new Ray3(ray[raycastBox.tIn], raycastBox.ComputeNormalIn()) : default;
            return raycastBox.Hit;
        }

        public static bool IntersectBoxIdentity(Ray3 ray, float maxDistance, out Ray3 pointNormalIn, out Ray3 pointNormalOut)
        {
            var raycastBox = new Ray3IntersectBox3(ray, maxDistance);
            pointNormalIn = raycastBox.Hit ? new Ray3(ray[raycastBox.tIn], raycastBox.ComputeNormalIn()) : default;
            pointNormalOut = raycastBox.Hit ? new Ray3(ray[raycastBox.tOut], raycastBox.ComputeNormalOut()) : default;
            return raycastBox.Hit;
        }

        public static bool IntersectBox(Ray3 ray, Aabb3M o, float maxDistance, out float t)
        {
            var raycastBox = new Ray3IntersectBox3(ray, maxDistance, o);
            t = raycastBox.tIn;
            return raycastBox.Hit;
        }

        public static bool IntersectBox(Ray3 ray, Aabb3M o, float maxDistance, out float tIn, out float tOut)
        {
            var raycastBox = new Ray3IntersectBox3(ray, maxDistance, o);
            tIn = raycastBox.tIn;
            tOut = raycastBox.tOut;
            return raycastBox.Hit;
        }

        public static bool IntersectBox(Ray3 ray, Aabb3M o, float maxDistance, out float t, out Direction3 normal)
        {
            var raycastBox = new Ray3IntersectBox3(ray, maxDistance, o);
            t = raycastBox.tIn;
            normal = raycastBox.ComputeNormalIn();
            return raycastBox.Hit;
        }

        public static bool IntersectBox(Ray3 ray, Aabb3M o, float maxDistance, out float tIn, out Direction3 normalIn, out float tOut, out Direction3 normalOut)
        {
            var raycastBox = new Ray3IntersectBox3(ray, maxDistance, o);
            tIn = raycastBox.tIn;
            tOut = raycastBox.tOut;
            normalIn = raycastBox.ComputeNormalIn();
            normalOut = raycastBox.ComputeNormalOut();
            return raycastBox.Hit;
        }

        public static bool IntersectBox(Ray3 ray, Aabb3M o, float maxDistance, out float3 point)
        {
            var raycastBox = new Ray3IntersectBox3(ray, maxDistance, o);
            point = raycastBox.Hit ? ray[raycastBox.tIn] : default;
            return raycastBox.Hit;
        }

        public static bool IntersectBox(Ray3 ray, Aabb3M o, float maxDistance, out LineSegment3 intersection)
        {
            var raycastBox = new Ray3IntersectBox3(ray, maxDistance, o);
            intersection = raycastBox.Hit ? new LineSegment3(ray[raycastBox.tIn], ray[raycastBox.tOut]) : default;
            return raycastBox.Hit;
        }

        public static bool IntersectBox(Ray3 ray, Aabb3M o, float maxDistance, out Ray3 pointNormal)
        {
            var raycastBox = new Ray3IntersectBox3(ray, maxDistance, o);
            pointNormal = raycastBox.Hit ? new Ray3(raycastBox.tIn, raycastBox.ComputeNormalIn()) : default;
            return raycastBox.Hit;
        }

        public static bool IntersectBox(Ray3 ray, Aabb3M o, float maxDistance, out Ray3 pointNormalIn, out Ray3 pointNormalOut)
        {
            var raycastBox = new Ray3IntersectBox3(ray, maxDistance, o);
            pointNormalIn = raycastBox.Hit ? new Ray3(raycastBox.tIn, raycastBox.ComputeNormalIn()) : default;
            pointNormalOut = raycastBox.Hit ? new Ray3(raycastBox.tOut, raycastBox.ComputeNormalOut()) : default;
            return raycastBox.Hit;
        }

        public static bool IntersectBox(Ray3 ray, Aabb3S o, float maxDistance, out float t) => IntersectBox(ray, (Aabb3M)o, maxDistance, out t);
        public static bool IntersectBox(Ray3 ray, Aabb3S o, float maxDistance, out float tIn, out float tOut) => IntersectBox(ray, (Aabb3M)o, maxDistance, out tIn, out tOut);
        public static bool IntersectBox(Ray3 ray, Aabb3S o, float maxDistance, out float t, out Direction3 normal) => IntersectBox(ray, (Aabb3M)o, maxDistance, out t, out normal);
        public static bool IntersectBox(Ray3 ray, Aabb3S o, float maxDistance, out float tIn, out Direction3 normalIn, out float tOut, out Direction3 normalOut) => IntersectBox(ray, (Aabb3M)o, maxDistance, out tIn, out normalIn, out tOut, out normalOut);
        public static bool IntersectBox(Ray3 ray, Aabb3S o, float maxDistance, out float3 point) => IntersectBox(ray, (Aabb3M)o, maxDistance, out point);
        public static bool IntersectBox(Ray3 ray, Aabb3S o, float maxDistance, out LineSegment3 intersection) => IntersectBox(ray, (Aabb3M)o, maxDistance, out intersection);
        public static bool IntersectBox(Ray3 ray, Aabb3S o, float maxDistance, out Ray3 pointNormal) => IntersectBox(ray, (Aabb3M)o, maxDistance, out pointNormal);
        public static bool IntersectBox(Ray3 ray, Aabb3S o, float maxDistance, out Ray3 pointNormalIn, out Ray3 pointNormalOut) => IntersectBox(ray, (Aabb3M)o, maxDistance, out pointNormalIn, out pointNormalOut);
        public static bool IntersectBox(Ray3 ray, Aabb3C o, float maxDistance, out float t) => IntersectBox(ray, (Aabb3M)o, maxDistance, out t);
        public static bool IntersectBox(Ray3 ray, Aabb3C o, float maxDistance, out float tIn, out float tOut) => IntersectBox(ray, (Aabb3M)o, maxDistance, out tIn, out tOut);
        public static bool IntersectBox(Ray3 ray, Aabb3C o, float maxDistance, out float t, out Direction3 normal) => IntersectBox(ray, (Aabb3M)o, maxDistance, out t, out normal);
        public static bool IntersectBox(Ray3 ray, Aabb3C o, float maxDistance, out float tIn, out Direction3 normalIn, out float tOut, out Direction3 normalOut) => IntersectBox(ray, (Aabb3M)o, maxDistance, out tIn, out normalIn, out tOut, out normalOut);
        public static bool IntersectBox(Ray3 ray, Aabb3C o, float maxDistance, out float3 point) => IntersectBox(ray, (Aabb3M)o, maxDistance, out point);
        public static bool IntersectBox(Ray3 ray, Aabb3C o, float maxDistance, out LineSegment3 intersection) => IntersectBox(ray, (Aabb3M)o, maxDistance, out intersection);
        public static bool IntersectBox(Ray3 ray, Aabb3C o, float maxDistance, out Ray3 pointNormal) => IntersectBox(ray, (Aabb3M)o, maxDistance, out pointNormal);
        public static bool IntersectBox(Ray3 ray, Aabb3C o, float maxDistance, out Ray3 pointNormalIn, out Ray3 pointNormalOut) => IntersectBox(ray, (Aabb3M)o, maxDistance, out pointNormalIn, out pointNormalOut);

        public static bool IntersectBox<TBox>(Ray3 ray, TBox o, float maxDistance, out float t)
            where TBox : IBox3
            => IntersectBoxIdentity(o.Untransform(ray), maxDistance, out t);

        public static bool IntersectBox<TBox>(Ray3 ray, TBox o, float maxDistance, out float t, out Direction3 normal)
            where TBox : IBox3
        {
            var result = IntersectBoxIdentity(o.Untransform(ray), maxDistance, out t, out normal);
            normal = o.Transform(normal);
            return result;
        }

        public static bool IntersectBox<TBox>(Ray3 ray, TBox o, float maxDistance, out float tIn, out float tOut)
            where TBox : IBox3
            => IntersectBoxIdentity(o.Untransform(ray), maxDistance, out tIn, out tOut);

        public static bool IntersectBox<TBox>(Ray3 ray, TBox o, float maxDistance, out float tIn, out Direction3 normalIn, out float tOut, out Direction3 normalOut)
            where TBox : IBox3
        {
            var result = IntersectBoxIdentity(o.Untransform(ray), maxDistance, out tIn, out normalIn, out tOut, out normalOut);
            normalIn = o.Transform(normalIn);
            normalOut = o.Transform(normalOut);
            return result;
        }

        public static bool IntersectBox<TBox>(Ray3 ray, TBox o, float maxDistance, out float3 point)
            where TBox : IBox3
            => IntersectBoxIdentity(o.Untransform(ray), maxDistance, out point);

        public static bool IntersectBox<TBox>(Ray3 ray, TBox o, float maxDistance, out LineSegment3 intersection)
            where TBox : IBox3
            => IntersectBoxIdentity(o.Untransform(ray), maxDistance, out intersection);

        public static bool IntersectBox<TBox>(Ray3 ray, TBox o, float maxDistance, out Ray3 pointNormal)
            where TBox : IBox3
        {
            var result = IntersectBoxIdentity(o.Untransform(ray), maxDistance, out pointNormal);
            pointNormal = o.Transform(pointNormal);
            return result;
        }

        public static bool IntersectBox<TBox>(Ray3 ray, TBox o, float maxDistance, out Ray3 pointNormalIn, out Ray3 pointNormalOut)
            where TBox : IBox3
        {
            var result = IntersectBoxIdentity(o.Untransform(ray), maxDistance, out pointNormalIn, out pointNormalOut);
            pointNormalIn = o.Transform(pointNormalIn);
            pointNormalOut = o.Transform(pointNormalOut);
            return result;
        }
    }
}