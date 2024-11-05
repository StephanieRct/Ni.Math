using Ni.Mathematics;
using NUnit.Framework;
using Unity.Mathematics;

namespace Ni.Mathematics.Tests
{
    public class TestMatrix4x4Transform : TransformTests
    {
        [Test] public void CtorFloat4x4() => TestCtor<Matrix4x4Transform3>("float4x4 matrix", new Matrix4x4Transform3(M40_4x4), M4M4T0);
        [Test] public void CtorColumns() => TestCtor<Matrix4x4Transform3>("float4 column0, float4 column1, float4 column2, float4 column3", new Matrix4x4Transform3(M4T0), M4M4T0);
        [Test] public void CtorTranslationFloat3x3() => TestCtor<Matrix4x4Transform3>("float3 translation, float3x3 rotationScale", new Matrix4x4Transform3(M40_T, M30), new float4x4(M30, M40_T));
        [Test] public void CtorTranslationRotationScale1() => TestCtor<Matrix4x4Transform3>("float3 translation, quaternion rotation, float scale", new Matrix4x4Transform3(M40_T, M40_R, UST0_S), float4x4.TRS(M40_T, M40_R, UST0_S));
        [Test] public void CtorTranslationRotationScale3() => TestCtor<Matrix4x4Transform3>("float3 translation, quaternion rotation, float3 scale", new Matrix4x4Transform3(M40_T, M40_R, NUST0_S), float4x4.TRS(M40_T, M40_R, NUST0_S));
        [Test] public void CtorTranslationRotation() => TestCtor<Matrix4x4Transform3>("float3 translation, quaternion rotation", new Matrix4x4Transform3(M40_T, M40_R), float4x4.TRS(M40_T, M40_R, I_NUS));
        [Test] public void CtorTranslationScale1() => TestCtor<Matrix4x4Transform3>("float3 translation, float scale", new Matrix4x4Transform3(M40_T, UST0_S), float4x4.TRS(M40_T, I_R, UST0_S));
        [Test] public void CtorTranslationScale3() => TestCtor<Matrix4x4Transform3>("float3 translation, float3 scale", new Matrix4x4Transform3(M40_T, NUST0_S), float4x4.TRS(M40_T, I_R, NUST0_S));
        [Test] public void CtorRotationScale1() => TestCtor<Matrix4x4Transform3>("quaternion rotation, float scale", new Matrix4x4Transform3(M40_R, UST0_S), float4x4.TRS(I_T, M40_R, UST0_S));
        [Test] public void CtorRotationScale3() => TestCtor<Matrix4x4Transform3>("quaternion rotation, float3 scale", new Matrix4x4Transform3(M40_R, NUST0_S), float4x4.TRS(I_T, M40_R, NUST0_S));
        [Test] public void CtorRotation() => TestCtor<Matrix4x4Transform3>("quaternion rotation", new Matrix4x4Transform3(M40_R), float4x4.TRS(I_T, M40_R, I_US));
        [Test] public void CtorTranslationMatrix3x3Transform() => TestCtor<Matrix4x4Transform3>("TranslationTransform3 translation, Matrix3x3Transform3 rotationScale", new Matrix4x4Transform3(TT0, M3T0), new float4x4(M30, TT0_T));
        [Test] public void CtorTranslationRotationScale1Transform() => TestCtor<Matrix4x4Transform3>("TranslationTransform3 translation, RotationQTransform3 rotation, ScaleUniformTransform3 scale", new Matrix4x4Transform3(TT0, RQT0, UST0), float4x4.TRS(TT0_T, RQT0_R, UST0_S));
        [Test] public void CtorTranslationRotationScale3Transform() => TestCtor<Matrix4x4Transform3>("TranslationTransform3 translation, RotationQTransform3 rotation, ScaleNonUniformTransform3 scale", new Matrix4x4Transform3(TT0, RQT0, NUST0), float4x4.TRS(TT0_T, RQT0_R, NUST0_S));
        [Test] public void CtorTranslationRotationTransform() => TestCtor<Matrix4x4Transform3>("TranslationTransform3 translation, RotationQTransform3 rotation", new Matrix4x4Transform3(TT0, RQT0), float4x4.TRS(TT0_T, RQT0_R, I_US));
        [Test] public void CtorTranslationScale1Transform() => TestCtor<Matrix4x4Transform3>("TranslationTransform3 translation, ScaleUniformTransform3 scale", new Matrix4x4Transform3(TT0, UST0), float4x4.TRS(TT0_T, I_R, UST0_S));
        [Test] public void CtorTranslationScale3Transform() => TestCtor<Matrix4x4Transform3>("TranslationTransform3 translation, ScaleNonUniformTransform3 scale", new Matrix4x4Transform3(TT0, NUST0), float4x4.TRS(TT0_T, I_R, NUST0_S));
        [Test] public void CtorRotationScale1Transform() => TestCtor<Matrix4x4Transform3>("RotationQTransform3 rotation, ScaleUniformTransform3 scale", new Matrix4x4Transform3(RQT0, UST0), float4x4.TRS(I_T, RQT0_R, UST0_S));
        [Test] public void CtorRotationScale3Transform() => TestCtor<Matrix4x4Transform3>("RotationQTransform3 rotation, ScaleNonUniformTransform3 scale", new Matrix4x4Transform3(RQT0, NUST0), float4x4.TRS(I_T, RQT0_R, NUST0_S));
        [Test] public void CtorTranslationTransform() => TestCtor<Matrix4x4Transform3>("TranslationTransform3 translation", new Matrix4x4Transform3(TT0), float4x4.TRS(TT0_T, I_R, I_US));
        [Test] public void CtorRotationTransform() => TestCtor<Matrix4x4Transform3>("RotationQTransform3 rotation", new Matrix4x4Transform3(RQT0), float4x4.TRS(I_T, RQT0_R, I_US));
        [Test] public void CtorScale1Transform() => TestCtor<Matrix4x4Transform3>("ScaleUniformTransform3 scale", new Matrix4x4Transform3(UST0), float4x4.TRS(I_T, I_R, UST0_S));
        [Test] public void CtorScale3Transform() => TestCtor<Matrix4x4Transform3>("ScaleNonUniformTransform3 scale", new Matrix4x4Transform3(NUST0), float4x4.TRS(I_T, I_R, NUST0_S));
        [Test] public void Identity() => TestIdentity<Matrix4x4Transform3>(Matrix4x4Transform3.Identity);
        [Test] public void Inversed() => TestInversed<Matrix4x4Transform3>(M4T0, M4M4Ti0);
        [Test] public void Translated() => TestTranslated<Matrix4x4Transform3>(M4T0, Translation, M4(M4Translation, M4M4T0));
        [Test] public void Rotated() => TestRotated<Matrix4x4Transform3>(M4T0, Rotation, M4(M4Rotation, M4M4T0));
        [Test] public void Scaled1() => TestScaled1<Matrix4x4Transform3>(M4T0, Scale1, M4(M4Scale1, M4M4T0));
        [Test] public void Scaled3() => TestScaled3<Matrix4x4Transform3>(M4T0, Scale3, M4(M4Scale3, M4M4T0));
        [Test] public void TestTranslate() => TestTranslate<Matrix4x4Transform3, Matrix4x4Transform3>(M4T0, Translation, M4(M4M4T0, M4Translation));
        [Test] public void TestRotate() => TestRotate<Matrix4x4Transform3, Matrix4x4Transform3>(M4T0, Rotation, M4(M4M4T0, M4Rotation));
        [Test] public void TestScale1() => TestScaleFloat<Matrix4x4Transform3, Matrix4x4Transform3>(M4T0, Scale1, M4(M4M4T0, M4Scale1));
        [Test] public void TestScale3() => TestScaleFloat3<Matrix4x4Transform3, Matrix4x4Transform3>(M4T0, Scale3, M4(M4M4T0, M4Scale3));
        [Test] public void TransformFloat3() => TestTransformFloat3(M4T0, Float3, M4(M4M4T0, Float3));
        //[Test] public void TransformRay3() => TestTransform<Matrix4x4Transform3, Ray3>(M4T0, M4T1, M4(M4M4T0, M4M4T1));
        [Test] public void UntransformFloat3() => TestUntransformFloat3(M4T0, Float3, M4(M4M4Ti0, Float3));
        //[Test] public void UntransformRay3() => TestUntransform<Matrix4x4Transform3, Matrix4x4Transform3>(M4T0, M4T1, M4(M4M4Ti0, M4M4T1));
        [Test] public void MulTranslationTransform() => TestMul<Matrix4x4Transform3, Translation3, Matrix4x4Transform3>(M4T0, TT1, M4(M4M4T0, M4TT1));
        [Test] public void MulRotationQTransform() => TestMul<Matrix4x4Transform3, Rotation3Q, Matrix4x4Transform3>(M4T0, RQT1, M4(M4M4T0, M4RQT1));
        [Test] public void MulUniformScaleTransform() => TestMul<Matrix4x4Transform3, Scale1, Matrix4x4Transform3>(M4T0, UST1, M4(M4M4T0, M4UST1));
        [Test] public void MulNonUniformScaleTransform() => TestMul<Matrix4x4Transform3, Scale3, Matrix4x4Transform3>(M4T0, NUST1, M4(M4M4T0, M4NUST1));
        [Test] public void MulRigidTransformNi() => TestMul<Matrix4x4Transform3, RigidTransform3, Matrix4x4Transform3>(M4T0, RT1, M4(M4M4T0, M4RT1));
        [Test] public void MulUniformTransform() => TestMul<Matrix4x4Transform3, UniformTransform3, Matrix4x4Transform3>(M4T0, UT1, M4(M4M4T0, M4UT1));
        [Test] public void MulNonUniformTransform() => TestMul<Matrix4x4Transform3, NonUniformTransform3, Matrix4x4Transform3>(M4T0, NUT1, M4(M4M4T0, M4NUT1));
        [Test] public void MulMatrix3x3Transform() => TestMul<Matrix4x4Transform3, Matrix3x3Transform3, Matrix4x4Transform3>(M4T0, M3T1, M4(M4M4T0, M4M3T1));
        [Test] public void MulMatrix4x4Transform() => TestMul<Matrix4x4Transform3, Matrix4x4Transform3, Matrix4x4Transform3>(M4T0, M4T1, M4(M4M4T0, M4M4T1));
        [Test] public void DivTranslationTransform() => TestDiv<Matrix4x4Transform3, Translation3, Matrix4x4Transform3>(M4T0, TT1, M4(M4M4Ti0, M4TT1));
        [Test] public void DivRotationQTransform() => TestDiv<Matrix4x4Transform3, Rotation3Q, Matrix4x4Transform3>(M4T0, RQT1, M4(M4M4Ti0, M4RQT1));
        [Test] public void DivUniformScaleTransform() => TestDiv<Matrix4x4Transform3, Scale1, Matrix4x4Transform3>(M4T0, UST1, M4(M4M4Ti0, M4UST1));
        [Test] public void DivNonUniformScaleTransform() => TestDiv<Matrix4x4Transform3, Scale3, Matrix4x4Transform3>(M4T0, NUST1, M4(M4M4Ti0, M4NUST1));
        [Test] public void DivRigidTransformNi() => TestDiv<Matrix4x4Transform3, RigidTransform3, Matrix4x4Transform3>(M4T0, RT1, M4(M4M4Ti0, M4RT1));
        [Test] public void DivUniformTransform() => TestDiv<Matrix4x4Transform3, UniformTransform3, Matrix4x4Transform3>(M4T0, UT1, M4(M4M4Ti0, M4UT1));
        [Test] public void DivNonUniformTransform() => TestDiv<Matrix4x4Transform3, NonUniformTransform3, Matrix4x4Transform3>(M4T0, NUT1, M4(M4M4Ti0, M4NUT1));
        [Test] public void DivMatrix3x3Transform() => TestDiv<Matrix4x4Transform3, Matrix3x3Transform3, Matrix4x4Transform3>(M4T0, M3T1, M4(M4M4Ti0, M4M3T1));
        [Test] public void DivMatrix4x4Transform() => TestDiv<Matrix4x4Transform3, Matrix4x4Transform3, Matrix4x4Transform3>(M4T0, M4T1, M4(M4M4Ti0, M4M4T1));
    }
}