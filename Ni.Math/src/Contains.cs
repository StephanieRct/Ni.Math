using Unity.Mathematics;

namespace Ni.Mathematics
{
    public static partial class NiMath
    {
        public static bool Contain(Aabb3M primitive, float3 point)
            => math.all(point >= primitive.min & point < primitive.max);

        //public static bool Contain(Obb3TI primitive, float3 point)
        //{
        //    var pointT = math.transform(primitive.InverseMatrix, point);
        //    return Contain(Aabb3M.Unit, pointT);
        //}

        //public static bool Contain(Obb3RI primitive, float3 point)
        //{
        //    var pointT = math.transform(primitive.InverseRigidTransform, point);
        //    return Contain(primitive.Bound, pointT);
        //}
    }
}