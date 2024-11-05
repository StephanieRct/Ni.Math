using Ni.Mathematics;
using NUnit.Framework;
using Unity.Mathematics;

namespace Ni.Mathematics.Tests
{
    public class TestRigidNiTransform : TransformTests
    {
        [Test] public void CtorTranslationRotation() => TestCtor<RigidTransform3>("float3 translation, quaternion rotation", new RigidTransform3(RT0_T, RT0_R), M4RT0);
        [Test] public void CtorTranslation() => TestCtor<RigidTransform3>("float3 translation", new RigidTransform3(RT0_T), float4x4.TRS(RT0_T, quaternion.identity, 1));
        [Test] public void CtorRotation() => TestCtor<RigidTransform3>("quaternion rotation", new RigidTransform3(RT0_R), float4x4.TRS(0, RT0_R, 1));
        [Test] public void CtorTranslationRotationTransform() => TestCtor<RigidTransform3>("TranslationTransform3 translation, RotationQTransform3 rotation", new RigidTransform3(TT0, RQT0), float4x4.TRS(TT0_T, RQT0_R, 1));
        [Test] public void CtorTranslationTransform() => TestCtor<RigidTransform3>("TranslationTransform3 translation", new RigidTransform3(TT0), float4x4.TRS(TT0_T, quaternion.identity, 1));
        [Test] public void CtorRotationTransform() => TestCtor<RigidTransform3>("RotationQTransform3 rotation", new RigidTransform3(RQT0), float4x4.TRS(0, RQT0_R, 1));
        [Test] public void Identity() => TestIdentity<RigidTransform3>(RigidTransform3.Identity);
        [Test] public void Inversed() => TestInversed<RigidTransform3>(RT0, M4RTi0);
        [Test] public void Translated() => TestTranslated<RigidTransform3>(RT0, Translation, M4(M4Translation, M4RT0));
        [Test] public void Rotated() => TestRotated<RigidTransform3>(RT0, Rotation, M4(M4Rotation, M4RT0));
        [Test] public void Scaled1() => TestScaled1<RigidTransform3, UniformTransform3>(RT0, Scale1, M4(M4Scale1, M4RT0));
        [Test] public void Scaled3() => TestScaled3<RigidTransform3, Matrix4x4Transform3>(RT0, Scale3, M4(M4Scale3, M4RT0));
        [Test] public void TestTranslate() => TestTranslate<RigidTransform3, RigidTransform3>(RT0, Translation, M4(M4RT0, M4Translation));
        [Test] public void TestRotate() => TestRotate<RigidTransform3>(RT0, Rotation, M4(M4RT0, M4Rotation));
        [Test] public void TestScale1() => TestScaleFloat<RigidTransform3, UniformTransform3>(RT0, Scale1, M4(M4RT0, M4Scale1));
        [Test] public void TestScale3() => TestScaleFloat3<RigidTransform3, NonUniformTransform3>(RT0, Scale3, M4(M4RT0, M4Scale3));
        [Test] public void MulTranslationTransform() => TestMul<RigidTransform3, Translation3, RigidTransform3>(RT0, TT1, M4(M4RT0, M4TT1));
        [Test] public void MulRotationQTransform() => TestMul<RigidTransform3, Rotation3Q, RigidTransform3>(RT0, RQT1, M4(M4RT0, M4RQT1));
        [Test] public void MulUniformScaleTransform() => TestMul<RigidTransform3, Scale1, UniformTransform3>(RT0, UST1, M4(M4RT0, M4UST1));
        [Test] public void MulNonUniformScaleTransform() => TestMul<RigidTransform3, Scale3, NonUniformTransform3>(RT0, NUST1, M4(M4RT0, M4NUST1));
        [Test] public void MulRigidTransformNi() => TestMul<RigidTransform3, RigidTransform3, RigidTransform3>(RT0, RT1, M4(M4RT0, M4RT1));
        [Test] public void MulUniformTransform() => TestMul<RigidTransform3, UniformTransform3, UniformTransform3>(RT0, UT1, M4(M4RT0, M4UT1));
        [Test] public void MulNonUniformTransform() => TestMul<RigidTransform3, NonUniformTransform3, NonUniformTransform3>(RT0, NUT1, M4(M4RT0, M4NUT1));
        [Test] public void MulMatrix3x3Transform() => TestMul<RigidTransform3, Matrix3x3Transform3, Matrix4x4Transform3>(RT0, M3T1, M4(M4RT0, M4M3T1));
        [Test] public void MulMatrix4x4Transform() => TestMul<RigidTransform3, Matrix4x4Transform3, Matrix4x4Transform3>(RT0, M4T1, M4(M4RT0, M4M4T1));
        [Test] public void DivTranslationTransform() => TestDiv<RigidTransform3, Translation3, RigidTransform3>(RT0, TT1, M4(M4RTi0, M4TT1));
        [Test] public void DivRotationQTransform() => TestDiv<RigidTransform3, Rotation3Q, RigidTransform3>(RT0, RQT1, M4(M4RTi0, M4RQT1));
        [Test] public void DivUniformScaleTransform() => TestDiv<RigidTransform3, Scale1, UniformTransform3>(RT0, UST1, M4(M4RTi0, M4UST1));
        [Test] public void DivNonUniformScaleTransform() => TestDiv<RigidTransform3, Scale3, NonUniformTransform3>(RT0, NUST1, M4(M4RTi0, M4NUST1));
        [Test] public void DivRigidTransformNi() => TestDiv<RigidTransform3, RigidTransform3, RigidTransform3>(RT0, RT1, M4(M4RTi0, M4RT1));
        [Test] public void DivUniformTransform() => TestDiv<RigidTransform3, UniformTransform3, UniformTransform3>(RT0, UT1, M4(M4RTi0, M4UT1));
        [Test] public void DivNonUniformTransform() => TestDiv<RigidTransform3, NonUniformTransform3, NonUniformTransform3>(RT0, NUT1, M4(M4RTi0, M4NUT1));
        [Test] public void DivMatrix3x3Transform() => TestDiv<RigidTransform3, Matrix3x3Transform3, Matrix4x4Transform3>(RT0, M3T1, M4(M4RTi0, M4M3T1));
        [Test] public void DivMatrix4x4Transform() => TestDiv<RigidTransform3, Matrix4x4Transform3, Matrix4x4Transform3>(RT0, M4T1, M4(M4RTi0, M4M4T1));
        [Test] public void TransformFloat3() => TestTransformFloat3(RT0, Float3, M4(M4RT0, Float3));
        [Test] public void UntransformFloat3() => TestUntransformFloat3(RT0, Float3, M4(M4RTi0, Float3));
    }
}