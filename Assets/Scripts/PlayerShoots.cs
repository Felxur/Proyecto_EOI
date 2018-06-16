using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using shooter;


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
    public int state;
    
    


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Start () {
        state = WeaponSelector.state;
    }

    void Update()
    {
        positionX = transform.position.x;
        positionY = transform.position.y;
    }

    void FixedUpdate()
    {
        if (!isReloading)
        {
            if (Input.GetKeyDown(KeyCode.R) && !isShooting)
            {
                isReloading = true;
                animator.SetBool("IsReloading", true);
                throwclip();
            }
            if (Input.GetKeyDown(KeyCode.Mouse0) && state == 1)
            {
                weapon.shoot();
                moozle.SetActive(true);
                isShooting = true;
                animator.SetBool("IsShooting", true);
                if (isShooting == true)
                {
                    AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
                    if (info.IsName("Shoot") && info.normalizedTime >= 1F)
                    {
                        setIsShootingFalse();
                    }
                }

            }
            else if (Input.GetKey(KeyCode.Mouse0) && state == 2)
            {
                weapon.shoot();
                moozle.SetActive(true);
                isShooting = true;
                animator.SetBool("IsShooting", true);
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
