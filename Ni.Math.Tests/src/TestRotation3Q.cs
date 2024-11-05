using Ni.Mathematics;
using NUnit.Framework;
using Unity.Mathematics;

namespace Ni.Mathematics.Tests
{
    public class TestRotation3Q : TransformTests
    {
        [Test] public void CtorRotation() => TestCtor<Rotation3Q>("quaternion rotation", new Rotation3Q(RQT0_R), M4RQT0);
        [Test] public void Identity() => TestIdentity<Rotation3Q>(Rotation3Q.Identity);
        [Test] public void Inversed() => TestInversed<Rotation3Q>(RQT0, M4RQTi0);
        [Test] public void Translated() => TestTranslated<Rotation3Q, RigidTransform3>(RQT0, Translation, M4(M4Translation, M4RQT0));
        [Test] public void Rotated() => TestRotated<Rotation3Q, Rotation3Q>(RQT0, Rotation, M4(M4Rotation, M4RQT0));
        [Test] public void Scaled1() => TestScaled1<Rotation3Q, UniformTransform3>(RQT0, Scale1, M4(M4Scale1, M4RQT0));
        [Test] public void Scaled3() => TestScaled3<Rotation3Q, Matrix3x3Transform3>(RQT0, Scale3, M4(M4Scale3, M4RQT0));
        [Test] public void TestTranslate() => TestTranslate<Rotation3Q, RigidTransform3>(RQT0, Translation, M4(M4RQT0, M4Translation));
        [Test] public void TestRotate() => TestRotate<Rotation3Q>(RQT0, Rotation, M4(M4RQT0, M4Rotation));
        [Test] public void TestScale1() => TestScaleFloat<Rotation3Q, UniformTransform3>(RQT0, Scale1, M4(M4RQT0, M4Scale1));
        [Test] public void TestScale3() => TestScaleFloat3<Rotation3Q, NonUniformTransform3>(RQT0, Scale3, M4(M4RQT0, M4Scale3));
        [Test] public void MulTranslationTransform() => TestMul<Rotation3Q, Translation3, RigidTransform3>(RQT0, TT1, M4(M4RQT0, M4TT1));
        [Test] public void MulRotationQTransform() => TestMul<Rotation3Q, Rotation3Q, Rotation3Q>(RQT0, RQT1, M4(M4RQT0, M4RQT1));
        [Test] public void MulUniformScaleTransform() => TestMul<Rotation3Q, Scale1, UniformTransform3>(RQT0, UST1, M4(M4RQT0, M4UST1));
        [Test] public void MulNonUniformScaleTransform() => TestMul<Rotation3Q, Scale3, NonUniformTransform3>(RQT0, NUST1, M4(M4RQT0, M4NUST1));
        [Test] public void MulRigidTransformNi() => TestMul<Rotation3Q, RigidTransform3, RigidTransform3>(RQT0, RT1, M4(M4RQT0, M4RT1));
        [Test] public void MulUniformTransform() => TestMul<Rotation3Q, UniformTransform3, UniformTransform3>(RQT0, UT1, M4(M4RQT0, M4UT1));
        [Test] public void MulNonUniformTransform() => TestMul<Rotation3Q, NonUniformTransform3, NonUniformTransform3>(RQT0, NUT1, M4(M4RQT0, M4NUT1));
        [Test] public void MulMatrix3x3Transform() => TestMul<Rotation3Q, Matrix3x3Transform3, Matrix3x3Transform3>(RQT0, M3T1, M4(M4RQT0, M4M3T1));
        [Test] public void MulMatrix4x4Transform() => TestMul<Rotation3Q, Matrix4x4Transform3, Matrix4x4Transform3>(RQT0, M4T1, M4(M4RQT0, M4M4T1));
        [Test] public void DivTranslationTransform() => TestDiv<Rotation3Q, Translation3, RigidTransform3>(RQT0, TT1, M4(M4RQTi0, M4TT1));
        [Test] public void DivRotationQTransform() => TestDiv<Rotation3Q, Rotation3Q, Rotation3Q>(RQT0, RQT1, M4(M4RQTi0, M4RQT1));
        [Test] public void DivUniformScaleTransform() => TestDiv<Rotation3Q, Scale1, UniformTransform3>(RQT0, UST1, M4(M4RQTi0, M4UST1));
        [Test] public void DivNonUniformScaleTransform() => TestDiv<Rotation3Q, Scale3, NonUniformTransform3>(RQT0, NUST1, M4(M4RQTi0, M4NUST1));
        [Test] public void DivRigidTransformNi() => TestDiv<Rotation3Q, RigidTransform3, RigidTransform3>(RQT0, RT1, M4(M4RQTi0, M4RT1));
        [Test] public void DivUniformTransform() => TestDiv<Rotation3Q, UniformTransform3, UniformTransform3>(RQT0, UT1, M4(M4RQTi0, M4UT1));
        [Test] public void DivNonUniformTransform() => TestDiv<Rotation3Q, NonUniformTransform3, NonUniformTransform3>(RQT0, NUT1, M4(M4RQTi0, M4NUT1));
        [Test] public void DivMatrix3x3Transform() => TestDiv<Rotation3Q, Matrix3x3Transform3, Matrix3x3Transform3>(RQT0, M3T1, M4(M4RQTi0, M4M3T1));
        [Test] public void DivMatrix4x4Transform() => TestDiv<Rotation3Q, Matrix4x4Transform3, Matrix4x4Transform3>(RQT0, M4T1, M4(M4RQTi0, M4M4T1));
        [Test] public void TransformFloat3() => TestTransformFloat3(RQT0, Float3, math.mul(RQT0_R, Float3));
        [Test] public void UntransformFloat3() => TestUntransformFloat3(RQT0, Float3, math.mul(RQTi0_R, Float3));
    }
}