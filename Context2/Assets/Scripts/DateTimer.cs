using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DateTimer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI year;
    [SerializeField]
    private TextMeshProUGUI week;
    [SerializeField]
    private Date date;
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

        CheckEndDate();
    }

    private void CheckEndDate()
    {
        if(date.currentYear == date.endYear && date.currentWeek == date.endWeek)
        {
            Application.Quit();
        }
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
