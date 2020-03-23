using FMODUnity;
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

        public void InitializeNewButton(Data data, AI ai)
        {
            initializedData.Add(data);
            Button button = GameObject.Instantiate(buttonPrefab, transform);
            UpdateButton update = button.gameObject.GetComponent<UpdateButton>();
            update.ButtonInformation(data, ai, tab);

            RectTransform rectTransform = button.GetComponent<RectTransform>();
            rectTransform.position = new Vector2(rectTransform.position.x, 0 + (transform.childCount * 110));
            button.gameObject.SetActive(true);
            gameObject.SetActive(true);
            amountOfUpgrades++;
            #region button
            //for (int i = 0; i < GameManager.Instance.AI.SDGManager.SDGBar.Length; i++)
            //{
            //    SDGBar sdgBar = GameManager.Instance.AI.SDGManager.SDGBar[i];
            //    if (data.ID == sdgBar.SDGUnlockID)
            //    {
            //        update.myButton.onClick.AddListener(() => GameManager.Instance.AI.SDGManager.SetLockImage(sdgBar));
            //    }
            //}
            //button.onClick.AddListener(() => GameManager.Instance.AI.creativityData.UpdateCreativityWithoutPoints());
            //button.onClick.AddListener(() => GameManager.Instance.AI.dronesData.UpdateDroneWithoutPoints());
            //button.onClick.AddListener(() => GameManager.Instance.AI.fundsData.UpdateFundsWithoutPoints());
            //button.onClick.AddListener(() => GameManager.Instance.AI.influenceData.UpdateInfluenceWithoutPoints());
            //button.onClick.AddListener(() => GameManager.Instance.AI.materialData.UpdateMaterialWithoutPoints());
            #endregion


        }

        [System.Obsolete("This was the Test function of the project not in use anymore.")]
        private string SetTextToButton(Data data)
        {
            string text = data.name;
            Debug.Log(data.name);

            if (data.researchCost != 0 || (data.researchCost != null && data.researchCost != 0))
                text += " R (" + data.researchCost + ")";
            if (data.creativityCost != 0 || (data.creativityCost != null && data.creativityCost != 0))
                text += " C (" + data.creativityCost + ")";
            if (data.fundsCost != 0 || (data.fundsCost != null && data.fundsCost != 0))
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
            upgrade.MinButton.onClick.AddListener(() => GameManager.Instance.AI.materialData.UpdateMaterialWithoutPoints());
            upgrade.MinButton.onClick.AddListener(() => GameManager.Instance.AI.powerData.UpdatePowerWithoutPoints());
            upgrade.MinButton.onClick.AddListener(() => GameManager.Instance.AI.droneData.UpdateDroneWithoutPoints());

            upgrade.PlusButton.onClick.AddListener(() => upgrade.CalculateStatus(data.allocatieCost));
            upgrade.PlusButton.onClick.AddListener(() => GameManager.Instance.AI.researchData.UpdateResearchWithoutPoints());
            upgrade.PlusButton.onClick.AddListener(() => GameManager.Instance.AI.creativityData.UpdateCreativityWithoutPoints());
            upgrade.PlusButton.onClick.AddListener(() => GameManager.Instance.AI.fundsData.UpdateFundsWithoutPoints());
            upgrade.PlusButton.onClick.AddListener(() => GameManager.Instance.AI.influenceData.UpdateInfluenceWithoutPoints());
            upgrade.PlusButton.onClick.AddListener(() => GameManager.Instance.AI.materialData.UpdateMaterialWithoutPoints());
            upgrade.PlusButton.onClick.AddListener(() => GameManager.Instance.AI.powerData.UpdatePowerWithoutPoints());
            upgrade.PlusButton.onClick.AddListener(() => GameManager.Instance.AI.droneData.UpdateDroneWithoutPoints());
            upgrade.UpdateInformation(data);
        }

        public void InitializeNewConstruction(Data data, AI ai)
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
            upgrade.MinButton.onClick.AddListener(() => GameManager.Instance.AI.materialData.UpdateMaterialWithoutPoints());
            upgrade.MinButton.onClick.AddListener(() => GameManager.Instance.AI.powerData.UpdatePowerWithoutPoints());
            upgrade.MinButton.onClick.AddListener(() => GameManager.Instance.AI.droneData.UpdateDroneWithoutPoints());

            upgrade.PlusButton.onClick.AddListener(() => upgrade.CalculateStatus(data.allocatieCost));
            upgrade.PlusButton.onClick.AddListener(() => GameManager.Instance.AI.researchData.UpdateResearchWithoutPoints());
            upgrade.PlusButton.onClick.AddListener(() => GameManager.Instance.AI.creativityData.UpdateCreativityWithoutPoints());
            upgrade.PlusButton.onClick.AddListener(() => GameManager.Instance.AI.fundsData.UpdateFundsWithoutPoints());
            upgrade.PlusButton.onClick.AddListener(() => GameManager.Instance.AI.influenceData.UpdateInfluenceWithoutPoints());
            upgrade.PlusButton.onClick.AddListener(() => GameManager.Instance.AI.materialData.UpdateMaterialWithoutPoints());
            upgrade.PlusButton.onClick.AddListener(() => GameManager.Instance.AI.powerData.UpdatePowerWithoutPoints());
            upgrade.PlusButton.onClick.AddListener(() => GameManager.Instance.AI.droneData.UpdateDroneWithoutPoints());
            upgrade.UpdateInformation(data);
        }
    }
}