using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace ZZBase.Lession09
{
    [CustomPropertyDrawer(typeof(PathToObject))]
    public sealed class PathToObjectDrawer : PropertyDrawer
    {
        public string PathToObject(GameObject gameObject)
        {
            if (gameObject == null) return "";
            if (gameObject.transform.parent == null)
            {
                return gameObject.name;
            }
            else
            {
                return PathToObject(gameObject.transform.parent.gameObject) + "/" + gameObject.name;
            }
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            MonoBehaviour monoBehaviour = (MonoBehaviour)property.serializedObject.targetObject;
            GameObject gameObject = monoBehaviour?.gameObject;
            EditorGUI.LabelField(position, label.text, PathToObject(gameObject));
            //EditorGUI.PropertyField(position, property, label);
        }
    }
}
