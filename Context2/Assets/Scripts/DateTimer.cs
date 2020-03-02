using UnityEngine;
using UnityEngine.UI;

public class DateTimer : MonoBehaviour
{
    [SerializeField]
    private Text dateText;
    
    public Date date;

    public void NextDate()
    {
        date.currentMonth++;
        if (date.currentMonth > 12)
        {
            date.currentYear++;
            date.currentMonth = 1;
        }

        dateText.text = string.Format("{0}/{1}",date.currentMonth,date.currentYear); 

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