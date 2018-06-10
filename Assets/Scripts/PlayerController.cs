using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rb;
    private Animator animator;
    public Animator feetAnimator;
    public float speed= 5f;
    bool isReloading=false;
    bool isRunning=false;
    bool isFeetRunning = false;
    bool isShooting = false;
    


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start () {
        animator = GetComponent<Animator>();
    }

   
   
    // Update is called once per frame
    void Update () {
 


    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 direccion = new Vector2(horizontal, vertical).normalized;

        rb.velocity = direccion * speed;//¿es necesario que velocidad esta tambien regulada por time.deltatime?

        Debug.LogFormat("Vector de movimiento que genero: {0} {1}", horizontal, vertical);

        if (horizontal !=0 || vertical!=0 )
        {
            animator.SetBool("IsRunning",true);
            feetAnimator.SetBool("IsRunning",true);
        }else if(horizontal==0 && vertical==0){
            feetAnimator.SetBool("IsRunning",false);
            animator.SetBool("IsRunning", false);
        }
        if (Input.GetKeyDown(KeyCode.R) && !isShooting)
        {
            isReloading = true;
            animator.SetBool("IsReloading", true);
        }

    }

    void setIsReloadingFalse()
    {
        isReloading = false;
        animator.SetBool("IsReloading", false);
    }
    void setIsshootingFalse()
    {
        isShooting = false;
        animator.SetBool("IsShooting", false);
    }
}
