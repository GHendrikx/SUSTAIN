using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
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
    private GameObject[] Sounds;

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

    public void StopSound()
    {
        for (int i = 0; i < Sounds.Length; i++)
            Sounds[i].SetActive(false);
    }

    public void ToggleGameObject(GameObject go)
    {
        go.SetActive(false);
        go.SetActive(true);
    }
}
