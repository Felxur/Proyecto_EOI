using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace shooter
{
    public class Weapon : MonoBehaviour
    {
        public Transform firePoint;
        public Transform bulletPrefab;
        public GameObject bulletshotgun;
        


        void Start()
        {
            
        }
        void Awake()
        {
        }
        void Update()
        {
        }
        //public void shoot()
        //{
        //    Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        //    Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        //    RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit);
        //    shootBullet();
        //    Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100);
        //}
        public void shotgunShoot()
        {

            //GameObject bullet1 = (GameObject)Instantiate(bulletshotgun);
            //bullet1.transform.position = firePoint.transform.position;

            //GameObject bullet2 = (GameObject)Instantiate(bulletshotgun);
            //bullet2.transform.position = firePoint.transform.position;

            //Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0,0,6f));
            //Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, 3f));
            //Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, 0));
            //Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, -3f));
            //Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, -6f));
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);


        }

        public void shoot()
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
