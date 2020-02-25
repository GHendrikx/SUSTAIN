using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Context
{
    public partial class AI : MonoBehaviour
    {
        [SerializeField]
        private Text processing;
        [SerializeField]
        private Text memory;
        [SerializeField]
        private UpdateButton[] updateButton;
        
        /// <summary>
        /// Update processing points
        /// </summary>
        private void UpdateUI()
        {
           
            processing.text = UpgradeAbilities.TEMPALLOCATIONPOOL + "/"+ UpgradeAbilities.ALLOCATIONPOOL.ToString();
            //processing.text = processingAmount.ToString() + " / " + MemoryPoints.ToString();
            memory.text = MemoryPoints.ToString();
        }
        
    }
}
