using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Context {
    public class Tutorial : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent unityEvent;
        

        // Update is called once per frame
        private void Update()
        {
            if (UpgradeAbilities.TEMPALLOCATIONPOOL == 0)
                unityEvent?.Invoke();
        }

        public void CheckPanel()
        {
            Debug.Log(gameObject.name);
            if(this.gameObject.activeInHierarchy)
                unityEvent?.Invoke();
        }
    }
}