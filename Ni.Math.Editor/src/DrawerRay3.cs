using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Ni.Mathematics.Editor
{
    [CustomPropertyDrawer(typeof(Ray3))]
    public class DrawerRay3 : NiMathDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            OnGUISubPropertyField(property, "translation");
            OnGUISubPropertyField(property, "projectionAxis");
        }

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            return BuildDefault(property, new Gizmo());
        }

        protected override void AddProperties(SerializedProperty property, VisualElement root)
        {
            root.Add(CreateSubPropertyField(property, "translation"));
            root.Add(CreateSubPropertyField(property, "projectionAxis"));
        }

        public class Gizmo : NiMathEditorGUI.IGizmo
        {
            public void RenderLocal(SceneView sceneView, SerializedProperty property, Transform transform) => NiMathHandles.Draw(PropertySerialization.PropertyToRay3(property), transform);
            public void RenderWorld(SceneView sceneView, SerializedProperty property) => NiMathHandles.Draw(PropertySerialization.PropertyToRay3(property));
        }
    }
    public partial class NiMathHandles
    {
        public static void Draw(Ray3 o) => Handles.DrawLine(o.Transform(0), o.Transform(1));
        public static void Draw(Ray3 o, Transform transform) => Handles.DrawLine(transform.TransformPoint(o.Transform(0)), transform.TransformPoint(o.Transform(1)));
    }
    public partial class NiMathGizmos
    {
        public static void Draw(Ray3 o) => Gizmos.DrawLine(o.Transform(0), o.Transform(1));
        public static void Draw(Ray3 o, Transform transform) => Gizmos.DrawLine(transform.TransformPoint(o.Transform(0)), transform.TransformPoint(o.Transform(1)));
    }


    public static partial class PropertySerialization
    {
        public static void SetRay3(SerializedProperty property, Ray3 value)
        {
            SetSubFloat3(property, "translation", value.translation);
            SetSubFloat3(property, "projectionAxis", value.translation);
        }
        public static void SetSubRay3(SerializedProperty property, string name, Ray3 value) => SetRay3(Sub(property, name), value);
        public static Ray3 PropertyToRay3(SerializedProperty property) => new Ray3(SubFloat3(property, "translation"), SubFloat3(property, "projectionAxis"));
        public static Ray3 SubRay3(SerializedProperty property, string name) => PropertyToRay3(Sub(property, name));
    }
}