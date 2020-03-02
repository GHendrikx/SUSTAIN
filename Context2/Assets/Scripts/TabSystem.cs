using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabSystem : MonoBehaviour
{
    
    private GameObject[] tabs;

    /// <summary>
    /// Set the tab as last sibling
    /// </summary>
    /// <param name="tab"></param>
    public void SetNewTab(Transform tab) =>
        tab.SetAsLastSibling();
}
