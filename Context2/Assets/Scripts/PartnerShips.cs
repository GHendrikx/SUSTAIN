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
        private bool isAccepted;

        public void InitializeNewPartenerShip(Data data)
        {
            title.text = data.name;
            this.data = data;

            acceptButton.onClick.AddListener(() => isAccepted = true);
            acceptButton.onClick.AddListener(() => ToggleGameObject(AudioManager.Instance.PolicyAccept));
            declineButton.onClick.AddListener(() => isAccepted = false);
            declineButton.onClick.AddListener(() => ToggleGameObject(AudioManager.Instance.PolicyDecline));

            approvalRequirementText.text = System.Convert.ToInt32(data.approvalReq * 100).ToString() + "%";
        }
        private void Update()
        {
            if (data.isResearched != isAccepted)
                data.isResearched = isAccepted;

            //if(GameManager.Instance.AI.ApprovalReq >= data.approvalReq)
            //    acceptButton.interactable = true;
            //else
            //{

            //}
        }

        private void ToggleGameObject(GameObject gameObject)
        {
            gameObject.SetActive(false);
            gameObject.SetActive(true);
        }
    }
}