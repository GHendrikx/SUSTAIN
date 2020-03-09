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

        [SerializeField]
        private Image aiFitnessScore;

        private bool lerping;

        private float GUIResearchPoints;
        private float GUICreativityPoints;
        private float GUIFundsPoints;

        /// <summary>
        /// Update processing points
        /// </summary>
        private void UpdateUI()
        {
            processing.text = "Processing Power: " + UpgradeAbilities.TEMPALLOCATIONPOOL + "/" + UpgradeAbilities.ALLOCATIONPOOL.ToString();
            Research.text = "Research: " + ResearchPoints.ToString("0.0") + "/" + ResearchLimit.ToString() + " (+" + ResearchGain.ToString("0.0") + ")";
            Creativity.text = "Creativity: " + CreativityPoints.ToString("0.0") + " (+" + CreativityGain + ")";
            Funds.text = "Funds: $" + fundsPoints + "(+" + fundsGain +")";

            #region AI Calculate Fitness Score

            //aiFitnessScore.fillAmount = .5f;

            #endregion
        }

        private IEnumerator LerpResources(float overtime, float newResearch,float newCreativity,float newFunds, float newInfluence, float newDrones,float newMaterials)
        {
            lerping = true;
            float startTime = Time.time;

            float temp1 = 0;
            float temp2 = 0;
            float temp3 = 0;
            float temp4 = 0;
            float temp5 = 0;
            float temp6 = 0;


            while (Time.time < (startTime + overtime))
            {

                temp1 = Mathf.Lerp(CreativityPoints, newCreativity,(Time.time - startTime) / overtime);
                temp2 = Mathf.Lerp(FundsPoints,newFunds, (Time.time - startTime) / overtime);
                temp3 = Mathf.Lerp(ResearchPoints, newResearch, (Time.time - startTime) / overtime);
                temp4 = Mathf.Lerp(InfluencePoints, newInfluence, (Time.time - startTime) / overtime);
                temp5 = Mathf.Lerp(DroneCost, newDrones, (Time.time - startTime) / overtime);
                temp6 = Mathf.Lerp(MaterialCost, newMaterials, (Time.time - startTime) / overtime);

                CreativityPoints = temp1;
                fundsPoints = temp2;
                researchPoints = temp3;

                yield return null;
            }

            lerping = false;
            yield return null;



        }

    }
}
