using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace Context
{
    [System.Serializable]
    public struct InputData
    {
        public Data[] Data;
    }

    public class IOManager : Singleton<IOManager>
    {
        public InputData data;
        public TextAsset textAsset;

        private void Awake()
        {
            data.Data = null;

            if (textAsset != null)
                data = JsonUtility.FromJson<InputData>(textAsset.ToString());
            else
                Debug.LogError("NO DATA GREAT AGAIN");
            
        }
    }
}