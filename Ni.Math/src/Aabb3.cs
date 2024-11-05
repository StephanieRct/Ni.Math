using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{





    //public static partial class NiMath
    //{
    //    public static bool Equal(Aabb3M a, Aabb3M b) => math.all(a.Min == b.Min & a.Max == b.Max);
    //    public static bool Equal(Aabb3S a, Aabb3S b) => math.all(a.Min == b.Min & a.Size == b.Size);
    //    public static bool Equal(Aabb3C a, Aabb3C b) => math.all(a.Center == b.Center & a.Extent == b.Extent);

    //    public static bool NearEqual(Aabb3M a, Aabb3M b, float margin) => math.all(math.abs(a.Min - b.Min) <= margin & math.abs(a.Max - b.Max) <= margin);
    //    public static bool NearEqual(Aabb3S a, Aabb3S b, float margin) => math.all(math.abs(a.Min - b.Min) <= margin & math.abs(a.Size - b.Size) <= margin);
    //    public static bool NearEqual(Aabb3C a, Aabb3C b, float margin) => math.all(math.abs(a.Center - b.Center) <= margin & math.abs(a.Extent - b.Extent) <= margin);

    //    public static Aabb3M Scale(float scale, Aabb3M o) => new Aabb3M(scale * o.Min, scale * o.Max);
    //    public static Aabb3S Scale(float scale, Aabb3S o) => new Aabb3S(scale * o.Min, scale * o.Size);
    //    public static Aabb3C Scale(float scale, Aabb3C o) => new Aabb3C(scale * o.Center, scale * o.Extent);
    //    public static Aabb3M Scale(float3 scale, Aabb3M o) => new Aabb3M(scale * o.Min, scale * o.Max);
    //    public static Aabb3S Scale(float3 scale, Aabb3S o) => new Aabb3S(scale * o.Min, scale * o.Size);
    //    public static Aabb3C Scale(float3 scale, Aabb3C o) => new Aabb3C(scale * o.Center, scale * o.Extent);

    //    public  static Aabb3M Translate(float3 translation, Aabb3M o) => new Aabb3M(translation + o.Min, translation + o.Max);
    //    public static Aabb3S Translate(float3 translation, Aabb3S o) => new Aabb3S(translation + o.Min, o.Size);
    //    public static Aabb3C Translate(float3 translation, Aabb3C o) => new Aabb3C(translation + o.Min, o.Extent);

    //    public static Aabb3M Inverse(Aabb3M a)
    //    {
    //        //return new Aabb3M(-a.Min / a.Size, (1 - a.Min) / a.Size);
    //        var sI = math.rcp(a.Size);
    //        var minI = sI * -a.Min;
    //        return new Aabb3M(minI, sI + minI);
    //    }
    //    public static Aabb3S Inverse(Aabb3S a)
    //    {
    //        //return new Aabb3S(-a.Min / a.Size, 1 / a.Size);
    //        var sI = math.rcp(a.Size);
    //        var minI = sI * -a.Min;
    //        return new Aabb3S(minI, sI);
    //    }
    //    public static Aabb3C Inverse(Aabb3C a)
    //    {
    //        //var sI = math.rcp(Size);
    //        //var minI = sI * -Min;
    //        //var maxI = sI + minI;

    //        // CenterI = (maxI + minI) * 0.5f
    //        // ExtentI = (maxI - minI) * 0.5f

    //        // CenterI = (maxI + minI) * 0.5f
    //        // CenterI = (maxI        + minI                ) * 0.5f
    //        // CenterI = (sI   + minI + sI * -Min           ) * 0.5f
    //        // CenterI = (sI   + minI - sI * (Center-Extent)) * 0.5f
    //        // CenterI = (sI   + sI * -(Center-Extent) - sI * (Center-Extent)) * 0.5f
    //        // CenterI = (sI   - 2 *                     sI * (Center-Extent)) * 0.5f
    //        // CenterI = ((1 / (2 * Extent)) - 2 * (1 / (2 * Extent)) * (Center-Extent)) * 0.5f
    //        // CenterI = ((1 / (2 * Extent)) -     (2 / (2 * Extent)) * (Center-Extent)) * 0.5f
    //        // CenterI = ((1 / (2 * Extent)) - (Center-Extent) / Extent            ) * 0.5f
    //        // CenterI =   1 / (4 * Extent)  - (Center-Extent) / (2 * Extent)
    //        // CenterI =   1 /  4f / Extent  - (Center-Extent) /  2 / Extent
    //        // CenterI = ( 1 /  4f           - (Center-Extent) /  2           ) / Extent
    //        // CenterI = ( 1/2f - (Center - Extent) ) / (2 * Extent)
    //        // CenterI = ( 0.5f -  Center + Extent  ) / (2 * Extent)
    //        // CenterI = ( 0.5f / (2 * Extent)) - (Center/ (2 * Extent)) + (Extent / (2 * Extent)) 
    //        // CenterI = ( 0.25f / Extent) - (Center/ (2 * Extent)) + 0.5f 
    //        // CenterI = 0.25f * ( (1/Extent) - (     Center / (0.5f * Extent)) ) + 0.5f 
    //        // CenterI = 0.25f * ( (1/Extent) - (2 *  Center /         Extent ) ) + 0.5f 
    //        // CenterI = 0.25f * ( (1/Extent) - (2 *  Center *       1/Extent ) ) + 0.5f 
    //        // CenterI = 0.25f * ( (1/Extent) - (2 * Center * 1/Extent ) )                + 0.5f 
    //        // CenterI = 0.25f * ( (1         - (2 * Center            ) ) * (1/Extent) ) + 0.5f 
    //        // CenterI = 0.25f * ( ( 1 - (2 * Center) ) * (1/Extent) ) + 0.5f 
    //        // CenterI = 0.25f *   ( 1 - (2 * Center) ) * (1/Extent)   + 0.5f 
    //        // CenterI = 0.25f * (1     - 2    * Center) * (1/Extent) + 0.5f 
    //        // CenterI =         (0.25f - 0.5f * Center) * (1/Extent) + 0.5f 
    //        // CenterI = (0.25f - 0.5f * Center) * (1/Extent) + 0.5f 

    //        // ExtentI = (maxI - minI) * 0.5f
    //        // ExtentI = (sI + minI + sI * (Center-Extent)) * 0.5f
    //        // ExtentI = (sI + sI * -(Center-Extent) + sI * (Center-Extent)) * 0.5f
    //        // ExtentI = (sI - sI *  (Center-Extent) + sI * (Center-Extent)) * 0.5f
    //        // ExtentI = 0.25f * 1 / Extent
    //        var eI = math.rcp(a.Extent);
    //        var extentI = 0.25f * eI;
    //        return new Aabb3C((1 - 2 * a.Center) * extentI + 0.5f, extentI);
    //    }


    //    public static float3 Transform(Aabb3M a, float3 p) => a.Min + p * a.Size;
    //    public static float3 Transform(Aabb3S a, float3 p) => a.Min + p * a.Size;
    //    public static float3 Transform(Aabb3C a, float3 p) => a.Min + p * a.Size;
    //    public static float3 Untransform(Aabb3M a, float3 p) => (p - a.Min) * math.rcp(a.Size);
    //    public static float3 Untransform(Aabb3S a, float3 p) => (p - a.Min) * math.rcp(a.Size);
    //    public static float3 Untransform(Aabb3C a, float3 p) => (p - a.Min) * math.rcp(a.Size);



    //    public static Aabb3M Transform(TranslationTransform t, Aabb3M p) => new Aabb3M(t.Transform(p.Min), t.Transform(p.Max));
    //    public static int Transform(RotationQTransform t, Aabb3M p) => throw new NotImplementedException();
    //    public static int Transform(UniformScaleTransform t, Aabb3M p) => throw new NotImplementedException();
    //    public static int Transform(NonUniformScaleTransform t, Aabb3M p) => throw new NotImplementedException();
    //    public static int Transform(RigidTransformNi t, Aabb3M p) => throw new NotImplementedException();
    //    public static int Transform(UniformTransform t, Aabb3M p) => throw new NotImplementedException();
    //    public static int Transform(NonUniformTransform t, Aabb3M p) => throw new NotImplementedException();
    //    public static int Transform(Matrix3x3Transform t, Aabb3M p) => throw new NotImplementedException();
    //    public static int Transform(Matrix4x4Transform t, Aabb3M p) => throw new NotImplementedException();


    //    public static Aabb3S Transform(TranslationTransform t, Aabb3S p) => new Aabb3S(t.Transform(p.Min), p.Size);
    //    public static int Transform(RotationQTransform t, Aabb3S p) => throw new NotImplementedException();
    //    public static int Transform(UniformScaleTransform t, Aabb3S p) => throw new NotImplementedException();
    //    public static int Transform(NonUniformScaleTransform t, Aabb3S p) => throw new NotImplementedException();
    //    public static int Transform(RigidTransformNi t, Aabb3S p) => throw new NotImplementedException();
    //    public static int Transform(UniformTransform t, Aabb3S p) => throw new NotImplementedException();
    //    public static int Transform(NonUniformTransform t, Aabb3S p) => throw new NotImplementedException();
    //    public static int Transform(Matrix3x3Transform t, Aabb3S p) => throw new NotImplementedException();
    //    public static int Transform(Matrix4x4Transform t, Aabb3S p) => throw new NotImplementedException();

    //    public static Aabb3C Transform(TranslationTransform t, Aabb3C p) => new Aabb3C(t.Transform(p.Center), p.Extent);
    //    public static int Transform(RotationQTransform t, Aabb3C p) => throw new NotImplementedException();
    //    public static int Transform(UniformScaleTransform t, Aabb3C p) => throw new NotImplementedException();
    //    public static int Transform(NonUniformScaleTransform t, Aabb3C p) => throw new NotImplementedException();
    //    public static int Transform(RigidTransformNi t, Aabb3C p) => throw new NotImplementedException();
    //    public static int Transform(UniformTransform t, Aabb3C p) => throw new NotImplementedException();
    //    public static int Transform(NonUniformTransform t, Aabb3C p) => throw new NotImplementedException();
    //    public static int Transform(Matrix3x3Transform t, Aabb3C p) => throw new NotImplementedException();
    //    public static int Transform(Matrix4x4Transform t, Aabb3C p) => throw new NotImplementedException();




    //}
}