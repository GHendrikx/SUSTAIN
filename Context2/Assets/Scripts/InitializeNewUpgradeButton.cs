using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Context
{
    public class InitializeNewUpgradeButton : MonoBehaviour
    {
        [SerializeField]
        private Button buttonPrefab;
        [SerializeField]
        private UpgradeAbilities upgradeAbilities;

        public Tab tab;
        public int amountOfUpgrades;
        public List<Data> initializedData = new List<Data>();


        public void InitializeNewButton(Data data,AI ai)
        {

            initializedData.Add(data);
            Button button = GameObject.Instantiate(buttonPrefab, transform);
            UpdateButton update = button.gameObject.AddComponent<UpdateButton>();
            update.ButtonInformation(data, ai);
            RectTransform rectTransform = button.GetComponent<RectTransform>();
            button.transform.GetSiblingIndex();
            rectTransform.position = new Vector2(rectTransform.position.x, 0 + (transform.childCount * 110));
            button.gameObject.SetActive(true);
            button.GetComponentInChildren<Text>(true).text = data.name;
            amountOfUpgrades++;
            button.onClick.AddListener(() => GameManager.Instance.AI.researchData.UpdateResearch());
        }

        public void InitializeNewSlider(Data data, AI ai)
        {
            
            if (!data.isPrototype)
                return;
            //Debug.Log(data.allocatieCost + "<>" + data.name);
            initializedData.Add(data);
            UpgradeAbilities upgrade = GameObject.Instantiate(upgradeAbilities, transform);
            upgrade.MinButton.onClick.AddListener(() => upgrade.CalculateStatus(-data.allocatieCost));
            upgrade.MinButton.onClick.AddListener(() => GameManager.Instance.AI.researchData.UpdateResearch());
            upgrade.PlusButton.onClick.AddListener(() => upgrade.CalculateStatus(data.allocatieCost));
            upgrade.PlusButton.onClick.AddListener(() => GameManager.Instance.AI.researchData.UpdateResearch());

            upgrade.UpdateInformation(data);
        }
    }
}