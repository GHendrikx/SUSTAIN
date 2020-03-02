using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class GenerateAudioEnum : MonoBehaviour
{
#if UNITY_EDITOR
    // Generate the audio clips in Unity
    [ContextMenu("Generate Enum")]
    private void Generate()
    {
        AudioClip[] audioClips = Resources.LoadAll<AudioClip>("SFX\\");
        AudioClip[] backgroundClips = Resources.LoadAll<AudioClip>("Background-Audio\\");
        Debug.Log(audioClips[0].name);

        using (StreamWriter sw = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory() + "\\Assets\\Scripts\\AudioEnum.cs")))
        {
            sw.WriteLine("/// <summary>");
            sw.WriteLine("/// this enum is automaticly generated.");
            sw.WriteLine("/// Made by Geoffrey Hendrikx.");
            sw.WriteLine("/// </summary>");
            if (audioClips.Length > 0)
            {
                sw.WriteLine("public enum SFXFragments");
                sw.WriteLine("{");

                for (int i = 0; i < audioClips.Length; i++)
                {
                    //The first one is always none.
                    if (i == 0 && audioClips.Length > 0)
                        sw.WriteLine("\tnone = " + i + ",");

                    // (i + 1) because the 0 is always none
                    sw.WriteLine("\t" + audioClips[i].name + " = " + (i + 1) + ",");

                }
                sw.WriteLine("}\n");
            }
            if (backgroundClips.Length > 0)
            {

                sw.WriteLine("public enum BackgroundFragments");
                sw.WriteLine("{");

                for (int i = 0; i < backgroundClips.Length; i++)
                {
                    //The first one is always none.
                    if (i == 0 && audioClips.Length > 0)
                        sw.WriteLine("\tnone = " + i + ",");

                    // (i + 1) because the 0 is always none
                    sw.WriteLine("\t" + backgroundClips[i].name + " = " + (i + 1) + ",");

                }
                sw.WriteLine("}");
            }
            sw.Flush();
            sw.Close();
        }
        AssetDatabase.Refresh();
    }
#endif // UNITY_EDITOR
}
