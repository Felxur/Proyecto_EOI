using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace shooter
{
    public class Weapon : MonoBehaviour
    {
        public Transform firePoint;
        public BulletController bulletPrefab;
        
        


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
            BulletController temp;
            temp = Instantiate(bulletPrefab);
            temp.transform.position = firePoint.transform.position;
            temp.transform.rotation = firePoint.rotation;
            

            temp = Instantiate(bulletPrefab);
            temp.transform.position = firePoint.transform.position;
            temp.transform.rotation = firePoint.rotation;
            temp.transform.Rotate(new Vector3(0,0,-12f));
            

            temp = Instantiate(bulletPrefab);
            temp.transform.position = firePoint.transform.position;
            temp.transform.rotation = firePoint.rotation;
            temp.transform.Rotate(new Vector3(0, 0, 12f));

            temp = Instantiate(bulletPrefab);
            temp.transform.position = firePoint.transform.position;
            temp.transform.rotation = firePoint.rotation;
            temp.transform.Rotate(new Vector3(0, 0, -24f));

            temp = Instantiate(bulletPrefab);
            temp.transform.position = firePoint.transform.position;
            temp.transform.rotation = firePoint.rotation;
            temp.transform.Rotate(new Vector3(0, 0, 24f));


        }

        public void shoot()
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
