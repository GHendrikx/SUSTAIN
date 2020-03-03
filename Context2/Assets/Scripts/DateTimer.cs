using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DateTimer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI month;
    [SerializeField]
    private TextMeshProUGUI year;

    public Date date;
    public void Start()
    {
        month.text = string.Format("{0}",(Months)date.currentMonth);
        year.text = date.currentYear.ToString();
    }
    public void NextDate()
    {
        date.currentMonth++;
        if (date.currentMonth == 12)
        {
            date.currentYear++;
            date.currentMonth = 0;
        }

        month.text = string.Format("{0}", (Months)date.currentMonth);
        year.text = string.Format("{0}", date.currentYear);

        CheckEndDate();
    }

    private void CheckEndDate()
    {
        if(date.currentMonth == date.endMonth && date.currentYear == date.endYear)
        {
            //GAME FUCKING OVER
        }
    }
}
[System.Serializable]
public class Date
{
    public int currentMonth;
    public int currentYear;

    public int beginYear = 2015;
    public int beginMonth = 1;

    public int endYear = 2030;
    public int endMonth = 12;

    public Date()
    {
        currentYear = beginYear;
        currentMonth = beginMonth;
    }

}

public enum Months
{
    January,
    February,
    March,
    April,
    May,
    June,
    Juli,
    August,
    September,
    October,
    November,
    December
}