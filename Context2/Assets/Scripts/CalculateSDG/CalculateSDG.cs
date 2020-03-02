using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Context
{
    public class CalculateSDG : MonoBehaviour
    {
        public List<float> sdgChange;
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
                }
            }
        }
    }
}
