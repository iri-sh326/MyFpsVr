using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class AOpening : MonoBehaviour
    {
        #region Variables
        public GameObject thePlayer;
        public SceneFader fader;

        // sequence UI
        public TextMeshProUGUI textBox;
        [SerializeField] private string sequence01 = "...Where am I?";
        [SerializeField] private string sequence02 = "I need get out of here";

        // ���� ����
        public AudioSource line01;
        public AudioSource line02;
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            // ���콺 Ŀ�� ���� ����
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            StartCoroutine(PlaySequence());
        }

        // ������ ������
        IEnumerator PlaySequence()
        {
            // 0. �÷��� ĳ���� ��Ȱ��ȭ
            thePlayer.GetComponent<FirstPersonController>().enabled = false;

            // 1. ���̵��� ����(1�� ��� �� ���̵��� ȿ��)
            //yield return new WaitForSeconds(1f);
            fader.FromFade(4f); // 5�ʵ��� ���̵� ȿ�� (1f + 4f)

            // 2. ȭ�� �ϴܿ� �ó����� �ؽ�Ʈ ȭ�� ���(3��)
            // (I need get out of here)
            textBox.gameObject.SetActive(true);
            textBox.text = sequence01;
            line01.Play();

            yield return new WaitForSeconds(3f);
            // (I need get out of here)
            textBox.text = sequence02;
            line02.Play();

            // 3. 3�� �Ŀ� �ó����� �ؽ�Ʈ�� ��������
            yield return new WaitForSeconds(3f);
            textBox.text = "";
            textBox.gameObject.SetActive(false);


            // 4. �÷��� ĳ���� Ȱ��ȭ
            thePlayer.GetComponent<FirstPersonController>().enabled = true;

            yield return null;
        }
    }
}

