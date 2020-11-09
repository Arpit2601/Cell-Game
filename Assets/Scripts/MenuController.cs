using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
    public class MenuController : MonoBehaviour
    {
        #region Default Values
        [Header("Default Menu Values")]
        [SerializeField] private float defaultBrightness;
        [SerializeField] private float defaultVolume;
        [SerializeField] private int defaultSen;
        [SerializeField] private bool defaultInvertY;

        [Header("Levels To Load")]
        public string _PlayButtonLevel;
        private string levelToLoad;

        private int menuNumber;
        #endregion

        #region Menu Dialogs
        [Header("Main Menu Components")]
        [SerializeField] private GameObject menuDefaultCanvas;
        [SerializeField] private GameObject GeneralSettingsCanvas;
        #endregion

        #region Initialisation - Button Selection & Menu Order
        private void Start()
        {
            menuNumber = 1;
        }
        #endregion
        private void ClickSound()
        {
            GetComponent<AudioSource>().Play();
        }

        #region Menu Mouse Clicks
        public void MouseClick(string buttonType)
        {

            // if (buttonType == "Controls")
            // {
            //     gameplayMenu.SetActive(false);
            //     controlsMenu.SetActive(true);
            //     menuNumber = 6;
            // }

            // if (buttonType == "Graphics")
            // {
            //     GeneralSettingsCanvas.SetActive(false);
            //     graphicsMenu.SetActive(true);
            //     menuNumber = 3;
            // }

            // if (buttonType == "Sound")
            // {
            //     GeneralSettingsCanvas.SetActive(false);
            //     soundMenu.SetActive(true);
            //     menuNumber = 4;
            // }

            // if (buttonType == "Gameplay")
            // {
            //     GeneralSettingsCanvas.SetActive(false);
            //     gameplayMenu.SetActive(true);
            //     menuNumber = 5;
            // }

            if (buttonType == "Exit")
            {
                Debug.Log("YES QUIT!");
                Application.Quit();
            }

            if (buttonType == "Play")
            {
                menuDefaultCanvas.SetActive(false);
                GeneralSettingsCanvas.SetActive(true);
                menuNumber = 2;
            }



            if (buttonType == "Level1")
            {
                SceneManager.LoadScene(1);
            }
            if (buttonType == "Level2")
            {
                SceneManager.LoadScene(2);
            }
            if (buttonType == "Level3")
            {
                SceneManager.LoadScene(3);
            }
            if (buttonType == "Level4")
            {
                SceneManager.LoadScene(4);
            }
            if (buttonType == "Level5")
            {
                SceneManager.LoadScene(5);
            }
            if (buttonType == "Level6")
            {
                SceneManager.LoadScene(6);
            }
            if (buttonType == "Level7")
            {
                SceneManager.LoadScene(7);
            }
            if (buttonType == "Level8")
            {
                SceneManager.LoadScene(8);
            }



            // if (buttonType == "LoadGame")
            // {
            //     menuDefaultCanvas.SetActive(false);
            //     loadGameDialog.SetActive(true);
            //     menuNumber = 8;
            // }

            // if (buttonType == "Play")
            // {
            //     menuDefaultCanvas.SetActive(false);
            //     PlayDialog.SetActive(true);
            //     menuNumber = 7;
            // }
        }
        #endregion


        #region Back to Menus


        public void GoBackToMainMenu()
        {
            menuDefaultCanvas.SetActive(true);
            GeneralSettingsCanvas.SetActive(false);
            menuNumber = 1;
        }

        public void ClickQuitOptions()
        {
            GoBackToMainMenu();
        }

        public void ClickNoSaveDialog()
        {
            GoBackToMainMenu();
        }
        #endregion
    }
