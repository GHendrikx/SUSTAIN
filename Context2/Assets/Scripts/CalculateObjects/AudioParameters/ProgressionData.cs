using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Context
{
    public class ProgressionData : MonoBehaviour
    {
        private Data[] data;
        [SerializeField]
        private IOManager ioManager;

        private int currentProgression;
        public int CurrentProgression
        {
            get
            {
                return currentProgression;
            }
            set
            {
                currentProgression = value;
            }
        }

        public void Start() =>
            data = ioManager.data.Data;

        public void CalculateProgressionGain()
        {
            currentProgression = 0;
            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentProgression += currentData.progression;

            AudioManager.Instance.SetParameters(-999, -999, -999, currentProgression, GameManager.Instance.StudioParameterBGM);
        }
    }
}