using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Timers;
namespace Context {
    public class DateTimer : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI year;
        [SerializeField]
        private TextMeshProUGUI week;
        [SerializeField]
        private Date date;
        [SerializeField]
        private GameClear gameClear;
        private int WeeksLeft = 779;
        private string timeLeft = " Weeks left until the end of 2030";

        public void Start()
        {
            week.text = "Week: " + date.beginWeek.ToString();
            year.text = date.beginYear.ToString();
        }
        public void NextDate()
        {
            week.text = "Week: " + date.currentWeek++.ToString();
            if (date.currentWeek == 53)
            {
                date.currentWeek = 1;
                date.currentYear++;
            }

            week.text = string.Format("Week: {0}", date.currentWeek);
            year.text = string.Format("{0}", date.currentYear);

        }

        public void EndDate()
        {
            AudioManager.Instance.StopSound();
            AudioManager.Instance.Lose.SetActive(true);
            gameClear.SetGameClear();
            TimerManager.Instance.AddTimer(QuitGame, 5);
        }

        public void UpdateText(TextMeshProUGUI tmp)
        {
            WeeksLeft--;
            tmp.text = WeeksLeft + timeLeft;
            if(WeeksLeft == 0)
                EndDate();
        }

        private void QuitGame()
        {
            Application.Quit();
        }

    }
    [System.Serializable]
    public class Date
    {
        public int beginYear = 2015;
        public int beginWeek = 1;

        public int currentWeek;
        public int currentYear;

        public int endYear = 2030;
        public int endWeek = 3;
    }
}