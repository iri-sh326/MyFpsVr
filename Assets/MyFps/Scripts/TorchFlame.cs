using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{
    public class TorchFlame : MonoBehaviour
    {
        #region Variables
        public Transform torchLight;    // 토치라이트 객체
        private Animation flameAnim;    //

        // 1초 타이머
        [SerializeField] private float flameTimer = 1f;
        private float countdown = 0f;

        int lightMod;
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            // 초기화
            flameAnim = torchLight.GetComponent<Animation>();
            lightMod = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if(lightMod == 0)
            {
                StartCoroutine(FlameAnimation());
            }
            
            /*
            // 1초마다 1번씩 랜덤한 라이트 애니메이션을 플레이
            if(countdown <= 0f)
            {
                // 랜덤 애니메이션 플레이
                LightAnimation();

                // 초기화
                countdown = flameTimer;
            }
            countdown -= Time.deltaTime;
            */
        }

        IEnumerator FlameAnimation()
        {
            lightMod = Random.Range(1, 4);

            switch (lightMod)
            {
                case 1:
                    flameAnim.Play("TorchLightAnim01");
                    break;
                case 2:
                    flameAnim.Play("TorchLightAnim02");
                    break;
                case 3:
                    flameAnim.Play("TorchLightAnim03");
                    break;
            }

            yield return new WaitForSeconds(1.0f);
            lightMod = 0;
        }

        // 랜덤 애니메이션 플레이
        void LightAnimation()
        {
            lightMod = Random.Range(1, 4);

            switch (lightMod)
            {
                case 1:
                    flameAnim.Play("TorchLightAnim01");
                    break;
                case 2:
                    flameAnim.Play("TorchLightAnim02");
                    break;
                case 3:
                    flameAnim.Play("TorchLightAnim03");
                    break;
            }



        }
    }
}

