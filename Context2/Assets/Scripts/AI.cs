using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Timers;

namespace Context
{
    /// <Information>
    /// This class is generated with the UML tool from Geoffrey Hendrikx.
    /// </Information>
    public partial class AI : MonoBehaviour
    {
        //Has update list
        public static List<Data> HASUPDATE = new List<Data>();

        #region data calculationObjects
        public ResearchData researchData;
        public CreativityData creativityData;
        #endregion

        [SerializeField]
        private int processingPoints;
        public int ProcessingPoints
        {
            get
            {
                return processingPoints;
            }
            set
            {
                processingPoints = value;
            }
        }

        public float processingAmount;

        [SerializeField]
        private float researchPoints;
        public float ResearchPoints
        {
            get
            {
                return researchPoints;
            }
            set
            {
                researchPoints = value;
            }
        }

        private int researchLimit;
        public int ResearchLimit
        {
            get
            {
                return researchLimit;
            }
            set
            {
                researchLimit = value;
            }
        }
        private float researchGain;
        public float ResearchGain
        {
            get
            {
                return researchGain;
            }
            set
            {
                researchGain = value;
            }
        }

        private float creativityPoints;
        public float CreativityPoints
        {
            get
            {
                return creativityPoints;
            }
            set
            {
                creativityPoints = value;
            }
        }

        private float creativityGain;
        public float CreativityGain
        {
            get
            {
                return creativityGain;
            }
            set
            {
                creativityGain = value;
            }
        }

        private float creativityGainMod;
        public float CreativityGainMod
        {
            get
            {
                return creativityGainMod;
            }
            set
            {
                creativityGainMod = value;
            }
        }

        #region Debug Variable
        public float CurrentResearchGainMod;
        #endregion
        //if you can add points this bool will become true
        private bool addPoints;
        public bool SetTurn = false;

        private void Start()
        {
            UpgradeAbilities.ALLOCATIONPOOL = GameManager.Instance.UIManager.CalculateAllocationMod();
            UpgradeAbilities.TEMPALLOCATIONPOOL = GameManager.Instance.UIManager.CalculateAllocationMod();
            AddTimer();
            UpdateUI();
        }

        private void Update()
        {
            if (addPoints)
            {
                //only update the points if the prossessing amount is lower than the memorypoints
                if (processingAmount < ResearchPoints)
                    UpdatePoints();

                AddTimer();
            }
            UpdateUI();

            if (SetTurn)
            {
                UpgradeAbilities.ALLOCATIONPOOL = GameManager.Instance.UIManager.CalculateAllocationMod();
                SetTurn = false;
            }
        }

        private void UpdatePoints() 
        {
            processingAmount += researchPoints;
        }

        private void AddTimer()
        {
            addPoints = false;
            TimerManager.Instance.AddTimer(() => { addPoints = !addPoints; }, 1);
        }

        public void GetUpdate(int amount, Data data)
        {
            if (amount > processingAmount)
                return;

            data.isResearched = true;
            researchPoints -= data.researchCost;
            
            UpdateUI();

            //Debug.Log(researchPoints);
            Debug.Log(creativityPoints);

            HASUPDATE.Add(data);
            processingAmount -= amount;

        }
    }
}
