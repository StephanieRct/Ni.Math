using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Ni.Mathematics.Editor
{
    [CustomPropertyDrawer(typeof(Aabb3C))]
    public class DrawerAabb3C : NiMathDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            OnGUISubPropertyField(property, "center");
            OnGUISubPropertyField(property, "extent");
        }

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            return BuildDefault(property, new Gizmo());
        }

        protected override void AddProperties(SerializedProperty property, VisualElement root)
        {
            root.Add(CreateSubPropertyField(property, "center"));
            root.Add(CreateSubPropertyField(property, "extent"));
        }

        public class Gizmo : NiMathEditorGUI.IGizmo
        {
            public void RenderLocal(SceneView sceneView, SerializedProperty property, Transform transform)
            {
                var o = PropertySerialization.PropertyToAabb3C(property);
                NiMathHandles.Draw(o, transform);
            }

            public void RenderWorld(SceneView sceneView, SerializedProperty property)
            {
                var o = PropertySerialization.PropertyToAabb3C(property);
                NiMathHandles.Draw(o);
            }
        }
    }
    public partial class NiMathHandles
    {
        public static void Draw(Aabb3C o)
        {
            var translation = o.translation3;
            var scale = o.scale3;
            for(int i = 0; i < Cube3.IdentityEdgesArray.Length; i++)
                Handles.DrawLine(translation + scale * Cube3.IdentityEdgesArray[i].a, translation + scale * Cube3.IdentityEdgesArray[i].b);
        }
        public static void Draw(Aabb3C o, Transform transform)
        {
            var translation = o.translation3;
            var scale = o.scale3;
            
            for (int i = 0; i < Cube3.IdentityEdgesArray.Length; i++)
                Handles.DrawLine(transform.TransformPoint(translation + scale * Cube3.IdentityEdgesArray[i].a), transform.TransformPoint(translation + scale * Cube3.IdentityEdgesArray[i].b));
        }
    }
}