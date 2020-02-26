using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;

namespace Context
{
    public class CreativityData : MonoBehaviour
    {
        private Data[] data;
        [SerializeField]
        private IOManager ioManager;
        public float CurrentCreativityPoints;
        public float CurrentCreativityGain;
        public float CurrentCreativityGainMod = 1;
        [SerializeField]
        private AI ai;


        // Start is called before the first frame update
        private void Start()
        {
            data = ioManager.data.Data;
        }

        // Update is called once per frame
        public void UpdateCreativity()
        {
            CalculateCreativityGainMod();
            CalculateCreativityGain();
            CalculateCreativityPoints();
        }
        public void UpdateCreativityWithoutPoints()
        {
            CalculateCreativityGainMod();
            CalculateCreativityGain();
        }

        //TODO: look into this one.
        private void CalculateCreativityPoints()
        {
            ai.CreativityPoints += CurrentCreativityGain;
            Debug.Log(ai.CreativityPoints);
        }

        private void CalculateCreativityGainMod()
        {
            CurrentCreativityGainMod = 1;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentCreativityGainMod += currentData.creativityGainMod;
            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                    CurrentCreativityGainMod += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.creativityGainMod;

            ai.CreativityGainMod = CurrentCreativityGainMod;
        }

        private void CalculateCreativityGain()
        {
            CurrentCreativityGain = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentCreativityGain += currentData.creativityGain;

            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                    CurrentCreativityGain += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.creativityGain;
            CurrentCreativityGain *= CurrentCreativityGainMod;

            ai.CreativityGain = CurrentCreativityGain;
        }
    }
}