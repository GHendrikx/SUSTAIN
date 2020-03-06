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
        private TextMeshProUGUI Funds;
        [SerializeField]
        private UpdateButton[] updateButton;

        private float previousResearchPoints;
        private float previousCreativityPoints;
        private float previousFundsPoints;
        private bool lerping;

        /// <summary>
        /// Update processing points
        /// </summary>
        private void UpdateUI()
        {

            if (previousResearchPoints != researchPoints || previousCreativityPoints != CreativityPoints || previousFundsPoints != FundsPoints)
            {
                //if (!lerping)
                //    StartCoroutine(LerpValues(0.1f));
            }

            processing.text = "Processing Power: " + UpgradeAbilities.TEMPALLOCATIONPOOL + "/" + UpgradeAbilities.ALLOCATIONPOOL.ToString();
            Research.text = "Research: " + ResearchPoints.ToString("0.0") + "/" + ResearchLimit.ToString() + " (+" + ResearchGain.ToString("0.0") + ")";
            Creativity.text = "Creativity: " + CreativityPoints.ToString("0.0") + " (+" + CreativityGain + ")";
            Funds.text = "Funds: $" + fundsPoints + "(+" + fundsGain +")";

            previousCreativityPoints = CreativityPoints;
            previousFundsPoints = FundsPoints;
            previousResearchPoints = researchPoints;

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

        private IEnumerator LerpValues(float overtime)
        {
            lerping = true;
            float startTime = Time.time;
            float temp1 = 0;
            float temp2 = 0;
            float temp3 = 0;
            float previous = previousCreativityPoints;
            float previous1 = previousFundsPoints;
            float previous2 = previousResearchPoints;

            while (Time.time < (startTime + overtime))
            {

                temp1 = Mathf.Lerp(previousCreativityPoints, CreativityPoints,(Time.time - startTime) / overtime);
                temp2 = Mathf.Lerp(previousFundsPoints,fundsPoints, (Time.time - startTime) / overtime);
                temp3 = Mathf.Lerp(previousResearchPoints,researchPoints, (Time.time - startTime) / overtime);

                CreativityPoints = temp1;
                fundsPoints = temp2;
                researchPoints = temp3;

                yield return null;
            }
            yield return null;


            lerping = false;

        }

    }
}
