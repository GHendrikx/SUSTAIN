using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SetParameters : MonoBehaviour
{
    [SerializeField]
    private StudioParameterTrigger studioParameterTrigger;
    private StudioEventEmitter eventEmitter;
    // Start is called before the first frame update
    void Start()
    {
        studioParameterTrigger.TriggerParameters(AudioParameters.Progression, 5);
        eventEmitter.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
