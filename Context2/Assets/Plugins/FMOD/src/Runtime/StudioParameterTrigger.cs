﻿using System;
using UnityEngine;

namespace FMODUnity
{
    [Serializable]
    public class EmitterRef
    {
        public StudioEventEmitter Target;
        public ParamRef[] Params;
    }

    [AddComponentMenu("FMOD Studio/FMOD Studio Parameter Trigger")]
    public class StudioParameterTrigger: EventHandler
    {
        public EmitterRef[] Emitters;
        public EmitterGameEvent TriggerEvent;

        void Awake()
        {
            for (int i = 0; i < Emitters.Length; i++)
            {
                var emitterRef = Emitters[i];
                if (emitterRef.Target != null && !string.IsNullOrEmpty(emitterRef.Target.Event))
                {
                    FMOD.Studio.EventDescription eventDesc = FMODUnity.RuntimeManager.GetEventDescription(emitterRef.Target.Event);
                    if (eventDesc.isValid())
                    {
                        for (int j = 0; j < Emitters[i].Params.Length; j++)
                        {
                            FMOD.Studio.PARAMETER_DESCRIPTION param;
                            eventDesc.getParameterDescriptionByName(emitterRef.Params[j].Name, out param);
                            emitterRef.Params[j].ID = param.id;
                        }
                    }
                }
            }
        }
        protected override void HandleGameEvent(EmitterGameEvent gameEvent)
        {
            if (TriggerEvent == gameEvent)
            {
                TriggerParameters();
            }
        }

        public void TriggerParameters()
        {

            for (int i = 0; i < Emitters.Length; i++)
            {
                var emitterRef = Emitters[i];
                if (emitterRef.Target != null && emitterRef.Target.EventInstance.isValid())
                {
                    for (int j = 0; j < Emitters[i].Params.Length; j++)
                    {
                        emitterRef.Target.EventInstance.setParameterByID(Emitters[i].Params[j].ID, Emitters[i].Params[j].Value);
                    }
                }
            }
        }

        public void TriggerParameters(AudioParameters parameter, float value)
        {
            Debug.Log(Emitters.Length);
            for (int i = 0; i < Emitters.Length; i++)
            {
                var emitterRef = Emitters[i];
                if (emitterRef.Target != null && emitterRef.Target.EventInstance.isValid())
                    for (int j = 0; j < Emitters[i].Params.Length; j++)
                    {
                        Debug.Log(Emitters[i].Params[j].Name == parameter.ToString() + " " + Emitters[i].Params[j].Value);

                        if (Emitters[i].Params[j].Name == parameter.ToString())
                        {
                            Emitters[i].Params[j].Value = value;
                            emitterRef.Target.EventInstance.setParameterByID(Emitters[i].Params[(int)parameter].ID, Emitters[i].Params[j].Value);
                        }
                    }
            }
        }
    }

    public enum AudioParameters
    {
        Performance,
        GameClear,
        Corruption,
        Progression,
        AllocationHeight
    }
}