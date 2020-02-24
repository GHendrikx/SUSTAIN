using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeAbilities : MonoBehaviour
{
    [SerializeField]
    private Text basePointText;
    [SerializeField]
    private Text abilityPointText;

    public void CalculateStatus(int amount)
    {
        int basePoints = 0;
        int points = 0;

        try
        {
            basePoints = Convert.ToInt32(basePointText.text);
            points = Convert.ToInt32(abilityPointText.text);
        }
        catch(Exception e)
        {
            Debug.Log("Contact Geoffrey Hendrikx when you get this error");
        }

        if ((basePoints + -amount) < 0 || (points + amount) < 0)
            return;

        basePoints = basePoints + -amount;
        points = points + amount;

        basePointText.text = basePoints.ToString();
        abilityPointText.text = points.ToString();
    }
}
