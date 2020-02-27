using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabSystem : MonoBehaviour
{
    
    private GameObject[] tabs;
    private int childCount;
    // Start is called before the first frame update
    private void Start() =>
        childCount = transform.childCount;
    

    public void SetNewTab(Transform tab) =>
        tab.SetAsLastSibling();
}
