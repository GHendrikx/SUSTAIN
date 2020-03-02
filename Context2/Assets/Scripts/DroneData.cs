using UnityEngine;

namespace Context
{
    public class DroneData
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
        private float dronesOffset = 0;


        // Start is called before the first frame update
        private void Start()
        {
            data = ioManager.data.Data;
        }

        // Update is called once per frame
        public void UpdateResearch()
        {
            CalculateDronesGainMod();
            CalculateDronesGain();
            CalculateDronesPoints();
            CalculateDronesLimitMod();
            CalculateDronesLimit();
        }
        public void UpdateResearchWithoutPoints()
        {
            CalculateDronesGainMod();
            CalculateDronesGain();
            CalculateDronesLimitMod();
            CalculateDronesLimit();
        }

        //TODO: look into this one.
        private void CalculateDronesPoints()
        {
            ai.ResearchCost += CurrentDronesGain;
        }

        private void CalculateDronesGainMod()
        {
            CurrentDronesGainMod = 1;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentDronesGainMod += currentData.droneGainMod;
            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                    CurrentDronesGainMod += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.droneGainMod;
        }

        private void CalculateDronesGain()
        {
            CurrentDronesGain = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentDronesGain += currentData.droneGain;
            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                    CurrentDronesGain += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.droneGain;
            CurrentDronesGain *= CurrentDronesGainMod;
        }

        private void CalculateDronesLimit()
        {
            CurrentDronesLimit = 0;
            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentDronesLimit += currentData.droneLimit;
            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                    CurrentDronesLimit += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.droneLimit;
            CurrentDronesLimit *= CurrentDronesLimitMod;

            if (ai.ResearchCost >= CurrentDronesLimit)
                ai.DroneCost = CurrentDronesLimit;

            ai.DroneLimit = System.Convert.ToInt32(CurrentDronesLimit);
            ai.DroneGain = CurrentDronesGain;
            ai.CurrentDroneGainMod = CurrentDronesGainMod;
        }

        private void CalculateDronesLimitMod()
        {
            CurrentDronesLimitMod = 1;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentDronesLimitMod += currentData.researchLimitMod;
            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                    CurrentDronesLimitMod += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.droneLimit;
        }
    }
}
