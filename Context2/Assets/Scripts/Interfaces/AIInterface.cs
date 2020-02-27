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

            processing.text = UpgradeAbilities.TEMPALLOCATIONPOOL + "/" + UpgradeAbilities.ALLOCATIONPOOL.ToString();
            
            //TODO: remove currentgainmod for prototype.
            memory.text = "R " + ResearchPoints.ToString("0.0") + "/"
                + ResearchLimit.ToString() + " (+"
                + ResearchGain.ToString("0.0") + ")" +
                "(" + CurrentResearchGainMod.ToString("0.0") + ")" + " \n C " 
                + creativityPoints.ToString("0.0") + " (+" + creativityGain.ToString("0.0") + ")" + "(" + creativityGainMod.ToString("0.0") + ")" + " \n" +
                "F "  + fundsPoints.ToString("0.0") + " (+" + FundsGain.ToString("0.0") + ")" + "(" + fundsGainMod.ToString("0.0") + ")";

        }

    }
}
