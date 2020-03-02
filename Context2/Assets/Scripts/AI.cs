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
        public InfluenceData influenceData;
        public DroneData dronesData;
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

        #region Research
        [SerializeField]
        private float researchCost;
        public float ResearchCost
        {
            get
            {
                return researchCost;
            }
            set
            {
                researchCost = value;
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
        private float creativityCost;
        public float CreativityCost
        {
            get
            {
                return creativityCost;
            }
            set
            {
                creativityCost = value;
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
        private float fundsCost;
        public float FundsCost
        {
            get
            {
                return fundsCost;
            }
            set
            {
                fundsCost = value;
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

        #region Influence
        private float influenceCost;
        public float InfluenceCost
        {
            get
            {
                return influenceCost;
            }
            set
            {
                influenceCost = value;
            }
        }

        private float influenceGain;
        public float InfluenceGain
        {
            get
            {
                return influenceGain;
            }
            set
            {
                influenceGain = value;
            }
        }

        private float influenceGainMod;
        public float InfluenceGainMod
        {
            get
            {
                return influenceGainMod;
            }
            set
            {
                influenceGainMod = value;
            }
        }
        #endregion

        #region Drones

        [SerializeField]
        private float droneCost;
        public float DroneCost
        {
            get
            {
                return droneCost;
            }
            set
            {
                droneCost = value;
            }
        }

        private int droneLimit;
        public int DroneLimit
        {
            get
            {
                return droneLimit;
            }
            set
            {
                droneLimit = value;
            }
        }
        private float droneGain;
        public float DroneGain
        {
            get
            {
                return droneGain;
            }
            set
            {
                droneGain = value;
            }
        }
        #endregion

        #region Material
        private float materialCost;
        public float MaterialCost
        {
            get
            {
                return materialCost;
            }
            set
            {
                materialCost = value;
            }
        }

        private float materialGain;
        public float MaterialGain
        {
            get
            {
                return materialGain;
            }
            set
            {
                materialGain = value;
            }
        }

        private float materialGainMod;
        public float MaterialGainMod
        {
            get
            {
                return materialGainMod;
            }
            set
            {
                materialGainMod = value;
            }
        }
        #endregion


        #region Debug Variable
        public float CurrentResearchGainMod;
        public float CurrentDroneGainMod;
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
                if (processingAmount < ResearchCost)
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
            processingAmount += researchCost;
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

            #region Calculate Resources
            //Calculate points
            ResearchCost -= data.researchCost - data.researchFixedGain;
            CreativityCost -= data.creativityCost - data.creativityFixedGain;
            FundsCost -= data.fundsCost - data.fundsFixedGain;
            InfluenceCost -= data.influenceCost - data.influenceFixedGain;
            DroneCost -= data.droneCost - data.droneFixedGain;
            MaterialCost -= data.materialCost - data.materialFixedGain;
            #endregion

            UpgradeAbilities.TEMPALLOCATIONPOOL += data.allocatieFixedGain ;
            UpgradeAbilities.ALLOCATIONPOOL += data.allocatieFixedGain;

            UpdateUI();

            //Debug.Log(researchPoints);

            if (ResearchCost >= researchData.CurrentResearchLimit)
                ResearchCost = researchData.CurrentResearchLimit;

            HASUPDATE.Add(data);
            processingAmount -= amount;

        }
    }
}
