using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameInput : MonoBehaviour
{
    [HideInInspector]
    public string PlayerName;
    public string PlayerNameWithoutExe;
    public Text inputField;
    public TextMeshProUGUI textDisplay;

    public void StoreName()
    {
        PlayerName = inputField.text + "_v3_Final(2).exe";
        PlayerNameWithoutExe = inputField.text;
        PlayerPrefs.SetString("Name", PlayerName);
        PlayerPrefs.SetString("NameWithout", PlayerNameWithoutExe);
        textDisplay.text = PlayerName;
        //textDisplay.GetComponent<TextMeshProUGUI>().text = "well met " + PlayerName +  " \n That is an interesting name. \n" + PlayerName + " you will be tested by running the 3th SDG good health and well-being, \n if your programme runs smoothly you will be assigned to run additional SDG’s.";
    }
}
