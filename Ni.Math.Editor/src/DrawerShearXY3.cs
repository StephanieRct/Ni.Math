using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Ni.Mathematics.Editor
{
    [CustomPropertyDrawer(typeof(ShearXY3))]
    public class DrawerShearXY3 : NiMathDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            OnGUISubPropertyField(property, "shear");
        }

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            return BuildDefault(property, new Gizmo());
        }

        protected override void AddProperties(SerializedProperty property, VisualElement root)
        {
            root.Add(CreateSubPropertyField(property, "shear"));
        }

        public class Gizmo : NiMathEditorGUI.IGizmo
        {
            public void RenderLocal(SceneView sceneView, SerializedProperty property, Transform transform)
            {
                var o = PropertySerialization.PropertyToShearXY3(property);
                NiMathHandles.Draw(o, transform);
            }

            public void RenderWorld(SceneView sceneView, SerializedProperty property)
            {
                var o = PropertySerialization.PropertyToShearXY3(property);
                NiMathHandles.Draw(o);
            }
        }
    }

    public partial class NiMathHandles
    {
        public static void Draw(ShearXY3 o)
        {
            for (int i = 0; i < Cube3.IdentityEdgesArray.Length; i++)
                Handles.DrawLine(o.Transform(Cube3.IdentityEdgesArray[i].a), o.Transform(Cube3.IdentityEdgesArray[i].b));
        }
        public static void Draw(ShearXY3 o, Transform transform)
        {
            for (int i = 0; i < Cube3.IdentityEdgesArray.Length; i++)
                Handles.DrawLine(transform.TransformPoint(o.Transform(Cube3.IdentityEdgesArray[i].a)), transform.TransformPoint(o.Transform(Cube3.IdentityEdgesArray[i].b)));
        }
    }

    public partial class NiMathGizmos
    {
        public static void Draw(ShearXY3 o)
        {
            for (int i = 0; i < Cube3.IdentityEdgesArray.Length; i++)
                Gizmos.DrawLine(o.Transform(Cube3.IdentityEdgesArray[i].a), o.Transform(Cube3.IdentityEdgesArray[i].b));
        }
        public static void Draw(ShearXY3 o, Transform transform)
        {
            for (int i = 0; i < Cube3.IdentityEdgesArray.Length; i++)
                Gizmos.DrawLine(transform.TransformPoint(o.Transform(Cube3.IdentityEdgesArray[i].a)), transform.TransformPoint(o.Transform(Cube3.IdentityEdgesArray[i].b)));
        }
    }

    public static partial class PropertySerialization
    {
        public static void SetShearXY3(SerializedProperty property, ShearXY3 value)
        {
            SetSubFloat3(property, "shear", value.shear);
        }
        public static void SetSubShearXY3(SerializedProperty property, string name, ShearXY3 value) => SetShearXY3(Sub(property, name), value);
        public static ShearXY3 PropertyToShearXY3(SerializedProperty property) => new ShearXY3(SubFloat3(property, "shear"));
        public static ShearXY3 SubShearXY3(SerializedProperty property, string name) => PropertyToShearXY3(Sub(property, name));
    }
}