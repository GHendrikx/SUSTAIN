using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
        [SerializeField]
        private TextMeshProUGUI effectDescription;
        [SerializeField]
        private TextMeshProUGUI SDGNummer;
        [SerializeField]
        private Image SDGColor;
        private bool isAccepted = false;



        public void InitializeNewConstruction(Data data)
        {
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

            for (int i = 0; i < GameManager.Instance.AI.SDGManager.SDGBar.Length; i++)
            {
                SDGBar sdgBar = GameManager.Instance.AI.SDGManager.SDGBar[i];
                if (data.sdgType[0] == i)
                    SDGColor.color = sdgBar.Color;
            }
        }
        private void Update()
        {
            //if (data.isResearched != isAccepted)
            //    data.isResearched = isAccepted;

            //if (GameManager.Instance.AI.ApprovalReq >= data.approvalReq)
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