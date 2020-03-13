using System.Collections;
using System.Collections.Generic;
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
        private Text title;

        private bool isAccepted;

        void InitializeNewPartenerShip(Data data)
        {
            title.text = data.name;
            acceptButton.onClick.AddListener(() => isAccepted = true);
            declineButton.onClick.AddListener(() => isAccepted = false);
        }



    }
}