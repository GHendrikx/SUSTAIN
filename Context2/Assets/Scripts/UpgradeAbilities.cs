using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Context
{
    public class UpgradeAbilities : MonoBehaviour
    {
        public static List<UpgradeAbilities> UPGRADEABILITIES = new List<UpgradeAbilities>();
        public static List<Construction> CONSTRUCTIONLIST = new List<Construction>();
        public Data data;
        public GameObject Instance;
        public static float TEMPALLOCATIONPOOL;
        [SerializeField]
        public static float ALLOCATIONPOOL = 0;
        public float CurrentDoneTarget;
        [SerializeField]
        private TextMeshProUGUI SDGNummer;
        [SerializeField]
        private Image SDGColor;
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
                Debug.LogError("Contact Geoffrey Hendrikx when you get this error \n" +
                    "Give him the following information: \n" + e);
            }

            if (((BasePoints + -amount) < 0 || (Points + amount) < 0) && amount != 999)
            {
                AudioManager.Instance.ToggleGameObject(AudioManager.Instance.AllocatieError);
                return;
            }

            BasePoints = BasePoints + -amount;
            Points = Points + amount;
            if (amount != 999)
            {
            int fmodPoints = 0;
            if(ALLOCATIONPOOL >= 26)
                fmodPoints = Mathf.RoundToInt((Points / ALLOCATIONPOOL) * 26 - 13);
            else
                fmodPoints = Mathf.RoundToInt((Points / ALLOCATIONPOOL) * ALLOCATIONPOOL * 2 - ALLOCATIONPOOL);

            //Set the FMod points. 
            GameManager.Instance.StudioEventAllocatie.Params[0].Value = fmodPoints;
            GameManager.Instance.StudioEventAllocatie.Play();
            
            abilityPointText.text = Points.ToString();
            TEMPALLOCATIONPOOL = BasePoints;
            }
        }

        /// <summary>
        /// Updating the Information
        /// </summary>
        /// <param name="data"></param>
        public void UpdateInformation(Data data)
        {
            this.Instance = gameObject;
            this.data = data;
            if (data.typeOfData == (int)Tab.Allocatie)
                SetRewardImage();
            if (data.typeOfData == (int)Tab.Construction)
                informationText.text = data.name;

            for (int i = 0; i < GameManager.Instance.AI.SDGManager.SDGBar.Length; i++)
            {
                SDGBar s = GameManager.Instance.AI.SDGManager.SDGBar[i];
                if (data.sdgType[0] == i)
                    SDGColor.color = s.Color;
            }
            if (SDGNummer != null)
                SDGNummer.text = data.sdgType[0].ToString();

            if (data.desc == null)
                descriptionText.text = string.Empty;
            UPGRADEABILITIES.Add(this);
            LockCheck();

            if (informationText != null)
                //informationText.text = data.name + "(" + data.allocatieCost + ")";
                if (data.hasTarget)
                    for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                        if (data.ID == UpgradeAbilities.UPGRADEABILITIES[i].data.ID)
                        {
                            informationText.text = string.Empty;
                            informationText.text += UpgradeAbilities.UPGRADEABILITIES[i].data.name;
                            UpgradeAbilities.UPGRADEABILITIES[i].CurrentDoneTarget = UpgradeAbilities.UPGRADEABILITIES[i].data.doneTarget;

                            if (UpgradeAbilities.UPGRADEABILITIES[i].data.hasTarget)
                            {
                                UpgradeAbilities.UPGRADEABILITIES[i].InformationText.text = UpgradeAbilities.UPGRADEABILITIES[i].data.name;
                                UpgradeAbilities.UPGRADEABILITIES[i].TargetText.text = UpgradeAbilities.UPGRADEABILITIES[i].data.doneTimes + "/" +
                                UpgradeAbilities.UPGRADEABILITIES[i].CurrentDoneTarget + " " + UpgradeAbilities.UPGRADEABILITIES[i].data.doneDesc;
                            }  
                        }

            if (data.creativityGain > 0 || data.creativityGain < 0)
            {
                string c = "";
                Color temp = Color.white;
                if (data.creativityGain > 0)
                {
                    temp = Color.green;
                    c = "+";
                }
                else
                    temp = Color.red;

                Extensions.SetEffectGain(c + data.creativityGain.ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_Creativity16X16"), costBlock, effectBlock, temp);
            }

            if (data.droneGain > 0 || data.droneGain < 0)
            {
                string c = "";

                Color temp = Color.white;
                if (data.droneGain > 0)
                {
                    temp = Color.green;
                    c = "+";
                }
                else
                    temp = Color.red;

                Extensions.SetEffectGain(c + data.droneGain.ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "iconen_Drone16X16"), costBlock, effectBlock, temp);
            }

            if (data.fundsGain > 0 || data.fundsGain < 0)
            {
                string c = "";

                Color temp = Color.white;
                if (data.fundsGain > 0)
                {
                    temp = Color.green;
                    c = "+";
                }
                else
                    temp = Color.red;

                Extensions.SetEffectGain(c + data.fundsGain.ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "Iconen_Fund16X16"), costBlock, effectBlock, temp);
            }

            if (data.influenceGain > 0 || data.influenceGain < 0)
            {
                string c = "";

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

                Extensions.SetEffectGain(c + data.influenceGain.ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_Stat16X16"), costBlock, effectBlock, temp);
            }

            if (data.materialGain > 0 || data.materialGain < 0)
            {
                string c = "";

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

                Extensions.SetEffectGain(c + data.materialGain.ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "Iconen_Materials16X16"), costBlock, effectBlock, temp);
            }

            if (data.powerGain > 0 || data.powerGain < 0)
            {
                string c = "";

                Color temp = Color.white;
                if (data.powerGain > 0)
                {
                    temp = Color.green;
                    c = "+";
                }
                else
                {
                    temp = Color.red;
                    c = "";
                }

                Extensions.SetEffectGain(c + data.powerGain.ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "Iconen_Energy16X16"), costBlock, effectBlock, temp);
            }

            if (data.researchGain > 0 || data.researchGain < 0)
            {
                string c = "";

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

                Extensions.SetEffectGain(c + data.researchGain.ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "Iconen_ResearchPoints_3_16X16"), costBlock, effectBlock, temp);
            }

            float sdgMultiplier = 1000;
            SDGBar[] sdgBar = GameManager.Instance.AI.SDGManager.SDGBar;
           
            if (data.sdgChange01 != 0)
            {
                Color temp = (data.sdgChange01 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";
                Extensions.SetEffectGain(c + (data.sdgChange01 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), costBlock, effectBlock, temp,sdgBar[0]);
            }
            if (data.sdgChange02 != 0)
            {
                Color temp = (data.sdgChange02 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange02 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), costBlock, effectBlock, temp, sdgBar[1]);
            }
            if (data.sdgChange03 != 0)
            {
                Color temp = (data.sdgChange03 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange03 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), costBlock, effectBlock, temp, sdgBar[2]);
            }
            if (data.sdgChange04 != 0)
            {
                Color temp = (data.sdgChange04 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange04 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), costBlock, effectBlock, temp, sdgBar[3]);
            }
            if (data.sdgChange05 != 0)
            {
                Color temp = (data.sdgChange05 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange05 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), costBlock, effectBlock, temp, sdgBar[4]);
            }
            if (data.sdgChange06 != 0)
            {
                Color temp = (data.sdgChange06 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange06 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), costBlock, effectBlock, temp, sdgBar[5]);
            }
            if (data.sdgChange07 != 0)
            {
                Color temp = (data.sdgChange07 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange07 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), costBlock, effectBlock, temp, sdgBar[6]);
            }
            if (data.sdgChange08 != 0)
            {
                Color temp = (data.sdgChange08 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange08 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), costBlock, effectBlock, temp, sdgBar[7]);
            }
            if (data.sdgChange09 != 0)
            {
                Color temp = (data.sdgChange09 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange09 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), costBlock, effectBlock, temp, sdgBar[8]);
            }
            if (data.sdgChange10 != 0)
            {
                Color temp = (data.sdgChange10 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange10 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), costBlock, effectBlock, temp, sdgBar[9]);
            }
            if (data.sdgChange11 != 0)
            {
                Color temp = (data.sdgChange11 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange11 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), costBlock, effectBlock, temp, sdgBar[10]);
            }
            if (data.sdgChange12 != 0)
            {
                Color temp = (data.sdgChange12 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange12 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), costBlock, effectBlock, temp, sdgBar[11]);
            }
            if (data.sdgChange13 != 0)
            {
                Color temp = (data.sdgChange13 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange13 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), costBlock, effectBlock, temp, sdgBar[12]);
            }
            if (data.sdgChange14 != 0)
            {
                Color temp = (data.sdgChange14 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange14 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), costBlock, effectBlock, temp, sdgBar[13]);
            }
            if (data.sdgChange15 != 0)
            {
                Color temp = (data.sdgChange15 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange15 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), costBlock, effectBlock, temp, sdgBar[14]);
            }
            if (data.sdgChange16 != 0)
            {
                Color temp = (data.sdgChange16 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange16 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), costBlock, effectBlock, temp, sdgBar[15]);
            }
            if (data.sdgChange17 != 0)
            {
                Color temp = (data.sdgChange17 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange17 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), costBlock, effectBlock, temp, sdgBar[16]);
            }
        }

        private void SetRewardImage()
        {
            if (data.allocatieFixedGain > 0)
                Extensions.SetAllocatieCost(rewardText, data.allocatieFixedGain, rewardImage, Resources.Load<Sprite>(GameManager.SPRITEPATH + "iconProcessingPower16X16"));
            else if (data.researchFixedGain > 0)
                Extensions.SetAllocatieCost(rewardText, data.researchFixedGain, rewardImage, Resources.Load<Sprite>(GameManager.SPRITEPATH + "Iconen_ResearchPoints_3_16X16"));
            else if (data.creativityFixedGain > 0)
                Extensions.SetAllocatieCost(rewardText, data.creativityFixedGain, rewardImage, Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_Creativity16X16"));
            else if (data.fundsFixedGain > 0)
                Extensions.SetAllocatieCost(rewardText, data.droneFixedGain, rewardImage, Resources.Load<Sprite>(GameManager.SPRITEPATH + "Iconen_Fund16X16"));
            else if (data.influenceFixedGain > 0)
                Extensions.SetAllocatieCost(rewardText, data.influenceFixedGain, rewardImage, Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_Stat16X16"));
            else if (data.powerFixedGain > 0)
                Extensions.SetAllocatieCost(rewardText, data.powerFixedGain, rewardImage, Resources.Load<Sprite>(GameManager.SPRITEPATH + "Iconen_Energy16X16"));
            else if (data.materialFixedGain > 0)
                Extensions.SetAllocatieCost(rewardText, data.materialFixedGain, rewardImage, Resources.Load<Sprite>(GameManager.SPRITEPATH + "Iconen_Materials16X16"));
            else if (data.droneFixedGain > 0)
                Extensions.SetAllocatieCost(rewardText, data.powerFixedGain, rewardImage, Resources.Load<Sprite>(GameManager.SPRITEPATH + "Iconen_Drone16X16"));

            else
            {
                 rewardText.gameObject.SetActive(false);
                 rewardImage.gameObject.SetActive(false);

            }
        }
        
        private void LockCheck()
        {
            for (int i = 0; i < UPGRADEABILITIES.Count; i++)
            {
                if (data.locks == UPGRADEABILITIES[i].data.ID)
                {
                    int points = System.Convert.ToInt32(UPGRADEABILITIES[i].abilityPointText.text);
                    if (points > 0)
                        for (int j = 0; j < points; j++)
                            UPGRADEABILITIES[i].CalculateStatus(-1);

                    Destroy(UPGRADEABILITIES[i].Instance.transform.parent.gameObject);
                }
            }
        }
    }
}