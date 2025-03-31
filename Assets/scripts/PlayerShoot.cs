
using UnityEngine;

namespace Shooting
{
    public class playerShoot : MonoBehaviour
    {
        public GameObject BulletPrefab;
        public Transform firePoint;
        public int numbertest = 0;

        void Update()
        {
            Shoot();
        }

        void Shoot()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(BulletPrefab, firePoint.position, Quaternion.identity);
            }
        }
    }
}

