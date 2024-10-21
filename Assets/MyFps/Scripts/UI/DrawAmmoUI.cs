using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class DrawAmmoUI : MonoBehaviour
    {
        #region Variables
        public TextMeshProUGUI ammoCount;
        #endregion
        void Update()
        {
            ammoCount.text = PlayerStats.Instance.AmmoCount.ToString();
        }
    }
}

