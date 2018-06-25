using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using shooter;
using selecWeapon;

namespace playershoots
{
    public class PlayerShoots : MonoBehaviour
    {

       
        float positionX;
        float positionY;
        public Animator animator;
        public static bool isShooting = false;
        public static bool isReloading = false;
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
        const float shotgunFrecuency=0.5f;
        const float pistolFrecuency = 0.2f;

        //Audio
        public AudioSource audioGuns;
        public AudioClip pistolShoot;
        public AudioClip pistolReload;
        public AudioClip rifleShoot;
        public AudioClip rifleReload;
        public AudioClip shotgunShoot;
        public AudioClip shotgunReload;

        public AudioSource audioCollision;
        public AudioClip munitionBox;


        //--------balas en cargador,tamaño de cargador,municion maxima
        public static int[,] munitions = new int[,]{
            {15,15,999},//pistola municion maxima infinita
            {0, 50,100},//rifle
            {5,5,20}//Escopeta
        };



        void Awake()
        {
            
        }
        void Start()
        {

            munition = munitions[0, 0];
            charger = munitions[0, 1];
            maxMunition = munitions[0, 2];
            state = 0;
            setPistolMunition(munition,maxMunition);
        }


        void Update()
        {
            positionX = transform.position.x;
            positionY = transform.position.y;
            if (isReloading == false)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1) && state!=0)
                {
                    audioGuns.Stop();
                    if (state == 1)
                    {
                        setRifleMunition(munition, maxMunition);
                    }
                    else if (state == 2)
                    {
                        setShotgunMunition(munition, maxMunition);
                    }
                    state = 0;
                    munition = munitions[0, 0];
                    charger = munitions[0, 1];
                    maxMunition = munitions[0, 2];
                }

                if (Input.GetKeyDown(KeyCode.Alpha2) && state != 1)
                {
                    audioGuns.Stop();
                    if (state == 0)
                    {
                        setPistolMunition(munition, maxMunition);
                    }
                    else if (state == 2)
                    {
                        setShotgunMunition(munition, maxMunition);
                    }
                    state = 1;
                    munition = munitions[1, 0];
                    charger = munitions[1, 1];
                    maxMunition = munitions[1, 2];
                }

                if (Input.GetKeyDown(KeyCode.Alpha3) && state != 2)
                {
                    audioGuns.Stop();
                    if (state == 0)
                    {
                        setPistolMunition(munition, maxMunition);
                    }
                    else if (state == 1)
                    {
                        setRifleMunition(munition, maxMunition);
                    }
                    state = 2;
                    munition = munitions[2, 0];
                    charger = munitions[2, 1];
                    maxMunition = munitions[2, 2];
                }
            }
        }

        void FixedUpdate()
        {
            if (!isReloading)
            {
                //recarga de pistola y rifle
                if (Input.GetKeyDown(KeyCode.R) && !isShooting && munition < charger && maxMunition > 0 && state!=2)
                {

                    isReloading = true;
                    if (state==0)
                    {
                        audioGuns.clip = pistolReload;
                        audioGuns.Play();
                    }
                    else
                    {
                        audioGuns.clip = rifleReload;
                        audioGuns.Play();
                    }
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
                        maxMunition = 999;
                    }
                }//recarga de escopeta
                else if (Input.GetKeyDown(KeyCode.R) && !isShooting && munition < charger && maxMunition > 0 && state==2)
                {
                    audioGuns.clip = shotgunReload;
                    audioGuns.Play();
                    isReloading = true;
                    animator.SetBool("IsReloading", true);
                    maxMunition--;
                    munition++;
                }

                //Gestion de disparos
                //Pistola
                if (Input.GetKeyDown(KeyCode.Mouse0) && state == 0 && munition > 0)
                {
                    if (Time.time - lastShoot > pistolFrecuency)
                    {
                        weapon.shoot();
                        audioGuns.clip = pistolShoot;
                        audioGuns.Play();
                        isShooting = true;
                        animator.SetBool("IsShooting", true);
                        --munition;
                        if (isShooting == true)
                        {
                            AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
                            if (info.IsName("shoot") && info.normalizedTime >= 1F)
                            {
                                setIsShootingFalse();
                            }
                        }
                        lastShoot = Time.time;
                    }
                }//Rifle
                else if (Input.GetKey(KeyCode.Mouse0) && state == 1 && munition > 0)
                {
                    if (Time.time - lastShoot > rifleFrequency)
                    {
                        weapon.shoot();
                        audioGuns.clip = rifleShoot;
                        audioGuns.Play();
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
                        lastShoot = Time.time;
                    }
                //Escopeta
                }else if(Input.GetKeyDown(KeyCode.Mouse0) && state == 2 && munition > 0)
                {
                    if (Time.time - lastShoot > shotgunFrecuency)
                    {
                        audioGuns.clip = shotgunShoot;
                        audioGuns.Play();
                        weapon.shotgunShoot();
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
            Debug.Log("isreloading false");
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
        public void setShotgunMunition(int muni, int maxMuni)
        {
            munitions[2, 0] = muni;
            munitions[2, 2] = maxMuni;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("RifleMunition"))
            {
                audioCollision.clip = munitionBox;
                audioCollision.Play();
                if (state==1)
                {
                    maxMunition += Random.Range(10, 25);
                }
                else
                {
                    munitions[1, 2] += Random.Range(10, 25);
                }
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.CompareTag("ShotgunMunition"))
            {
                audioCollision.clip = munitionBox;
                audioCollision.Play();
                if (state == 2)
                {
                    maxMunition += Random.Range(3, 6);
                }
                else
                {
                    munitions[2, 2] += Random.Range(3, 6);
                }
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.CompareTag("MisionObject"))
            {
                Destroy(collision.gameObject);
            }

        }
        
    }
    
}
