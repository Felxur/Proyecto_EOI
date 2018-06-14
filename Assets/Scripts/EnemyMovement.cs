using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float speed;
    private Transform target;
    public float stopingDistance;


    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Start () { 
    }
	
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        if (Vector2.Distance(transform.position, target.position)> stopingDistance)
        {
            //Debug.Log("siguiendo");
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
       
	}
}
