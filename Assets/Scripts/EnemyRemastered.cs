using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using playershoots;

public class EnemyRemastered : MonoBehaviour {

    // Variables para gestionar el radio de visión, el de ataque y la velocidad
    public float visionRadius;
    public float attackRadius;
    public float speed;
    private bool isAttacking = false;
    public static int damage = 20;
    public int enemyLife = 60;
    int bulletDamage;

    // Variable para guardar al jugador
    GameObject player;
    Transform playerTarget;


    // Variable para guardar la posición inicial
    Vector3 initialPosition;

    // Animador y cuerpo cinemático con la rotación en Z congelada
    Animator anim;
    Rigidbody2D rb2d;

    void Start()
    {

        // Recuperamos al jugador gracias al Tag
        player = GameObject.FindGameObjectWithTag("Player");
        playerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        // Guardamos nuestra posición inicial
        initialPosition = transform.position;

        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        bulletDamage = BulletController.damageBullet;

        //selecciona objetivo cuando el jugador cambia de arma
        
            player = GameObject.FindGameObjectWithTag("Player");
            playerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
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
            }
        }

        // Calculamos la distancia y dirección actual hasta el target
        float distance = Vector3.Distance(target, transform.position);
        Vector3 dir = (target - transform.position).normalized;

        // Si es el enemigo y está en rango de ataque nos paramos y le atacamos
        if (target != initialPosition && distance < attackRadius)
        {
            anim.SetBool("IsWalking", false);
            isAttacking = true;
            anim.SetBool("IsAttacking", true);
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
        else
        {
            rb2d.MovePosition(transform.position + dir * speed * Time.deltaTime);
            transform.position = Vector2.MoveTowards(transform.position, playerTarget.position, speed * Time.deltaTime);
            Quaternion rotation = Quaternion.LookRotation
                (playerTarget.transform.position - transform.position, transform.TransformDirection(Vector3.up));
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

            // Al movernos establecemos la animación de movimiento

            anim.SetBool("IsWalking", true);
        }

        // Una última comprobación para evitar bugs forzando la posición inicial


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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BulletPistol"))
        {
            enemyLife -= bulletDamage;
            Debug.Log("La vida del enemigo es:" + enemyLife);
            if (enemyLife <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
