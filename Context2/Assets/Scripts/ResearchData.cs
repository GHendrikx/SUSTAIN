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
        private IOManager ioManager;
        private float researchPoints;
        private float startAmount;
        public float CurrentResearchLimit;
        public float CurrentResearchPoints;
        public float CurrentResearchGain;
        public float CurrentResearchGainMod = 1;
        private AI ai;
        private float researchOffset = 0;


        // Start is called before the first frame update
        void Start()
        {
            data = ioManager.data.Data;
            TimerManager.Instance.AddTimer(UpdateResearch, 1);
        }

        // Update is called once per frame
        void UpdateResearch()
        {
            CalculateResearchGainMod();
            CalculateResearchGain();
            CalculateResearchPoints();
            CalculateResearchLimit();

            TimerManager.Instance.AddTimer(UpdateResearch, 1);
        }

        //TODO: look into this one.
        private void CalculateResearchPoints()
        {
            foreach (Data currentData in data)
            {
                if (!currentData.isUsed)
                {
                    if(currentData.isResearched)
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
            foreach (Data currentData in data)
            {
                if (currentData.isResearched)
                    CurrentResearchGainMod += currentData.researchGainMod;
                if (currentData.isActive)
                    CurrentResearchGainMod += currentData.amount * currentData.researchGainMod;
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