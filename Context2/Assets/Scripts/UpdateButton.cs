﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Timers;

namespace Context
{
    public class UpdateButton : MonoBehaviour
    {
        public int CostOfUpdate = 0;
        public string UpdateName = "";
        public Button myButton;
        private AI Ai;
        private Data data;
        private float BackupAllocationPoints;
        [SerializeField]
        private GameObject costBlock;
        [SerializeField]
        private GameObject costInformation;

        #region Information
        [SerializeField]
        private TextMeshProUGUI title;
        [SerializeField]
        private TextMeshProUGUI description;
        [SerializeField]
        private TextMeshProUGUI researchUnlocks;
        [SerializeField]
        private GameObject upgradeBlock;
        [SerializeField]
        private GameObject upgradeCost;
        [SerializeField]
        private Image SDGColor;
        [SerializeField]
        private TextMeshProUGUI researchNummer;
        #endregion


        /// <summary>
        /// Setting new update
        /// </summary>
        /// <param name="data"></param>
        /// <param name="ai"></param>
        public void ButtonInformation(Data data, AI ai, Tab tab)
        {
            this.UpdateName = data.name + data.desc;
            this.CostOfUpdate = data.researchCost;
            Ai = ai;
            this.data = data;
            
            SetTextToUpdateButton();
            BackupAllocationPoints = GameManager.Instance.UIManager.CalculateAllocationMod();
            
            bool status = gameObject.transform.root.gameObject.activeInHierarchy;

            SetUpdateCost();
            
            for (int i = 0; i < GameManager.Instance.AI.SDGManager.SDGBar.Length; i++)
            {
                SDGBar sdgBar = GameManager.Instance.AI.SDGManager.SDGBar[i];
                if (data.ID == sdgBar.SDGUnlockID)
                    myButton.onClick.AddListener(() => GameManager.Instance.AI.SDGManager.SetLockImage(sdgBar));
            }

            myButton.onClick.AddListener(() => GameManager.Instance.AI.creativityData.UpdateCreativityWithoutPoints());
            myButton.onClick.AddListener(() => GameManager.Instance.AI.dronesData.UpdateDroneWithoutPoints());
            myButton.onClick.AddListener(() => GameManager.Instance.AI.fundsData.UpdateFundsWithoutPoints());
            myButton.onClick.AddListener(() => GameManager.Instance.AI.influenceData.UpdateInfluenceWithoutPoints());
            myButton.onClick.AddListener(() => GameManager.Instance.AI.materialData.UpdateMaterialWithoutPoints());

            if (tab == Tab.PartnerShip)
            {
                PartnerShips PartnerShips = this.gameObject.GetComponent<PartnerShips>();
                PartnerShips.InitializeNewPartenerShip(data);
            }
        }
     
        private void Update()
        {
            if (Ai == null)
                return;

            if (Ai.ResearchPoints >= -data.researchCost &&
                Ai.CreativityPoints >= -data.creativityCost &&
                Ai.FundsPoints >= -data.fundsCost &&
                Ai.InfluencePoints >= -data.influenceCost &&
                Ai.DronePoints >= -data.droneCost &&
                Ai.MaterialCost >= -data.materialCost &&
                Ai.PowerCost >= -data.powerCost)
                myButton.interactable = true;
            else
                myButton.interactable = false;
        }

        public void PressButton()
        {
            Ai.GetUpdate(CostOfUpdate, data);
            data.isResearched = true;
            AllocationUpdate();
            
            Destroy(this.gameObject);
        }

        private void SetTextToUpdateButton()
        {
            if (title != null)
                title.text = data.name;
            if (description != null)
                description.text = data.desc;

            SetEffects();
        }

        private void SetEffects()
        {
            if (data.creativityGain != 0)
                Extensions.SetEffectGain(data.creativityGain.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/icon_Creativity16X16"), upgradeCost, upgradeBlock);
            if (data.droneGain != 0)
                Extensions.SetEffectGain(data.droneGain.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/Iconen_Drone16X16"), upgradeCost, upgradeBlock);
            if (data.fundsGain != 0)
                Extensions.SetEffectGain(data.fundsGain.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/Iconen_Fund16X16"), upgradeCost, upgradeBlock);
            if (data.influenceGain != 0)
                Extensions.SetEffectGain(data.influenceGain.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/icon_Influence16X16"), upgradeCost, upgradeBlock);
            if (data.materialGain != 0)
                Extensions.SetEffectGain(data.materialGain.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/Iconen_Materials16X16"), upgradeCost, upgradeBlock);
            if (data.researchGain != 0)
                Extensions.SetEffectGain(data.researchGain.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/Iconen_ResearchPoints16X16"), upgradeCost, upgradeBlock);
        }

         private void SetUpdateCost()
        {
            if (data.creativityCost != 0)
                SetCostBlock(data.creativityCost.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/icon_Creativity16X16"), costInformation, costBlock, data.creativityCost);
            if (data.droneCost != 0)
                SetCostBlock(data.droneCost.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/Iconen_Drone16X16"), costInformation, costBlock, data.droneCost);
            if (data.fundsCost != 0)
                SetCostBlock(data.fundsCost.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/Iconen_Fund16X16"), costInformation, costBlock,data.fundsCost);
            if (data.influenceCost != 0)
                SetCostBlock(data.influenceCost.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/iconProcessingPower16X16"), costInformation, costBlock, data.influenceCost);
            if (data.materialCost != 0)
                SetCostBlock(data.materialCost.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/Iconen_Materials16X16"), costInformation, costBlock, data.materialCost);
            if (data.powerCost != 0)
                SetCostBlock(data.powerCost.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/iconProcessingPower16X16"), costInformation, costBlock,data.powerCost);
            if (data.researchCost != 0)
                SetCostBlock(data.researchCost.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/Iconen_ResearchPoints_3_16X16"), costInformation, costBlock,data.researchCost);
        }

        private void AllocationUpdate()
        {
            float currentAllocationMod = GameManager.Instance.UIManager.CalculateAllocationMod();
            float temp = UpgradeAbilities.ALLOCATIONPOOL;
            float calculation = currentAllocationMod - temp;

            if (currentAllocationMod > BackupAllocationPoints)
                UpgradeAbilities.TEMPALLOCATIONPOOL += calculation;

            UpgradeAbilities.ALLOCATIONPOOL = currentAllocationMod;
        }


        public void SetCostBlock(string text, Sprite sprite, GameObject costInfo, GameObject costBlock, float amount)
        {
            string c = string.Empty;

            Color textColor = Color.white;

            if (amount > 0)
            {
                textColor = Color.green;
                c = "+";
            }
            else
                textColor = Color.red;


            Transform cost = GameObject.Instantiate(costInfo.transform, costBlock.transform);

            cost.GetComponentInChildren<TextMeshProUGUI>().text = string.Empty;
            cost.GetComponentInChildren<TextMeshProUGUI>().color = textColor;
            cost.GetComponentInChildren<TextMeshProUGUI>().text = c + text;
            Image i = costInfo.GetComponentInChildren<Image>();
            i.sprite = sprite;
        }
    }
}