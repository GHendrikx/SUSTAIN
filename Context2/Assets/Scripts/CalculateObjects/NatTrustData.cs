using UnityEngine;
using UnityEngine.Timers;

namespace Context
{
    public class NatTrustData : MonoBehaviour
    {
        private Data[] data;
        [SerializeField]
        private IOManager iOManager;
        [SerializeField]
        private AI ai;
        #region all Variables
        public float currentRebelliousAngry;
        public float currentAngryDislikes;
        public float currentDislikesNeutral;
        public float currentNeutralLikes;
        public float currentLikesLoves;
        public float currentLovesControlled;
        public float currentRebelliosControlled;
        public float currentAngryControlled;
        public float currentDislikesControlled;
        public float currentNeutralControlled;
        public float currentLikesControlled;
        #endregion

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
                    currentLikesControlled += currentData.natLikesControlled;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    currentLikesControlled += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.natLikesControlled;

            ai.CurrentNatlikesControlled = currentLikesControlled;
        }

        private void CalculateNeutralControlled()
        {
            currentNeutralControlled = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentNeutralControlled += currentData.natNeutralControlled;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    currentNeutralControlled += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.natNeutralControlled;

            ai.CurrentNatNeutralControlled = currentNeutralControlled;
        }

        private void CalculateDislikesControlled()
        {
            currentDislikesControlled = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentDislikesControlled += currentData.natDislikesControlled;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    currentDislikesControlled += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.natDislikesControlled;

            ai.CurrentNatDislikesControlled = currentDislikesControlled;
        }

        private void CalculateAngryControlled()
        {
            currentAngryControlled = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentAngryControlled += currentData.natAngryControlled;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    currentAngryControlled += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.natAngryControlled;

            ai.CurrentNatAngryControlled = currentAngryControlled;
        }

        private void CalculateRebelliosControlled()
        {
            currentRebelliosControlled = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentRebelliosControlled += currentData.natRebelliousControlled;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    currentRebelliosControlled += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.natRebelliousControlled;

            ai.CurrentNatRebelliosControlled = currentRebelliosControlled;
        }

        private void CalculateLovesControlled()
        {
            currentLovesControlled = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentLovesControlled += currentData.natLovesControlled;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    currentLovesControlled += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.natLovesControlled;

            ai.CurrentNatLovesControlled = currentLovesControlled;
        }

        private void CalculateLikesLoves()
        {
            currentLikesLoves = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentLikesLoves += currentData.natLikesLoves;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    currentLikesLoves += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.natLikesLoves;

            ai.CurrentNatLikesLove = currentLikesLoves;
        }

        private void CalculateNeutralLikes()
        {
            currentNeutralLikes = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentNeutralLikes += currentData.natNeutralLikes;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    currentNeutralLikes += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.natNeutralLikes;

            ai.CurrentNatNeutralLikes = currentNeutralLikes;
        }

        private void CalculateDislikesNeutral()
        {
            currentDislikesNeutral = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentDislikesNeutral += currentData.natDislikesNeutral;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    currentDislikesNeutral += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.natDislikesNeutral;

            ai.CurrentNatDislikesNeutral = currentDislikesNeutral;
        }

        private void CalculateAngryDislikes()
        {
            currentAngryDislikes = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentAngryDislikes += currentData.natAngryDislikes;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    currentAngryDislikes += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.natAngryDislikes;

            ai.CurrentNatAngryDislikes = currentAngryDislikes;
        }

        private void CalculateRebelliosTrust()
        {
            currentRebelliousAngry = 0;

            foreach (Data currentData in data)
                if (currentData.isResearched)
                    currentRebelliousAngry += currentData.natRebelliousAngry;

            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
                if (UpgradeAbilities.UPGRADEABILITIES[i].data.typeOfData == 0)
                    currentRebelliousAngry += UpgradeAbilities.UPGRADEABILITIES[i].Points * UpgradeAbilities.UPGRADEABILITIES[i].data.natRebelliousAngry;

            ai.CurrentNatRebelliosAngry = currentRebelliousAngry;
        }
    }
}