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
        private TextMeshProUGUI Influence;
        [SerializeField]
        private TextMeshProUGUI Power;
        [SerializeField]
        private TextMeshProUGUI Material;
        [SerializeField]
        private TextMeshProUGUI Drone;

        [SerializeField]
        private TextMeshProUGUI name;
        public TextMeshProUGUI Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        [SerializeField]
        private UpdateButton[] updateButton;

        [SerializeField]
        private Button turnButton;
        [SerializeField]
        private Image turnButtonImage;


        [SerializeField]
        private Image aiFitnessScore;

        #region TrustSlider
        [SerializeField]
        private Slider svHateSlider;
        [SerializeField]
        private Slider svNeutralSlider;
        #endregion

        private bool lerping;

        private float GUIResearchPoints;
        private float GUICreativityPoints;
        private float GUIFundsPoints;

        /// <summary>
        /// Update processing points
        /// </summary>
        private void UpdateUI()
        {
            if (name.text != string.Empty && PlayerPrefs.GetString("Name") != null)
                name.text = PlayerPrefs.GetString("Name");
            processing.text = UpgradeAbilities.TEMPALLOCATIONPOOL + "/" + UpgradeAbilities.ALLOCATIONPOOL.ToString();
            Research.text = ResearchPoints.ToString("0.0") + "/" + ResearchLimit.ToString() + " (+" + ResearchGain.ToString("0.0") + ")";
            Creativity.text = CreativityPoints.ToString("0.0") + " (+" + CreativityGain.ToString("0.0") + ")";
            Funds.text = fundsPoints.ToString("0.0") + " (+" + fundsGain.ToString("0.0") + ")";
            Influence.text = influencePoints.ToString("0") + " (+" + influenceGain.ToString("0") + ")";
            Power.text = powerPoints.ToString("0") + " (+" + powerGain.ToString("0") + ")";
            Material.text = materialPoints.ToString("0") + " (+" + materialGain.ToString("0") + ")";
            Drone.text = DronePoints.ToString("0") + " (+" + droneGain.ToString("0") + ")";


            #region AI Calculate Fitness Score
            aiFitnessScore.fillAmount = SDGManager.CalculateHealth();
            #endregion

            if (UpgradeAbilities.TEMPALLOCATIONPOOL > 0)
                turnButton.interactable = false;
            else
                turnButton.interactable = true;


            #region AI Trust
            svHateSlider.value = SvDisapprovesPercentage;
            svNeutralSlider.value = SvDisapprovesPercentage + SvNeutralPercentage;
            #endregion
        }

        public IEnumerator LerpResources(float overtime, float newResearch, float newCreativity, float newFunds, float newInfluence, float newDrones, float newMaterials, float newPower)
        {
            lerping = true;
            float startTime = Time.time;

            float temp1 = CreativityPoints;
            float temp2 = FundsPoints;
            float temp3 = ResearchPoints;
            float temp4 = InfluencePoints;
            float temp5 = DroneCost;
            float temp6 = MaterialCost;
            float temp7 = powerCost;

            while (Time.time < (startTime + overtime))
            {
                if (newCreativity != Mathf.Infinity)
                {
                    
                    temp1 = Mathf.Lerp(CreativityPoints, newCreativity, (Time.time - startTime) / overtime);
                    CreativityPoints = temp1;
                }
                
                if (newFunds != Mathf.Infinity)
                {
                    temp2 = Mathf.Lerp(FundsPoints, newFunds, (Time.time - startTime) / overtime);
                    FundsPoints = temp2;
                }
                
                if (newResearch != Mathf.Infinity)
                {
                    temp3 = Mathf.Lerp(ResearchPoints, newResearch, (Time.time - startTime) / overtime);
                    ResearchPoints = temp3;
                }

                if (newInfluence != Mathf.Infinity)
                {
                    temp4 = Mathf.Lerp(InfluencePoints, newInfluence, (Time.time - startTime) / overtime);
                    influencePoints = temp4;
                }
                
                if (newDrones != Mathf.Infinity)
                {
                    temp5 = Mathf.Lerp(DroneCost, newDrones, (Time.time - startTime) / overtime);
                    dronePoint = temp5;
                }
                
                if (newMaterials != Mathf.Infinity)
                {
                    temp6 = Mathf.Lerp(MaterialCost, newMaterials, (Time.time - startTime) / overtime);
                    materialPoints = temp6;
                }

                if(newPower != Mathf.Infinity)
                {
                    temp7 = Mathf.Lerp(powerCost, newPower, (Time.time - startTime) / overtime);
                    PowerPoints = temp7;
                }
                yield return null;
            }

            lerping = false;
            yield return null;
        }

    }
}
