using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class PistolShoot : MonoBehaviour
    {
        #region Variables
        private Animator animator;

        public ParticleSystem muzzle;
        public AudioSource pistolShot;

        //public Transform camera;
        public Transform firePoint;

        // ����
        private float attackDamage = 5f;

        // ���� ������
        [SerializeField] private float fireDelay = 0.5f;
        private bool isFire = false;

        // ����Ʈ
        public GameObject hitImpactPrefab;
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            // ����
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            // ��
            if (Input.GetButtonDown("Fire") && !isFire)
            {
                if (PlayerStats.Instance.UseAmmo(1) == true)
                {
                    StartCoroutine(Shoot());
                }
            }
        }

        IEnumerator Shoot()
        {
            isFire = true;

            // �÷��̾� ��ó 100 �ȿ� ���� ������ ������ �������� �ش�.
            float maxDistance = 100f;
            RaycastHit hit;
            if(Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit, maxDistance))
            {
                // ������ �������� �ش�
                Debug.Log($"{hit.transform.name}���� �������� �ش�");
                IDamageable damageable = hit.transform.GetComponent<IDamageable>();
                if(damageable != null)
                {
                    damageable.TakeDamage(attackDamage);
                }

                GameObject eff = Instantiate(hitImpactPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(eff, 2f);
            }

            // �� ȿ�� - VFX, SFX
            animator.SetTrigger("Fire");

            pistolShot.Play();

            muzzle.gameObject.SetActive(true);
            muzzle.Play();

            yield return new WaitForSeconds(fireDelay);
            muzzle.Stop();
            muzzle.gameObject.SetActive(false);

            isFire = false;
        }

        private void OnDrawGizmosSelected()
        {
            float maxDistance = 100f;
            RaycastHit hit;
            bool isHit = Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit, maxDistance);

            Gizmos.color = Color.red;
            if (isHit)
            {
                Gizmos.DrawRay(firePoint.position, firePoint.forward * hit.distance);
            }
            else
            {
                Gizmos.DrawRay(firePoint.position, firePoint.forward * maxDistance);
            }

        }
    }
}

