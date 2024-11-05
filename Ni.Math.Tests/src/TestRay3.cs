using Ni.Mathematics;
using NUnit.Framework;
using Unity.Mathematics;

namespace Ni.Mathematics.Tests
{
    public class TestRay3 : MathTests
    {
        public static readonly float3 RayIdentity_Axis = TestProjectionAxis3x1.ProjectionI_Axis;
        public static readonly float3 RayIdentity_T = float3.zero;

        public static readonly float3 Ray0_Axis = TestProjectionAxis3x1.Projection0_Axis;
        public static readonly float3 Ray0_T = new float3(3, -4, 1);

        public static readonly float3 RayI0_Axis = Ray0_Axis;
        public static readonly float3 RayI0_T = -Ray0_T;

        public static readonly float Input0 = 0.5f;
        public static readonly float3 Output0 = Ray0_T + Input0 * Ray0_Axis;

        public static readonly float translation1 = -5;
        public static readonly float3 translation3 = new float3(1, 4, 7);
        public static readonly quaternion rotation3 = quaternion.EulerXYZ(1, 4, 7);
        public static readonly float scale1 = 4;
        public static readonly float3 scale3 = new float3(-2, 6, 4);

        public static readonly Ray3 RayIdentity = new Ray3(RayIdentity_T, RayIdentity_Axis);
        public static readonly Ray3 Ray0 = new Ray3(Ray0_T, Ray0_Axis);
        public static readonly RayI3 RayI0 = new RayI3(RayI0_T, RayI0_Axis);

        public static readonly Ray3 Ray0Translated = new Ray3(translation3 + Ray0_T, Ray0_Axis);
        public static readonly Ray3 Ray0Rotated = new Ray3(math.mul(rotation3, Ray0_T), math.mul(rotation3, Ray0_Axis));
        public static readonly Ray3 Ray0Scaled1 = new Ray3(scale1 * Ray0_T, scale1 * Ray0_Axis);
        public static readonly Ray3 Ray0Scaled3 = new Ray3(scale3 * Ray0_T, scale3 * Ray0_Axis);

        public static readonly Ray3 Ray0Translate = new Ray3(Ray0_T + Ray0_Axis * translation1, Ray0_Axis);
        public static readonly Ray3 Ray0Rotate = new Ray3(Ray0_T, math.mul(rotation3, Ray0_Axis));
        public static readonly Ray3 Ray0Scale1 = new Ray3(Ray0_T, scale1 * Ray0_Axis);
        //public static readonly Ray3 Ray0Scale3 = new Ray3(Ray0_T, scale3 * Ray0_Axis);
        public static readonly RayI3 Ray0DivTranslation = new RayI3(translation3 - Ray0_T, Ray0_Axis);

        [Test] public void TestIdentity() => Test("Identity", Ray3.Identity, RayIdentity);


        [Test] public void TestTranslated() => Test("Translated", Ray0.Translated(translation3), Ray0Translated);
        [Test] public void TestRotated() => Test("Rotated", Ray0.Rotated(rotation3), Ray0Rotated);
        [Test] public void TestScaled1() => Test("Scaled1", Ray0.Scaled(scale1), Ray0Scaled1);
        [Test] public void TestScaled3() => Test("Scaled3", Ray0.Scaled(scale3), Ray0Scaled3);

        [Test] public void TestTranslate() => Test("Translate", Ray0.Translate(translation1), Ray0Translate);
        [Test] public void TestRotate() => Test("Rotate", Ray0.Rotate(rotation3), Ray0Rotate);
        [Test] public void TestScale1() => Test("Scale1", Ray0.Scale(scale1), Ray0Scale1);

        [Test] public void TestTransform() => Test("Transform", Ray0.Transform(Input0), Output0);
        [Test] public void TestUntransform() => Test("Untransform", Ray0.Untransform(Output0), Input0);
        [Test] public void TestInverseTransform() => Test("Inversed.Transform", Ray0.Inversed.Transform(Output0), Input0);
        [Test] public void TestInverseUntransform() => Test("Inversed.Untransform", Ray0.Inversed.Untransform(Input0), Output0);
        //[Test] public void TestMul() => Test("Mul", Ray0.Mul(translation1), Ray0Translate);
        //[Test] public void TestDiv() => Test("Div", Ray0.Div(translation3), Input0);
    }
}