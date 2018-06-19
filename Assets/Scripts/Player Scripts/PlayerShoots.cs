using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using shooter;
using selecWeapon;

namespace playershoots
{
    public class PlayerShoots : MonoBehaviour
    {

        //Rigidbody2D rb;
        float positionX;
        float positionY;
        private Animator animator;
        bool isShooting = false;
        bool isReloading = false;
        public GameObject moozle;
        public GameObject clipEmptyPrefab;
        public Weapon weapon;
        public WeaponSelector weaponSelector;
        public static int state;
        public static int munition;
        private int charger;
        public static int maxMunition;
        float lastShoot;
        const float rifleFrequency = 0.15f;
        //--------balas en cargador,tamaño de cargador,municion maxima
        public static int[,] munitions = new int[,]{
            {0,15,99},//pistola municion maxima infinita
            {0, 50,100},//rifle
            {0,5,0}//Escopeta
        };




        void Awake()
        {
            //rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }
        void Start()
        {
            munition = munitions[0, 0];
            charger = munitions[0, 1];
            maxMunition = munitions[0, 2];

            //#if UNITY_EDITOR
            //HACKS();
            //#endif
        }

        //BORRAME
        //void HACKS()
        //{
        //    maxMunition = 12;
        //}

        void Update()
        {
            positionX = transform.position.x;
            positionY = transform.position.y;
            Debug.Log("estado actual" + state);

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                
                if (state == 1)
                {
                    setRifleMunition(munition, maxMunition);
                }
                else if (state == 2)
                {
                    //setShotgunMunition(munition, maxMunition);
                }
                state = 0;
                munition = munitions[0, 0];
                charger = munitions[0, 1];
                maxMunition = munitions[0, 2];
                //Debug.Log("municion de la pistola" + munition);
                //Debug.Log("cargador de la pistola" + charger);
                //Debug.Log("municion maxima de la pistola" + maxMunition);
                
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                

                if (state == 0)
                {
                    setPistolMunition(munition, maxMunition);
                }
                else if (state == 2)
                {
                    //setShotgunMunition(munition, maxMunition);
                }
                state = 1;
                munition = munitions[1, 0];
                charger = munitions[1, 1];
                maxMunition = munitions[1, 2];
                //Debug.Log("municion de la rifle" + munition);
                //Debug.Log("cargador de la rifle" + charger);
                //Debug.Log("municion maxima del rifle" + maxMunition);
            }
            //if (Input.GetKeyDown(KeyCode.Alpha3)&& state!=2)
            //{
            //    state=2;
            //    if (state == 0)
            //    {
            //        weaponSelector.setPistolMunition(munition, maxMunition);
            //    }
            //    else if (state == 1)
            //    {
            //        weaponSelector.setRifleMunition(munition, maxMunition);
            //    }
            //    munition = munitions[state, 0];
            //    charger = munitions[state, 1];
            //    maxMunition = munitions[state, 2];
            //}
        }



        void FixedUpdate()
        {
            if (!isReloading)
            {
                if (Input.GetKeyDown(KeyCode.R) && !isShooting && munition < charger && maxMunition > 0)
                {

                    isReloading = true;
                    animator.SetBool("IsReloading", true);
                    throwclip();

                    int r = charger - munition;
                    int m = maxMunition - r;
                    if (m < 0)
                        r += m;

                    maxMunition -= r;
                    munition += r;

                    if (state == 0)
                    {
                        maxMunition = 99;
                    }
                }
                if (Input.GetKeyDown(KeyCode.Mouse0) && state == 0 && munition > 0)
                {
                    weapon.shoot();
                    moozle.SetActive(true);
                    isShooting = true;
                    animator.SetBool("IsShooting", true);
                    --munition;
                    if (isShooting == true)
                    {
                        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
                        if (info.IsName("Shoot") && info.normalizedTime >= 1F)
                        {
                            setIsShootingFalse();
                        }
                    }

                }
                else if (Input.GetKey(KeyCode.Mouse0) && state == 1 && munition > 0)
                {
                    if (Time.time - lastShoot > rifleFrequency)
                    {
                        weapon.shoot();
                        moozle.SetActive(true);
                        isShooting = true;
                        animator.SetBool("IsShooting", true);
                        --munition;
                        //Debug.Log("municion del rifle es" + munition);
                        if (isShooting == true)
                        {
                            AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
                            if (info.IsName("Shoot") && info.normalizedTime >= 1F)
                            {
                                setIsShootingFalse();
                            }
                        }
                        lastShoot = Time.time;
                    }
                }
            }
            else
            {
                AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
                if (info.IsName("Reload") && info.normalizedTime >= 1F)
                {
                    setIsReloadingFalse();
                }
            }
        }

        void throwclip()
        {

            Instantiate(clipEmptyPrefab, new Vector2(positionX + Random.Range(-0.6f, 0.6f), positionY + Random.Range(-0.6f, 0.6f)), Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360f))));
        }
        void setIsShootingFalse()
        {

            isShooting = false;
            animator.SetBool("IsShooting", false);
        }

        void setIsReloadingFalse()
        {
            isReloading = false;
            animator.SetBool("IsReloading", false);
        }

        public void setPistolMunition(int muni, int maxMuni)
        {
            munitions[0, 0] = muni;
            munitions[0, 2] = maxMuni;
        }
        public void setRifleMunition(int muni, int maxMuni)
        {
            munitions[1, 0] = muni;
            munitions[1, 2] = maxMuni;

        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(collision.gameObject);
            if (collision.gameObject.CompareTag("RifleMunition"))
            {
                if (state==1)
                {
                    
                    maxMunition = munitions[1, 2] += Random.Range(10, 25);
                }
                else
                {
                    
                    munitions[1, 2] += Random.Range(10, 25);
                }
            }
            if (collision.gameObject.CompareTag("ShotgunMunition"))
            {
                if (state == 2)
                {
                    
                    maxMunition = munitions[1, 2] += Random.Range(3, 6);
                }
                else
                {
                    munitions[1, 2] += Random.Range(3, 6);
                }
            }
            Destroy(collision.gameObject);
        }
    }
}
