using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{

    ///// <summary>
    ///// Represent the combination of transformation: Translation * Rotation * NonUniformScale
    ///// </summary>
    ///// <typeparam name="TAabb"></typeparam>
    //public struct Obb3A<TAabb> : ITransform3, ITranslation3RW, IRotation3QRW, INonUniformScale3RW
    //    IEquatable<Obb3A<TAabb>>,
    //    INearEquatable<Obb3A<TAabb>, float>,
    //    IScaled<Obb3A<TAabb>, float>,
    //    //IScalable<oob with shear, float3>,
    //    ITranslated<Obb3A<TAabb>, float3>,
    //    IInvertible<Obb3A<TAabb>>,
    //    ITransform<float3>
    //    where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
    //        ITranslated<TAabb, float3>, IScaled<TAabb, float>, IInvertible<TAabb>,
    //        ITransform<float3>
    //{
    //    public RotationQTransform3 Rotation;
    //    public TAabb Aabb;


    //    public Obb3A(RotationQTransform3 rotation, TAabb aabb)
    //    {
    //        Rotation = rotation;
    //        Aabb = aabb;
    //    }
    //    //public static readonly Obb3Axis Identity = new Obb3Axis(0.5f, 0.5f, new float3(1, 0, 0), new float3(0, 1, 0), new float3(0, 0, 1));
    //    //public static readonly Obb3Axis Origin = new Obb3Axis(-0.5f, 1, new float3(1, 0, 0), new float3(0, 1, 0), new float3(0, 0, 1));

    //    public override string ToString() => $"{nameof(Obb3RA<TAabb>)}(A:{Aabb}, R:{Rotation})";
    //    public bool Equals(Obb3RA<TAabb> other) => NiMath.Equal(this, other);
    //    public bool NearEquals(Obb3RA<TAabb> other, float margin) => NiMath.NearEqual(this, other, margin);
    //    public bool NearEquals(TranslationTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
    //    public bool NearEquals(RotationQTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
    //    public bool NearEquals(ScaleUniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
    //    public bool NearEquals(ScaleNonUniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
    //    public bool NearEquals(RigidTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
    //    public bool NearEquals(UniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
    //    public bool NearEquals(NonUniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
    //    public bool NearEquals(Matrix3x3Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);
    //    public bool NearEquals(Matrix4x4Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);
    //    //public Matrix4x4Transform3 ToMatrix4x4Transform => new Matrix4x4Transform3(Aabb.Tr;
    //    public Obb3RA<TAabb> Scaled(float scale) => NiMath.Scale(scale, this);
    //    public Obb3RA<TAabb> Translated(float3 translation) => NiMath.Translate(translation, this);
    //    public Obb3AR<TAabb> Inversed => NiMath.Inverse(this);
    //    public float3 Transform(float3 a) => Rotation.Transform(Aabb.Transform(a));
    //    public float3 Untransform(float3 a) => Aabb.Untransform(Rotation.Untransform(a));
    //}




    [Serializable]
    public struct Obb3RA<TAabb> : //ITransform3, ITranslation3RW, IRotation3QRW, INonUniformScale3RW
        IEquatable<Obb3RA<TAabb>>,
        INearEquatable<Obb3RA<TAabb>, float>,
        IScaled<Obb3RA<TAabb>, float>,
        //IScalable<oob with shear, float3>,
        ITranslated<Obb3RA<TAabb>, float3>,
        IInvertible<Obb3AR<TAabb>>,
        ITransform<float3>
        where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
            ITranslated<TAabb, float3>, IScaled<TAabb, float>, IInvertible<TAabb>,
            ITransform<float3>
    {
        public Rotation3Q Rotation;
        public TAabb Aabb;


        public Obb3RA(Rotation3Q rotation, TAabb aabb)
        {
            Rotation = rotation;
            Aabb = aabb;
        }
        //public static readonly Obb3Axis Identity = new Obb3Axis(0.5f, 0.5f, new float3(1, 0, 0), new float3(0, 1, 0), new float3(0, 0, 1));
        //public static readonly Obb3Axis Origin = new Obb3Axis(-0.5f, 1, new float3(1, 0, 0), new float3(0, 1, 0), new float3(0, 0, 1));

        public override string ToString() => $"{nameof(Obb3RA<TAabb>)}(A:{Aabb}, R:{Rotation})";
        public bool Equals(Obb3RA<TAabb> other) => NiMath.Equal(this, other);
        public bool NearEquals(Obb3RA<TAabb> other, float margin) => NiMath.NearEqual(this, other, margin);
        //public bool NearEquals(TranslationTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        //public bool NearEquals(RotationQTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        //public bool NearEquals(ScaleUniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        //public bool NearEquals(ScaleNonUniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        //public bool NearEquals(RigidTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        //public bool NearEquals(UniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        //public bool NearEquals(NonUniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        //public bool NearEquals(Matrix3x3Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        //public bool NearEquals(Matrix4x4Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        //public Matrix4x4Transform3 ToMatrix4x4Transform => new Matrix4x4Transform3(Aabb.Tr;
        public Obb3RA<TAabb> Scaled(float scale) => NiMath.Scale(scale, this);
        public Obb3RA<TAabb> Translated(float3 translation) => NiMath.Translate(translation, this);
        public Obb3AR<TAabb> Inversed => NiMath.Inverse(this);
        public float3 Transform(float3 a) => Rotation.Transform(Aabb.Transform(a));
        public float3 Untransform(float3 a) => Aabb.Untransform(Rotation.Untransform(a));
    }

    public static partial class NiMath
    {
        public static bool Equal<TAabb>(Obb3RA<TAabb> a, Obb3RA<TAabb> b)
            where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
                ITranslated<TAabb, float3>, IInvertible<TAabb>, IScaled<TAabb, float>,
                ITransform<float3>
            => a.Rotation.Equals(b.Rotation) && a.Aabb.Equals(b.Aabb);
        public static bool NearEqual<TAabb>(Obb3RA<TAabb> a, Obb3RA<TAabb> b, float margin)
            where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
                ITranslated<TAabb, float3>, IScaled<TAabb, float>, IInvertible<TAabb>,
                ITransform<float3>
            => a.Rotation.NearEquals(b.Rotation, margin) && a.Aabb.NearEquals(b.Aabb, margin);
        public static Obb3RA<TAabb> Scale<TAabb>(float scale, Obb3RA<TAabb> o)
            where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
                ITranslated<TAabb, float3>, IInvertible<TAabb>, IScaled<TAabb, float>,
                ITransform<float3>
            => new Obb3RA<TAabb>(o.Rotation, o.Aabb.Scaled(scale));
        public static Obb3RA<TAabb> Translate<TAabb>(float3 translation, Obb3RA<TAabb> o)
            where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
                ITranslated<TAabb, float3>, IInvertible<TAabb>, IScaled<TAabb, float>,
                ITransform<float3>
            => new Obb3RA<TAabb>(o.Rotation, o.Aabb.Translated(translation));
        public static Obb3AR<TAabb> Inverse<TAabb>(Obb3RA<TAabb> o)
            where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
                ITranslated<TAabb, float3>, IInvertible<TAabb>, IScaled<TAabb, float>,
                ITransform<float3>
            => new Obb3AR<TAabb>(o.Aabb.Inversed, o.Rotation.Inversed);

    }

    [Serializable]
    public struct Obb3RA<TRotation, TAabb> :
        IEquatable<Obb3RA<TRotation, TAabb>>,
        INearEquatable<Obb3RA<TRotation, TAabb>, float>,
        IScaled<Obb3RA<TRotation, TAabb>, float>,
        //IScalable<oob with shear, float3>,
        ITranslated<Obb3RA<TRotation, TAabb>, float3>,
        IInvertible<Obb3AR<TAabb, TRotation>>,
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


        public Obb3RA(TRotation rotation, TAabb aabb)
        {
            Rotation = rotation;
            Aabb = aabb;
        }
        //public static readonly Obb3Axis Identity = new Obb3Axis(0.5f, 0.5f, new float3(1, 0, 0), new float3(0, 1, 0), new float3(0, 0, 1));
        //public static readonly Obb3Axis Origin = new Obb3Axis(-0.5f, 1, new float3(1, 0, 0), new float3(0, 1, 0), new float3(0, 0, 1));

        public override string ToString() => $"{nameof(Obb3RA<TRotation, TAabb>)}(A:{Aabb}, R:{Rotation})";
        public bool Equals(Obb3RA<TRotation, TAabb> other) => NiMath.Equal(this, other);
        public bool NearEquals(Obb3RA<TRotation, TAabb> other, float margin) => NiMath.NearEqual(this, other, margin);
        public Obb3RA<TRotation, TAabb> Scaled(float scale) => NiMath.Scale(scale, this);
        public Obb3RA<TRotation, TAabb> Translated(float3 translation) => NiMath.Translate(translation, this);
        public Obb3AR<TAabb, TRotation> Inversed => NiMath.Inverse(this);
        public float3 Transform(float3 a) => Rotation.Transform(Aabb.Transform(a));
        public float3 Untransform(float3 a) => Aabb.Untransform(Rotation.Untransform(a));
    }

    public static partial class NiMath
    {
        public static bool Equal<TRotation, TAabb>(Obb3RA<TRotation, TAabb> a, Obb3RA<TRotation, TAabb> b)
            where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
                ITranslated<TAabb, float3>, IInvertible<TAabb>, IScaled<TAabb, float>,
                ITransform<float3>
            where TRotation : IEquatable<TRotation>, INearEquatable<TRotation, float>,
                IInvertible<TRotation>,
                ITransform<float3>
            => a.Rotation.Equals(b.Rotation) && a.Aabb.Equals(b.Aabb);
        public static bool NearEqual<TRotation, TAabb>(Obb3RA<TRotation, TAabb> a, Obb3RA<TRotation, TAabb> b, float margin)
            where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
                ITranslated<TAabb, float3>, IScaled<TAabb, float>, IInvertible<TAabb>,
                ITransform<float3>
            where TRotation : IEquatable<TRotation>, INearEquatable<TRotation, float>,
                IInvertible<TRotation>,
                ITransform<float3>
            => a.Rotation.NearEquals(b.Rotation, margin) && a.Aabb.NearEquals(b.Aabb, margin);
        public static Obb3RA<TRotation, TAabb> Scale<TRotation, TAabb>(float scale, Obb3RA<TRotation, TAabb> o)
            where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
                ITranslated<TAabb, float3>, IInvertible<TAabb>, IScaled<TAabb, float>,
                ITransform<float3>
            where TRotation : IEquatable<TRotation>, INearEquatable<TRotation, float>,
                IInvertible<TRotation>,
                ITransform<float3>
            => new Obb3RA<TRotation, TAabb>(o.Rotation, o.Aabb.Scaled(scale));
        public static Obb3RA<TRotation, TAabb> Translate<TRotation, TAabb>(float3 translation, Obb3RA<TRotation, TAabb> o)
            where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
                ITranslated<TAabb, float3>, IInvertible<TAabb>, IScaled<TAabb, float>,
                ITransform<float3>
            where TRotation : IEquatable<TRotation>, INearEquatable<TRotation, float>,
                IInvertible<TRotation>,
                ITransform<float3>
            => new Obb3RA<TRotation, TAabb>(o.Rotation, o.Aabb.Translated(translation));
        public static Obb3AR<TAabb, TRotation> Inverse<TRotation, TAabb>(Obb3RA<TRotation, TAabb> o)
            where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
                ITranslated<TAabb, float3>, IInvertible<TAabb>, IScaled<TAabb, float>,
                ITransform<float3>
            where TRotation : IEquatable<TRotation>, INearEquatable<TRotation, float>,
                IInvertible<TRotation>,
                ITransform<float3>
            => new Obb3AR<TAabb, TRotation>(o.Aabb.Inversed, o.Rotation.Inversed);

    }
}