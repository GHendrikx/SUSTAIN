using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Context
{
    public class UpgradeAbilities : MonoBehaviour
    {
        private static List<UpgradeAbilities> upgradeAbilities = new List<UpgradeAbilities>();
        public Data data;
        public GameObject Instance;
        public static float TEMPALLOCATIONPOOL;
        [SerializeField]
        public static float ALLOCATIONPOOL = 0;
        [SerializeField]
        private Text abilityPointText;
        [SerializeField]
        private Text informationText;

        public Button PlusButton;
        public Button MinButton;


        public void CalculateStatus(int amount)
        {
            int basePoints = System.Convert.ToInt32(TEMPALLOCATIONPOOL);
            int points = 0;

            try
            {
                points = Convert.ToInt32(abilityPointText.text);
            } catch (Exception e)
            {
                Debug.LogError("Contact Geoffrey Hendrikx when you get this error " +
                    "Give him the following information: \n" + e);
                
                Debug.Break();
            }

            if ((basePoints + -amount) < 0 || (points + amount) < 0)
                return;

            basePoints = basePoints + -amount;
            points = points + amount;

            abilityPointText.text = points.ToString();
            TEMPALLOCATIONPOOL = basePoints;
        }

        /// <summary>
        /// Updating the Information
        /// </summary>
        /// <param name="data"></param>
        public void UpdateInformation(Data data)
        {
            this.Instance = gameObject;
            this.data = data;
            upgradeAbilities.Add(this);
            LockCheck();
            if (informationText != null)
                informationText.text = data.name + "(" + data.allocatieCost + ")";
            else
            {
                informationText = GetComponentInChildren<Text>(true);
                informationText.text = data.name + "(" + data.allocatieCost + ")";
            }
        }

        private void LockCheck()
        {
            for (int i = 0; i < upgradeAbilities.Count; i++)
            {
                if (data.locks == upgradeAbilities[i].data.ID)
                {
                    int points = System.Convert.ToInt32(upgradeAbilities[i].abilityPointText.text);
                    if(points > 0)
                        for (int j = 0; j < points; j++)
                            upgradeAbilities[i].CalculateStatus(-1);

                    Destroy(upgradeAbilities[i].Instance);
                }
            }
        }
    }
}