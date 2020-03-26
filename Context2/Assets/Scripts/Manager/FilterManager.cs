using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Context {
    public class FilterManager : MonoBehaviour
    {
        private Filter currentFiler;
        
        [SerializeField]
        private Image[] Filtered;


        // Start is called before the first frame update
        private void Start()
        {
            currentFiler = new Filter();
            currentFiler.StartFiltering();
         }
        
        public void ToggleFilter(int sdgType) =>
            currentFiler.Toggeling((SDGType)sdgType);
    }
}