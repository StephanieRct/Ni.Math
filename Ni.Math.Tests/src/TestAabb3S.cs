using Ni.Mathematics;
using NUnit.Framework;
using Unity.Mathematics;

namespace Ni.Mathematics.Tests
{
    public class TestAabb3S : TransformTests
    {
        [Test] public void CtorMinSize() => TestCtor<Aabb3S>("float3 min, float3 size", new Aabb3S(Aabb3S0_Min, Aabb3S0_Size), M4Aabb3S0);
        [Test] public void CtorTranslationScale() => TestCtor<Aabb3S>("TranslationTransform3 translation, ScaleNonUniformTransform3 scale", new Aabb3S(Aabb3S0_TT, Aabb3S0_ST), M4Aabb3S0);
        [Test] public void Identity() => TestIdentity<Aabb3S>(Aabb3S.Identity);
        [Test] public void Inversed() => TestInversed<Aabb3S>(Aabb3S0, M4Aabb3Si0);
        [Test] public void Translated() => TestTranslated<Aabb3S>(Aabb3S0, Translation, M4(M4Translation, M4Aabb3S0));
        [Test] public void Rotated() => TestRotated<Aabb3S, Obb3T>(Aabb3S0, Rotation, M4(M4Rotation, M4Aabb3S0));
        [Test] public void Scaled1() => TestScaled1<Aabb3S>(Aabb3S0, Scale1, M4(M4Scale1, M4Aabb3S0));
        [Test] public void Scaled3() => TestScaled3<Aabb3S>(Aabb3S0, Scale3, M4(M4Scale3, M4Aabb3S0));
        [Test] public void TestTranslate() => TestTranslate<Aabb3S, Aabb3S>(Aabb3S0, Translation, M4(M4Aabb3S0, M4Translation));
        [Test] public void TestRotate() => TestRotate<Aabb3S, Obb3M>(Aabb3S0, Rotation, M4(M4Aabb3S0, M4Rotation));
        [Test] public void TestScale1() => TestScaleFloat<Aabb3S, Aabb3S>(Aabb3S0, Scale1, M4(M4Aabb3S0, M4Scale1));
        [Test] public void TestScale3() => TestScaleFloat3<Aabb3S, Aabb3S>(Aabb3S0, Scale3, M4(M4Aabb3S0, M4Scale3));
        [Test] public void MulTranslationTransform() => TestMul<Aabb3S, Translation3, Aabb3S>(Aabb3S0, TT1, M4(M4Aabb3S0, M4TT1));
        [Test] public void MulRotationQTransform() => TestMul<Aabb3S, Rotation3Q, Obb3M>(Aabb3S0, RQT1, M4(M4Aabb3S0, M4RQT1));
        [Test] public void MulUniformScaleTransform() => TestMul<Aabb3S, Scale1, Aabb3S>(Aabb3S0, UST1, M4(M4Aabb3S0, M4UST1));
        [Test] public void MulNonUniformScaleTransform() => TestMul<Aabb3S, Scale3, Aabb3S>(Aabb3S0, NUST1, M4(M4Aabb3S0, M4NUST1));
        [Test] public void MulRigidTransformNi() => TestMul<Aabb3S, RigidTransform3, Obb3M>(Aabb3S0, RT1, M4(M4Aabb3S0, M4RT1));
        [Test] public void MulUniformTransform() => TestMul<Aabb3S, UniformTransform3, Obb3M>(Aabb3S0, UT1, M4(M4Aabb3S0, M4UT1));
        [Test] public void MulNonUniformTransform() => TestMul<Aabb3S, NonUniformTransform3, Obb3M>(Aabb3S0, NUT1, M4(M4Aabb3S0, M4NUT1));
        [Test] public void MulMatrix3x3Transform() => TestMul<Aabb3S, Matrix3x3Transform3, Obb3M>(Aabb3S0, M3T1, M4(M4Aabb3S0, M4M3T1));
        [Test] public void MulMatrix4x4Transform() => TestMul<Aabb3S, Matrix4x4Transform3, Obb3M>(Aabb3S0, M4T1, M4(M4Aabb3S0, M4M4T1));
        [Test] public void DivTranslationTransform() => TestDiv<Aabb3S, Translation3, Aabb3S>(Aabb3S0, TT1, M4(M4Aabb3Si0, M4TT1));
        [Test] public void DivRotationQTransform() => TestDiv<Aabb3S, Rotation3Q, Obb3M>(Aabb3S0, RQT1, M4(M4Aabb3Si0, M4RQT1));
        [Test] public void DivUniformScaleTransform() => TestDiv<Aabb3S, Scale1, Aabb3S>(Aabb3S0, UST1, M4(M4Aabb3Si0, M4UST1));
        [Test] public void DivNonUniformScaleTransform() => TestDiv<Aabb3S, Scale3, Aabb3S>(Aabb3S0, NUST1, M4(M4Aabb3Si0, M4NUST1));
        [Test] public void DivRigidTransformNi() => TestDiv<Aabb3S, RigidTransform3, Obb3M>(Aabb3S0, RT1, M4(M4Aabb3Si0, M4RT1));
        [Test] public void DivUniformTransform() => TestDiv<Aabb3S, UniformTransform3, Obb3M>(Aabb3S0, UT1, M4(M4Aabb3Si0, M4UT1));
        [Test] public void DivNonUniformTransform() => TestDiv<Aabb3S, NonUniformTransform3, Obb3M>(Aabb3S0, NUT1, M4(M4Aabb3Si0, M4NUT1));
        [Test] public void DivMatrix3x3Transform() => TestDiv<Aabb3S, Matrix3x3Transform3, Obb3M>(Aabb3S0, M3T1, M4(M4Aabb3Si0, M4M3T1));
        [Test] public void DivMatrix4x4Transform() => TestDiv<Aabb3S, Matrix4x4Transform3, Obb3M>(Aabb3S0, M4T1, M4(M4Aabb3Si0, M4M4T1));
        [Test] public void TransformFloat3() => TestTransformFloat3(Aabb3S0, Float3, M4(M4Aabb3S0, Float3));
        [Test] public void UntransformFloat3() => TestUntransformFloat3(Aabb3S0, Float3, M4(M4Aabb3Si0, Float3));
    }

    public partial class TransformTests
    {
        public static readonly float3 Aabb3S0_Min = new float3(3.2f, -4.5f, 6.8f);
        public static readonly float3 Aabb3S0_Size = new float3(7.7f, -5.8f, 2.6f);
        public static readonly float3 Aabb3S1_Min = new float3(1.8f, 2.4f, -1.7f);
        public static readonly float3 Aabb3S1_Size = new float3(3.7f, -5.8f, 2.6f);

        public static readonly Aabb3S Aabb3S0 = new Aabb3S(Aabb3S0_Min, Aabb3S0_Size);
        public static readonly Aabb3S Aabb3S1 = new Aabb3S(Aabb3S1_Min, Aabb3S1_Size);


        public static readonly float4x4 M4Aabb3S0 = Aabb3S0.ToMatrix4x4Transform3;
        public static readonly float4x4 M4Aabb3S1 = Aabb3S1.ToMatrix4x4Transform3;
        public static readonly float4x4 M4Aabb3Si0 = math.inverse(Aabb3S0.ToMatrix4x4Transform3);
        public static readonly float4x4 M4Aabb3Si1 = math.inverse(Aabb3S1.ToMatrix4x4Transform3);


        public static readonly float3 Aabb3S0_T = Aabb3S0_Min;
        public static readonly float3 Aabb3S0_S = Aabb3S0_Size;
        public static readonly float3 Aabb3Si0_T = -Aabb3S0_Min;
        public static readonly float3 Aabb3Si0_S = math.rcp(Aabb3S0_Size);

        public static readonly Translation3 Aabb3S0_TT = new Translation3(Aabb3S0_T);
        public static readonly Scale3 Aabb3S0_ST = new Scale3(Aabb3S0_S);
    }
}