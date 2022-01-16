using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace ZZBase.Lession09
{
    public sealed class MyWindow : EditorWindow
    {
        public static GameObject ObjectInstantiate;
        public string nameObject = "Name of Object";
        public bool groupEnabled;
        public bool randomColor = true;
        public int countObject = 1;
        public float radius = 10;
        public float upStep = 0.1f;

        private void OnGUI()
        {
            GUILayout.Label("Базовые настройки", EditorStyles.boldLabel);
            ObjectInstantiate = EditorGUILayout.ObjectField("Объект который хотим вставить", ObjectInstantiate, typeof(GameObject), true) as GameObject;
            nameObject = EditorGUILayout.TextField("Имя объекта", nameObject);

            groupEnabled = EditorGUILayout.BeginToggleGroup("Дополнительные настройки", groupEnabled);
            randomColor = EditorGUILayout.Toggle("Случайный цвет", randomColor);
            countObject = EditorGUILayout.IntSlider("Количество объектов", countObject, 1, 100);
            radius = EditorGUILayout.Slider("Радиус окружности", radius, 10, 50);
            upStep = EditorGUILayout.Slider("Изменение высоты", upStep, 0, 1);
            EditorGUILayout.EndToggleGroup();

            var button = GUILayout.Button("Создать объекты");
            if (button)
            {
                if (ObjectInstantiate)
                {
                    float upPosition = 0f;
                    GameObject root = new GameObject("Root");
                    for (int i = 0; i < countObject; i++)
                    {
                        float angle = i * Mathf.PI * 2 / countObject;
                        Vector3 pos = new Vector3(Mathf.Cos(angle), upPosition, Mathf.Sin(angle)) * radius;
                        upPosition += upStep;
                        GameObject temp = Instantiate(ObjectInstantiate, pos, Quaternion.identity);
                        SetObjectDirty(temp);
                        temp.name = nameObject + "(" + i + ")";
                        temp.transform.parent = root.transform;
                        if (randomColor)
                        {
                            Rotator rotator = temp.GetComponent<Rotator>();
                            rotator.ResetMaterial();
                            rotator.ChangeColor();
                        }
                    }
                }
            }
        }

        public void SetObjectDirty(GameObject obj)
        {
            if (!Application.isPlaying)
            {
                EditorUtility.SetDirty(obj);
                EditorSceneManager.MarkSceneDirty(obj.scene);
            }
        }

    }
}
