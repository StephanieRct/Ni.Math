#if NIMATHEXPERIMENTAL
using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    [Serializable]
    public struct Obb3AR<TAabb> :
        IEquatable<Obb3AR<TAabb>>,
        INearEquatable<Obb3AR<TAabb>, float>,
        IScaled<Obb3AR<TAabb>, float>,
        //IScaled<oob with shear, float3>,
        ITranslated<Obb3AR<TAabb>, float3>,
        IInvertible<Obb3RA<TAabb>>,
        ITransform<float3>
        where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
            ITranslated<TAabb, float3>, IScaled<TAabb, float>, IInvertible<TAabb>,
            ITransform<float3>
    {
        public Rotation3Q Rotation;
        public TAabb Aabb;


        public Obb3AR(TAabb aabb, Rotation3Q rotation)
        {
            Rotation = rotation;
            Aabb = aabb;
        }
        //public static readonly Obb3Axis Identity = new Obb3Axis(0.5f, 0.5f, new float3(1, 0, 0), new float3(0, 1, 0), new float3(0, 0, 1));
        //public static readonly Obb3Axis Origin = new Obb3Axis(-0.5f, 1, new float3(1, 0, 0), new float3(0, 1, 0), new float3(0, 0, 1));
        public override string ToString() => $"{nameof(Obb3AR<TAabb>)}(R:{Rotation}, A:{Aabb})";
        public bool Equals(Obb3AR<TAabb> other) => NiMath.Equal(this, other);
        public bool NearEquals(Obb3AR<TAabb> other, float margin) => NiMath.NearEqual(this, other, margin);
        public Obb3AR<TAabb> Scaled(float scale) => NiMath.Scale(scale, this);
        public Obb3AR<TAabb> Translated(float3 translation) => NiMath.Translate(translation, this);
        public Obb3RA<TAabb> Inversed => NiMath.Inverse(this);
        public float3 Transform(float3 a) => Aabb.Transform(Rotation.Transform(a));
        public float3 Untransform(float3 a) => Rotation.Untransform(Aabb.Untransform(a));
    }

    public static partial class NiMath
    {
        public static bool Equal<TAabb>(Obb3AR<TAabb> a, Obb3AR<TAabb> b)
            where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
                ITranslated<TAabb, float3>, IInvertible<TAabb>, IScaled<TAabb, float>,
                ITransform<float3>
            => a.Aabb.Equals(b.Aabb) && a.Rotation.Equals(b.Rotation);
        public static bool NearEqual<TAabb>(Obb3AR<TAabb> a, Obb3AR<TAabb> b, float margin)
            where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
                ITranslated<TAabb, float3>, IScaled<TAabb, float>, IInvertible<TAabb>,
                ITransform<float3>
            => a.Aabb.NearEquals(b.Aabb, margin) && a.Rotation.NearEquals(b.Rotation, margin);
        public static Obb3RA<TAabb> Inverse<TAabb>(Obb3AR<TAabb> o)
            where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
                ITranslated<TAabb, float3>, IInvertible<TAabb>, IScaled<TAabb, float>,
                ITransform<float3>
            => new Obb3RA<TAabb>(o.Rotation.Inversed, o.Aabb.Inversed);
        public static Obb3AR<TAabb> Translate<TAabb>(float3 translation, Obb3AR<TAabb> o)
            where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
                ITranslated<TAabb, float3>, IInvertible<TAabb>, IScaled<TAabb, float>,
                ITransform<float3>
            => new Obb3AR<TAabb>(o.Aabb.Translated(translation), o.Rotation);
        public static Obb3AR<TAabb> Scale<TAabb>(float scale, Obb3AR<TAabb> o)
            where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
                ITranslated<TAabb, float3>, IInvertible<TAabb>, IScaled<TAabb, float>,
                ITransform<float3>
            => new Obb3AR<TAabb>(o.Aabb.Scaled(scale), o.Rotation);

    }


    [Serializable]
    public struct Obb3AR<TAabb, TRotation> :
        IEquatable<Obb3AR<TAabb, TRotation>>,
        INearEquatable<Obb3AR<TAabb, TRotation>, float>,
        IScaled<Obb3AR<TAabb, TRotation>, float>,
        //IScalable<oob with shear, float3>,
        ITranslated<Obb3AR<TAabb, TRotation>, float3>,
        IInvertible<Obb3RA<TRotation, TAabb>>,
        ITransform<float3>
        where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
            ITranslated<TAabb, float3>, IScaled<TAabb, float>, IInvertible<TAabb>,
            ITransform<float3>
        where TRotation : IEquatable<TRotation>, INearEquatable<TRotation, float>,
            IInvertible<TRotation>,
            ITransform<float3>
    {
        public TRotation Rotation;
        public TAabb Aabb;


        public Obb3AR(TAabb aabb, TRotation rotation)
        {
            Rotation = rotation;
            Aabb = aabb;
        }
        //public static readonly Obb3Axis Identity = new Obb3Axis(0.5f, 0.5f, new float3(1, 0, 0), new float3(0, 1, 0), new float3(0, 0, 1));
        //public static readonly Obb3Axis Origin = new Obb3Axis(-0.5f, 1, new float3(1, 0, 0), new float3(0, 1, 0), new float3(0, 0, 1));
        public override string ToString() => $"{nameof(Obb3AR<TAabb, TRotation>)}(R:{Rotation}, A:{Aabb})";
        public bool Equals(Obb3AR<TAabb, TRotation> other) => NiMath.Equal(this, other);
        public bool NearEquals(Obb3AR<TAabb, TRotation> other, float margin) => NiMath.NearEqual(this, other, margin);
        public Obb3AR<TAabb, TRotation> Scaled(float scale) => NiMath.Scale(scale, this);
        public Obb3AR<TAabb, TRotation> Translated(float3 translation) => NiMath.Translate(translation, this);
        public Obb3RA<TRotation, TAabb> Inversed => NiMath.Inverse(this);
        public float3 Transform(float3 a) => Aabb.Transform(Rotation.Transform(a));
        public float3 Untransform(float3 a) => Rotation.Untransform(Aabb.Untransform(a));
    }

    public static partial class NiMath
    {
        public static bool Equal<TAabb, TRotation>(Obb3AR<TAabb, TRotation> a, Obb3AR<TAabb, TRotation> b)
            where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
                ITranslated<TAabb, float3>, IInvertible<TAabb>, IScaled<TAabb, float>,
                ITransform<float3>
            where TRotation : IEquatable<TRotation>, INearEquatable<TRotation, float>,
                IInvertible<TRotation>,
                ITransform<float3>
            => a.Aabb.Equals(b.Aabb) && a.Rotation.Equals(b.Rotation);
        public static bool NearEqual<TAabb, TRotation>(Obb3AR<TAabb, TRotation> a, Obb3AR<TAabb, TRotation> b, float margin)
            where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
                ITranslated<TAabb, float3>, IScaled<TAabb, float>, IInvertible<TAabb>,
                ITransform<float3>
            where TRotation : IEquatable<TRotation>, INearEquatable<TRotation, float>,
                IInvertible<TRotation>,
                ITransform<float3>
            => a.Aabb.NearEquals(b.Aabb, margin) && a.Rotation.NearEquals(b.Rotation, margin);
        public static Obb3AR<TAabb, TRotation> Scale<TRotation, TAabb>(float scale, Obb3AR<TAabb, TRotation> o)
            where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
                ITranslated<TAabb, float3>, IInvertible<TAabb>, IScaled<TAabb, float>,
                ITransform<float3>
            where TRotation : IEquatable<TRotation>, INearEquatable<TRotation, float>,
                IInvertible<TRotation>,
                ITransform<float3>
            => new Obb3AR<TAabb, TRotation>(o.Aabb.Scaled(scale), o.Rotation);
        public static Obb3AR<TAabb, TRotation> Translate<TRotation, TAabb>(float3 translation, Obb3AR<TAabb, TRotation> o)
            where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
                ITranslated<TAabb, float3>, IInvertible<TAabb>, IScaled<TAabb, float>,
                ITransform<float3>
            where TRotation : IEquatable<TRotation>, INearEquatable<TRotation, float>,
                IInvertible<TRotation>,
                ITransform<float3>
            => new Obb3AR<TAabb, TRotation>(o.Aabb.Translated(translation), o.Rotation);
        public static Obb3RA<TRotation, TAabb> Inverse<TAabb, TRotation>(Obb3AR<TAabb, TRotation> o)
            where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
                ITranslated<TAabb, float3>, IInvertible<TAabb>, IScaled<TAabb, float>,
                ITransform<float3>
            where TRotation : IEquatable<TRotation>, INearEquatable<TRotation, float>,
                IInvertible<TRotation>,
                ITransform<float3>
            => new Obb3RA<TRotation, TAabb>(o.Rotation.Inversed, o.Aabb.Inversed);

    }
}
#endif