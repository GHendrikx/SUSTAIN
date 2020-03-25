using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Context
{
    public class GameClear : MonoBehaviour
    {
        private int currentGameClear;
        public int CurrentGameClear
        {
            get
            {
                return currentGameClear;
            }
            set
            {
                currentGameClear = value;
            }
        }

        public void SetGameClear()
        {
            currentGameClear = 1;
            AudioManager.Instance.SetParameters(-999, currentGameClear, -999, -999, GameManager.Instance.StudioParameterBGM);
        }
    }
}