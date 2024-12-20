using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Ni.Mathematics.Editor
{
    [CustomPropertyDrawer(typeof(NonUniformTransform3))]
    public class DrawerNonUniformTransform3 : NiMathDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            OnGUISubPropertyField(property, "translation");
            OnGUISubPropertyField(property, "rotation");
            OnGUISubPropertyField(property, "scale");
        }

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            return BuildDefault(property, new Gizmo());
        }

        protected override void AddProperties(SerializedProperty property, VisualElement root)
        {
            root.Add(CreateSubPropertyField(property, "translation"));
            root.Add(CreateNormalizedSubQuaternionField(property, "rotation"));
            root.Add(CreateSubPropertyField(property, "scale"));
        }

        public class Gizmo : NiMathEditorGUI.IGizmo
        {
            public void RenderLocal(SceneView sceneView, SerializedProperty property, Transform transform)
            {
                var o = PropertySerialization.PropertyToNonUniformTransform3(property);
                NiMathHandles.Draw(o, transform);
            }

            public void RenderWorld(SceneView sceneView, SerializedProperty property)
            {
                var o = PropertySerialization.PropertyToNonUniformTransform3(property);
                NiMathHandles.Draw(o);
            }
        }
    }
    public partial class NiMathHandles
    {
        public static void Draw(NonUniformTransform3 o)
        {
            var center = o.Transform(new float3(0, 0, 0));
            var x = o.Transform(new float3(1, 0, 0));
            var y = o.Transform(new float3(0, 1, 0));
            var z = o.Transform(new float3(0, 0, 1));
            Handles.color = Color.red;
            Handles.DrawLine(center, x);
            Handles.color = Color.green;
            Handles.DrawLine(center, y);
            Handles.color = Color.blue;
            Handles.DrawLine(center, z);
            Handles.color = Color.white;
            Handles.DrawLine(x, y);
            Handles.DrawLine(x, z);
            Handles.DrawLine(y, z);
        }
        public static void Draw(NonUniformTransform3 o, Transform transform)
        {
            var center = transform.TransformPoint(o.Transform(new float3(0, 0, 0)));
            var x = transform.TransformPoint(o.Transform(new float3(1, 0, 0)));
            var y = transform.TransformPoint(o.Transform(new float3(0, 1, 0)));
            var z = transform.TransformPoint(o.Transform(new float3(0, 0, 1)));
            Handles.color = Color.red;
            Handles.DrawLine(center, x);
            Handles.color = Color.green;
            Handles.DrawLine(center, y);
            Handles.color = Color.blue;
            Handles.DrawLine(center, z);
        }
    }
    public partial class NiMathGizmos
    {
        public static void Draw(NonUniformTransform3 o)
        {
            var center = o.Transform(new float3(0, 0, 0));
            var x = o.Transform(new float3(1, 0, 0));
            var y = o.Transform(new float3(0, 1, 0));
            var z = o.Transform(new float3(0, 0, 1));
            Gizmos.color = Color.red;
            Gizmos.DrawLine(center, x);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(center, y);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(center, z);
            Gizmos.color = Color.white;
            Gizmos.DrawLine(x, y);
            Gizmos.DrawLine(x, z);
            Gizmos.DrawLine(y, z);
        }
        public static void Draw(NonUniformTransform3 o, Transform transform)
        {
            var center = transform.TransformPoint(o.Transform(new float3(0, 0, 0)));
            var x = transform.TransformPoint(o.Transform(new float3(1, 0, 0)));
            var y = transform.TransformPoint(o.Transform(new float3(0, 1, 0)));
            var z = transform.TransformPoint(o.Transform(new float3(0, 0, 1)));
            Gizmos.color = Color.red;
            Gizmos.DrawLine(center, x);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(center, y);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(center, z);
        }
    }
}