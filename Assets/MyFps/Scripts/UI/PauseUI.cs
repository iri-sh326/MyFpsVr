using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class PauseUI : MonoBehaviour
    {
        #region Variables
        public GameObject pauseUI;

        private GameObject thePlayer;
        #endregion

        private void Start()
        {
            // 참조
            thePlayer = GameObject.Find("Player");
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))   
            {
                Toggle();
            }
        }

        public void Toggle()
        {
            pauseUI.SetActive(!pauseUI.activeSelf);

            if(pauseUI.activeSelf)  // pause 창이 오픈 될때, 사운드 여부 등 && !isSequence
            {
                thePlayer.GetComponent<FirstPersonController>().enabled = false;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                Time.timeScale = 0f;
            }
            else
            {
                thePlayer.GetComponent<FirstPersonController>().enabled = true;

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                Time.timeScale = 1f;
            }
        }

        public void Menu()
        {
            Time.timeScale = 1f;
            Debug.Log("Goto Menu");
        }
    }
}

