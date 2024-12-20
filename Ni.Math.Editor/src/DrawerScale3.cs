using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Ni.Mathematics.Editor
{
    [CustomPropertyDrawer(typeof(Scale3))]
    public class DrawerScale3 : NiMathDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            OnGUISubPropertyField(property, "scale");
        }

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            return BuildDefault(property, new Gizmo());
        }

        protected override void AddProperties(SerializedProperty property, VisualElement root)
        {
            root.Add(CreateSubPropertyField(property, "scale"));
        }

        public class Gizmo : NiMathEditorGUI.IGizmo
        {
            public void RenderLocal(SceneView sceneView, SerializedProperty property, Transform transform)
            {
                var o = PropertySerialization.PropertyToScaleNonUniformTransform3(property);
                NiMathHandles.Draw(o, transform);
            }

            public void RenderWorld(SceneView sceneView, SerializedProperty property)
            {
                var o = PropertySerialization.PropertyToScaleNonUniformTransform3(property);
                NiMathHandles.Draw(o);
            }
        }
    }
    public partial class NiMathHandles
    {
        public static void Draw(Scale3 o)
        {
            //var f = o.Transform(Aabb3M.Identity);
            var box = Aabb3M.Identity.Mul(o);

            var x0 = new float3(1, 0, 0);
            var y0 = new float3(0, 1, 0);
            var z0 = new float3(0, 0, 1);
            var one0 = new float3(1, 1, 1);
            Handles.color = new Color(1, 0, 0, 0.25f);
            Handles.DrawLine(float3.zero, x0);
            Handles.color = new Color(0, 1, 0, 0.25f);
            Handles.DrawLine(float3.zero, y0);
            Handles.color = new Color(0, 0, 1, 0.25f);
            Handles.DrawLine(float3.zero, z0);

            Handles.color = new Color(1, 1, 1, 0.5f);
            Handles.DrawLine(x0, y0);
            Handles.DrawLine(x0, z0);
            Handles.DrawLine(y0, z0);
            Handles.DrawLine(x0, one0);
            Handles.DrawLine(y0, one0);
            Handles.DrawLine(y0, one0);

            var x1 = o.Transform(new float3(1, 0, 0));
            var y1 = o.Transform(new float3(0, 1, 0));
            var z1 = o.Transform(new float3(0, 0, 1));
            var one1 = o.Transform(new float3(1, 1, 1));
            Handles.color = Color.red;
            Handles.DrawLine(float3.zero, x1);
            Handles.color = Color.green;
            Handles.DrawLine(float3.zero, y1);
            Handles.color = Color.blue;
            Handles.DrawLine(float3.zero, z1);
            Handles.color = Color.white;
            Handles.DrawLine(x1, y1);
            Handles.DrawLine(x1, z1);
            Handles.DrawLine(y1, z1);
            Handles.DrawLine(x0, one1);
            Handles.DrawLine(y0, one1);
            Handles.DrawLine(y0, one1);
        }
        public static void Draw(Scale3 o, Transform transform)
        {
            var x0 = transform.TransformPoint(new float3(1, 0, 0));
            var y0 = transform.TransformPoint(new float3(0, 1, 0));
            var z0 = transform.TransformPoint(new float3(0, 0, 1));
            Handles.color = new Color(1, 0, 0, 0.25f);
            Handles.DrawLine(transform.position, x0);
            Handles.color = new Color(0, 1, 0, 0.25f);
            Handles.DrawLine(transform.position, y0);
            Handles.color = new Color(0, 0, 1, 0.25f);
            Handles.DrawLine(transform.position, z0);

            Handles.color = new Color(1, 1, 1, 0.5f);
            Handles.DrawLine(x0, y0);
            Handles.DrawLine(x0, z0);
            Handles.DrawLine(y0, z0);

            var x1 = transform.TransformPoint(o.Transform(new float3(1, 0, 0)));
            var y1 = transform.TransformPoint(o.Transform(new float3(0, 1, 0)));
            var z1 = transform.TransformPoint(o.Transform(new float3(0, 0, 1)));
            Handles.color = Color.red;
            Handles.DrawLine(transform.position, x1);
            Handles.color = Color.green;
            Handles.DrawLine(transform.position, y1);
            Handles.color = Color.blue;
            Handles.DrawLine(transform.position, z1);
            Handles.color = Color.white;
            Handles.DrawLine(x1, y1);
            Handles.DrawLine(x1, z1);
            Handles.DrawLine(y1, z1);
        }
    }
    public partial class NiMathGizmos
    {
        public static void Draw(Scale3 o)
        {
            //var f = o.Transform(Aabb3M.Identity);
            var box = Aabb3M.Identity.Mul(o);

            var x0 = new float3(1, 0, 0);
            var y0 = new float3(0, 1, 0);
            var z0 = new float3(0, 0, 1);
            var one0 = new float3(1, 1, 1);
            Gizmos.color = new Color(1, 0, 0, 0.25f);
            Gizmos.DrawLine(float3.zero, x0);
            Gizmos.color = new Color(0, 1, 0, 0.25f);
            Gizmos.DrawLine(float3.zero, y0);
            Gizmos.color = new Color(0, 0, 1, 0.25f);
            Gizmos.DrawLine(float3.zero, z0);

            Gizmos.color = new Color(1, 1, 1, 0.5f);
            Gizmos.DrawLine(x0, y0);
            Gizmos.DrawLine(x0, z0);
            Gizmos.DrawLine(y0, z0);
            Gizmos.DrawLine(x0, one0);
            Gizmos.DrawLine(y0, one0);
            Gizmos.DrawLine(y0, one0);

            var x1 = o.Transform(new float3(1, 0, 0));
            var y1 = o.Transform(new float3(0, 1, 0));
            var z1 = o.Transform(new float3(0, 0, 1));
            var one1 = o.Transform(new float3(1, 1, 1));
            Gizmos.color = Color.red;
            Gizmos.DrawLine(float3.zero, x1);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(float3.zero, y1);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(float3.zero, z1);
            Gizmos.color = Color.white;
            Gizmos.DrawLine(x1, y1);
            Gizmos.DrawLine(x1, z1);
            Gizmos.DrawLine(y1, z1);
            Gizmos.DrawLine(x0, one1);
            Gizmos.DrawLine(y0, one1);
            Gizmos.DrawLine(y0, one1);
        }
        public static void Draw(Scale3 o, Transform transform)
        {
            var x0 = transform.TransformPoint(new float3(1, 0, 0));
            var y0 = transform.TransformPoint(new float3(0, 1, 0));
            var z0 = transform.TransformPoint(new float3(0, 0, 1));
            Gizmos.color = new Color(1, 0, 0, 0.25f);
            Gizmos.DrawLine(transform.position, x0);
            Gizmos.color = new Color(0, 1, 0, 0.25f);
            Gizmos.DrawLine(transform.position, y0);
            Gizmos.color = new Color(0, 0, 1, 0.25f);
            Gizmos.DrawLine(transform.position, z0);

            Gizmos.color = new Color(1, 1, 1, 0.5f);
            Gizmos.DrawLine(x0, y0);
            Gizmos.DrawLine(x0, z0);
            Gizmos.DrawLine(y0, z0);

            var x1 = transform.TransformPoint(o.Transform(new float3(1, 0, 0)));
            var y1 = transform.TransformPoint(o.Transform(new float3(0, 1, 0)));
            var z1 = transform.TransformPoint(o.Transform(new float3(0, 0, 1)));
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, x1);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, y1);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, z1);
            Gizmos.color = Color.white;
            Gizmos.DrawLine(x1, y1);
            Gizmos.DrawLine(x1, z1);
            Gizmos.DrawLine(y1, z1);
        }
    }
}