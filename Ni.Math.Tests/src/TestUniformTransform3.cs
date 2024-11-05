using Ni.Mathematics;
using NUnit.Framework;
using Unity.Mathematics;

namespace Ni.Mathematics.Tests
{
    public class TestUniformTransform : TransformTests
    {
        [Test] public void CtorTranslationRotationScale() => TestCtor<UniformTransform3>("float3 translation, quaternion rotation, float scale", new UniformTransform3(UT0_T, UT0_R, UT0_S), float4x4.TRS(UT0_T, UT0_R, UT0_S));
        [Test] public void CtorTranslationRotation() => TestCtor<UniformTransform3>("float3 translation, quaternion rotation", new UniformTransform3(UT0_T, UT0_R), float4x4.TRS(UT0_T, UT0_R, I_US));
        [Test] public void CtorRotation() => TestCtor<UniformTransform3>("quaternion rotation", new UniformTransform3(UT0_R), float4x4.TRS(I_T, UT0_R, I_US));
        [Test] public void CtorTranslationRotationScaleTransform() => TestCtor<UniformTransform3>("TranslationTransform3 translation, RotationQTransform3 rotation, ScaleUniformTransform3 scale", new UniformTransform3(TT0, RQT0, UST0), float4x4.TRS(TT0_T, RQT0_R, UST0_S));
        [Test] public void CtorTranslationRotationTransform() => TestCtor<UniformTransform3>("TranslationTransform3 translation, RotationQTransform3 rotation", new UniformTransform3(TT0, RQT0), float4x4.TRS(TT0_T, RQT0_R, I_US));
        [Test] public void CtorTranslationScaleTransform() => TestCtor<UniformTransform3>("TranslationTransform3 translation, ScaleUniformTransform3 scale", new UniformTransform3(TT0, UST0), float4x4.TRS(TT0_T, I_R, UST0_S));
        [Test] public void CtorRotationScaleTransform() => TestCtor<UniformTransform3>("RotationQTransform3 rotation, ScaleUniformTransform3 scale", new UniformTransform3(RQT0, UST0), float4x4.TRS(I_T, RQT0_R, UST0_S));
        [Test] public void CtorTranslationTransform() => TestCtor<UniformTransform3>("TranslationTransform3 translation", new UniformTransform3(TT0), float4x4.TRS(TT0_T, I_R, I_US));
        [Test] public void CtorRotationTransform() => TestCtor<UniformTransform3>("RotationQTransform3 rotation", new UniformTransform3(RQT0), float4x4.TRS(I_T, RQT0_R, I_US));
        [Test] public void CtorScaleTransform() => TestCtor<UniformTransform3>("ScaleUniformTransform3 scale", new UniformTransform3(UST0), float4x4.TRS(I_T, I_R, UST0_S));
        [Test] public void Identity() => TestIdentity<UniformTransform3>(UniformTransform3.Identity);
        [Test] public void Inversed() => TestInversed<UniformTransform3>(UT0, M4UTi0);
        [Test] public void Translated() => TestTranslated<UniformTransform3>(UT0, Translation, M4(M4Translation, M4UT0));
        [Test] public void Rotated() => TestRotated<UniformTransform3>(UT0, Rotation, M4(M4Rotation, M4UT0));
        [Test] public void Scaled1() => TestScaled1<UniformTransform3, UniformTransform3>(UT0, Scale1, M4(M4Scale1, M4UT0));
        [Test] public void Scaled3() => TestScaled3<UniformTransform3, Matrix4x4Transform3>(UT0, Scale3, M4(M4Scale3, M4UT0));
        [Test] public void TestTranslate() => TestTranslate<UniformTransform3, UniformTransform3>(UT0, Translation, M4(M4UT0, M4Translation));
        [Test] public void TestRotate() => TestRotate<UniformTransform3, UniformTransform3>(UT0, Rotation, M4(M4UT0, M4Rotation));
        [Test] public void TestScale1() => TestScaleFloat<UniformTransform3, UniformTransform3>(UT0, Scale1, M4(M4UT0, M4Scale1));
        [Test] public void TestScale3() => TestScaleFloat3<UniformTransform3, NonUniformTransform3>(UT0, Scale3, M4(M4UT0, M4Scale3));
        [Test] public void MulTranslationTransform() => TestMul<UniformTransform3, Translation3, UniformTransform3>(UT0, TT1, M4(M4UT0, M4TT1));
        [Test] public void MulRotationQTransform() => TestMul<UniformTransform3, Rotation3Q, UniformTransform3>(UT0, RQT1, M4(M4UT0, M4RQT1));
        [Test] public void MulUniformScaleTransform() => TestMul<UniformTransform3, Scale1, UniformTransform3>(UT0, UST1, M4(M4UT0, M4UST1));
        [Test] public void MulNonUniformScaleTransform() => TestMul<UniformTransform3, Scale3, NonUniformTransform3>(UT0, NUST1, M4(M4UT0, M4NUST1));
        [Test] public void MulRigidTransformNi() => TestMul<UniformTransform3, RigidTransform3, UniformTransform3>(UT0, RT1, M4(M4UT0, M4RT1));
        [Test] public void MulUniformTransform() => TestMul<UniformTransform3, UniformTransform3, UniformTransform3>(UT0, UT1, M4(M4UT0, M4UT1));
        [Test] public void MulNonUniformTransform() => TestMul<UniformTransform3, NonUniformTransform3, NonUniformTransform3>(UT0, NUT1, M4(M4UT0, M4NUT1));
        [Test] public void MulMatrix3x3Transform() => TestMul<UniformTransform3, Matrix3x3Transform3, Matrix4x4Transform3>(UT0, M3T1, M4(M4UT0, M4M3T1));
        [Test] public void MulMatrix4x4Transform() => TestMul<UniformTransform3, Matrix4x4Transform3, Matrix4x4Transform3>(UT0, M4T1, M4(M4UT0, M4M4T1));
        [Test] public void DivTranslationTransform() => TestDiv<UniformTransform3, Translation3, UniformTransform3>(UT0, TT1, M4(M4UTi0, M4TT1));
        [Test] public void DivRotationQTransform() => TestDiv<UniformTransform3, Rotation3Q, UniformTransform3>(UT0, RQT1, M4(M4UTi0, M4RQT1));
        [Test] public void DivUniformScaleTransform() => TestDiv<UniformTransform3, Scale1, UniformTransform3>(UT0, UST1, M4(M4UTi0, M4UST1));
        [Test] public void DivNonUniformScaleTransform() => TestDiv<UniformTransform3, Scale3, NonUniformTransform3>(UT0, NUST1, M4(M4UTi0, M4NUST1));
        [Test] public void DivRigidTransformNi() => TestDiv<UniformTransform3, RigidTransform3, UniformTransform3>(UT0, RT1, M4(M4UTi0, M4RT1));
        [Test] public void DivUniformTransform() => TestDiv<UniformTransform3, UniformTransform3, UniformTransform3>(UT0, UT1, M4(M4UTi0, M4UT1));
        [Test] public void DivNonUniformTransform() => TestDiv<UniformTransform3, NonUniformTransform3, NonUniformTransform3>(UT0, NUT1, M4(M4UTi0, M4NUT1));
        [Test] public void DivMatrix3x3Transform() => TestDiv<UniformTransform3, Matrix3x3Transform3, Matrix4x4Transform3>(UT0, M3T1, M4(M4UTi0, M4M3T1));
        [Test] public void DivMatrix4x4Transform() => TestDiv<UniformTransform3, Matrix4x4Transform3, Matrix4x4Transform3>(UT0, M4T1, M4(M4UTi0, M4M4T1));
        [Test] public void TransformFloat3() => TestTransformFloat3(UT0, Float3, M4(M4UT0, Float3));
        [Test] public void UntransformFloat3() => TestUntransformFloat3(UT0, Float3, M4(M4UTi0, Float3));
    }
}