﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    public Rigidbody2D myrb;
    public int moveSpeed=50;
    float currentTime;
    public float destroyTime = 2f;
    public static int damageBullet=15;


    void Start () {
    
    }
	
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            damageBullet = 15;
            Debug.Log("El daño ahora es"+damageBullet);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            damageBullet = 25;
            Debug.Log("El daño ahora es" + damageBullet);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            damageBullet = 10;
            Debug.Log("El daño ahora es" + damageBullet);
        }
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        currentTime += Time.deltaTime;
        if (currentTime >= destroyTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        gameObject.SetActive(false);
    }
}
