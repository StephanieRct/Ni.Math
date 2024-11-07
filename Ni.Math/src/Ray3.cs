using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    /// <summary>
    /// Represent the sequence of transformations: Translation3 * ProjectionAxis3x1
    /// Input: float
    /// Output: float3
    /// </summary>
    [Serializable]
    public struct Ray3 : ITranslation3RW,
        IEquatable<Ray3>,
        INearEquatable<Ray3>,
        IInvertible<RayI3>,
        ITranslated<Ray3, float3>,
        IRotated<Ray3, quaternion>,
        IScaled<Ray3, float>,
        IScaled<Ray3, float3>,
        ITranslate<Ray3, float>,
        IRotate<Ray3, quaternion>,  // insert rotation: Translation3 * rotation * ProjectionAxis3x1
        IScale<Ray3, float>,
        ITransform<float, float3>,
        IMultipliable<TranslationTransform1, Ray3>,
        IDividable<Translation3, RayI3>  
    {
        /// <summary>
        /// Translation portion of this transform
        /// </summary>
        public float3 translation;

        /// <summary>
        /// Direction with scale.
        /// </summary>
        public float3 projectionAxis;

        public Ray3(float3 origin, float3 direction)
        {
            translation = origin;
            projectionAxis = direction;
        }
        
        public Ray3(Translation3 translation, ProjectionAxis3x1 projection)
        {
            this.translation = translation.translation;
            projectionAxis = projection.axis;
        }

        public Ray3(UnityEngine.Ray ray)
        {
            translation = ray.origin;
            projectionAxis = ray.direction;
        }

        public static implicit operator Ray3(UnityEngine.Ray ray) => new Ray3(ray);
        public static implicit operator UnityEngine.Ray(Ray3 ray) => new UnityEngine.Ray(ray.origin, ray.direction);
        public static Ray3 Identity => new Ray3(Translation3.Identity, ProjectionAxis3x1.Identity);

        /// <summary>
        /// Projection portion of this transform.
        /// Local to the Ray Translation
        /// </summary>
        public ProjectionAxis3x1 Projection3x1 { get => new ProjectionAxis3x1(projectionAxis); set => projectionAxis = value.axis; }
        /// <summary>
        /// Translation portion of this transform
        /// </summary>
        public Translation3 Translation3 { get => new Translation3(translation); set => translation = value.translation; }

        public float3 origin => Translation3.translation;
        public float3 direction => Projection3x1.axis;
        public float3 this[float o] => Translation3.translation + Projection3x1.axis * o;

        float3 ITranslation3RW.translation3 { get => translation; set => translation = value; }
        float3 ITranslation3.translation3 => translation;
        float3 ITranslation3W.translation3 { set => translation = value; }
        public bool Equals(Ray3 o) => NiMath.Equal(this, o);
        public bool NearEquals(Ray3 o, float margin) => NiMath.NearEqual(this, o, margin);

        public RayI3 Inversed => NiMath.Inverse(this); 
        public float3 Transform(float o) => NiMath.Transform(this, o);
        public float Untransform(float3 o) => NiMath.Untransform(this, o);


        public Ray3 Translated(float3 translation) => NiMath.Translate(translation, this);
        public Ray3 Rotated(quaternion rotation) => NiMath.Rotate(rotation, this);
        public Ray3 Scaled(float scale) => NiMath.Scale(scale, this);
        public Ray3 Scaled(float3 scale) => NiMath.Scale(scale, this);

        /// <summary>
        /// Move the ray along it's direction
        /// </summary>
        public Ray3 Translate(float translation) => NiMath.Translate(this, translation);
        /// <summary>
        /// add rotation like this: Translation3 * rotation * ProjectionAxis3x1
        /// </summary>
        public Ray3 Rotate(quaternion rotation) => NiMath.Rotate(this, rotation);
        public Ray3 Scale(float scale) => NiMath.Scale(this, scale);


        public Ray3 Mul(TranslationTransform1 translation) => NiMath.Mul(this, translation);
        public RayI3 Div(Translation3 translation) => NiMath.Div(this, translation);


        public bool Cast1(Aabb3M o, float maxDistance, out float t) => NiMath.Raycast1(this, o, maxDistance, out t);
        public bool Cast1(Aabb3S o, float maxDistance, out float t) => NiMath.Raycast1(this, o, maxDistance, out t);
        public bool Cast1(Aabb3C o, float maxDistance, out float t) => NiMath.Raycast1(this, o, maxDistance, out t);
        public bool Cast1<T>(T o, float maxDistance, out float t) where T : ITransform<Ray3> => NiMath.Raycast1(this, o, maxDistance, out t);
    }

    public static partial class NiMath
    {
        public static bool Equal(Ray3 a, Ray3 b) => Equal(a.translation, b.translation) && Equal(a.projectionAxis, b.projectionAxis);

        public static bool NearEqual(Ray3 a, Ray3 b, float margin) => NearEqual(a.translation, b.translation, margin) && NearEqual(a.projectionAxis, b.projectionAxis, margin);

        public static RayI3 Inverse(Ray3 o) => new RayI3(o.projectionAxis, -o.translation);


        public static Ray3 Translate(float3 translation, Ray3 o) => new Ray3(translation + o.origin, o.direction);
        public static Ray3 Rotate(quaternion rotation, Ray3 o) => new Ray3(math.rotate(rotation, o.origin), math.rotate(rotation, o.direction));
        public static Ray3 Scale(float scale, Ray3 o) => new Ray3(scale * o.origin, scale * o.direction);
        public static Ray3 Scale(float3 scale, Ray3 o) => new Ray3(scale * o.origin, scale * o.direction);

        public static Ray3 Translate(Ray3 o, float translation) => new Ray3(o.origin + o.direction * translation, o.direction);
        public static Ray3 Rotate(Ray3 o, quaternion rotation) => new Ray3(o.origin, math.rotate(rotation, o.projectionAxis));
        public static Ray3 Scale(Ray3 o, float scale) => new Ray3(o.origin, o.direction * scale);

        public static Ray3 Translate(Translation3 translation, Ray3 o) => new Ray3(translation.translation + o.origin, o.direction);
        public static Ray3 Rotate(Rotation3Q rotation, Ray3 o) => new Ray3(math.rotate(rotation, o.origin), math.rotate(rotation, o.direction));
        public static Ray3 Scale(Scale1 scale, Ray3 o) => new Ray3(scale.scale * o.origin, scale.scale * o.direction);
        public static Ray3 Scale(Scale3 scale, Ray3 o) => new Ray3(scale.scale * o.origin, scale.scale * o.direction);

        public static Ray3 Translate(Ray3 o, Translation3 translation) => new Ray3(o.origin + o.direction * translation.translation, o.direction);
        public static Ray3 Rotate(Ray3 o, Rotation3Q rotation) => new Ray3(o.origin, math.rotate(rotation, o.projectionAxis));
        public static Ray3 Scale(Ray3 o, Scale1 scale) => new Ray3(o.origin, o.direction * scale.scale);

        public static float3 Transform(Ray3 a, float b) => a.translation + a.projectionAxis * b;
        public static float Untransform(Ray3 a, float3 b) => math.dot(b - a.translation, a.projectionAxis) / math.dot(a.projectionAxis, a.projectionAxis);

        public static Ray3 Mul(Ray3 o, TranslationTransform1 translation) => Translate(o, translation.translation);
        public static void Mul(Ray3 o, Scale1 scale) => Scale(o, scale.scale);

        public static RayI3 Div(Ray3 o, Translation3 translation) => Inverse(o).Translate(translation.translation);
        public static RayI3 Div(Ray3 o, Scale1 scale) => Scale(Inverse(o), scale.scale);

    }

    /// <summary>
    /// Represent the sequence of transformations: ProjectionVector1x3 * Translation3
    /// </summary>
    public struct RayI3 : ITranslation3RW,
        IEquatable<RayI3>,
        INearEquatable<RayI3>,
        IInvertible<Ray3>,
        IScaled<RayI3, float>,
        IRotated<RayI3, quaternion>,
        ITranslated<RayI3, float>,
        ITranslate<RayI3, float3>,
        IScale<RayI3, float>,
        IScale<RayI3, float3>,
        ITransform<float3, float>
    {
        public float3 translation3 { get; set; }

        public float3 projectionAxis1x3 { get; set; }


        public RayI3(float3 direction, float3 origin)
        {
            translation3 = origin;
            projectionAxis1x3 = direction;
        }

        public RayI3(ProjectionAxis1x3 projection, Translation3 translation)
        {
            translation3 = translation.translation;
            projectionAxis1x3 = projection.axis;
        }

        public RayI3(UnityEngine.Ray ray)
        {
            translation3 = ray.origin;
            projectionAxis1x3 = ray.direction;
        }

        public static RayI3 Identity => new RayI3(ProjectionAxis1x3.Identity, Translation3.Identity);

        public ProjectionAxis1x3 Projection1x3 { get => new ProjectionAxis1x3(projectionAxis1x3); set => projectionAxis1x3 = value.axis; }

        public Translation3 Translation3 { get => new Translation3(translation3); set => translation3 = value.translation; }

        public float3 Origin => Translation3.translation;
        public float3 Direction => Projection1x3.axis;

        public float3 this[float o] => Translation3[Projection1x3[o]];
        public bool Equals(RayI3 o) => NiMath.Equal(this, o);
        public bool NearEquals(RayI3 o, float margin) => NiMath.NearEqual(this, o, margin);
        public Ray3 Inversed => new Ray3(-translation3, projectionAxis1x3);
        public float Transform(float3 o) => Projection1x3.Transform(Translation3.Transform(o));
        public float3 Untransform(float o) => Translation3.Untransform(Projection1x3.Untransform(o));

        public RayI3 Translated(float translation) => NiMath.Translate(translation, this);
        public RayI3 Rotated(quaternion rotation) => NiMath.Rotate(rotation, this);
        public RayI3 Scaled(float scale) => NiMath.Scale(scale, this);
        public RayI3 Translate(float3 translation) => NiMath.Translate(this, translation);
        public RayI3 Scale(float scale) => NiMath.Scale(this, scale);
        public RayI3 Scale(float3 scale) => NiMath.Scale(this, scale);

        public RayI3 Mul(float3 o) => NiMath.Mul(this, o);
        public Ray3 Div(float o) => NiMath.Div(this, o);
    }

    public static partial class NiMath
    {
        public static bool Equal(RayI3 a, RayI3 b) => Equal(a.translation3, b.translation3) && Equal(a.projectionAxis1x3, b.projectionAxis1x3);

        public static bool NearEqual(RayI3 a, RayI3 b, float margin) => NearEqual(a.translation3, b.translation3, margin) && NearEqual(a.projectionAxis1x3, b.projectionAxis1x3, margin);

        public static RayI3 Translate(float translation, RayI3 o) => new RayI3(o.projectionAxis1x3, o.translation3 + translation * o.projectionAxis1x3);
        public static RayI3 Rotate(quaternion rotation, RayI3 o) => new RayI3(math.rotate(rotation, o.translation3), math.rotate(rotation, o.projectionAxis1x3));
        public static RayI3 Scale(float scale, RayI3 o) => new RayI3(o.projectionAxis1x3, o.translation3 + scale * o.projectionAxis1x3);

        public static RayI3 Translate(RayI3 o, float3 translation) => new RayI3(o.projectionAxis1x3, o.translation3 + translation);
        public static RayI3 Scale(RayI3 o, float scale) => new RayI3(o.projectionAxis1x3 * scale, o.translation3);
        public static RayI3 Scale(RayI3 o, float3 scale) => new RayI3(o.translation3, o.projectionAxis1x3 * scale);

        public static float Transform(RayI3 a, float3 b) => a.Projection1x3.Transform(a.Translation3.Transform(b));
        public static float3 Untransform(RayI3 a, float b) => a.Translation3.Untransform(a.Projection1x3.Untransform(b));

        public static RayI3 Mul(RayI3 o, float3 translation) => Translate(o, translation);
        public static Ray3 Div(RayI3 o, float translation) => o.Inversed.Translate(translation);
    }
}