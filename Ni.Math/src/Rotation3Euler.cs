using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    /// <summary>
    /// Represent a rotation transform for 3d vectors
    /// </summary>
    [Serializable]
    public struct Rotation3Euler : IRotation3ERW, IRotation3QRW, IToMatrix4x4Transform
    {
        public float3 rotation;

        public Rotation3Euler(float3 eulerRotation)
        {
            this.rotation = eulerRotation;
        }

        public static explicit operator float3(Rotation3Euler o) => o.rotation;
        public static implicit operator Rotation3Euler(float3 o) => new Rotation3Euler(o);

        public static explicit operator Rotation3Euler(Rotation3Q o) => NiMath.QuaternionToEulerXYZ(o.rotation);
        public static explicit operator Rotation3Euler(RigidTransform3 o) => NiMath.QuaternionToEulerXYZ(o.rotation);
        public static explicit operator Rotation3Euler(UniformTransform3 o) => NiMath.QuaternionToEulerXYZ(o.rotation);
        public static explicit operator Rotation3Euler(NonUniformTransform3 o) => NiMath.QuaternionToEulerXYZ(o.rotation);

        public static readonly Rotation3Euler Identity = new Rotation3Euler(float3.zero);
        public static Rotation3Euler Rotating(quaternion rotation) => new Rotation3Euler(NiMath.QuaternionToEulerXYZ(rotation));

        public quaternion rotation3
        {
            get => quaternion.EulerXYZ(rotation);
            set => rotation = NiMath.QuaternionToEulerXYZ(value);
        }
        public Rotation3Q Rotation3 { get => rotation3; set => rotation3 = value.rotation; }
        Rotation3Euler IRotation3ERW.EulerRotation3 { get => rotation; set => rotation = value.rotation; }
        Rotation3Euler IRotation3E.EulerRotation3 => rotation;
        Rotation3Euler IRotation3EW.EulerRotation3 { set => rotation = value.rotation; }
        float3 IRotation3ERW.eulerRotation3 { get => rotation; set => rotation = value; }
        float3 IRotation3E.eulerRotation3 => rotation;
        float3 IRotation3EW.eulerRotation3 { set => rotation = value; }

        public override string ToString() => $"{nameof(Rotation3Euler)}({rotation.x}, {rotation.y}, {rotation.z})";

        public Matrix4x4Transform3 ToMatrix4x4Transform3 => new float4x4(quaternion.EulerXYZ(rotation), float3.zero);

        public float3 Transform(float3 o) => math.mul(quaternion.EulerXYZ(o), o);
    }

    public static partial class NiMath
    {
        public static bool Equal(Rotation3Euler a, Rotation3Euler b) => Equal(a.rotation3, b.rotation3);
        public static bool NearEqual(Rotation3Euler a, Rotation3Euler b, float margin) => NearEqual(a.rotation3, b.rotation3, margin);

        public static Rotation3Euler RotationEulerXYZ(float3 eulerRotation) => new Rotation3Euler(eulerRotation);
    }
}