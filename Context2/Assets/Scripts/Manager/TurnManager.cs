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

        private bool virgin = true;

        public static bool ISINTERACTABLE = true;

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
                }
            }
        }

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
            TimerManager.Instance.AddTimer(GameManager.Instance.AI.powerData.UpdatePower, 0.1f);
            TimerManager.Instance.AddTimer(GameManager.Instance.AI.SDGManager.UpdateSDGValues, 0.1f);
            TimerManager.Instance.AddTimer(GameManager.Instance.AI.SDGCalculate.UpdateSDG, 0.1f);
            TimerManager.Instance.AddTimer(GameManager.Instance.AI.TrustMeter.UpdateTrustMeter, 0.1f);
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
            if (!virgin)
            {
                AudioManager.Instance.ToggleGameObject(AudioManager.Instance.NextWeek);
                ISINTERACTABLE = false;
                TimerManager.Instance.AddTimer(() => { ISINTERACTABLE = !ISINTERACTABLE; }, 3f);

                GameManager.Instance.AI.SDGManager.offset -= 0.016f;
            }
            virgin = false;


            for (int i = 0; i < UpgradeAbilities.UPGRADEABILITIES.Count; i++)
            {
                int points = System.Convert.ToInt32(UpgradeAbilities.UPGRADEABILITIES[i].AbilityPointText.text);
                float beginNumber = UpgradeAbilities.UPGRADEABILITIES[i].data.doneTimes;

                UpgradeAbilities.UPGRADEABILITIES[i].data.doneTimes += points * UpgradeAbilities.UPGRADEABILITIES[i].data.doneAmount;

                if (UpgradeAbilities.UPGRADEABILITIES[i].data.hasTarget)
                {
                    UpgradeAbilities.UPGRADEABILITIES[i].InformationText.text = UpgradeAbilities.UPGRADEABILITIES[i].data.name;
                    StartCoroutine(LerpToNumber(i, 2.5f, points, beginNumber, UpgradeAbilities.UPGRADEABILITIES[i].data.doneTimes));
                    UpgradeAbilities.UPGRADEABILITIES[i].TargetText.text = UpgradeAbilities.UPGRADEABILITIES[i].data.doneTimes + "/" +
                    UpgradeAbilities.UPGRADEABILITIES[i].CurrentDoneTarget + " " + UpgradeAbilities.UPGRADEABILITIES[i].data.doneDesc;

                }
            }

            turn++;

            GameManager.Instance.AI.SetTurn = true;


        }

        public IEnumerator LerpToNumber(int i, float overTime, int points, float beginNumber, float endNumber)
        {
            if (endNumber >= (UpgradeAbilities.UPGRADEABILITIES[i].CurrentDoneTarget))
            {
                ai.researchData.CurrentResearchPoints += UpgradeAbilities.UPGRADEABILITIES[i].data.researchFixedGain;
                ai.creativityData.CurrentCreativityPoints += UpgradeAbilities.UPGRADEABILITIES[i].data.creativityFixedGain;
                ai.fundsData.CurrentFundsPoints += UpgradeAbilities.UPGRADEABILITIES[i].data.fundsFixedGain;
                ai.influenceData.CurrentInfluencePoints += UpgradeAbilities.UPGRADEABILITIES[i].data.influenceFixedGain;
                ai.materialData.CurrentMaterialPoints += UpgradeAbilities.UPGRADEABILITIES[i].data.materialFixedGain;
                ai.powerData.CurrentPowerPoints += UpgradeAbilities.UPGRADEABILITIES[i].data.powerFixedGain;
                ai.droneData.CurrentDronesPoints += UpgradeAbilities.UPGRADEABILITIES[i].data.droneFixedGain;
                if (ai.researchData.CurrentResearchPoints >= ai.ResearchLimit)
                    ai.researchData.CurrentResearchPoints = ai.ResearchLimit;
                if (ai.droneData.CurrentDronesPoints >= ai.DroneLimit)
                    ai.droneData.CurrentDronesPoints = ai.DroneLimit;
            }
            float startTime = Time.time;

            while (Time.time < (startTime + overTime))
            {
                UpgradeAbilities.UPGRADEABILITIES[i].TargetText.text = Mathf.Round(Mathf.Lerp(beginNumber, endNumber, (Time.time - startTime) / overTime)).ToString("0") + "/" + UpgradeAbilities.UPGRADEABILITIES[i].CurrentDoneTarget + " " + UpgradeAbilities.UPGRADEABILITIES[i].data.doneDesc;
                if (Mathf.Round(Mathf.Lerp(beginNumber, endNumber, (Time.time - startTime) / overTime)) >= (UpgradeAbilities.UPGRADEABILITIES[i].CurrentDoneTarget) && UpgradeAbilities.UPGRADEABILITIES[i].data.hasTarget)
                {

                    UpgradeAbilities.UPGRADEABILITIES[i].data.doneLevel += 1;
                    UpgradeAbilities.UPGRADEABILITIES[i].CurrentDoneTarget += Mathf.Round(UpgradeAbilities.UPGRADEABILITIES[i].data.doneGain * Mathf.Pow(UpgradeAbilities.UPGRADEABILITIES[i].data.doneGrowth, UpgradeAbilities.UPGRADEABILITIES[i].data.doneLevel));
                    ai.ResearchPoints += UpgradeAbilities.UPGRADEABILITIES[i].data.researchFixedGain;
                    ai.CreativityPoints += UpgradeAbilities.UPGRADEABILITIES[i].data.creativityFixedGain;
                    ai.FundsPoints += UpgradeAbilities.UPGRADEABILITIES[i].data.fundsFixedGain;
                    ai.InfluencePoints += UpgradeAbilities.UPGRADEABILITIES[i].data.influenceFixedGain;
                    ai.MaterialPoints += UpgradeAbilities.UPGRADEABILITIES[i].data.materialFixedGain;
                    ai.PowerPoints += UpgradeAbilities.UPGRADEABILITIES[i].data.powerFixedGain;
                    ai.DronePoints += UpgradeAbilities.UPGRADEABILITIES[i].data.droneFixedGain;
                    UpgradeAbilities.TEMPALLOCATIONPOOL += UpgradeAbilities.UPGRADEABILITIES[i].data.allocatieFixedGain;
                    UpgradeAbilities.ALLOCATIONPOOL += UpgradeAbilities.UPGRADEABILITIES[i].data.allocatieFixedGain;
                    Debug.Log(UpgradeAbilities.ALLOCATIONPOOL);
                    TimerManager.Instance.AddTimer(() => { UpgradeAbilities.CURRENTALLOCATIONPOOL = UpgradeAbilities.ALLOCATIONPOOL; }, 0.1f);
                    if (ai.ResearchPoints >= ai.ResearchLimit)
                        ai.ResearchPoints = ai.ResearchLimit;
                    if (ai.DronePoints >= ai.DroneLimit)
                        ai.DronePoints = ai.DroneLimit;
                    TimerManager.Instance.AddTimer(() =>
                    {
                        ai.ResearchPoints = ai.researchData.CurrentResearchPoints;
                        ai.CreativityPoints = ai.creativityData.CurrentCreativityPoints;
                        ai.FundsPoints = ai.fundsData.CurrentFundsPoints;
                        ai.InfluencePoints = ai.influenceData.CurrentInfluencePoints;
                        ai.MaterialPoints = ai.materialData.CurrentMaterialPoints;
                        ai.PowerPoints = ai.powerData.CurrentPowerPoints;
                        ai.DronePoints = ai.droneData.CurrentDronesPoints;
                    }, 2f);


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