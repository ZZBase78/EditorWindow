using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ZZBase.Lession09
{
    [CustomEditor(typeof(Rotator))]
    public sealed class ScriptExtend : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            Rotator rotator = (Rotator)target;

            rotator.speed = EditorGUILayout.IntSlider((int)rotator.speed, 1, 50);

            bool buttonResetMaterial = GUILayout.Button("������������� ���������");
            if (buttonResetMaterial) rotator.ResetMaterial();

            bool button = GUILayout.Button("�������� ����");
            if (button) rotator.ChangeColor();

        }
    }
}
