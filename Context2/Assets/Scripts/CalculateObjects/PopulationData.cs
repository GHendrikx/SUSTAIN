using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;

namespace Context
{
    public class PopulationData : MonoBehaviour
    {
        private Data[] data;
        [SerializeField]
        private IOManager iOManager;
        public float CurrentLocalPopulation = 100000;
        public double CurrentGlobalPopulation = 7000000000;
        public float PopulationGrowthFactor = 1.00009f;

        public float CurrentLocalPopulationGrowthMod;
        public float CurrentGlobalPopulationGrowthMod;

        // Start is called before the first frame update
        private void Start()
        {
            data = iOManager.data.Data;
            TimerManager.Instance.AddTimer(UpdatePopulation, 1);
        }

        /// <summary>
        /// Updating once a second
        /// </summary>
        private void UpdatePopulation()
        {
            CalculateLocalPopulationGrowthMod();
            CalculateGlobalPopulationGrowthMod();
            CalculateLocalPopulation();
            CalculateGlobalPopulation();
            TimerManager.Instance.AddTimer(UpdatePopulation, 1);
        }

        private void CalculateGlobalPopulation()
        {
            CurrentGlobalPopulation *= PopulationGrowthFactor * CurrentGlobalPopulationGrowthMod;
        }

        private void CalculateLocalPopulation()
        {
            CurrentLocalPopulation *= PopulationGrowthFactor * CurrentLocalPopulationGrowthMod;
        }

        private void CalculateGlobalPopulationGrowthMod()
        {
            foreach (Data currentData in data)
            {
                if (currentData.isResearched)
                    CurrentGlobalPopulationGrowthMod += currentData.globalPopulationGrowthMod;
                if (currentData.isActive)
                    CurrentGlobalPopulationGrowthMod += currentData.amount * currentData.globalPopulationGrowthMod;
            }
        }

        private void CalculateLocalPopulationGrowthMod()
        {
            foreach (Data currentData in data)
            {
                if (currentData.isResearched)
                    CurrentLocalPopulationGrowthMod += currentData.localPopulationGrowthMod;
                if (currentData.isActive)
                    CurrentLocalPopulationGrowthMod += currentData.amount * currentData.localPopulationGrowthMod;
            }

        }
    }
}