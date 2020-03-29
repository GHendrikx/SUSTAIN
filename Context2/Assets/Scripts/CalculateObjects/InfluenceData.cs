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
            CurrentInfluencePoints = ai.InfluencePoints + CurrentInfluenceGain;
            float temp1 = ai.InfluencePoints + CurrentInfluenceGain;

            //research creativity funds influence drones materials
            StartCoroutine(ai.LerpResources(1, Mathf.Infinity, Mathf.Infinity, Mathf.Infinity , temp1, Mathf.Infinity , Mathf.Infinity, Mathf.Infinity));
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