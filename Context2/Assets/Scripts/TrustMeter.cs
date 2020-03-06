using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Context
{
    public class TrustMeter : MonoBehaviour
    {
        private Slider[] slider;
        private AI ai;

        private void UpdateTrustMeter()
        {
            ai.GlobalScoreTotal = ai.GlobalRebelliousScore + ai.GlobalHatesScore + ai.GlobalLikesScore + ai.GlobalControlledScore + ai.GlobalLoveScore + ai.GlobalDisLikesScore;
            ai.GlobalRebeliousPercentage = ai.GlobalRebelliousScore / ai.GlobalScoreTotal;
            ai.LocalScoreTotal = ai.LocalRebelliousScore + ai.LocalHatesScore + ai.LocalLikesScore + ai.LocalControlledScore + ai.LocalLoveScore + ai.LocalDisLikesScore;
            ai.LocalRebelliousScore = ai.LocalRebelliousScore / ai.LocalScoreTotal;
        }
    }
}
