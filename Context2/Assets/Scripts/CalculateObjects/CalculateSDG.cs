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

        public static float SDGBASELOG = 1.5f;
        public static float SDGDECAY = 0.002f;

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

        public void UpdateSDGWithoutPoints()
        {
            CalculateSDGGain();
            CalculateSDGProgress();
        }

        private void CalculateSDGProgress()
        {
            ai.SDGProgress01 = Mathf.Clamp((Mathf.Log(ai.SDGPoints01, SDGBASELOG) / 10), 0, 1);
            ai.SDGProgress02 = Mathf.Clamp((Mathf.Log(ai.SDGPoints02, SDGBASELOG) / 10), 0, 1);
            ai.SDGProgress03 = Mathf.Clamp((Mathf.Log(ai.SDGPoints03, SDGBASELOG) / 10), 0, 1);
            ai.SDGProgress04 = Mathf.Clamp((Mathf.Log(ai.SDGPoints04, SDGBASELOG) / 10), 0, 1);
            ai.SDGProgress05 = Mathf.Clamp((Mathf.Log(ai.SDGPoints05, SDGBASELOG) / 10), 0, 1);
            ai.SDGProgress06 = Mathf.Clamp((Mathf.Log(ai.SDGPoints06, SDGBASELOG) / 10), 0, 1);
            ai.SDGProgress07 = Mathf.Clamp((Mathf.Log(ai.SDGPoints07, SDGBASELOG) / 10), 0, 1);
            ai.SDGProgress08 = Mathf.Clamp((Mathf.Log(ai.SDGPoints08, SDGBASELOG) / 10), 0, 1);
            ai.SDGProgress09 = Mathf.Clamp((Mathf.Log(ai.SDGPoints09, SDGBASELOG) / 10), 0, 1);
            ai.SDGProgress10 = Mathf.Clamp((Mathf.Log(ai.SDGPoints10, SDGBASELOG) / 10), 0, 1);
            ai.SDGProgress11 = Mathf.Clamp((Mathf.Log(ai.SDGPoints11, SDGBASELOG) / 10), 0, 1);
            ai.SDGProgress12 = Mathf.Clamp((Mathf.Log(ai.SDGPoints12, SDGBASELOG) / 10), 0, 1);
            ai.SDGProgress13 = Mathf.Clamp((Mathf.Log(ai.SDGPoints13, SDGBASELOG) / 10), 0, 1);
            ai.SDGProgress14 = Mathf.Clamp((Mathf.Log(ai.SDGPoints14, SDGBASELOG) / 10), 0, 1);
            ai.SDGProgress15 = Mathf.Clamp((Mathf.Log(ai.SDGPoints15, SDGBASELOG) / 10), 0, 1);
            ai.SDGProgress16 = Mathf.Clamp((Mathf.Log(ai.SDGPoints16, SDGBASELOG) / 10), 0, 1);
            ai.SDGProgress17 = Mathf.Clamp((Mathf.Log(ai.SDGPoints17, SDGBASELOG) / 10), 0, 1);
        }

        public void CalculateSDGPoints()
        {
            SDGBar[] sdgBar = ai.SDGManager.SDGBar;

            if (!sdgBar[0].LockImage[0].gameObject.activeInHierarchy)
                ai.SDGPoints01 += CurrentSDGChange01 - (SDGDECAY * ai.SDGPoints01);
            if (!sdgBar[1].LockImage[0].gameObject.activeInHierarchy)
                ai.SDGPoints02 += CurrentSDGChange02 - (SDGDECAY * ai.SDGPoints02);
            if (!sdgBar[2].LockImage[0].gameObject.activeInHierarchy)
                ai.SDGPoints03 += CurrentSDGChange03 - (SDGDECAY * ai.SDGPoints03);
            if (!sdgBar[3].LockImage[0].gameObject.activeInHierarchy)
                ai.SDGPoints04 += CurrentSDGChange04 - (SDGDECAY * ai.SDGPoints04);
            if (!sdgBar[4].LockImage[0].gameObject.activeInHierarchy)
                ai.SDGPoints05 += CurrentSDGChange05 - (SDGDECAY * ai.SDGPoints05);
            if (!sdgBar[5].LockImage[0].gameObject.activeInHierarchy)
                ai.SDGPoints06 += CurrentSDGChange06 - (SDGDECAY * ai.SDGPoints06);
            if (!sdgBar[6].LockImage[0].gameObject.activeInHierarchy)
                ai.SDGPoints07 += CurrentSDGChange07 - (SDGDECAY * ai.SDGPoints07);
            if (!sdgBar[7].LockImage[0].gameObject.activeInHierarchy)
                ai.SDGPoints08 += CurrentSDGChange08 - (SDGDECAY * ai.SDGPoints08);
            if (!sdgBar[8].LockImage[0].gameObject.activeInHierarchy)
                ai.SDGPoints09 += CurrentSDGChange09 - (SDGDECAY * ai.SDGPoints09);
            if (!sdgBar[9].LockImage[0].gameObject.activeInHierarchy)
                ai.SDGPoints10 += CurrentSDGChange10 - (SDGDECAY * ai.SDGPoints10);
            if (!sdgBar[10].LockImage[0].gameObject.activeInHierarchy)
                ai.SDGPoints11 += CurrentSDGChange11 - (SDGDECAY * ai.SDGPoints11);
            if (!sdgBar[11].LockImage[0].gameObject.activeInHierarchy)
                ai.SDGPoints12 += CurrentSDGChange12 - (SDGDECAY * ai.SDGPoints12);
            if (!sdgBar[12].LockImage[0].gameObject.activeInHierarchy)
                ai.SDGPoints13 += CurrentSDGChange13 - (SDGDECAY * ai.SDGPoints13);
            if (!sdgBar[13].LockImage[0].gameObject.activeInHierarchy)
                ai.SDGPoints14 += CurrentSDGChange14 - (SDGDECAY * ai.SDGPoints14);
            if (!sdgBar[14].LockImage[0].gameObject.activeInHierarchy)
                ai.SDGPoints15 += CurrentSDGChange15 - (SDGDECAY * ai.SDGPoints15);
            if (!sdgBar[15].LockImage[0].gameObject.activeInHierarchy)
                ai.SDGPoints16 += CurrentSDGChange16 - (SDGDECAY * ai.SDGPoints16);
            if (!sdgBar[16].LockImage[0].gameObject.activeInHierarchy)
                ai.SDGPoints17 += CurrentSDGChange17 - (SDGDECAY * ai.SDGPoints17);
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
                if (data.isResearched)
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

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                {
                    CurrentSDGChange01 += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.sdgChange01;
                    CurrentSDGChange02 += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.sdgChange02;
                    CurrentSDGChange03 += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.sdgChange03;
                    CurrentSDGChange04 += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.sdgChange04;
                    CurrentSDGChange05 += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.sdgChange05;
                    CurrentSDGChange06 += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.sdgChange06;
                    CurrentSDGChange07 += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.sdgChange07;
                    CurrentSDGChange08 += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.sdgChange08;
                    CurrentSDGChange09 += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.sdgChange09;
                    CurrentSDGChange10 += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.sdgChange10;
                    CurrentSDGChange11 += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.sdgChange11;
                    CurrentSDGChange12 += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.sdgChange12;
                    CurrentSDGChange13 += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.sdgChange13;
                    CurrentSDGChange14 += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.sdgChange14;
                    CurrentSDGChange15 += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.sdgChange15;
                    CurrentSDGChange16 += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.sdgChange16;
                    CurrentSDGChange17 += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.sdgChange17;
                }
        }
    }
}
