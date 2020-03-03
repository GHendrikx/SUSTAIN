using UnityEngine;
namespace Context
{
    public class MaterialData
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
            ai.CreativityPoints += CurrentMaterialGain;
        }

        private void CalculateMaterialGainMod()
        {
            CurrentMaterialGainMod = 1;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentMaterialGainMod += currentData.materialGainMod;
            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                    CurrentMaterialGainMod += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.materialGainMod;

            ai.MaterialGainMod = CurrentMaterialGainMod;
        }

        private void CalculateMaterialGain()
        {
            CurrentMaterialGain = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    CurrentMaterialGain += currentData.materialGain;

            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                    CurrentMaterialGain += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.materialGain;
            CurrentMaterialGain *= CurrentMaterialGainMod;

            ai.MaterialGain = CurrentMaterialGain;
        }
    }
}