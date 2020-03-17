using UnityEngine;
namespace Context
{
    public class MaterialData : MonoBehaviour
    {
        private Data[] data;
        [SerializeField]
        private IOManager ioManager;
        [HideInInspector]
        public float CurrentMaterialPoints;
        [HideInInspector]
        public float CurrentMaterialGain;
        [HideInInspector]
        public float CurrentMaterialGainMod = 1;
        [SerializeField]
        private AI ai;


        // Start is called before the first frame update
        private void Start()
        {
            data = ioManager.data.Data;
        }

        public void UpdateMaterial()
        {
            CalculateMaterialGainMod();
            CalculateMaterialGain();
            CalculateMaterialPoints();
        }

        public void UpdateMaterialWithoutPoints()
        {
            CalculateMaterialGainMod();
            CalculateMaterialGain();
        }

        private void CalculateMaterialPoints()
        {
            float temp1 = ai.CreativityPoints + CurrentMaterialGain;
            StartCoroutine(ai.LerpResources(1, Mathf.Infinity, Mathf.Infinity, Mathf.Infinity, Mathf.Infinity, Mathf.Infinity, temp1,Mathf.Infinity));

        }

        private void CalculateMaterialGainMod()
        {
            CurrentMaterialGainMod = 1;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentMaterialGainMod += currentData.materialGainMod;
            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    CurrentMaterialGainMod += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.materialGainMod;

            ai.MaterialGainMod = CurrentMaterialGainMod;
        }

        private void CalculateMaterialGain()
        {
            CurrentMaterialGain = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentMaterialGain += currentData.materialGain;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    CurrentMaterialGain += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.materialGain;
            CurrentMaterialGain *= CurrentMaterialGainMod;

            ai.MaterialGain = CurrentMaterialGain;
        }
    }
}