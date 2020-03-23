using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;
using UnityEngine.UI;

namespace Context
{
    public class TurnManager : MonoBehaviour
    {
        public delegate void NextTurn();
        public event NextTurn nextTurn;
        [SerializeField]
        private AI ai;

        private int turn = 0;
        private const string turnText = "Turn: ";

        private Resources[] resources;

        private float currentDoneTarget;

        /// <summary>
        /// TODO: subscribe all data to the nextturn variable
        /// </summary>
        private void Start()
        {
            //guiText.text = turnText + turn;
            #region deprecated code
            //for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
            //{
            //    float currentDoneTarget = UpgradeAbilities.UPGRADEABILITIES[i].data.doneTarget *
            //        Mathf.Pow(2, UpgradeAbilities.UPGRADEABILITIES[i].data.doneLevel);
            //    UpgradeAbilities.UPGRADEABILITIES[i].CurrentDoneTarget = currentDoneTarget;
            //    int points = System.Convert.ToInt32(UpgradeAbilities.UPGRADEABILITIES[i].AbilityPointText);
            //    UpgradeAbilities.UPGRADEABILITIES[i].data.doneTimes += UpgradeAbilities.UPGRADEABILITIES[i].data.doneGain * points;

            //    if (UpgradeAbilities.UPGRADEABILITIES[i].data.doneTimes > currentDoneTarget)
            //    {
            //        UpgradeAbilities.UPGRADEABILITIES[i].data.doneLevel += 1;
            //        Debug.Log(UpgradeAbilities.UPGRADEABILITIES[i].data.doneLevel);
            //        GameManager.Instance.IOManager.data.Data[0].allocatieFixedGain += 1;
            //    }

            //    if (UpgradeAbilities.UPGRADEABILITIES[i].data.hasTarget)
            //    {
            //        Debug.Log(UpgradeAbilities.UPGRADEABILITIES[i].data.hasTarget);
            //        UpgradeAbilities.UPGRADEABILITIES[i].InformationText.text =
            //        UpgradeAbilities.UPGRADEABILITIES[i].data.name + "(" + UpgradeAbilities.UPGRADEABILITIES[i].data.allocatieCost + ")" + "\n" +
            //        UpgradeAbilities.UPGRADEABILITIES[i].data.doneTimes + "/"
            //        + UpgradeAbilities.UPGRADEABILITIES[i].CurrentDoneTarget + " "
            //        + UpgradeAbilities.UPGRADEABILITIES[i].data.doneDesc;
            //    }
            //}
            #endregion


            TimerManager.Instance.AddTimer(SetFirstTurn, 0.1f);
            TimerManager.Instance.AddTimer(GoToNextTurn, 0.1f);
            TimerManager.Instance.AddTimer(GameManager.Instance.AI.researchData.UpdateResearch, 0.1f);
            TimerManager.Instance.AddTimer(GameManager.Instance.AI.creativityData.UpdateCreativity, 0.1f);
            TimerManager.Instance.AddTimer(GameManager.Instance.AI.fundsData.UpdateFunds, 0.1f);
            TimerManager.Instance.AddTimer(GameManager.Instance.AI.influenceData.UpdateInfluence, 0.1f);
            TimerManager.Instance.AddTimer(GameManager.Instance.AI.materialData.UpdateMaterial, 0.1f);
            TimerManager.Instance.AddTimer(GameManager.Instance.AI.dronesData.UpdateDrone, 0.1f);
            TimerManager.Instance.AddTimer(GameManager.Instance.AI.SDGManager.UpdateSDGValues, 0.1f);
            TimerManager.Instance.AddTimer(GameManager.Instance.AI.SDGCalculate.UpdateSDG, 0.1f);
            TimerManager.Instance.AddTimer(GameManager.Instance.AI.TrustMeter.UpdateTrustMeter, 0.1f);
        }

        private void Awake()
        {
            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
            {
                UpgradeAbilities.UPGRADEABILITIES[i].CurrentDoneTarget = UpgradeAbilities.UPGRADEABILITIES[i].data.doneTarget;

                if (UpgradeAbilities.UPGRADEABILITIES[i].data.hasTarget)
                {
                    UpgradeAbilities.UPGRADEABILITIES[i].InformationText.text = UpgradeAbilities.UPGRADEABILITIES[i].data.name;
                    UpgradeAbilities.UPGRADEABILITIES[i].TargetText.text = UpgradeAbilities.UPGRADEABILITIES[i].data.doneTimes + "/" +
                    UpgradeAbilities.UPGRADEABILITIES[i].CurrentDoneTarget + " " + UpgradeAbilities.UPGRADEABILITIES[i].data.doneDesc;
                    Debug.Log("test");
                }
            }
        }

        private void SetFirstTurn()
        {
            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
            {
                UpgradeAbilities.UPGRADEABILITIES[i].CurrentDoneTarget = UpgradeAbilities.UPGRADEABILITIES[i].data.doneTarget;
            }

        }

        public void GoToNextTurn()
        {
            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
            {
                int points = System.Convert.ToInt32(UpgradeAbilities.UPGRADEABILITIES[i].AbilityPointText.text);
                float beginNumber = UpgradeAbilities.UPGRADEABILITIES[i].data.doneTimes;

                UpgradeAbilities.UPGRADEABILITIES[i].data.doneTimes += points;



                if (UpgradeAbilities.UPGRADEABILITIES[i].data.hasTarget)
                {
                    UpgradeAbilities.UPGRADEABILITIES[i].InformationText.text = UpgradeAbilities.UPGRADEABILITIES[i].data.name;
                    StartCoroutine(LerpToNumber(i, 0.5f, points, beginNumber, UpgradeAbilities.UPGRADEABILITIES[i].data.doneTimes));
                    UpgradeAbilities.UPGRADEABILITIES[i].TargetText.text = UpgradeAbilities.UPGRADEABILITIES[i].data.doneTimes + "/" +
                    UpgradeAbilities.UPGRADEABILITIES[i].CurrentDoneTarget + " " + UpgradeAbilities.UPGRADEABILITIES[i].data.doneDesc;

                }
            }

            turn++;

            GameManager.Instance.AI.SetTurn = true;


        }

        public IEnumerator LerpToNumber(int i, float overTime, int points, float beginNumber, float endNumber)
        {
            float startTime = Time.time;

            while (Time.time < (startTime + overTime))
            {
                UpgradeAbilities.UPGRADEABILITIES[i].TargetText.text = Mathf.Round(Mathf.Lerp(beginNumber, endNumber, (Time.time - startTime) / overTime)).ToString("0") + "/" + UpgradeAbilities.UPGRADEABILITIES[i].CurrentDoneTarget + " " + UpgradeAbilities.UPGRADEABILITIES[i].data.doneDesc;
                if (Mathf.Round(Mathf.Lerp(beginNumber, endNumber, (Time.time - startTime) / overTime)) >= UpgradeAbilities.UPGRADEABILITIES[i].CurrentDoneTarget && UpgradeAbilities.UPGRADEABILITIES[i].data.hasTarget)
                {
                    UpgradeAbilities.UPGRADEABILITIES[i].data.doneLevel += 1;
                    UpgradeAbilities.UPGRADEABILITIES[i].CurrentDoneTarget += Mathf.Round(UpgradeAbilities.UPGRADEABILITIES[i].data.doneGain * Mathf.Pow(UpgradeAbilities.UPGRADEABILITIES[i].data.doneGrowth, UpgradeAbilities.UPGRADEABILITIES[i].data.doneLevel));
                    GameManager.Instance.IOManager.data.Data[0].allocatieFixedGain += UpgradeAbilities.UPGRADEABILITIES[i].data.allocatieFixedGain;
                    GameManager.Instance.IOManager.data.Data[0].researchFixedGain += UpgradeAbilities.UPGRADEABILITIES[i].data.researchFixedGain;
                    GameManager.Instance.IOManager.data.Data[0].researchFixedGain += UpgradeAbilities.UPGRADEABILITIES[i].data.creativityFixedGain;
                    GameManager.Instance.IOManager.data.Data[0].researchFixedGain += UpgradeAbilities.UPGRADEABILITIES[i].data.fundsFixedGain;
                    GameManager.Instance.IOManager.data.Data[0].researchFixedGain += UpgradeAbilities.UPGRADEABILITIES[i].data.influenceFixedGain;
                    GameManager.Instance.IOManager.data.Data[0].researchFixedGain += UpgradeAbilities.UPGRADEABILITIES[i].data.materialFixedGain;
                    GameManager.Instance.IOManager.data.Data[0].researchFixedGain += UpgradeAbilities.UPGRADEABILITIES[i].data.powerFixedGain;
                    GameManager.Instance.IOManager.data.Data[0].researchFixedGain += UpgradeAbilities.UPGRADEABILITIES[i].data.droneFixedGain;
                    UpgradeAbilities.TEMPALLOCATIONPOOL += UpgradeAbilities.UPGRADEABILITIES[i].data.allocatieFixedGain;
                    UpgradeAbilities.ALLOCATIONPOOL += UpgradeAbilities.UPGRADEABILITIES[i].data.allocatieFixedGain;
                    //speel hier rewardsound
                    AudioManager.Instance.ToggleGameObject(AudioManager.Instance.AllocatieReward);
                }
                yield return null;
            }
        }

        private void Turn() =>
            nextTurn?.Invoke();


    }
}