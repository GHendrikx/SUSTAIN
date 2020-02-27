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
        public float CurrentFundsPoints;
        public float CurrentFundsGain;
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
            ai.FundsPoints += CurrentFundsGain;
        }

        private void CalculateFundsGainMod()
        {
            CurrentFundsGainMod = 1;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentFundsGainMod += currentData.fundsGainMod;
            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                    CurrentFundsGainMod += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.fundsGainMod;

            ai.FundsGainMod = CurrentFundsGainMod;
        }

        private void CalculateFundsGain()
        {
            CurrentFundsGain = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentFundsGain += currentData.fundsGain;

            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                    CurrentFundsGain += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.fundsGain;
            CurrentFundsGain *= CurrentFundsGainMod;

            ai.FundsGain = CurrentFundsGain;
        }
    }
}