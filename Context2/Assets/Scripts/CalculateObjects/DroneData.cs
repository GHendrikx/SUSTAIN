using System.Collections;
using UnityEngine;

namespace Context
{
    public class DroneData : MonoBehaviour
    {
        private Data[] data;
        [SerializeField]
        private IOManager ioManager;
        private float dronesPoints;
        public float DronesPoints
        {
            get
            {
                return dronesPoints;
            }
            set
            {
                dronesPoints = value;
            }
        }
        private float startAmount;
        [HideInInspector]
        public float CurrentDronesLimit;
        [HideInInspector]
        public float CurrentDronesLimitMod;
        [HideInInspector]
        public float CurrentDronesPoints;
        [HideInInspector]
        public float CurrentDronesGain;
        [HideInInspector]
        public float CurrentDronesGainMod = 1;
        [SerializeField]
        private AI ai;


        // Start is called before the first frame update
        private void Start()
        {
            data = ioManager.data.Data;
        }

        // Update is called once per frame
        public void UpdateDrone()
        {
            CalculateDronesGainMod();
            CalculateDronesGain();
            CalculateDronesPoints();
            CalculateDronesLimitMod();
            CalculateDronesLimit();
        }
        public void UpdateDroneWithoutPoints()
        {
            CalculateDronesGainMod();
            CalculateDronesGain();
            CalculateDronesLimitMod();
            CalculateDronesLimit();
        }

        private void CalculateDronesPoints()
        {
            CurrentDronesPoints = ai.DronePoints + CurrentDronesGain;
            if (CurrentDronesPoints > ai.DroneLimit)
                CurrentDronesPoints = ai.DroneLimit;

            float temp1 = ai.DronePoints + CurrentDronesGain;
            StartCoroutine(ai.LerpResources(1, Mathf.Infinity, Mathf.Infinity, Mathf.Infinity, Mathf.Infinity, temp1, Mathf.Infinity, Mathf.Infinity));
        }

        private void CalculateDronesGainMod()
        {
            CurrentDronesGainMod = 1;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentDronesGainMod += currentData.droneGainMod;
            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    CurrentDronesGainMod += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.droneGainMod;
            for (int i = 0; i < UpgradeAbilities.CONSTRUCTIONLIST.Count; i++)
                if (UpgradeAbilities.CONSTRUCTIONLIST[i].Data.typeOfData == 3)
                    CurrentDronesLimit += UpgradeAbilities.CONSTRUCTIONLIST[i].Points * UpgradeAbilities.CONSTRUCTIONLIST[i].Data.droneGainMod;
        }

        private void CalculateDronesGain()
        {
            CurrentDronesGain = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentDronesGain += currentData.droneGain;
            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    CurrentDronesGain += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.droneGain;
            for (int i = 0; i < UpgradeAbilities.CONSTRUCTIONLIST.Count; i++)
                if (UpgradeAbilities.CONSTRUCTIONLIST[i].Data.typeOfData == 3)
                    CurrentDronesLimit += UpgradeAbilities.CONSTRUCTIONLIST[i].Points * UpgradeAbilities.CONSTRUCTIONLIST[i].Data.droneGain;

            CurrentDronesGain *= CurrentDronesGainMod;
        }

        private void CalculateDronesLimit()
        {
            CurrentDronesLimit = 0;
            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentDronesLimit += currentData.droneLimit;
            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    CurrentDronesLimit += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.droneLimit;
            for (int i = 0; i < UpgradeAbilities.CONSTRUCTIONLIST.Count; i++)
                if (UpgradeAbilities.CONSTRUCTIONLIST[i].Data.typeOfData == 3)
                    CurrentDronesLimit += UpgradeAbilities.CONSTRUCTIONLIST[i].Points * UpgradeAbilities.CONSTRUCTIONLIST[i].Data.droneLimit;
            CurrentDronesLimit *= CurrentDronesLimitMod;

            if (ai.DronePoints >= CurrentDronesLimit)
                ai.DronePoints = CurrentDronesLimit;

            ai.DroneLimit = System.Convert.ToInt32(CurrentDronesLimit);
            ai.DroneGain = CurrentDronesGain;
            ai.DroneGainMod = CurrentDronesGainMod;
        }

        private void CalculateDronesLimitMod()
        {
            CurrentDronesLimitMod = 1;
        }
    }
}
