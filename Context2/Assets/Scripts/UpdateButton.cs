using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Context
{
    public class UpdateButton : MonoBehaviour
    {
        [SerializeField]
        public int CostOfUpdate = 0;
        public string UpdateName = "";
        public Button myButton;
        private AI Ai;
        private Data Data;
        private void Update()
        {
            if (Ai == null)
                return;
            if (Ai.ResearchPoints >= Data.researchCost)
                myButton.interactable = true;
            else
                myButton.interactable = false;
        }
        public void OnEnable() =>
            myButton = GetComponent<Button>();

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
            Data = data;
            Debug.Log(this.Ai);

            myButton.onClick.AddListener(()=> ai.GetUpdate(CostOfUpdate,data));
            myButton.onClick.AddListener(() => data.isResearched = true);
            myButton.onClick.AddListener(() => Destroy(this.gameObject));
        }
    }
}