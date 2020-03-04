using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        private UpdateBlockInformation upgradeBlockInformation;
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
    [System.Serializable]
    public struct UpdateBlockInformation
    {
        [SerializeField]
        private TextMeshProUGUI text;
        public TextMeshProUGUI Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }

        [SerializeField]
        private Image upgradeIcon;
        public Image UpgradeIcon
        {
            get
            {
                return upgradeIcon;
            }
            set
            {
                upgradeIcon = value;
            }
        }
    }
}