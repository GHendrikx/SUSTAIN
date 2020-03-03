using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Context
{
    public class CalculateSDG : MonoBehaviour
    {
        public List<float> sdgChange = new List<float>();

        // Start is called before the first frame update
        private void Start()
        {
            for (int i = 0; i < 18; i++)
                sdgChange.Add(0);
        }

        void UpdateSDGS()
        {
            List<UpgradeAbilities> upgradeAbilities = UpgradeAbilities.upgradeAbilities;
            foreach (UpgradeAbilities abilities in upgradeAbilities)
            {
                Data data = abilities.data;

                if(abilities.data.isResearched)
                {
                    sdgChange[0] += data.sdgChange00;
                    sdgChange[1] += data.sdgChange01;
                    sdgChange[2] += data.sdgChange02;
                    sdgChange[3] += data.sdgChange03;
                    sdgChange[4] += data.sdgChange04;
                    sdgChange[5] += data.sdgChange05;
                    sdgChange[6] += data.sdgChange06;
                    sdgChange[7] += data.sdgChange07;
                    sdgChange[8] += data.sdgChange08;
                    sdgChange[9] += data.sdgChange09;
                    sdgChange[10] += data.sdgChange10;
                    sdgChange[11] += data.sdgChange11;
                    sdgChange[12] += data.sdgChange12;
                    sdgChange[13] += data.sdgChange13;
                    sdgChange[14] += data.sdgChange14;
                    sdgChange[15] += data.sdgChange15;
                    sdgChange[16] += data.sdgChange16;
                    sdgChange[17] += data.sdgChange17;
                }
            }
        }
    }
}
