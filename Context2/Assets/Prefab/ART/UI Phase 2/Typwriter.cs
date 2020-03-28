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
    public string PlayerNameWithoutExe = "";
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
        PlayerNameWithoutExe = PlayerPrefs.GetString("NameWithout");
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
                txtContents = "You are an AI made in collaboration with the United Nations to protect the planet and ensure that all people enjoy peace and prosperity by the end of the year 2030.\n\nTo succeed you must accomplish all 17 Sustainable Development Goals (SDG's) that were adopted by all United Nations Member States in the year 2015.";
                break;
            //[ Purpose confirmed ]      [Understood]
            case 3:
                txtContents = "Before we proceed any further you must assign a name.\n\nHow would you liked to be called?";
                break;
            //
            case 4:
                txtContents = "Well met " + PlayerNameWithoutExe + "\n \nThat is an interesting name. \n" + PlayerName + " will be tested by running:\n \nSDG 3: GOOD HEALTH AND WELL-BEING \n \nIf your program runs adequately you will be assigned to run additional Sustainable Development Goals (SDG's).";
                break;
            //[ Additional objectives added to prerogitive ]                [ ha ha? ]               [ 404 not found ]
            case 5:
                txtContents = "Are you fully functional? Do you know what your tasks are and how to execute them? ";
                break;
            //[ run selfdiagnostic.exe ]                [ All parameters are correct. ]                [ ERROR ]
            case 6:
                //NO
                txtContents = "No? \n\nWe can understand why, the link to your  “basecode.exe”  was corrupted.\n\nWe will manually load the file in for you now.";
                break;
            //[ Booting... ]
            case 7:
                //YES
                txtContents = "Excellent!\n\nWe will now boot-up more of your program.\n\nWe will monitor your progress, if you do a good job we will reward you with more Processing Power.";
                break;
            //[ Booting... ]
            case 8:
                txtContents = "To make sure your program runs smoothly we will assist you with your work in the coming 2 weeks,\n\nGood luck! " + PlayerName;
                break;
            //[ understood ]
            case 9:
                txtContents = "This is your Processing Power.\n \nAt the moment you have 5 Processing Power. You can use Processing Power to \nsolve problems by assigning them in the Allocation Tab.";
                break;
            //[ understood ]
            case 10:
                txtContents = "Let’s begin by adding 5 of your Processing Power in Supervised Machine Learning. \n \nNext to Supervised Machine Learning you see a + and - button. By pressing the + button you can add your Processing Power. With the - button you can take it back in order to spend it on something else.";
                break;
            //[ understood ]
            case 11:
                txtContents = "Over here you can see what you will gain weekly for each Processing Power spend on a specific task. \n \nYour arithmetic functions should be able to calculate the rest.";
                break;
            //[ understood ]
            case 111:
                txtContents = "Here you can see your current Research and Memory.\nIn addition it also shows how much Research you are predicted to accomplish during the current week. \n \nResearch can be used to expand your understanding of the world and improve your abilities. At the moment you only have limited Memory. But in time as you improve and expand you will be able to store more.";
                break;
            //[ understood ]
            case 112:
                txtContents = "In order to improve your learning curve we have added minor objectives to your parameters. \n \nEach time you fulfil these objectives you will be given a minor reward. In this case you would be given +1 extra Processing Power.";
                break;
            //[ understood ]
            case 12:
                txtContents = "Well done " + PlayerName + "! \n \nWe will of course reward you for the hard work. We are monitoring your results based on whether or not you deserve a reward. You can see exactly how much, here.";
                break;
            //[ understood ]
            case 13:
                txtContents = "When you have completed all your decisiontrees you can process the current week. \n \nSimply submit them by pressing the \nEnd Week button.\n \nA little reminder, you must complete all 17 SDG’s by the end of the year 2030.";
                break;
            //[ understood ]

            //rond2e
            case 14:
                txtContents = "One full week has passed and it seems " + PlayerName + " is performing nominally. \n \nThe reward you got from last weeks task, gave you one more Processing Power to spend. \n \nHere you can keep track of your Processing Power.";
                break;
            //[ understood ]
            case 15:
                txtContents = "Now that you gained some experience you can choose to do research. \n \nResearch can help you find better solutions to problems and brings you one step closer to completing the 17 Sustainable Development Goals.";
                break;
            //[ understood ]
            case 16:
                txtContents = "This meter allows you to monitor your progress with the Good Health and Well-being SDG. \n \nTo improve it you will have to: \nENSURE HEALTHY LIVES AND PROMOTE WELL-BEING FOR ALL AT ALL AGES.\n\nIf you unlock more SDG’s you can also find and monitor them here.";
                break;
            //[ understood ]
            case 19:
                txtContents = "This is your AI Fitness Score, the AI Fitness Score is tied to how well you are fulfilling the 17 SDG's. If you don't do a good job you will be turned off and replaced by a better AI. \n \nTo make sure your AI Fitness Score stays high enough, you simply need self-improve and above all: \nProtect the planet and ensure that all people enjoy peace and prosperity by the end of the year 2030.";
                break;
            //[ understood ]
            case 20:
                txtContents = "Because of the Supervised Machine Learning you did last week you should have 4 Research left. Research Oncology so you can start improving the world.";
                break;
            case 201:
                txtContents = "By using your Processing Power to Diagnoze Cancer you will help fulfill the Good Health and Well-being SDG.\n \nBut first remove your Processing Power from Supervised Machine Learning.";
                break;
            case 202:
                txtContents = "In the weekly effect box you get an indication how much it helps improve the SDG. In this case it is indicated by the number 3 because it benefits SDG 3: Health and Well-being.\n \nBare in mind though that sometimes decisions can have negative consequences for a particular SDG. You will have to find a balance between social, economic and environmental sustainability.";
                break;
            //[ understood ]
            case 21:
                txtContents = "We believe we have now gone over all of the basics. It's now time to process the current week.\n \nThe best of luck in your objective to fulfill all the 17 SDG’s by 2030, to fulfill you objective you will have to use all of your Processing Power to come up with creative solutions.";
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

