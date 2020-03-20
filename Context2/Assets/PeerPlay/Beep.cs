using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beep : MonoBehaviour
{
    public AudioPeer audioPeer;
    [Range(0, 7)] private int audioBand = 7;
    public Animator animator;
    public bool Test;

    private void Start()
    {
        StartCoroutine(MuteMic());
    }

    // Update is called once per frame
    void Update()
    {
        if (audioPeer._audioBand[audioBand] > 0.01f)
        {
            animator.Play(0);
            Test = true;
        }
        else
            Test = false;
        
    }

    private IEnumerator MuteMic()
    {
        yield return new WaitForSeconds(0.001f);
        audioPeer._useMicrophone = true;
    }
}
