using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Timers;
using UnityEngine.UI;

namespace Context
{
    /// <Information>
    /// This class is generated with the UML tool from Geoffrey Hendrikx.
    /// Second class is made in the class AIInterface
    /// </Information>
    public partial class AI : MonoBehaviour
    {
        //Has update list
        public static List<Data> HASUPDATE = new List<Data>();
        [SerializeField]
        private AudioManager audioManager;
        public SDGManager SDGManager;
        #region Data CalculationObjects
        public ResearchData researchData;
        public CreativityData creativityData;
        public FundsData fundsData;
        public InfluenceData influenceData;
        public DroneData dronesData;
        public MaterialData materialData;
        public PowerData powerData;
        public DroneData droneData;
        public CalculateSDG SDGCalculate;
        public TrustMeter TrustMeter;
        public ProgressionData progressionData;
        public CorruptionData corruptionData;
        public PerformanceData performanceData;
        #endregion
        [SerializeField]
        private DateTimer dateTimer;

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

        private float approvalReq;
        public float ApprovalReq
        {
            get
            {
                return approvalReq;
            }
            set
            {
                approvalReq = value;
            }
        }

        #region Research
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
        private float influencePoints = 0;
        public float InfluencePoints
        {
            get
            {
                return influencePoints;
            }
            set
            {
                influencePoints = value;
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
        private float dronePoint = 0;
        public float DronePoints
        {
            get
            {
                return dronePoint;
            }
            set
            {
                dronePoint = value;
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
        private float droneGainMod;
        public float DroneGainMod
        {
            get
            {
                return droneGainMod;
            }
            set
            {
                droneGainMod = value;
            }
        }
        #endregion

        #region Material
        private float materialPoints;
        public float MaterialPoints
        {
            get
            {
                return materialPoints;
            }
            set
            {
                materialPoints = value;
            }
        }

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

        #region Power
        private float powerPoints;
        public float PowerPoints
        {
            get
            {
                return powerPoints;
            }
            set
            {
                powerPoints = value;
            }
        }

        private float powerCost;
        public float PowerCost
        {
            get
            {
                return powerCost;
            }
            set
            {
                powerCost = value;
            }
        }

        private float powerGain;
        public float PowerGain
        {
            get
            {
                return powerGain;
            }
            set
            {
                powerGain = value;
            }
        }

        private float powerGainMod;
        public float PowerGainMod
        {
            get
            {
                return powerGainMod;
            }
            set
            {
                powerGainMod = value;
            }
        }
        #endregion

        #region SDG

        #region SDGPoint
        [SerializeField]
        private float SDGBeginValue = 3;
        [HideInInspector]
        public float SDGPoints01;
        [HideInInspector]
        public float SDGPoints02;
        [HideInInspector]
        public float SDGPoints03;
        [HideInInspector]
        public float SDGPoints04;
        [HideInInspector]
        public float SDGPoints05;
        [HideInInspector]
        public float SDGPoints06;
        [HideInInspector]
        public float SDGPoints07;
        [HideInInspector]
        public float SDGPoints08;
        [HideInInspector]
        public float SDGPoints09;
        [HideInInspector]
        public float SDGPoints10;
        [HideInInspector]
        public float SDGPoints11;
        [HideInInspector]
        public float SDGPoints12;
        [HideInInspector]
        public float SDGPoints13;
        [HideInInspector]
        public float SDGPoints14;
        [HideInInspector]
        public float SDGPoints15;
        [HideInInspector]
        public float SDGPoints16;
        [HideInInspector]
        public float SDGPoints17;
        #endregion
        #region SDGProgress
        [HideInInspector]
        public float SDGProgress01;
        [HideInInspector]
        public float SDGProgress02;
        [HideInInspector]
        public float SDGProgress03;
        [HideInInspector]
        public float SDGProgress04;
        [HideInInspector]
        public float SDGProgress05;
        [HideInInspector]
        public float SDGProgress06;
        [HideInInspector]
        public float SDGProgress07;
        [HideInInspector]
        public float SDGProgress08;
        [HideInInspector]
        public float SDGProgress09;
        [HideInInspector]
        public float SDGProgress10;
        [HideInInspector]
        public float SDGProgress11;
        [HideInInspector]
        public float SDGProgress12;
        [HideInInspector]
        public float SDGProgress13;
        [HideInInspector]
        public float SDGProgress14;
        [HideInInspector]
        public float SDGProgress15;
        [HideInInspector]
        public float SDGProgress16;
        [HideInInspector]
        public float SDGProgress17;
        [Space(10)]
        #endregion

        #endregion

        #region TrustData
        [Space(20)]
        #region GlobalTrustData
        private float currentGlobalRebelliosAngry;
        public float CurrentGlobalRebelliosAngry
        {
            get
            {
                return currentGlobalRebelliosAngry;
            }
            set
            {
                currentGlobalRebelliosAngry = value;
            }
        }
        public float currentGlobalAngryDislikes;
        public float CurrentGlobalAngryDislikes
        {
            get
            {
                return currentGlobalAngryDislikes;
            }
            set
            {
                currentGlobalAngryDislikes = value;
            }
        }
        public float currentGlobalDislikesNeutral;
        public float CurrentGlobalDislikesNeutral
        {
            get
            {
                return currentGlobalDislikesNeutral;
            }
            set
            {
                currentGlobalDislikesNeutral = value;
            }

        }
        public float currentGlobalNeutralLikes;
        public float CurrentGlobalNeutralLikes
        {
            get
            {
                return currentGlobalNeutralLikes;
            }
            set
            {
                currentGlobalNeutralLikes = value;
            }
        }
        public float currentGlobalLikesLove;
        public float CurrentGlobalLikesLove
        {
            get
            {
                return currentGlobalLikesLove;
            }
            set
            {
                currentGlobalLikesLove = value;
            }
        }
        public float currentGlobalRebelliosControlled;
        public float CurrentGlobalRebelliosControlled
        {
            get
            {
                return currentGlobalRebelliosControlled;
            }
            set
            {
                currentGlobalRebelliosControlled = value;
            }
        }
        public float currentGlobalAngryControlled;
        public float CurrentGlobalAngryControlled
        {
            get
            {
                return currentGlobalAngryControlled;
            }
            set
            {
                currentGlobalAngryControlled = value;
            }
        }
        public float currentGlobalDislikesControlled;
        public float CurrentGlobalDislikesControlled
        {
            get
            {
                return currentGlobalDislikesControlled;
            }
            set
            {
                currentGlobalDislikesControlled = value;
            }
        }
        public float currentGlobalLovesControlled;
        public float CurrentGlobalLovesControlled
        {
            get
            {
                return currentGlobalLovesControlled;
            }
            set
            {
                currentGlobalLovesControlled = value;
            }
        }
        public float currentGloballikesControlled;
        public float CurrentGloballikesControlled
        {
            get
            {
                return currentGloballikesControlled;
            }
            set
            {
                currentGloballikesControlled = value;
            }
        }
        public float currentGlobalNeutralControlled;
        public float CurrentGlobalNeutralControlled
        {
            get
            {
                return currentGlobalNeutralControlled;
            }
            set
            {
                currentGlobalNeutralControlled = value;
            }
        }
            #endregion
        
        [Space(10)]

        #region SvTrustData
        [HideInInspector]
        public float CurrentSvRebelliosAngry;
        [HideInInspector]
        public float CurrentSvAngryDislikes;
        [HideInInspector]
        public float CurrentSvDislikesNeutral;
        [HideInInspector]
        public float CurrentSvNeutralLikes;
        [HideInInspector]
        public float CurrentSvLikesLove;
        [HideInInspector]
        public float CurrentSvRebelliosControlled;
        [HideInInspector]
        public float CurrentSvAngryControlled;
        [HideInInspector]
        public float CurrentSvDislikesControlled;
        [HideInInspector]
        public float CurrentSvLovesControlled;
        [HideInInspector]
        public float CurrentSvlikesControlled;
        [HideInInspector]
        public float CurrentSvNeutralControlled;
        #endregion

        [Space(10)]

        #region NatTrustData
        [HideInInspector]
        public float CurrentNatRebelliosAngry;
        [HideInInspector]
        public float CurrentNatAngryDislikes;
        [HideInInspector]
        public float CurrentNatDislikesNeutral;
        [HideInInspector]
        public float CurrentNatNeutralLikes;
        [HideInInspector]
        public float CurrentNatLikesLove;
        [HideInInspector]
        public float CurrentNatRebelliosControlled;
        [HideInInspector]
        public float CurrentNatAngryControlled;
        [HideInInspector]
        public float CurrentNatDislikesControlled;
        [HideInInspector]
        public float CurrentNatLovesControlled;
        [HideInInspector]
        public float CurrentNatlikesControlled;
        [HideInInspector]
        public float CurrentNatNeutralControlled;
        #endregion

        [Space(10)]

        #region LocalTrustData
        [HideInInspector]
        public float CurrentLocalRebelliosAngry;
        [HideInInspector]
        public float CurrentLocalAngryDislikes;
        [HideInInspector]
        public float CurrentLocalDislikesNeutral;
        [HideInInspector]
        public float CurrentLocalNeutralLikes;
        [HideInInspector]
        public float CurrentLocalLikesLove;
        [HideInInspector]
        public float CurrentLocalRebelliosControlled;
        [HideInInspector]
        public float CurrentLocalAngryControlled;
        [HideInInspector]
        public float CurrentLocalDislikesControlled;
        [HideInInspector]
        public float CurrentLocalLovesControlled;
        [HideInInspector]
        public float CurrentLocallikesControlled;
        [HideInInspector]
        public float CurrentLocalNeutralControlled;
        #endregion
        [Space(10)]

        //Gecombineerd met rebelious hates dialikes neutral likes loves controlled
        #region Score
        [HideInInspector]
        public float GlobalRebelliousScore, GlobalHatesScore, GlobalDisLikesScore,GlobalNeutralScore,GlobalLikesScore, GlobalLoveScore, GlobalControlledScore;
        [HideInInspector]
        public float LocalRebelliousScore, LocalHatesScore, LocalDisLikesScore,LocalNeutralScore,LocalLikesScore, LocalLovesScore, LocalControlledScore;
        [HideInInspector]
        public float NationalRebelliousScore, NationalHatesScore, NationalDisLikesScore, NationalNeutralScore, NationalLikesScore, NationalLoveScore, NationalControlledScore;
        [HideInInspector]
        public float SvRebelliousScore, SvHatesScore, SvDisLikesScore, SvNeutralScore, SvLikesScore, SvLoveScore, SvControlledScore;
        [HideInInspector]
        public float GlobalScoreTotal, LocalScoreTotal, NationalScoreTotal, SvScoreTotal;
        [HideInInspector]
        public float GlobalRebeliousPercentage, GlobalHatesPercentage, GlobalDislikesPercentage, GlobalNeutralPercentage, GlobalLikesPercentage, GlobalLovesPercentage, GlobalControlledPercentage;
        [HideInInspector]
        public float LocalRebeliousPercentage, LocalHatesPercentage, LocalDislikesPercentage, LocalNeutralPercentage, LocalLikesPercentage, LocalLovesPercentage, LocalControlledPercentage;
        [HideInInspector]
        public float NationalRebeliousPercentage, NationalHatesPercentage, NationalDislikesPercentage, NationalNeutralPercentage, NationalLikesPercentage, NationalLovesPercentage, NationalControlledPercentage;
        [HideInInspector]
        public float SvRebeliousPercentage, SvHatesPercentage, SvDislikesPercentage, SvNeutralPercentage, SvLikesPercentage, SvLovesPercentage, SvControlledPercentage;
        [HideInInspector]
        public float GlobalApprovesPercentage, GlobalDisapprovesPercentage;
        [HideInInspector]
        public float LocalApprovesPercentage, LocalDisapprovesPercentage;
        [HideInInspector]
        public float NationalApprovesPercentage, NationalDisapprovesPercentage;
        [HideInInspector]
        public float SvApprovesPercentage, SvDisapprovesPercentage;
        #endregion
        #endregion

        #region Debug Variable
        [HideInInspector]
        public float CurrentResearchGainMod;
        [HideInInspector]
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
            //name.text = PlayerPrefs.GetString("Name");
            UpgradeAbilities.ALLOCATIONPOOL = GameManager.Instance.UIManager.CalculateAllocationMod();
            UpgradeAbilities.TEMPALLOCATIONPOOL = GameManager.Instance.UIManager.CalculateAllocationMod();
            AddTimer();
            UpdateUI();
            turnButton.onClick.AddListener(() => Processing());
            turnButton.onClick.AddListener(() => TimerManager.Instance.AddTimer(Processing2, 3f));
        }

        private void Update()
        {
            if (addPoints)
                AddTimer();
            UpdateUI();

            if (SetTurn)
            {
                UpgradeAbilities.ALLOCATIONPOOL = GameManager.Instance.UIManager.CalculateAllocationMod();
                SetTurn = false;
            }
        }



        private void AddTimer()
        {
            addPoints = false;
            TimerManager.Instance.AddTimer(() => { addPoints = !addPoints; }, 1);
        }

        public void GetUpdate(Data data)
        {
            data.isResearched = true;

            #region Calculate Resources

            //Calculate points
            float temp1 = ResearchPoints + data.researchCost/* - data.researchFixedGain*/;
            float temp2 = CreativityPoints + data.creativityCost/* - data.creativityFixedGain*/;
            float temp3 = fundsPoints + data.fundsCost /*- data.fundsFixedGain*/;
            float temp4 = InfluencePoints + data.influenceCost /*- data.influenceFixedGain*/;
            float temp5 = DronePoints + data.droneCost/* - data.droneFixedGain*/;
            float temp6 = materialPoints + data.materialCost /*- data.materialFixedGain*/;
            float temp7 = powerPoints + data.powerCost;
            if (temp1 >= ResearchLimit)
                temp1 = ResearchLimit;
           
            #region without lerp ugly as hell
            //ResearchPoints -= data.researchCost - data.researchFixedGain;
            //CreativityPoints -= data.creativityCost - data.creativityFixedGain;
            //FundsPoints -= data.fundsCost - data.fundsFixedGain;
            //InfluencePoints -= data.influenceCost - data.influenceFixedGain;
            //DroneCost -= data.droneCost - data.droneFixedGain;
            //MaterialCost -= data.materialCost - data.materialFixedGain;
            #endregion

            //time lerping = .5f
            //(Time.time - startTime) / overtime 
            StartCoroutine(LerpResources(1, temp1, temp2, temp3,temp4,temp5,temp6,temp7));

            #endregion

            UpgradeAbilities.TEMPALLOCATIONPOOL += data.allocatieFixedGain;
            UpgradeAbilities.ALLOCATIONPOOL += data.allocatieFixedGain;

            UpdateUI();

            if (ResearchPoints >= researchData.CurrentResearchLimit)
                ResearchPoints = researchData.CurrentResearchLimit;

            HASUPDATE.Add(data);
        }

        public void RemoveUpdate(Data data)
        {
            data.isResearched = false;

            #region Calculate Resources

            //Calculate points
            float temp1 = ResearchPoints - data.researchCost/* - data.researchFixedGain*/;
            float temp2 = CreativityPoints - data.creativityCost/* - data.creativityFixedGain*/;
            float temp3 = fundsPoints - data.fundsCost /*- data.fundsFixedGain*/;
            float temp4 = InfluencePoints - data.influenceCost /*- data.influenceFixedGain*/;
            float temp5 = DronePoints - data.droneCost/* - data.droneFixedGain*/;
            float temp6 = materialPoints - data.materialCost /*- data.materialFixedGain*/;
            float temp7 = powerPoints - data.powerCost;

            if (temp1 >= ResearchLimit)
                temp1 = ResearchLimit;

            StartCoroutine(LerpResources(1, temp1, temp2, temp3, temp4, temp5, temp6, temp7));

            #endregion

            UpgradeAbilities.TEMPALLOCATIONPOOL -= data.allocatieFixedGain;
            UpgradeAbilities.ALLOCATIONPOOL -= data.allocatieFixedGain;

            UpdateUI();

            if (ResearchPoints >= researchData.CurrentResearchLimit)
                ResearchPoints = researchData.CurrentResearchLimit;

            HASUPDATE.Add(data);
        }
    }
}
