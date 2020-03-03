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

        private int turn = 0;
        private const string turnText = "Turn: ";

        private Resources[] resources;

        /// <summary>
        /// TODO: subscribe all data to the nextturn variable
        /// </summary>
        private void Start()
        {
            //guiText.text = turnText + turn;

            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
            {
                float currentDoneTarget = UpgradeAbilities.upgradeAbilities[i].data.doneTarget *
                    Mathf.Pow(2, UpgradeAbilities.upgradeAbilities[i].data.doneLevel);
                UpgradeAbilities.upgradeAbilities[i].CurrentDoneTarget = currentDoneTarget;
                int points = System.Convert.ToInt32(UpgradeAbilities.upgradeAbilities[i].AbilityPointText);
                UpgradeAbilities.upgradeAbilities[i].data.doneTimes += UpgradeAbilities.upgradeAbilities[i].data.doneGain * points;
                Debug.Log(UpgradeAbilities.upgradeAbilities[i].data.doneTimes + "    " + currentDoneTarget);

                if (UpgradeAbilities.upgradeAbilities[i].data.doneTimes > currentDoneTarget)
                {
                    UpgradeAbilities.upgradeAbilities[i].data.doneLevel += 1;
                    Debug.Log(UpgradeAbilities.upgradeAbilities[i].data.doneLevel);
                    GameManager.Instance.IOManager.data.Data[0].allocatieFixedGain += 1;
                }

                if (UpgradeAbilities.upgradeAbilities[i].data.hasTarget)
                {
                    Debug.Log(UpgradeAbilities.upgradeAbilities[i].data.hasTarget);
                    UpgradeAbilities.upgradeAbilities[i].InformationText.text =
                    UpgradeAbilities.upgradeAbilities[i].data.name + "(" + UpgradeAbilities.upgradeAbilities[i].data.allocatieCost + ")" + "\n" +
                    UpgradeAbilities.upgradeAbilities[i].data.doneTimes + "/"
                    + UpgradeAbilities.upgradeAbilities[i].CurrentDoneTarget + " "
                    + UpgradeAbilities.upgradeAbilities[i].data.doneDesc;
                }
            }
            
            TimerManager.Instance.AddTimer(GoToNextTurn,1);

            TimerManager.Instance.AddTimer(GameManager.Instance.AI.researchData.UpdateResearch,1);
            TimerManager.Instance.AddTimer(GameManager.Instance.AI.creativityData.UpdateCreativity, 1);
            TimerManager.Instance.AddTimer(GameManager.Instance.AI.fundsData.UpdateFunds, 1);
            TimerManager.Instance.AddTimer(GameManager.Instance.AI.influenceData.UpdateInfluence, 1);
        }

        public void GoToNextTurn()
        {
            for (int i = 0; i < UpgradeAbilities.upgradeAbilities.Count; i++)
            {
                float currentDoneTarget = UpgradeAbilities.upgradeAbilities[i].data.doneTarget *
                    Mathf.Pow(2, UpgradeAbilities.upgradeAbilities[i].data.doneLevel);
                UpgradeAbilities.upgradeAbilities[i].CurrentDoneTarget = currentDoneTarget;

                int points = System.Convert.ToInt32(UpgradeAbilities.upgradeAbilities[i].AbilityPointText.text);
                UpgradeAbilities.upgradeAbilities[i].data.doneTimes += UpgradeAbilities.upgradeAbilities[i].data.doneGain * points;
                
                if (UpgradeAbilities.upgradeAbilities[i].data.doneTimes >= currentDoneTarget && UpgradeAbilities.upgradeAbilities[i].data.hasTarget)
                {
                    UpgradeAbilities.upgradeAbilities[i].data.doneLevel += 1;
                    currentDoneTarget = UpgradeAbilities.upgradeAbilities[i].data.doneTarget *
                    Mathf.Pow(2, UpgradeAbilities.upgradeAbilities[i].data.doneLevel);

                    UpgradeAbilities.upgradeAbilities[i].CurrentDoneTarget = currentDoneTarget;
                    GameManager.Instance.IOManager.data.Data[0].allocatieFixedGain += 1;
                    UpgradeAbilities.TEMPALLOCATIONPOOL += 1;
                }

                if (UpgradeAbilities.upgradeAbilities[i].data.hasTarget)
                    UpgradeAbilities.upgradeAbilities[i].InformationText.text =
                    UpgradeAbilities.upgradeAbilities[i].data.name + "(" + UpgradeAbilities.upgradeAbilities[i].data.allocatieCost + ")" + "\n" +
                    UpgradeAbilities.upgradeAbilities[i].data.doneTimes + "/"
                    + UpgradeAbilities.upgradeAbilities[i].CurrentDoneTarget + " "
                    + UpgradeAbilities.upgradeAbilities[i].data.doneDesc;
            }

            turn++;
            GameManager.Instance.AI.SetTurn = true;
        }

        private void Turn()
        {
            nextTurn?.Invoke();
        }


    }
}