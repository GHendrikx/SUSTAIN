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

        public static int CURRENTPHASE = 1;
        
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

        public void QuitGame() =>
            Application.Quit();
        public void SwitchScene(int index) =>
            SceneManager.LoadScene(index);
    }
}