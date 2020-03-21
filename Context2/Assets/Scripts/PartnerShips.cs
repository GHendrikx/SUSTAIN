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

        private TextMeshProUGUI RequirementText;
        private int requirementPoints;
        private bool isAccepted;

        public void InitializeNewPartenerShip(Data data)
        {
            //Debug.Log("Initialize");
            title.text = data.name;
            this.data = data;
            acceptButton.onClick.AddListener(() => isAccepted = true);
            declineButton.onClick.AddListener(() => isAccepted = false);
        }
        private void Update()
        {
            if (data.isResearched != isAccepted)
                data.isResearched = isAccepted;

            if(GameManager.Instance.AI.ApprovalReq >= data.approvalReq)
            {
                acceptButton.interactable = true;
            }
            else
            {

            }
        }


    }
}