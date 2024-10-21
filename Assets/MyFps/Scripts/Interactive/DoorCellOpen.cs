using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MyFps
{
    public class DoorCellOpen : Interactive
    {
        #region Variables
        private Animator animator;
        private Collider m_Collider;
        public AudioSource audioSource;
        // 
        #endregion

        private void Start()
        {
            animator = GetComponent<Animator>();
            m_Collider = GetComponent<BoxCollider>();
        }

        protected override void DoAction()
        {
            animator.SetBool("isOpen", true);
            GetComponent<Collider>().enabled = false;
            audioSource.Play();
        }
    }
}

