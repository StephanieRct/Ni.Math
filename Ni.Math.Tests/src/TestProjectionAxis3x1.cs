using Ni.Mathematics;
using NUnit.Framework;
using Unity.Mathematics;

namespace Ni.Mathematics.Tests
{
    public class TestProjectionAxis3x1 : MathTests
    {
        public static readonly float3 ProjectionI_Axis = new float3(0, 0, 1);

        public static readonly float3 Projection0_Axis = new float3(1, 0, 0);
        public static readonly float Input0 = 0.5f;
        public static readonly float3 Output0 = Input0 * Projection0_Axis;
        public static readonly quaternion rotation3 = quaternion.EulerXYZ(1,4,7);
        public static readonly float scale1 = 4;
        public static readonly float3 scale3 = new float3(-2, 6, 4);

        public static readonly ProjectionAxis3x1 Projection0 = new ProjectionAxis3x1(Projection0_Axis);
        public static readonly ProjectionAxis3x1 ProjectionI = new ProjectionAxis3x1(ProjectionI_Axis);

        public static readonly ProjectionAxis3x1 Projection0Rotated = new ProjectionAxis3x1(math.mul(rotation3, Projection0_Axis));
        public static readonly ProjectionAxis3x1 Projection0Scaled1 = new ProjectionAxis3x1(scale1 * Projection0_Axis);
        public static readonly ProjectionAxis3x1 Projection0Scaled3 = new ProjectionAxis3x1(scale3 * Projection0_Axis);
        public static readonly ProjectionAxis3x1 Projection0Scale1 = new ProjectionAxis3x1(Projection0_Axis * scale1);


        [Test] public void TestIdentity() => Test("Identity", ProjectionAxis3x1.Identity, ProjectionI);
        [Test] public void TestInverseTransform() => Test("Inverse.Transform", Projection0.Inverse.Transform(Output0), Input0);
        [Test] public void TestInverseUntransform() => Test("Inverse.Untransform", Projection0.Inverse.Untransform(Input0), Output0);


        [Test] public void TestScaled1() => Test("Scaled1", Projection0.Scaled(scale1), Projection0Scaled1);
        [Test] public void TestScaled3() => Test("Scaled3", Projection0.Scaled(scale3), Projection0Scaled3);
        [Test] public void TestRotated() => Test("Rotated", Projection0.Rotated(rotation3), Projection0Rotated);
        [Test] public void TestScale1() => Test("Scale1", Projection0.Scale(scale1), Projection0Scale1);
        [Test] public void TestTransform() => Test("Transform", Projection0.Transform(Input0), Output0);
        [Test] public void TestUntransform() => Test("Untransform", Projection0.Untransform(Output0), Input0);
    }
}