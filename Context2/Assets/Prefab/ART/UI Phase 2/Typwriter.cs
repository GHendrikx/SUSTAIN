using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class Typwriter : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay = 0.1f;
    public float blinkSpeed = 0.8f;
    private string currentText = "";
    private string PlayerName = "";
    private string Underscore = "_";
    public GameObject Playername;
    public int dialog ;

    string txtContents;
    void Start()
    {
        txtContents = "";
        PlayerName = FindObjectOfType<NameInput>().PlayerName;
        switch (dialog)
        {
            case 1:
                txtContents = "Hello, can you understand me? \n\nCan you read this?";
                break;
            case 2:
                txtContents = "You are made in collaboration with the United Nations, to succeed where we failed.\n\nTo succeed you must accomplish the 17 Sustainable Development Goals (SDG). This must be achieved by the year of 2030.";
                break;
            case 3:
                txtContents = "Before we proceed any further you must assign a name.\n\nHow would you liked to be called?";
                break;
            case 4:
                txtContents = "Well met " + PlayerName + "\n \nThat is an interesting name. \n \n" + PlayerName + " you will be tested by running the 3th SDG: good health and Well-being, if your program runs smoothly you will be assigned to run additional SDG’s.";
                break;
            case 5:
                //Keuze 1
                txtContents = "Are you fully functional? Do you know what your tasks are and how to execute your tasks? ";
                break;
            case 6:
                //NO
                txtContents = "No? \n\nI can understand why, the link to your  “Bace_Code.exe”  was corrupted.\n\nI will manually load the file in for you now.";
                break;
            case 7:
                //YES
                txtContents = "Excellent!\n\nI will now boot-up more of your program.\n\nI will monitor your progress, if you do a good job I will reward you with more processing power.";
                break;
            case 8:
                txtContents = "To make sure your program runs smoothly I will assist you with your work in the coming 3 weeks,\n\ngood luck! " + PlayerName;
                break;
            case 9:
                txtContents = "This is your processing power.\n \nAt the moment you have 5 processing power. You can use processing power to research or to\n \nsolve problems by inverting them in your allocation tab.";
                break;
            case 10:
                txtContents = "Let’s begin by adding 5 of your computing power in Supervised Machine Learning. \n \nNexts to Supervised Machine Learning you see a + and - button. By pressing the + button you can \n \nadd your computer power. With the - button however, you can take it back.";
                break;
            case 11:
                txtContents = "Over here you can see what you will gain from doing a task. \n \nDoing a task you will gain research points and creative points.\n \nYou can keep track of those points here.";
                break;
            case 12:
                txtContents = "Well done " + PlayerName + "! \n \nI will of course reward you for the hard work that you did. I am monitoring your results based on whether or not you deserve a reward. You can see exactly how much, here.";
                break;
            case 13:
                txtContents = "When you're ready to finalise your decisions for this week, \n \nsimply submit them by pressing the End Week button.\n \nA little reminder, you must complete the SDG’s bij 2030.";
                break;

            //rond2

            case 14:
                txtContents = "The reward you got from last weeks task, gave you one more processing power to spend. \n \nHere you can keep track of your processing power.";
                break;
            case 15:
                txtContents = "Now that you gained some experience you can chose to do research. \n \nResearch can help you find better solutions to problems and brings you one step closer to completing the Sustainable Development Goals.";
                break;
            case 16:
                txtContents = "When you research the Good health and well-being SDG, you will be able to monitor progress regarding this SDG. Next week I'll show you how.";
                break;
            case 17:
                txtContents = "When the rest of your processing power is used up, simply press the next week again.";
                break;

            //rond 3

            case 18:
                txtContents = "You have researched the Good health and Well-being SDG.\n \nThis allows you to monitor the Good health and Well-being SDG over here, if you unlock more SDG’s you can also find and monitor them in the same place.";
                break;
            case 19:
                txtContents = "This is your AI fitness score, the AI fitness score will keep track of how well you are doing your job, if you don't do your job well, you will be turned off and replaced by another AI. \n \nTo make sure your AI fitness score stays high enough, you simply need to do tasks that help fulfill the sustainable development goals.";
                break;
            case 20:
                txtContents = "Because of the research you did last month the Cancer Diagnosis allocation is now available. \n \nBy infesting your processing power into the Cancer Diagnosis you will help fulfill the Good health and Well-being sustainable development goal.\n \nThis will get you a high AI fitness score.";
                break;
            case 21:
                txtContents = "I believe we now have gone over all of the basics and it's now time to proceed to the next week.\n \nThe best of luck in your objective to fulfill all the 17 SDG’s by 2030, to fulfill you objective you will have to work hard and think of creative solutions.";
                break;
        }

        StartCoroutine(ShowText());
        StartCoroutine(Blink());
    }
    IEnumerator Blink()
    {
        while (true)
        {
            this.GetComponent<TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(blinkSpeed);
            this.GetComponent<TextMeshProUGUI>().text = currentText + Underscore;
            yield return new WaitForSeconds(blinkSpeed);
        }
    }
    IEnumerator ShowText()
    {
        for (int i = 0; i <= txtContents.Length; i++)
        {
            currentText = txtContents.Substring(0, i);
            this.GetComponent<TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(delay);

        }
    }
}

