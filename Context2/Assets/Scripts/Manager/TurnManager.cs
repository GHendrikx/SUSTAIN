using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public delegate void NextTurn();
    public event NextTurn nextTurn;

    [SerializeField]
    private Text guiText;

    private int turn = 0;
    private const string turnText = "Turn: ";

    private Resources[] resources;

    /// <summary>
    /// TODO: subscribe all data to the nextturn variable
    /// </summary>
    private void Start()
    {
        guiText.text = turnText + turn;

    }

    public void GoToNextTurn()
    {
        //TimerManager.Instance.AddTimer(Turn, 1);
        turn++;
        guiText.text = turnText + turn;
    }

    private void Turn()
    {
        nextTurn?.Invoke();
    }


}
