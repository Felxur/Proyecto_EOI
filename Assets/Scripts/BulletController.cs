using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    
    public int moveSpeed=50;
    float currentTime;
    public float destroyTime = 2f;
    public static int damageBullet=15;
    Vector3 bulletDirection;

    void Start () {
    
    }

    
    public void SetBullet(Vector3 direction)
    {
        bulletDirection = direction;
        Debug.Log(direction);
    }
	
	
	void Update () {

        transform.position += transform.right * Time.deltaTime * moveSpeed;
        //transform.Translate(bulletDirection * Time.deltaTime * moveSpeed);


        //transform.Translate(Vector3.right * Time.deltaTime * moveSpeed); original
        currentTime += Time.deltaTime;
        if (currentTime >= destroyTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
