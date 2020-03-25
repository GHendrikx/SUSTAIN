using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField]
    private GameObject backgroundMusic;
    public GameObject BackgroundMusic
    {
        get
        {
            return backgroundMusic;
        }
        set
        {
            backgroundMusic = value;
        }
    }

    [SerializeField]
    private GameObject tabSound;
    public GameObject TabSound
    {
        get
        {
            return tabSound;
        }
        set
        {
            tabSound = value;
        }
    }

    [SerializeField]
    private GameObject researchObject;
    public GameObject ResearchObject
    {
        get
        {
            return researchObject;
        }
        set
        {
            researchObject = value;
        }
    }

    [SerializeField]
    private GameObject policyAccept;
    public GameObject PolicyAccept
    {
        get
        {
            return policyAccept;
        }
        set
        {
            policyAccept = value;
        }
    }

    [SerializeField]
    private GameObject policyDecline;
    public GameObject PolicyDecline
    {
        get
        {
            return policyDecline;
        }
        set
        {
            policyDecline = value;
        }
    }

    [SerializeField]
    private GameObject lose;
    public GameObject Lose
    {
        get
        {
            return lose;
        }
        set
        {
            lose = value;
        }
    }

    [SerializeField]
    private GameObject spawnBubble;
    public GameObject SpawnBubble
    {
        get
        {
            return spawnBubble;
        }
        set
        {
            spawnBubble = value;
        }
    }

    [SerializeField]
    private GameObject destroyBubble;
    public GameObject DestroyBubble
    {
        get
        {
            return destroyBubble;
        }
        set
        {
            destroyBubble = value;
        }
    }


    [SerializeField]
    private GameObject allocatieReward;
    public GameObject AllocatieReward
    {
        get
        {
            return allocatieReward;
        }
        set
        {
            allocatieReward = value;
        }
    }
    [SerializeField]
    private GameObject allocatieError;
    public GameObject AllocatieError
    {
        get
        {
            return allocatieError;
        }
        set
        {
            allocatieError = value;
        }
    }
    [SerializeField]
    private GameObject addBuilding;
    public GameObject AddBuilding
    {
        get
        {
            return addBuilding;
        }
        set
        {
            addBuilding = value;
        }
    }

    [SerializeField]
    private GameObject nextWeek;
    public GameObject NextWeek
    {
        get
        {
            return nextWeek;
        }
        set
        {
            nextWeek = value;
        }
    }

    [SerializeField]
    private GameObject[] Sounds;

    public void StopSound()
    {
        for (int i = 0; i < Sounds.Length; i++)
            Sounds[i].SetActive(false);
    }

    public void ToggleGameObject(GameObject go, bool toggle = true)
    {
        go.SetActive(false);
        go.SetActive(true);
    }

    public void SetParameters(float performance, int gameClear, int corrupion, int progression, StudioParameterTrigger sp)
    {
        if (performance != -999)
            sp.TriggerParameters(AudioParameters.Performance, performance);
        if (gameClear != -999)
            sp.TriggerParameters(AudioParameters.GameClear, gameClear);
        if (corrupion != -999)
            sp.TriggerParameters(AudioParameters.Corruption, corrupion);
        if (progression != -999)
            sp.TriggerParameters(AudioParameters.Progression, progression);
    }
}
