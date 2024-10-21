using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class GameOver : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;

        [SerializeField] private string loadToScene = "PlayScene";
        #endregion

        private void Start()
        {
            // ���콺 Ŀ�� ���� ����
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // ���̵��� ȿ��
            fader.FromFade();
        }

        public void Retry()
        {
            fader.FadeTo(loadToScene);
        }

        public void Menu()
        {
            Debug.Log("Goto Menu");
        }
    }
}

