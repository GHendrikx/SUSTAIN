using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Context
{
    public class CalculateSDG : MonoBehaviour
    {

        [SerializeField]
        private AI ai;

        private Data[] data;
        [SerializeField]
        private IOManager ioManager;
        [SerializeField]
        private SDGManager sdgManager;

        #region CurrentSDGGain variables
        public float CurrentSDGChange01;
        public float CurrentSDGChange02;
        public float CurrentSDGChange03;
        public float CurrentSDGChange04;
        public float CurrentSDGChange05;
        public float CurrentSDGChange06;
        public float CurrentSDGChange07;
        public float CurrentSDGChange08;
        public float CurrentSDGChange09;
        public float CurrentSDGChange10;
        public float CurrentSDGChange11;
        public float CurrentSDGChange12;
        public float CurrentSDGChange13;
        public float CurrentSDGChange14;
        public float CurrentSDGChange15;
        public float CurrentSDGChange16;
        public float CurrentSDGChange17;
        #endregion

        public static float SDGBASELOG = 1.34f;

        // Start is called before the first frame update
        private void Start()
        {
            data = ioManager.data.Data;
        }

        public void UpdateSDG()
        {
            CalculateSDGGain();
            CalculateSDGPoints();
            CalculateSDGProgress();
        }

        private void CalculateSDGProgress()
        {
            ai.SDGProgress01 = Mathf.Log(ai.SDGPoints01, SDGBASELOG) / 10;
            ai.SDGProgress02 = Mathf.Log(ai.SDGPoints02, SDGBASELOG) / 10;
            ai.SDGProgress03 = Mathf.Log(ai.SDGPoints03, SDGBASELOG) / 10;
            ai.SDGProgress04 = Mathf.Log(ai.SDGPoints04, SDGBASELOG) / 10;
            ai.SDGProgress05 = Mathf.Log(ai.SDGPoints05, SDGBASELOG) / 10;
            ai.SDGProgress06 = Mathf.Log(ai.SDGPoints06, SDGBASELOG) / 10;
            ai.SDGProgress07 = Mathf.Log(ai.SDGPoints07, SDGBASELOG) / 10;
            ai.SDGProgress08 = Mathf.Log(ai.SDGPoints08, SDGBASELOG) / 10;
            ai.SDGProgress09 = Mathf.Log(ai.SDGPoints09, SDGBASELOG) / 10;
            ai.SDGProgress10 = Mathf.Log(ai.SDGPoints10, SDGBASELOG) / 10;
            ai.SDGProgress11 = Mathf.Log(ai.SDGPoints11, SDGBASELOG) / 10;
            ai.SDGProgress12 = Mathf.Log(ai.SDGPoints12, SDGBASELOG) / 10;
            ai.SDGProgress13 = Mathf.Log(ai.SDGPoints13, SDGBASELOG) / 10;
            ai.SDGProgress14 = Mathf.Log(ai.SDGPoints14, SDGBASELOG) / 10;
            ai.SDGProgress15 = Mathf.Log(ai.SDGPoints15, SDGBASELOG) / 10;
            ai.SDGProgress16 = Mathf.Log(ai.SDGPoints16, SDGBASELOG) / 10;
            ai.SDGProgress17 = Mathf.Log(ai.SDGPoints17, SDGBASELOG) / 10;
        }

        public void CalculateSDGPoints()
        {
            ai.SDGPoints01 += CurrentSDGChange01;
            ai.SDGPoints02 += CurrentSDGChange02;
            ai.SDGPoints03 += CurrentSDGChange03;
            ai.SDGPoints04 += CurrentSDGChange04;
            ai.SDGPoints05 += CurrentSDGChange05;
            ai.SDGPoints06 += CurrentSDGChange06;
            ai.SDGPoints07 += CurrentSDGChange07;
            ai.SDGPoints08 += CurrentSDGChange08;
            ai.SDGPoints09 += CurrentSDGChange09;
            ai.SDGPoints10 += CurrentSDGChange10;
            ai.SDGPoints11 += CurrentSDGChange11;
            ai.SDGPoints12 += CurrentSDGChange12;
            ai.SDGPoints13 += CurrentSDGChange13;
            ai.SDGPoints14 += CurrentSDGChange14;
            ai.SDGPoints15 += CurrentSDGChange15;
            ai.SDGPoints16 += CurrentSDGChange16;
            ai.SDGPoints17 += CurrentSDGChange17;
            

        }

        public void ResetSDGGain()
        {
            CurrentSDGChange01 = 0;
            CurrentSDGChange02 = 0;
            CurrentSDGChange03 = 0;
            CurrentSDGChange04 = 0;
            CurrentSDGChange05 = 0;
            CurrentSDGChange06 = 0;
            CurrentSDGChange07 = 0;
            CurrentSDGChange08 = 0;
            CurrentSDGChange09 = 0;
            CurrentSDGChange10 = 0;
            CurrentSDGChange11 = 0;
            CurrentSDGChange12 = 0;
            CurrentSDGChange13 = 0;
            CurrentSDGChange14 = 0;
            CurrentSDGChange15 = 0;
            CurrentSDGChange16 = 0;
            CurrentSDGChange17 = 0;
        }

        private void CalculateSDGGain()
        {
            ResetSDGGain();

            foreach (Data data in data)
            {
                if(data.isResearched)
                {
                    CurrentSDGChange01 += data.sdgChange01;
                    CurrentSDGChange02 += data.sdgChange02;
                    CurrentSDGChange03 += data.sdgChange03;
                    CurrentSDGChange04 += data.sdgChange04;
                    CurrentSDGChange05 += data.sdgChange05;
                    CurrentSDGChange06 += data.sdgChange06;
                    CurrentSDGChange07 += data.sdgChange07;
                    CurrentSDGChange08 += data.sdgChange08;
                    CurrentSDGChange09 += data.sdgChange09;
                    CurrentSDGChange10 += data.sdgChange10;
                    CurrentSDGChange11 += data.sdgChange11;
                    CurrentSDGChange12 += data.sdgChange12;
                    CurrentSDGChange13 += data.sdgChange13;
                    CurrentSDGChange14 += data.sdgChange14;
                    CurrentSDGChange15 += data.sdgChange15;
                    CurrentSDGChange16 += data.sdgChange16;
                    CurrentSDGChange17 += data.sdgChange17;
                }
            }

            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                {
                    CurrentSDGChange01 += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.sdgChange01;
                    CurrentSDGChange02 += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.sdgChange02;
                    CurrentSDGChange03 += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.sdgChange03;
                    CurrentSDGChange04 += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.sdgChange04;
                    CurrentSDGChange05 += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.sdgChange05;
                    CurrentSDGChange06 += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.sdgChange06;
                    CurrentSDGChange07 += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.sdgChange07;
                    CurrentSDGChange08 += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.sdgChange08;
                    CurrentSDGChange09 += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.sdgChange09;
                    CurrentSDGChange10 += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.sdgChange10;
                    CurrentSDGChange11 += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.sdgChange11;
                    CurrentSDGChange12 += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.sdgChange12;
                    CurrentSDGChange13 += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.sdgChange13;
                    CurrentSDGChange14 += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.sdgChange14;
                    CurrentSDGChange15 += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.sdgChange15;
                    CurrentSDGChange16 += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.sdgChange16;
                    CurrentSDGChange17 += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.sdgChange17;
                }
        }
    }
}
