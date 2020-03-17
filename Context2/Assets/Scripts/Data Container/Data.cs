namespace Context
{
    [System.Serializable]
    public class Data
    {
        public int ID;
        public string name;
        public string desc;
        public bool isPrototype;
        public int[] sdgType;
        public int typeOfData;
        public int neededPhase;
        public int[] techPrereq;
        public int musicStage;
        public int musicSoundSFX;
        public int musicAdvancement;
        public string effectDesc;
        public int locks;
        public bool isResearched;
        public bool hasTarget;
        public bool isUsed;
        public bool isAvailable;
        public bool isShownInGUI;
        public bool isActive;
        public float approvalReq;
        public int approvalType;
        public int creativityCost;

        public int researchCost;
        public int allocatieCost;
        public int fundsCost;
        public int influenceCost;
        public int materialCost;
        public int droneCost;
        public int powerCost;

        public int doneTimes;
        public int doneGain;
        public string doneDesc;
        public int doneAmount;
        public int doneLevel;
        public int doneTarget;

        public float neededSupervisorTrust;
        public float neededLocalTrust;
        public float neededGlobalTrust;
        public float neededNationalTrust;

        public float sdgChange00;
        public float sdgChange01;
        public float sdgChange02;
        public float sdgChange03;
        public float sdgChange04;
        public float sdgChange05;
        public float sdgChange06;
        public float sdgChange07;
        public float sdgChange08;
        public float sdgChange09;
        public float sdgChange10;
        public float sdgChange11;
        public float sdgChange12;
        public float sdgChange13;
        public float sdgChange14;
        public float sdgChange15;
        public float sdgChange16;
        public float sdgChange17;

        public int amount;

        public float creativityGain;
        public int creativityFixedGain;
        public float creativityGainMod;
        public float influenceGain;
        public int influenceFixedGain;
        public float influenceGainMod;
        public float researchGain;
        public int researchFixedGain;
        public float researchGainMod;
        public int researchLimit;
        public float researchLimitMod;
        public int allocatieFixedGain;
        public int allocatieLimit;
        public int allocatieCostMod;
        public float fundsGain;
        public int fundsFixedGain;
        public float fundsGainMod;
        public int droneGain;
        public int droneFixedGain;
        public float droneGainMod;
        public int droneLimit;
        public float materialGain;
        public int materialFixedGain;
        public float materialGainMod;
        public float powerGain;
        public int powerFixedGain;
        public float powerGainMod;
        public float localRebelliousAngry;
        public float localAngryDislikes;
        public float localDislikesNeutral;
        public float localNeutralLikes;
        public float localLikesLoves;
        public float localLovesControlled;
        public float localRebelliousControlled;
        public float localAngryControlled;
        public float localDislikesControlled;
        public float localNeutralControlled;
        public float localLikesControlled;
        
        public float rebellionRiskMod;
        public int cyberSecurity;
        public float droneStrengthMod;

        public float globalRebelliousAngry;
        public float globalAngryDislikes;
        public float globalDislikesNeutral;
        public float globalNeutralLikes;
        public float globalLikesLoves;
        public float globalLovesControlled;
        public float globalRebelliousControlled;
        public float globalAngryControlled;
        public float globalDislikesControlled;
        public float globalNeutralControlled;
        public float globalLikesControlled;

        public float svRebelliousAngry;
        public float svAngryDislikes;
        public float svDislikesNeutral;
        public float svNeutralLikes;
        public float svLikesLoves;
        public float svLovesControlled;
        public float svRebelliousControlled;
        public float svAngryControlled;
        public float svDislikesControlled;
        public float svNeutralControlled;
        public float svLikesControlled;

        public float localPopulationGrowthMod;
        public float globalPopulationGrowthMod;
        public int housingAmount;
        public float housingEfficiency;

        public float natRebelliousAngry;
        public float natAngryDislikes;
        public float natDislikesNeutral;
        public float natNeutralLikes;
        public float natLikesLoves;
        public float natLovesControlled;
        public float natRebelliousControlled;
        public float natAngryControlled;
        public float natDislikesControlled;
        public float natNeutralControlled;
        public float natLikesControlled;
        public int SFX;
        public int backgroundMusic;
    }
}