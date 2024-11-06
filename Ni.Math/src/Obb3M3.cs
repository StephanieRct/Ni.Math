#if NIMATHEXPERIMENTAL
using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    [Serializable]
    public struct Obb3M3 :
        IEquatable<Obb3M3>,
        INearEquatable<Obb3M3, float>,
        IScaled<Obb3M3, float>,
        IScaled<Obb3M3, float3>,
        ITranslated<Obb3M3, float3>,
        IInvertible<Obb3M3>,
        ITransform<float3>
    {
        public Matrix3x3Transform3 Matrix;
        public float3 Center;
        public Obb3M3(float3 center, Matrix3x3Transform3 matrix)
        {
            Matrix = matrix;
            Center = center;
        }
        public static readonly Obb3M3 Identity = new Obb3M3(float3.zero, Matrix3x3Transform3.Identity);
        public static readonly Obb3M3 Origin = new Obb3M3(new float3(-0.5f), Matrix3x3Transform3.Identity);

        public bool Equals(Obb3M3 other) => NiMath.Equal(this, other);
        public bool NearEquals(Obb3M3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public Obb3M3 Scaled(float scale) => NiMath.Scale(scale, this);
        public Obb3M3 Scaled(float3 scale) => NiMath.Scale(scale, this);
        public Obb3M3 Translated(float3 translation) => NiMath.Translate(translation, this);
        public Obb3M3 Inversed => NiMath.Inverse(this);
        public float3 Transform(float3 primitive) => Center + Matrix.Transform(primitive);
        public float3 Untransform(float3 primitive) => Matrix.Untransform(primitive - Center);
    }

    public static partial class NiMath
    {
        public static bool Equal(Obb3M3 a, Obb3M3 b) => Equal(a.Center, b.Center) && Equal(a.Matrix, b.Matrix);
        public static bool NearEqual(Obb3M3 a, Obb3M3 b, float margin) => NearEqual(a.Center, b.Center, margin) && NearEqual(a.Matrix, b.Matrix, margin);
        public static Obb3M3 Scale(float scale, Obb3M3 o) => new Obb3M3(scale * o.Center, Scale(scale, o.Matrix));
        public static Obb3M3 Scale(float3 scale, Obb3M3 o) => new Obb3M3(scale * o.Center, Scale(scale, o.Matrix));
        public static Obb3M3 Translate(float3 translation, Obb3M3 o) => new Obb3M3(translation + o.Center, o.Matrix);
        public static Obb3M3 Inverse(Obb3M3 a)
        {
            var mI = a.Matrix.Inversed;
            return new Obb3M3(mI.Transform(-a.Center), mI);
        }
    }
}
#endif