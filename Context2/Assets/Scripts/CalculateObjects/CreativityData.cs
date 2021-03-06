﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;

namespace Context
{
    public class CreativityData : MonoBehaviour
    {
        private Data[] data;
        [SerializeField]
        private IOManager ioManager;
        [HideInInspector]
        public float CurrentCreativityPoints;
        [HideInInspector]
        public float CurrentCreativityGain;
        [HideInInspector]
        public float CurrentCreativityGainMod = 1;
        [SerializeField]
        private AI ai;


        // Start is called before the first frame update
        private void Start()
        {
            data = ioManager.data.Data;
        }

        public void UpdateCreativity()
        {
            CalculateCreativityGainMod();
            CalculateCreativityGain();
            CalculateCreativityPoints();
        }

        public void UpdateCreativityWithoutPoints()
        {
            CalculateCreativityGainMod();
            CalculateCreativityGain();
        }

        private void CalculateCreativityPoints()
        {
            CurrentCreativityPoints = ai.CreativityPoints + CurrentCreativityGain;
            float temp1 = ai.CreativityPoints + CurrentCreativityGain;
            StartCoroutine(ai.LerpResources(1,Mathf.Infinity,temp1,Mathf.Infinity,Mathf.Infinity,Mathf.Infinity,Mathf.Infinity, Mathf.Infinity));
        }

        private void CalculateCreativityGainMod()
        {
            CurrentCreativityGainMod = 1;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentCreativityGainMod += currentData.creativityGainMod;
            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    CurrentCreativityGainMod += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.creativityGainMod;

            ai.CreativityGainMod = CurrentCreativityGainMod;
        }

        private void CalculateCreativityGain()
        {
            CurrentCreativityGain = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentCreativityGain += currentData.creativityGain;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    CurrentCreativityGain += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.creativityGain;
            CurrentCreativityGain *= CurrentCreativityGainMod;

            ai.CreativityGain = CurrentCreativityGain;
        }

        private IEnumerator UpdateCreativityData(float overTime, float newCreativityPoints, float newCreativityGain, float newCreativityGainMod)
        {
            float startTime = Time.time;
            float creativityPoints = ai.CreativityPoints;
            float creativityGain = ai.CreativityGain;
            float creativityGainMod = ai.CreativityGainMod;

            while(Time.time < (startTime + overTime))
            {
                ai.CreativityPoints = Mathf.Lerp(creativityPoints, newCreativityPoints, (Time.time - startTime) / overTime);
                ai.CreativityGain = Mathf.Lerp(creativityGain, newCreativityGain, (Time.time - startTime) / overTime);
                ai.CreativityGainMod = Mathf.Lerp(creativityGainMod, newCreativityGainMod, (Time.time - startTime) / overTime);

                yield return null;
                //(Time.time - startTime) / overtime
            }
            yield return null;
        }
    }
}