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
        [SerializeField]
        private AudioManager audioManager;
        public SDGManager SDGManager;
        #region data calculationObjects
        public ResearchData researchData;
        public CreativityData creativityData;
        public FundsData fundsData;
        public InfluenceData influenceData;
        public DroneData dronesData;
        public CalculateSDG SDGCalculate;
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
        private float creativityCost;
        public float CreativityPoints
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

        #region Influence
        private float influenceCost;
        public float InfluencePoints
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

        #region SDG

        #region SDGPoint
        private float SDGBeginValue = 4;
        public float SDGPoints01;
        public float SDGPoints02;
        public float SDGPoints03;
        public float SDGPoints04;
        public float SDGPoints05;
        public float SDGPoints06;
        public float SDGPoints07;
        public float SDGPoints08;
        public float SDGPoints09;
        public float SDGPoints10;
        public float SDGPoints11;
        public float SDGPoints12;
        public float SDGPoints13;
        public float SDGPoints14;
        public float SDGPoints15;
        public float SDGPoints16;
        public float SDGPoints17;
        #endregion
        #region SDGProgress
        public float SDGProgress01;
        public float SDGProgress02;
        public float SDGProgress03;
        public float SDGProgress04;
        public float SDGProgress05;
        public float SDGProgress06;
        public float SDGProgress07;
        public float SDGProgress08;
        public float SDGProgress09;
        public float SDGProgress10;
        public float SDGProgress11;
        public float SDGProgress12;
        public float SDGProgress13;
        public float SDGProgress14;
        public float SDGProgress15;
        public float SDGProgress16;
        public float SDGProgress17;
        #endregion

        #endregion

        #region TrustData
        public float GlobalRebelliosAngry;
        public float CurrentGlobalAngryDislikes;
        public float CurrentDislikesNeutral;
        public float CurrentNeutralLikes;
        public float CurrentLikesLove;



        #endregion

        #region Debug Variable
        public float CurrentResearchGainMod;
        public float CurrentDroneGainMod;
        #endregion

        private bool addPoints;

        [HideInInspector]
        public bool SetTurn = false;
        private void Awake()
        {
            SDGPoints01 = SDGBeginValue;
            SDGPoints02 = SDGBeginValue;
            SDGPoints03 = SDGBeginValue;
            SDGPoints04 = SDGBeginValue;
            SDGPoints05 = SDGBeginValue;
            SDGPoints06 = SDGBeginValue;
            SDGPoints07 = SDGBeginValue;
            SDGPoints08 = SDGBeginValue;
            SDGPoints09 = SDGBeginValue;
            SDGPoints10 = SDGBeginValue;
            SDGPoints11 = SDGBeginValue;
            SDGPoints12 = SDGBeginValue;
            SDGPoints13 = SDGBeginValue;
            SDGPoints14 = SDGBeginValue;
            SDGPoints15 = SDGBeginValue;
            SDGPoints16 = SDGBeginValue;
            SDGPoints17 = SDGBeginValue;
        }
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

            #region Calculate Resources
            //Calculate points
            ResearchPoints -= data.researchCost - data.researchFixedGain;
            CreativityPoints -= data.creativityCost - data.creativityFixedGain;
            FundsPoints -= data.fundsCost - data.fundsFixedGain;
            InfluencePoints -= data.influenceCost - data.influenceFixedGain;
            DroneCost -= data.droneCost - data.droneFixedGain;
            MaterialCost -= data.materialCost - data.materialFixedGain;
            #endregion

            UpgradeAbilities.TEMPALLOCATIONPOOL += data.allocatieFixedGain ;
            UpgradeAbilities.ALLOCATIONPOOL += data.allocatieFixedGain;

            UpdateUI();


            #region PlayMusic of the upgrade
            audioManager.PlaySFX((SFXFragments)data.SFX);
            audioManager.PlayBackground((BackgroundFragments)data.backgroundMusic);
            #endregion

            if (ResearchPoints >= researchData.CurrentResearchLimit)
                ResearchPoints = researchData.CurrentResearchLimit;

            HASUPDATE.Add(data);
            processingAmount -= amount;

        }
    }
}
