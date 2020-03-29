using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;

namespace Context
{
    public class FundsData : MonoBehaviour
    {
        private Data[] data;
        [SerializeField]
        private IOManager ioManager;
        [HideInInspector]
        public float CurrentFundsPoints;
        [HideInInspector]
        public float CurrentFundsGain;
        [HideInInspector]
        public float CurrentFundsGainMod = 1;
        [SerializeField]
        private AI ai;


        // Start is called before the first frame update
        private void Start()
        {
            data = ioManager.data.Data;
        }

        public void UpdateFunds()
        {
            CalculateFundsGainMod();
            CalculateFundsGain();
            CalculateFundsPoints();
        }

        public void UpdateFundsWithoutPoints()
        {
            CalculateFundsGainMod();
            CalculateFundsGain();
        }

        private void CalculateFundsPoints()
        {
            CurrentFundsPoints = ai.FundsPoints + CurrentFundsGain;
            float temp1 = ai.FundsPoints + CurrentFundsGain;
            StartCoroutine(ai.LerpResources(1, Mathf.Infinity, Mathf.Infinity, temp1, Mathf.Infinity,Mathf.Infinity, Mathf.Infinity, Mathf.Infinity));
        }

        private void CalculateFundsGainMod()
        {
            CurrentFundsGainMod = 1;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentFundsGainMod += currentData.fundsGainMod;
            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    CurrentFundsGainMod += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.fundsGainMod;

            ai.FundsGainMod = CurrentFundsGainMod;
        }

        private void CalculateFundsGain()
        {
            CurrentFundsGain = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentFundsGain += currentData.fundsGain;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    CurrentFundsGain += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.fundsGain;
            CurrentFundsGain *= CurrentFundsGainMod;

            ai.FundsGain = CurrentFundsGain;
        }
    }
}