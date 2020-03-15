using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSibling : MonoBehaviour
{
    [SerializeField]
    private Transform UI;
    [SerializeField]
    private Transform myTransform;
    // Update is called once per frame
    private void Update()
    {
        //if the background isn't the first sibling it will be changed
        if (myTransform.GetSiblingIndex() != 0)
            myTransform.SetAsFirstSibling();
    }
}
