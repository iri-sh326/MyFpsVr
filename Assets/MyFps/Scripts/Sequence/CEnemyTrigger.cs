using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class CEnemyTrigger : MonoBehaviour
    {
        #region Variables
        public GameObject theDoor;  // ��
        public AudioSource doorBang;    // �� ����

        public AudioSource bgm01;   // ���ξ� 1 �����
        public AudioSource bgm02;   // �� ���� �����

        public GameObject theRobot;     // ��
        #endregion
        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySequence());
        }

        // Ʈ���� �۵��� �÷���
        IEnumerator PlaySequence()
        {
            // �� ����
            theDoor.GetComponent<Animator>().SetBool("isOpen", true);
            theDoor.GetComponent<BoxCollider>().enabled = false;

            // �� ����
            bgm01.Stop();
            doorBang.Play();

            // Enemy Ȱ��ȭ
            theRobot.SetActive(true);

            yield return new WaitForSeconds(1f);

            // Enemy ���� ����
            bgm02.Play();

            // Ÿ���� ���� �ȱ�
            RobotController robot = theRobot.GetComponent<RobotController>();
            if(robot != null)
            {
                robot.SetState(RobotState.R_Walk);
            }

            // Ʈ���� ų
            Destroy(this.gameObject);
        }
    }
}

