using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Context
{
    public class UpgradeAbilities : MonoBehaviour
    {
        public static List<UpgradeAbilities> upgradeAbilities = new List<UpgradeAbilities>();
        public Data data;
        public GameObject Instance;
        public static float TEMPALLOCATIONPOOL;
        [SerializeField]
        public static float ALLOCATIONPOOL = 0;
        public float CurrentDoneTarget;
        [SerializeField]
        private TextMeshProUGUI abilityPointText;
        public TextMeshProUGUI AbilityPointText
        {
            get
            {
                return abilityPointText;
            }
            set
            {
                abilityPointText = value;
            }
        }
        [SerializeField]
        private TextMeshProUGUI targetText;
        public TextMeshProUGUI TargetText
        {
            get
            {
                return targetText;
            }
            set
            {
                targetText = value;
            }
        }
        [SerializeField]
        private TextMeshProUGUI informationText;
        public TextMeshProUGUI InformationText
        {
            get
            {
                return informationText;
            }
            set
            {
                informationText = value;
            }
        }

        private TextMeshProUGUI descriptionText;

        public Button PlusButton;
        public Button MinButton;
        public int BasePoints;
        public int Points;
        [SerializeField]
        private GameObject effectBlock;
        [SerializeField]
        private GameObject costBlock;

        public void CalculateStatus(int amount)
        {
            BasePoints = Convert.ToInt32(TEMPALLOCATIONPOOL);
            Points = 0;

            try
            {
                Points = Convert.ToInt32(abilityPointText.text);
                data.amount = Points;
            } catch (Exception e)
            {
                Debug.LogError("Contact Geoffrey Hendrikx when you get this error " +
                    "Give him the following information: \n" + e);

                Debug.Break();
            }

            if ((BasePoints + -amount) < 0 || (Points + amount) < 0)
                return;

            BasePoints = BasePoints + -amount;
            Points = Points + amount;


            abilityPointText.text = Points.ToString();
            TEMPALLOCATIONPOOL = BasePoints;
        }

        /// <summary>
        /// Updating the Information
        /// </summary>
        /// <param name="data"></param>
        public void UpdateInformation(Data data)
        {
            this.Instance = gameObject;
            this.data = data;
            if (data.desc == null)
                descriptionText.text = string.Empty;
            upgradeAbilities.Add(this);
            LockCheck();

            if (informationText != null)
            {
                //informationText.text = data.name + "(" + data.allocatieCost + ")";
                if (data.hasTarget)
                {
                    for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                    {
                        if (data.ID == UpgradeAbilities.upgradeAbilities[i].data.ID)
                        {
                            informationText.text = string.Empty;
                            informationText.text +=  UpgradeAbilities.upgradeAbilities[i].data.name;
                            targetText.text = UpgradeAbilities.upgradeAbilities[i].CurrentDoneTarget + "/" + UpgradeAbilities.upgradeAbilities[i].data.doneDesc ;
                        }
                    }
                }
            }
        }

        private void SetEffect()
        {
            
        }

        private void LockCheck()
        {
            for (int i = 0; i < upgradeAbilities.Count; i++)
            {
                if (data.locks == upgradeAbilities[i].data.ID)
                {
                    int points = System.Convert.ToInt32(upgradeAbilities[i].abilityPointText.text);
                    if (points > 0)
                        for (int j = 0; j < points; j++)
                            upgradeAbilities[i].CalculateStatus(-1);

                    Destroy(upgradeAbilities[i].Instance.transform.parent.gameObject);
                }
            }
        }
    }
}