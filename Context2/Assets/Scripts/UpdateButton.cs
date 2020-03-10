﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

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
        
        #region information
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

        private void Update()
        {
            if (Ai == null)
                return;

            if (Ai.ResearchPoints >= data.researchCost &&
                Ai.CreativityPoints >= data.creativityCost &&
                Ai.FundsPoints >= data.fundsCost &&
                Ai.InfluencePoints >= data.influenceCost)
                myButton.interactable = true;
            else
                myButton.interactable = false;
        }

        /// <summary>
        /// Setting new update
        /// </summary>
        /// <param name="data"></param>
        /// <param name="ai"></param>
        public void ButtonInformation(Data data, AI ai)
        {
            this.UpdateName = data.name + data.desc;
            this.CostOfUpdate = data.researchCost;
            //Debug.Break();
            Ai = ai;
            this.data = data;
            SetTextToUpdateButton();
            BackupAllocationPoints = GameManager.Instance.UIManager.CalculateAllocationMod();
            bool status = gameObject.transform.root.gameObject.activeInHierarchy;
            if (myButton != null)
                myButton = GetComponent<Button>();

            myButton.onClick.AddListener(() => ai.GetUpdate(CostOfUpdate, data));
            myButton.onClick.AddListener(() => data.isResearched = true);
            myButton.onClick.AddListener(() => AllocationUpdate());
            myButton.onClick.AddListener(() => Destroy(this.gameObject));

        }

        private void SetTextToUpdateButton()
        {
            if (title != null)
                title.text = data.name;
            if (description != null)
                description.text = data.desc;

            SetUpdateCost();
            SetEffects();
        }

        private void SetEffects()
        {
            if (data.creativityGain > 0 || data.creativityGain < 0)
                Extensions.SetEffectGain(data.creativityGain.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/icon_Creativity16X16"), upgradeCost, upgradeBlock);
            if (data.droneGain > 0 || data.droneGain < 0)
                Extensions.SetEffectGain(data.droneGain.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/Iconen_Drone16X16"), upgradeCost, upgradeBlock);
            if (data.fundsGain > 0 || data.fundsGain < 0)
                Extensions.SetEffectGain(data.fundsGain.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/Iconen_Fund16X16"), upgradeCost, upgradeBlock);
            if (data.influenceGain > 0 || data.influenceGain < 0)
                Extensions.SetEffectGain(data.influenceGain.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/iconProcessingPower16X16"), upgradeCost, upgradeBlock);
            if(data.materialGain > 0 ||data.materialGain < 0)
                Extensions.SetEffectGain(data.materialGain.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/Iconen_Materials16X16"), upgradeCost, upgradeBlock);
            if (data.researchGain > 0 || data.researchGain < 0)
                Extensions.SetEffectGain(data.researchGain.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/Iconen_ResearchPoints16X16"), upgradeCost, upgradeBlock);
        }

         private void SetUpdateCost()
        {
            //if (data.allocatieCost > 0)
            //    Extensions.SetEffectGain(data.allocatieCost.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/iconProcessingPower16X16"), upgradeCost,upgradeBlock);
            //if (data.creativityCost > 0)
            //    Extensions.SetEffectGain(data.creativityCost.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/icon_Creativity16X16"), upgradeCost,upgradeBlock);
            //if (data.droneCost > 0)
            //    Extensions.SetEffectGain(data.droneCost.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/Iconen_Drone16X16"), upgradeCost,upgradeBlock);
            //if (data.fundsCost > 0)
            //    Extensions.SetEffectGain(data.droneCost.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/Iconen_Fund16X16"), upgradeCost,upgradeBlock);
            //if (data.influenceCost > 0)
            //    Extensions.SetEffectGain(data.influenceCost.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/iconProcessingPower16X16"), upgradeCost,upgradeBlock);
            //if (data.materialCost > 0)
            //    Extensions.SetEffectGain(data.materialCost.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/Iconen_Materials16X16"), upgradeCost,upgradeBlock);
            //if (data.powerCost > 0)
            //    Extensions.SetEffectGain(data.powerCost.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/iconProcessingPower16X16"), upgradeCost, upgradeBlock);
            //if (data.researchCost > 0)
            //    Extensions.SetEffectGain(data.researchCost.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/Iconen_ResearchPoints16X16"), upgradeCost, upgradeBlock);
        }

        [System.Obsolete("Use the Function in extensions called SetUpdateCost() Same thing better execution", true)]
        private void SetUpdateCost(string text, Image image)
        {
            Debug.Log(text);
            GameObject upgrade = GameObject.Instantiate<GameObject>(upgradeCost);
            upgrade.GetComponentInChildren<TextMeshProUGUI>().text = text;

            //upgrade.GetComponentInChildren<Image>().sprite = image.sprite;
            upgrade.transform.parent = upgradeBlock.transform;
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
    }
}