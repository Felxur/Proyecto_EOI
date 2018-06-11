using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoots : MonoBehaviour {

    Rigidbody2D rb;
    private Animator animator;
    bool isShooting = false;
    bool isReloading = false;
    bool isMozzle = false;
    public GameObject moozle;
    public GameObject clipEmptyPrefab;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Start () {
		
	}
	
	
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.R) && !isShooting)
        {
            isReloading = true;
            animator.SetBool("IsReloading", true);
            throwclip();
           
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isReloading)
        {
            moozle.SetActive(true);
            isShooting = true;
            animator.SetBool("IsShooting", true);
        }
    }

    void throwclip()
    {
        Instantiate(clipEmptyPrefab, transform.position, Quaternion.identity);
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
