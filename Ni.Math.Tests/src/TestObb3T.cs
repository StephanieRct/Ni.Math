using Ni.Mathematics;
using NUnit.Framework;
using Unity.Mathematics;

namespace Ni.Mathematics.Tests
{
    public class TestObb3T : TransformTests
    {
        [Test] public void CtorNonUniformTransform() => TestCtor<Obb3T>("NonUniformTransform3 nonUniformTransform", new Obb3T(NUT0), M4NUT0);
        [Test] public void CtorTranslationRotationScale() => TestCtor<Obb3T>("float3 translation, quaternion rotation, float3 scale", new Obb3T(NUT0_T, NUT0_R, NUT0_S), float4x4.TRS(NUT0_T, NUT0_R, NUT0_S));
        [Test] public void CtorTranslationRotation() => TestCtor<Obb3T>("float3 translation, quaternion rotation", new Obb3T(NUT0_T, NUT0_R), float4x4.TRS(NUT0_T, NUT0_R, I_NUS));
        [Test] public void CtorRotation() => TestCtor<Obb3T>("quaternion rotation", new Obb3T(NUT0_R), float4x4.TRS(I_T, NUT0_R, I_US));
        [Test] public void CtorTranslationRotationScaleTransform() => TestCtor<Obb3T>("TranslationTransform3 translation, RotationQTransform3 rotation, ScaleNonUniformTransform3 scale", new Obb3T(TT0, RQT0, NUST0), float4x4.TRS(TT0_T, RQT0_R, NUST0_S));
        [Test] public void CtorTranslationRotationTransform() => TestCtor<Obb3T>("TranslationTransform3 translation, RotationQTransform3 rotation", new Obb3T(TT0, RQT0), float4x4.TRS(TT0_T, RQT0_R, I_US));
        [Test] public void CtorTranslationScaleTransform() => TestCtor<Obb3T>("TranslationTransform3 translation, ScaleNonUniformTransform3 scale", new Obb3T(TT0, NUST0), float4x4.TRS(TT0_T, I_R, NUST0_S));
        [Test] public void CtorRotationScaleTransform() => TestCtor<Obb3T>("RotationQTransform3 rotation, ScaleNonUniformTransform3 scale", new Obb3T(RQT0, NUST0), float4x4.TRS(I_T, RQT0_R, NUST0_S));
        [Test] public void CtorTranslationTransform() => TestCtor<Obb3T>("TranslationTransform3 translation", new Obb3T(TT0), float4x4.TRS(TT0_T, I_R, I_US));
        [Test] public void CtorRotationTransform() => TestCtor<Obb3T>("RotationQTransform3 rotation", new Obb3T(RQT0), float4x4.TRS(I_T, RQT0_R, I_US));
        [Test] public void CtorScaleTransform() => TestCtor<Obb3T>("ScaleNonUniformTransform3 scale", new Obb3T(NUST0), float4x4.TRS(I_T, I_R, NUST0_S));
        [Test] public void Identity() => TestIdentity<Obb3T>(Obb3T.Identity);
        [Test] public void Inversed() => TestInversed<Obb3T, Obb3M>(Obb3T0, M4Obb3Ti0);
        [Test] public void Translated() => TestTranslated<Obb3T>(Obb3T0, Translation, M4(M4Translation, M4Obb3T0));
        [Test] public void Rotated() => TestRotated<Obb3T, Obb3T>(Obb3T0, Rotation, M4(M4Rotation, M4Obb3T0));
        [Test] public void Scaled1() => TestScaled1<Obb3T>(Obb3T0, Scale1, M4(M4Scale1, M4Obb3T0));
        [Test] public void Scaled3() => TestScaled3<Obb3T, Obb3M>(Obb3T0, Scale3, M4(M4Scale3, M4Obb3T0));
        [Test] public void TestTranslate() => TestTranslate<Obb3T, Obb3T>(Obb3T0, Translation, M4(M4Obb3T0, M4Translation));
        [Test] public void TestRotate() => TestRotate<Obb3T, Obb3M>(Obb3T0, Rotation, M4(M4Obb3T0, M4Rotation));
        [Test] public void TestScale1() => TestScaleFloat<Obb3T, Obb3T>(Obb3T0, Scale1, M4(M4Obb3T0, M4Scale1));
        [Test] public void TestScale3() => TestScaleFloat3<Obb3T, Obb3T>(Obb3T0, Scale3, M4(M4Obb3T0, M4Scale3));
        [Test] public void MulTranslationTransform() => TestMul<Obb3T, Translation3, Obb3T>(Obb3T0, TT1, M4(M4Obb3T0, M4TT1));
        [Test] public void MulRotationQTransform() => TestMul<Obb3T, Rotation3Q, Obb3M>(Obb3T0, RQT1, M4(M4Obb3T0, M4RQT1));
        [Test] public void MulUniformScaleTransform() => TestMul<Obb3T, Scale1, Obb3T>(Obb3T0, UST1, M4(M4Obb3T0, M4UST1));
        [Test] public void MulNonUniformScaleTransform() => TestMul<Obb3T, Scale3, Obb3T>(Obb3T0, NUST1, M4(M4Obb3T0, M4NUST1));
        [Test] public void MulRigidTransformNi() => TestMul<Obb3T, RigidTransform3, Obb3M>(Obb3T0, RT1, M4(M4Obb3T0, M4RT1));
        [Test] public void MulUniformTransform() => TestMul<Obb3T, UniformTransform3, Obb3M>(Obb3T0, UT1, M4(M4Obb3T0, M4UT1));
        [Test] public void MulNonUniformTransform() => TestMul<Obb3T, NonUniformTransform3, Obb3M>(Obb3T0, NUT1, M4(M4Obb3T0, M4NUT1));
        [Test] public void MulMatrix3x3Transform() => TestMul<Obb3T, Matrix3x3Transform3, Obb3M>(Obb3T0, M3T1, M4(M4Obb3T0, M4M3T1));
        [Test] public void MulMatrix4x4Transform() => TestMul<Obb3T, Matrix4x4Transform3, Obb3M>(Obb3T0, M4T1, M4(M4Obb3T0, M4M4T1));
        [Test] public void DivTranslationTransform() => TestDiv<Obb3T, Translation3, Obb3M>(Obb3T0, TT1, M4(M4Obb3Ti0, M4TT1));
        [Test] public void DivRotationQTransform() => TestDiv<Obb3T, Rotation3Q, Obb3M>(Obb3T0, RQT1, M4(M4Obb3Ti0, M4RQT1));
        [Test] public void DivUniformScaleTransform() => TestDiv<Obb3T, Scale1, Obb3M>(Obb3T0, UST1, M4(M4Obb3Ti0, M4UST1));
        [Test] public void DivNonUniformScaleTransform() => TestDiv<Obb3T, Scale3, Obb3M>(Obb3T0, NUST1, M4(M4Obb3Ti0, M4NUST1));
        [Test] public void DivRigidTransformNi() => TestDiv<Obb3T, RigidTransform3, Obb3M>(Obb3T0, RT1, M4(M4Obb3Ti0, M4RT1));
        [Test] public void DivUniformTransform() => TestDiv<Obb3T, UniformTransform3, Obb3M>(Obb3T0, UT1, M4(M4Obb3Ti0, M4UT1));
        [Test] public void DivNonUniformTransform() => TestDiv<Obb3T, NonUniformTransform3, Obb3M>(Obb3T0, NUT1, M4(M4Obb3Ti0, M4NUT1));
        [Test] public void DivMatrix3x3Transform() => TestDiv<Obb3T, Matrix3x3Transform3, Obb3M>(Obb3T0, M3T1, M4(M4Obb3Ti0, M4M3T1));
        [Test] public void DivMatrix4x4Transform() => TestDiv<Obb3T, Matrix4x4Transform3, Obb3M>(Obb3T0, M4T1, M4(M4Obb3Ti0, M4M4T1));
        [Test] public void TransformFloat3() => TestTransformFloat3(Obb3T0, Float3, M4(M4Obb3T0, Float3));
        [Test] public void UntransformFloat3() => TestUntransformFloat3(Obb3T0, Float3, M4(M4Obb3Ti0, Float3));
    }

    public partial class TransformTests
    {
        public static readonly float3 Obb3T0_T = new float3(3.2f, -4.5f, 6.8f);
        public static readonly quaternion Obb3T0_R = quaternion.EulerXYZ(new float3(7.7f, -5.8f, 2.6f));
        public static readonly float3 Obb3T0_S = new float3(7.7f, -5.8f, 2.6f);
        public static readonly float3 Obb3T1_T = new float3(1.8f, 2.4f, -1.7f);
        public static readonly quaternion Obb3T1_R = quaternion.EulerXYZ(new float3(3.7f, 2.6f, -5.8f));
        public static readonly float3 Obb3T1_S = new float3(3.7f, -5.8f, 2.6f);

        public static readonly Obb3T Obb3T0 = new Obb3T(Obb3T0_T, Obb3T0_R, Obb3T0_S);
        public static readonly Obb3T Obb3T1 = new Obb3T(Obb3T1_T, Obb3T1_R, Obb3T1_S);


        public static readonly float4x4 M4Obb3T0 = Obb3T0.ToMatrix4x4Transform;
        public static readonly float4x4 M4Obb3T1 = Obb3T1.ToMatrix4x4Transform;
        public static readonly float4x4 M4Obb3Ti0 = math.inverse(Obb3T0.ToMatrix4x4Transform);
        public static readonly float4x4 M4Obb3Ti1 = math.inverse(Obb3T1.ToMatrix4x4Transform);


    }
}