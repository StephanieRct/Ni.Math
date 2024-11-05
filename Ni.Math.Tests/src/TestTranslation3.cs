using Ni.Mathematics;
using NUnit.Framework;

namespace Ni.Mathematics.Tests
{
    public class TestTranslation3 : TransformTests
    {
        [Test] public void CtorTranslation() => TestCtor<Translation3>("float3 translation", new Translation3(TT0_T), M4TT0);
        [Test] public void Identity() => TestIdentity<Translation3>(Translation3.Identity);
        [Test] public void Inversed() => TestInversed<Translation3>(TT0, M4TTi0);
        [Test] public void Translated() => TestTranslated<Translation3, Translation3>(TT0, Translation, M4(M4Translation, M4TT0));
        [Test] public void Rotated() => TestRotated<Translation3, RigidTransform3>(TT0, Rotation, M4(M4Rotation, M4TT0));
        [Test] public void Scaled1() => TestScaled1<Translation3, UniformTransform3>(TT0, Scale1, M4(M4Scale1, M4TT0));
        [Test] public void Scaled3() => TestScaled3<Translation3, NonUniformTransform3>(TT0, Scale3, M4(M4Scale3, M4TT0));
        [Test] public void TestTranslate() => TestTranslate<Translation3>(TT0, Translation, M4(M4TT0, M4Translation));
        [Test] public void TestRotate() => TestRotate<Translation3, RigidTransform3>(TT0, Rotation, M4(M4TT0, M4Rotation));
        [Test] public void TestScale1() => TestScaleFloat<Translation3, UniformTransform3>(TT0, Scale1, M4(M4TT0, M4Scale1));
        [Test] public void TestScale3() => TestScaleFloat3<Translation3, NonUniformTransform3>(TT0, Scale3, M4(M4TT0, M4Scale3));
        [Test] public void TransformFloat3() => TestTransformFloat3(TT0, Float3, TT0_T + Float3);
        [Test] public void UntransformFloat3() => TestUntransformFloat3(TT0, Float3, TTi0_T + Float3);
        [Test] public void MulTranslationTransform() => TestMul<Translation3, Translation3, Translation3>(TT0, TT1, M4(M4TT0, M4TT1));
        [Test] public void MulRotationQTransform() => TestMul<Translation3, Rotation3Q, RigidTransform3>(TT0, RQT1, M4(M4TT0, M4RQT1));
        [Test] public void MulUniformScaleTransform() => TestMul<Translation3, Scale1, UniformTransform3>(TT0, UST1, M4(M4TT0, M4UST1));
        [Test] public void MulNonUniformScaleTransform() => TestMul<Translation3, Scale3, NonUniformTransform3>(TT0, NUST1, M4(M4TT0, M4NUST1));
        [Test] public void MulRigidTransformNi() => TestMul<Translation3, RigidTransform3, RigidTransform3>(TT0, RT1, M4(M4TT0, M4RT1));
        [Test] public void MulUniformTransform() => TestMul<Translation3, UniformTransform3, UniformTransform3>(TT0, UT1, M4(M4TT0, M4UT1));
        [Test] public void MulNonUniformTransform() => TestMul<Translation3, NonUniformTransform3, NonUniformTransform3>(TT0, NUT1, M4(M4TT0, M4NUT1));
        [Test] public void MulMatrix3x3Transform() => TestMul<Translation3, Matrix3x3Transform3, Matrix4x4Transform3>(TT0, M3T1, M4(M4TT0, M4M3T1));
        [Test] public void MulMatrix4x4Transform() => TestMul<Translation3, Matrix4x4Transform3, Matrix4x4Transform3>(TT0, M4T1, M4(M4TT0, M4M4T1));
        [Test] public void DivTranslationTransform() => TestDiv<Translation3, Translation3, Translation3>(TT0, TT1, M4(M4TTi0, M4TT1));
        [Test] public void DivRotationQTransform() => TestDiv<Translation3, Rotation3Q, RigidTransform3>(TT0, RQT1, M4(M4TTi0, M4RQT1));
        [Test] public void DivUniformScaleTransform() => TestDiv<Translation3, Scale1, UniformTransform3>(TT0, UST1, M4(M4TTi0, M4UST1));
        [Test] public void DivNonUniformScaleTransform() => TestDiv<Translation3, Scale3, NonUniformTransform3>(TT0, NUST1, M4(M4TTi0, M4NUST1));
        [Test] public void DivRigidTransformNi() => TestDiv<Translation3, RigidTransform3, RigidTransform3>(TT0, RT1, M4(M4TTi0, M4RT1));
        [Test] public void DivUniformTransform() => TestDiv<Translation3, UniformTransform3, UniformTransform3>(TT0, UT1, M4(M4TTi0, M4UT1));
        [Test] public void DivNonUniformTransform() => TestDiv<Translation3, NonUniformTransform3, NonUniformTransform3>(TT0, NUT1, M4(M4TTi0, M4NUT1));
        [Test] public void DivMatrix3x3Transform() => TestDiv<Translation3, Matrix3x3Transform3, Matrix4x4Transform3>(TT0, M3T1, M4(M4TTi0, M4M3T1));
        [Test] public void DivMatrix4x4Transform() => TestDiv<Translation3, Matrix4x4Transform3, Matrix4x4Transform3>(TT0, M4T1, M4(M4TTi0, M4M4T1));
    }
}