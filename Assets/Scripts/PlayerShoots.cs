using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoots : MonoBehaviour {

    Rigidbody2D rb;
    float positionX;
    float positionY;
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

    void Update()
    {
        positionX = transform.position.x;
        positionY = transform.position.y;
    }

    void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.R) && !isShooting && !isReloading)
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
