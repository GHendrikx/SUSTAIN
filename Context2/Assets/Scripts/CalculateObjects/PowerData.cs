﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Context
{
    public class PowerData : MonoBehaviour
    {
        private Data[] data;
        [SerializeField]
        private IOManager ioManager;
        [HideInInspector]
        public float CurrentPowerPoints;
        [HideInInspector]
        public float CurrentPowerGain;
        [HideInInspector]
        public float CurrentPowerGainMod = 1;
        [SerializeField]
        private AI ai;


        // Start is called before the first frame update
        private void Start()
        {
            data = ioManager.data.Data;
        }

        public void UpdateMaterial()
        {
            CalculatePowerGainMod();
            CalculatePowerGain();
            CalculatePowerPoints();
        }

        public void UpdateMaterialWithoutPoints()
        {
            CalculatePowerGainMod();
            CalculatePowerGain();
        }

        private void CalculatePowerPoints()
        {
            ai.CreativityPoints += CurrentPowerGain;
        }

        private void CalculatePowerGainMod()
        {
            CurrentPowerGainMod = 1;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentPowerGainMod += currentData.materialGainMod;
            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    CurrentPowerGainMod += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.materialGainMod;

            ai.MaterialGainMod = CurrentPowerGainMod;
        }

        private void CalculatePowerGain()
        {
            CurrentPowerGain = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentPowerGain += currentData.materialGain;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    CurrentPowerGain += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.powerGain;
            CurrentPowerGain *= CurrentPowerGainMod;

            ai.PowerGain = CurrentPowerGain;
        }
    }
}