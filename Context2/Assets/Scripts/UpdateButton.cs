using UnityEngine;
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
        private GameObject[] panels;

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
        [SerializeField]
        private TextMeshProUGUI effectDescription;
        #endregion
        private static bool firstTime = true;

        private void Start()
        {
            if (firstTime && GameManager.Instance.ShowTutorial)
            {
                panels = new GameObject[2] { GameObject.Find("panel 15"), GameObject.Find("panel 16") };
                for (int i = 0; i < panels.Length; i++)
                    panels[i].SetActive(false);
                firstTime = false;
            }
        }

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

            BackupAllocationPoints = GameManager.Instance.UIManager.CalculateAllocationMod();

            bool status = gameObject.transform.root.gameObject.activeInHierarchy;

            SetTextToUpdateButton();
            SetEffects();
            SetUpdateCost();

            if (data.ID == 301 && GameManager.Instance.ShowTutorial)
            {
                myButton.onClick.AddListener(() => panels[0].SetActive(false));
                myButton.onClick.AddListener(() => panels[1].SetActive(true));
                myButton.onClick.AddListener(() => panels[1].transform.GetChild(2).gameObject.SetActive(true));

            }

            for (int i = 0; i < GameManager.Instance.AI.SDGManager.SDGBar.Length; i++)
            {
                SDGBar sdgBar = GameManager.Instance.AI.SDGManager.SDGBar[i];
                if (data.ID == sdgBar.SDGUnlockID)
                    myButton.onClick.AddListener(() => GameManager.Instance.AI.SDGManager.SetLockImage(sdgBar));

                if (data.sdgType[0] == i)
                    SDGColor.color = sdgBar.Color;
            }

            if (myButton != null)
            {
                myButton.onClick.AddListener(() => GameManager.Instance.AI.creativityData.UpdateCreativityWithoutPoints());
                myButton.onClick.AddListener(() => GameManager.Instance.AI.dronesData.UpdateDroneWithoutPoints());
                myButton.onClick.AddListener(() => GameManager.Instance.AI.fundsData.UpdateFundsWithoutPoints());
                myButton.onClick.AddListener(() => GameManager.Instance.AI.influenceData.UpdateInfluenceWithoutPoints());
                myButton.onClick.AddListener(() => GameManager.Instance.AI.materialData.UpdateMaterialWithoutPoints());
                myButton.onClick.AddListener(() => GameManager.Instance.AI.powerData.UpdatePowerWithoutPoints());
                myButton.onClick.AddListener(() => AudioManager.Instance.ResearchObject.SetActive(false));
                myButton.onClick.AddListener(() => AudioManager.Instance.ResearchObject.SetActive(true));

                #region fmod parameters set
                myButton.onClick.AddListener(() => ai.progressionData.CalculateProgressionGain());
                myButton.onClick.AddListener(() => ai.corruptionData.CalculateCorruptionGain());
                #endregion

            }

            if (data.typeOfData == (int)Tab.PartnerShip)
            {
                PartnerShips PartnerShips = this.gameObject.GetComponent<PartnerShips>();
                PartnerShips.InitializeNewPartenerShip(data);
            }

            if (data.typeOfData == (int)Tab.Policies)
            {
                Policy Policies = this.gameObject.GetComponent<Policy>();
                Policies.InitializeNewPolicy(data);
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
                Ai.MaterialPoints >= -data.materialCost &&
                Ai.PowerPoints >= -data.powerCost)
                myButton.interactable = true;
            else
                myButton.interactable = false;

        }

        public void PressButton()
        {


            Ai.GetUpdate(data);
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
            if (effectDescription != null)
            {
                effectDescription.text = data.effectDesc;       
            }
            if (researchNummer != null)
                researchNummer.text = data.sdgType[0].ToString();

        }

        //Deze werkt is de effectsgain van Research
        private void SetEffects()
        {
            if (data.researchGain != 0)
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

                Extensions.SetEffectGain(c + data.researchGain.ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "Iconen_ResearchPoints_3_16X16"), upgradeCost, upgradeBlock, temp);
            }
            if (data.creativityGain != 0)
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

                Extensions.SetEffectGain(c + data.creativityGain.ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_Creativity16X16"), upgradeCost, upgradeBlock, temp);
            }
            if (data.fundsGain != 0)
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

                Extensions.SetEffectGain(c + data.fundsGain.ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "Iconen_Fund16X16"), upgradeCost, upgradeBlock, temp);
            }
            if (data.influenceGain != 0)
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
                Extensions.SetEffectGain(c + data.influenceGain.ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_Stat16X16"), upgradeCost, upgradeBlock, temp);
            }
            if (data.powerGain != 0)
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

                Extensions.SetEffectGain(c + data.powerGain.ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "Iconen_Energy16X16"), upgradeCost, upgradeBlock, temp);
            }
            if (data.materialGain != 0)
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

                Extensions.SetEffectGain(c + data.materialGain.ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "Iconen_Materials16X16"), upgradeCost, upgradeBlock, temp);
            }
            if (data.droneGain != 0)
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

                Extensions.SetEffectGain(c + data.droneGain.ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "iconen_Drone16X16"), upgradeCost, upgradeBlock, temp);
            }

            float sdgMultiplier = 100;
            SDGBar[] sdgBar = Ai.SDGManager.SDGBar;

            if (data.sdgChange01 != 0)
            {
                Color temp = (data.sdgChange01 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";
                Extensions.SetEffectGain(c + (data.sdgChange01 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), upgradeCost, upgradeBlock, temp, sdgBar[0]);
            }
            if (data.sdgChange02 != 0)
            {
                Color temp = (data.sdgChange02 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange02 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), upgradeCost, upgradeBlock, temp, sdgBar[1]);
            }
            if (data.sdgChange03 != 0)
            {
                Color temp = (data.sdgChange03 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange03 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), upgradeCost, upgradeBlock, temp, sdgBar[2]);
            }
            if (data.sdgChange04 != 0)
            {
                Color temp = (data.sdgChange04 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange04 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), upgradeCost, upgradeBlock, temp, sdgBar[3]);
            }
            if (data.sdgChange05 != 0)
            {
                Color temp = (data.sdgChange05 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange05 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), upgradeCost, upgradeBlock, temp, sdgBar[4]);
            }
            if (data.sdgChange06 != 0)
            {
                Color temp = (data.sdgChange06 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange06 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), upgradeCost, upgradeBlock, temp, sdgBar[5]);
            }
            if (data.sdgChange07 != 0)
            {
                Color temp = (data.sdgChange07 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange07 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), upgradeCost, upgradeBlock, temp, sdgBar[6]);
            }
            if (data.sdgChange08 != 0)
            {
                Color temp = (data.sdgChange08 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange08 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), upgradeCost, upgradeBlock, temp, sdgBar[7]);
            }
            if (data.sdgChange09 != 0)
            {
                Color temp = (data.sdgChange09 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange09 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), upgradeCost, upgradeBlock, temp, sdgBar[8]);
            }
            if (data.sdgChange10 != 0)
            {
                Color temp = (data.sdgChange10 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange10 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), upgradeCost, upgradeBlock, temp, sdgBar[9]);
            }
            if (data.sdgChange11 != 0)
            {
                Color temp = (data.sdgChange11 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange11 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), upgradeCost, upgradeBlock, temp, sdgBar[10]);
            }
            if (data.sdgChange12 != 0)
            {
                Color temp = (data.sdgChange12 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange12 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), upgradeCost, upgradeBlock, temp, sdgBar[11]);
            }
            if (data.sdgChange13 != 0)
            {
                Color temp = (data.sdgChange13 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange13 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), upgradeCost, upgradeBlock, temp, sdgBar[12]);
            }
            if (data.sdgChange14 != 0)
            {
                Color temp = (data.sdgChange14 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange14 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), upgradeCost, upgradeBlock, temp, sdgBar[13]);
            }
            if (data.sdgChange15 != 0)
            {
                Color temp = (data.sdgChange15 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange15 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), upgradeCost, upgradeBlock, temp, sdgBar[14]);
            }
            if (data.sdgChange16 != 0)
            {
                Color temp = (data.sdgChange16 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange16 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), upgradeCost, upgradeBlock, temp, sdgBar[15]);
            }
            if (data.sdgChange17 != 0)
            {
                Color temp = (data.sdgChange17 > 0) ? Color.green : Color.red;
                string c = (temp == Color.green) ? "+" : "";

                Extensions.SetEffectGain(c + (data.sdgChange17 * sdgMultiplier).ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_SDG16X16"), upgradeCost, upgradeBlock, temp, sdgBar[16]);
            }

        }



        private void SetUpdateCost()
        {
            if (data.allocatieCost != 0 && (data.typeOfData > 0 && data.typeOfData < 5))
                SetCostBlock(data.allocatieCost.ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "iconProcessingPower16X16"), costInformation, costBlock, data.allocatieCost);
            if (data.researchCost != 0 && (data.typeOfData > 0 && data.typeOfData < 5))
                SetCostBlock(data.researchCost.ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "Iconen_ResearchPoints_3_16X16"), costInformation, costBlock, data.researchCost);
            if (data.creativityCost != 0 && (data.typeOfData > 0 && data.typeOfData < 5))
                SetCostBlock(data.creativityCost.ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_Creativity16X16"), costInformation, costBlock, data.creativityCost);
            if (data.fundsCost != 0 && (data.typeOfData >0 && data.typeOfData < 5))
                SetCostBlock(data.fundsCost.ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "Iconen_Fund16X16"), costInformation, costBlock, data.fundsCost);
            if (data.influenceCost != 0 && (data.typeOfData > 0 && data.typeOfData < 5))
                SetCostBlock(data.influenceCost.ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_Stat16X16"), costInformation, costBlock, data.influenceCost);
            if (data.powerCost != 0 && (data.typeOfData > 0 && data.typeOfData < 5))
                SetCostBlock(data.powerCost.ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "Iconen_Energy16X16"), costInformation, costBlock, data.powerCost);
            if (data.materialCost != 0 && (data.typeOfData > 0 && data.typeOfData < 5))
                SetCostBlock(data.materialCost.ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "Iconen_Materials16X16"), costInformation, costBlock, data.materialCost);
            if (data.droneCost != 0 && (data.typeOfData > 0 && data.typeOfData < 5))
                SetCostBlock(data.droneCost.ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "Iconen_Drone16X16"), costInformation, costBlock, data.droneCost);
        
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
            Image i = cost.GetComponentInChildren<Image>();
            i.sprite = sprite;
        }
    }
}