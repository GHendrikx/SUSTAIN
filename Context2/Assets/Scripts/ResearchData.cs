using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;

namespace Context
{
    public class ResearchData : MonoBehaviour
    {
        private Data[] data;
        [SerializeField]
        private IOManager ioManager;
        private float researchPoints;
        private float startAmount;
        public float CurrentResearchLimit;
        public float CurrentResearchPoints;
        public float CurrentResearchGain;
        public float CurrentResearchGainMod = 1;
        [SerializeField]
        private AI ai;
        private float researchOffset = 0;


        // Start is called before the first frame update
        private void Start()
        {
            data = ioManager.data.Data;
        }

        // Update is called once per frame
        public void UpdateResearch()
        {
            CalculateResearchGainMod();
            CalculateResearchGain();
            CalculateResearchPoints();
            CalculateResearchLimit();
        }

        //TODO: look into this one.
        private void CalculateResearchPoints()
        {
            foreach (Data currentData in data)
            {
                if (currentData.isPrototype)
                {
                    if (currentData.isResearched)
                    {
                        researchOffset += currentData.researchCost;
                    }
                    researchOffset += currentData.researchFixedGain * CurrentResearchGainMod;
                    currentData.isUsed = !currentData.isUsed;
                }
            }
            CurrentResearchPoints += CurrentResearchGain;

            CurrentResearchPoints += researchOffset;
        }

        private void CalculateResearchGainMod()
        {
            CurrentResearchGainMod = 1;

            foreach (Data currentData in data)
            {
                if (currentData.isResearched)
                {
                    CurrentResearchGainMod += currentData.researchGainMod;
                }
            }
            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
            {
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                {
                    CurrentResearchGainMod += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.researchGainMod;
                    Debug.Log(UpgradeAbilities.upgradeAbilities[i].Points);
                }
            }
        }

        private void CalculateResearchGain()
        {
            foreach (Data currentData in data)
            {
                if (currentData.isResearched)
                    CurrentResearchGain += currentData.researchGain * CurrentResearchGainMod;
                if (currentData.isActive)
                    CurrentResearchGain += currentData.amount * currentData.researchGain * CurrentResearchGainMod;
            }
        }

        private void CalculateResearchLimit()
        {
            foreach (Data currentData in data)
            {
                if (currentData.isResearched)
                    CurrentResearchLimit += currentData.researchLimit;
                if (currentData.isActive)
                    CurrentResearchLimit += currentData.amount * currentData.researchLimit;

                CurrentResearchLimit += startAmount + ai.MemoryPoints * 1000;
            }
            if (researchPoints >= CurrentResearchLimit)
                researchPoints = CurrentResearchLimit;
        }
    }
}