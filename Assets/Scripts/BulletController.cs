using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    public Rigidbody2D myrb;
    public int moveSpeed=50;
    float currentTime;
    public float destroyTime = 2f;


    void Start () {

        
    }
	
	
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        currentTime += Time.deltaTime;
        if (currentTime >= destroyTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }


}
