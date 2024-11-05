using Ni.Mathematics;
using NUnit.Framework;
using Unity.Mathematics;

namespace Ni.Mathematics.Tests
{
    public class TestMatrix3x3Transform : TransformTests
    {
        [Test] public void CtorFloat3x3() => TestCtor<Matrix3x3Transform3>("float3x3 matrix", new Matrix3x3Transform3(new float3x3(M30C0, M30C1, M30C2)), new float4x4(new float3x3(M30C0, M30C1, M30C2), 0));
        [Test] public void CtorColumns() => TestCtor<Matrix3x3Transform3>("float3 c0, float3 c1, float3 c2", new Matrix3x3Transform3(M30C0, M30C1, M30C2), new float4x4(new float3x3(M30C0, M30C1, M30C2), 0));
        [Test] public void CtorRotation() => TestCtor<Matrix3x3Transform3>("quaternion rotation", new Matrix3x3Transform3(UT0_R), float4x4.TRS(I_T, UT0_R, I_US));
        [Test] public void CtorScale1() => TestCtor<Matrix3x3Transform3>("float scale", new Matrix3x3Transform3(UST0_S), float4x4.TRS(I_T, I_R, UST0_S));
        [Test] public void CtorScale3() => TestCtor<Matrix3x3Transform3>("float3 scale", new Matrix3x3Transform3(NUST0_S), float4x4.TRS(I_T, I_R, NUST0_S));
        [Test] public void CtorRotationScale1Transform() => TestCtor<Matrix3x3Transform3>("RotationQTransform3 rotation, ScaleUniformTransform3 scale", new Matrix3x3Transform3(RQT0, UST0), float4x4.TRS(I_T, RQT0_R, UST0_S));
        [Test] public void CtorRotationScale3Transform() => TestCtor<Matrix3x3Transform3>("RotationQTransform3 rotation, ScaleNonUniformTransform3 scale", new Matrix3x3Transform3(RQT0, NUST0), float4x4.TRS(I_T, RQT0_R, NUST0_S));
        [Test] public void CtorRotationTransform() => TestCtor<Matrix3x3Transform3>("RotationQTransform3 rotation", new Matrix3x3Transform3(RQT0), float4x4.TRS(I_T, RQT0_R, I_US));
        [Test] public void CtorScale1Transform() => TestCtor<Matrix3x3Transform3>("ScaleUniformTransform3 scale", new Matrix3x3Transform3(UST0), float4x4.TRS(I_T, I_R, UST0_S));
        [Test] public void CtorScale3Transform() => TestCtor<Matrix3x3Transform3>("ScaleNonUniformTransform3 scale", new Matrix3x3Transform3(UST0), float4x4.TRS(I_T, I_R, UST0_S));
        [Test] public void Identity() => TestIdentity<Matrix3x3Transform3>(Matrix3x3Transform3.Identity);
        [Test] public void Inversed() => TestInversed<Matrix3x3Transform3>(M3T0, M4M3Ti0);
        [Test] public void Translated() => TestTranslated<Matrix3x3Transform3, Matrix4x4Transform3>(M3T0, Translation, M4(M4Translation, M4M3T0));
        [Test] public void Rotated() => TestRotated<Matrix3x3Transform3>(M3T0, Rotation, M4(M4Rotation, M4M3T0));
        [Test] public void Scaled1() => TestScaled1<Matrix3x3Transform3>(M3T0, Scale1, M4(M4Scale1, M4M3T0));
        [Test] public void Scaled3() => TestScaled3<Matrix3x3Transform3>(M3T0, Scale3, M4(M4Scale3, M4M3T0));
        [Test] public void TestTranslate() => TestTranslate<Matrix3x3Transform3, Matrix4x4Transform3>(M3T0, Translation, M4(M4M3T0, M4Translation));
        [Test] public void TestRotate() => TestRotate<Matrix3x3Transform3, Matrix3x3Transform3>(M3T0, Rotation, M4(M4M3T0, M4Rotation));
        [Test] public void TestScale1() => TestScaleFloat<Matrix3x3Transform3, Matrix3x3Transform3>(M3T0, Scale1, M4(M4M3T0, M4Scale1));
        [Test] public void TestScale3() => TestScaleFloat3<Matrix3x3Transform3, Matrix3x3Transform3>(M3T0, Scale3, M4(M4M3T0, M4Scale3));
        [Test] public void MulTranslationTransform() => TestMul<Matrix3x3Transform3, Translation3, Matrix4x4Transform3>(M3T0, TT1, M4(M4M3T0, M4TT1));
        [Test] public void MulRotationQTransform() => TestMul<Matrix3x3Transform3, Rotation3Q, Matrix3x3Transform3>(M3T0, RQT1, M4(M4M3T0, M4RQT1));
        [Test] public void MulUniformScaleTransform() => TestMul<Matrix3x3Transform3, Scale1, Matrix3x3Transform3>(M3T0, UST1, M4(M4M3T0, M4UST1));
        [Test] public void MulNonUniformScaleTransform() => TestMul<Matrix3x3Transform3, Scale3, Matrix3x3Transform3>(M3T0, NUST1, M4(M4M3T0, M4NUST1));
        [Test] public void MulRigidTransformNi() => TestMul<Matrix3x3Transform3, RigidTransform3, Matrix4x4Transform3>(M3T0, RT1, M4(M4M3T0, M4RT1));
        [Test] public void MulUniformTransform() => TestMul<Matrix3x3Transform3, UniformTransform3, Matrix4x4Transform3>(M3T0, UT1, M4(M4M3T0, M4UT1));
        [Test] public void MulNonUniformTransform() => TestMul<Matrix3x3Transform3, NonUniformTransform3, Matrix4x4Transform3>(M3T0, NUT1, M4(M4M3T0, M4NUT1));
        [Test] public void MulMatrix3x3Transform() => TestMul<Matrix3x3Transform3, Matrix3x3Transform3, Matrix3x3Transform3>(M3T0, M3T1, M4(M4M3T0, M4M3T1));
        [Test] public void MulMatrix4x4Transform() => TestMul<Matrix3x3Transform3, Matrix4x4Transform3, Matrix4x4Transform3>(M3T0, M4T1, M4(M4M3T0, M4M4T1));
        [Test] public void DivTranslationTransform() => TestDiv<Matrix3x3Transform3, Translation3, Matrix4x4Transform3>(M3T0, TT1, M4(M4M3Ti0, M4TT1));
        [Test] public void DivRotationQTransform() => TestDiv<Matrix3x3Transform3, Rotation3Q, Matrix3x3Transform3>(M3T0, RQT1, M4(M4M3Ti0, M4RQT1));
        [Test] public void DivUniformScaleTransform() => TestDiv<Matrix3x3Transform3, Scale1, Matrix3x3Transform3>(M3T0, UST1, M4(M4M3Ti0, M4UST1));
        [Test] public void DivNonUniformScaleTransform() => TestDiv<Matrix3x3Transform3, Scale3, Matrix3x3Transform3>(M3T0, NUST1, M4(M4M3Ti0, M4NUST1));
        [Test] public void DivRigidTransformNi() => TestDiv<Matrix3x3Transform3, RigidTransform3, Matrix4x4Transform3>(M3T0, RT1, M4(M4M3Ti0, M4RT1));
        [Test] public void DivUniformTransform() => TestDiv<Matrix3x3Transform3, UniformTransform3, Matrix4x4Transform3>(M3T0, UT1, M4(M4M3Ti0, M4UT1));
        [Test] public void DivNonUniformTransform() => TestDiv<Matrix3x3Transform3, NonUniformTransform3, Matrix4x4Transform3>(M3T0, NUT1, M4(M4M3Ti0, M4NUT1));
        [Test] public void DivMatrix3x3Transform() => TestDiv<Matrix3x3Transform3, Matrix3x3Transform3, Matrix3x3Transform3>(M3T0, M3T1, M4(M4M3Ti0, M4M3T1));
        [Test] public void DivMatrix4x4Transform() => TestDiv<Matrix3x3Transform3, Matrix4x4Transform3, Matrix4x4Transform3>(M3T0, M4T1, M4(M4M3Ti0, M4M4T1));
        [Test] public void TransformFloat3() => TestTransformFloat3(M3T0, Float3, M4(M4M3T0, Float3));
        [Test] public void UntransformFloat3() => TestUntransformFloat3(M3T0, Float3, M4(M4M3Ti0, Float3));
    }
}