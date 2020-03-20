using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;
using UnityEngine.UI;

public class InteractableButton : MonoBehaviour
{
    [SerializeField]
    private Button button;
    private float time = 7;

    // Start
    public void Start()
    {
        button.interactable = false;
        TimerManager.Instance.AddTimer(SetInteractable, time);
    }

    // Update is called once per frame
    public void SetInteractable()
    {
        button.interactable = true;
    }
}
