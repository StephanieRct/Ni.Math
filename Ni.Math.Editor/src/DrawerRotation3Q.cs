using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Ni.Mathematics.Editor
{
    [CustomPropertyDrawer(typeof(Rotation3Q))]
    public class DrawerRotation3Q : NiMathDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            OnGUISubPropertyField(property, "rotation");
        }

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            return BuildDefault(property, new Gizmo());
        }

        protected override void AddProperties(SerializedProperty property, VisualElement root)
        {
            root.Add(CreateNormalizedSubQuaternionField(property, "rotation"));
        }

        public class Gizmo : NiMathEditorGUI.IGizmo
        {
            public void RenderLocal(SceneView sceneView, SerializedProperty property, Transform transform)
            {
                var o = PropertySerialization.PropertyToRotationQTransform3(property);
                NiMathHandles.Draw(o, transform);
            }

            public void RenderWorld(SceneView sceneView, SerializedProperty property)
            {
                var o = PropertySerialization.PropertyToRotationQTransform3(property);
                NiMathHandles.Draw(o);
            }
        }
    }
    public partial class NiMathHandles
    {
        public static void Draw(Rotation3Q o)
        {
            var x = o.Transform(new float3(1, 0, 0));
            var y = o.Transform(new float3(0, 1, 0));
            var z = o.Transform(new float3(0, 0, 1));
            Handles.color = Color.red;
            Handles.DrawLine(float3.zero, x);
            Handles.color = Color.green;
            Handles.DrawLine(float3.zero, y);
            Handles.color = Color.blue;
            Handles.DrawLine(float3.zero, z);
        }
        public static void Draw(Rotation3Q o, Transform transform)
        {
            var x = transform.TransformPoint(o.Transform(new float3(1, 0, 0)));
            var y = transform.TransformPoint(o.Transform(new float3(0, 1, 0)));
            var z = transform.TransformPoint(o.Transform(new float3(0, 0, 1)));
            Handles.color = Color.red;
            Handles.DrawLine(transform.position, x);
            Handles.color = Color.green;
            Handles.DrawLine(transform.position, y);
            Handles.color = Color.blue;
            Handles.DrawLine(transform.position, z);
        }
    }
}