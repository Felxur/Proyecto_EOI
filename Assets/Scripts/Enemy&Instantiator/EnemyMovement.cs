using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using playershoots;

public class EnemyMovement : MonoBehaviour {
    private Animator animator;
    public float speed;
    private Transform target;
    public float stopingDistance;
    private bool isAttacking = false;
    int random;

    //daños
    public static int damage = 20;
    public int enemyLife = 60;
    public int bulletPistolDamage = 8;
    public int bulletRifleDamage = 17;
    public int bulletShotgunDamage = 15;


    //audio
    private float lastScream;
    private float screamFrecuency;
    public AudioSource audioEnemy;
    public AudioSource screamEnemy;
    public AudioSource attack;
    public AudioClip scream1;
    public AudioClip scream2;
    public AudioClip scream3;
    public AudioClip scream4;
    public AudioClip hit1;
    public AudioClip hit2;
    public AudioClip hit3;
    private AudioClip[] attacks;


    void Awake()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }
    void Start()
    {
        attacks = new AudioClip[]
        {
            (AudioClip)Resources.Load("Audio/Zombie/attack1"),
            (AudioClip)Resources.Load("Audio/Zombie/attack2"),
            (AudioClip)Resources.Load("Audio/Zombie/attack3"),
            (AudioClip)Resources.Load("Audio/Zombie/attack4"),
            (AudioClip)Resources.Load("Audio/Zombie/attack5"),
        };
        screamFrecuency = Random.Range(3f,6f);
    }


    void Update()
    {

        //gritos
        if (Time.time - lastScream > screamFrecuency)
        {
            scream();
            screamFrecuency = Random.Range(3f, 6f);
            lastScream = Time.time;
        }
        //selecciona objetivo cuando el jugador cambia de arma
        if (PlayerShoots.isReloading==false && (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3)))
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        //movimiento del enemigo hacia el jugador
        if (Vector2.Distance(transform.position, target.position) > stopingDistance && !isAttacking)
        {
            animator.SetBool("IsWalking", true);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.right = (target.transform.position - transform.position).normalized;
        }
        else
        {//ataque del enemigo
            animator.SetBool("IsWalking", false);
            isAttacking = true;
            animator.SetBool("IsAttacking", true);
            random = Random.Range(0, 4);
            if (isAttacking == true)
            {
                AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
                if (info.IsName("Attack") && info.normalizedTime >= 1F)
                {
                    setIsAttackingFalse();
                }
            }
        }
    }

    void setIsAttackingFalse()
    {
        isAttacking = false;
        animator.SetBool("IsAttacking", false);
    }
    
    //daño
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BulletPistol"))
        {
            hit();
            enemyLife -= bulletPistolDamage;

        }else if (collision.gameObject.CompareTag("BulletRifle"))
        {
            hit();
            enemyLife -= bulletRifleDamage;
            
        }else if (collision.gameObject.CompareTag("BulletShotgun"))
        {
            hit();
            enemyLife -= bulletShotgunDamage;
        }
        if (enemyLife <= 0)
        {
            hit();
            Destroy(gameObject);
        }
    }
    //gritos al andar
    private void scream()
    {
        int random = Random.Range(1,4);
        
        switch (random)
        {
            case 1:
                screamEnemy.clip = scream1;
                screamEnemy.Play();

                break;
            case 2:
                screamEnemy.clip = scream2;
                screamEnemy.Play();

                break;
            case 3:
                screamEnemy.clip = scream3;
                screamEnemy.Play();

                break;
            case 4:
                screamEnemy.clip = scream4;
                screamEnemy.Play();

                break;
            default:
                break;
        }
    }
    //sonido al recivir daño
    private void hit()
    {
            int random = Random.Range(1, 3);
            if (random==1)
            {
                audioEnemy.clip = hit1;
                audioEnemy.Play();
            }
            else if (random==2)
            {
                audioEnemy.clip = hit2;
                audioEnemy.Play();
            }else if (random == 3)
            {
                audioEnemy.clip = hit3;
                audioEnemy.Play();
            }
    }
    //sonido al atacar
    private void attackSound()
    {
        int random = Random.Range(0, 4);
        AudioSource audio = attack;
        audio.clip = attacks[random];
        audio.Play();
    }

}
