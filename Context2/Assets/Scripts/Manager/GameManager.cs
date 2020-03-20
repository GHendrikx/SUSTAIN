using FMODUnity;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Context
{
    /// <Information>
    /// This class is generated with the UML tool from Geoffrey Hendrikx.
    /// </Information>
    public class GameManager : Singleton<GameManager>
    {

        [SerializeField]
        private StudioEventEmitter studioEventAllocatie;
        public StudioEventEmitter StudioEventAllocatie
        {
            get
            {
                return studioEventAllocatie;
            }
            set
            {
                studioEventAllocatie = value;
            }
        }

        public bool ShowTutorial;
        public GameObject TutorialPanel;
        public static int CURRENTPHASE = 5;
        public static string SPRITEPATH = "ART/UI_PHASE_2/16X16/v2/";
        [SerializeField]
        private IOManager ioManager;
        public IOManager IOManager 
        {
            get
            {
                return ioManager;
            }
            set
            {
                ioManager = value;
            }
        
        }
        
        [SerializeField]
        private UIManager uiManager;
        public UIManager UIManager
        {
            get
            {
                return uiManager;
            }
            set
            {
                uiManager = value;
            }
        }

        /// <summary>
        /// allocation buttons
        /// </summary>
        private List<UpdateButton> allocationButtons;
        public List<UpdateButton> AllocationButtons
        {
            get
            {
                return allocationButtons;
            }
            set
            {
                allocationButtons = value;
            }
        }

        /// <summary>
        /// research buttons
        /// </summary>
        private List<UpdateButton> researchButtons;
        public List<UpdateButton> ResearchButtons
        {
            get
            {
                return researchButtons;
            }
            set
            {
                researchButtons = value;
            }
        }

        [SerializeField]
        private AI ai;
        public AI AI
        {
            get
            {
                return ai;
            }
            set
            {
                ai = value;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            TutorialPanel.SetActive(ShowTutorial);
        }
        private void Start() =>
            PlayerPrefs.SetString("Name", "");

        public void QuitGame() =>
            Application.Quit();

        public void SwitchScene(int index) =>
            SceneManager.LoadScene(index);
    }
}