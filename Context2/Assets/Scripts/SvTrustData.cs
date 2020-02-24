using UnityEngine;
using UnityEngine.Timers;

namespace Context
{
    public class SvTrustData
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
            TimerManager.Instance.AddTimer(UpdateTrust, 1);
        }
    }

}