using System;
using UnityEngine;
using UnityEngine.Timers;

namespace Context
{
    public class GlobalTrustData :MonoBehaviour
    {
        private Data[] data;
        [SerializeField]
        private IOManager iOManager;
        [SerializeField]
        private AI ai;
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

        public float CurrentGlobalTrustGain;

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
            CalculateRebelliosTrust();
            CalculateAngryDislikes();
            CalculateDislikesNeutral();
            CalculateNeutralLikes();
            CalculateLikesLoves();
            CalculateLovesControlled();
            CalculateRebelliosControlled();
            CalculateAngryControlled();
            CalculateDislikesControlled();
            CalculateNeutralControlled();
            CalculateLikesControlled();

            TimerManager.Instance.AddTimer(UpdateTrust, 1);
        }

        private void CalculateLikesControlled()
        {
            currentLikesControlled = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentLikesControlled += currentData.globalLikesControlled;

            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                    currentLikesControlled += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.globalLikesControlled;

            ai.CurrentGloballikesControlled = currentLikesControlled;
        }

        private void CalculateNeutralControlled()
        {
            currentNeutralControlled = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentNeutralControlled += currentData.globalNeutralControlled;

            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                    currentNeutralControlled += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.globalNeutralControlled;

            ai.CurrentGlobalNeutralControlled = currentNeutralControlled;
        }

        private void CalculateDislikesControlled()
        {
            currentDislikesControlled = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentDislikesControlled += currentData.globalDislikesControlled;

            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                    currentDislikesControlled += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.globalDislikesControlled;

            ai.CurrentGlobalDislikesControlled = currentDislikesControlled;
        }

        private void CalculateAngryControlled()
        {
            currentAngryControlled = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentAngryControlled += currentData.globalAngryControlled;

            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                    currentAngryControlled += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.globalAngryControlled;

            ai.CurrentGlobalAngryControlled = currentAngryControlled;
        }

        private void CalculateRebelliosControlled()
        {
            currentRebelliosControlled = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentRebelliosControlled += currentData.globalRebelliousControlled;

            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                    currentRebelliosControlled += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.globalRebelliousControlled;

            ai.CurrentGlobalRebelliosControlled = currentRebelliosControlled;
        }

        private void CalculateLovesControlled()
        {
            currentLovesControlled = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentLovesControlled += currentData.globalLikesControlled;

            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                    currentLovesControlled += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.globalLikesControlled;

            ai.CurrentGlobalLovesControlled = currentLovesControlled;
        }

        private void CalculateLikesLoves()
        {
            currentLikesLoves = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentLikesLoves += currentData.globalLikesLoves;

            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                    currentLikesLoves += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.globalLikesLoves;

            ai.CurrentGlobalLikesLove = currentLikesLoves;
        }

        private void CalculateNeutralLikes()
        {
            currentNeutralLikes = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentNeutralLikes += currentData.globalNeutralLikes;

            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                    currentNeutralLikes += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.globalNeutralLikes;

            ai.CurrentGlobalNeutralLikes = currentNeutralLikes;
        }

        private void CalculateDislikesNeutral()
        {
            currentDislikesNeutral = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentDislikesNeutral += currentData.globalDislikesNeutral;

            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                    currentDislikesNeutral += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.globalDislikesNeutral;

            ai.CurrentGlobalDislikesNeutral = currentDislikesNeutral;
        }

        private void CalculateAngryDislikes()
        {
            currentAngryDislikes = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentAngryDislikes += currentData.globalAngryDislikes;

            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                    currentAngryDislikes += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.globalAngryDislikes;

            ai.CurrentGlobalAngryDislikes = currentAngryDislikes;
        }

        private void CalculateRebelliosTrust()
        {
            currentRebelliousAngry = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentRebelliousAngry += currentData.globalRebelliousAngry;

            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
                if (UpgradeAbilities.upgradeAbilities[i].data.typeOfData == 0)
                    currentRebelliousAngry += UpgradeAbilities.upgradeAbilities[i].Points * UpgradeAbilities.upgradeAbilities[i].data.globalRebelliousAngry;

            ai.CurrentGlobalRebelliosAngry = currentRebelliousAngry;
        }
    }

}