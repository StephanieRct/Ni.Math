using System;
using Unity.Mathematics;

namespace Ni.Mathematics
{
    /// <summary>
    /// Represent the sequence of transformations: Rotation * Shear * NonUniformScale
    /// </summary>
    [Serializable]
    public struct Matrix3x3Transform3 : IRotation3QRW, IShear3RW, IScale3RW,
        ITransform3<Matrix3x3Transform3>,
        IShearableTransformable3<Matrix3x3Transform3>,
        ISheared<Matrix3x3Transform3, float3>,
        IShear<Matrix3x3Transform3, float3>,
        ISheared<Matrix3x3Transform3, ShearXY3>,
        IShear<Matrix3x3Transform3, ShearXY3>,
        ITransformable3<Matrix3x3Transform3, Matrix4x4Transform3, Matrix3x3Transform3, Matrix3x3Transform3, Matrix3x3Transform3>,
        IToMatrix3x3Transform,
        IInvertible<Matrix3x3Transform3>,
        IMultipliable<Translation3, Matrix4x4Transform3>,
        IMultipliable<Rotation3Q, Matrix3x3Transform3>,
        IMultipliable<Scale1, Matrix3x3Transform3>,
        IMultipliable<Scale3, Matrix3x3Transform3>,
        IMultipliable<RigidTransform3, Matrix4x4Transform3>,
        IMultipliable<UniformTransform3, Matrix4x4Transform3>,
        IMultipliable<NonUniformTransform3, Matrix4x4Transform3>,
        IMultipliable<Matrix3x3Transform3>,
        IMultipliable<Matrix4x4Transform3>,
        IMultipliable<Aabb3M, Obb3M>,
        IMultipliable<Aabb3C, Obb3M>,
        IMultipliable<Aabb3S, Obb3M>,
        IMultipliable<Obb3T, Obb3M>,
        IMultipliable<Obb3M>,
        IDividable<Translation3, Matrix4x4Transform3>,
        IDividable<Rotation3Q, Matrix3x3Transform3>,
        IDividable<Scale1, Matrix3x3Transform3>,
        IDividable<Scale3, Matrix3x3Transform3>,
        IDividable<RigidTransform3, Matrix4x4Transform3>,
        IDividable<UniformTransform3, Matrix4x4Transform3>,
        IDividable<NonUniformTransform3, Matrix4x4Transform3>,
        IDividable<Matrix3x3Transform3>,
        IDividable<Matrix4x4Transform3>,
        IDividable<Aabb3M, Obb3M>,
        IDividable<Aabb3C, Obb3M>,
        IDividable<Aabb3S, Obb3M>,
        IDividable<Obb3T, Obb3M>,
        IDividable<Obb3M>
    {
        public float3x3 matrix;

        public Matrix3x3Transform3(float3x3 matrix) => this.matrix = matrix;
        public Matrix3x3Transform3(float3 c0, float3 c1, float3 c2) => matrix = new float3x3(c0, c1, c2);

        public Matrix3x3Transform3(quaternion rotation) => this = Rotating(rotation);
        public Matrix3x3Transform3(quaternion rotation, float3 shear, float3 scale) => this = RotatingShearingScaling(rotation, shear, scale);
        public Matrix3x3Transform3(quaternion rotation, float scale) => this = RotatingScaling(rotation, scale);
        public Matrix3x3Transform3(quaternion rotation, float3 scale) => this = RotatingScaling(rotation, scale);
        public Matrix3x3Transform3(float scale) => this = Scaling(scale);
        public Matrix3x3Transform3(float3 scale) => this = Scaling(scale);

        public Matrix3x3Transform3(Rotation3Q rotation) => this = Rotating(rotation);
        public Matrix3x3Transform3(Rotation3Q rotation, ShearXY3 shear) => this = RotatingShearing(rotation, shear.shear);
        public Matrix3x3Transform3(Rotation3Q rotation, ShearXY3 shear, Scale1 scale) => this = RotatingShearingScaling(rotation, shear.shear, scale.scale);
        public Matrix3x3Transform3(Rotation3Q rotation, ShearXY3 shear, Scale3 scale) => this = RotatingShearingScaling(rotation, shear.shear, scale.scale);
        public Matrix3x3Transform3(Rotation3Q rotation, Scale1 scale) => this = RotatingScaling(rotation, scale.scale);
        public Matrix3x3Transform3(Rotation3Q rotation, Scale3 scale) => this = RotatingScaling(rotation, scale.scale);
        public Matrix3x3Transform3(ShearXY3 shear) => this = Shearing(shear.shear);
        public Matrix3x3Transform3(ShearXY3 shear, Scale1 scale) => this = ShearingScaling(shear.shear, scale.scale);
        public Matrix3x3Transform3(ShearXY3 shear, Scale3 scale) => this = ShearingScaling(shear.shear, scale.scale);
        public Matrix3x3Transform3(Scale1 scale) => this = Scaling(scale.scale);
        public Matrix3x3Transform3(Scale3 scale) => this = Scaling(scale.scale);

        public static implicit operator float3x3(Matrix3x3Transform3 o) => o.matrix;
        public static implicit operator Matrix3x3Transform3(float3x3 o) => new Matrix3x3Transform3(o);

        public static explicit operator Matrix3x3Transform3(Rotation3Q o) => new Matrix3x3Transform3(o);
        public static explicit operator Matrix3x3Transform3(Rotation3Euler o) => new Matrix3x3Transform3(o.rotation3, 1);
        public static explicit operator Matrix3x3Transform3(ShearXY3 o) => new Matrix3x3Transform3(o);
        public static explicit operator Matrix3x3Transform3(Scale1 o) => new Matrix3x3Transform3(o);
        public static explicit operator Matrix3x3Transform3(Scale3 o) => new Matrix3x3Transform3(o);

        public static readonly Matrix3x3Transform3 Identity = new Matrix3x3Transform3(float3x3.identity);

        public static Matrix3x3Transform3 Rotating(quaternion rotation) => new float3x3(rotation);
        public static Matrix3x3Transform3 RotatingShearing(quaternion rotation, float3 shear) => math.mul(Rotating(rotation), Shearing(shear));
        public static Matrix3x3Transform3 RotatingShearingScaling(quaternion rotation, float3 shear, float scale) => math.mul(Rotating(rotation), ShearingScaling(shear, scale));
        public static Matrix3x3Transform3 RotatingShearingScaling(quaternion rotation, float3 shear, float3 scale) => math.mul(Rotating(rotation), ShearingScaling(shear, scale));
        public static Matrix3x3Transform3 RotatingScaling(quaternion rotation, float scale) => math.mul(Rotating(rotation), Scaling(scale));
        public static Matrix3x3Transform3 RotatingScaling(quaternion rotation, float3 scale) => math.mul(Rotating(rotation), Scaling(scale));
        public static Matrix3x3Transform3 Shearing(float3 shear) => new float3x3(1, shear.x, shear.y, 0, 1, shear.z, 0, 0, 1);
        public static Matrix3x3Transform3 ShearingScaling(float3 shear, float scale) => new float3x3(scale, scale * shear.x, scale * shear.y, 0, scale, scale * shear.z, 0, 0, scale);
        public static Matrix3x3Transform3 ShearingScaling(float3 shear, float3 scale) => new float3x3(scale.x, scale.y * shear.x, scale.z * shear.y, 0, scale.y, scale.z * shear.z, 0, 0, scale.z);
        public static Matrix3x3Transform3 Scaling(float scale) => float3x3.Scale(scale);
        public static Matrix3x3Transform3 Scaling(float3 scale) => float3x3.Scale(scale);

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

        public float3x3 shear3scale3
        {
            get => NiMath.GetShearScale(this);
            set => this = NiMath.ReShearScale(this, value);
        }

        public float3x3 shear3scale3Inversed
        {
            get => NiMath.GetShearScaleInverse(this);
        }

        public float3 column0 => matrix.c0;
        public float3 column1 => matrix.c1;
        public float3 column2 => matrix.c2;
        public float determinant => math.determinant(matrix);
        public bool isOrthonormal => NiMath.NearEqual(math.mul(matrix, math.transpose(matrix)), Identity.matrix, 0.001f);
        public bool isOrthogonal => NiMath.NearEqual(math.mul(matrix, math.transpose(matrix)), float3x3.Scale(scale3 * scale3), 0.001f);
        public Rotation3Q Rotation3 { get => new Rotation3Q(rotation3); set => rotation3 = value.rotation; }
        public Scale3 Scale3 { get => new Scale3(scale3); set => scale3 = value.scale; }
        public ShearXY3 Shear3 { get => new ShearXY3(shear3); set => scale3 = value.shear; }
        public ShearXY3 Shear3Scale3 { get => new ShearXY3(shear3); set => scale3 = value.shear; }
        public float3 this[float3 o] => Transform(o);

        public override string ToString() => $"{nameof(Matrix3x3Transform3)}({matrix.c0.x}, {matrix.c1.x}, {matrix.c2.x}, {matrix.c0.y}, {matrix.c1.y}, {matrix.c2.y}, {matrix.c0.z}, {matrix.c1.z}, {matrix.c2.z})";
        
        public bool Equals(Matrix3x3Transform3 other) => NiMath.Equal(this, other);
        
        public bool NearEquals(Translation3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Rotation3Q other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Scale1 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Scale3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(RigidTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(UniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(NonUniformTransform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Matrix3x3Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);
        public bool NearEquals(Matrix4x4Transform3 other, float margin) => NiMath.NearEqual(this, other, margin);

        public Matrix3x3Transform3 ToMatrix3x3Transform3 => new float3x3(matrix);
        public Matrix4x4Transform3 ToMatrix4x4Transform3 => new float4x4(matrix, float3.zero);
        public Matrix3x3Transform3 Transposed => math.transpose(matrix);
        public Matrix3x3Transform3 Inversed => NiMath.Inverse(this);

        public Matrix4x4Transform3 Translated(float3 translation) => NiMath.Translate(translation, this);
        public Matrix3x3Transform3 Rotated(quaternion rotation) => NiMath.Rotate(rotation, this);
        public Matrix3x3Transform3 Sheared(float3 shear) => NiMath.Shear(shear, this);
        public Matrix3x3Transform3 Scaled(float scale) => NiMath.Scale(scale, this);
        public Matrix3x3Transform3 Scaled(float3 scale) => NiMath.Scale(scale, this);

        public Matrix4x4Transform3 Translate(float3 translation) => NiMath.Translate(this, translation);
        public Matrix3x3Transform3 Rotate(quaternion rotation) => NiMath.Rotate(this, rotation);
        public Matrix3x3Transform3 Shear(float3 shear) => NiMath.Shear(this, shear);
        public Matrix3x3Transform3 Scale(float scale) => NiMath.Scale(this, scale);
        public Matrix3x3Transform3 Scale(float3 scale) => NiMath.Scale(this, scale);

        public Matrix4x4Transform3 Translated(Translation3 translation) => NiMath.Translate(translation, this);
        public Matrix3x3Transform3 Rotated(Rotation3Q rotation) => NiMath.Rotate(rotation, this);
        public Matrix3x3Transform3 Sheared(ShearXY3 shear) => NiMath.Shear(shear, this);
        public Matrix3x3Transform3 Scaled(Scale1 scale) => NiMath.Scale(scale, this);
        public Matrix3x3Transform3 Scaled(Scale3 scale) => NiMath.Scale(scale, this);

        public Matrix4x4Transform3 Translate(Translation3 translation) => NiMath.Translate(this, translation);
        public Matrix3x3Transform3 Rotate(Rotation3Q rotation) => NiMath.Rotate(this, rotation);
        public Matrix3x3Transform3 Shear(ShearXY3 shear) => NiMath.Shear(this, shear);
        public Matrix3x3Transform3 Scale(Scale1 scale) => NiMath.Scale(this, scale);
        public Matrix3x3Transform3 Scale(Scale3 scale) => NiMath.Scale(this, scale);

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

        public Matrix4x4Transform3 Mul(Translation3 primitive) => NiMath.Mul(this, primitive);
        public Matrix3x3Transform3 Mul(Rotation3Q primitive) => NiMath.Mul(this, primitive);
        public Matrix3x3Transform3 Mul(Scale1 primitive) => NiMath.Mul(this, primitive);
        public Matrix3x3Transform3 Mul(Scale3 primitive) => NiMath.Mul(this, primitive);
        public Matrix4x4Transform3 Mul(RigidTransform3 primitive) => NiMath.Mul(this, primitive);
        public Matrix4x4Transform3 Mul(UniformTransform3 primitive) => NiMath.Mul(this, primitive);
        public Matrix4x4Transform3 Mul(NonUniformTransform3 primitive) => NiMath.Mul(this, primitive);
        public Matrix3x3Transform3 Mul(Matrix3x3Transform3 primitive) => NiMath.Mul(this, primitive);
        public Matrix4x4Transform3 Mul(Matrix4x4Transform3 primitive) => NiMath.Mul(this, primitive);
        public Obb3M Mul(Aabb3M o) => NiMath.Mul(this, o);
        public Obb3M Mul(Aabb3C o) => NiMath.Mul(this, o);
        public Obb3M Mul(Aabb3S o) => NiMath.Mul(this, o);
        public Obb3M Mul(Obb3T o) => NiMath.Mul(this, o);
        public Obb3M Mul(Obb3M o) => NiMath.Mul(this, o);
        public Matrix4x4Transform3 Div(Translation3 primitive) => NiMath.Div(this, primitive);
        public Matrix3x3Transform3 Div(Rotation3Q primitive) => NiMath.Div(this, primitive);
        public Matrix3x3Transform3 Div(Scale1 primitive) => NiMath.Div(this, primitive);
        public Matrix3x3Transform3 Div(Scale3 primitive) => NiMath.Div(this, primitive);
        public Matrix4x4Transform3 Div(RigidTransform3 primitive) => NiMath.Div(this, primitive);
        public Matrix4x4Transform3 Div(UniformTransform3 primitive) => NiMath.Div(this, primitive);
        public Matrix4x4Transform3 Div(NonUniformTransform3 primitive) => NiMath.Div(this, primitive);
        public Matrix3x3Transform3 Div(Matrix3x3Transform3 primitive) => NiMath.Div(this, primitive);
        public Matrix4x4Transform3 Div(Matrix4x4Transform3 primitive) => NiMath.Div(this, primitive);
        public Obb3M Div(Aabb3M o) => NiMath.Div(this, o);
        public Obb3M Div(Aabb3C o) => NiMath.Div(this, o);
        public Obb3M Div(Aabb3S o) => NiMath.Div(this, o);
        public Obb3M Div(Obb3T o) => NiMath.Div(this, o);
        public Obb3M Div(Obb3M o) => NiMath.Div(this, o);
    }

    public static partial class NiMath
    {
        public static bool Equal(Matrix3x3Transform3 a, Matrix3x3Transform3 b) => Equal(a.matrix, b.matrix);

        public static bool NearEqual(Matrix3x3Transform3 a, Translation3 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform3, margin);
        public static bool NearEqual(Matrix3x3Transform3 a, Rotation3Q b, float margin) => NearEqual(a, b.ToMatrix4x4Transform3, margin);
        public static bool NearEqual(Matrix3x3Transform3 a, Scale1 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform3, margin);
        public static bool NearEqual(Matrix3x3Transform3 a, Scale3 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform3, margin);
        public static bool NearEqual(Matrix3x3Transform3 a, RigidTransform3 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform3, margin);
        public static bool NearEqual(Matrix3x3Transform3 a, UniformTransform3 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform3, margin);
        public static bool NearEqual(Matrix3x3Transform3 a, NonUniformTransform3 b, float margin) => NearEqual(a, b.ToMatrix4x4Transform3, margin);
        public static bool NearEqual(Matrix3x3Transform3 a, Matrix3x3Transform3 b, float margin) => NearEqual(a.matrix, b.matrix, margin);
        public static bool NearEqual(Matrix3x3Transform3 a, Matrix4x4Transform3 b, float margin) => NearEqual(a.matrix, b.matrix, margin);

        public static Matrix3x3Transform3 Inverse(Matrix3x3Transform3 a) => math.inverse(a.matrix);
        public static float3 RotateVector(Matrix3x3Transform3 rotation, float3 vector) => math.mul(rotation, vector);

        public static Rotation3Q GetRotation(Matrix3x3Transform3 o) { DecomposeRotation(o, out Rotation3Q rotation); return rotation; }
        public static Rotation3Q GetRotationOrthonormal(Matrix3x3Transform3 o) { DecomposeRotationOrthonormal(o, out Rotation3Q rotation); return rotation; }
        public static Matrix3x3Transform3 GetRotationMatrix(Matrix3x3Transform3 o) { DecomposeRotationMatrix(o, out Matrix3x3Transform3 rotation); return rotation; }
        public static Matrix3x3Transform3 GetRotationMatrixOrthonormal(Matrix3x3Transform3 o) => GetRotationOrthonormal(o).ToMatrix3x3Transform3;
        public static ShearXY3 GetShear(Matrix3x3Transform3 o) { DecomposeShear(o, out ShearXY3 shear); return shear; }
        public static Scale3 GetScale(Matrix3x3Transform3 o) { DecomposeScale(o, out Scale3 scale); return scale; }
        public static Scale3 GetScaleOrthogonal(Matrix3x3Transform3 o) { DecomposeScaleOrthogonal(o, out Scale3 scale); return scale; }
        public static Matrix3x3Transform3 GetShearScale(Matrix3x3Transform3 o) { DecomposeShearScale(o, out Matrix3x3Transform3 shearScale); return shearScale; }
        public static Matrix3x3Transform3 GetShearScaleInverse(Matrix3x3Transform3 o) { DecomposeShearScaleInverse(o, out Matrix3x3Transform3 shearScaleInverse); return shearScaleInverse; }

        public static Matrix3x3Transform3 ReRotate(Matrix3x3Transform3 o, quaternion rotation) => math.mul(new float3x3(rotation), GetShearScale(o));
        public static Matrix3x3Transform3 ReRotateOrthonormal(Matrix3x3Transform3 o, quaternion rotation) => Rotate(math.mul(rotation, math.inverse(GetRotationOrthonormal(o))), o);
        public static Matrix3x3Transform3 ReShear(Matrix3x3Transform3 o, float3 shear)
        {
            Decompose(o, out Matrix3x3Transform3 rotation, out ShearXY3 shearOld, out Scale3 scale);
            return math.mul(rotation, new Matrix3x3Transform3(new ShearXY3(shear), scale));
        }
        public static Matrix3x3Transform3 ReScale(Matrix3x3Transform3 o, float scale) => Scale(o, Inverse(GetScale(o)).scale * scale);
        public static Matrix3x3Transform3 ReScale(Matrix3x3Transform3 o, float3 scale) => Mul(o, new Matrix3x3Transform3(o.scale3 * scale));
        public static Matrix3x3Transform3 ReScaleOrthogonal(Matrix3x3Transform3 o, float scale) => new float3x3(
                scale * math.length(o.column0.xyz) * o.column0.xyz,
                scale * math.length(o.column1.xyz) * o.column1.xyz,
                scale * math.length(o.column2.xyz) * o.column2.xyz); //Scale(o, Inverse(GetScaleOrthogonal(o)).scale * scale);
        public static Matrix3x3Transform3 ReScaleOrthogonal(Matrix3x3Transform3 o, float3 scale) => new float3x3(
                scale.x * math.length(o.column0.xyz) * o.column0.xyz,
                scale.y * math.length(o.column1.xyz) * o.column1.xyz,
                scale.z * math.length(o.column2.xyz) * o.column2.xyz); // Scale(o, Inverse(GetScaleOrthogonal(o)).scale * scale);

        public static Matrix3x3Transform3 ReShearScale(Matrix3x3Transform3 o, float3x3 shearScale) => Mul(o.rotation3M, shearScale);

        public static Matrix3x3Transform3 ReRotate(Matrix3x3Transform3 o, Rotation3Q rotation) => ReRotate(o, rotation.rotation);
        public static Matrix3x3Transform3 ReRotateOrthonormal(Matrix3x3Transform3 o, Rotation3Q rotation) => ReRotate(o, rotation.rotation);
        public static Matrix3x3Transform3 ReShear(Matrix3x3Transform3 o, ShearXY3 shear) => ReShear(o, shear.shear);
        public static Matrix3x3Transform3 ReScale(Matrix3x3Transform3 o, Scale1 scale) => ReScale(o, scale.scale);
        public static Matrix3x3Transform3 ReScale(Matrix3x3Transform3 o, Scale3 scale) => ReScale(o, scale.scale);
        public static Matrix3x3Transform3 ReScaleOrthogonal(Matrix3x3Transform3 o, Scale1 scale) => ReScaleOrthogonal(o, scale.scale);
        public static Matrix3x3Transform3 ReScaleOrthogonal(Matrix3x3Transform3 o, Scale3 scale) => ReScaleOrthogonal(o, scale.scale);

        public static Matrix4x4Transform3 Translate(float3 translation, Matrix3x3Transform3 o) => new float4x4(o, translation);
        public static Matrix3x3Transform3 Rotate(quaternion rotation, Matrix3x3Transform3 o) => new Matrix3x3Transform3(math.mul(new float3x3(rotation), o.matrix));
        public static Matrix3x3Transform3 Shear(float3 shear, Matrix3x3Transform3 o) => Mul(Matrix3x3Transform3.Shearing(shear), o);
        public static Matrix3x3Transform3 Scale(float scale, Matrix3x3Transform3 o) => new Matrix3x3Transform3(math.mul(float3x3.Scale(scale), o.matrix));
        public static Matrix3x3Transform3 Scale(float3 scale, Matrix3x3Transform3 o) => new Matrix3x3Transform3(math.mul(float3x3.Scale(scale), o.matrix));

        public static Matrix4x4Transform3 Translate(Matrix3x3Transform3 o, float3 translation) => new float4x4(o, math.mul(o, translation));
        public static Matrix3x3Transform3 Rotate(Matrix3x3Transform3 o, quaternion rotation) => math.mul(o, new float3x3(rotation));
        public static Matrix3x3Transform3 Shear(Matrix3x3Transform3 o, float3 shear) => Mul(o, Matrix3x3Transform3.Shearing(shear));
        public static Matrix3x3Transform3 Scale(Matrix3x3Transform3 o, float scale) => new Matrix3x3Transform3(scale * o.column0, scale * o.column1, scale * o.column2);
        public static Matrix3x3Transform3 Scale(Matrix3x3Transform3 o, float3 scale) => new Matrix3x3Transform3(scale.x * o.column0, scale.y * o.column1, scale.z * o.column2);

        public static Matrix4x4Transform3 Translate(Translation3 translation, Matrix3x3Transform3 o) => new float4x4(o, translation.translation);
        public static Matrix3x3Transform3 Rotate(Rotation3Q rotation, Matrix3x3Transform3 o) => new Matrix3x3Transform3(math.mul(new float3x3(rotation), o.matrix));
        public static Matrix3x3Transform3 Shear(ShearXY3 shear, Matrix3x3Transform3 o) => Mul(Matrix3x3Transform3.Shearing(shear.shear), o);
        public static Matrix3x3Transform3 Scale(Scale1 scale, Matrix3x3Transform3 o) => new Matrix3x3Transform3(math.mul(float3x3.Scale(scale.scale), o.matrix));
        public static Matrix3x3Transform3 Scale(Scale3 scale, Matrix3x3Transform3 o) => new Matrix3x3Transform3(math.mul(float3x3.Scale(scale.scale), o.matrix));

        public static Matrix4x4Transform3 Translate(Matrix3x3Transform3 o, Translation3 translation) => Translate(o, translation.translation);
        public static Matrix3x3Transform3 Rotate(Matrix3x3Transform3 o, Rotation3Q rotation) => Rotate(o, rotation.rotation);
        public static Matrix3x3Transform3 Shear(Matrix3x3Transform3 o, ShearXY3 shear) => Mul(o, Matrix3x3Transform3.Shearing(shear.shear));
        public static Matrix3x3Transform3 Scale(Matrix3x3Transform3 o, Scale1 scale) => Scale(o, scale.scale);
        public static Matrix3x3Transform3 Scale(Matrix3x3Transform3 o, Scale3 scale) => Scale(o, scale.scale);

        public static float3 Transform(Matrix3x3Transform3 a, float3 b) => math.mul(a, b);
        public static Direction3 Transform(Matrix3x3Transform3 a, Direction3 b) => Direction3.Direction(Transform(a, b.vector));
        public static ProjectionAxis3x1 Transform(Matrix3x3Transform3 a, ProjectionAxis3x1 b) => new ProjectionAxis3x1(Transform(a, b.axis));
        public static ProjectionAxis1x3 Transform(Matrix3x3Transform3 a, ProjectionAxis1x3 b) => new ProjectionAxis1x3(Transform(a, b.axis));
        public static Ray3 Transform(Matrix3x3Transform3 a, Ray3 b) => new Ray3(Transform(a, b.translation), RotateVector(a, b.projectionAxis));

        public static float3 Untransform(Matrix3x3Transform3 a, float3 b) => math.mul(Inverse(a), b);
        public static Direction3 Untransform(Matrix3x3Transform3 a, Direction3 b) => Transform(Inverse(a), b);
        public static ProjectionAxis3x1 Untransform(Matrix3x3Transform3 a, ProjectionAxis3x1 b) => Transform(Inverse(a), b);
        public static ProjectionAxis1x3 Untransform(Matrix3x3Transform3 a, ProjectionAxis1x3 b) => Transform(Inverse(a), b);
        public static Ray3 Untransform(Matrix3x3Transform3 a, Ray3 b) => Transform(Inverse(a), b);

        public static Matrix4x4Transform3 Mul(Matrix3x3Transform3 a, Translation3 b) => Translate(a, b);
        public static Matrix3x3Transform3 Mul(Matrix3x3Transform3 a, Rotation3Q b) => Rotate(a, b);
        public static Matrix3x3Transform3 Mul(Matrix3x3Transform3 a, Scale1 b) => Scale(a, b);
        public static Matrix3x3Transform3 Mul(Matrix3x3Transform3 a, Scale3 b) => Scale(a, b);
        public static Matrix4x4Transform3 Mul(Matrix3x3Transform3 a, RigidTransform3 b) => math.mul(a.ToMatrix4x4Transform3, b.ToMatrix4x4Transform3);
        public static Matrix4x4Transform3 Mul(Matrix3x3Transform3 a, UniformTransform3 b) => math.mul(a.ToMatrix4x4Transform3, b.ToMatrix4x4Transform3);
        public static Matrix4x4Transform3 Mul(Matrix3x3Transform3 a, NonUniformTransform3 b) => math.mul(a.ToMatrix4x4Transform3, b.ToMatrix4x4Transform3);
        public static Matrix3x3Transform3 Mul(Matrix3x3Transform3 a, Matrix3x3Transform3 b) => math.mul(a, b);
        public static Matrix4x4Transform3 Mul(Matrix3x3Transform3 a, Matrix4x4Transform3 b) => math.mul(a.ToMatrix4x4Transform3, b);
        public static Obb3M Mul(Matrix3x3Transform3 a, Aabb3M b) => Mul(a, b.ToMatrix4x4Transform3);
        public static Obb3M Mul(Matrix3x3Transform3 a, Aabb3C b) => Mul(a, b.ToMatrix4x4Transform3);
        public static Obb3M Mul(Matrix3x3Transform3 a, Aabb3S b) => Mul(a, b.ToMatrix4x4Transform3);
        public static Obb3M Mul(Matrix3x3Transform3 a, Obb3T b) => Mul(a, b.ToMatrix4x4Transform3);
        public static Obb3M Mul(Matrix3x3Transform3 a, Obb3M b) => Mul(a, b.ToMatrix4x4Transform3);
        public static Matrix4x4Transform3 Div(Matrix3x3Transform3 a, Translation3 b) => Translate(Inverse(a), b);
        public static Matrix3x3Transform3 Div(Matrix3x3Transform3 a, Rotation3Q b) => Rotate(Inverse(a), b);
        public static Matrix3x3Transform3 Div(Matrix3x3Transform3 a, Scale1 b) => Scale(Inverse(a), b);
        public static Matrix3x3Transform3 Div(Matrix3x3Transform3 a, Scale3 b) => Scale(Inverse(a), b);
        public static Matrix4x4Transform3 Div(Matrix3x3Transform3 a, RigidTransform3 b) => math.mul(Inverse(a).ToMatrix4x4Transform3, b.ToMatrix4x4Transform3);
        public static Matrix4x4Transform3 Div(Matrix3x3Transform3 a, UniformTransform3 b) => math.mul(Inverse(a).ToMatrix4x4Transform3, b.ToMatrix4x4Transform3);
        public static Matrix4x4Transform3 Div(Matrix3x3Transform3 a, NonUniformTransform3 b) => math.mul(Inverse(a).ToMatrix4x4Transform3, b.ToMatrix4x4Transform3);
        public static Matrix3x3Transform3 Div(Matrix3x3Transform3 a, Matrix3x3Transform3 b) => math.mul(Inverse(a), b);
        public static Matrix4x4Transform3 Div(Matrix3x3Transform3 a, Matrix4x4Transform3 b) => math.mul(Inverse(a).ToMatrix4x4Transform3, b);
        public static Obb3M Div(Matrix3x3Transform3 a, Aabb3M b) => Mul(Inverse(a), b);
        public static Obb3M Div(Matrix3x3Transform3 a, Aabb3C b) => Mul(Inverse(a), b);
        public static Obb3M Div(Matrix3x3Transform3 a, Aabb3S b) => Mul(Inverse(a), b);
        public static Obb3M Div(Matrix3x3Transform3 a, Obb3T b) => Mul(Inverse(a), b);
        public static Obb3M Div(Matrix3x3Transform3 a, Obb3M b) => Mul(Inverse(a), b);

        public static void DecomposeRotationMatrix(Matrix3x3Transform3 o, out Matrix3x3Transform3 rotation, out Matrix3x3Transform3 shearScaleInverse)
        {
            var det = math.determinant(o.matrix);
            var m3t = math.transpose(o.matrix);
            float3x3 mTm = math.mul(m3t, o.matrix);
            float s = math.sign(det);
            float a = s * math.sqrt(mTm.c0.x);
            float ai = math.rcp(a);
            float di = -mTm.c1.x / ai;
            float ei = -mTm.c2.x / ai;
            float bi = math.rcp(s * math.sqrt(mTm.c1.y - di * di));
            float fi = -(mTm.c2.y - di * ei) / bi;
            float ci = math.rcp(s * math.sqrt(mTm.c2.z - ei * ei - fi * fi));
            shearScaleInverse = new float3x3(ai, di, ei, 0, bi, fi, 0, 0, ci);
            rotation = math.mul(o.matrix, shearScaleInverse);
        }
        public static void DecomposeRotationMatrix(Matrix3x3Transform3 o, out Matrix3x3Transform3 rotation) => DecomposeRotationMatrix(o, out rotation, out _);
        public static void DecomposeRotation(Matrix3x3Transform3 o, out Rotation3Q rotation) { DecomposeRotationMatrix(o, out Matrix3x3Transform3 rotationMatrix); rotation = new(new quaternion(rotationMatrix)); }
        public static void DecomposeRotationOrthonormal(Matrix3x3Transform3 o, out Rotation3Q rotation) => rotation = new(new quaternion(o));
        public static void DecomposeShear(Matrix3x3Transform3 o, out ShearXY3 shear)
        {
            var det = math.determinant(o.matrix);
            var m3t = math.transpose(o.matrix);
            float3x3 mTm = math.mul(m3t, o.matrix);
            float s = math.sign(det);
            float a = s * math.sqrt(mTm.c0.x);
            float d = mTm.c1.x / a;
            float e = mTm.c2.x / a;
            float b = s * math.sqrt(mTm.c1.y - d * d);
            float f = (mTm.c2.y - d * e) / b;
            float c = s * math.sqrt(mTm.c2.z - e * e - f * f);
            shear = new(new float3(d / b, e / c, f / c));
        }
        public static void DecomposeScale(Matrix3x3Transform3 o, out Scale3 scale)
        {
            var det = math.determinant(o.matrix);
            var m3t = math.transpose(o.matrix);
            float3x3 mTm = math.mul(m3t, o.matrix);
            float s = math.sign(det);
            float a = s * math.sqrt(mTm.c0.x);
            float d = mTm.c1.x / a;
            float e = mTm.c2.x / a;
            float b = s * math.sqrt(mTm.c1.y - d * d);
            float f = (mTm.c2.y - d * e) / b;
            float c = s * math.sqrt(mTm.c2.z - e * e - f * f);
            scale = new(new float3(a, b, c));
        }
        public static void DecomposeScaleOrthogonal(Matrix3x3Transform3 o, out Scale3 scale) => scale = new(new float3(math.length(o.matrix.c0.xyz), math.length(o.matrix.c1.xyz), math.length(o.matrix.c2.xyz)));
        public static void DecomposeShearScale(Matrix3x3Transform3 o, out Matrix3x3Transform3 shearScale, out Matrix3x3Transform3 shearScaleInverse)
        {
            var det = math.determinant(o.matrix);
            var m3t = math.transpose(o.matrix);
            float3x3 mTm = math.mul(m3t, o.matrix);
            float s = math.sign(det);
            float a = s * math.sqrt(mTm.c0.x);
            float d = mTm.c1.x / a;
            float e = mTm.c2.x / a;
            float b = s * math.sqrt(mTm.c1.y - d * d);
            float f = (mTm.c2.y - d * e) / b;
            float c = s * math.sqrt(mTm.c2.z - e * e - f * f);
            shearScale = new float3x3(a, d, e, 0, b, f, 0, 0, c);
            float ai = math.rcp(a);
            float di = -mTm.c1.x / ai;
            float ei = -mTm.c2.x / ai;
            float bi = math.rcp(s * math.sqrt(mTm.c1.y - di * di));
            float fi = -(mTm.c2.y - di * ei) / bi;
            float ci = math.rcp(s * math.sqrt(mTm.c2.z - ei * ei - fi * fi));
            shearScaleInverse = new float3x3(ai, di, ei, 0, bi, fi, 0, 0, ci);
        }
        public static void DecomposeShearScale(Matrix3x3Transform3 o, out Matrix3x3Transform3 shearScale)
        {
            var det = math.determinant(o.matrix);
            var m3t = math.transpose(o.matrix);
            float3x3 mTm = math.mul(m3t, o.matrix);
            float s = math.sign(det);
            float a = s * math.sqrt(mTm.c0.x);
            float d = mTm.c1.x / a;
            float e = mTm.c2.x / a;
            float b = s * math.sqrt(mTm.c1.y - d * d);
            float f = (mTm.c2.y - d * e) / b;
            float c = s * math.sqrt(mTm.c2.z - e * e - f * f);
            shearScale = new float3x3(a, d, e, 0, b, f, 0, 0, c);
        }
        public static void DecomposeShearScaleInverse(Matrix3x3Transform3 o, out Matrix3x3Transform3 shearScaleInverse)
        {
            var det = math.determinant(o.matrix);
            var m3t = math.transpose(o.matrix);
            float3x3 mTm = math.mul(m3t, o.matrix);
            float s = math.sign(det);
            float ai = math.rcp(s * math.sqrt(mTm.c0.x));
            float di = -mTm.c1.x / ai;
            float ei = -mTm.c2.x / ai;
            float bi = math.rcp(s * math.sqrt(mTm.c1.y - di * di));
            float fi = -(mTm.c2.y - di * ei) / bi;
            float ci = math.rcp(s * math.sqrt(mTm.c2.z - ei * ei - fi * fi));
            shearScaleInverse = new float3x3(ai, di, ei, 0, bi, fi, 0, 0, ci);
        }
        public static void Decompose(Matrix3x3Transform3 o, out Matrix3x3Transform3 rotation, out Matrix3x3Transform3 shearScale, out Matrix3x3Transform3 shearScaleInverse)
        {
            var det = math.determinant(o.matrix);
            var m3t = math.transpose(o.matrix);
            float3x3 mTm = math.mul(m3t, o.matrix);
            float s = math.sign(det);
            float a = s * math.sqrt(mTm.c0.x);
            float d = mTm.c1.x / a;
            float e = mTm.c2.x / a;
            float b = s * math.sqrt(mTm.c1.y - d * d);
            float f = (mTm.c2.y - d * e) / b;
            float c = s * math.sqrt(mTm.c2.z - e * e - f * f);
            shearScale = new float3x3(a, d, e, 0, b, f, 0, 0, c);
            float ai = math.rcp(a);
            float di = -mTm.c1.x / ai;
            float ei = -mTm.c2.x / ai;
            float bi = math.rcp(s * math.sqrt(mTm.c1.y - di * di));
            float fi = -(mTm.c2.y - di * ei) / bi;
            float ci = math.rcp(s * math.sqrt(mTm.c2.z - ei * ei - fi * fi));
            shearScaleInverse = new float3x3(ai, di, ei, 0, bi, fi, 0, 0, ci);
            rotation = math.mul(o.matrix, shearScaleInverse);
        }
        public static void Decompose(Matrix3x3Transform3 o, out Matrix3x3Transform3 rotation, out Matrix3x3Transform3 shearScale) => Decompose(o, out rotation, out shearScale, out _);
        public static void Decompose(Matrix3x3Transform3 o, out Matrix3x3Transform3 rotation, out ShearXY3 shear, out Scale3 scale)
        {
            Decompose(o, out rotation, out Matrix3x3Transform3 shearScale);
            shear = new(new float3(shearScale.column1.x / shearScale.column1.y,
                                   shearScale.column2.x / shearScale.column2.z,
                                   shearScale.column2.y / shearScale.column2.z));
            scale = new(new float3(shearScale.column0.x, shearScale.column0.y, shearScale.column0.z));
        }
        public static void Decompose(Matrix3x3Transform3 o, out Rotation3Q rotation, out ShearXY3 shear, out Scale3 scale)
        {
            Decompose(o, out Matrix3x3Transform3 rotationMatrix, out shear, out scale);
            rotation = new quaternion(rotationMatrix);
        }
    }
}