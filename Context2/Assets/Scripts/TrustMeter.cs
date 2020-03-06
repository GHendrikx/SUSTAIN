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
                    ai.LocalScoreTotal = ai.LocalRebelliousScore + ai.LocalHatesScore + ai.LocalLikesScore + ai.LocalControlledScore + ai.LocalLoveScore + ai.LocalDisLikesScore;
                    ai.LocalRebeliousPercentage = ai.LocalRebelliousScore / ai.LocalScoreTotal;
                    for (int i = 0; i < slider.Length; i++)
                        slider[i].value = ai.LocalRebeliousPercentage;
                    break;

                case TrustType.Global:
                    ai.GlobalScoreTotal = ai.GlobalRebelliousScore + ai.GlobalHatesScore + ai.GlobalLikesScore + ai.GlobalControlledScore + ai.GlobalLoveScore + ai.GlobalDisLikesScore;
                    ai.GlobalRebeliousPercentage = ai.GlobalRebelliousScore / ai.GlobalScoreTotal;
                    for (int i = 0; i < slider.Length; i++)
                        slider[i].value = ai.GlobalRebeliousPercentage;
                    break;
                case TrustType.Supervisor:
                    ai.SvRebelliousScore = ai.SvRebelliousScore + ai.SvHatesScore + ai.SvLikesScore + ai.SvControlledScore + ai.SvLoveScore + ai.SvDisLikesScore;
                    ai.SvRebelliousPercentage = ai.SvRebelliousScore / ai.SvScoreTotal;
                    for (int i = 0; i < slider.Length; i++)
                        slider[i].value = ai.SvRebelliousPercentage;
                    break;

                case TrustType.National:
                    ai.NationalRebelliousScore = ai.GlobalRebelliousScore + ai.GlobalHatesScore + ai.GlobalLikesScore + ai.GlobalControlledScore + ai.GlobalLoveScore + ai.GlobalDisLikesScore;
                    ai.GlobalRebeliousPercentage = ai.GlobalRebelliousScore / ai.GlobalScoreTotal;
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
