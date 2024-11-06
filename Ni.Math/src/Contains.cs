using Unity.Mathematics;

namespace Ni.Mathematics
{
    public static partial class NiMath
    {
        public static bool Contain(float3 point) => math.all(point >= float3.zero & point <= 1);
        public static bool Contain(Matrix3x3Transform3 o, float3 point) => Contain(o.Untransform(point));
        public static bool Contain(Aabb3M o, float3 point) => math.all(point >= o.min & point < o.max);
        public static bool Contain(Aabb3S o, float3 point) => math.all(point >= o.min & point < o.max);
        public static bool Contain(Aabb3C o, float3 point) => math.all(point >= o.min & point < o.max);
        public static bool Contain(Obb3T o, float3 point) => Contain(o.Untransform(point));
        public static bool Contain(Obb3M o, float3 point) => Contain(o.Untransform(point));
    }
}