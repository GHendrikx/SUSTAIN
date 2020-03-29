using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Context
{
    public class Policy : MonoBehaviour
    {
        [SerializeField]
        private Button acceptButton;
        [SerializeField]
        private Button declineButton;
        [SerializeField]
        private TextMeshProUGUI title;
        [SerializeField]
        private TextMeshProUGUI description;
        private Data data;
        [SerializeField]
        private TextMeshProUGUI approvalRequirementText;
        [SerializeField]
        private TextMeshProUGUI effectDescription;
        [SerializeField]
        private TextMeshProUGUI SDGNummer;
        [SerializeField]
        private Image SDGColor;
        private int requirementPoints;
        private bool isAccepted = false;


        public void InitializeNewPolicy(Data data)
        {
            this.data = data;
            if (title != null)
                title.text = data.name;
            if (description != null)
                description.text = data.desc;
            if (effectDescription != null)
            {
                effectDescription.text = data.effectDesc;
            }
            if (SDGNummer != null)
                SDGNummer.text = data.sdgType[0].ToString();

            approvalRequirementText.text = System.Convert.ToInt32(data.neededLocalTrust * 100).ToString() + "%";

            #region Adding Listeners

            acceptButton.onClick.AddListener(() => isAccepted = true);
            acceptButton.onClick.AddListener(() => ToggleGameObject(AudioManager.Instance.PolicyAccept));
            acceptButton.onClick.AddListener(() => data.isResearched = true);
            acceptButton.onClick.AddListener(() => GameManager.Instance.AI.creativityData.UpdateCreativityWithoutPoints());
            acceptButton.onClick.AddListener(() => GameManager.Instance.AI.researchData.UpdateResearchWithoutPoints());
            acceptButton.onClick.AddListener(() => GameManager.Instance.AI.fundsData.UpdateFundsWithoutPoints());
            acceptButton.onClick.AddListener(() => GameManager.Instance.AI.influenceData.UpdateInfluenceWithoutPoints());
            acceptButton.onClick.AddListener(() => GameManager.Instance.AI.materialData.UpdateMaterialWithoutPoints());
            acceptButton.onClick.AddListener(() => GameManager.Instance.AI.powerData.UpdatePowerWithoutPoints());
            acceptButton.onClick.AddListener(() => GameManager.Instance.AI.droneData.UpdateDroneWithoutPoints());
            acceptButton.onClick.AddListener(() => GameManager.Instance.AI.GetUpdate(data));

            #region Fmod
            acceptButton.onClick.AddListener(() => GameManager.Instance.AI.corruptionData.CalculateCorruptionGain());
            acceptButton.onClick.AddListener(() => GameManager.Instance.AI.progressionData.CalculateProgressionGain());
            #endregion

            declineButton.onClick.AddListener(() => isAccepted = false);
            declineButton.onClick.AddListener(() => ToggleGameObject(AudioManager.Instance.PolicyDecline));
            acceptButton.onClick.AddListener(() => data.isResearched = false);
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.creativityData.UpdateCreativityWithoutPoints());
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.researchData.UpdateResearchWithoutPoints());
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.fundsData.UpdateFundsWithoutPoints());
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.influenceData.UpdateInfluenceWithoutPoints());
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.materialData.UpdateMaterialWithoutPoints());
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.powerData.UpdatePowerWithoutPoints());
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.droneData.UpdateDroneWithoutPoints());
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.GetUpdate(data));

            #region Fmod
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.corruptionData.CalculateCorruptionGain());
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.progressionData.CalculateProgressionGain());
            #endregion

            #endregion


            for (int i = 0; i < GameManager.Instance.AI.SDGManager.SDGBar.Length; i++)
            {
                SDGBar sdgBar = GameManager.Instance.AI.SDGManager.SDGBar[i];
                if (data.sdgType[0] == i)
                    SDGColor.color = sdgBar.Color;
            }
        }
        private void Update()
        {
            if (isAccepted &&                
                GameManager.Instance.AI.CreativityPoints >= +data.creativityCost &&
                GameManager.Instance.AI.FundsPoints >= +data.fundsCost &&
                GameManager.Instance.AI.InfluencePoints >= +data.influenceCost &&
                GameManager.Instance.AI.DronePoints >= +data.droneCost &&
                GameManager.Instance.AI.MaterialPoints >= +data.materialCost &&
                GameManager.Instance.AI.PowerPoints >= +data.powerCost &&
                GameManager.Instance.AI.ProcessingPoints >= +data.allocatieCost)
                declineButton.interactable = true;
            else
                declineButton.interactable = false;

            if (GameManager.Instance.AI.LocalApprovesPercentage >= data.neededLocalTrust &&
                GameManager.Instance.AI.ResearchPoints >= -data.researchCost &&
                GameManager.Instance.AI.CreativityPoints >= -data.creativityCost &&
                GameManager.Instance.AI.FundsPoints >= -data.fundsCost &&
                GameManager.Instance.AI.InfluencePoints >= -data.influenceCost &&
                GameManager.Instance.AI.DronePoints >= -data.droneCost &&
                GameManager.Instance.AI.MaterialPoints >= -data.materialCost &&
                GameManager.Instance.AI.PowerPoints >= -data.powerCost &&
                GameManager.Instance.AI.ProcessingPoints >= -data.allocatieCost)
            {
                acceptButton.interactable = true;
            }
            else
                acceptButton.interactable = false;
        }

        private void ToggleGameObject(GameObject gameObject)
        {
            gameObject.SetActive(false);
            gameObject.SetActive(true);
        }
    }
}