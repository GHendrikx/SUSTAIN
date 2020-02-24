using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;

namespace Context
{
    public class FundsData : MonoBehaviour
    {
        private Data[] data;
        private float CurrentFundsGainMod = 1;
        private float CurrentFundsGain;
        private float fundsOffset;
        private double currentFunds;
        [SerializeField]
        private IOManager iOManager;

        // Start is called before the first frame update
        private void Start()
        {
            data = iOManager.data.Data;
            TimerManager.Instance.AddTimer(UpdateFunds, 1);
        }

        /// <summary>
        /// Updating once a second
        /// </summary>
        private void UpdateFunds()
        {
            CalculateFundsGainMod();
            CalculateFundsGain();
            CalculateFunds();


            TimerManager.Instance.AddTimer(UpdateFunds, 1);
        }

        //TODO: Think about this.
        private void CalculateFunds()
        {
            foreach (Data currentData in data)
            {
                if (currentData.isResearched && !currentData.isUsed)
                {
                    fundsOffset += currentData.researchFixedGain * CurrentFundsGainMod;
                    currentData.isUsed = !currentData.isUsed;
                }
            }
            currentFunds += CurrentFundsGain;

            currentFunds += fundsOffset;
        }

        private void CalculateFundsGainMod()
        {
            foreach (Data currentData in data)
            {
                if (currentData.isResearched)
                    CurrentFundsGainMod += currentData.fundsGainMod;
                if (currentData.isActive)
                    CurrentFundsGainMod += currentData.amount * currentData.fundsGainMod;
            }
        }

        private void CalculateFundsGain()
        {
            foreach (Data currentData in data)
            {
                if (currentData.isResearched)
                    CurrentFundsGain += currentData.fundsGain * CurrentFundsGainMod;
                if (currentData.isActive)
                    CurrentFundsGain += currentData.amount * currentData.fundsGain * CurrentFundsGainMod;
            }
        }
    }
}
