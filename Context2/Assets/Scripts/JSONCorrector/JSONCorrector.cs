using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class JSONCorrector : MonoBehaviour
{
    [SerializeField]
    private TextAsset textAsset;

    #if UNITY_EDITOR
    [ContextMenu("Make Data Great Again")]
    private void ConvertData()
    {
        string text = textAsset.ToString();
        text = text.Replace("\\n", "");
        using (StreamWriter sr = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory() + "\\Assets\\Resources\\JsonData\\", "Gameplay.json")))
        {
            sr.Write("{");
            sr.Write("\"Data\":");
            sr.Write(text);
            sr.Write("}");

            sr.Flush();
            sr.Close();
        }

        File.Delete(Path.Combine(Directory.GetCurrentDirectory() + "\\Assets\\Resources\\JsonData\\", "Blad1.txt"));
        AssetDatabase.Refresh();
    }
    #endif
}
