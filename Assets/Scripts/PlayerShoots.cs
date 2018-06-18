using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using shooter;
using selecWeapon;


public class PlayerShoots : MonoBehaviour {

    Rigidbody2D rb;
    float positionX;
    float positionY;
    private Animator animator;
    bool isShooting = false;
    bool isReloading = false;
    public GameObject moozle;
    public GameObject clipEmptyPrefab;
    public Weapon weapon;
    public WeaponSelector weaponSelector;
    public int state;
    public static int munition;
    public int charger;
    public static int maxMunition;
    
    


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Start () {
        state = WeaponSelector.state;
        munition = WeaponSelector.munitions[0, 0];
        charger = WeaponSelector.munitions[0, 1];
        maxMunition = WeaponSelector.munitions[0, 2];

        #if UNITY_EDITOR
        HACKS();
        #endif
    }

    //BORRAME
    void HACKS()
    {
        maxMunition = 12;
    }

    void Update()
    {
        positionX = transform.position.x;
        positionY = transform.position.y;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (state==1)
            {
                weaponSelector.setRifleMunition(munition, maxMunition);
            }else if (state==2)
            {

            }
            munition = WeaponSelector.munitions[state, 0];
            charger = WeaponSelector.munitions[state, 1];
            maxMunition = WeaponSelector.munitions[state, 2];

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (state == 0)
            {
                weaponSelector.setPistolMunition(munition, maxMunition);
            }
            else if (state == 1)
            {

            }
            munition = WeaponSelector.munitions[state, 0];
            charger = WeaponSelector.munitions[state, 1];
            maxMunition = WeaponSelector.munitions[state, 2];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (state == 0)
            {
                weaponSelector.setPistolMunition(munition, maxMunition);
            }
            else if (state == 1)
            {
                weaponSelector.setRifleMunition(munition, maxMunition);
            }
            munition = WeaponSelector.munitions[state, 0];
            charger = WeaponSelector.munitions[state, 1];
            maxMunition = WeaponSelector.munitions[state, 2];
        }
    }

    void FixedUpdate()
    {
        if (!isReloading)
        {
            if (Input.GetKeyDown(KeyCode.R) && !isShooting && munition<charger && maxMunition>0)
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

                if (state==0)
                {
                    maxMunition = 99;
                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse0) && state == 0 && munition>0)
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
            else if (Input.GetKey(KeyCode.Mouse0) && state == 1 && munition>0)
            {
                weapon.shoot();
                moozle.SetActive(true);
                isShooting = true;
                animator.SetBool("IsShooting", true);
                --munition;
                Debug.Log("municion del rifle es" + munition);
                if (isShooting == true)
                {
                    AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
                    if (info.IsName("Shoot") && info.normalizedTime >= 1F)
                    {
                        setIsShootingFalse();
                    }
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
        
        Instantiate(clipEmptyPrefab, new Vector2(positionX+Random.Range(-0.6f, 0.6f), positionY+Random.Range(-0.6f, 0.6f)), Quaternion.Euler(new Vector3(0,0,Random.Range(0,360f))));
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

 
}
