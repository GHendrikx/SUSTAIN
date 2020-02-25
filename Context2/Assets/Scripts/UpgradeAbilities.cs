using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Context
{
    public class UpgradeAbilities : MonoBehaviour
    {
        public static float TEMPALLOCATIONPOOL;
        [SerializeField]
        public static float ALLOCATIONPOOL = 0;
        [SerializeField]
        private Text abilityPointText;
        [SerializeField]
        private Text informationText;

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
            Debug.Log(data.name);

            if (informationText != null)
                informationText.text = data.name;
            else
            {
                informationText = GetComponentInChildren<Text>(true);
                informationText.text = data.name;
            }
        }
    }
}