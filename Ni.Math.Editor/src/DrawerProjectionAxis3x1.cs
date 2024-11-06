using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Ni.Mathematics.Editor
{
    [CustomPropertyDrawer(typeof(ProjectionAxis3x1))]
    public class DrawerProjectionAxis3x1 : NiMathDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            OnGUISubPropertyField(property, "axis");
        }

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            return BuildDefault(property, new Gizmo());
        }

        protected override void AddProperties(SerializedProperty property, VisualElement root)
        {
            root.Add(CreateSubPropertyField(property, "axis"));
        }

        public class Gizmo : NiMathEditorGUI.IGizmo
        {
            public void RenderLocal(SceneView sceneView, SerializedProperty property, Transform transform) => NiMathHandles.Draw(PropertySerialization.PropertyToProjectionAxis3x1(property), transform);
            public void RenderWorld(SceneView sceneView, SerializedProperty property) => NiMathHandles.Draw(PropertySerialization.PropertyToProjectionAxis3x1(property));
        }
    }
    public partial class NiMathHandles
    {
        public static void Draw(ProjectionAxis3x1 o) => Handles.DrawLine(o.Transform(0), o.Transform(1));
        public static void Draw(ProjectionAxis3x1 o, Transform transform) => Handles.DrawLine(transform.TransformPoint(o.Transform(0)), transform.TransformPoint(o.Transform(1)));
    }
    public partial class NiMathGizmos
    {
        public static void Draw(ProjectionAxis3x1 o) => Gizmos.DrawLine(o.Transform(0), o.Transform(1));
        public static void Draw(ProjectionAxis3x1 o, Transform transform) => Gizmos.DrawLine(transform.TransformPoint(o.Transform(0)), transform.TransformPoint(o.Transform(1)));
    }

    public static partial class PropertySerialization
    {
        public static void SetProjectionAxis3x1(SerializedProperty property, ProjectionAxis3x1 value) => SetSubFloat3(property, "axis", value.axis);
        public static void SetSubProjectionAxis3x1(SerializedProperty property, string name, ProjectionAxis3x1 value) => SetProjectionAxis3x1(Sub(property, name), value);
        public static ProjectionAxis3x1 PropertyToProjectionAxis3x1(SerializedProperty property) => new ProjectionAxis3x1(SubFloat3(property, "axis"));
        public static ProjectionAxis3x1 SubProjectionAxis3x1(SerializedProperty property, string name) => PropertyToProjectionAxis3x1(Sub(property, name));
    }
}