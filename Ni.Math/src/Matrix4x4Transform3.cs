using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    /// <summary>
    /// Represent the sequence of transformations: Translation * Rotation * Shear * NonUniformScale
    /// </summary>
    [Serializable]
    public struct Matrix4x4Transform3 : ITranslation3RW, IRotation3QRW, IShear3RW, IScale3RW,
        ITransform3<Matrix4x4Transform3>,
        IShearableTransformable3<Matrix4x4Transform3>,
        ISheared<Matrix4x4Transform3, float3>,
        IShear<Matrix4x4Transform3, float3>,
        ISheared<Matrix4x4Transform3, ShearXY3>,
        IShear<Matrix4x4Transform3, ShearXY3>,
        ITransformable3<Translation3, Matrix4x4Transform3, Matrix4x4Transform3, Matrix4x4Transform3, Matrix4x4Transform3>,
        IInvertible<Matrix4x4Transform3>,
        IMultipliable<Translation3, Matrix4x4Transform3>,
        IMultipliable<Rotation3Q, Matrix4x4Transform3>,
        IMultipliable<Scale1, Matrix4x4Transform3>,
        IMultipliable<Scale3, Matrix4x4Transform3>,
        IMultipliable<RigidTransform3, Matrix4x4Transform3>,
        IMultipliable<UniformTransform3, Matrix4x4Transform3>,
        IMultipliable<NonUniformTransform3, Matrix4x4Transform3>,
        IMultipliable<Matrix3x3Transform3, Matrix4x4Transform3>,
        IMultipliable<Matrix4x4Transform3>,
        IMultipliable<Aabb3M, Obb3M>,
        IMultipliable<Aabb3C, Obb3M>,
        IMultipliable<Aabb3S, Obb3M>,
        IMultipliable<Obb3T, Obb3M>,
        IMultipliable<Obb3M>,
        IDividable<Translation3, Matrix4x4Transform3>,
        IDividable<Rotation3Q, Matrix4x4Transform3>,
        IDividable<Scale1, Matrix4x4Transform3>,
        IDividable<Scale3, Matrix4x4Transform3>,
        IDividable<RigidTransform3, Matrix4x4Transform3>,
        IDividable<UniformTransform3, Matrix4x4Transform3>,
        IDividable<NonUniformTransform3, Matrix4x4Transform3>,
        IDividable<Matrix3x3Transform3, Matrix4x4Transform3>,
        IDividable<Matrix4x4Transform3>,
        IDividable<Aabb3M, Obb3M>,
        IDividable<Aabb3C, Obb3M>,
        IDividable<Aabb3S, Obb3M>,
        IDividable<Obb3T, Obb3M>,
        IDividable<Obb3M>
    {
        public float4x4 matrix;

        public Matrix4x4Transform3(float4x4 matrix) => this.matrix = matrix;
        public Matrix4x4Transform3(float4 column0, float4 column1, float4 column2, float4 column3) => matrix = new float4x4(column0, column1, column2, column3);

        public Matrix4x4Transform3(float3 translation, quaternion rotation, float scale) => matrix = float4x4.TRS(translation, rotation, scale);
        public Matrix4x4Transform3(float3 translation, quaternion rotation, float3 scale) => matrix = float4x4.TRS(translation, rotation, scale);
        public Matrix4x4Transform3(float3 translation, quaternion rotation) => matrix = new float4x4(rotation, translation);
        public Matrix4x4Transform3(float3 translation, float scale) => matrix = float4x4.TRS(translation, quaternion.identity, scale);
        public Matrix4x4Transform3(float3 translation, float3 scale) => matrix = float4x4.TRS(translation, quaternion.identity, scale);
        public Matrix4x4Transform3(float3 translation, float3x3 rotationShearScale) => matrix = new float4x4(rotationShearScale, translation);
        public Matrix4x4Transform3(quaternion rotation) => matrix = new float4x4(rotation, float3.zero);
        public Matrix4x4Transform3(quaternion rotation, float scale) => matrix = float4x4.TRS(0, rotation, scale);
        public Matrix4x4Transform3(quaternion rotation, float3 scale) => matrix = float4x4.TRS(0, rotation, scale);

        public Matrix4x4Transform3(Translation3 translation) => this = Translating(translation.translation);
        public Matrix4x4Transform3(Translation3 translation, Rotation3Q rotation) => this = TranslatingRotating(translation.translation, rotation);
        public Matrix4x4Transform3(Translation3 translation, Rotation3Q rotation, ShearXY3 shear) => this = TranslatingRotatingShearing(translation.translation, rotation, shear.shear);
        public Matrix4x4Transform3(Translation3 translation, Rotation3Q rotation, ShearXY3 shear, Scale1 scale) => this = TranslatingRotatingShearingScaling(translation.translation, rotation, shear.shear, scale.scale);
        public Matrix4x4Transform3(Translation3 translation, Rotation3Q rotation, ShearXY3 shear, Scale3 scale) => this = TranslatingRotatingShearingScaling(translation.translation, rotation, shear.shear, scale.scale);
        public Matrix4x4Transform3(Translation3 translation, Rotation3Q rotation, Scale1 scale) => this = TranslatingRotatingScaling(translation.translation, rotation, scale.scale);
        public Matrix4x4Transform3(Translation3 translation, Rotation3Q rotation, Scale3 scale) => this = TranslatingRotatingScaling(translation.translation, rotation, scale.scale);
        public Matrix4x4Transform3(Translation3 translation, ShearXY3 shear, Scale1 scale) => this = TranslatingShearingScaling(translation.translation, shear.shear, scale.scale);
        public Matrix4x4Transform3(Translation3 translation, ShearXY3 shear, Scale3 scale) => this = TranslatingShearingScaling(translation.translation, shear.shear, scale.scale);
        public Matrix4x4Transform3(Translation3 translation, ShearXY3 shear) => this = TranslatingShearing(translation.translation, shear.shear);
        public Matrix4x4Transform3(Translation3 translation, Scale1 scale) => this = TranslatingScaling(translation.translation, scale.scale);
        public Matrix4x4Transform3(Translation3 translation, Scale3 scale) => this = TranslatingScaling(translation.translation, scale.scale);
        public Matrix4x4Transform3(Translation3 translation, Matrix3x3Transform3 rotationShearScale) => this = TranslatingRotatingShearingScaling(translation.translation, rotationShearScale);
        public Matrix4x4Transform3(Rotation3Q rotation) => matrix = this = Rotating(rotation);
        public Matrix4x4Transform3(Rotation3Q rotation, ShearXY3 shear) => this = RotatingShearing(rotation, shear.shear);
        public Matrix4x4Transform3(Rotation3Q rotation, ShearXY3 shear, Scale1 scale) => this = RotatingShearingScaling(rotation, shear.shear, scale.scale);
        public Matrix4x4Transform3(Rotation3Q rotation, ShearXY3 shear, Scale3 scale) => this = RotatingShearingScaling(rotation, shear.shear, scale.scale);
        public Matrix4x4Transform3(Rotation3Q rotation, Scale1 scale) => this = RotatingScaling(rotation, scale.scale);
        public Matrix4x4Transform3(Rotation3Q rotation, Scale3 scale) => this = RotatingScaling(rotation, scale.scale);
        public Matrix4x4Transform3(ShearXY3 shear) => this = Shearing(shear.shear);
        public Matrix4x4Transform3(ShearXY3 shear, Scale1 scale) => this = ShearingScaling(shear.shear, scale.scale);
        public Matrix4x4Transform3(ShearXY3 shear, Scale3 scale) => this = ShearingScaling(shear.shear, scale.scale);
        public Matrix4x4Transform3(Scale1 scale) => this = Scaling(scale.scale);
        public Matrix4x4Transform3(Scale3 scale) => this = Scaling(scale.scale);
        public Matrix4x4Transform3(RigidTransform3 o) => matrix = o.ToMatrix4x4Transform3;
        public Matrix4x4Transform3(RigidTransform3 o, Scale1 scale) => matrix = float4x4.TRS(o.translation, o.rotation, scale.scale);
        public Matrix4x4Transform3(RigidTransform3 o, Scale3 scale) => matrix = float4x4.TRS(o.translation, o.rotation, scale.scale);
        public Matrix4x4Transform3(UniformTransform3 o) => matrix = o.ToMatrix4x4Transform3;
        public Matrix4x4Transform3(NonUniformTransform3 o) => matrix = o.ToMatrix4x4Transform3;
        public Matrix4x4Transform3(Matrix4x4Transform3 matrix) => this.matrix = matrix;
        public Matrix4x4Transform3(Aabb3M o) => matrix = new Matrix4x4Transform3(o.translation3, quaternion.identity, o.scale3);
        public Matrix4x4Transform3(Aabb3S o) => matrix = new Matrix4x4Transform3(o.translation3, quaternion.identity, o.scale3);
        public Matrix4x4Transform3(Aabb3C o) => matrix = new Matrix4x4Transform3(o.translation3, quaternion.identity, o.scale3);
        public Matrix4x4Transform3(Obb3T o) => matrix = o.NonUniformTransform.ToMatrix4x4Transform3;
        public Matrix4x4Transform3(Obb3M o) => matrix = o.Matrix4x4Transform;

        public static implicit operator float4x4(Matrix4x4Transform3 o) => o.matrix;
        public static implicit operator Matrix4x4Transform3(float4x4 o) => new Matrix4x4Transform3(o);

        public static explicit operator Matrix4x4Transform3(Translation3 o) => new Matrix4x4Transform3(o.translation, quaternion.identity, 1);
        public static explicit operator Matrix4x4Transform3(Rotation3Q o) => new Matrix4x4Transform3(float3.zero, o.rotation, 1);
        public static explicit operator Matrix4x4Transform3(Rotation3Euler o) => new Matrix4x4Transform3(float3.zero, o.rotation3, 1);
        public static explicit operator Matrix4x4Transform3(RigidTransform3 o) => new Matrix4x4Transform3(o.translation, o.rotation, 1);
        public static explicit operator Matrix4x4Transform3(UniformTransform3 o) => new Matrix4x4Transform3(o.translation, o.rotation, o.scale);
        public static explicit operator Matrix4x4Transform3(NonUniformTransform3 o) => new Matrix4x4Transform3(o.translation, o.rotation, o.scale);
        public static explicit operator Matrix4x4Transform3(Matrix3x3Transform3 o) => new float4x4(o, float3.zero);
        public static explicit operator Matrix4x4Transform3(Aabb3M o) => new Matrix4x4Transform3(o.translation3, quaternion.identity, o.scale3);
        public static explicit operator Matrix4x4Transform3(Aabb3S o) => new Matrix4x4Transform3(o.translation3, quaternion.identity, o.scale3);
        public static explicit operator Matrix4x4Transform3(Aabb3C o) => new Matrix4x4Transform3(o.translation3, quaternion.identity, o.scale3);
        public static explicit operator Matrix4x4Transform3(Obb3T o) => o.NonUniformTransform.ToMatrix4x4Transform3;
        public static implicit operator Matrix4x4Transform3(Obb3M o) => o.Matrix4x4Transform;

        public static readonly Matrix4x4Transform3 Identity = new Matrix4x4Transform3(float4x4.identity);
        public static Matrix4x4Transform3 Translating(float3 translation) => new Matrix4x4Transform3(float4x4.Translate(translation));
        public static Matrix4x4Transform3 TranslatingRotating(float3 translation, quaternion rotation) => new Matrix4x4Transform3(translation, Matrix3x3Transform3.Rotating(rotation));
        public static Matrix4x4Transform3 TranslatingRotatingShearing(float3 translation, quaternion rotation, float3 shear) => new Matrix4x4Transform3(translation, Matrix3x3Transform3.RotatingShearing(rotation, shear));
        public static Matrix4x4Transform3 TranslatingRotatingShearingScaling(float3 translation, quaternion rotation, float3 shear, float scale) => new Matrix4x4Transform3(translation, Matrix3x3Transform3.RotatingShearingScaling(rotation, shear, scale));
        public static Matrix4x4Transform3 TranslatingRotatingShearingScaling(float3 translation, quaternion rotation, float3 shear, float3 scale) => new Matrix4x4Transform3(translation, Matrix3x3Transform3.RotatingShearingScaling(rotation, shear, scale));
        public static Matrix4x4Transform3 TranslatingRotatingShearingScaling(float3 translation, float3x3 rotatingShearingScaling) => new Matrix4x4Transform3(translation, rotatingShearingScaling);
        public static Matrix4x4Transform3 TranslatingRotatingScaling(float3 translation, quaternion rotation, float scale) => new Matrix4x4Transform3(translation, Matrix3x3Transform3.RotatingScaling(rotation, scale));
        public static Matrix4x4Transform3 TranslatingRotatingScaling(float3 translation, quaternion rotation, float3 scale) => new Matrix4x4Transform3(translation, Matrix3x3Transform3.RotatingScaling(rotation, scale));
        public static Matrix4x4Transform3 TranslatingShearing(float3 translation, float3 shear) => new Matrix4x4Transform3(translation, Matrix3x3Transform3.Shearing(shear));
        public static Matrix4x4Transform3 TranslatingShearingScaling(float3 translation, float3 shear, float scale) => new Matrix4x4Transform3(translation, Matrix3x3Transform3.ShearingScaling(shear, scale));
        public static Matrix4x4Transform3 TranslatingShearingScaling(float3 translation, float3 shear, float3 scale) => new Matrix4x4Transform3(translation, Matrix3x3Transform3.ShearingScaling(shear, scale));
        public static Matrix4x4Transform3 TranslatingScaling(float3 translation, float scale) => new Matrix4x4Transform3(translation, Matrix3x3Transform3.Scaling(scale));
        public static Matrix4x4Transform3 TranslatingScaling(float3 translation, float3 scale) => new Matrix4x4Transform3(translation, Matrix3x3Transform3.Scaling(scale));
        public static Matrix4x4Transform3 Rotating(quaternion rotation) => new Matrix4x4Transform3(float3.zero, Matrix3x3Transform3.Rotating(rotation));
        public static Matrix4x4Transform3 RotatingShearing(quaternion rotation, float3 shear) => new Matrix4x4Transform3(float3.zero, Matrix3x3Transform3.RotatingShearing(rotation, shear));
        public static Matrix4x4Transform3 RotatingShearingScaling(quaternion rotation, float3 shear, float scale) => new Matrix4x4Transform3(float3.zero, Matrix3x3Transform3.RotatingShearingScaling(rotation, shear, scale));
        public static Matrix4x4Transform3 RotatingShearingScaling(quaternion rotation, float3 shear, float3 scale) => new Matrix4x4Transform3(float3.zero, Matrix3x3Transform3.RotatingShearingScaling(rotation, shear, scale));
        public static Matrix4x4Transform3 RotatingScaling(quaternion rotation, float scale) => new Matrix4x4Transform3(float3.zero, Matrix3x3Transform3.RotatingScaling(rotation, scale));
        public static Matrix4x4Transform3 RotatingScaling(quaternion rotation, float3 scale) => new Matrix4x4Transform3(float3.zero, Matrix3x3Transform3.RotatingScaling(rotation, scale));
        public static Matrix4x4Transform3 Shearing(float3 shear) => new Matrix4x4Transform3(float3.zero, Matrix3x3Transform3.Shearing(shear));
        public static Matrix4x4Transform3 ShearingScaling(float3 shear, float scale) => new Matrix4x4Transform3(float3.zero, Matrix3x3Transform3.ShearingScaling(shear, scale));
        public static Matrix4x4Transform3 ShearingScaling(float3 shear, float3 scale) => new Matrix4x4Transform3(float3.zero, Matrix3x3Transform3.ShearingScaling(shear, scale));
        public static Matrix4x4Transform3 Scaling(float scale) => new Matrix4x4Transform3(float3.zero, Matrix3x3Transform3.Scaling(scale));
        public static Matrix4x4Transform3 Scaling(float3 scale) => new Matrix4x4Transform3(float3.zero, Matrix3x3Transform3.Scaling(scale));

        public static Matrix4x4Transform3 TRS(float3 translation, quaternion rotation, float3 scale) => new Matrix4x4Transform3(float4x4.TRS(translation, rotation, scale));

        public float3 translation3
        {
            get => matrix.c3.xyz;
            set => matrix.c3 = new float4(value, matrix.c3.w);
        }

        public quaternion rotation3
        {
            get => NiMath.GetRotation(this);
            set => this = NiMath.ReRotate(this, value);
        }

        public float3x3 rotation3M => NiMath.GetRotationMatrix(this);

        public quaternion rotation3Orthonormal
        {
            get => NiMath.GetRotationOrthonormal(this);
            set => this = NiMath.ReRotateOrthonormal(this, value);
        }

        public float3 scale3
        {
            get => NiMath.GetScale(this).scale;
            set => this = NiMath.ReScale(this, value);
        }

        public float3 scale3Orthogonal
        {
            get => NiMath.GetScaleOrthogonal(this).scale;
            set => this = NiMath.ReScaleOrthogonal(this, value);
        }

        public float3 shear3
        {
            get => NiMath.GetShear(this).shear;
            set => this = NiMath.ReShear(this, value);
        }

        public float3x3 shear3scale3 => NiMath.GetShearScale(this);

        public float3x3 shear3scale3Inversed => NiMath.GetShearScaleInverse(this);

        public float3x3 rotation3shear3scale3
        {
            get => NiMath.GetRotationShearScale(this);
            set => this = NiMath.ReRotateShearScale(this, value);
        }

        public float4 column0 => matrix.c0;
        public float4 column1 => matrix.c1;
        public float4 column2 => matrix.c2;
        public float4 column3 => matrix.c3;
        public float determinant => math.determinant(matrix);
        public bool isOrthonormal => Rotation3Shear3Scale3.isOrthonormal;
        public bool isOrthogonal => Rotation3Shear3Scale3.isOrthogonal;

        public Translation3 Translation3 { get => new Translation3(translation3); set => translation3 = value.translation; }
        public Rotation3Q Rotation3 { get => new Rotation3Q(rotation3); set => rotation3 = value.rotation; }
        public Matrix3x3Transform3 Rotation3M { get => new Matrix3x3Transform3(rotation3M); }
        public Scale3 Scale3 { get => new Scale3(scale3); set => scale3 = value.scale; }
        public ShearXY3 Shear3 { get => new ShearXY3(shear3); set => scale3 = value.shear; }

        public Aabb3M Translation3Scale3
        {
            get => new Aabb3M(translation3, scale3);

            set
            {
                translation3 = value.translation3;
                scale3 = value.scale3;
            }
        }

        public RigidTransform3 Translation3Rotation3 
        { 
            get => new RigidTransform3(translation3, rotation3); 
            set
            {
                translation3 = value.translation;
                rotation3 = value.rotation;
            }
        }

        public Matrix3x3Transform3 Rotation3Shear3Scale3
        {
            get => new Matrix3x3Transform3(matrix.c0.xyz, matrix.c1.xyz, matrix.c2.xyz);
            set
            {
                matrix.c0.xyz = value.matrix.c0;
                matrix.c1.xyz = value.matrix.c1;
                matrix.c2.xyz = value.matrix.c2;
            }
        }

        public override string ToString() => $"{nameof(Matrix4x4Transform3)}({matrix.c0.x}, {matrix.c1.x}, {matrix.c2.x}, {matrix.c3.x}, {matrix.c0.y}, {matrix.c1.y}, {matrix.c2.y}, {matrix.c3.y}, {matrix.c0.z}, {matrix.c1.z}, {matrix.c2.z}, {matrix.c3.z}, {matrix.c0.w}, {matrix.c1.w}, {matrix.c2.w}, {matrix.c3.w})";
        
        public bool Equals(Matrix4x4Transform3 other) => NiMath.Equal(this, other);
        
        public bool NearEquals(Translation3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Rotation3Q other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Scale1 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Scale3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(RigidTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(UniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(NonUniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Matrix3x3Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Matrix4x4Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);

        public Matrix4x4Transform3 Inversed => NiMath.Inverse(this);
        public Matrix4x4Transform3 Transposed => math.transpose(matrix);
        public Matrix4x4Transform3 ToMatrix4x4Transform3 => this;

        public Matrix4x4Transform3 Translated(float3 translation) => NiMath.Translate(translation, this);
        public Matrix4x4Transform3 Rotated(quaternion rotation) => NiMath.Rotate(rotation, this);
        public Matrix4x4Transform3 Scaled(float scale) => NiMath.Scale(scale, this);
        public Matrix4x4Transform3 Scaled(float3 scale) => NiMath.Scale(scale, this);
        public Matrix4x4Transform3 Sheared(float3 shear) => NiMath.Shear(shear, this);

        public Matrix4x4Transform3 Translate(float3 translation) => NiMath.Translate(this, translation);
        public Matrix4x4Transform3 Rotate(quaternion rotation) => NiMath.Rotate(this, rotation);
        public Matrix4x4Transform3 Scale(float scale) => NiMath.Scale(this, scale);
        public Matrix4x4Transform3 Scale(float3 scale) => NiMath.Scale(this, scale);
        public Matrix4x4Transform3 Shear(float3 shear) => NiMath.Shear(this, shear);

        public Matrix4x4Transform3 Translated(Translation3 translation) => NiMath.Translate(translation, this);
        public Matrix4x4Transform3 Rotated(Rotation3Q rotation) => NiMath.Rotate(rotation, this);
        public Matrix4x4Transform3 Scaled(Scale1 scale) => NiMath.Scale(scale, this);
        public Matrix4x4Transform3 Scaled(Scale3 scale) => NiMath.Scale(scale, this);
        public Matrix4x4Transform3 Sheared(ShearXY3 shear) => NiMath.Shear(shear, this);

        public Matrix4x4Transform3 Translate(Translation3 translation) => NiMath.Translate(this, translation);
        public Matrix4x4Transform3 Rotate(Rotation3Q rotation) => NiMath.Rotate(this, rotation);
        public Matrix4x4Transform3 Scale(Scale1 scale) => NiMath.Scale(this, scale);
        public Matrix4x4Transform3 Scale(Scale3 scale) => NiMath.Scale(this, scale);
        public Matrix4x4Transform3 Shear(ShearXY3 shear) => NiMath.Shear(this, shear);

        public float3 this[float3 o] => Transform(o);
        public Direction3 this[Direction3 o] => Transform(o);
        public ProjectionAxis3x1 this[ProjectionAxis3x1 o] => Transform(o);
        public ProjectionAxis1x3 this[ProjectionAxis1x3 o] => Transform(o);
        public Ray3 this[Ray3 o] => Transform(o);

        public float3 Transform(float3 o) => NiMath.Transform(this, o);
        public Direction3 Transform(Direction3 o) => NiMath.Transform(this, o);
        public ProjectionAxis3x1 Transform(ProjectionAxis3x1 o) => NiMath.Transform(this, o);
        public ProjectionAxis1x3 Transform(ProjectionAxis1x3 o) => NiMath.Transform(this, o);
        public Ray3 Transform(Ray3 o) => NiMath.Transform(this, o);

        public float3 Untransform(float3 o) => NiMath.Untransform(this, o);
        public Direction3 Untransform(Direction3 o) => NiMath.Untransform(this, o);
        public ProjectionAxis3x1 Untransform(ProjectionAxis3x1 o) => NiMath.Untransform(this, o);
        public ProjectionAxis1x3 Untransform(ProjectionAxis1x3 o) => NiMath.Untransform(this, o);
        public Ray3 Untransform(Ray3 o) => NiMath.Untransform(this, o);

        public Matrix4x4Transform3 Mul(Translation3 o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Mul(Rotation3Q o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Mul(Scale1 o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Mul(Scale3 o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Mul(RigidTransform3 o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Mul(UniformTransform3 o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Mul(NonUniformTransform3 o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Mul(Matrix3x3Transform3 o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Mul(Matrix4x4Transform3 o) => NiMath.Mul(this, o);
        public Obb3M Mul(Aabb3M o) => NiMath.Mul(this, o);
        public Obb3M Mul(Aabb3C o) => NiMath.Mul(this, o);
        public Obb3M Mul(Aabb3S o) => NiMath.Mul(this, o);
        public Obb3M Mul(Obb3T o) => NiMath.Mul(this, o);
        public Obb3M Mul(Obb3M o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Div(Translation3 o) => NiMath.Div(this, o);
        public Matrix4x4Transform3 Div(Rotation3Q o) => NiMath.Div(this, o);
        public Matrix4x4Transform3 Div(Scale1 o) => NiMath.Div(this, o);
        public Matrix4x4Transform3 Div(Scale3 o) => NiMath.Div(this, o);
        public Matrix4x4Transform3 Div(RigidTransform3 o) => NiMath.Div(this, o);
        public Matrix4x4Transform3 Div(UniformTransform3 o) => NiMath.Div(this, o);
        public Matrix4x4Transform3 Div(NonUniformTransform3 o) => NiMath.Div(this, o);
        public Matrix4x4Transform3 Div(Matrix3x3Transform3 o) => NiMath.Div(this, o);
        public Matrix4x4Transform3 Div(Matrix4x4Transform3 o) => NiMath.Div(this, o);
        public Obb3M Div(Aabb3M o) => NiMath.Div(this, o);
        public Obb3M Div(Aabb3C o) => NiMath.Div(this, o);
        public Obb3M Div(Aabb3S o) => NiMath.Div(this, o);
        public Obb3M Div(Obb3T o) => NiMath.Div(this, o);
        public Obb3M Div(Obb3M o) => NiMath.Div(this, o);
    }

    public static partial class NiMath
    {
        public static bool Equal(Matrix4x4Transform3 a, Matrix4x4Transform3 b) => Equal(a.matrix, b.matrix);

        public static bool NearEqual(Matrix4x4Transform3 a, Translation3 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform3, margin);
        public static bool NearEqual(Matrix4x4Transform3 a, Rotation3Q b, float margin) => NearEqual(a, b.ToMatrix4x4Transform3, margin);
        public static bool NearEqual(Matrix4x4Transform3 a, Scale1 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform3, margin);
        public static bool NearEqual(Matrix4x4Transform3 a, Scale3 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform3, margin);
        public static bool NearEqual(Matrix4x4Transform3 a, RigidTransform3 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform3, margin);
        public static bool NearEqual(Matrix4x4Transform3 a, UniformTransform3 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform3, margin);
        public static bool NearEqual(Matrix4x4Transform3 a, NonUniformTransform3 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform3, margin);
        public static bool NearEqual(Matrix4x4Transform3 a, Matrix3x3Transform3 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform3, margin);
        public static bool NearEqual(Matrix4x4Transform3 a, Matrix4x4Transform3 b, float margin) => NearEqual(a.matrix, b.matrix, margin);

        public static Matrix4x4Transform3 Inverse(Matrix4x4Transform3 a) => math.inverse(a.matrix);

        public static float3 RotateVector(Matrix4x4Transform3 rotation, float3 vector) => math.rotate(rotation, vector);

        public static Translation3 GetTranslation(Matrix4x4Transform3 o) { DecomposeTranslation(o, out Translation3 translation); return translation; }
        public static Rotation3Q GetRotation(Matrix4x4Transform3 o) { DecomposeRotation(o, out Rotation3Q rotation); return rotation; }
        public static Matrix3x3Transform3 GetRotationShearScale(Matrix4x4Transform3 o) { DecomposeRotationShearScale(o, out Matrix3x3Transform3 rotationShearScale); return rotationShearScale; }
        public static Rotation3Q GetRotationOrthonormal(Matrix4x4Transform3 o) { DecomposeRotationOrthonormal(o, out Rotation3Q rotation); return rotation; }
        public static Matrix3x3Transform3 GetRotationMatrix(Matrix4x4Transform3 o) { DecomposeRotationMatrix(o, out Matrix3x3Transform3 rotation); return rotation; }
        public static Matrix3x3Transform3 GetRotationMatrixOrthonormal(Matrix4x4Transform3 o) => GetRotationOrthonormal(o).ToMatrix3x3Transform3;
        public static ShearXY3 GetShear(Matrix4x4Transform3 o) { DecomposeShear(o, out ShearXY3 shear); return shear; }
        public static Scale3 GetScale(Matrix4x4Transform3 o) { DecomposeScale(o, out Scale3 scale); return scale; }
        public static Scale3 GetScaleOrthogonal(Matrix4x4Transform3 o) { DecomposeScaleOrthogonal(o, out Scale3 scale); return scale; }
        public static Matrix3x3Transform3 GetShearScale(Matrix4x4Transform3 o) { DecomposeShearScale(o, out Matrix3x3Transform3 shearScale); return shearScale; }
        public static Matrix3x3Transform3 GetShearScaleInverse(Matrix4x4Transform3 o) { DecomposeShearScaleInverse(o, out Matrix3x3Transform3 shearScaleInverse); return shearScaleInverse; }

        public static Matrix4x4Transform3 ReTranslate(Matrix4x4Transform3 o, float3 translation) => new float4x4(o.column0, o.column1, o.column2, new float4(translation, o.column3.w));
        public static Matrix4x4Transform3 ReRotate(Matrix4x4Transform3 o, quaternion rotation) => new Matrix4x4Transform3(o.translation3, ReRotate(o.rotation3shear3scale3, rotation));
        public static Matrix4x4Transform3 ReRotateOrthonormal(Matrix4x4Transform3 o, quaternion rotation) => new Matrix4x4Transform3(o.translation3, ReRotateOrthonormal(o.rotation3shear3scale3, rotation));
        public static Matrix4x4Transform3 ReShear(Matrix4x4Transform3 o, float3 shear) => new Matrix4x4Transform3(o.translation3, ReShear(o.rotation3shear3scale3, shear));
        public static Matrix4x4Transform3 ReScale(Matrix4x4Transform3 o, float scale) => new Matrix4x4Transform3(o.translation3, ReScale(o.rotation3shear3scale3, scale));
        public static Matrix4x4Transform3 ReScale(Matrix4x4Transform3 o, float3 scale) => new Matrix4x4Transform3(o.translation3, ReScale(o.rotation3shear3scale3, scale));
        public static Matrix4x4Transform3 ReScaleOrthogonal(Matrix4x4Transform3 o, float scale) => new Matrix4x4Transform3(o.translation3, ReScaleOrthogonal(o.rotation3shear3scale3, scale));
        public static Matrix4x4Transform3 ReScaleOrthogonal(Matrix4x4Transform3 o, float3 scale) => new Matrix4x4Transform3(o.translation3, ReScaleOrthogonal(o.rotation3shear3scale3, scale));

        public static Matrix4x4Transform3 ReTranslate(Matrix4x4Transform3 o, Translation3 translation) => ReTranslate(o, translation.translation);
        public static Matrix4x4Transform3 ReRotate(Matrix4x4Transform3 o, Rotation3Q rotation) => ReRotate(o, rotation.rotation);
        public static Matrix4x4Transform3 ReRotateOrthonormal(Matrix4x4Transform3 o, Rotation3Q rotation) => ReRotateOrthonormal(o, rotation.rotation);
        public static Matrix4x4Transform3 ReShear(Matrix4x4Transform3 o, ShearXY3 shear) => ReShear(o, shear.shear);
        public static Matrix4x4Transform3 ReScale(Matrix4x4Transform3 o, Scale1 scale) => ReScale(o, scale.scale);
        public static Matrix4x4Transform3 ReScale(Matrix4x4Transform3 o, Scale3 scale) => ReScale(o, scale.scale);
        public static Matrix4x4Transform3 ReScaleOrthogonal(Matrix4x4Transform3 o, Scale1 scale) => ReScaleOrthogonal(o, scale.scale);
        public static Matrix4x4Transform3 ReScaleOrthogonal(Matrix4x4Transform3 o, Scale3 scale) => ReScaleOrthogonal(o, scale.scale);

        public static Matrix4x4Transform3 ReRotateShearScale(Matrix4x4Transform3 o, float3x3 shearScale) => new Matrix4x4Transform3(o.translation3, ReShearScale(o.rotation3shear3scale3, shearScale));

        public static Matrix4x4Transform3 Translate(float3 translation, Matrix4x4Transform3 o) => new Matrix4x4Transform3(math.mul(float4x4.Translate(translation), o.matrix));
        public static Matrix4x4Transform3 Rotate(quaternion rotation, Matrix4x4Transform3 b) => new Matrix4x4Transform3(math.mul(new float4x4(rotation, float3.zero), b.matrix));
        public static Matrix4x4Transform3 Shear(float3 shear, Matrix4x4Transform3 o) => Mul(Matrix4x4Transform3.Shearing(shear), o);
        public static Matrix4x4Transform3 Scale(float scale, Matrix4x4Transform3 b) => new Matrix4x4Transform3(math.mul(float4x4.Scale(scale), b.matrix));
        public static Matrix4x4Transform3 Scale(float3 scale, Matrix4x4Transform3 b) => new Matrix4x4Transform3(math.mul(float4x4.Scale(scale), b.matrix));

        public static Matrix4x4Transform3 Translate(Matrix4x4Transform3 o, float3 translation) => new float4x4(o.column0, o.column1, o.column2, new float4(math.transform(o, translation), o.column3.w));
        public static Matrix4x4Transform3 Rotate(Matrix4x4Transform3 o, quaternion rotation) => math.mul(o, new float4x4(rotation, float3.zero));
        public static Matrix4x4Transform3 Shear(Matrix4x4Transform3 o, float3 shear) => Mul(o, Matrix4x4Transform3.Shearing(shear));
        public static Matrix4x4Transform3 Scale(Matrix4x4Transform3 o, float scale)
        {
            var scale4 = new float4(scale, scale, scale, 1);
            return new Matrix4x4Transform3(scale4 * o.column0, scale4 * o.column1, scale4 * o.column2, o.column3);
        }
        public static Matrix4x4Transform3 Scale(Matrix4x4Transform3 o, float3 scale) => new Matrix4x4Transform3(new float4(scale.x, scale.x, scale.x, 1) * o.column0, new float4(scale.y, scale.y, scale.y, 1) * o.column1, new float4(scale.z, scale.z, scale.z, 1) * o.column2, o.column3);

        public static Matrix4x4Transform3 Translate(Translation3 translation, Matrix4x4Transform3 o) => new Matrix4x4Transform3(math.mul(float4x4.Translate(translation.translation), o.matrix));
        public static Matrix4x4Transform3 Rotate(Rotation3Q rotation, Matrix4x4Transform3 b) => new Matrix4x4Transform3(math.mul(new float4x4(rotation, float3.zero), b.matrix));
        public static Matrix4x4Transform3 Shear(ShearXY3 shear, Matrix4x4Transform3 o) => Mul(Matrix4x4Transform3.Shearing(shear.shear), o);
        public static Matrix4x4Transform3 Scale(Scale1 scale, Matrix4x4Transform3 b) => new Matrix4x4Transform3(math.mul(float4x4.Scale(scale.scale), b.matrix));
        public static Matrix4x4Transform3 Scale(Scale3 scale, Matrix4x4Transform3 b) => new Matrix4x4Transform3(math.mul(float4x4.Scale(scale.scale), b.matrix));

        public static Matrix4x4Transform3 Translate(Matrix4x4Transform3 o, Translation3 translation) => Translate(o, translation.translation);
        public static Matrix4x4Transform3 Rotate(Matrix4x4Transform3 o, Rotation3Q rotation) => Rotate(o, rotation.rotation);
        public static Matrix4x4Transform3 Shear(Matrix4x4Transform3 o, ShearXY3 shear) => Mul(o, Matrix4x4Transform3.Shearing(shear.shear));
        public static Matrix4x4Transform3 Scale(Matrix4x4Transform3 o, Scale1 scale) => Scale(o, scale.scale);
        public static Matrix4x4Transform3 Scale(Matrix4x4Transform3 o, Scale3 scale) => Scale(o, scale.scale);

        public static float3 Transform(Matrix4x4Transform3 a, float3 b) => math.transform(a, b);
        public static Direction3 Transform(Matrix4x4Transform3 a, Direction3 b) => Direction3.Direction(Transform(a.Rotation3Shear3Scale3, b.vector));
        public static ProjectionAxis3x1 Transform(Matrix4x4Transform3 a, ProjectionAxis3x1 b) => new ProjectionAxis3x1(Transform(a.Rotation3Shear3Scale3, b.axis));
        public static ProjectionAxis1x3 Transform(Matrix4x4Transform3 a, ProjectionAxis1x3 b) => new ProjectionAxis1x3(Transform(a.Rotation3Shear3Scale3, b.axis));
        public static Ray3 Transform(Matrix4x4Transform3 a, Ray3 b) => new Ray3(Transform(a, b.translation), RotateVector(a, b.projectionAxis));

        public static float3 Untransform(Matrix4x4Transform3 a, float3 b) => math.transform(math.inverse(a), b);
        public static Direction3 Untransform(Matrix4x4Transform3 a, Direction3 b) => Transform(Inverse(a), b);
        public static ProjectionAxis3x1 Untransform(Matrix4x4Transform3 a, ProjectionAxis3x1 b) => Transform(Inverse(a), b);
        public static ProjectionAxis1x3 Untransform(Matrix4x4Transform3 a, ProjectionAxis1x3 b) => Transform(Inverse(a), b);
        public static Ray3 Untransform(Matrix4x4Transform3 a, Ray3 b) => Transform(Inverse(a), b);

        public static Matrix4x4Transform3 Mul(Matrix4x4Transform3 a, Translation3 b) => Translate(a, b);
        public static Matrix4x4Transform3 Mul(Matrix4x4Transform3 a, Rotation3Q b) => Rotate(a, b);
        public static Matrix4x4Transform3 Mul(Matrix4x4Transform3 a, Scale1 b) => Scale(a, b);
        public static Matrix4x4Transform3 Mul(Matrix4x4Transform3 a, Scale3 b) => Scale(a, b);
        public static Matrix4x4Transform3 Mul(Matrix4x4Transform3 a, RigidTransform3 b) => math.mul(a, b.ToMatrix4x4Transform3);
        public static Matrix4x4Transform3 Mul(Matrix4x4Transform3 a, UniformTransform3 b) => math.mul(a, b.ToMatrix4x4Transform3);
        public static Matrix4x4Transform3 Mul(Matrix4x4Transform3 a, NonUniformTransform3 b) => math.mul(a, b.ToMatrix4x4Transform3);
        public static Matrix4x4Transform3 Mul(Matrix4x4Transform3 a, Matrix3x3Transform3 b) => math.mul(a, b.ToMatrix4x4Transform3);
        public static Matrix4x4Transform3 Mul(Matrix4x4Transform3 a, Matrix4x4Transform3 b) => math.mul(a, b);
        public static Obb3M Mul(Matrix4x4Transform3 a, Aabb3M b) => math.mul(a, b.ToMatrix4x4Transform3);
        public static Obb3M Mul(Matrix4x4Transform3 a, Aabb3C b) => math.mul(a, b.ToMatrix4x4Transform3);
        public static Obb3M Mul(Matrix4x4Transform3 a, Aabb3S b) => math.mul(a, b.ToMatrix4x4Transform3);
        public static Obb3M Mul(Matrix4x4Transform3 a, Obb3T b) => math.mul(a, b.ToMatrix4x4Transform3);
        public static Obb3M Mul(Matrix4x4Transform3 a, Obb3M b) => math.mul(a, b.ToMatrix4x4Transform3);
        public static Matrix4x4Transform3 Div(Matrix4x4Transform3 a, Translation3 b) => Mul(Inverse(a), b);
        public static Matrix4x4Transform3 Div(Matrix4x4Transform3 a, Rotation3Q b) => Mul(Inverse(a), b);
        public static Matrix4x4Transform3 Div(Matrix4x4Transform3 a, Scale1 b) => Mul(Inverse(a), b);
        public static Matrix4x4Transform3 Div(Matrix4x4Transform3 a, Scale3 b) => Mul(Inverse(a), b);
        public static Matrix4x4Transform3 Div(Matrix4x4Transform3 a, RigidTransform3 b) => Mul(Inverse(a), b);
        public static Matrix4x4Transform3 Div(Matrix4x4Transform3 a, UniformTransform3 b) => Mul(Inverse(a), b);
        public static Matrix4x4Transform3 Div(Matrix4x4Transform3 a, NonUniformTransform3 b) => Mul(Inverse(a), b);
        public static Matrix4x4Transform3 Div(Matrix4x4Transform3 a, Matrix3x3Transform3 b) => Mul(Inverse(a), b);
        public static Matrix4x4Transform3 Div(Matrix4x4Transform3 a, Matrix4x4Transform3 b) => Mul(Inverse(a), b);
        public static Obb3M Div(Matrix4x4Transform3 a, Aabb3M b) => Mul(Inverse(a), b);
        public static Obb3M Div(Matrix4x4Transform3 a, Aabb3C b) => Mul(Inverse(a), b);
        public static Obb3M Div(Matrix4x4Transform3 a, Aabb3S b) => Mul(Inverse(a), b);
        public static Obb3M Div(Matrix4x4Transform3 a, Obb3T b) => Mul(Inverse(a), b);
        public static Obb3M Div(Matrix4x4Transform3 a, Obb3M b) => Mul(Inverse(a), b);

        public static void DecomposeTranslation(Matrix4x4Transform3 o, out Translation3 translation) => translation = new(o.column3.xyz);
        public static void DecomposeTranslationRotation(Matrix4x4Transform3 o, out Translation3 translation, out Rotation3Q rotation) { translation = new(o.column3.xyz); DecomposeRotation(o.Rotation3Shear3Scale3, out rotation); }
        public static void DecomposeTranslationRotationOrthonormal(Matrix4x4Transform3 o, out Translation3 translation, out Rotation3Q rotation) { translation = new(o.column3.xyz); DecomposeRotationOrthonormal(o.Rotation3Shear3Scale3, out rotation); }
        public static void DecomposeTranslationRotationMatrix(Matrix4x4Transform3 o, out Translation3 translation, out Matrix3x3Transform3 rotation, out Matrix3x3Transform3 shearScaleInverse) { translation = new(o.column3.xyz); DecomposeRotationMatrix(o.Rotation3Shear3Scale3, out rotation, out shearScaleInverse); }
        public static void DecomposeTranslationRotationMatrix(Matrix4x4Transform3 o, out Translation3 translation, out Matrix3x3Transform3 rotation) {  translation = new(o.column3.xyz); DecomposeRotationMatrix(o.Rotation3Shear3Scale3, out rotation); }
        public static void DecomposeTranslationShear(Matrix4x4Transform3 o, out Translation3 translation, out ShearXY3 shear) {  translation = new(o.column3.xyz); DecomposeShear(o.Rotation3Shear3Scale3, out shear); }
        public static void DecomposeTranslationScale(Matrix4x4Transform3 o, out Translation3 translation, out Scale3 scale) {  translation = new(o.column3.xyz); DecomposeScale(o.Rotation3Shear3Scale3, out scale); }
        public static void DecomposeTranslationScaleOrthogonal(Matrix4x4Transform3 o, out Translation3 translation, out Scale3 scale) {  translation = new(o.column3.xyz); DecomposeScaleOrthogonal(o.Rotation3Shear3Scale3, out scale); }
        public static void DecomposeTranslationShearScale(Matrix4x4Transform3 o, out Translation3 translation, out Matrix3x3Transform3 shearScale, out Matrix3x3Transform3 shearScaleInverse) {  translation = new(o.column3.xyz); DecomposeShearScale(o.Rotation3Shear3Scale3, out shearScale, out shearScaleInverse); }
        public static void DecomposeTranslationShearScale(Matrix4x4Transform3 o, out Translation3 translation, out Matrix3x3Transform3 shearScale) {  translation = new(o.column3.xyz); DecomposeShearScale(o.Rotation3Shear3Scale3, out shearScale); }
        public static void DecomposeTranslationShearScaleInverse(Matrix4x4Transform3 o, out Translation3 translation, out Matrix3x3Transform3 shearScaleInverse) {  translation = new(o.column3.xyz); DecomposeShearScaleInverse(o.Rotation3Shear3Scale3, out shearScaleInverse); }

        public static void DecomposeRotation(Matrix4x4Transform3 o, out Rotation3Q rotation) => DecomposeRotation(o.Rotation3Shear3Scale3, out rotation);
        public static void DecomposeRotationOrthonormal(Matrix4x4Transform3 o, out Rotation3Q rotation) => DecomposeRotationOrthonormal(o.Rotation3Shear3Scale3, out rotation);
        public static void DecomposeRotationMatrix(Matrix4x4Transform3 o, out Matrix3x3Transform3 rotation, out Matrix3x3Transform3 shearScaleInverse) => DecomposeRotationMatrix(o.Rotation3Shear3Scale3, out rotation, out shearScaleInverse);
        public static void DecomposeRotationMatrix(Matrix4x4Transform3 o, out Matrix3x3Transform3 rotation) => DecomposeRotationMatrix(o.Rotation3Shear3Scale3, out rotation);
        public static void DecomposeRotationShearScale(Matrix4x4Transform3 o, out Matrix3x3Transform3 rotationShearScale) => rotationShearScale = new Matrix3x3Transform3(o.matrix.c0.xyz, o.matrix.c1.xyz, o.matrix.c2.xyz);
        public static void DecomposeShear(Matrix4x4Transform3 o, out ShearXY3 shear) => DecomposeShear(o.Rotation3Shear3Scale3, out shear);
        public static void DecomposeShearScale(Matrix4x4Transform3 o, out Matrix3x3Transform3 shearScale, out Matrix3x3Transform3 shearScaleInverse) => DecomposeShearScale(o.Rotation3Shear3Scale3, out shearScale, out shearScaleInverse);
        public static void DecomposeShearScale(Matrix4x4Transform3 o, out Matrix3x3Transform3 shearScale) => DecomposeShearScale(o.Rotation3Shear3Scale3, out shearScale);
        public static void DecomposeShearScaleInverse(Matrix4x4Transform3 o, out Matrix3x3Transform3 shearScaleInverse) => DecomposeShearScaleInverse(o.Rotation3Shear3Scale3, out shearScaleInverse);
        public static void DecomposeScale(Matrix4x4Transform3 o, out Scale3 scale) => DecomposeScale(o.Rotation3Shear3Scale3, out scale);
        public static void DecomposeScaleOrthogonal(Matrix4x4Transform3 o, out Scale3 scale) => DecomposeScaleOrthogonal(o.Rotation3Shear3Scale3, out scale);

        public static void Decompose(Matrix4x4Transform3 o, out Translation3 translation, out Matrix3x3Transform3 rotation, out Matrix3x3Transform3 shearScale, out Matrix3x3Transform3 shearScaleInverse) { translation = new(o.column3.xyz); Decompose(o.Rotation3Shear3Scale3, out rotation, out shearScale, out shearScaleInverse); }
        public static void Decompose(Matrix4x4Transform3 o, out Translation3 translation, out Matrix3x3Transform3 rotation, out Matrix3x3Transform3 shearScale) { translation = new(o.column3.xyz); Decompose(o.Rotation3Shear3Scale3, out rotation, out shearScale); }
        public static void Decompose(Matrix4x4Transform3 o, out Translation3 translation, out Matrix3x3Transform3 rotation, out ShearXY3 shear, out Scale3 scale) { translation = new(o.column3.xyz); Decompose(o.Rotation3Shear3Scale3, out rotation, out shear, out scale); }
        public static void Decompose(Matrix4x4Transform3 o, out Translation3 translation, out Rotation3Q rotation, out ShearXY3 shear, out Scale3 scale) { translation = new(o.column3.xyz); Decompose(o.Rotation3Shear3Scale3, out rotation, out shear, out scale); }

        public static void Decompose(Matrix4x4Transform3 o, out Matrix3x3Transform3 rotation, out Matrix3x3Transform3 shearScale, out Matrix3x3Transform3 shearScaleInverse) => Decompose(o.Rotation3Shear3Scale3, out rotation, out shearScale, out shearScaleInverse);
        public static void Decompose(Matrix4x4Transform3 o, out Matrix3x3Transform3 rotation, out Matrix3x3Transform3 shearScale) => Decompose(o.Rotation3Shear3Scale3, out rotation, out shearScale);
        public static void Decompose(Matrix4x4Transform3 o, out Matrix3x3Transform3 rotation, out ShearXY3 shear, out Scale3 scale) => Decompose(o.Rotation3Shear3Scale3, out rotation, out shear, out scale);
        public static void Decompose(Matrix4x4Transform3 o, out Rotation3Q rotation, out ShearXY3 shear, out Scale3 scale) => Decompose(o.Rotation3Shear3Scale3, out rotation, out shear, out scale);
    }
}