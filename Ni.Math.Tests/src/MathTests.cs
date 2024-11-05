using Ni.Mathematics;
using NUnit.Framework;
using Unity.Mathematics;

namespace Ni.Mathematics.Tests
{

    public class MathTests
    {

        public int Test<T>(string operation, T result, T expected)
            where T : INearEquatable<T>
        {
            if (!result.NearEquals(expected, 0.0001f))
                Assert.Fail($"{operation}. Result transform must be equal to expectation\ne: {expected}\nr: {result}");
            return 0;
        }

        public int Test(string operation, float result, float expected)
        {
            if (!NiMath.NearEqual(result, expected, 0.0001f))
                Assert.Fail($"{operation}. Result transform must be equal to expectation\ne: {expected}\nr: {result}");
            return 0;
        }

        public int Test(string operation, float2 result, float2 expected)
        {
            if (!NiMath.NearEqual(result, expected, 0.0001f))
                Assert.Fail($"{operation}. Result transform must be equal to expectation\ne: {expected}\nr: {result}");
            return 0;
        }

        public int Test(string operation, float3 result, float3 expected)
        {
            if (!NiMath.NearEqual(result, expected, 0.0001f))
                Assert.Fail($"{operation}. Result transform must be equal to expectation\ne: {expected}\nr: {result}");
            return 0;
        }

        public int Test(string operation, float4 result, float4 expected)
        {
            if (!NiMath.NearEqual(result, expected, 0.0001f))
                Assert.Fail($"{operation}. Result transform must be equal to expectation\ne: {expected}\nr: {result}");
            return 0;
        }

        public int Test(string operation, quaternion result, quaternion expected)
        {
            if (!NiMath.NearEqual(result, expected, 0.0001f))
                Assert.Fail($"{operation}. Result transform must be equal to expectation\ne: {expected}\nr: {result}");
            return 0;
        }

        public int Test(string operation, float3x3 result, float3x3 expected)
        {
            if (!NiMath.NearEqual(result, expected, 0.0001f))
                Assert.Fail($"{operation}. Result transform must be equal to expectation\ne: {expected}\nr: {result}");
            return 0;
        }

        public int Test(string operation, float4x4 result, float4x4 expected)
        {
            if (!NiMath.NearEqual(result, expected, 0.0001f))
                Assert.Fail($"{operation}. Result transform must be equal to expectation\ne: {expected}\nr: {result}");
            return 0;
        }
    }
}