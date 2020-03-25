using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Context
{
    public class PerformanceData : MonoBehaviour
    {
        private Data[] data;
        [SerializeField]
        private IOManager ioManager;

        private float currentPerformance;
        public float CurrentPerformance
        {
            get
            {
                return currentPerformance;
            }
            set
            {
                currentPerformance = value;
            }
        }

        [SerializeField]
        private AI ai;

        // Start is called before the first frame update
        void Start() =>
            data = ioManager.data.Data;

        public void CalculatePerformance()
        {
            currentPerformance = ai.AIFitnessScore.fillAmount * 10;
            Debug.Log(ai.AIFitnessScore.fillAmount);
            AudioManager.Instance.SetParameters(currentPerformance, -999, -999, -999, GameManager.Instance.StudioParameterBGM);
        }

    }
}