using Ni.Mathematics;
using NUnit.Framework;
using Unity.Mathematics;

namespace Ni.Mathematics.Tests
{
    public class TestNonUniformTransform : TransformTests
    {
        [Test] public void CtorTranslationRotationScale() => TestCtor<NonUniformTransform3>("float3 translation, quaternion rotation, float3 scale", new NonUniformTransform3(NUT0_T, NUT0_R, NUT0_S), float4x4.TRS(NUT0_T, NUT0_R, NUT0_S));
        [Test] public void CtorTranslationRotation() => TestCtor<NonUniformTransform3>("float3 translation, quaternion rotation", new NonUniformTransform3(NUT0_T, NUT0_R), float4x4.TRS(NUT0_T, NUT0_R, I_NUS));
        [Test] public void CtorRotation() => TestCtor<NonUniformTransform3>("quaternion rotation", new NonUniformTransform3(NUT0_R), float4x4.TRS(I_T, NUT0_R, I_US));
        [Test] public void CtorTranslationRotationScaleTransform() => TestCtor<NonUniformTransform3>("TranslationTransform3 translation, RotationQTransform3 rotation, ScaleNonUniformTransform3 scale", new NonUniformTransform3(TT0, RQT0, NUST0), float4x4.TRS(TT0_T, RQT0_R, NUST0_S));
        [Test] public void CtorTranslationRotationTransform() => TestCtor<NonUniformTransform3>("TranslationTransform3 translation, RotationQTransform3 rotation", new NonUniformTransform3(TT0, RQT0), float4x4.TRS(TT0_T, RQT0_R, I_US));
        [Test] public void CtorTranslationScaleTransform() => TestCtor<NonUniformTransform3>("TranslationTransform3 translation, ScaleNonUniformTransform3 scale", new NonUniformTransform3(TT0, NUST0), float4x4.TRS(TT0_T, I_R, NUST0_S));
        [Test] public void CtorRotationScaleTransform() => TestCtor<NonUniformTransform3>("RotationQTransform3 rotation, ScaleNonUniformTransform3 scale", new NonUniformTransform3(RQT0, NUST0), float4x4.TRS(I_T, RQT0_R, NUST0_S));
        [Test] public void CtorTranslationTransform() => TestCtor<NonUniformTransform3>("TranslationTransform3 translation", new NonUniformTransform3(TT0), float4x4.TRS(TT0_T, I_R, I_US));
        [Test] public void CtorRotationTransform() => TestCtor<NonUniformTransform3>("RotationQTransform3 rotation", new NonUniformTransform3(RQT0), float4x4.TRS(I_T, RQT0_R, I_US));
        [Test] public void CtorScaleTransform() => TestCtor<NonUniformTransform3>("ScaleNonUniformTransform3 scale", new NonUniformTransform3(NUST0), float4x4.TRS(I_T, I_R, NUST0_S));

        [Test] public void CtorTranslation() => TestCtor<Translation3>("float3 translation", new Translation3(TT0_T), M4TT0);
        [Test] public void Identity() => TestIdentity<NonUniformTransform3>(NonUniformTransform3.Identity);
        [Test] public void Inversed() => TestInversed<NonUniformTransform3, Matrix4x4Transform3>(NUT0, M4NUTi0);
        [Test] public void Translated() => TestTranslated<NonUniformTransform3>(NUT0, Translation, M4(M4Translation, M4NUT0));
        [Test] public void Rotated() => TestRotated<NonUniformTransform3>(NUT0, Rotation, M4(M4Rotation, M4NUT0));
        [Test] public void Scaled1() => TestScaled1<NonUniformTransform3, NonUniformTransform3>(NUT0, Scale1, M4(M4Scale1, M4NUT0));
        [Test] public void Scaled3() => TestScaled3<NonUniformTransform3, Matrix4x4Transform3>(NUT0, Scale3, M4(M4Scale3, M4NUT0));
        [Test] public void TestTranslate() => TestTranslate<NonUniformTransform3, NonUniformTransform3>(NUT0, Translation, M4(M4NUT0, M4Translation));
        [Test] public void TestRotate() => TestRotate<NonUniformTransform3, Matrix4x4Transform3>(NUT0, Rotation, M4(M4NUT0, M4Rotation));
        [Test] public void TestScale1() => TestScaleFloat<NonUniformTransform3, NonUniformTransform3>(NUT0, Scale1, M4(M4NUT0, M4Scale1));
        [Test] public void TestScale3() => TestScaleFloat3<NonUniformTransform3, NonUniformTransform3>(NUT0, Scale3, M4(M4NUT0, M4Scale3));
        [Test] public void MulTranslationTransform() => TestMul<NonUniformTransform3, Translation3, NonUniformTransform3>(NUT0, TT1, M4(M4NUT0, M4TT1));
        [Test] public void MulRotationQTransform() => TestMul<NonUniformTransform3, Rotation3Q, Matrix4x4Transform3>(NUT0, RQT1, M4(M4NUT0, M4RQT1));
        [Test] public void MulUniformScaleTransform() => TestMul<NonUniformTransform3, Scale1, NonUniformTransform3>(NUT0, UST1, M4(M4NUT0, M4UST1));
        [Test] public void MulNonUniformScaleTransform() => TestMul<NonUniformTransform3, Scale3, NonUniformTransform3>(NUT0, NUST1, M4(M4NUT0, M4NUST1));
        [Test] public void MulRigidTransformNi() => TestMul<NonUniformTransform3, RigidTransform3, Matrix4x4Transform3>(NUT0, RT1, M4(M4NUT0, M4RT1));
        [Test] public void MulUniformTransform() => TestMul<NonUniformTransform3, UniformTransform3, Matrix4x4Transform3>(NUT0, UT1, M4(M4NUT0, M4UT1));
        [Test] public void MulNonUniformTransform() => TestMul<NonUniformTransform3, NonUniformTransform3, Matrix4x4Transform3>(NUT0, NUT1, M4(M4NUT0, M4NUT1));
        [Test] public void MulMatrix3x3Transform() => TestMul<NonUniformTransform3, Matrix3x3Transform3, Matrix4x4Transform3>(NUT0, M3T1, M4(M4NUT0, M4M3T1));
        [Test] public void MulMatrix4x4Transform() => TestMul<NonUniformTransform3, Matrix4x4Transform3, Matrix4x4Transform3>(NUT0, M4T1, M4(M4NUT0, M4M4T1));
        [Test] public void DivTranslationTransform() => TestDiv<NonUniformTransform3, Translation3, Matrix4x4Transform3>(NUT0, TT1, M4(M4NUTi0, M4TT1));
        [Test] public void DivRotationQTransform() => TestDiv<NonUniformTransform3, Rotation3Q, Matrix4x4Transform3>(NUT0, RQT1, M4(M4NUTi0, M4RQT1));
        [Test] public void DivUniformScaleTransform() => TestDiv<NonUniformTransform3, Scale1, Matrix4x4Transform3>(NUT0, UST1, M4(M4NUTi0, M4UST1));
        [Test] public void DivNonUniformScaleTransform() => TestDiv<NonUniformTransform3, Scale3, Matrix4x4Transform3>(NUT0, NUST1, M4(M4NUTi0, M4NUST1));
        [Test] public void DivRigidTransformNi() => TestDiv<NonUniformTransform3, RigidTransform3, Matrix4x4Transform3>(NUT0, RT1, M4(M4NUTi0, M4RT1));
        [Test] public void DivUniformTransform() => TestDiv<NonUniformTransform3, UniformTransform3, Matrix4x4Transform3>(NUT0, UT1, M4(M4NUTi0, M4UT1));
        [Test] public void DivNonUniformTransform() => TestDiv<NonUniformTransform3, NonUniformTransform3, Matrix4x4Transform3>(NUT0, NUT1, M4(M4NUTi0, M4NUT1));
        [Test] public void DivMatrix3x3Transform() => TestDiv<NonUniformTransform3, Matrix3x3Transform3, Matrix4x4Transform3>(NUT0, M3T1, M4(M4NUTi0, M4M3T1));
        [Test] public void DivMatrix4x4Transform() => TestDiv<NonUniformTransform3, Matrix4x4Transform3, Matrix4x4Transform3>(NUT0, M4T1, M4(M4NUTi0, M4M4T1));
        [Test] public void TransformFloat3() => TestTransformFloat3(NUT0, Float3, M4(M4NUT0, Float3));
        [Test] public void UntransformFloat3() => TestUntransformFloat3(NUT0, Float3, M4(M4NUTi0, Float3));
    }
}