using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace shooter
{
    public class Weapon : MonoBehaviour
    {
        public float damagePistol = 10f;
        public LayerMask whatToHit;
        public Transform firePoint;
        public Transform bulletPrefab;


        void Start()
        {

        }

        void Awake()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void shoot()
        {
            Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
            //RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit);
            shootBullet();
            Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100);
        }

        void shootBullet()
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
