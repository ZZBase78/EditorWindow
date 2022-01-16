using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ZZBase.Lession09
{
    public sealed class MenuItems
    {
        [MenuItem("Test Menu Group/Test menu Item")]
        private static void MenuOption()
        {
            EditorWindow.GetWindow(typeof(MyWindow), false, "Test My Window");
        }
    }

}
