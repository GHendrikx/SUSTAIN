using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Context
{
    public class InitializeNewUpgradeButton : MonoBehaviour
    {
        [SerializeField]
        private Button buttonPrefab;
        [SerializeField]
        private GameObject upgradeAbilities;
        [SerializeField]
        private TextMeshProUGUI[] costs;
        [SerializeField]
        private Image[] image;

        public Tab tab;
        public int amountOfUpgrades;
        public List<Data> initializedData = new List<Data>();

        public void Start()
        {
            Debug.Log(gameObject.name);
        }

        public void InitializeNewButton(Data data,AI ai)
        {
            initializedData.Add(data);
            Button button = GameObject.Instantiate(buttonPrefab, transform);
            UpdateButton update = button.gameObject.GetComponent<UpdateButton>();
            update.ButtonInformation(data, ai);
            RectTransform rectTransform = button.GetComponent<RectTransform>();
            rectTransform.position = new Vector2(rectTransform.position.x, 0 + (transform.childCount * 110));
            button.gameObject.SetActive(true);
            gameObject.SetActive(true);

            //button.gameObject.GetComponentInChildren<TextMeshProUGUI>(true).text = SetTextToButton(data); //data.name +  "R (" + data.researchCost + ")" + "C (" + data.creativityCost + ")";
            

            amountOfUpgrades++;
            button.onClick.AddListener(() => GameManager.Instance.AI.researchData.UpdateResearchWithoutPoints());
            button.onClick.AddListener(() => GameManager.Instance.AI.creativityData.UpdateCreativityWithoutPoints());
            button.onClick.AddListener(() => GameManager.Instance.AI.fundsData.UpdateFundsWithoutPoints());

        }

        [System.Obsolete]
        private string SetTextToButton(Data data)
        {
            string text = data.name;
            Debug.Log(data.name);

            if (data.researchCost != 0 || (data.researchCost != null && data.researchCost != 0))
                text += " R (" + data.researchCost + ")";
            if(data.creativityCost != 0 || (data.creativityCost != null && data.creativityCost != 0))
                text += " C (" + data.creativityCost + ")";
            if(data.fundsCost != 0 || (data.fundsCost != null && data.fundsCost != 0))
                text += " F (" + data.fundsCost + ")";
            if (data.influenceCost != 0 || (data.influenceCost != null && data.influenceCost != 0))
                text += " I (" + data.influenceCost + ")";

            return text;
        }

        public void InitializeNewAllocation(Data data, AI ai)
        {
            
            if (!data.isPrototype)
                return;

            initializedData.Add(data);
            //Allocatie buttons adding and minus. instantiate ALLOCATION
            GameObject go = GameObject.Instantiate(upgradeAbilities, transform);
            UpgradeAbilities upgrade = go.GetComponentInChildren<UpgradeAbilities>();

            upgrade.MinButton.onClick.AddListener(() => upgrade.CalculateStatus(-data.allocatieCost));
            upgrade.MinButton.onClick.AddListener(() => GameManager.Instance.AI.researchData.UpdateResearchWithoutPoints());
            upgrade.MinButton.onClick.AddListener(() => GameManager.Instance.AI.creativityData.UpdateCreativityWithoutPoints());
            upgrade.MinButton.onClick.AddListener(() => GameManager.Instance.AI.fundsData.UpdateFundsWithoutPoints());
            upgrade.MinButton.onClick.AddListener(() => GameManager.Instance.AI.influenceData.UpdateInfluenceWithoutPoints());

            upgrade.PlusButton.onClick.AddListener(() => upgrade.CalculateStatus(data.allocatieCost));
            upgrade.PlusButton.onClick.AddListener(() => GameManager.Instance.AI.researchData.UpdateResearchWithoutPoints());
            upgrade.PlusButton.onClick.AddListener(() => GameManager.Instance.AI.creativityData.UpdateCreativityWithoutPoints());
            upgrade.PlusButton.onClick.AddListener(() => GameManager.Instance.AI.fundsData.UpdateFundsWithoutPoints());
            upgrade.PlusButton.onClick.AddListener(() => GameManager.Instance.AI.influenceData.UpdateInfluenceWithoutPoints());
            upgrade.UpdateInformation(data);
        }
    }
}