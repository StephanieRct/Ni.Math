using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Ni.Mathematics.Editor
{

    [InitializeOnLoad]
    public static class NiMathEditorGUI
    {
        public enum GizmoState
        {
            Hidden,
            ShowWorld,
            ShowLocal,
        }
        public interface IGizmo
        {
            void RenderWorld(SceneView sceneView, SerializedProperty property);
            void RenderLocal(SceneView sceneView, SerializedProperty property, Transform transform);
        }
        public struct ObjectPropertyRef
        {
            public Object Object;
            public string PropertyName;
            public ObjectPropertyRef(Object obj, string propertyName)
            {
                Object = obj;
                PropertyName = propertyName;
            }
            public ObjectPropertyRef(SerializedProperty property)
            {
                Object = property.serializedObject.targetObject;
                PropertyName = property.propertyPath;
            }
        }

        public class GizmoProperty
        {
            public IGizmo Gizmo;
            public SerializedProperty Property;
            public GizmoState State;
            public GizmoProperty(IGizmo gizmo, SerializedProperty property, GizmoState state)
            {
                Gizmo = gizmo;
                Property = property;
                State = state;
            }

            public bool UpdateProperty(ObjectPropertyRef objectProperty)
            {
                try
                {
                    var name = Property.name;
                }
                catch (System.Exception)
                {
                    var serializedObject = new SerializedObject(objectProperty.Object);
                    Property = serializedObject.FindProperty(objectProperty.PropertyName);
                    if (Property == null)
                        return false;
                }
                return true;
            }
        }
        public delegate void RenderGizmo(SceneView sceneView, SerializedProperty property);
        public static Dictionary<ObjectPropertyRef, GizmoProperty> Gizmos = new();
        //public interface IGizmo
        //{
        //    void Render(SceneView sceneView);
        //}
        static NiMathEditorGUI()
        {
            SceneView.duringSceneGui += DrawGizmo;
        }
        public static void DrawGizmo(SceneView sceneView)
        {
            //Handles
            //SceneView.duringSceneGui
            var gismos = Gizmos.Keys;
            List<ObjectPropertyRef> toRemove = null;
            foreach (var (objectProperty, gizmoProperty) in Gizmos)
            {
                if (!gizmoProperty.UpdateProperty(objectProperty))
                {
                    if (toRemove == null) toRemove = new List<ObjectPropertyRef>();
                    toRemove.Add(objectProperty);
                }
                else
                {
                    switch (gizmoProperty.State)
                    {
                        case GizmoState.ShowWorld:
                            gizmoProperty.Gizmo.RenderWorld(sceneView, gizmoProperty.Property);
                            break;
                        case GizmoState.ShowLocal:
                            var transform = (gizmoProperty.Property.serializedObject.targetObject as Component).transform;
                            gizmoProperty.Gizmo.RenderLocal(sceneView, gizmoProperty.Property, transform);
                            break;
                    }
                }
            }
            if (toRemove != null)
            {
                foreach (var g in toRemove)
                    Gizmos.Remove(g);
            }
        }
        public static void AddGizmo(SerializedProperty property, IGizmo gizmo, GizmoState state)
        {
            Gizmos.Add(new ObjectPropertyRef(property), new GizmoProperty(gizmo, property, state));
        }
        public static bool RemoveGizmo(SerializedProperty property)
        {
            return Gizmos.Remove(new ObjectPropertyRef(property));
        }

        public static bool HasGizmo(SerializedProperty property)
        {
            return Gizmos.ContainsKey(new ObjectPropertyRef(property));
        }

        public static GizmoState GetGizmoState(SerializedProperty property)
        {
            if (Gizmos.TryGetValue(new ObjectPropertyRef(property), out var gizmoProperty))
            {
                return gizmoProperty.State;
            }
            return GizmoState.Hidden;
        }
        public static void SetGizmoState(SerializedProperty property, GizmoState state)
        {
            if (state == GizmoState.Hidden)
            {
                Gizmos.Remove(new ObjectPropertyRef(property));
            }
            else if (Gizmos.TryGetValue(new ObjectPropertyRef(property), out var gizmoProperty))
            {
                gizmoProperty.State = state;
            }
            else
                throw new System.InvalidOperationException($"Cannot set gizmo state '{state}' on property '{property.propertyPath}'. No gizmo was created for the property");
        }


        public class ShowButtonsVE : VisualElement
        {
            public SerializedProperty Property;
            public Button BtShowWorld;
            public Button BtShowLocal;
            public IGizmo Gizmo;
            public ShowButtonsVE(SerializedProperty property, IGizmo gizmo)
            {
                Property = property;
                Gizmo = gizmo;

                style.flexDirection = FlexDirection.Row;

                BtShowWorld = new Button();
                Add(BtShowWorld);

                BtShowLocal = new Button();
                Add(BtShowLocal);

                BtShowWorld.clicked += ToggleShowWorld;
                BtShowLocal.clicked += ToggleShowLocal;

                UpdateShowButton();
            }


            void ToggleShowWorld()
            {
                var state = NiMathEditorGUI.GetGizmoState(Property);
                switch (state)
                {
                    case GizmoState.Hidden:
                        NiMathEditorGUI.AddGizmo(Property, Gizmo, GizmoState.ShowWorld);
                        break;
                    case GizmoState.ShowLocal:
                        NiMathEditorGUI.SetGizmoState(Property, GizmoState.ShowWorld);
                        break;
                    case GizmoState.ShowWorld:
                        NiMathEditorGUI.RemoveGizmo(Property);
                        break;
                }
                SceneView.RepaintAll();
                UpdateShowButton();
            }

            void ToggleShowLocal()
            {
                var state = NiMathEditorGUI.GetGizmoState(Property);
                switch (state)
                {
                    case GizmoState.Hidden:
                        NiMathEditorGUI.AddGizmo(Property, Gizmo, GizmoState.ShowLocal);
                        break;
                    case GizmoState.ShowLocal:
                        NiMathEditorGUI.RemoveGizmo(Property);
                        break;
                    case GizmoState.ShowWorld:
                        NiMathEditorGUI.SetGizmoState(Property, GizmoState.ShowLocal);
                        break;
                }
                SceneView.RepaintAll();
                UpdateShowButton();
            }

            void UpdateShowButton()
            {
                var state = NiMathEditorGUI.GetGizmoState(Property);
                switch (state)
                {
                    case GizmoState.Hidden:
                        BtShowWorld.text = "W";
                        BtShowLocal.text = "L";
                        break;
                    case GizmoState.ShowWorld:
                        BtShowWorld.text = "X";
                        BtShowLocal.text = "L";
                        break;
                    case GizmoState.ShowLocal:
                        BtShowWorld.text = "W";
                        BtShowLocal.text = "X";
                        break;
                }
            }
        }
        public static void Float2Field(Rect position, SerializedProperty property, GUIContent label, SerializedProperty propertyA, string labelFloatA, SerializedProperty propertyB, string labelFloatB, float labelAWidth = 24, float labelBWidth = 24)
        {
            EditorGUI.BeginProperty(position, label, property);
            var rectContent = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            EditorGUI.EndProperty();

            var rectA = rectContent;
            var rectB = rectContent;
            rectA.xMax -= rectContent.width * 0.5f;
            rectB.xMin += rectContent.width * 0.5f;
            var offset = 16 * Mathf.Max(property.depth - 1, 0);
            rectA.xMin -= offset;
            rectA.xMax -= 2;
            rectB.xMin -= offset;

            var w = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = labelAWidth + offset;

            var labelA = new GUIContent(labelFloatA);
            var newA = EditorGUI.FloatField(rectA, labelA, propertyA.floatValue);
            if (newA != propertyA.floatValue)
            {
                propertyA.floatValue = newA;
                propertyA.serializedObject.ApplyModifiedProperties();
            }
            //EditorGUI.EndProperty();

            EditorGUIUtility.labelWidth = labelBWidth + offset;
            var labelB = new GUIContent(labelFloatB);
            var newB = EditorGUI.FloatField(rectB, labelB, propertyB.floatValue);
            if (newB != propertyB.floatValue)
            {
                propertyB.floatValue = newB;
                propertyB.serializedObject.ApplyModifiedProperties();
            }

            EditorGUIUtility.labelWidth = w;
        }
        public static void Float3Field(Rect position, SerializedProperty property, GUIContent label,
            SerializedProperty propertyA, string labelFloatA,
            SerializedProperty propertyB, string labelFloatB,
            SerializedProperty propertyC, string labelFloatC,
            float labelAWidth = 24, float labelBWidth = 24, float labelCWidth = 24)
        {
            EditorGUI.BeginProperty(position, label, property);
            var rectContent = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            EditorGUI.EndProperty();

            var rectA = rectContent;
            var rectB = rectContent;
            var rectC = rectContent;
            var x1 = rectContent.width * 0.333333333f + rectContent.xMin;
            var x2 = rectContent.width * 0.666666666f + rectContent.xMin;
            rectA.xMax = x1;
            rectB.xMin = x1;
            rectB.xMax = x2;
            rectC.xMin = x2;


            var offset = 16 * Mathf.Max(property.depth - 1, 0);
            rectA.xMin -= offset;
            rectB.xMin -= offset;
            rectC.xMin -= offset;

            //rectA.xMin -= 16;
            //rectA.xMax -= 2;
            //rectB.xMin -= 16;

            var w = EditorGUIUtility.labelWidth;

            EditorGUIUtility.labelWidth = labelAWidth + offset;
            var labelA = new GUIContent(labelFloatA);
            var newA = EditorGUI.FloatField(rectA, labelA, propertyA.floatValue);
            if (newA != propertyA.floatValue)
            {
                propertyA.floatValue = newA;
                propertyA.serializedObject.ApplyModifiedProperties();
            }

            EditorGUIUtility.labelWidth = labelBWidth + offset;
            var labelB = new GUIContent(labelFloatB);
            var newB = EditorGUI.FloatField(rectB, labelB, propertyB.floatValue);
            if (newB != propertyB.floatValue)
            {
                propertyB.floatValue = newB;
                propertyB.serializedObject.ApplyModifiedProperties();
            }

            EditorGUIUtility.labelWidth = labelCWidth + offset;
            var labelC = new GUIContent(labelFloatC);
            var newC = EditorGUI.FloatField(rectC, labelC, propertyC.floatValue);
            if (newC != propertyC.floatValue)
            {
                propertyC.floatValue = newC;
                propertyC.serializedObject.ApplyModifiedProperties();
            }

            EditorGUIUtility.labelWidth = w;
        }


        //public static void Float3Field(Rect position, SerializedProperty property, GUIContent label,
        //    SerializedProperty propertyFloat3)
        //{
        //    EditorGUI.BeginProperty(position, label, property);
        //    var rectContent = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        //    EditorGUI.EndProperty();

        //    var rectA = rectContent;
        //    var rectB = rectContent;
        //    var rectC = rectContent;
        //    var x1 = rectContent.width * 0.333333333f + rectContent.xMin;
        //    var x2 = rectContent.width * 0.666666666f + rectContent.xMin;
        //    rectA.xMax = x1;
        //    rectB.xMin = x1;
        //    rectB.xMax = x2;
        //    rectC.xMin = x2;


        //    var offset = 16 * Mathf.Max(property.depth - 1, 0);
        //    rectA.xMin -= offset;
        //    rectB.xMin -= offset;
        //    rectC.xMin -= offset;

        //    //rectA.xMin -= 16;
        //    //rectA.xMax -= 2;
        //    //rectB.xMin -= 16;

        //    var w = EditorGUIUtility.labelWidth;

        //    EditorGUIUtility.labelWidth = labelAWidth + offset;
        //    var labelA = new GUIContent(labelFloatA);
        //    var newA = EditorGUI.FloatField(rectA, labelA, propertyA.floatValue);
        //    if (newA != propertyA.floatValue)
        //    {
        //        propertyA.floatValue = newA;
        //        propertyA.serializedObject.ApplyModifiedProperties();
        //    }

        //    EditorGUIUtility.labelWidth = labelBWidth + offset;
        //    var labelB = new GUIContent(labelFloatB);
        //    var newB = EditorGUI.FloatField(rectB, labelB, propertyB.floatValue);
        //    if (newB != propertyB.floatValue)
        //    {
        //        propertyB.floatValue = newB;
        //        propertyB.serializedObject.ApplyModifiedProperties();
        //    }

        //    EditorGUIUtility.labelWidth = labelCWidth + offset;
        //    var labelC = new GUIContent(labelFloatC);
        //    var newC = EditorGUI.FloatField(rectC, labelC, propertyC.floatValue);
        //    if (newC != propertyC.floatValue)
        //    {
        //        propertyC.floatValue = newC;
        //        propertyC.serializedObject.ApplyModifiedProperties();
        //    }

        //    EditorGUIUtility.labelWidth = w;
        //}
    }
}