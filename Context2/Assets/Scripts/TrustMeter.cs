﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Context
{
    public class TrustMeter : MonoBehaviour
    {
        [SerializeField]
        private Slider[] slider;
        [SerializeField]
        private AI ai;
        [SerializeField]
        private TrustType trustType;

        private float populationGrowth = 1.00009f;
        private float naturalDecay = 0.015f;

        public void UpdateTrustMeter()
        {
            float tempLocalRebeliousScore = ai.LocalRebelliousScore;
            float tempLocalHatesScore = ai.LocalHatesScore;
            float tempLocalDislikesScore = ai.LocalDisLikesScore;
            float tempLocalNeutralScore = ai.LocalNeutralScore;
            float tempLocalLikesScore = ai.LocalLikesScore;
            float tempLocalLovesScore = ai.LocalLovesScore;
            float tempLocalControlledScore = ai.LocalControlledScore;

            float tempSvRebeliousScore = ai.SvRebelliousScore;
            float tempSvHatesScore = ai.SvHatesScore;
            float tempSvDislikesScore = ai.SvDisLikesScore;
            float tempSvNeutralScore = ai.SvNeutralScore;
            float tempSvLikesScore = ai.SvLikesScore;
            float tempSvLovesScore = ai.SvLoveScore;
            float tempSvControlledScore = ai.SvControlledScore;

            float tempGlobalRebeliousScore = ai.GlobalRebelliousScore;
            float tempGlobalHatesScore = ai.GlobalHatesScore;
            float tempGlobalDislikesScore = ai.GlobalDisLikesScore;
            float tempGlobalNeutralScore = ai.GlobalNeutralScore;
            float tempGlobalLikesScore = ai.GlobalLikesScore;
            float tempGlobalLovesScore = ai.GlobalLoveScore;
            float tempGlobalControlledScore = ai.GlobalControlledScore;

            float tempNationalRebeliousScore = ai.NationalRebelliousScore;
            float tempNationalHatesScore = ai.NationalHatesScore;
            float tempNationalDislikesScore = ai.NationalDisLikesScore;
            float tempNationalNeutralScore = ai.NationalNeutralScore;
            float tempNationalLikesScore = ai.NationalLikesScore;
            float tempNationalLovesScore = ai.NationalLoveScore;
            float tempNationalControlledScore = ai.NationalControlledScore;

            TrustChangeCalculator(ref ai.LocalRebelliousScore, ai.CurrentLocalRebelliosAngry, 0, 0, tempLocalRebeliousScore, tempLocalHatesScore, populationGrowth, naturalDecay, true, false, true, false);
            TrustChangeCalculator(ref ai.LocalHatesScore, ai.CurrentLocalAngryDislikes, ai.CurrentLocalRebelliosAngry, tempLocalRebeliousScore, tempLocalHatesScore, tempLocalDislikesScore, populationGrowth, naturalDecay, true, false, false, false);
            TrustChangeCalculator(ref ai.LocalDisLikesScore, ai.CurrentLocalDislikesNeutral, ai.CurrentLocalAngryDislikes, tempLocalHatesScore, tempLocalDislikesScore, tempLocalNeutralScore, populationGrowth, naturalDecay, true, false, false, false);
            TrustChangeCalculator(ref ai.LocalNeutralScore, ai.CurrentLocalNeutralLikes, ai.CurrentLocalDislikesNeutral, tempLocalDislikesScore, tempLocalNeutralScore, tempLocalLikesScore, populationGrowth, naturalDecay, false, true, false, false);
            TrustChangeCalculator(ref ai.LocalLikesScore, ai.CurrentLocalLikesLove, ai.CurrentLocalNeutralLikes, tempLocalNeutralScore, tempLocalLikesScore, tempLocalLovesScore, populationGrowth, naturalDecay, false, false, false, false);
            TrustChangeCalculator(ref ai.LocalLovesScore, ai.CurrentLocalLovesControlled, ai.CurrentLocalLikesLove, tempLocalLikesScore, tempLocalLovesScore, tempLocalControlledScore, populationGrowth, naturalDecay, false, false, false, false);
            TrustChangeCalculator(ref ai.LocalControlledScore, 0, ai.CurrentLocalLikesLove, tempLocalLovesScore, tempLocalControlledScore, 0, populationGrowth, naturalDecay, false, false, true, false);

            TrustChangeCalculator(ref ai.GlobalRebelliousScore, ai.CurrentGlobalRebelliosAngry, 0, 0, tempGlobalRebeliousScore, tempGlobalHatesScore, populationGrowth, naturalDecay, true, false, true, false);
            TrustChangeCalculator(ref ai.GlobalHatesScore, ai.CurrentGlobalAngryDislikes, ai.CurrentGlobalRebelliosAngry, tempGlobalRebeliousScore, tempGlobalHatesScore, tempGlobalDislikesScore, populationGrowth, naturalDecay, true, false, false, false);
            TrustChangeCalculator(ref ai.GlobalDisLikesScore, ai.CurrentGlobalDislikesNeutral, ai.CurrentGlobalAngryDislikes, tempGlobalHatesScore, tempGlobalDislikesScore, tempGlobalNeutralScore, populationGrowth, naturalDecay, true, false, false, false);
            TrustChangeCalculator(ref ai.GlobalNeutralScore, ai.CurrentGlobalNeutralLikes, ai.CurrentGlobalDislikesNeutral, tempGlobalDislikesScore, tempGlobalNeutralScore, tempGlobalLikesScore, populationGrowth, naturalDecay, false, true, false, false);
            TrustChangeCalculator(ref ai.GlobalLikesScore, ai.CurrentGlobalLikesLove, ai.CurrentGlobalNeutralLikes, tempGlobalNeutralScore, tempGlobalLikesScore, tempGlobalLovesScore, populationGrowth, naturalDecay, false, false, false, false);
            TrustChangeCalculator(ref ai.GlobalLoveScore, ai.CurrentGlobalLovesControlled, ai.CurrentGlobalLikesLove, tempGlobalLikesScore, tempGlobalLovesScore, tempGlobalControlledScore, populationGrowth, naturalDecay, false, false, false, false);
            TrustChangeCalculator(ref ai.GlobalControlledScore, 0, ai.CurrentGlobalLikesLove, tempGlobalLovesScore, tempGlobalControlledScore, 0, populationGrowth, naturalDecay, false, false, true, false);

            TrustChangeCalculator(ref ai.SvRebelliousScore, ai.CurrentSvRebelliosAngry, 0, 0, tempSvRebeliousScore, tempSvHatesScore, populationGrowth, naturalDecay, true, false, true, false);
            TrustChangeCalculator(ref ai.SvHatesScore, ai.CurrentSvAngryDislikes, ai.CurrentSvRebelliosAngry, tempSvRebeliousScore, tempSvHatesScore, tempSvDislikesScore, populationGrowth, naturalDecay, true, false, false, false);
            TrustChangeCalculator(ref ai.SvDisLikesScore, ai.CurrentSvDislikesNeutral, ai.CurrentSvAngryDislikes, tempSvHatesScore, tempSvDislikesScore, tempSvNeutralScore, populationGrowth, naturalDecay, true, false, false, false);
            TrustChangeCalculator(ref ai.SvNeutralScore, ai.CurrentSvNeutralLikes, ai.CurrentSvDislikesNeutral, tempSvDislikesScore, tempSvNeutralScore, tempSvLikesScore, populationGrowth, naturalDecay, false, true, false, true);
            TrustChangeCalculator(ref ai.SvLikesScore, ai.CurrentSvLikesLove, ai.CurrentSvNeutralLikes, tempSvNeutralScore, tempSvLikesScore, tempSvLovesScore, populationGrowth, naturalDecay, false, false, false, false);
            TrustChangeCalculator(ref ai.SvLoveScore, ai.CurrentSvLovesControlled, ai.CurrentSvLikesLove, tempSvLikesScore, tempSvLovesScore, tempSvControlledScore, populationGrowth, naturalDecay, false, false, false, false);
            TrustChangeCalculator(ref ai.SvControlledScore, 0, ai.CurrentSvLikesLove, tempSvLovesScore, tempSvControlledScore, 0, populationGrowth, naturalDecay, false, false, true, false);

            TrustChangeCalculator(ref ai.NationalRebelliousScore, ai.CurrentNatRebelliosAngry, 0, 0, tempNationalRebeliousScore, tempNationalHatesScore, populationGrowth, naturalDecay, true, false, true, false);
            TrustChangeCalculator(ref ai.NationalHatesScore, ai.CurrentNatAngryDislikes, ai.CurrentNatRebelliosAngry, tempNationalRebeliousScore, tempNationalHatesScore, tempNationalDislikesScore, populationGrowth, naturalDecay, true, false, false, false);
            TrustChangeCalculator(ref ai.NationalDisLikesScore, ai.CurrentNatDislikesNeutral, ai.CurrentNatAngryDislikes, tempNationalHatesScore, tempNationalDislikesScore, tempNationalNeutralScore, populationGrowth, naturalDecay, true, false, false, false);
            TrustChangeCalculator(ref ai.NationalNeutralScore, ai.CurrentNatNeutralLikes, ai.CurrentNatDislikesNeutral, tempNationalDislikesScore, tempNationalNeutralScore, tempNationalLikesScore, populationGrowth, naturalDecay, false, true, false, false);
            TrustChangeCalculator(ref ai.NationalLikesScore, ai.CurrentNatLikesLove, ai.CurrentNatNeutralLikes, tempNationalNeutralScore, tempNationalLikesScore, tempNationalLovesScore, populationGrowth, naturalDecay, false, false, false, false);
            TrustChangeCalculator(ref ai.NationalLoveScore, ai.CurrentNatLovesControlled, ai.CurrentNatLikesLove, tempNationalLikesScore, tempNationalLovesScore, tempNationalControlledScore, populationGrowth, naturalDecay, false, false, false, false);
            TrustChangeCalculator(ref ai.NationalControlledScore, 0, ai.CurrentNatLikesLove, tempNationalLovesScore, tempNationalControlledScore, 0, populationGrowth, naturalDecay, false, false, true, false);

            ai.LocalScoreTotal = ai.LocalRebelliousScore + ai.LocalHatesScore + ai.LocalLikesScore + ai.LocalControlledScore + ai.LocalLovesScore + ai.LocalDisLikesScore + ai.LocalNeutralScore;
            ai.LocalRebeliousPercentage = ai.LocalRebelliousScore / ai.LocalScoreTotal;
            ai.LocalHatesPercentage = ai.LocalHatesScore / ai.LocalScoreTotal;
            ai.LocalDislikesPercentage = ai.LocalDisLikesScore / ai.LocalScoreTotal;
            ai.LocalNeutralPercentage = ai.LocalNeutralScore / ai.LocalScoreTotal;
            ai.LocalLikesPercentage = ai.LocalLikesScore / ai.LocalScoreTotal;
            ai.LocalLovesPercentage = ai.LocalLovesScore / ai.LocalScoreTotal;
            ai.LocalControlledPercentage = ai.LocalControlledScore / ai.LocalScoreTotal;

            ai.LocalDisapprovesPercentage = ai.LocalRebeliousPercentage + ai.LocalHatesPercentage + ai.LocalDislikesPercentage;
            ai.LocalApprovesPercentage = ai.LocalLikesPercentage + ai.LocalLovesPercentage + ai.LocalControlledPercentage;

            ai.GlobalScoreTotal = ai.GlobalRebelliousScore + ai.GlobalHatesScore + ai.GlobalLikesScore + ai.GlobalControlledScore + ai.GlobalLoveScore + ai.GlobalDisLikesScore + ai.GlobalNeutralScore;
            ai.GlobalRebeliousPercentage = ai.GlobalRebelliousScore / ai.GlobalScoreTotal;
            ai.GlobalHatesPercentage = ai.GlobalHatesScore / ai.GlobalScoreTotal;
            ai.GlobalDislikesPercentage = ai.GlobalDisLikesScore / ai.GlobalScoreTotal;
            ai.GlobalNeutralPercentage = ai.GlobalNeutralScore / ai.GlobalScoreTotal;
            ai.GlobalLikesPercentage = ai.GlobalLikesScore / ai.GlobalScoreTotal;
            ai.GlobalLovesPercentage = ai.GlobalLoveScore / ai.GlobalScoreTotal;
            ai.GlobalControlledPercentage = ai.GlobalControlledScore / ai.GlobalScoreTotal;

            ai.GlobalDisapprovesPercentage = ai.GlobalRebeliousPercentage + ai.GlobalHatesPercentage + ai.GlobalDislikesPercentage;
            ai.GlobalApprovesPercentage = ai.GlobalLikesPercentage + ai.GlobalLovesPercentage + ai.GlobalControlledPercentage;

            ai.SvScoreTotal = ai.SvRebelliousScore + ai.SvHatesScore + ai.SvLikesScore + ai.SvControlledScore + ai.SvLoveScore + ai.SvDisLikesScore + ai.SvNeutralScore;
            ai.SvRebeliousPercentage = ai.SvRebelliousScore / ai.SvScoreTotal;
            ai.SvHatesPercentage = ai.SvHatesScore / ai.SvScoreTotal;
            ai.SvDislikesPercentage = ai.SvDisLikesScore / ai.SvScoreTotal;
            ai.SvNeutralPercentage = ai.SvNeutralScore / ai.SvScoreTotal;
            ai.SvLikesPercentage = ai.SvLikesScore / ai.SvScoreTotal;
            ai.SvLovesPercentage = ai.SvLoveScore / ai.SvScoreTotal;
            ai.SvControlledPercentage = ai.SvControlledScore / ai.SvScoreTotal;

            ai.SvDisapprovesPercentage = ai.SvRebeliousPercentage + ai.SvHatesPercentage + ai.SvDislikesPercentage;
            ai.SvApprovesPercentage = ai.SvLikesPercentage + ai.SvLovesPercentage + ai.SvControlledPercentage;

            ai.NationalScoreTotal = ai.NationalRebelliousScore + ai.NationalHatesScore + ai.NationalLikesScore + ai.NationalControlledScore + ai.NationalLoveScore + ai.NationalDisLikesScore + ai.NationalNeutralScore; ;
            ai.NationalRebeliousPercentage = ai.NationalRebelliousScore / ai.NationalScoreTotal;
            ai.NationalHatesPercentage = ai.NationalHatesScore / ai.NationalScoreTotal;
            ai.NationalDislikesPercentage = ai.NationalDisLikesScore / ai.NationalScoreTotal;
            ai.NationalNeutralPercentage = ai.NationalNeutralScore / ai.NationalScoreTotal;
            ai.NationalLikesPercentage = ai.NationalLikesScore / ai.NationalScoreTotal;
            ai.NationalLovesPercentage = ai.NationalLoveScore / ai.NationalScoreTotal;
            ai.NationalControlledPercentage = ai.NationalControlledScore / ai.NationalScoreTotal;

            ai.NationalDisapprovesPercentage = ai.NationalRebeliousPercentage + ai.NationalHatesPercentage + ai.NationalDislikesPercentage;
            ai.NationalApprovesPercentage = ai.NationalLikesPercentage + ai.NationalLovesPercentage + ai.NationalControlledPercentage;

            switch (trustType)
            {
                case TrustType.Local:
                    for (int i = 0; i < slider.Length; i++)
                        slider[i].value = ai.LocalDisapprovesPercentage;
                    break;

                case TrustType.Global:
                    for (int i = 0; i < slider.Length; i++)
                        slider[i].value = ai.GlobalDisapprovesPercentage;
                    break;
                case TrustType.Supervisor:

                    for (int i = 0; i < slider.Length; i++)
                        slider[i].value = ai.SvDisapprovesPercentage;
                    break;

                case TrustType.National:
                    for (int i = 0; i < slider.Length; i++)
                        slider[i].value = ai.NationalDisapprovesPercentage;
                    break;
                default:
                    break;
            }
        }

        private void TrustChangeCalculator(ref float scoreHuidig, float GrowthRechts, float GrowthLinks, float tempLinks, float tempHuidig, float tempRechts, float groeiFactor, float decay, bool isLeft, bool isCenter, bool isOuter, bool debug)
        {
            float temp1;
            float temp2;
            if (GrowthRechts > 0) temp1 = tempHuidig;
            else temp1 = tempRechts;
            if (GrowthLinks > 0) temp2 = tempLinks;
            else temp2 = tempHuidig;

            if (isCenter)
            {
                scoreHuidig = (tempHuidig - GrowthRechts * temp1 + GrowthLinks * temp2 + tempLinks * decay + tempRechts * decay) * groeiFactor;
            }
            else
            {
                if (isLeft)
                {
                    if (isOuter)
                        scoreHuidig = (tempHuidig - GrowthRechts * temp1 - tempHuidig * decay) * groeiFactor;
                    else scoreHuidig = (tempHuidig - GrowthRechts * temp1 + GrowthLinks * temp2 + tempLinks * decay - tempHuidig * decay) * groeiFactor;
                }
                else
                {
                    if (isOuter)
                        scoreHuidig = (tempHuidig + GrowthLinks * temp2 - tempHuidig * decay) * groeiFactor;
                    else
                    {
                        scoreHuidig = (tempHuidig - GrowthRechts * temp1 + GrowthLinks * temp2 + tempRechts * decay - tempHuidig * decay) * groeiFactor;
                    }
                }

            }
        }
    }
    public enum TrustType
    {
        Local,
        Global,
        Supervisor,
        National
    }


}
