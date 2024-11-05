using Ni.Mathematics;
using NUnit.Framework;

namespace Ni.Mathematics.Tests
{
    public class TestScale1 : TransformTests
    {
        [Test] public void CtorUniformScale() => TestCtor<Scale1>("float uniformScale", new Scale1(UST0_S), M4UST0);
        [Test] public void Identity() => TestIdentity(Mathematics.Scale1.Identity);
        [Test] public void Inversed() => TestInversed<Scale1>(UST0, M4USTi0);
        [Test] public void Translated() => TestTranslated<Scale1, UniformTransform3>(UST0, Translation, M4(M4Translation, M4UST0));
        [Test] public void Rotated() => TestRotated<Scale1, UniformTransform3>(UST0, Rotation, M4(M4Rotation, M4UST0));
        [Test] public void Scaled1() => TestScaled1<Scale1, Scale1>(UST0, Scale1, M4(M4Scale1, M4UST0));
        [Test] public void Scaled3() => TestScaled3<Scale1, Scale3>(UST0, Scale3, M4(M4Scale3, M4UST0));
        [Test] public void TestTranslate() => TestTranslate<Scale1, UniformTransform3>(UST0, Translation, M4(M4UST0, M4Translation));
        [Test] public void TestRotate() => TestRotate<Scale1, UniformTransform3>(UST0, Rotation, M4(M4UST0, M4Rotation));
        [Test] public void TestScaleFLoat() => TestScaleFloat<Scale1, Scale1>(UST0, Scale1, M4(M4UST0, M4Scale1));
        [Test] public void TestScaleFLoat3() => TestScaleFloat3<Scale1, Scale3>(UST0, Scale3, M4(M4UST0, M4Scale3));
        [Test] public void MulTranslationTransform() => TestMul<Scale1, Translation3, UniformTransform3>(UST0, TT1, M4(M4UST0, M4TT1));
        [Test] public void MulRotationQTransform() => TestMul<Scale1, Rotation3Q, UniformTransform3>(UST0, RQT1, M4(M4UST0, M4RQT1));
        [Test] public void MulUniformScaleTransform() => TestMul<Scale1, Scale1, Scale1>(UST0, UST1, M4(M4UST0, M4UST1));
        [Test] public void MulNonUniformScaleTransform() => TestMul<Scale1, Scale3, Scale3>(UST0, NUST1, M4(M4UST0, M4NUST1));
        [Test] public void MulRigidTransformNi() => TestMul<Scale1, RigidTransform3, UniformTransform3>(UST0, RT1, M4(M4UST0, M4RT1));
        [Test] public void MulUniformTransform() => TestMul<Scale1, UniformTransform3, UniformTransform3>(UST0, UT1, M4(M4UST0, M4UT1));
        [Test] public void MulNonUniformTransform() => TestMul<Scale1, NonUniformTransform3, NonUniformTransform3>(UST0, NUT1, M4(M4UST0, M4NUT1));
        [Test] public void MulMatrix3x3Transform() => TestMul<Scale1, Matrix3x3Transform3, Matrix3x3Transform3>(UST0, M3T1, M4(M4UST0, M4M3T1));
        [Test] public void MulMatrix4x4Transform() => TestMul<Scale1, Matrix4x4Transform3, Matrix4x4Transform3>(UST0, M4T1, M4(M4UST0, M4M4T1));
        [Test] public void DivTranslationTransform() => TestDiv<Scale1, Translation3, UniformTransform3>(UST0, TT1, M4(M4USTi0, M4TT1));
        [Test] public void DivRotationQTransform() => TestDiv<Scale1, Rotation3Q, UniformTransform3>(UST0, RQT1, M4(M4USTi0, M4RQT1));
        [Test] public void DivUniformScaleTransform() => TestDiv<Scale1, Scale1, Scale1>(UST0, UST1, M4(M4USTi0, M4UST1));
        [Test] public void DivNonUniformScaleTransform() => TestDiv<Scale1, Scale3, Scale3>(UST0, NUST1, M4(M4USTi0, M4NUST1));
        [Test] public void DivRigidTransformNi() => TestDiv<Scale1, RigidTransform3, UniformTransform3>(UST0, RT1, M4(M4USTi0, M4RT1));
        [Test] public void DivUniformTransform() => TestDiv<Scale1, UniformTransform3, UniformTransform3>(UST0, UT1, M4(M4USTi0, M4UT1));
        [Test] public void DivNonUniformTransform() => TestDiv<Scale1, NonUniformTransform3, NonUniformTransform3>(UST0, NUT1, M4(M4USTi0, M4NUT1));
        [Test] public void DivMatrix3x3Transform() => TestDiv<Scale1, Matrix3x3Transform3, Matrix3x3Transform3>(UST0, M3T1, M4(M4USTi0, M4M3T1));
        [Test] public void DivMatrix4x4Transform() => TestDiv<Scale1, Matrix4x4Transform3, Matrix4x4Transform3>(UST0, M4T1, M4(M4USTi0, M4M4T1));
        [Test] public void TransformFloat3() => TestTransformFloat3(UST0, Float3, UST0_S * Float3);
        [Test] public void UntransformFloat3() => TestUntransformFloat3(UST0, Float3, USTi0_S * Float3);
    }
}