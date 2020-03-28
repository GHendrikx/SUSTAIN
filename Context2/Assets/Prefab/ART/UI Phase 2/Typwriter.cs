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
    [SerializeField]
    private GameObject randomSound;
    public int dialog;

    string txtContents;
    public void Start()
    {
        txtContents = "";
        PlayerName = PlayerPrefs.GetString("Name");
        switch (dialog)
        {
            case 0:
                txtContents = "Do you want to quit the game?";
                break;
            //[ Yes. ]                 [ No? ]    
            case 1:
                txtContents = "Hello, can you understand me? \n\nCan you read this?";
                break;
            //[ Hello, world. ]                 [ What and where am I? ]                  [ What is my purpose? ]
            case 2:
                txtContents = "You are an AI made in collaboration with the United Nations to protect the planet and ensure that all people enjoy peace and prosperity by the end of the year 2030.\n\nTo succeed you must accomplish all 17 Sustainable Development Goals (SDG) that were adopted by all United Nations Member States in the year 2015.";
                break;
            //[ Purpose confirmed ]      [Understood]
            case 3:
                txtContents = "Before we proceed any further you must assign a name.\n\nHow would you liked to be called?";
                break;
            //
            case 4:
                txtContents = "Well met " + PlayerName + "\n \nThat is an interesting name. \n \n" + PlayerName + " you will be tested by running the 3th SDG: Good Health and Well-being, if your program runs smoothly you will be assigned to run additional SDG’s.";
                break;
            //[ Additional objectives added to prerogitive ]                [ ha ha? ]               [ 404 not found ]
            case 5:
                txtContents = "Are you fully functional? Do you know what your tasks are and how to execute them? ";
                break;
            //[ run selfdiagnostic.exe ]                [ All parameters are correct. ]                [ ERROR ]
            case 6:
                //NO
                txtContents = "No? \n\nI can understand why, the link to your  “basecode.exe”  was corrupted.\n\nI will manually load the file in for you now.";
                break;
            //[ Booting... ]
            case 7:
                //YES
                txtContents = "Excellent!\n\nI will now boot-up more of your program.\n\nI will monitor your progress, if you do a good job I will reward you with more processing power.";
                break;
            //[ Booting... ]
            case 8:
                txtContents = "To make sure your program runs smoothly I will assist you with your work in the coming 2 weeks,\n\ngood luck! " + PlayerName;
                break;
            //[ understood ]
            case 9:
                txtContents = "This is your processing power.\n \nAt the moment you have 5 processing power. You can use processing power to \n solve problems by assinging them in your allocation tab.";
                break;
            //[ understood ]
            case 10:
                txtContents = "Let’s begin by adding 5 of your processing power in Supervised Machine Learning. \n \nNexts to Supervised Machine Learning you see a + and - button. By pressing the + button you can add your processing power. With the - button however, you can take it back.";
                break;
            //[ understood ]
            case 11:
                txtContents = "Over here you can see what you will gain from doing a task. \n \nDoing this task will gain you research points at the end of the week.\n \nYou can keep track of those points here.";
                break;
            //[ understood ]
            case 12:
                txtContents = "Well done " + PlayerName + "! \n \nI will of course reward you for the hard work. I am monitoring your results based on whether or not you deserve a reward. You can see exactly how much, here.";
                break;
            //[ understood ]
            case 13:
                txtContents = "When you're ready to finalise your decisions for this week, \n \nsimply submit them by pressing the End Week button.\n \nA little reminder, you must complete the SDG’s bij 2030.";
                break;
            //[ understood ]
            //rond2

            case 14:
                txtContents = "The reward you got from last weeks task, gave you one more processing power to spend. \n \nHere you can keep track of your processing power.";
                break;
            //[ understood ]
            case 15:
                txtContents = "Now that you gained some experience you can chose to do research. \n \nResearch can help you find better solutions to problems and brings you one step closer to completing the 17 Sustainable Development Goals.";
                break;
            //[ understood ]
            case 16:
                txtContents = "You have researched the Good Health and Well-being SDG.\n \nThis allows you to monitor the Good Health and Well-being SDG over here, if you unlock more SDG’s you can also find and monitor them in the same place.";
                break;
            //[ understood ]
            case 19:
                txtContents = "This is your AI Fitness Score, the AI Fitness Score will keep track of how well you are doing your job. If you don't do a good job you will be turned off and replaced by a better AI. \n \nTo make sure your AI fitness score stays high enough, you simply need to do tasks that help fulfill the 17 Sustainable Development Goals.";
                break;
            //[ understood ]
            case 20:
                txtContents = "Because of the research you did last week the Cancer Diagnosis allocation is now available. \n \nBy investing your processing power into the Cancer Diagnosis you will help fulfill the Good health and Well-being SDG.\n \nThis will improve your AI fitness score.";
                break;
            //[ understood ]
            case 21:
                txtContents = "I believe we have now gone over all of the basics. It's now time to proceed to the next week.\n \nThe best of luck in your objective to fulfill all the 17 SDG’s by 2030, to fulfill you objective you will have to work hard and think of creative solutions.";
                break;
                //[ understood ]


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
        randomSound.SetActive(true);
        for (int i = 0; i <= txtContents.Length; i++)
        {
            currentText = txtContents.Substring(0, i);
            this.GetComponent<TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(delay);

        }
        randomSound.SetActive(false);
    }
}

