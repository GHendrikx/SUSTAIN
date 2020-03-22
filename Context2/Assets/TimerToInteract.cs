using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;
using UnityEngine.UI;

public class TimerToInteract : MonoBehaviour
{
    [SerializeField]
    private Button button;
    public static bool turnButtonTimer = false;
    public void StartTimer()
    {
        turnButtonTimer = false;
        TimerManager.Instance.AddTimer(() => EndTimer(), 2);
    }


    private void EndTimer()
    {
        Debug.Log("End");
        turnButtonTimer = true;
    }

}
