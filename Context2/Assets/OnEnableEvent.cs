using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class OnEnableEvent : MonoBehaviour
{
    public UnityEvent unityEvent;

    private void OnEnable() =>
        unityEvent.Invoke();

}
