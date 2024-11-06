using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Ni.Mathematics.Editor
{
    [CustomPropertyDrawer(typeof(Obb3M))]
    public class DrawerObb3M : NiMathDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            OnGUISubPropertyField(property, "Matrix4x4Transform.matrix");
        }

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            return BuildDefault(property, new Gizmo());
        }

        protected override void AddProperties(SerializedProperty property, VisualElement root)
        {
            root.Add(CreateSubPropertyField(property, "Matrix4x4Transform.matrix"));
        }

        public class Gizmo : NiMathEditorGUI.IGizmo
        {
            public void RenderLocal(SceneView sceneView, SerializedProperty property, Transform transform)
            {
                var o = PropertySerialization.PropertyToObb3M(property);
                NiMathHandles.Draw(o, transform);
            }

            public void RenderWorld(SceneView sceneView, SerializedProperty property)
            {
                var o = PropertySerialization.PropertyToObb3M(property);
                NiMathHandles.Draw(o);
            }
        }
    }
    public partial class NiMathHandles
    {
        public static void Draw(Obb3M o)
        {
            for (int i = 0; i < Cube3.IdentityEdgesArray.Length; i++)
                Handles.DrawLine(o.Transform(Cube3.IdentityEdgesArray[i].a), o.Transform(Cube3.IdentityEdgesArray[i].b));
        }
        public static void Draw(Obb3M o, Transform transform)
        {
            for (int i = 0; i < Cube3.IdentityEdgesArray.Length; i++)
                Handles.DrawLine(transform.TransformPoint(o.Transform(Cube3.IdentityEdgesArray[i].a)), transform.TransformPoint(o.Transform(Cube3.IdentityEdgesArray[i].b)));
        }
    }
    public partial class NiMathGizmos
    {
        public static void Draw(Obb3M o)
        {
            for (int i = 0; i < Cube3.IdentityEdgesArray.Length; i++)
                Gizmos.DrawLine(o.Transform(Cube3.IdentityEdgesArray[i].a), o.Transform(Cube3.IdentityEdgesArray[i].b));
        }
        public static void Draw(Obb3M o, Transform transform)
        {
            for (int i = 0; i < Cube3.IdentityEdgesArray.Length; i++)
                Gizmos.DrawLine(transform.TransformPoint(o.Transform(Cube3.IdentityEdgesArray[i].a)), transform.TransformPoint(o.Transform(Cube3.IdentityEdgesArray[i].b)));
        }
    }
}