using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Timers;
using UnityEngine.UI;

namespace Context
{
    public class Construction : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI title;
        [SerializeField]
        private TextMeshProUGUI description;
        private Data data;
        public Data Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }
        [SerializeField]
        private TextMeshProUGUI effectDescription;
        [SerializeField]
        private TextMeshProUGUI SDGNummer;
        [SerializeField]
        private Image SDGColor;
        private bool isAccepted = false;

        [SerializeField]
        private GameObject costBlock;
        [SerializeField]
        private GameObject costInformation;
        private Button myButton;
        [SerializeField]
        private TextMeshProUGUI constructionCount;
        public int Points;
        public bool CanPress;

        public void InitializeNewConstruction(Data data, Button myButton)
        {
            CanPress = true;
            UpgradeAbilities.CONSTRUCTIONLIST.Add(this);
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

            this.data = data;
            this.myButton = myButton;
            for (int i = 0; i < GameManager.Instance.AI.SDGManager.SDGBar.Length; i++)
            {
                SDGBar sdgBar = GameManager.Instance.AI.SDGManager.SDGBar[i];
                if (data.sdgType[0] == i)
                    SDGColor.color = sdgBar.Color;
            }
            SetUpdateCost();

            myButton.onClick.AddListener(() => OnClickButton());
        }

        private void OnClickButton()
        {
            GameManager.Instance.AI.GetUpdate(this.data);
            GameManager.Instance.AI.creativityData.UpdateCreativityWithoutPoints();
            GameManager.Instance.AI.dronesData.UpdateDroneWithoutPoints();
            GameManager.Instance.AI.fundsData.UpdateFundsWithoutPoints();
            GameManager.Instance.AI.influenceData.UpdateInfluenceWithoutPoints();
            GameManager.Instance.AI.materialData.UpdateMaterialWithoutPoints();
            GameManager.Instance.AI.powerData.UpdatePowerWithoutPoints();
            AudioManager.Instance.ToggleGameObject(AudioManager.Instance.AddBuilding);
            AddConstructionCount();

            CanPress = false;
            TimerManager.Instance.AddTimer(() => { CanPress = !CanPress; },1f);
        }

        private void AddConstructionCount()
        {
            int c = System.Convert.ToInt32(constructionCount.text);
            c++;
            Points = c;
            constructionCount.text = c.ToString();
        }

        private void Update()
        {
            if (GameManager.Instance == null || GameManager.Instance.AI == null)
                return;
            
            if (GameManager.Instance.AI.ResearchPoints >= -data.researchCost &&
                GameManager.Instance.AI.CreativityPoints >= -data.creativityCost &&
                GameManager.Instance.AI.FundsPoints >= -data.fundsCost &&
                GameManager.Instance.AI.InfluencePoints >= -data.influenceCost &&
                GameManager.Instance.AI.DronePoints >= -data.droneCost &&
                GameManager.Instance.AI.MaterialPoints >= -data.materialCost &&
                GameManager.Instance.AI.PowerPoints >= -data.powerCost &&
                CanPress)
                myButton.interactable = true;
            else
            {
                myButton.interactable = false;
            }
        }

        private void ToggleGameObject(GameObject gameObject)
        {
            gameObject.SetActive(false);
            gameObject.SetActive(true);
        }

        private void SetUpdateCost()
        {
            if (data.researchCost != 0 && (data.typeOfData > 0 && data.typeOfData < 5))
                SetCostBlock(data.researchCost.ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "Iconen_ResearchPoints_3_16X16"), costInformation, costBlock, data.researchCost);
            if (data.creativityCost != 0 && (data.typeOfData > 0 && data.typeOfData < 5))
                SetCostBlock(data.creativityCost.ToString(), Resources.Load<Sprite>(GameManager.SPRITEPATH + "icon_Creativity16X16"), costInformation, costBlock, data.creativityCost);
            if (data.fundsCost != 0 && (data.typeOfData > 0 && data.typeOfData < 5))
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

        public void SetCostBlock(string text, Sprite sprite, GameObject costInfo, GameObject costBlock, float amount)
        {

            string c = "-";

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