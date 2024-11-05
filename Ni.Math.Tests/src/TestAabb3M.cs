using Ni.Mathematics;
using NUnit.Framework;
using Unity.Mathematics;

namespace Ni.Mathematics.Tests
{
    public class TestAabb3M : TransformTests
    {
        [Test] public void CtorMinMax() => TestCtor<Aabb3M>("float3 min, float3 max", new Aabb3M(Aabb3M0_Min, Aabb3M0_Max), M4Aabb3M0);
        [Test] public void CtorTranslationScale() => TestCtor<Aabb3M>("TranslationTransform3 translation, ScaleNonUniformTransform3 scale", new Aabb3M(Aabb3M0_TT, Aabb3M0_ST), M4Aabb3M0);
        [Test] public void Identity() => TestIdentity<Aabb3M>(Aabb3M.Identity);
        [Test] public void Inversed() => TestInversed<Aabb3M>(Aabb3M0, M4Aabb3Mi0);
        [Test] public void Translated() => TestTranslated<Aabb3M>(Aabb3M0, Translation, M4(M4Translation, M4Aabb3M0));
        [Test] public void Rotated() => TestRotated<Aabb3M, Obb3T>(Aabb3M0, Rotation, M4(M4Rotation, M4Aabb3M0));
        [Test] public void Scaled1() => TestScaled1<Aabb3M>(Aabb3M0, Scale1, M4(M4Scale1, M4Aabb3M0));
        [Test] public void Scaled3() => TestScaled3<Aabb3M>(Aabb3M0, Scale3, M4(M4Scale3, M4Aabb3M0));
        [Test] public void TestTranslate() => TestTranslate<Aabb3M, Aabb3M>(Aabb3M0, Translation, M4(M4Aabb3M0, M4Translation));
        [Test] public void TestRotate() => TestRotate<Aabb3M, Obb3M>(Aabb3M0, Rotation, M4(M4Aabb3M0, M4Rotation));
        [Test] public void TestScale1() => TestScaleFloat<Aabb3M, Aabb3M>(Aabb3M0, Scale1, M4(M4Aabb3M0, M4Scale1));
        [Test] public void TestScale3() => TestScaleFloat3<Aabb3M, Aabb3M>(Aabb3M0, Scale3, M4(M4Aabb3M0, M4Scale3));
        [Test] public void MulTranslationTransform() => TestMul<Aabb3M, Translation3, Aabb3M>(Aabb3M0, TT1, M4(M4Aabb3M0, M4TT1));
        [Test] public void MulRotationQTransform() => TestMul<Aabb3M, Rotation3Q, Obb3M>(Aabb3M0, RQT1, M4(M4Aabb3M0, M4RQT1));
        [Test] public void MulUniformScaleTransform() => TestMul<Aabb3M, Scale1, Aabb3M>(Aabb3M0, UST1, M4(M4Aabb3M0, M4UST1));
        [Test] public void MulNonUniformScaleTransform() => TestMul<Aabb3M, Scale3, Aabb3M>(Aabb3M0, NUST1, M4(M4Aabb3M0, M4NUST1));
        [Test] public void MulRigidTransformNi() => TestMul<Aabb3M, RigidTransform3, Obb3M>(Aabb3M0, RT1, M4(M4Aabb3M0, M4RT1));
        [Test] public void MulUniformTransform() => TestMul<Aabb3M, UniformTransform3, Obb3M>(Aabb3M0, UT1, M4(M4Aabb3M0, M4UT1));
        [Test] public void MulNonUniformTransform() => TestMul<Aabb3M, NonUniformTransform3, Obb3M>(Aabb3M0, NUT1, M4(M4Aabb3M0, M4NUT1));
        [Test] public void MulMatrix3x3Transform() => TestMul<Aabb3M, Matrix3x3Transform3, Obb3M>(Aabb3M0, M3T1, M4(M4Aabb3M0, M4M3T1));
        [Test] public void MulMatrix4x4Transform() => TestMul<Aabb3M, Matrix4x4Transform3, Obb3M>(Aabb3M0, M4T1, M4(M4Aabb3M0, M4M4T1));
        [Test] public void DivTranslationTransform() => TestDiv<Aabb3M, Translation3, Aabb3M>(Aabb3M0, TT1, M4(M4Aabb3Mi0, M4TT1));
        [Test] public void DivRotationQTransform() => TestDiv<Aabb3M, Rotation3Q, Obb3M>(Aabb3M0, RQT1, M4(M4Aabb3Mi0, M4RQT1));
        [Test] public void DivUniformScaleTransform() => TestDiv<Aabb3M, Scale1, Aabb3M>(Aabb3M0, UST1, M4(M4Aabb3Mi0, M4UST1));
        [Test] public void DivNonUniformScaleTransform() => TestDiv<Aabb3M, Scale3, Aabb3M>(Aabb3M0, NUST1, M4(M4Aabb3Mi0, M4NUST1));
        [Test] public void DivRigidTransformNi() => TestDiv<Aabb3M, RigidTransform3, Obb3M>(Aabb3M0, RT1, M4(M4Aabb3Mi0, M4RT1));
        [Test] public void DivUniformTransform() => TestDiv<Aabb3M, UniformTransform3, Obb3M>(Aabb3M0, UT1, M4(M4Aabb3Mi0, M4UT1));
        [Test] public void DivNonUniformTransform() => TestDiv<Aabb3M, NonUniformTransform3, Obb3M>(Aabb3M0, NUT1, M4(M4Aabb3Mi0, M4NUT1));
        [Test] public void DivMatrix3x3Transform() => TestDiv<Aabb3M, Matrix3x3Transform3, Obb3M>(Aabb3M0, M3T1, M4(M4Aabb3Mi0, M4M3T1));
        [Test] public void DivMatrix4x4Transform() => TestDiv<Aabb3M, Matrix4x4Transform3, Obb3M>(Aabb3M0, M4T1, M4(M4Aabb3Mi0, M4M4T1));
        [Test] public void TransformFloat3() => TestTransformFloat3(Aabb3M0, Float3, M4(M4Aabb3M0, Float3));
        [Test] public void UntransformFloat3() => TestUntransformFloat3(Aabb3M0, Float3, M4(M4Aabb3Mi0, Float3));
    }

    public partial class TransformTests
    {
        public static readonly float3 Aabb3M0_Min = new float3(3.2f, -4.5f, 6.8f);
        public static readonly float3 Aabb3M0_Max = new float3(7.7f, -5.8f, 2.6f);
        public static readonly float3 Aabb3M1_Min = new float3(1.8f, 2.4f, -1.7f);
        public static readonly float3 Aabb3M1_Max = new float3(3.7f, -5.8f, 2.6f);

        public static readonly Aabb3M Aabb3M0 = new Aabb3M(Aabb3M0_Min, Aabb3M0_Max);
        public static readonly Aabb3M Aabb3M1 = new Aabb3M(Aabb3M1_Min, Aabb3M1_Max);


        public static readonly float4x4 M4Aabb3M0 = Aabb3M0.ToMatrix4x4Transform;
        public static readonly float4x4 M4Aabb3M1 = Aabb3M1.ToMatrix4x4Transform;
        public static readonly float4x4 M4Aabb3Mi0 = math.inverse(Aabb3M0.ToMatrix4x4Transform);
        public static readonly float4x4 M4Aabb3Mi1 = math.inverse(Aabb3M1.ToMatrix4x4Transform);


        public static readonly float3 Aabb3M0_T = Aabb3M0_Min;
        public static readonly float3 Aabb3M0_S = Aabb3M0_Max - Aabb3M0_Min;
        public static readonly float3 Aabb3Mi0_T = -Aabb3M0_Min;
        public static readonly float3 Aabb3Mi0_S = math.rcp(Aabb3M0_Max - Aabb3M0_Min);

        public static readonly Translation3 Aabb3M0_TT = new Translation3(Aabb3M0_T);
        public static readonly Scale3 Aabb3M0_ST = new Scale3(Aabb3M0_S);
    }
}