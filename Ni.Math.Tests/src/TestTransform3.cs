using Unity.Mathematics;
using Ni.Mathematics;
using NUnit.Framework;

namespace Ni.Mathematics.Tests
{
    public partial class TransformTests
    {
        public static readonly float3 I_T = float3.zero;
        public static readonly quaternion I_R = quaternion.identity;
        public static readonly float I_US = 1;
        public static readonly float3 I_NUS = 1;

        //, 9.5f, 2.4f, 3.7f, -5.8f, 2.6f, 1.8f, 2.4f, -1.7f, -3.6f, 7.2f, -4.5f, 6.8f, -8.2f, 5.7f, 5.1f, -5.3f, -8.5f, -3.5f, 7.4f, 5.3f);
        public static readonly float3 TT0_T = new float3(3.5f, -4, 1);
        public static readonly quaternion RQT0_R = quaternion.EulerXYZ(1, 2, -3);
        public static readonly float3 RET0_R = new float3(2.1f, -6, 3.5f);
        public static readonly float UST0_S = 4.7f;
        public static readonly float3 NUST0_S = new float3(8.7f, -6.5f, 1);
        public static readonly float3 RT0_T = new float3(9.7f, 7.2f, -3.9f);
        public static readonly quaternion RT0_R = quaternion.EulerXYZ(-3.1f, 8.4f, 3.8f);
        public static readonly float3 UT0_T = new float3(9.3f, 9.5f, 9.7f);
        public static readonly quaternion UT0_R = quaternion.EulerXYZ(8.9f, -7.4f, 6.8f);
        public static readonly float UT0_S = 6.1f;
        public static readonly float3 NUT0_T = new float3(8.9f, 2.3f, 7.9f);
        public static readonly quaternion NUT0_R = quaternion.EulerXYZ(2.5f, 9.2f, 4.2f);
        public static readonly float3 NUT0_S = 6.8f;
        public static readonly quaternion M30_R = quaternion.EulerXYZ(5.3f, 4.9f, 5.2f);
        public static readonly float3 M30_S = new float3(3.7f, 6.6f, 8.7f);
        public static readonly float3 M40_T = new float3(4.2f, 7.1f, 4.7f);
        public static readonly quaternion M40_R = quaternion.EulerXYZ(7.8f, 7.6f, 4.6f);
        public static readonly float3 M40_S = 5.1f;
        public static readonly float4x4 M40_4x4 = float4x4.TRS(M40_T, M40_R, M40_S);

        public static readonly float3 TT1_T = new float3(8, 10, 0);
        public static readonly quaternion RQT1_R = quaternion.EulerXYZ(-6.5f, 1.7f, 0.1f);
        public static readonly float3 RET1_R = new float3(2.3f, 7.6f, 8.1f);
        public static readonly float UST1_S = 6.3f;
        public static readonly float3 NUST1_S = new float3(4.2f, 6.4f, 5.1f);
        public static readonly float3 RT1_T = new float3(4.2f, 6.4f, 5.1f);
        public static readonly quaternion RT1_R = quaternion.EulerXYZ(4.2f, 6.4f, 5.1f);
        public static readonly float3 UT1_T = new float3(4.2f, 6.4f, 5.1f);
        public static readonly quaternion UT1_R = quaternion.EulerXYZ(9.6f, 1.5f, 8.1f);
        public static readonly float UT1_S = 7.6f;
        public static readonly float3 NUT1_T = new float3(5.9f, 7.6f, 7.7f);
        public static readonly quaternion NUT1_R = quaternion.EulerXYZ(4.3f, 5.2f, 9.9f);
        public static readonly float3 NUT1_S = 5.9f;
        public static readonly quaternion M31_R = quaternion.EulerXYZ(4.3f, 5.2f, 9.9f);
        public static readonly float3 M31_S = new float3(4.3f, 5.2f, 9.9f);
        public static readonly float3 M41_T = new float3(1.4f, 4.1f, 5.6f);
        public static readonly quaternion M41_R = quaternion.EulerXYZ(8.4f, 6.4f, 3.5f);
        public static readonly float3 M41_S = 1.3f;

        public static readonly float3 TTi0_T = -TT0_T;
        public static readonly quaternion RQTi0_R = math.inverse(RQT0_R);
        public static readonly float3 RETi0_R = -RET0_R;
        public static readonly float USTi0_S = 1.0f / UST0_S;
        public static readonly float3 NUSTi0_S = 1.0f / NUST0_S;
        public static readonly float3 RTi0_T = -RT0_T;
        public static readonly quaternion RTi0_R = math.inverse(RT0_R);
        public static readonly float3 UTi0_T = -UT0_T;
        public static readonly quaternion UTi0_R = math.inverse(UT0_R);
        public static readonly float UTi0_S = 1.0f / UT0_S;
        public static readonly float3 NUTi0_T = -NUT0_T;
        public static readonly quaternion NUTi0_R = math.inverse(NUT0_R);
        public static readonly float3 NUTi0_S = 1.0f / NUT0_S;
        public static readonly quaternion M3i0_R = math.inverse(M30_R);
        public static readonly float3 M3i0_S = 1.0f / M30_S;
        public static readonly float3 M4i0_T = -M40_T;
        public static readonly quaternion M4i0_R = math.inverse(M40_R);
        public static readonly float3 M4i0_S = 1.0f / M40_S;


        public static readonly float3 TTi1_T = -TT1_T;
        public static readonly quaternion RQTi1_R = math.inverse(RQT1_R);
        public static readonly float3 RETi1_R = -RET1_R;
        public static readonly float USTi1_S = 1.0f / UST1_S;
        public static readonly float3 NUSTi1_S = 1.0f / NUST1_S;
        public static readonly float3 RTi1_T = -RT1_T;
        public static readonly quaternion RTi1_R = math.inverse(RT1_R);
        public static readonly float3 UTi1_T = -UT1_T;
        public static readonly quaternion UTi1_R = math.inverse(UT1_R);
        public static readonly float UTi1_S = 1.0f / UT1_S;
        public static readonly float3 NUTi1_T = -NUT1_T;
        public static readonly quaternion NUTi1_R = math.inverse(NUT1_R);
        public static readonly float3 NUTi1_S = 1.0f / NUT1_S;
        public static readonly quaternion M3i1_R = math.inverse(M31_R);
        public static readonly float3 M3i1_S = 1.0f / M31_S;
        public static readonly float3 M4i1_T = -M41_T;
        public static readonly quaternion M4i1_R = math.inverse(M41_R);
        public static readonly float3 M4i1_S = 1.0f / M41_S;

        public static readonly float3x3 M30 = math.mul(new float3x3(M30_R), float3x3.Scale(M30_S));

        public static readonly Translation3 TT0 = new Translation3(TT0_T);
        public static readonly Rotation3Q RQT0 = new Rotation3Q(RQT0_R);
        public static readonly Rotation3Euler RET0 = new Rotation3Euler(RET0_R);
        public static readonly Scale1 UST0 = new Scale1(UST0_S);
        public static readonly Scale3 NUST0 = new Scale3(NUST0_S);
        public static readonly RigidTransform3 RT0 = new RigidTransform3(RT0_T, RT0_R);
        public static readonly UniformTransform3 UT0 = new UniformTransform3(UT0_T, UT0_R, UT0_S);
        public static readonly NonUniformTransform3 NUT0 = new NonUniformTransform3(NUT0_T, NUT0_R, NUT0_S);
        public static readonly Matrix3x3Transform3 M3T0 = new Matrix3x3Transform3(M30_R, M30_S);
        public static readonly Matrix4x4Transform3 M4T0 = new Matrix4x4Transform3(M40_T, M40_R, M40_S);

        public static readonly Translation3 TT1 = new Translation3(TT1_T);
        public static readonly Rotation3Q RQT1 = new Rotation3Q(RQT1_R);
        public static readonly Rotation3Euler RET1 = new Rotation3Euler(RET1_R);
        public static readonly Scale1 UST1 = new Scale1(UST1_S);
        public static readonly Scale3 NUST1 = new Scale3(NUST1_S);
        public static readonly RigidTransform3 RT1 = new RigidTransform3(RT1_T, RT1_R);
        public static readonly UniformTransform3 UT1 = new UniformTransform3(UT1_T, UT1_R, UT1_S);
        public static readonly NonUniformTransform3 NUT1 = new NonUniformTransform3(NUT1_T, NUT1_R, NUT1_S);
        public static readonly Matrix3x3Transform3 M3T1 = new Matrix3x3Transform3(M31_R, M31_S);
        public static readonly Matrix4x4Transform3 M4T1 = new Matrix4x4Transform3(M41_T, M41_R, M41_S);

        public static readonly Translation3 TTIdentity = new Translation3(float3.zero);
        public static readonly Rotation3Q RQTIdentity = new Rotation3Q(quaternion.identity);
        public static readonly Rotation3Euler RETIdentity = new Rotation3Euler(float3.zero);
        public static readonly Scale1 USTIdentity = new Scale1(1);
        public static readonly Scale3 NUSTIdentity = new Scale3((float3)1);
        public static readonly RigidTransform3 RTIdentity = new RigidTransform3(float3.zero, quaternion.identity);
        public static readonly UniformTransform3 UTIdentity = new UniformTransform3(float3.zero, quaternion.identity, 1);
        public static readonly NonUniformTransform3 NUTIdentity = new NonUniformTransform3(float3.zero, quaternion.identity, 1);
        public static readonly Matrix3x3Transform3 M3TIdentity = new Matrix3x3Transform3(quaternion.identity, 1);
        public static readonly Matrix4x4Transform3 M4TIdentity = new Matrix4x4Transform3(float3.zero, quaternion.identity, 1);


        public static readonly float3 Translation = new float3(3.5f, -4, 1);
        public static readonly float Scale1 = 5.7f;
        public static readonly float3 Scale3 = new float3(8.7f, -6.5f, 1);
        public static readonly quaternion Rotation = quaternion.EulerXYZ(1, 2, -3);
        public static readonly float3 Euler = new float3(1, 2, -3);
        public static readonly float3 Float3 = new float3(9.4f, 3.2f, -3);

        public static readonly float3 M30C0 = M3T0.matrix.c0;
        public static readonly float3 M30C1 = M3T0.matrix.c1;
        public static readonly float3 M30C2 = M3T0.matrix.c2;

        public static readonly float4 M40C0 = M4T0.matrix.c0;
        public static readonly float4 M40C1 = M4T0.matrix.c1;
        public static readonly float4 M40C2 = M4T0.matrix.c2;
        public static readonly float4 M40C3 = M4T0.matrix.c3;

        public static readonly float4x4 M4TT0 = TT0.ToMatrix4x4Transform;
        public static readonly float4x4 M4RQT0 = RQT0.ToMatrix4x4Transform;
        public static readonly float4x4 M4RET0 = RET0.ToMatrix4x4Transform;
        public static readonly float4x4 M4UST0 = UST0.ToMatrix4x4Transform;
        public static readonly float4x4 M4NUST0 = NUST0.ToMatrix4x4Transform;
        public static readonly float4x4 M4RT0 = RT0.ToMatrix4x4Transform;
        public static readonly float4x4 M4UT0 = UT0.ToMatrix4x4Transform;
        public static readonly float4x4 M4NUT0 = NUT0.ToMatrix4x4Transform;
        public static readonly float4x4 M4M3T0 = M3T0.ToMatrix4x4Transform;
        public static readonly float4x4 M4M4T0 = M4T0.ToMatrix4x4Transform;

        public static readonly float4x4 M4TT1 = TT1.ToMatrix4x4Transform;
        public static readonly float4x4 M4RQT1 = RQT1.ToMatrix4x4Transform;
        public static readonly float4x4 M4RET1 = RET1.ToMatrix4x4Transform;
        public static readonly float4x4 M4UST1 = UST1.ToMatrix4x4Transform;
        public static readonly float4x4 M4NUST1 = NUST1.ToMatrix4x4Transform;
        public static readonly float4x4 M4RT1 = RT1.ToMatrix4x4Transform;
        public static readonly float4x4 M4UT1 = UT1.ToMatrix4x4Transform;
        public static readonly float4x4 M4NUT1 = NUT1.ToMatrix4x4Transform;
        public static readonly float4x4 M4M3T1 = M3T1.ToMatrix4x4Transform;
        public static readonly float4x4 M4M4T1 = M4T1.ToMatrix4x4Transform;


        public static readonly float4x4 M4TTi0 = math.inverse(TT0.ToMatrix4x4Transform);
        public static readonly float4x4 M4RQTi0 = math.inverse(RQT0.ToMatrix4x4Transform);
        public static readonly float4x4 M4RETi0 = math.inverse(RET0.ToMatrix4x4Transform);
        public static readonly float4x4 M4USTi0 = math.inverse(UST0.ToMatrix4x4Transform);
        public static readonly float4x4 M4NUSTi0 = math.inverse(NUST0.ToMatrix4x4Transform);
        public static readonly float4x4 M4RTi0 = math.inverse(RT0.ToMatrix4x4Transform);
        public static readonly float4x4 M4UTi0 = math.inverse(UT0.ToMatrix4x4Transform);
        public static readonly float4x4 M4NUTi0 = math.inverse(NUT0.ToMatrix4x4Transform);
        public static readonly float4x4 M4M3Ti0 = math.inverse(M3T0.ToMatrix4x4Transform);
        public static readonly float4x4 M4M4Ti0 = math.inverse(M4T0.ToMatrix4x4Transform);

        public static readonly float4x4 M4TTi1 = math.inverse(TT1.ToMatrix4x4Transform);
        public static readonly float4x4 M4RQTi1 = math.inverse(RQT1.ToMatrix4x4Transform);
        public static readonly float4x4 M4RETi1 = math.inverse(RET1.ToMatrix4x4Transform);
        public static readonly float4x4 M4USTi1 = math.inverse(UST1.ToMatrix4x4Transform);
        public static readonly float4x4 M4NUSTi1 = math.inverse(NUST1.ToMatrix4x4Transform);
        public static readonly float4x4 M4RTi1 = math.inverse(RT1.ToMatrix4x4Transform);
        public static readonly float4x4 M4UTi1 = math.inverse(UT1.ToMatrix4x4Transform);
        public static readonly float4x4 M4NUTi1 = math.inverse(NUT1.ToMatrix4x4Transform);
        public static readonly float4x4 M4M3Ti1 = math.inverse(M3T1.ToMatrix4x4Transform);
        public static readonly float4x4 M4M4Ti1 = math.inverse(M4T1.ToMatrix4x4Transform);

        public static readonly float4x4 M4Translation = float4x4.Translate(Translation);
        public static readonly float4x4 M4Scale1 = float4x4.Scale(Scale1);
        public static readonly float4x4 M4Scale3 = float4x4.Scale(Scale3);
        public static readonly float4x4 M4Rotation = new float4x4(Rotation, float3.zero);
        public static readonly float4x4 M4Euler = new float4x4(quaternion.EulerXYZ(Euler), float3.zero);

        public float4x4 M4(float3 translation, quaternion rotation, float3 scale) => float4x4.TRS(translation, rotation, scale);

        public float3 M4_Translation(float4x4 m) => m.c3.xyz;
        public quaternion M4_Rotation(float4x4 m) => new quaternion(m);
        public float3 M4_Scale(float4x4 m) => new float3(math.length(m.c0.xyz), math.length(m.c1.xyz), math.length(m.c2.xyz));

        public float4x4 M4(float4x4 a, float4x4 b) => math.mul(a, b);
        public float3 M4(float4x4 a, float3 b) => math.transform(a, b);

        public bool AreEqual(float3 a, float3 b, float margin = 0.001f) => math.all(math.abs(a - b) <= margin);
        public bool AreEqual(float4x4 a, float4x4 b, float margin = 0.001f) => math.all(math.abs(a.c0 - b.c0) <= margin & math.abs(a.c1 - b.c1) <= margin & math.abs(a.c2 - b.c2) <= margin & math.abs(a.c3 - b.c3) <= margin);
        public bool AreEqual<T0, T1>(T0 a, T1 b, float margin = 0.001f)
            where T0 : INearEquatable<T1, float>
            => a.NearEquals(b, margin);



        public int Test<TTransform>(string operation, TTransform transform, float4x4 expected)
            where TTransform : IToMatrix4x4Transform
        {
            var result4x4 = (float4x4)transform.ToMatrix4x4Transform;
            if (!AreEqual(result4x4, expected, 0.0001f))
                Assert.Fail($"{operation}. {typeof(TTransform).Name}. Result transform must be equal to expectation\ne: {expected}\nr: {result4x4}");
            return 0;
        }

        public int TestCtor<TTransform>(string parameters, TTransform transform, float4x4 expected)
            where TTransform : IToMatrix4x4Transform
            => Test<TTransform>($"T.Ctor({parameters})", transform, expected);

        public int TestIdentity<TTransform>(TTransform transform)
            where TTransform : IToMatrix4x4Transform
            => Test<TTransform>("T.Identity", transform, float4x4.identity);

        public int TestTranslated<TTransform>(TTransform transform, float3 translation, float4x4 expected)
            where TTransform : IToMatrix4x4Transform, ITranslated<TTransform, float3>
        {
            var result = transform.Translated(translation);
            var result4x4 = (float4x4)result.ToMatrix4x4Transform;
            if (!AreEqual(result4x4, expected, 0.0001f))
                Assert.Fail($"T' == T.Translated(float3). {typeof(TTransform).Name}. Result transform must be equal to expectation\ne: {expected}\nr: {result4x4}");
            return 0;
        }
        public int TestTranslated<TTransform, TPrime>(TTransform transform, float3 translation, float4x4 expected)
            where TTransform : ITranslated<TPrime, float3>
            where TPrime : IToMatrix4x4Transform
        {
            var result = transform.Translated(translation);
            var result4x4 = (float4x4)result.ToMatrix4x4Transform;
            if (!AreEqual(result4x4, expected, 0.0001f))
                Assert.Fail($"T' == T.Translated(float3). {typeof(TTransform).Name}. Result transform must be equal to expectation\ne: {expected}\nr: {result4x4}");
            return 0;
        }

        public int TestRotated<TTransform>(TTransform transform, quaternion rotation, float4x4 expected)
            where TTransform : IToMatrix4x4Transform, IRotated<TTransform, quaternion>
        {
            var result = transform.Rotated(rotation);
            var result4x4 = (float4x4)result.ToMatrix4x4Transform;
            if (!AreEqual(result4x4, expected, 0.0001f))
                Assert.Fail($"T' == T.Rotated(quaternion). {typeof(TTransform).Name}. Result transform must be equal to expectation\ne: {expected}\nr: {result4x4}");
            return 0;
        }

        public int TestRotated<TTransform, TPrime>(TTransform transform, quaternion rotation, float4x4 expected)
            where TTransform : IRotated<TPrime, quaternion>
            where TPrime : IToMatrix4x4Transform
        {
            var result = transform.Rotated(rotation);
            var result4x4 = (float4x4)result.ToMatrix4x4Transform;
            if (!AreEqual(result4x4, expected, 0.0001f))
                Assert.Fail($"T' == T.Rotated(quaternion). {typeof(TTransform).Name}. Result transform must be equal to expectation\ne: {expected}\nr: {result4x4}");
            return 0;
        }

        public int TestScaled1<TTransform>(TTransform transform, float scale, float4x4 expected)
            where TTransform : IToMatrix4x4Transform, IScaled<TTransform, float>
        {
            var result = transform.Scaled(scale);
            var result4x4 = (float4x4)result.ToMatrix4x4Transform;
            if (!AreEqual(result4x4, expected, 0.0001f))
                Assert.Fail($"T' == T.Scaled(float). {typeof(TTransform).Name}. Result transform must be equal to expectation\ne: {expected}\nr: {result4x4}");
            return 0;
        }

        public int TestScaled1<TTransform, TPrime>(TTransform transform, float scale, float4x4 expected)
            where TTransform : IScaled<TPrime, float>
            where TPrime : IToMatrix4x4Transform
        {
            var result = transform.Scaled(scale);
            var result4x4 = (float4x4)result.ToMatrix4x4Transform;
            if (!AreEqual(result4x4, expected, 0.0001f))
                Assert.Fail($"T' == T.Scaled(float). {typeof(TTransform).Name}. Result transform must be equal to expectation\ne: {expected}\nr: {result4x4}");
            return 0;
        }

        public int TestScaled3<TTransform>(TTransform transform, float3 scale, float4x4 expected)
            where TTransform : IToMatrix4x4Transform, IScaled<TTransform, float3>
        {
            var result = transform.Scaled(scale);
            var result4x4 = (float4x4)result.ToMatrix4x4Transform;
            if (!AreEqual(result4x4, expected, 0.0001f))
                Assert.Fail($"T' == T.Scaled(float3). {typeof(TTransform).Name}. Result transform must be equal to expectation\ne: {expected}\nr: {result4x4}");
            return 0;
        }

        public int TestScaled3<TTransform, TPrime>(TTransform transform, float3 scale, float4x4 expected)
            where TTransform : IScaled<TPrime, float3>
            where TPrime : IToMatrix4x4Transform
        {
            var result = transform.Scaled(scale);
            var result4x4 = (float4x4)result.ToMatrix4x4Transform;
            if (!AreEqual(result4x4, expected, 0.0001f))
                Assert.Fail($"T' == T.Scaled(float3). {typeof(TTransform).Name}. Result transform must be equal to expectation\ne: {expected}\nr: {result4x4}");
            return 0;
        }

        public int TestInversed<TTransform>(TTransform transform, float4x4 expected)
            where TTransform : IToMatrix4x4Transform, IInvertible<TTransform>
        {
            var result = transform.Inversed;
            var result4x4 = (float4x4)result.ToMatrix4x4Transform;
            if (!AreEqual(result4x4, expected, 0.0001f))
                Assert.Fail($"T' == T.Inversed. {typeof(TTransform).Name}. Result transform must be equal to expectation\ne: {expected}\nr: {result4x4}");
            return 0;
        }

        public int TestInversed<TTransform, TPrime>(TTransform transform, float4x4 expected)
            where TTransform : IInvertible<TPrime>
            where TPrime : IToMatrix4x4Transform
        {
            var result = transform.Inversed;
            var result4x4 = (float4x4)result.ToMatrix4x4Transform;
            if (!AreEqual(result4x4, expected, 0.0001f))
                Assert.Fail($"T' == T.Inversed. {typeof(TTransform).Name}. Result transform must be equal to expectation\ne: {expected}\nr: {result4x4}");
            return 0;
        }

        public int TestTranslate<TTransform>(TTransform transform, float3 translation, float4x4 expected)
            where TTransform : IToMatrix4x4Transform, ITranslate<TTransform, float3>
        {
            var result = transform.Translate(translation);
            var result4x4 = (float4x4)result.ToMatrix4x4Transform;
            if (!AreEqual(result4x4, expected, 0.0001f))
                Assert.Fail($"T' == T.Translate(t). {typeof(TTransform).Name}. Result transform must be equal to expectation\ne: {expected}\nr: {result4x4}");
            return 0;
        }

        public int TestTranslate<TTransform, TPrime>(TTransform transform, float3 translation, float4x4 expected)
            where TTransform : ITranslate<TPrime, float3>
            where TPrime : IToMatrix4x4Transform
        {
            var result = transform.Translate(translation);
            var result4x4 = (float4x4)result.ToMatrix4x4Transform;
            if (!AreEqual(result4x4, expected, 0.0001f))
                Assert.Fail($"T' == T.Translate(t). {typeof(TTransform).Name}. Result transform must be equal to expectation.\ne: {expected}\nr: {result4x4}");
            return 0;
        }

        public int TestRotate<TTransform>(TTransform transform, quaternion rotation, float4x4 expected)
            where TTransform : IToMatrix4x4Transform, IRotate<TTransform, quaternion>
        {
            var result = transform.Rotate(rotation);
            var result4x4 = (float4x4)result.ToMatrix4x4Transform;
            if (!AreEqual(result4x4, expected, 0.0001f))
                Assert.Fail($"T' == T.Rotate(r). {typeof(TTransform).Name}. Result transform must be equal to expectation\ne: {expected}\nr: {result4x4}");
            return 0;
        }

        public int TestRotate<TTransform, TPrime>(TTransform transform, quaternion rotation, float4x4 expected)
            where TTransform : IRotate<TPrime, quaternion>
            where TPrime : IToMatrix4x4Transform
        {
            var result = transform.Rotate(rotation);
            var result4x4 = (float4x4)result.ToMatrix4x4Transform;
            if (!AreEqual(result4x4, expected, 0.0001f))
                Assert.Fail($"T' == T.Rotate(r). {typeof(TTransform).Name}. Result transform must be equal to expectation.\ne: {expected}\nr: {result4x4}");
            return 0;
        }

        public int TestScaleFloat<TTransform>(TTransform transform, float scale, float4x4 expected)
            where TTransform : IToMatrix4x4Transform, IScale<TTransform, float>
        {
            var result = transform.Scale(scale);
            var result4x4 = (float4x4)result.ToMatrix4x4Transform;
            if (!AreEqual(result4x4, expected, 0.0001f))
                Assert.Fail($"T' == T.Scale(s). {typeof(TTransform).Name}. Result transform must be equal to expectation\ne: {expected}\nr: {result4x4}");
            return 0;
        }

        public int TestScaleFloat<TTransform, TPrime>(TTransform transform, float scale, float4x4 expected)
            where TTransform : IScale<TPrime, float>
            where TPrime : IToMatrix4x4Transform
        {
            var result = transform.Scale(scale);
            var result4x4 = (float4x4)result.ToMatrix4x4Transform;
            if (!AreEqual(result4x4, expected, 0.0001f))
                Assert.Fail($"T' == T.WithScale(s). {typeof(TTransform).Name}. Result transform must be equal to expectation.\ne: {expected}\nr: {result4x4}");
            return 0;
        }

        public int TestScaleFloat3<TTransform>(TTransform transform, float3 scale, float4x4 expected)
            where TTransform : IToMatrix4x4Transform, IScale<TTransform, float3>
        {
            var result = transform.Scale(scale);
            var result4x4 = (float4x4)result.ToMatrix4x4Transform;
            if (!AreEqual(result4x4, expected, 0.0001f))
                Assert.Fail($"T' == T.Scale(t). {typeof(TTransform).Name}. Result transform must be equal to expectation\ne: {expected}\nr: {result4x4}");
            return 0;
        }

        public int TestScaleFloat3<TTransform, TPrime>(TTransform transform, float3 scale, float4x4 expected)
            where TTransform : IScale<TPrime, float3>
            where TPrime : IToMatrix4x4Transform
        {
            var result = transform.Scale(scale);
            var result4x4 = (float4x4)result.ToMatrix4x4Transform;
            if (!AreEqual(result4x4, expected, 0.0001f))
                Assert.Fail($"T' == T.Scale(t). {typeof(TTransform).Name}. Result transform must be equal to expectation.\ne: {expected}\nr: {result4x4}");
            return 0;
        }

        public int TestTransformFloat3<TTransform>(TTransform transform, float3 primitive, float3 expected)
            where TTransform : ITransform<float3>
        {
            var result = transform.Transform(primitive);
            if (!AreEqual(result, expected, 0.0001f))
                Assert.Fail($"x' == T.Transform(float3 x). {typeof(TTransform).Name}. Result transform must be equal to expectation\ne: {expected}\nr: {result}");
            return 0;
        }

        public int TestTransform<TTransform, TPrimitive>(TTransform transform, TPrimitive primitive, float4x4 expected)
            where TTransform : ITransform<TPrimitive>
            where TPrimitive : IToMatrix4x4Transform
        {
            var result = transform.Transform(primitive);
            var result4x4 = (float4x4)result.ToMatrix4x4Transform;
            if (!AreEqual(result4x4, expected, 0.0001f))
                Assert.Fail($"x' == T.Transform({typeof(TPrimitive).Name} x). {typeof(TTransform).Name}. Result transform must be equal to expectation\ne: {expected}\nr: {result4x4}");
            return 0;
        }

        public int TestUntransformFloat3<TTransform>(TTransform transform, float3 primitive, float3 expected)
            where TTransform : ITransform<float3>
        {
            var result = transform.Untransform(primitive);
            if (!AreEqual(result, expected, 0.0001f))
                Assert.Fail($"x' == T.Untransform(float3 x). {typeof(TTransform).Name}. Result transform must be equal to expectation\ne: {expected}\nr: {result}");
            return 0;
        }

        public int TestUntransform<TTransform, TPrimitive>(TTransform transform, TPrimitive primitive, float4x4 expected)
            where TTransform : ITransform<TPrimitive>
            where TPrimitive : IToMatrix4x4Transform
        {
            var result = transform.Untransform(primitive);
            var result4x4 = (float4x4)result.ToMatrix4x4Transform;
            if (!AreEqual(result4x4, expected, 0.0001f))
                Assert.Fail($"x' == T.Untransform({typeof(TPrimitive).Name} x). {typeof(TTransform).Name}. Result transform must be equal to expectation\ne: {expected}\nr: {result4x4}");
            return 0;
        }

        public int TestMulFloat3<TTransform>(TTransform transform, float3 primitive, float3 expected)
            where TTransform : IMultipliable<float3>
        {
            var result = transform.Mul(primitive);
            if (!AreEqual(result, expected, 0.0001f))
                Assert.Fail($"x' == T.Mul(float3 x). {typeof(TTransform).Name}. Result transform must be equal to expectation\ne: {expected}\nr: {result}");
            return 0;
        }

        public int TestMul<TTransform, TPrimitive>(TTransform transform, TPrimitive primitive, float4x4 expected)
            where TTransform : IMultipliable<TPrimitive>
            where TPrimitive : IToMatrix4x4Transform
        {
            var result = transform.Mul(primitive);
            var result4x4 = (float4x4)result.ToMatrix4x4Transform;
            if (!AreEqual(result4x4, expected, 0.0001f))
                Assert.Fail($"x' == T.Mul({typeof(TPrimitive).Name} x). {typeof(TTransform).Name}. Result transform must be equal to expectation\ne: {expected}\nr: {result4x4}");
            return 0;
        }

        public int TestMul<TTransform, TPrimitive, TPrime>(TTransform transform, TPrimitive primitive, float4x4 expected)
            where TTransform : IMultipliable<TPrimitive, TPrime>
            where TPrime : IToMatrix4x4Transform
        {
            var result = transform.Mul(primitive);
            var result4x4 = (float4x4)result.ToMatrix4x4Transform;
            if (!AreEqual(result4x4, expected, 0.0001f))
                Assert.Fail($"x' == T.Mul({typeof(TPrimitive).Name} x). {typeof(TTransform).Name}. Result transform must be equal to expectation\ne: {expected}\nr: {result4x4}");
            return 0;
        }

        public int TestDivFloat3<TTransform>(TTransform transform, float3 primitive, float3 expected)
            where TTransform : IDividable<float3>
        {
            var result = transform.Div(primitive);
            if (!AreEqual(result, expected, 0.0001f))
                Assert.Fail($"x' == T.Div(float3 x). {typeof(TTransform).Name}. Result transform must be equal to expectation\ne: {expected}\nr: {result}");
            return 0;
        }

        public int TestDiv<TTransform, TPrimitive>(TTransform transform, TPrimitive primitive, float4x4 expected)
            where TTransform : IDividable<TPrimitive>
            where TPrimitive : IToMatrix4x4Transform
        {
            var result = transform.Div(primitive);
            var result4x4 = (float4x4)result.ToMatrix4x4Transform;
            if (!AreEqual(result4x4, expected, 0.0001f))
                Assert.Fail($"x' == T.Div({typeof(TPrimitive).Name} x). {typeof(TTransform).Name}. Result transform must be equal to expectation\ne: {expected}\nr: {result4x4}");
            return 0;
        }

        public int TestDiv<TTransform, TPrimitive, TPrime>(TTransform transform, TPrimitive primitive, float4x4 expected)
            where TTransform : IDividable<TPrimitive, TPrime>
            where TPrime : IToMatrix4x4Transform
        {
            var result = transform.Div(primitive);
            var result4x4 = (float4x4)result.ToMatrix4x4Transform;
            if (!AreEqual(result4x4, expected, 0.0001f))
                Assert.Fail($"x' == T.Div({typeof(TPrimitive).Name} x). {typeof(TTransform).Name}. Result transform must be equal to expectation\ne: {expected}\nr: {result4x4}");
            return 0;
        }
    }
}