using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Context
{
    public class PartnerShips : MonoBehaviour
    {
        [SerializeField]
        private Button acceptButton;
        [SerializeField]
        private Button declineButton;
        [SerializeField]
        private TextMeshProUGUI title;
        [SerializeField]
        private TextMeshProUGUI description;
        private Data data;
        [SerializeField]
        private TextMeshProUGUI approvalRequirementText;
        private int requirementPoints;
        private bool isAccepted = false;

        public void InitializeNewPartenerShip(Data data)
        {
            title.text = data.name;
            this.data = data;

            acceptButton.onClick.AddListener(() => isAccepted = true);
            acceptButton.onClick.AddListener(() => AudioManager.Instance.ToggleGameObject(AudioManager.Instance.PolicyAccept));
            acceptButton.onClick.AddListener(() => data.isResearched = true);

            acceptButton.onClick.AddListener(() => GameManager.Instance.AI.creativityData.UpdateCreativityWithoutPoints());
            acceptButton.onClick.AddListener(() => GameManager.Instance.AI.researchData.UpdateResearchWithoutPoints());
            acceptButton.onClick.AddListener(() => GameManager.Instance.AI.fundsData.UpdateFundsWithoutPoints());
            acceptButton.onClick.AddListener(() => GameManager.Instance.AI.influenceData.UpdateInfluenceWithoutPoints());
            acceptButton.onClick.AddListener(() => GameManager.Instance.AI.materialData.UpdateMaterialWithoutPoints());
            acceptButton.onClick.AddListener(() => GameManager.Instance.AI.powerData.UpdatePowerWithoutPoints());
            acceptButton.onClick.AddListener(() => GameManager.Instance.AI.droneData.UpdateDroneWithoutPoints());
            acceptButton.onClick.AddListener(() => GameManager.Instance.AI.GetUpdate(data));

            declineButton.onClick.AddListener(() => isAccepted = false);
            declineButton.onClick.AddListener(() => AudioManager.Instance.ToggleGameObject(AudioManager.Instance.PolicyDecline));
            declineButton.onClick.AddListener(() => data.isResearched = false);

            declineButton.onClick.AddListener(() => GameManager.Instance.AI.researchData.UpdateResearchWithoutPoints());
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.creativityData.UpdateCreativityWithoutPoints());
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.fundsData.UpdateFundsWithoutPoints());
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.influenceData.UpdateInfluenceWithoutPoints());
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.materialData.UpdateMaterialWithoutPoints());
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.powerData.UpdatePowerWithoutPoints());
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.droneData.UpdateDroneWithoutPoints());
            declineButton.onClick.AddListener(() => GameManager.Instance.AI.RemoveUpdate(data));


            approvalRequirementText.text = System.Convert.ToInt32(data.neededSupervisorTrust * 100).ToString() + "%";
        }
        private void Update()
        {
            if (isAccepted)
                declineButton.interactable = true;
            else
                declineButton.interactable = false;
            
            if (GameManager.Instance.AI.SvApprovesPercentage >= data.neededSupervisorTrust)
                acceptButton.interactable = true;
            else
                acceptButton.interactable = false;

        }

        private void ToggleGameObject(GameObject gameObject)
        {
            gameObject.SetActive(false);
            gameObject.SetActive(true);
        }
    }
}