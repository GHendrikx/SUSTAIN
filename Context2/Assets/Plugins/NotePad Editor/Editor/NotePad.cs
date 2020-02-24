using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Notepad
{
    public class NotePad : EditorWindow
    {
        private static NotePad window;
        private string note;
        private SaveNote saveNote;
        private Allignment allignment = Allignment.left;
        private string allignmentButtonText;
        private Dictionary<string,Allignment> Notes = new Dictionary<string, Allignment>();

        [MenuItem("Window/Notepad #n")]
        static void Init()
        {
            window = GetWindow<NotePad>();
            window.saveNote = (SaveNote)AssetDatabase.LoadAssetAtPath("Assets/SaveNote.asset", typeof(SaveNote));

            if (window.saveNote != null)
                window.note = window.saveNote.note;

            else
            {
                window.saveNote = window.saveNote = ScriptableObject.CreateInstance(typeof(SaveNote)) as SaveNote;
                AssetDatabase.CreateAsset(window.saveNote, "Assets/SaveNote.asset");
            }

            GUIContent icon = EditorGUIUtility.IconContent("unityLogo");
            window.Show();
            window.titleContent = new GUIContent("Notepad");
        }
        private void OnGUI()
        {
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("N", GUILayout.Width(20)))
                note = string.Empty;
            if (GUILayout.Button("S", GUILayout.Width(20)))
                saveNote.note = note;
            switch (allignment)
            {
                case Allignment.left:
                    allignmentButtonText = "<";
                    break;
                case Allignment.centered:
                    allignmentButtonText = "|";
                    break;
                case Allignment.right:
                    allignmentButtonText = ">";
                    break;
                default:
                    break;
            }

            if (GUILayout.Button(allignmentButtonText, GUILayout.Width(20))) 
            {
                if ((int)allignment == 2)
                    allignment = 0;
                else
                    allignment += 1;
            }

            GUIStyle GUIAlligment = new GUIStyle();
            switch (allignment)
            {
                case Allignment.left:
                    GUIAlligment.alignment = TextAnchor.UpperLeft;
                    break;
                case Allignment.centered:
                    GUIAlligment.alignment = TextAnchor.UpperCenter;
                    break;
                case Allignment.right:
                    GUIAlligment.alignment = TextAnchor.UpperRight;
                    break;
                default:
                    break;
            }
            note = GUI.TextArea(new Rect(0, 40, Screen.width, Screen.height), note, GUIAlligment);
            GUILayout.EndHorizontal();
        }

        private void OnDisable() =>
            AssetDatabase.Refresh();
    }
        public enum Allignment
        {
            left,
            centered,
            right
        }
}