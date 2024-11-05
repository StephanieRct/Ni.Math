using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Ni.Mathematics.Editor
{
    [CustomPropertyDrawer(typeof(Translation3))]
    public class DrawerTranslation3 : NiMathDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            OnGUISubPropertyField(property, "translation");
        }

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            return BuildDefault(property, new Gizmo());
        }

        protected override void AddProperties(SerializedProperty property, VisualElement root)
        {
            root.Add(CreateSubPropertyField(property, "translation"));
        }

        public class Gizmo : NiMathEditorGUI.IGizmo
        {
            public void RenderLocal(SceneView sceneView, SerializedProperty property, Transform transform)
            {
                var o = PropertySerialization.PropertyToTranslationTransform3(property);
                NiMathHandles.Draw(o, transform);
            }

            public void RenderWorld(SceneView sceneView, SerializedProperty property)
            {
                var o = PropertySerialization.PropertyToTranslationTransform3(property);
                NiMathHandles.Draw(o);
            }
        }
    }
    public partial class NiMathHandles
    {
        public static void Draw(Translation3 o)
        {
            Handles.DrawLine(float3.zero, o.translation);
        }
        public static void Draw(Translation3 o, Transform transform)
        {
            Handles.DrawLine(transform.position, transform.TransformPoint(o.translation));
        }
    }
}