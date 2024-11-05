using Ni.Mathematics;
using NUnit.Framework;
using Unity.Mathematics;

namespace Ni.Mathematics.Tests
{
    public class TestAabb3C : TransformTests
    {
        [Test] public void CtorCenterExtent() => TestCtor<Aabb3C>("float3 center, float3 extent", new Aabb3C(Aabb3C0_Center, Aabb3C0_Extent), M4Aabb3C0);
        [Test] public void CtorTranslationScale() => TestCtor<Aabb3C>("TranslationTransform3 translation, ScaleNonUniformTransform3 scale", new Aabb3C(Aabb3C0_TT, Aabb3C0_ST), M4Aabb3C0);
        [Test] public void Identity() => TestIdentity<Aabb3C>(Aabb3C.Identity);
        [Test] public void Inversed() => TestInversed<Aabb3C>(Aabb3C0, M4Aabb3Ci0);
        [Test] public void Translated() => TestTranslated<Aabb3C>(Aabb3C0, Translation, M4(M4Translation, M4Aabb3C0));
        [Test] public void Rotated() => TestRotated<Aabb3C, Obb3T>(Aabb3C0, Rotation, M4(M4Rotation, M4Aabb3C0));
        [Test] public void Scaled1() => TestScaled1<Aabb3C>(Aabb3C0, Scale1, M4(M4Scale1, M4Aabb3C0));
        [Test] public void Scaled3() => TestScaled3<Aabb3C>(Aabb3C0, Scale3, M4(M4Scale3, M4Aabb3C0));
        [Test] public void TestTranslate() => TestTranslate<Aabb3C, Aabb3C>(Aabb3C0, Translation, M4(M4Aabb3C0, M4Translation));
        [Test] public void TestRotate() => TestRotate<Aabb3C, Obb3M>(Aabb3C0, Rotation, M4(M4Aabb3C0, M4Rotation));
        [Test] public void TestScale1() => TestScaleFloat<Aabb3C, Aabb3C>(Aabb3C0, Scale1, M4(M4Aabb3C0, M4Scale1));
        [Test] public void TestScale3() => TestScaleFloat3<Aabb3C, Aabb3C>(Aabb3C0, Scale3, M4(M4Aabb3C0, M4Scale3));
        [Test] public void MulTranslationTransform() => TestMul<Aabb3C, Translation3, Aabb3C>(Aabb3C0, TT1, M4(M4Aabb3C0, M4TT1));
        [Test] public void MulRotationQTransform() => TestMul<Aabb3C, Rotation3Q, Obb3M>(Aabb3C0, RQT1, M4(M4Aabb3C0, M4RQT1));
        [Test] public void MulUniformScaleTransform() => TestMul<Aabb3C, Scale1, Aabb3C>(Aabb3C0, UST1, M4(M4Aabb3C0, M4UST1));
        [Test] public void MulNonUniformScaleTransform() => TestMul<Aabb3C, Scale3, Aabb3C>(Aabb3C0, NUST1, M4(M4Aabb3C0, M4NUST1));
        [Test] public void MulRigidTransformNi() => TestMul<Aabb3C, RigidTransform3, Obb3M>(Aabb3C0, RT1, M4(M4Aabb3C0, M4RT1));
        [Test] public void MulUniformTransform() => TestMul<Aabb3C, UniformTransform3, Obb3M>(Aabb3C0, UT1, M4(M4Aabb3C0, M4UT1));
        [Test] public void MulNonUniformTransform() => TestMul<Aabb3C, NonUniformTransform3, Obb3M>(Aabb3C0, NUT1, M4(M4Aabb3C0, M4NUT1));
        [Test] public void MulMatrix3x3Transform() => TestMul<Aabb3C, Matrix3x3Transform3, Obb3M>(Aabb3C0, M3T1, M4(M4Aabb3C0, M4M3T1));
        [Test] public void MulMatrix4x4Transform() => TestMul<Aabb3C, Matrix4x4Transform3, Obb3M>(Aabb3C0, M4T1, M4(M4Aabb3C0, M4M4T1));
        [Test] public void DivTranslationTransform() => TestDiv<Aabb3C, Translation3, Aabb3C>(Aabb3C0, TT1, M4(M4Aabb3Ci0, M4TT1));
        [Test] public void DivRotationQTransform() => TestDiv<Aabb3C, Rotation3Q, Obb3M>(Aabb3C0, RQT1, M4(M4Aabb3Ci0, M4RQT1));
        [Test] public void DivUniformScaleTransform() => TestDiv<Aabb3C, Scale1, Aabb3C>(Aabb3C0, UST1, M4(M4Aabb3Ci0, M4UST1));
        [Test] public void DivNonUniformScaleTransform() => TestDiv<Aabb3C, Scale3, Aabb3C>(Aabb3C0, NUST1, M4(M4Aabb3Ci0, M4NUST1));
        [Test] public void DivRigidTransformNi() => TestDiv<Aabb3C, RigidTransform3, Obb3M>(Aabb3C0, RT1, M4(M4Aabb3Ci0, M4RT1));
        [Test] public void DivUniformTransform() => TestDiv<Aabb3C, UniformTransform3, Obb3M>(Aabb3C0, UT1, M4(M4Aabb3Ci0, M4UT1));
        [Test] public void DivNonUniformTransform() => TestDiv<Aabb3C, NonUniformTransform3, Obb3M>(Aabb3C0, NUT1, M4(M4Aabb3Ci0, M4NUT1));
        [Test] public void DivMatrix3x3Transform() => TestDiv<Aabb3C, Matrix3x3Transform3, Obb3M>(Aabb3C0, M3T1, M4(M4Aabb3Ci0, M4M3T1));
        [Test] public void DivMatrix4x4Transform() => TestDiv<Aabb3C, Matrix4x4Transform3, Obb3M>(Aabb3C0, M4T1, M4(M4Aabb3Ci0, M4M4T1));
        [Test] public void TransformFloat3() => TestTransformFloat3(Aabb3C0, Float3, M4(M4Aabb3C0, Float3));
        [Test] public void UntransformFloat3() => TestUntransformFloat3(Aabb3C0, Float3, M4(M4Aabb3Ci0, Float3));
    }

    public partial class TransformTests
    {
        public static readonly float3 Aabb3C0_Center = new float3(3.2f, -4.5f, 6.8f);
        public static readonly float3 Aabb3C0_Extent = new float3(7.7f, -5.8f, 2.6f);
        public static readonly float3 Aabb3C1_Center = new float3(1.8f, 2.4f, -1.7f);
        public static readonly float3 Aabb3C1_Extent = new float3(3.7f, -5.8f, 2.6f);

        public static readonly Aabb3C Aabb3C0 = new Aabb3C(Aabb3C0_Center, Aabb3C0_Extent);
        public static readonly Aabb3C Aabb3C1 = new Aabb3C(Aabb3C1_Center, Aabb3C1_Extent);


        public static readonly float4x4 M4Aabb3C0 = Aabb3C0.ToMatrix4x4Transform;
        public static readonly float4x4 M4Aabb3C1 = Aabb3C1.ToMatrix4x4Transform;
        public static readonly float4x4 M4Aabb3Ci0 = math.inverse(Aabb3C0.ToMatrix4x4Transform);
        public static readonly float4x4 M4Aabb3Ci1 = math.inverse(Aabb3C1.ToMatrix4x4Transform);


        public static readonly float3 Aabb3C0_T = Aabb3C0_Center - Aabb3C0_Extent;
        public static readonly float3 Aabb3C0_S = Aabb3C0_Extent * 2;
        public static readonly float3 Aabb3Ci0_T = -Aabb3C0_T;
        public static readonly float3 Aabb3Ci0_S = math.rcp(Aabb3C0_S);

        public static readonly Translation3 Aabb3C0_TT = new Translation3(Aabb3C0_T);
        public static readonly Scale3 Aabb3C0_ST = new Scale3(Aabb3C0_S);
    }
}