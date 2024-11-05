using Unity.Mathematics;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Ni.Mathematics.Editor
{

    public class NiMathDrawer : PropertyDrawer
    {
        protected void OnGUISubPropertyField(SerializedProperty property, string name)
        {
            var prop = property.FindPropertyRelative(name);
            if (prop == null)
                throw new System.InvalidOperationException($"Could not find property named '{name}' under property at path '{property.propertyPath}'");
            EditorGUILayout.PropertyField(prop);
        }

        protected SerializedProperty Sub(SerializedProperty property, string name)
        {
            var sub = property.FindPropertyRelative(name);
            if (sub == null)
                Debug.LogError($"Could not find property named '{name}' under '{property.propertyPath}'");
            return sub;
        }
        protected PropertyField CreatePropertyField(SerializedProperty property)
        {
            var propField = new PropertyField();
            propField.BindProperty(property);
            return propField;
        }
        protected PropertyField CreateSubPropertyField(SerializedProperty property, string name)
        {
            var prop = property.FindPropertyRelative(name);
            if (prop == null)
                throw new System.InvalidOperationException($"Could not find property named '{name}' under property at path '{property.propertyPath}'");
            var propField = new PropertyField();
            propField.BindProperty(prop);
            return propField;
        }
        protected VisualElement BuildName(SerializedProperty property) => new Label(property.displayName);

        protected VisualElement BuildGizmoButtons(SerializedProperty property, NiMathEditorGUI.IGizmo gizmo) => new NiMathEditorGUI.ShowButtonsVE(property, gizmo);

        protected VisualElement BuildPrefix(SerializedProperty property, NiMathEditorGUI.IGizmo gizmo)
        {
            if (gizmo == null)
                return BuildName(property);
            var vePrefix = new VisualElement();
            vePrefix.Add(BuildName(property));
            var showButtons = BuildGizmoButtons(property, gizmo);
            vePrefix.Add(showButtons);
            return vePrefix;
        }
        protected VisualElement BuildDefault(SerializedProperty property, NiMathEditorGUI.IGizmo gizmo)
        {
            var veRoot = new VisualElement();
            veRoot.style.flexDirection = FlexDirection.Row;

            var veOptions = BuildPrefix(property, gizmo);
            veRoot.Add(veOptions);

            var propertyContainer = BuildPropertiesContainer();
            AddProperties(property, propertyContainer);
            veRoot.Add(propertyContainer);
            return veRoot;
        }

        VisualElement BuildPropertiesContainer()
        {
            var veProps = new VisualElement();
            veProps.style.flexGrow = 1;
            return veProps;
        }

        protected virtual void AddProperties(SerializedProperty property, VisualElement root)
        {

        }

        public PropertyField CreateNormalizedQuaternionField(SerializedProperty property)
        {
            var propField = CreatePropertyField(property); 
            propField.RegisterValueChangeCallback(new EventCallback<SerializedPropertyChangeEvent>(x =>
            {
                PropertySerialization.SetQuaternion(x.changedProperty, math.normalize(PropertySerialization.PropertyQuaternion(x.changedProperty)));
                x.changedProperty.serializedObject.ApplyModifiedProperties();
            }));
            return propField;
        }
        public PropertyField CreateNormalizedSubQuaternionField(SerializedProperty property, string name) => CreateNormalizedQuaternionField(Sub(property, name));
    }
}