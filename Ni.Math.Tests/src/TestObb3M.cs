using Ni.Mathematics;
using NUnit.Framework;
using Unity.Mathematics;

namespace Ni.Mathematics.Tests
{
    public class TestObb3M : TransformTests
    {
        [Test] public void CtorFloat4x4() => TestCtor<Obb3M>("float4x4 matrix", new Obb3M(M40_4x4), M4M4T0);
        [Test] public void CtorMatrix4x4Transform() => TestCtor<Obb3M>("Matrix4x4Transform3 matrix", new Obb3M(M4T0), M4M4T0);
        [Test] public void CtorColumns() => TestCtor<Obb3M>("float4 column0, float4 column1, float4 column2, float4 column3", new Obb3M(M40C0, M40C1, M40C2, M40C3), new float4x4(M40C0, M40C1, M40C2, M40C3));
        [Test] public void CtorTranslationFloat3x3() => TestCtor<Obb3M>("float3 translation, float3x3 rotationScale", new Obb3M(M40_T, M30), new float4x4(M30, M40_T));
        [Test] public void CtorTranslationRotationScale1() => TestCtor<Obb3M>("float3 translation, quaternion rotation, float scale", new Obb3M(M40_T, M40_R, UST0_S), float4x4.TRS(M40_T, M40_R, UST0_S));
        [Test] public void CtorTranslationRotationScale3() => TestCtor<Obb3M>("float3 translation, quaternion rotation, float3 scale", new Obb3M(M40_T, M40_R, NUST0_S), float4x4.TRS(M40_T, M40_R, NUST0_S));
        [Test] public void CtorTranslationRotation() => TestCtor<Obb3M>("float3 translation, quaternion rotation", new Obb3M(M40_T, M40_R), float4x4.TRS(M40_T, M40_R, I_NUS));
        [Test] public void CtorTranslationScale1() => TestCtor<Obb3M>("float3 translation, float scale", new Obb3M(M40_T, UST0_S), float4x4.TRS(M40_T, I_R, UST0_S));
        [Test] public void CtorTranslationScale3() => TestCtor<Obb3M>("float3 translation, float3 scale", new Obb3M(M40_T, NUST0_S), float4x4.TRS(M40_T, I_R, NUST0_S));
        [Test] public void CtorRotationScale1() => TestCtor<Obb3M>("quaternion rotation, float scale", new Obb3M(M40_R, UST0_S), float4x4.TRS(I_T, M40_R, UST0_S));
        [Test] public void CtorRotationScale3() => TestCtor<Obb3M>("quaternion rotation, float3 scale", new Obb3M(M40_R, NUST0_S), float4x4.TRS(I_T, M40_R, NUST0_S));
        [Test] public void CtorRotation() => TestCtor<Obb3M>("quaternion rotation", new Obb3M(M40_R), float4x4.TRS(I_T, M40_R, I_US));
        [Test] public void CtorTranslationMatrix3x3Transform() => TestCtor<Obb3M>("TranslationTransform3 translation, Matrix3x3Transform3 rotationScale", new Obb3M(TT0, M3T0), new float4x4(M30, TT0_T));
        [Test] public void CtorTranslationRotationScale1Transform() => TestCtor<Obb3M>("TranslationTransform3 translation, RotationQTransform3 rotation, ScaleUniformTransform3 scale", new Obb3M(TT0, RQT0, UST0), float4x4.TRS(TT0_T, RQT0_R, UST0_S));
        [Test] public void CtorTranslationRotationScale3Transform() => TestCtor<Obb3M>("TranslationTransform3 translation, RotationQTransform3 rotation, ScaleNonUniformTransform3 scale", new Obb3M(TT0, RQT0, NUST0), float4x4.TRS(TT0_T, RQT0_R, NUST0_S));
        [Test] public void CtorTranslationRotationTransform() => TestCtor<Obb3M>("TranslationTransform3 translation, RotationQTransform3 rotation", new Obb3M(TT0, RQT0), float4x4.TRS(TT0_T, RQT0_R, I_US));
        [Test] public void CtorTranslationScale1Transform() => TestCtor<Obb3M>("TranslationTransform3 translation, ScaleUniformTransform3 scale", new Obb3M(TT0, UST0), float4x4.TRS(TT0_T, I_R, UST0_S));
        [Test] public void CtorTranslationScale3Transform() => TestCtor<Obb3M>("TranslationTransform3 translation, ScaleNonUniformTransform3 scale", new Obb3M(TT0, NUST0), float4x4.TRS(TT0_T, I_R, NUST0_S));
        [Test] public void CtorRotationScale1Transform() => TestCtor<Obb3M>("RotationQTransform3 rotation, ScaleUniformTransform3 scale", new Obb3M(RQT0, UST0), float4x4.TRS(I_T, RQT0_R, UST0_S));
        [Test] public void CtorRotationScale3Transform() => TestCtor<Obb3M>("RotationQTransform3 rotation, ScaleNonUniformTransform3 scale", new Obb3M(RQT0, NUST0), float4x4.TRS(I_T, RQT0_R, NUST0_S));
        [Test] public void CtorTranslationTransform() => TestCtor<Obb3M>("TranslationTransform3 translation", new Obb3M(TT0), float4x4.TRS(TT0_T, I_R, I_US));
        [Test] public void CtorRotationTransform() => TestCtor<Obb3M>("RotationQTransform3 rotation", new Obb3M(RQT0), float4x4.TRS(I_T, RQT0_R, I_US));
        [Test] public void CtorScale1Transform() => TestCtor<Obb3M>("ScaleUniformTransform3 scale", new Obb3M(UST0), float4x4.TRS(I_T, I_R, UST0_S));
        [Test] public void CtorScale3Transform() => TestCtor<Obb3M>("ScaleNonUniformTransform3 scale", new Obb3M(NUST0), float4x4.TRS(I_T, I_R, NUST0_S));
        [Test] public void CtorTranslation() => TestCtor<Translation3>("float3 translation", new Translation3(TT0_T), M4TT0);
        [Test] public void Identity() => TestIdentity<Obb3M>(Obb3M.Identity);
        [Test] public void Inversed() => TestInversed<Obb3M, Obb3M>(Obb3M0, M4Obb3Mi0);
        [Test] public void Translated() => TestTranslated<Obb3M>(Obb3M0, Translation, M4(M4Translation, M4Obb3M0));
        [Test] public void Rotated() => TestRotated<Obb3M, Obb3M>(Obb3M0, Rotation, M4(M4Rotation, M4Obb3M0));
        [Test] public void Scaled1() => TestScaled1<Obb3M>(Obb3M0, Scale1, M4(M4Scale1, M4Obb3M0));
        [Test] public void Scaled3() => TestScaled3<Obb3M, Obb3M>(Obb3M0, Scale3, M4(M4Scale3, M4Obb3M0));
        [Test] public void TestTranslate() => TestTranslate<Obb3M, Obb3M>(Obb3M0, Translation, M4(M4Obb3M0, M4Translation));
        [Test] public void TestRotate() => TestRotate<Obb3M, Obb3M>(Obb3M0, Rotation, M4(M4Obb3M0, M4Rotation));
        [Test] public void TestScale1() => TestScaleFloat<Obb3M, Obb3M>(Obb3M0, Scale1, M4(M4Obb3M0, M4Scale1));
        [Test] public void TestScale3() => TestScaleFloat3<Obb3M, Obb3M>(Obb3M0, Scale3, M4(M4Obb3M0, M4Scale3));
        [Test] public void MulTranslationTransform() => TestMul<Obb3M, Translation3, Obb3M>(Obb3M0, TT1, M4(M4Obb3M0, M4TT1));
        [Test] public void MulRotationQTransform() => TestMul<Obb3M, Rotation3Q, Obb3M>(Obb3M0, RQT1, M4(M4Obb3M0, M4RQT1));
        [Test] public void MulUniformScaleTransform() => TestMul<Obb3M, Scale1, Obb3M>(Obb3M0, UST1, M4(M4Obb3M0, M4UST1));
        [Test] public void MulNonUniformScaleTransform() => TestMul<Obb3M, Scale3, Obb3M>(Obb3M0, NUST1, M4(M4Obb3M0, M4NUST1));
        [Test] public void MulRigidTransformNi() => TestMul<Obb3M, RigidTransform3, Obb3M>(Obb3M0, RT1, M4(M4Obb3M0, M4RT1));
        [Test] public void MulUniformTransform() => TestMul<Obb3M, UniformTransform3, Obb3M>(Obb3M0, UT1, M4(M4Obb3M0, M4UT1));
        [Test] public void MulNonUniformTransform() => TestMul<Obb3M, NonUniformTransform3, Obb3M>(Obb3M0, NUT1, M4(M4Obb3M0, M4NUT1));
        [Test] public void MulMatrix3x3Transform() => TestMul<Obb3M, Matrix3x3Transform3, Obb3M>(Obb3M0, M3T1, M4(M4Obb3M0, M4M3T1));
        [Test] public void MulMatrix4x4Transform() => TestMul<Obb3M, Matrix4x4Transform3, Obb3M>(Obb3M0, M4T1, M4(M4Obb3M0, M4M4T1));
        [Test] public void DivTranslationTransform() => TestDiv<Obb3M, Translation3, Obb3M>(Obb3M0, TT1, M4(M4Obb3Mi0, M4TT1));
        [Test] public void DivRotationQTransform() => TestDiv<Obb3M, Rotation3Q, Obb3M>(Obb3M0, RQT1, M4(M4Obb3Mi0, M4RQT1));
        [Test] public void DivUniformScaleTransform() => TestDiv<Obb3M, Scale1, Obb3M>(Obb3M0, UST1, M4(M4Obb3Mi0, M4UST1));
        [Test] public void DivNonUniformScaleTransform() => TestDiv<Obb3M, Scale3, Obb3M>(Obb3M0, NUST1, M4(M4Obb3Mi0, M4NUST1));
        [Test] public void DivRigidTransformNi() => TestDiv<Obb3M, RigidTransform3, Obb3M>(Obb3M0, RT1, M4(M4Obb3Mi0, M4RT1));
        [Test] public void DivUniformTransform() => TestDiv<Obb3M, UniformTransform3, Obb3M>(Obb3M0, UT1, M4(M4Obb3Mi0, M4UT1));
        [Test] public void DivNonUniformTransform() => TestDiv<Obb3M, NonUniformTransform3, Obb3M>(Obb3M0, NUT1, M4(M4Obb3Mi0, M4NUT1));
        [Test] public void DivMatrix3x3Transform() => TestDiv<Obb3M, Matrix3x3Transform3, Obb3M>(Obb3M0, M3T1, M4(M4Obb3Mi0, M4M3T1));
        [Test] public void DivMatrix4x4Transform() => TestDiv<Obb3M, Matrix4x4Transform3, Obb3M>(Obb3M0, M4T1, M4(M4Obb3Mi0, M4M4T1));
        [Test] public void TransformFloat3() => TestTransformFloat3(Obb3M0, Float3, M4(M4Obb3M0, Float3));
        [Test] public void UntransformFloat3() => TestUntransformFloat3(Obb3M0, Float3, M4(M4Obb3Mi0, Float3));
    }

    public partial class TransformTests
    {
        public static readonly float3 Obb3M0_T = new float3(3.2f, -4.5f, 6.8f);
        public static readonly quaternion Obb3M0_R = quaternion.EulerXYZ(new float3(7.7f, -5.8f, 2.6f));
        public static readonly float3 Obb3M0_S = new float3(7.7f, -5.8f, 2.6f);
        public static readonly float3 Obb3M1_T = new float3(1.8f, 2.4f, -1.7f);
        public static readonly quaternion Obb3M1_R = quaternion.EulerXYZ(new float3(3.7f, 2.6f, -5.8f));
        public static readonly float3 Obb3M1_S = new float3(3.7f, -5.8f, 2.6f);

        public static readonly Obb3M Obb3M0 = new Obb3M(Obb3M0_T, Obb3M0_R, Obb3M0_S);
        public static readonly Obb3M Obb3M1 = new Obb3M(Obb3M1_T, Obb3M1_R, Obb3M1_S);


        public static readonly float4x4 M4Obb3M0 = Obb3M0.ToMatrix4x4Transform;
        public static readonly float4x4 M4Obb3M1 = Obb3M1.ToMatrix4x4Transform;
        public static readonly float4x4 M4Obb3Mi0 = math.inverse(Obb3M0.ToMatrix4x4Transform);
        public static readonly float4x4 M4Obb3Mi1 = math.inverse(Obb3M1.ToMatrix4x4Transform);


    }
}