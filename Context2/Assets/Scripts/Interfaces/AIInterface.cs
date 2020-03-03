using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Context
{
    public partial class AI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI processing;
        [SerializeField]
        private TextMeshProUGUI Research;
        [SerializeField]
        private TextMeshProUGUI Creativity;

        [SerializeField]
        private UpdateButton[] updateButton;

        /// <summary>
        /// Update processing points
        /// </summary>
        private void UpdateUI()
        {
            processing.text = "Processing Power: " + UpgradeAbilities.TEMPALLOCATIONPOOL + "/" + UpgradeAbilities.ALLOCATIONPOOL.ToString();
            Research.text = "Research: " + ResearchPoints.ToString("0.0") + "/" + ResearchLimit.ToString() + " (+" + ResearchGain.ToString("0.0") + ")";
            Creativity.text = "Creativity: " + CreativityPoints.ToString("0.0") + " (+" + CreativityGain + ")";

            #region Old Code
            //TODO: remove currentgainmod for prototype.
            //memory.text = "R " + ResearchCost.ToString("0.0") + "/"
            //    + ResearchLimit.ToString() + " (+"
            //    + ResearchGain.ToString("0.0") + ")" +
            //    "(" + CurrentResearchGainMod.ToString("0.0") + ")" + " \n" +
            //    " C " + creativityCost.ToString("0.0") + " (+" + creativityGain.ToString("0.0") + ")" + "(" + creativityGainMod.ToString("0.0") + ") \n" +
            //    "F "  + fundsCost.ToString("0.0") + " (+" + FundsGain.ToString("0.0") + ")" + "(" + fundsGainMod.ToString("0.0") + ") \n" +
            //    "I " + InfluenceCost.ToString("0.0") + " (+" + InfluenceGain.ToString("0.0") + "(" + InfluenceGainMod.ToString("0.0") + ") \n";
            #endregion
        }

    }
}
