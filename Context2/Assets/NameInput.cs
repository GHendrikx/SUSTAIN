using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameInput : MonoBehaviour
{
    public string PlayerName;
    public GameObject inputeField;
    public GameObject storename;
    public TextMeshProUGUI textDisplay;

    public void StoreName()
    {
        PlayerName = inputeField.GetComponent<Text>().text;
        //textDisplay.GetComponent<TextMeshProUGUI>().text = "well met " + PlayerName +  " \n That is an interesting name. \n" + PlayerName + " you will be tested by running the 3th SDG good health and well-being, \n if your programme runs smoothly you will be assigned to run additional SDG’s.";
    }
}
