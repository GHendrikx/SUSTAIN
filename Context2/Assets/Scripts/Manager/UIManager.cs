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

                for (int j = 0; j < data.techPrereq.Length; j++)
                {
                    if (data.techPrereq[j] == d.ID)
                    {
                        if (!d.isResearched)
                            break;
                        else
                        {
                            data.isAvailable = true;
                            
                            break;
                        }
                    }
                }
            }

        }

        private void SetNewUpdate(Data data)
        {
            if (data.isResearched)
                return;
            data.isShownInGUI = true;
            
            if (data.typeOfData == 5)
                return;

            int tabNeeded = data.typeOfData;
            //Debug.Log(upgradesTabs[data.typeOfData] + " " + data.name);

            UpdateUI(data, tabNeeded);
        }

        public void UpdateUI(Data data, int tab)
        {
            if(data.typeOfData == 1 || data.typeOfData == 2)
                upgradesTabs[data.typeOfData].InitializeNewButton(data, AI);
            else
                upgradesTabs[data.typeOfData].InitializeNewSlider(data, AI);

        }
    }

}
