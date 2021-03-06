﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Context
{
    public class PartnerShips : MonoBehaviour
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
        private int requirementPoints;
        private bool isAccepted = false;

        public void InitializeNewPartenerShip(Data data)
        {
            title.text = data.name;
            declineButton.interactable = false;
            this.data = data;

            #region Adding Listeners

            acceptButton.onClick.AddListener(() => isAccepted = true);
            acceptButton.onClick.AddListener(() => AudioManager.Instance.ToggleGameObject(AudioManager.Instance.PolicyAccept));
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

            declineButton.onClick.AddListener(() => AudioManager.Instance.ToggleGameObject(AudioManager.Instance.PolicyDecline));
            declineButton.onClick.AddListener(() => data.isResearched = false);

            declineButton.onClick.AddListener(() => GameManager.Instance.AI.researchData.UpdateResearchWithoutPoints());
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.creativityData.UpdateCreativityWithoutPoints());
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.fundsData.UpdateFundsWithoutPoints());
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.influenceData.UpdateInfluenceWithoutPoints());
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.materialData.UpdateMaterialWithoutPoints());
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.powerData.UpdatePowerWithoutPoints());
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.droneData.UpdateDroneWithoutPoints());
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.RemoveUpdate(data));

            #region Fmod
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.corruptionData.CalculateCorruptionGain());
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.progressionData.CalculateProgressionGain());
            #endregion

            #endregion

            approvalRequirementText.text = System.Convert.ToInt32(data.neededSupervisorTrust * 100).ToString() + "%";
        }
        private void Update()
        {
            if (isAccepted && GameManager.Instance.AI.ResearchPoints >= +data.researchCost &&
                GameManager.Instance.AI.CreativityPoints >= +data.creativityCost &&
                GameManager.Instance.AI.FundsPoints >= +data.fundsCost &&
                GameManager.Instance.AI.InfluencePoints >= +data.influenceCost &&
                GameManager.Instance.AI.DronePoints >= +data.droneCost &&
                GameManager.Instance.AI.MaterialPoints >= +data.materialCost &&
                GameManager.Instance.AI.PowerPoints >= +data.powerCost &&
                GameManager.Instance.AI.ProcessingPoints >= +data.allocatieCost)
                declineButton.interactable = true;
            else
                if (GameManager.Instance.AI.SvApprovesPercentage >= data.neededSupervisorTrust &&
                GameManager.Instance.AI.ResearchPoints >= -data.researchCost &&
                GameManager.Instance.AI.CreativityPoints >= -data.creativityCost &&
                GameManager.Instance.AI.FundsPoints >= -data.fundsCost &&
                GameManager.Instance.AI.InfluencePoints >= -data.influenceCost &&
                GameManager.Instance.AI.DronePoints >= -data.droneCost &&
                GameManager.Instance.AI.MaterialPoints >= -data.materialCost &&
                GameManager.Instance.AI.PowerPoints >= -data.powerCost &&
                GameManager.Instance.AI.ProcessingPoints >= -data.allocatieCost)
                acceptButton.interactable = true;
            else
                acceptButton.interactable = false;

        }

    }
}