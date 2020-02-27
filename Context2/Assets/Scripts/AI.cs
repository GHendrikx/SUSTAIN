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
        public FundsData fundsData;
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

        #region ResearchPoints
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
        #endregion

        #region Creativity
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
        #endregion

        #region Funds
        private float fundsPoints;
        public float FundsPoints
        {
            get
            {
                return fundsPoints;
            }
            set
            {
                fundsPoints = value;
            }
        }

        private float fundsGain;
        public float FundsGain
        {
            get
            {
                return fundsGain;
            }
            set
            {
                fundsGain = value;
            }
        }

        private float fundsGainMod;
        public float FundsGainMod
        {
            get
            {
                return fundsGainMod;
            }
            set
            {
                fundsGainMod = value;
            }
        }
        #endregion

        #region Debug Variable
        public float CurrentResearchGainMod;
        #endregion
        private bool addPoints;

        [HideInInspector]
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
            //Calculate points
            ResearchPoints -= data.researchCost - data.researchFixedGain;
            CreativityPoints -= data.creativityCost - data.creativityFixedGain;
            FundsPoints -= data.fundsCost - data.fundsFixedGain;

            UpgradeAbilities.TEMPALLOCATIONPOOL += data.allocatieFixedGain ;
            UpgradeAbilities.ALLOCATIONPOOL += data.allocatieFixedGain;

            UpdateUI();

            //Debug.Log(researchPoints);

            if (ResearchPoints >= researchData.CurrentResearchLimit)
                ResearchPoints = researchData.CurrentResearchLimit;

            HASUPDATE.Add(data);
            processingAmount -= amount;

        }
    }
}
