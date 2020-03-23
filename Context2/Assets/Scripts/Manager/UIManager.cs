using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Context
{
    /// <Information>
    /// This class is generated with the UML tool from Geoffrey Hendrikx.
    /// </Information>
    public class UIManager : MonoBehaviour
    {
        public AI AI;

        [SerializeField]
        private IOManager IOFile;

        [SerializeField]
        private InitializeNewUpgradeButton[] upgradesTabs;

        public void Update()
        {
            for (int i = 0; i < IOFile.data.Data.Length; i++)
            {
                Data data = IOFile.data.Data[i];
                CheckPreReq(data);

                if (data.isAvailable && !data.isShownInGUI)
                    SetNewUpdate(data);
            }
        }

        private void CheckPreReq(Data data)
        {
            if (data.isResearched)
            {
                data.isAvailable = false;
                return;
            }

            if (data.neededPhase > GameManager.CURRENTPHASE)
                return;

            for (int i = 0; i < IOFile.data.Data.Length; i++)
            {
                Data d = IOFile.data.Data[i];

                if (data.techPrereq.Length < 1)
                    continue;
                if(data.techPrereq != null)
                for (int j = 0; j < data.techPrereq.Length; j++)
                {
                    if (data.techPrereq[j] == d.ID)
                    {
                        if (!d.isResearched)
                            return;

                    }
                }
            }
            data.isAvailable = true;

        }

        private void SetNewUpdate(Data data)
        {
            if (data.isResearched)
                return;
            if (data.typeOfData == 5)
                return;
            data.isShownInGUI = true;

            int tabNeeded = data.typeOfData;

            UpdateUI(data, tabNeeded);
        }

        public void UpdateUI(Data data, int tab)
        {
            if (data.typeOfData == 6)
                return;

            if (data.typeOfData == (int)Tab.Allocatie)
                upgradesTabs[data.typeOfData].InitializeNewAllocation(data, AI);
            else if (data.typeOfData == (int)Tab.Construction)
                upgradesTabs[data.typeOfData].InitializeNewConstruction(data, AI);
            else
            {
                Debug.Log(upgradesTabs.Length + " " + data.typeOfData);
                upgradesTabs[data.typeOfData].InitializeNewButton(data, AI);
            }
        }

        public float CalculateAllocationMod(int temp = 0)
        {
            float CurrentAllocatieMod = 1;

            foreach (Data currentData in IOFile.data.Data)
                if (currentData.isResearched)
                    CurrentAllocatieMod += currentData.allocatieCostMod;

            CurrentAllocatieMod -= temp;

            return (CurrentAllocatieMod * CalculateFixedGainAllocation());
        }

        private float CalculateFixedGainAllocation()
        {
            float CurrentFixedGain = 0;

            foreach (Data currentData in IOFile.data.Data)
                if (currentData.isResearched)
                    CurrentFixedGain += currentData.allocatieFixedGain;

            return CurrentFixedGain;
        }
    }

}
