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
            float temp1 = ai.ResearchPoints + CurrentResearchGain;
            //float temp2 = ai.CreativityPoints;
            //float temp3 = ai.FundsPoints;
            //float temp4 = ai.InfluenceGain;
            //float temp5 = ai.DronePoints;
            //float temp6 = ai.MaterialPoints;
            
            StartCoroutine(ai.LerpResources(1f, temp1,Mathf.Infinity, Mathf.Infinity, Mathf.Infinity, Mathf.Infinity, Mathf.Infinity));
           //ai.ResearchPoints += CurrentResearchGain;
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
            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
            {
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    CurrentResearchGainMod += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.researchGainMod;
            }
        }

        private void CalculateResearchGain()
        {
            CurrentResearchGain = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentResearchGain += currentData.researchGain;
            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    CurrentResearchGain += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.researchGain;
            CurrentResearchGain *= CurrentResearchGainMod;
        }

        private void CalculateResearchLimit()
        {
            CurrentResearchLimit = 0;
            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentResearchLimit += currentData.researchLimit;
            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    CurrentResearchLimit += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.researchLimit;
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
            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    CurrentResearchLimitMod += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.researchLimitMod;
        }
    }
}