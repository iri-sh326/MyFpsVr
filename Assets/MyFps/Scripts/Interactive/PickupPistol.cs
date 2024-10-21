using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class PickupPistol : Interactive
    {
        #region Variables
        // action
        public GameObject realPistol;
        public GameObject arrow;

        public GameObject enemyTrigger;
        public GameObject ammoBox;
        public GameObject ammoUI;
        #endregion

   

        protected override void DoAction()
        {
            realPistol.SetActive(true);
            arrow.SetActive(false);

            ammoBox.SetActive(true);
            actionUI.SetActive(true);

            enemyTrigger.SetActive(true);

            Destroy(gameObject);
        }
    }
}

