using Ni.Mathematics;
using NUnit.Framework;

namespace Ni.Mathematics.Tests
{
    public class TestScale3 : TransformTests
    {
        [Test] public void CtornNonUniformScale() => TestCtor<Scale3>("float3 nonUniformScale", new Scale3(NUST0_S), M4NUST0);
        [Test] public void Identity() => TestIdentity(Mathematics.Scale3.Identity);
        [Test] public void Inversed() => TestInversed<Scale3>(NUST0, M4NUSTi0);
        [Test] public void Translated() => TestTranslated<Scale3, NonUniformTransform3>(NUST0, Translation, M4(M4Translation, M4NUST0));
        [Test] public void Rotated() => TestRotated<Scale3, NonUniformTransform3>(NUST0, Rotation, M4(M4Rotation, M4NUST0));
        [Test] public void Scaled1() => TestScaled1<Scale3, Scale3>(NUST0, Scale1, M4(M4Scale1, M4NUST0));
        [Test] public void Scaled3() => TestScaled3<Scale3, Scale3>(NUST0, Scale3, M4(M4Scale3, M4NUST0));
        [Test] public void TestTranslate() => TestTranslate<Scale3, NonUniformTransform3>(NUST0, Translation, M4(M4NUST0, M4Translation));
        [Test] public void TestRotate() => TestRotate<Scale3, Matrix3x3Transform3>(NUST0, Rotation, M4(M4NUST0, M4Rotation));
        [Test] public void TestScaleFloat() => TestScaleFloat<Scale3, Scale3>(NUST0, Scale1, M4(M4NUST0, M4Scale1));
        [Test] public void TestScaleFloat3() => TestScaleFloat3<Scale3, Scale3>(NUST0, Scale3, M4(M4NUST0, M4Scale3));
        [Test] public void MulTranslationTransform() => TestMul<Scale3, Translation3, NonUniformTransform3>(NUST0, TT1, M4(M4NUST0, M4TT1));
        [Test] public void MulRotationQTransform() => TestMul<Scale3, Rotation3Q, Matrix3x3Transform3>(NUST0, RQT1, M4(M4NUST0, M4RQT1));
        [Test] public void MulUniformScaleTransform() => TestMul<Scale3, Scale1, Scale3>(NUST0, UST1, M4(M4NUST0, M4UST1));
        [Test] public void MulNonUniformScaleTransform() => TestMul<Scale3, Scale3, Scale3>(NUST0, NUST1, M4(M4NUST0, M4NUST1));
        [Test] public void MulRigidTransformNi() => TestMul<Scale3, RigidTransform3, Matrix4x4Transform3>(NUST0, RT1, M4(M4NUST0, M4RT1));
        [Test] public void MulUniformTransform() => TestMul<Scale3, UniformTransform3, Matrix4x4Transform3>(NUST0, UT1, M4(M4NUST0, M4UT1));
        [Test] public void MulNonUniformTransform() => TestMul<Scale3, NonUniformTransform3, Matrix4x4Transform3>(NUST0, NUT1, M4(M4NUST0, M4NUT1));
        [Test] public void MulMatrix3x3Transform() => TestMul<Scale3, Matrix3x3Transform3, Matrix3x3Transform3>(NUST0, M3T1, M4(M4NUST0, M4M3T1));
        [Test] public void MulMatrix4x4Transform() => TestMul<Scale3, Matrix4x4Transform3, Matrix4x4Transform3>(NUST0, M4T1, M4(M4NUST0, M4M4T1));
        [Test] public void DivTranslationTransform() => TestDiv<Scale3, Translation3, NonUniformTransform3>(NUST0, TT1, M4(M4NUSTi0, M4TT1));
        [Test] public void DivRotationQTransform() => TestDiv<Scale3, Rotation3Q, Matrix3x3Transform3>(NUST0, RQT1, M4(M4NUSTi0, M4RQT1));
        [Test] public void DivUniformScaleTransform() => TestDiv<Scale3, Scale1, Scale3>(NUST0, UST1, M4(M4NUSTi0, M4UST1));
        [Test] public void DivNonUniformScaleTransform() => TestDiv<Scale3, Scale3, Scale3>(NUST0, NUST1, M4(M4NUSTi0, M4NUST1));
        [Test] public void DivRigidTransformNi() => TestDiv<Scale3, RigidTransform3, Matrix4x4Transform3>(NUST0, RT1, M4(M4NUSTi0, M4RT1));
        [Test] public void DivUniformTransform() => TestDiv<Scale3, UniformTransform3, Matrix4x4Transform3>(NUST0, UT1, M4(M4NUSTi0, M4UT1));
        [Test] public void DivNonUniformTransform() => TestDiv<Scale3, NonUniformTransform3, Matrix4x4Transform3>(NUST0, NUT1, M4(M4NUSTi0, M4NUT1));
        [Test] public void DivMatrix3x3Transform() => TestDiv<Scale3, Matrix3x3Transform3, Matrix3x3Transform3>(NUST0, M3T1, M4(M4NUSTi0, M4M3T1));
        [Test] public void DivMatrix4x4Transform() => TestDiv<Scale3, Matrix4x4Transform3, Matrix4x4Transform3>(NUST0, M4T1, M4(M4NUSTi0, M4M4T1));
        [Test] public void TransformFloat3() => TestTransformFloat3(UST0, Float3, UST0_S * Float3);
        [Test] public void UntransformFloat3() => TestUntransformFloat3(UST0, Float3, USTi0_S * Float3);
    }
}