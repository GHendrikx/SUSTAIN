﻿using UnityEngine;
using UnityEngine.Timers;

namespace Context
{
    public class SvTrustData : MonoBehaviour
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
        public void UpdateTrust()
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
                    currentLikesControlled += currentData.svLikesControlled;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    currentLikesControlled += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.svLikesControlled;

            ai.CurrentSvlikesControlled = currentLikesControlled;
        }

        private void CalculateNeutralControlled()
        {
            currentNeutralControlled = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentNeutralControlled += currentData.svNeutralControlled;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    currentNeutralControlled += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.svNeutralControlled;

            ai.CurrentSvNeutralControlled = currentNeutralControlled;
        }

        private void CalculateDislikesControlled()
        {
            currentDislikesControlled = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentDislikesControlled += currentData.svDislikesControlled;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    currentDislikesControlled += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.svDislikesControlled;

            ai.CurrentSvDislikesControlled = currentDislikesControlled;
        }

        private void CalculateAngryControlled()
        {
            currentAngryControlled = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentAngryControlled += currentData.svAngryControlled;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    currentAngryControlled += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.svAngryControlled;

            ai.CurrentSvAngryControlled = currentAngryControlled;
        }

        private void CalculateRebelliosControlled()
        {
            currentRebelliosControlled = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentRebelliosControlled += currentData.svRebelliousControlled;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    currentRebelliosControlled += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.svRebelliousControlled;

            ai.CurrentSvRebelliosControlled = currentRebelliosControlled;
        }

        private void CalculateLovesControlled()
        {
            currentLovesControlled = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentLovesControlled += currentData.svLovesControlled;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    currentLovesControlled += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.svLovesControlled;

            ai.CurrentSvLovesControlled = currentLovesControlled;
        }

        private void CalculateLikesLoves()
        {
            currentLikesLoves = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentLikesLoves += currentData.svLikesLoves;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    currentLikesLoves += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.svLikesLoves;
            ai.CurrentSvLikesLove = currentLikesLoves;
        }

        private void CalculateNeutralLikes()
        {
            currentNeutralLikes = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentNeutralLikes += currentData.svNeutralLikes;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    currentNeutralLikes += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.svNeutralLikes;

            ai.CurrentSvNeutralLikes = currentNeutralLikes;
        }

        private void CalculateDislikesNeutral()
        {
            currentDislikesNeutral = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentDislikesNeutral += currentData.svDislikesNeutral;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    currentDislikesNeutral += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.svDislikesNeutral;

            ai.CurrentSvDislikesNeutral = currentDislikesNeutral;
        }

        private void CalculateAngryDislikes()
        {
            currentAngryDislikes = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentAngryDislikes += currentData.svAngryDislikes;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    currentAngryDislikes += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.svAngryDislikes;

            ai.CurrentSvAngryDislikes = currentAngryDislikes;
        }

        private void CalculateRebelliosTrust()
        {
            currentRebelliousAngry = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentRebelliousAngry += currentData.svRebelliousAngry;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    currentRebelliousAngry += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.svRebelliousAngry;

            ai.CurrentSvRebelliosAngry = currentRebelliousAngry;
        }
    }

}