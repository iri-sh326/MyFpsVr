using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    // 플레이어의 속성, 데이터값을 관리하는 (싱글톤, DontDestory)클래스.. ammoCount
    public class PlayerStats : PersistentSingleton<PlayerStats>
    {
        #region Variables
        // 탄환 개수
        private int ammoCount;
        public int AmmoCount
        {
            get { return ammoCount; }
            set { ammoCount = value; }
        }
        #endregion

        private void Start()
        {
            // 속성값, Data 초기화
            AmmoCount = 0;
        }

        public void AddAmmo(int amount)
        {
            AmmoCount += amount;
        }

        public bool UseAmmo(int amount)
        {
            // 소지 개수 체크
            if(AmmoCount < amount)
            {
                Debug.Log("You need to reload!");
                return false;
            }

            AmmoCount -= amount;
            return true;
        }
    }

}
