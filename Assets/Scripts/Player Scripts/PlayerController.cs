using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rb;
    private Animator animator;
    public Animator feetAnimator;
    public float speed=5f;
    public static int life=100;
    int EnemyDamage;

    
    
    


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start () {
        EnemyDamage = EnemyMovement.damage;
    }
    void Update () {
    }


    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 direccion = new Vector2(horizontal, vertical).normalized;

        rb.velocity = direccion * speed;//¿es necesario que velocidad esta tambien regulada por time.deltatime?

        if (horizontal !=0 || vertical!=0 )
        {
            animator.SetBool("IsRunning",true);
            feetAnimator.SetBool("IsRunning",true);

        }else if(horizontal==0 && vertical==0){
            feetAnimator.SetBool("IsRunning",false);
            animator.SetBool("IsRunning", false);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag.Equals("Attack"))
        {
            life -=EnemyDamage;
        }
        if (collision.tag.Equals("Health"))
        {
            life += 15;
            life += 15;
            Destroy(collision.gameObject);
        }
    }
}
