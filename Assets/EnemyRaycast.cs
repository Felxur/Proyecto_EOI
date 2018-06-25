using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using playershoots;

public class EnemyRaycast : MonoBehaviour
{
    private bool isAttacking;
    Vector3 lastPosition;
    int random;

    // Variables para gestionar el radio de visión, el de ataque y la velocidad
    public float visionRadius;
    public float attackRadius;
    public float speed;

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
    public AudioClip scream1;
    public AudioClip scream2;
    public AudioClip scream3;
    public AudioClip scream4;
    public AudioClip hit1;
    public AudioClip hit2;
    public AudioClip hit3;
    private AudioClip[] attacks;


    // Variable para guardar al jugador
    GameObject player;
    Transform playerLooker;

    // Variable para guardar la posición inicial
    Vector3 initialPosition;

    
    private Animator anim;
    Rigidbody2D rb2d;

    void Start()
    {

        // Recuperamos al jugador gracias al Tag
        player = GameObject.FindGameObjectWithTag("Player");
        playerLooker = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        // Guardamos nuestra posición inicial
        initialPosition = transform.position;

        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        attacks = new AudioClip[]
        {
            (AudioClip)Resources.Load("Audio/Zombie/attack1"),
            (AudioClip)Resources.Load("Audio/Zombie/attack2"),
            (AudioClip)Resources.Load("Audio/Zombie/attack3"),
            (AudioClip)Resources.Load("Audio/Zombie/attack4"),
            (AudioClip)Resources.Load("Audio/Zombie/attack5"),
        };
        screamFrecuency = Random.Range(3f, 6f);
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
        

        anim.SetBool("IsWalking", false);
        if (PlayerShoots.isReloading == false && (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3)))
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerLooker = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        // Por defecto nuestro target siempre será nuestra posición inicial
        Vector3 target = initialPosition;
        

        // Comprobamos un Raycast del enemigo hasta el jugador
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            player.transform.position - transform.position,
            visionRadius,
            1 << LayerMask.NameToLayer("Default")
        // Poner el propio Enemy en una layer distinta a Default para evitar el raycast
        // También poner al objeto Attack y al Prefab Slash una Layer Attack 
        // Sino los detectará como entorno y se mueve atrás al hacer ataques
        );

        // Aquí podemos debugear el Raycast
        Vector3 forward = transform.TransformDirection(player.transform.position - transform.position);
        Debug.DrawRay(transform.position, forward, Color.red);

        // Si el Raycast encuentra al jugador lo ponemos de target
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player")
            {
                target = player.transform.position;
                lastPosition = target;
            }
        }

        // Calculamos la distancia y dirección actual hasta el target
        float distance = Vector3.Distance(target, transform.position);
        Vector3 dir = (target - transform.position).normalized;

        // Si es el enemigo y está en rango de ataque nos paramos y le atacamos
        if (target != initialPosition && distance < attackRadius)
        {
            
            // Aquí le atacaríamos
            isAttacking = true;
            anim.SetBool("IsAttacking", true);
            random = Random.Range(0, 4);
            if (isAttacking == true)
            {
                AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
                if (info.IsName("Attack") && info.normalizedTime >= 1F)
                {
                    setIsAttackingFalse();
                }
            }
        }
        // En caso contrario nos movemos hacia él
        else //if(distance < visionRadius && distance>attackRadius)
        {
            if (isAttacking == false)
            {
                anim.SetBool("IsWalking", true);
               
                transform.position = Vector2.MoveTowards(transform.position, playerLooker.position, speed * Time.deltaTime);
                transform.right = (playerLooker.transform.position - transform.position).normalized;
            }
        }

        // Una última comprobación para evitar bugs forzando la posición inicial
        if (target == initialPosition && distance < 0.02f)
        {
            transform.position = initialPosition;
            // Y cambiamos la animación de nuevo a Idle
            anim.SetBool("IsWalking", false);
        }

        // Y un debug optativo con una línea hasta el target
        Debug.DrawLine(transform.position, target, Color.green);
    }

    // Podemos dibujar el radio de visión y ataque sobre la escena dibujando una esfera
    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);

    }

    void setIsAttackingFalse()
    {
        isAttacking = false;
        anim.SetBool("IsAttacking", false);
    }

    //daño
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BulletPistol"))
        {
            hit();
            enemyLife -= bulletPistolDamage;

        }
        else if (collision.gameObject.CompareTag("BulletRifle"))
        {
            hit();
            enemyLife -= bulletRifleDamage;

        }
        else if (collision.gameObject.CompareTag("BulletShotgun"))
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
        int random = Random.Range(1, 4);

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
        if (random == 1)
        {
            audioEnemy.clip = hit1;
            audioEnemy.Play();
        }
        else if (random == 2)
        {
            audioEnemy.clip = hit2;
            audioEnemy.Play();
        }
        else if (random == 3)
        {
            audioEnemy.clip = hit3;
            audioEnemy.Play();
        }
    }
    //sonido al atacar
    private void attackSound()
    {
        int random = Random.Range(0, 4);
        AudioSource audio = screamEnemy;
        audio.clip = attacks[random];
        audio.Play();
    }

}
