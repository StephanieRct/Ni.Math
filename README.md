Mathematics Package for Unity

Transforms:
  * Translation1 : 1D translation
  * Translation3 : 3D translation
  * Rotation3Q : 3D rotation as quaternion
  * Rotation3E : 3D rotation as Euler X, Y, Z angles
  * Scale1 : 1D scale, 3D uniform scale
  * Scale3 : 3D non-uniform scale
  * RigidTransform3 : 3D translation * 3D rotation
  * UniformTransform3 : 3D translation * 3D rotation * 3D uniform scale
  * NonUniformTransform3 : 3D translation * 3D rotation * 3D non-uniform scale
  * Matrix3x3Transform3 : 3D rotation * 3D shear * 3D non-uniform scale
  * Matrix4x4Transform3 : 3D translation * 3D rotation * 3D shear * 3D non-uniform scale
  * Aabb3M : 3D translation * 3D non-uniform scale : 3D Axis-Aligned Bounding Box (min, max)
  * Aabb3S : 3D translation * 3D non-uniform scale : 3D Axis-Aligned Bounding Box (min, size)
  * Aabb3C : 3D translation * 3D non-uniform scale : 3D Axis-Aligned Bounding Box (center, extent)
  * Obb3T : 3D translation * 3D rotation * 3D non-uniform scale : 3D Oriented Bounding Box (NonUniformTransform3)
  * Obb3M : 3D translation * 3D rotation * 3D shear * 3D non-uniform scale : 3D Oriented Bounding Box (Matrix4x4Transform3)
  * ProjectionAxis3x1 : 3D projection from 1D : Project a 1D scalar value onto a 3D axis vector.
  * ProjectionAxis1x3 : 1D projection from 3D : Project a 3D vector onto an axis vector 1D scalar value.
  * Ray3 : 3D translation * 3D projection from 1D : 3D ray (origin, direction)
  * RayI3 : 1D projection from 3D * 3D translation : 3D inverse ray.
  * LineSegment3: 3D translation * 3D projection from 1D : 2 3D points connected as a line segment

Static classes:
  * NiMath : Contains all variations of Translate, Rotate, Scale, Transform, Mul, Div, etc functions.
  * Cube3 : Contains metrics for a 3D cube such as vertices, edges, indices, etc.
    
Ni.Math.Editor:
  * PropertySerialization : Utility function for serialization of math transforms with the SerializedProperty API
  * NiMathDrawer : Base drawer class. Each transform has its own drawer class
  * NiMathHandles : Utility functions for drawing transforms with the Handles API
  * NiMathGizmos : Utility functions for drawing transforms with the Gizmos API
  * NiMathEditorGUI : Utility functions for editor GUI.
