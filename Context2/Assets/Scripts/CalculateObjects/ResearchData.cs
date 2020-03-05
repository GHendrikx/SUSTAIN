﻿using System;
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
        public float ResearchPoints
        {
            get
            {
                return researchPoints;
            }
            set
            {
                researchPoints = value;
            }
        }
        private float startAmount;
        [HideInInspector]
        public float CurrentResearchLimit;
        [HideInInspector]
        public float CurrentResearchLimitMod;
        [HideInInspector]
        public float CurrentResearchPoints;
        [HideInInspector]
        public float CurrentResearchGain;
        [HideInInspector]
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
            CalculateResearchLimitMod();
            CalculateResearchLimit();
        }
        public void UpdateResearchWithoutPoints()
        {
            CalculateResearchGainMod();
            CalculateResearchGain();
            CalculateResearchLimitMod();
            CalculateResearchLimit();
        }

        //TODO: look into this one.
        private void CalculateResearchPoints()
        {
            ai.ResearchPoints += CurrentResearchGain;
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
                    CurrentResearchGainMod += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.researchGainMod;
            }
        }

        private void CalculateResearchGain()
        {
            CurrentResearchGain = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentResearchGain += currentData.researchGain;
            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                    CurrentResearchGain += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.researchGain;
            CurrentResearchGain *= CurrentResearchGainMod;
        }

        private void CalculateResearchLimit()
        {
            CurrentResearchLimit = 0;
            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentResearchLimit += currentData.researchLimit;
            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                    CurrentResearchLimit += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.researchLimit;
            CurrentResearchLimit *= CurrentResearchLimitMod;

            if (ai.ResearchPoints >= CurrentResearchLimit)
                ai.ResearchPoints = CurrentResearchLimit;

            ai.ResearchLimit = System.Convert.ToInt32(CurrentResearchLimit);
            ai.ResearchGain = CurrentResearchGain;
            ai.CurrentResearchGainMod = CurrentResearchGainMod;
        }

        private void CalculateResearchLimitMod()
        {
            CurrentResearchLimitMod = 1;
            
            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentResearchLimitMod += currentData.researchLimitMod;
            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                    CurrentResearchLimitMod += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.researchLimitMod;
        }
    }
}