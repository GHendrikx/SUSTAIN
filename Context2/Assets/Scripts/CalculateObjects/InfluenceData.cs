using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;

namespace Context
{
    public class InfluenceData : MonoBehaviour
    {
        private Data[] data;
        [SerializeField]
        private IOManager ioManager;
        [HideInInspector]
        public float CurrentInfluencePoints;
        [HideInInspector]
        public float CurrentInfluenceGain;
        [HideInInspector]
        public float CurrentInfluenceGainMod = 1;
        [SerializeField]
        private AI ai;


        // Start is called before the first frame update
        private void Start()
        {
            data = ioManager.data.Data;
        }

        public void UpdateInfluence()
        {
            CalculateInfluenceGainMod();
            CalculateInfluenceGain();
            CalculateInfluencePoints();
        }

        public void UpdateInfluenceWithoutPoints()
        {
            CalculateInfluenceGainMod();
            CalculateInfluenceGain();
        }

        private void CalculateInfluencePoints()
        {
            ai.InfluencePoints += CurrentInfluenceGain;
        }

        private void CalculateInfluenceGainMod()
        {
            CurrentInfluenceGainMod = 1;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentInfluenceGainMod += currentData.influenceGainMod;
            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    CurrentInfluenceGainMod += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.influenceGainMod;

            ai.InfluenceGainMod = CurrentInfluenceGainMod;
        }

        private void CalculateInfluenceGain()
        {
            CurrentInfluenceGain = 0;
            //TODO: influence GAIN doesn't excist
            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentInfluenceGain += currentData.influenceGain;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    CurrentInfluenceGain += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.influenceGain;
            CurrentInfluenceGain *= CurrentInfluenceGainMod;

            ai.InfluenceGain = CurrentInfluenceGain;
        }
    }
}