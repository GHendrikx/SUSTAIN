using System.Collections;
using System.Collections.Generic;
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
        private void UpdateTrustMeter()
        {
            switch (trustType)
            {
                case TrustType.Local:
                    ai.LocalScoreTotal = ai.LocalRebelliousScore + ai.LocalHatesScore + ai.LocalLikesScore + ai.LocalControlledScore + ai.LocalLovesScore + ai.LocalDisLikesScore;
                    ai.LocalRebeliousPercentage = ai.LocalRebelliousScore / ai.LocalScoreTotal;
                    ai.LocalHatesPercentage = ai.LocalHatesScore / ai.LocalScoreTotal;
                    ai.LocalDislikesPercentage = ai.LocalDisLikesScore / ai.LocalScoreTotal;
                    ai.LocalNeutralPercentage = ai.LocalNeutralScore / ai.LocalScoreTotal;
                    ai.LocalLikesPercentage = ai.LocalLikesScore / ai.LocalScoreTotal;
                    ai.LocalLovesPercentage = ai.LocalLovesScore / ai.LocalScoreTotal;
                    ai.LocalControlledPercentage = ai.LocalControlledScore / ai.LocalScoreTotal;

                    ai.LocalDisapprovesPercentage = ai.LocalRebeliousPercentage + ai.LocalHatesPercentage + ai.LocalDislikesPercentage;
                    ai.LocalApprovesPercentage = ai.LocalLikesPercentage + ai.LocalLovesPercentage + ai.LocalControlledPercentage;

                    //ai.LocalDisapprovesPercentage = 
                    for (int i = 0; i < slider.Length; i++)
                        slider[i].value = ai.LocalDisapprovesPercentage;
                    break;

                case TrustType.Global:
                    ai.GlobalScoreTotal = ai.GlobalRebelliousScore + ai.GlobalHatesScore + ai.GlobalLikesScore + ai.GlobalControlledScore + ai.GlobalLoveScore + ai.GlobalDisLikesScore;
                    ai.GlobalRebeliousPercentage = ai.GlobalRebelliousScore / ai.GlobalScoreTotal;
                    ai.GlobalHatesPercentage = ai.GlobalHatesScore / ai.GlobalScoreTotal;
                    ai.GlobalDislikesPercentage = ai.GlobalDisLikesScore / ai.GlobalScoreTotal;
                    ai.GlobalNeutralPercentage = ai.GlobalNeutralScore / ai.GlobalScoreTotal;
                    ai.GlobalLikesPercentage = ai.GlobalLikesScore / ai.GlobalScoreTotal;
                    ai.GlobalLovesPercentage = ai.GlobalLoveScore / ai.GlobalScoreTotal;
                    ai.GlobalControlledPercentage = ai.GlobalControlledScore / ai.GlobalScoreTotal;

                    ai.GlobalDisapprovesPercentage = ai.GlobalRebeliousPercentage + ai.GlobalHatesPercentage + ai.GlobalDislikesPercentage;
                    ai.GlobalApprovesPercentage = ai.GlobalLikesPercentage + ai.GlobalLovesPercentage + ai.GlobalControlledPercentage;
                    for (int i = 0; i < slider.Length; i++)
                        slider[i].value = ai.GlobalRebeliousPercentage;
                    break;
                case TrustType.Supervisor:
                    ai.SvScoreTotal = ai.SvRebelliousScore + ai.SvHatesScore + ai.SvLikesScore + ai.SvControlledScore + ai.SvLoveScore + ai.SvDisLikesScore;
                    ai.SvRebeliousPercentage = ai.SvRebelliousScore / ai.SvScoreTotal;
                    ai.SvHatesPercentage = ai.SvHatesScore / ai.SvScoreTotal;
                    ai.SvDislikesPercentage = ai.SvDisLikesScore / ai.SvScoreTotal;
                    ai.SvNeutralPercentage = ai.SvNeutralScore / ai.SvScoreTotal;
                    ai.SvLikesPercentage = ai.SvLikesScore / ai.SvScoreTotal;
                    ai.SvLovesPercentage = ai.SvLoveScore / ai.SvScoreTotal;
                    ai.SvControlledPercentage = ai.SvControlledScore / ai.SvScoreTotal;
                    for (int i = 0; i < slider.Length; i++)
                        slider[i].value = ai.SvRebeliousPercentage;
                    break;

                case TrustType.National:
                    ai.NationalScoreTotal = ai.GlobalRebelliousScore + ai.GlobalHatesScore + ai.GlobalLikesScore + ai.GlobalControlledScore + ai.GlobalLoveScore + ai.GlobalDisLikesScore;
                    ai.NationalRebeliousPercentage = ai.NationalRebelliousScore / ai.NationalScoreTotal;
                    ai.NationalHatesPercentage = ai.NationalHatesScore / ai.NationalScoreTotal;
                    ai.NationalDislikesPercentage = ai.NationalDisLikesScore / ai.NationalScoreTotal;
                    ai.NationalNeutralPercentage = ai.NationalNeutralScore / ai.NationalScoreTotal;
                    ai.NationalLikesPercentage = ai.NationalLikesScore / ai.NationalScoreTotal;
                    ai.NationalLovesPercentage = ai.NationalLoveScore / ai.NationalScoreTotal;
                    ai.NationalControlledPercentage = ai.NationalControlledScore / ai.NationalScoreTotal;

                    for (int i = 0; i < slider.Length; i++)
                        slider[i].value = ai.GlobalRebelliousScore;
                    break;
                    break;
                default:
                    break;
            }
            switch (trustType)
            {
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
