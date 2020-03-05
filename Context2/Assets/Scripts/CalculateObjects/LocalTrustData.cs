using System;
using UnityEngine;
using UnityEngine.Timers;

namespace Context
{
    public class LocalTrustData
    {
        private Data[] data;
        [SerializeField]
        private IOManager iOManager;

        #region all Variables
        private float currentRebelliousAngry;
        private float currentAngryDislikes;
        private float currentDislikesNeutral;
        private float currentNeutralLikes;
        private float currentLikesLoves;
        private float currentLovesControlled;
        private float currentRebelliosControlled;
        private float currentAngryControlled;
        private float currentDislikesControlled;
        private float currentNeutralControlled;
        private float currentLikesControlled;
        #endregion

        private void Start()
        {
            TimerManager.Instance.AddTimer(UpdateTrust, 1);
        }

        private void UpdateTrust()
        {

            CalculateLocalTrust();
            TimerManager.Instance.AddTimer(UpdateTrust, 1);
        }

        private void CalculateLocalTrust()
        {
            foreach (Data currentData in data)
            {
                if (currentData.isResearched)
                    currentRebelliousAngry += currentData.localRebelliousAngry;
                if (currentData.isActive)
                    currentRebelliousAngry += currentData.amount * currentData.localRebelliousAngry;

                if (currentData.isResearched)
                    currentAngryDislikes += currentData.globalAngryDislikes;
                if (currentData.isActive)
                    currentAngryDislikes += currentData.amount * currentData.globalAngryDislikes;

                if (currentData.isResearched)
                    currentDislikesNeutral += currentData.localDislikesNeutral;
                if (currentData.isActive)
                    currentDislikesNeutral += currentData.amount * currentData.localDislikesNeutral;

                if (currentData.isResearched)
                    currentNeutralLikes += currentData.localNeutralLikes;
                if (currentData.isActive)
                    currentNeutralLikes += currentData.amount * currentData.localNeutralLikes;

                if (currentData.isResearched)
                    currentLikesLoves += currentData.localLikesLoves;
                if (currentData.isActive)
                    currentLikesLoves += currentData.amount * currentData.localLikesLoves;

                if (currentData.isResearched)
                    currentLovesControlled += currentData.localLovesControlled;
                if (currentData.isActive)
                    currentLovesControlled += currentData.amount * currentData.localLovesControlled;

                if (currentData.isResearched)
                    currentRebelliosControlled += currentData.localRebelliousControlled;
                if (currentData.isActive)
                    currentRebelliosControlled += currentData.amount * currentData.localRebelliousControlled;

                if (currentData.isResearched)
                    currentAngryControlled += currentData.localAngryControlled;
                if (currentData.isActive)
                    currentAngryControlled += currentData.amount * currentData.localAngryControlled;

                if (currentData.isResearched)
                    currentDislikesControlled += currentData.localDislikesControlled;
                if (currentData.isActive)
                    currentDislikesControlled += currentData.amount * currentData.localDislikesControlled;

                if (currentData.isResearched)
                    currentNeutralControlled += currentData.localNeutralControlled;
                if (currentData.isActive)
                    currentNeutralControlled += currentData.amount * currentData.localNeutralControlled;

                if (currentData.isResearched)
                    currentLikesControlled += currentData.localLikesControlled;
                if (currentData.isActive)
                    currentLikesControlled += currentData.amount * currentData.localLikesControlled;
            }
        }
    }

}