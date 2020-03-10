using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Context
{
    public class UpgradeAbilities : MonoBehaviour
    {
        public static List<UpgradeAbilities> upgradeAbilities = new List<UpgradeAbilities>();
        public Data data;
        public GameObject Instance;
        public static float TEMPALLOCATIONPOOL;
        [SerializeField]
        public static float ALLOCATIONPOOL = 0;
        public float CurrentDoneTarget;
        [SerializeField]
        private TextMeshProUGUI abilityPointText;
        public TextMeshProUGUI AbilityPointText
        {
            get
            {
                return abilityPointText;
            }
            set
            {
                abilityPointText = value;
            }
        }
        [SerializeField]
        private TextMeshProUGUI targetText;
        public TextMeshProUGUI TargetText
        {
            get
            {
                return targetText;
            }
            set
            {
                targetText = value;
            }
        }
        [SerializeField]
        private TextMeshProUGUI informationText;
        public TextMeshProUGUI InformationText
        {
            get
            {
                return informationText;
            }
            set
            {
                informationText = value;
            }
        }

        private TextMeshProUGUI descriptionText;

        public Button PlusButton;
        public Button MinButton;
        public int BasePoints;
        public int Points;
        [SerializeField]
        private GameObject effectBlock;
        [SerializeField]
        private GameObject costBlock;


        [SerializeField]
        private Image rewardImage;
        [SerializeField]
        private TextMeshProUGUI rewardText;

        public void CalculateStatus(int amount)
        {
            BasePoints = Convert.ToInt32(TEMPALLOCATIONPOOL);
            Points = 0;

            try
            {
                Points = Convert.ToInt32(abilityPointText.text);
                data.amount = Points;
            } catch (Exception e)
            {
                Debug.LogError("Contact Geoffrey Hendrikx when you get this error " +
                    "Give him the following information: \n" + e);

                Debug.Break();
            }

            if ((BasePoints + -amount) < 0 || (Points + amount) < 0)
                return;

            BasePoints = BasePoints + -amount;
            Points = Points + amount;


            abilityPointText.text = Points.ToString();
            TEMPALLOCATIONPOOL = BasePoints;
        }

        /// <summary>
        /// Updating the Information
        /// </summary>
        /// <param name="data"></param>
        public void UpdateInformation(Data data)
        {
            this.Instance = gameObject;
            this.data = data;
            SetRewardImage();
            if (data.desc == null)
                descriptionText.text = string.Empty;
            upgradeAbilities.Add(this);
            LockCheck();

            if (informationText != null)
                //informationText.text = data.name + "(" + data.allocatieCost + ")";
                if (data.hasTarget)
                    for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                        if (data.ID == UpgradeAbilities.upgradeAbilities[i].data.ID)
                        {
                            informationText.text = string.Empty;
                            informationText.text += UpgradeAbilities.upgradeAbilities[i].data.name;
                            targetText.text = UpgradeAbilities.upgradeAbilities[i].CurrentDoneTarget + "/" + UpgradeAbilities.upgradeAbilities[i].data.doneDesc;
                        }

            if (data.creativityGain > 0 || data.creativityGain < 0)
            {
                string c;
                Color temp = Color.white;
                if (data.creativityGain > 0)
                {
                    temp = Color.green;
                    c = "+";
                }
                else
                {
                    temp = Color.red;
                    c = "";
                }
                Extensions.SetEffectGain(c + data.creativityGain.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/icon_Creativity16X16"), costBlock, effectBlock, temp);
            }

            if (data.droneGain > 0 || data.droneGain <0)
            {
                string c;

                Color temp = Color.white;
                if (data.droneGain > 0)
                {
                    temp = Color.green;
                    c = "+";
                }
                else {
                    temp = Color.red;
                    c = "";
                }
                Extensions.SetEffectGain(c + data.droneGain.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/iconen_Drone16X16"), costBlock, effectBlock, temp);
            }

            if (data.fundsGain > 0 || data.fundsGain<0)
            {
                string c;

                Color temp = Color.white;
                if (data.fundsGain > 0)
                {
                    temp = Color.green;
                    c = "+";
                }
                else
                {
                    temp = Color.red;
                    c = "";
                }
                Extensions.SetEffectGain(c + data.fundsGain.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/Iconen_Fund16X16"), costBlock, effectBlock, temp);
            }
            
            if (data.influenceGain > 0 || data.influenceGain < 0)
            {
                string c;

                Color temp = Color.white;
                if (data.influenceGain > 0)
                {
                    temp = Color.green;
                    c = "+";
                }
                else 
                {
                    c = "";
                    temp = Color.red; 
                }
                Extensions.SetEffectGain(c + data.influenceGain.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/icon_Influence16X16"), costBlock, effectBlock, temp);
            }

            if (data.materialGain > 0 || data.materialGain < 0)
            {
                string c;

                Color temp = Color.white;
                if (data.materialGain > 0)
                {
                    temp = Color.green;
                    c = "+";
                }
                else
                {
                    temp = Color.red;
                    c = "";
                }
                Extensions.SetEffectGain(c + data.materialGain.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/Iconen_Materials16X16"), costBlock, effectBlock, temp);
            }

            if (data.researchGain > 0 || data.researchGain < 0)
            {
                string c;

                Color temp = Color.white;
                if (data.researchGain > 0)
                {
                    temp = Color.green;
                    c = "+";
                }
                else
                {
                    temp = Color.red;
                    c = "";
                }
                Extensions.SetEffectGain(c + data.researchGain.ToString(), Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/Iconen_ResearchPoints_3_16X16"), costBlock, effectBlock, temp);
            }
        }

        private void SetRewardImage()
        {
            if (data.allocatieFixedGain > 0)
                Extensions.SetAllocatieCost(rewardText, data.allocatieFixedGain, rewardImage, Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/iconProcessingPower16X16"));
            else if (data.creativityFixedGain > 0)
                Extensions.SetAllocatieCost(rewardText, data.creativityFixedGain, rewardImage, Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/icon_Creativity16X16"));
            else if (data.researchFixedGain > 0)
                Extensions.SetAllocatieCost(rewardText, data.researchFixedGain, rewardImage, Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/Iconen_ResearchPoints16X16"));
            else if (data.droneFixedGain > 0)
                Extensions.SetAllocatieCost(rewardText, data.droneFixedGain, rewardImage, Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/Iconen_Drone16X16"));
            else if (data.fundsFixedGain > 0)
                Extensions.SetAllocatieCost(rewardText, data.droneFixedGain, rewardImage, Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/Iconen_Fund16X16"));
            else if (data.influenceFixedGain > 0)
                Extensions.SetAllocatieCost(rewardText, data.droneFixedGain, rewardImage, Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/iconProcessingPower16X16"));
            else if (data.materialFixedGain > 0)
                Extensions.SetAllocatieCost(rewardText, data.droneFixedGain, rewardImage, Resources.Load<Sprite>("ART/UI_PHASE_2/16X16/Iconen_Materials16X16"));
            else
            {
                rewardText.gameObject.SetActive(false);
                rewardImage.gameObject.SetActive(false);
            }
        }

        private void LockCheck()
        {
            for (int i = 0; i < upgradeAbilities.Count; i++)
            {
                if (data.locks == upgradeAbilities[i].data.ID)
                {
                    int points = System.Convert.ToInt32(upgradeAbilities[i].abilityPointText.text);
                    if (points > 0)
                        for (int j = 0; j < points; j++)
                            upgradeAbilities[i].CalculateStatus(-1);

                    Destroy(upgradeAbilities[i].Instance.transform.parent.gameObject);
                }
            }
        }
    }
}