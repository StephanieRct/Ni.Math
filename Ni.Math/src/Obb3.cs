using System;
using Unity.Mathematics;
using UnityEngine.UIElements;

namespace Ni.Mathematics
{

    // Matrix4x4
    // RigidTransform + extent
    // NonUniformTransform
    // 




    //public struct Obb3MRSC<TRotationScale> :
    //    IInvertible<Obb3M3>,
    //    ITransform<float3>,
    //    IUntransform<float3>
    //{
    //    public TRotationScale RotationScale;
    //    public float3 Center;
    //    public Obb3MRSC(TRotationScale rotationScale, float3 center)
    //    {
    //        RotationScale = rotationScale;
    //        Center = center;
    //    }
    //    //public static readonly Obb3M3 Identity = new Obb3M3(Matrix3x3Transform.Identity, float3.zero);
    //    //public static readonly Obb3M3 Origin = new Obb3M3(Matrix3x3Transform.Identity, new float3(-0.5f));

    //    public Obb3M3 Inversed => throw new NotImplementedException();
    //    public float3 Transform(float3 primitive) => Center + Matrix.Transform(primitive);
    //    public float3 Untransform(float3 primitive) => Matrix.Untransform(primitive - Center);
    //}





    //public struct Obb3Axis2 :
    //    INormalizable<Obb3Axis>,
    //    IInvertible<Obb3Axis>,
    //    ITransform<float3>,
    //    IUntransform<float3>
    //{
    //    public Aabb3M Aabb;
    //    public float3 XAxis;
    //    public float3 YAxis;
    //    public float3 ZAxis;


    //    public Obb3Axis(float3 center, float3 extent, float3 xAxis, float3 yAxis, float3 zAxis)
    //    {
    //        XAxis = xAxis;
    //        YAxis = yAxis;
    //        ZAxis = zAxis;
    //        Extent = extent;
    //        Center = center;
    //    }
    //    public static readonly Obb3Axis Identity = new Obb3Axis(0.5f, 0.5f, new float3(1, 0, 0), new float3(0, 1, 0), new float3(0, 0, 1));
    //    public static readonly Obb3Axis Origin = new Obb3Axis(-0.5f, 1, new float3(1, 0, 0), new float3(0, 1, 0), new float3(0, 0, 1));

    //    public Obb3Axis Normalize()
    //    {
    //        var xLength = math.length(XAxis);
    //        var yLength = math.length(YAxis);
    //        var zLength = math.length(ZAxis);
    //        return new Obb3Axis(Center, Extent * new float3(xLength, yLength, zLength), XAxis * math.rcp(xLength), YAxis * math.rcp(yLength), ZAxis * math.rcp(zLength));
    //    }
    //    public Obb3Axis Inverse() => new Obb3Axis(NonUniformTransform.Inverse());
    //    public float3 Transform(float3 a) => Center + a * Extent * 2;
    //    public float3 Untransform(float3 a) => NonUniformTransform.Untransform(primitive);
    //}
    //public struct Obb3Axis :
    //    INormalizable<Obb3Axis>,
    //    IInvertible<Obb3Axis>,
    //    ITransform<float3>,
    //    IUntransform<float3>
    //{
    //    public float3 Center;
    //    public float3 Extent;
    //    public float3 XAxis;
    //    public float3 YAxis;
    //    public float3 ZAxis;


    //    public Obb3Axis(float3 center, float3 extent, float3 xAxis, float3 yAxis, float3 zAxis)
    //    {
    //        XAxis = xAxis;
    //        YAxis = yAxis;
    //        ZAxis = zAxis;
    //        Extent = extent;
    //        Center = center;
    //    }
    //    public static readonly Obb3Axis Identity = new Obb3Axis(0.5f, 0.5f, new float3(1, 0, 0), new float3(0, 1, 0), new float3(0, 0, 1));
    //    public static readonly Obb3Axis Origin = new Obb3Axis(-0.5f, 1, new float3(1, 0, 0), new float3(0, 1, 0), new float3(0, 0, 1));

    //    public Obb3Axis Normalize()
    //    {
    //        var xLength = math.length(XAxis);
    //        var yLength = math.length(YAxis);
    //        var zLength = math.length(ZAxis);
    //        return new Obb3Axis(Center, Extent * new float3(xLength, yLength, zLength), XAxis * math.rcp(xLength), YAxis * math.rcp(yLength), ZAxis * math.rcp(zLength));
    //    }
    //    public Obb3Axis Inverse() => new Obb3Axis(NonUniformTransform.Inverse());
    //    public float3 Transform(float3 a) => Center + a * Extent * 2;
    //    public float3 Untransform(float3 a) => NonUniformTransform.Untransform(primitive);
    //}



    //public static partial class NiMath
    //{
    //    public static bool Equal(Obb3M a, Obb3M b) => Equal(a.Matrix, b.Matrix);
    //    public static bool Equal(Obb3T a, Obb3T b) => Equal(a.NonUniformTransform, b.NonUniformTransform);
    //    public static bool Equal(Obb3M3 a, Obb3M3 b) => Equal(a.Center, b.Center) && Equal(a.Matrix, b.Matrix);
    //    public static bool Equal<TRotation, TAabb>(Obb3RA<TRotation, TAabb> a, Obb3RA<TRotation, TAabb> b)
    //        where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
    //            IInvertible<TAabb>, IScalable<TAabb, float>,
    //            ITransform<float3>, IUntransform<float3>
    //        where TRotation : IEquatable<TRotation>, INearEquatable<TRotation, float>,
    //            IInvertible<TRotation>,
    //            ITransform<float3>, IUntransform<float3>
    //        => a.Rotation.Equals(b.Rotation) && a.Aabb.Equals(b.Aabb);
    //    public static bool Equal<TAabb, TRotation>(Obb3AR<TAabb, TRotation> a, Obb3AR<TAabb, TRotation> b)
    //        where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
    //            IInvertible<TAabb>, IScalable<TAabb, float>,
    //            ITransform<float3>, IUntransform<float3>
    //        where TRotation : IEquatable<TRotation>, INearEquatable<TRotation, float>,
    //            IInvertible<TRotation>,
    //            ITransform<float3>, IUntransform<float3>
    //        => a.Aabb.Equals(b.Aabb) && a.Rotation.Equals(b.Rotation);
    //    public static bool NearEqual(Obb3M a, Obb3M b, float margin) => NearEqual(a.Matrix, b.Matrix, margin);
    //    public static bool NearEqual(Obb3T a, Obb3T b, float margin) => NearEqual(a.NonUniformTransform, b.NonUniformTransform, margin);
    //    public static bool NearEqual(Obb3M3 a, Obb3M3 b, float margin) => NearEqual(a.Center, b.Center, margin) && NearEqual(a.Matrix, b.Matrix, margin);
    //    public static bool NearEqual<TRotation, TAabb>(Obb3RA<TRotation, TAabb> a, Obb3RA<TRotation, TAabb> b, float margin)
    //        where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
    //            ITranslatable<TAabb, float3>, IScalable<TAabb, float>, IInvertible<TAabb>,
    //            ITransform<float3>, IUntransform<float3>
    //        where TRotation : IEquatable<TRotation>, INearEquatable<TRotation, float>,
    //            IInvertible<TRotation>,
    //            ITransform<float3>, IUntransform<float3>
    //        => a.Rotation.NearEquals(b.Rotation, margin) && a.Aabb.NearEquals(b.Aabb, margin);
    //    public static bool NearEqual<TAabb, TRotation>(Obb3AR<TAabb, TRotation> a, Obb3AR<TAabb, TRotation> b, float margin)
    //        where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
    //            ITranslatable<TAabb, float3>, IScalable<TAabb, float>, IInvertible<TAabb>,
    //            ITransform<float3>, IUntransform<float3>
    //        where TRotation : IEquatable<TRotation>, INearEquatable<TRotation, float>,
    //            IInvertible<TRotation>,
    //            ITransform<float3>, IUntransform<float3>
    //        => a.Aabb.NearEquals(b.Aabb, margin) && a.Rotation.NearEquals(b.Rotation, margin);

    //    public static Obb3M Scale(float scale, Obb3M o) => new Obb3M(Scale(scale, o.Matrix));
    //    public static Obb3T Scale(float scale, Obb3T o) => new Obb3T(Scale(scale, o.NonUniformTransform));
    //    public static Obb3M3 Scale(float scale, Obb3M3 o) => new Obb3M3(scale * o.Center, Scale(scale, o.Matrix));
    //    public static Obb3RA<TRotation, TAabb> Scale<TRotation, TAabb>(float scale, Obb3RA<TRotation, TAabb> o)
    //        where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
    //            ITranslatable<TAabb, float3>, IInvertible<TAabb>, IScalable<TAabb, float>,
    //            ITransform<float3>, IUntransform<float3>
    //        where TRotation : IEquatable<TRotation>, INearEquatable<TRotation, float>,
    //            IInvertible<TRotation>,
    //            ITransform<float3>, IUntransform<float3>
    //        => new Obb3RA<TRotation, TAabb>(o.Rotation, o.Aabb.Scaled(scale));
    //    public static Obb3AR<TAabb, TRotation> Scale<TRotation, TAabb>(float scale, Obb3AR<TAabb, TRotation> o)
    //        where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
    //            ITranslatable<TAabb, float3>, IInvertible<TAabb>, IScalable<TAabb, float>,
    //            ITransform<float3>, IUntransform<float3>
    //        where TRotation : IEquatable<TRotation>, INearEquatable<TRotation, float>,
    //            IInvertible<TRotation>,
    //            ITransform<float3>, IUntransform<float3>
    //        => new Obb3AR<TAabb, TRotation>(o.Aabb.Scaled(scale), o.Rotation);
        
    //    public static Obb3M Scale(float3 scale, Obb3M o) => new Obb3M(Scale(scale, o.Matrix));
    //    public static Obb3M Scale(float3 scale, Obb3T o) => new Obb3M(Scale(scale, o.NonUniformTransform));
    //    public static Obb3M3 Scale(float3 scale, Obb3M3 o) => new Obb3M3(Scale(scale, o.Center), Scale(scale, o.Matrix));
    //    public static Obb3M Translate(float3 translation, Obb3M o) => new Obb3M(Translate(translation, o.Matrix));
    //    public static Obb3T Translate(float3 translation, Obb3T o) => new Obb3T(Translate(translation, o.NonUniformTransform));
    //    public static Obb3M3 Translate(float3 translation, Obb3M3 o) => new Obb3M3(translation + o.Center, o.Matrix);


    //    public static Obb3M Inverse(Obb3M a) => new Obb3M(a.Matrix.Inversed);
    //    public static Obb3M Inverse(Obb3T a) => new Obb3M(a.NonUniformTransform.Inversed);
    //    public static Obb3M3 Inverse(Obb3M3 a)
    //    {
    //        var mI = a.Matrix.Inversed;
    //        return new Obb3M3(mI.Transform(-a.Center), mI);
    //    }
    //    public static Obb3AR<TAabb, TRotation> Inverse<TRotation, TAabb>(Obb3RA<TRotation, TAabb> o)
    //        where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
    //            ITranslatable<TAabb, float3>, IInvertible<TAabb>, IScalable<TAabb, float>,
    //            ITransform<float3>, IUntransform<float3>
    //        where TRotation : IEquatable<TRotation>, INearEquatable<TRotation, float>,
    //            IInvertible<TRotation>,
    //            ITransform<float3>, IUntransform<float3>
    //        => new Obb3AR<TAabb, TRotation>(o.Aabb, o.Rotation);
    //    public static Obb3RA<TRotation, TAabb> Inverse<TAabb, TRotation>(Obb3AR<TAabb, TRotation> o)
    //        where TAabb : IEquatable<TAabb>, INearEquatable<TAabb, float>,
    //            ITranslatable<TAabb, float3>, IInvertible<TAabb>, IScalable<TAabb, float>,
    //            ITransform<float3>, IUntransform<float3>
    //        where TRotation : IEquatable<TRotation>, INearEquatable<TRotation, float>,
    //            IInvertible<TRotation>,
    //            ITransform<float3>, IUntransform<float3>
    //        => new Obb3RA<TRotation, TAabb>(o.Aabb, o.Rotation);

    //}




    //public interface IObb3
    //{
    //    //float3 Center { get; }
    //    //float3 Transform(float3 t);
    //}
    //public interface IObb3<TPrimitive> : IObb3, 
    //    IScalable<TPrimitive, float>,
    //    IRotatable<TPrimitive, quaternion>, 
    //    ITranslatable<TPrimitive, float3>
    //{
    //}


    ///// <summary>
    ///// This box can be:
    /////     Translated
    /////     Rotated
    /////     Scaled
    /////     Skewed
    ///// </summary>
    //public struct Obb3T : IObb3<Obb3T>, IScalable<Obb3T, float3>
    //{
    //    public float4x4 Matrix;
    //    public Obb3T(float4x4 transform)
    //    {
    //        Matrix = transform;
    //    }

    //    public void ScaleBy(float scalar) => this = ScaledBy(scalar);
    //    public Obb3T ScaledBy(float scalar) => new Obb3T(math.mul(float4x4.Scale(scalar), Matrix));
    //    public void ScaleBy(float3 scalar) => this = ScaledBy(scalar);
    //    public Obb3T ScaledBy(float3 scalar) => new Obb3T(math.mul(float4x4.Scale(scalar), Matrix));
    //    public void RotateBy(quaternion rotation) => this = RotatedBy(rotation);
    //    public Obb3T RotatedBy(quaternion rotation) => new Obb3T(math.mul(new float4x4(rotation, float3.zero), Matrix));
    //    public void TranslateBy(float3 offset) => this = TranslatedBy(offset);
    //    public Obb3T TranslatedBy(float3 offset) => new Obb3T(math.mul(float4x4.Translate(offset), Matrix));
    //}

    ///// <summary>
    ///// This box can be:
    /////     Translated
    /////     Rotated
    /////     Scaled
    /////     Skewed
    ///// </summary>
    //public struct Obb3TI : IObb3
    //{
    //    public float4x4 Matrix;
    //    public float4x4 InverseMatrix;
    //    public Obb3TI(float4x4 matrix, float4x4 inverseMatrix)
    //    {
    //        Matrix = matrix;
    //        InverseMatrix = inverseMatrix;
    //    }
    //    public static explicit operator Obb3TI(Obb3T a) => new Obb3TI(a.Matrix, math.inverse(a.Matrix));
    //    public static implicit operator Obb3T(Obb3TI a) => new Obb3T(a.Matrix);

    //    public bool Raycast(Ray3 ray, float maxDistance, out float3 hit)
    //        => NiMath.Raycast(this, ray, maxDistance, out hit);
    //}

    ///// <summary>
    ///// This box can be:
    /////     Translated
    /////     Rotated
    /////     Scaled
    ///// This box cannot be:
    /////     Skewed
    ///// </summary>
    //public struct Obb3R : IObb3<Obb3R>
    //{
    //    public RigidTransform RigidTransform;
    //    public float3 Extent;
    //    public Obb3R(RigidTransform rigidTransform, Aabb3M bound)
    //    {
    //        RigidTransform = rigidTransform;
    //        Bound = bound;
    //    }

    //    public void ScaleBy(float scalar) => this = ScaledBy(scalar);
    //    public Obb3R ScaledBy(float scalar) => new Obb3R(new RigidTransform(RigidTransform.rot, RigidTransform.pos * scalar), Bound.Scaled(scalar));
    //    public void RotateBy(quaternion rotation) => this = RotatedBy(rotation);
    //    public Obb3R RotatedBy(quaternion rotation) => new Obb3R(math.mul(RigidTransform, new RigidTransform(rotation, float3.zero)),);
    //    public void TranslateBy(float3 offset) => this = TranslatedBy(offset);
    //    public Obb3R TranslatedBy(float3 offset) => new Obb3R(new RigidTransform(RigidTransform.rot, RigidTransform.pos + offset), Bound);
    //}

    ///// <summary>
    ///// This box can be:
    /////     Translated
    /////     Rotated
    /////     Scaled
    ///// This box cannot be:
    /////     Skewed
    ///// </summary>
    //public struct Obb3RI : IObb3
    //{
    //    public RigidTransform RigidTransform;
    //    public RigidTransform InverseRigidTransform;
    //    public Aabb3M Bound;
    //    public Obb3RI(RigidTransform transform, Aabb3M bound, RigidTransform inverseRigidTransform)
    //    {
    //        RigidTransform = transform;
    //        Bound = bound;
    //        InverseRigidTransform = inverseRigidTransform;
    //    }
    //    public static explicit operator Obb3RI(Obb3R a) => new Obb3RI(a.RigidTransform, a.Bound, math.inverse(a.RigidTransform));
    //    public static implicit operator Obb3R(Obb3RI a) => new Obb3R(a.RigidTransform, a.Bound);


    //    public bool Raycast(Ray3 ray, float maxDistance, out float3 hit)
    //        => NiMath.Raycast(this, ray, maxDistance, out hit);
    //}



}