using UnityEngine;
using UnityEngine.Timers;

namespace Context
{
    public class GlobalTrustData :MonoBehaviour
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
            data = iOManager.data.Data;
            TimerManager.Instance.AddTimer(UpdateTrust, 1);
        }

        /// <summary>
        /// Updating once a second
        /// </summary>
        private void UpdateTrust()
        {
            CalculateGlobalTrust();
            TimerManager.Instance.AddTimer(UpdateTrust, 1);
        }

        private void CalculateGlobalTrust()
        {
            foreach (Data currentData in data)
            {
                if (currentData.isResearched)
                    currentRebelliousAngry += currentData.globalRebelliousAngry;
                if (currentData.isActive)
                    currentRebelliousAngry += currentData.amount * currentData.globalRebelliousAngry;

                if (currentData.isResearched)
                    currentAngryDislikes += currentData.globalAngryDislikes;
                if (currentData.isActive)
                    currentAngryDislikes += currentData.amount * currentData.globalAngryDislikes;

                if (currentData.isResearched)
                    currentDislikesNeutral += currentData.globalDislikesNeutral;
                if (currentData.isActive)
                    currentDislikesNeutral += currentData.amount * currentData.globalDislikesNeutral;

                if (currentData.isResearched)
                    currentNeutralLikes += currentData.globalNeutralLikes;
                if (currentData.isActive)
                    currentNeutralLikes += currentData.amount * currentData.globalNeutralLikes;

                if (currentData.isResearched)
                    currentLikesLoves += currentData.globalLikesLoves;
                if (currentData.isActive)
                    currentLikesLoves += currentData.amount * currentData.globalLikesLoves;

                if (currentData.isResearched)
                    currentLovesControlled += currentData.globalLovesControlled;
                if (currentData.isActive)
                    currentLovesControlled += currentData.amount * currentData.globalLovesControlled;

                if (currentData.isResearched)
                    currentRebelliosControlled += currentData.globalRebelliousControlled;
                if (currentData.isActive)
                    currentRebelliosControlled += currentData.amount * currentData.globalRebelliousControlled;

                if (currentData.isResearched)
                    currentAngryControlled += currentData.globalAngryControlled;
                if (currentData.isActive)
                    currentAngryControlled += currentData.amount * currentData.globalAngryControlled;

                if (currentData.isResearched)
                    currentDislikesControlled += currentData.globalDislikesControlled;
                if (currentData.isActive)
                    currentDislikesControlled += currentData.amount * currentData.globalDislikesControlled;

                if (currentData.isResearched)
                    currentNeutralControlled += currentData.globalNeutralControlled;
                if (currentData.isActive)
                    currentNeutralControlled += currentData.amount * currentData.globalNeutralControlled;

                if (currentData.isResearched)
                    currentLikesControlled += currentData.globalLikesControlled;
                if (currentData.isActive)
                    currentLikesControlled += currentData.amount * currentData.globalLikesControlled;
            }
        }
    }

}