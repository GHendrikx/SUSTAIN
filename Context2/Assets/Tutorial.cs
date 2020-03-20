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

        // Update is called once per frame
        private void Update()
        {

            if (UpgradeAbilities.TEMPALLOCATIONPOOL == 0 && !stopUpdate)
            {
                unityEvent?.Invoke();
                stopUpdate = true;
            }
        }

        public void CheckPanel()
        {
            if(this.gameObject.activeInHierarchy)
            unityEvent?.Invoke();
        }
    }
}