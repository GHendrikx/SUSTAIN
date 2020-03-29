using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Context {
    public class Tutorial : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent unityEvent;
        private static bool stopUpdate = false;
        private GameObject panel10;
        private GameObject panel20a;
        private GameObject panel24;
        private GameObject tabs;

        private void Awake()
        {
            panel10 = GameObject.Find("panel 10");
            panel20a = GameObject.Find("panel 20a");
            panel24 = GameObject.Find("panel 24");
            tabs = GameObject.Find("tabs-allocation-partnerships-construction");
            stopUpdate = false;
        }

            // Update is called once per frame
            private void Update()
        {

            if (panel10 && UpgradeAbilities.TEMPALLOCATIONPOOL == 0 && !stopUpdate)
            {
                unityEvent?.Invoke();
                stopUpdate = true;
            }
            if (panel20a && UpgradeAbilities.TEMPALLOCATIONPOOL == 6 && !stopUpdate)
            {
                unityEvent?.Invoke();
                stopUpdate = true;
            }
            if (panel24 && (tabs.transform.GetChild(2).name == "tabPartnerships"))
            {
                unityEvent?.Invoke();
                stopUpdate = true;
                Debug.Log("hello");
            }
        }

        public void CheckPanel()
        {
            if(this.gameObject.activeInHierarchy)
            unityEvent?.Invoke();
        }
    }
}