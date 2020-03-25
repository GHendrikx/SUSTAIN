using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Context
{
    public class CorruptionData : MonoBehaviour
    {
        private Data[] data;
        [SerializeField]
        private IOManager ioManager;

        private int currentCorruption;
        public int CurrentCorruption
        {
            get
            {
                return currentCorruption;
            }
            set
            {
                currentCorruption = value;
            }
        }

        void Start() =>
            data = ioManager.data.Data;

        public void CalculateCorruptionGain()
        {
            currentCorruption = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentCorruption += currentData.corruption;

            AudioManager.Instance.SetParameters(-999, -999, currentCorruption, -999, GameManager.Instance.StudioParameterBGM);
        }
    }
}