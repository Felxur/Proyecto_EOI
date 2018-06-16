using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    private Animator animator;
    public float speed;
    private Transform target;
    public float stopingDistance;
    private bool isAttacking = false;
    public static int damage = 20;
    public int enemyLife=60;
    int bulletDamage;
   



    void Awake()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Start () {
        bulletDamage = BulletController.damageBullet;
    }
	
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        
        if (Vector2.Distance(transform.position, target.position)> stopingDistance && !isAttacking)
        {

           
            animator.SetBool("IsWalking", true);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            Quaternion rotation = Quaternion.LookRotation
             (target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        }
        else
        {
            
            animator.SetBool("IsWalking", false);
            isAttacking = true;
            animator.SetBool("IsAttacking", true);
            if (isAttacking==true)
            {
                AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
                if (info.IsName("Attack") && info.normalizedTime >= 1F /*&& Vector2.Distance(transform.position, target.position) > stopingDistance*/)
                {
                    setIsAttackingFalse();
                }
            }
            
        }
        Debug.Log("el daño es" + bulletDamage);
	}
    void setIsAttackingFalse()
    {
        isAttacking = false;
        animator.SetBool("IsAttacking", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BulletPistol"))
        {
            enemyLife -= bulletDamage;
            Debug.Log("La vida del enemigo es:" + enemyLife);
            if (enemyLife<=0)
            {
                Destroy(gameObject);
            }
        }
    }

}
