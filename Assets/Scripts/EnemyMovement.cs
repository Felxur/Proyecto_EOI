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
        if (Vector2.Distance(transform.position, target.position)> stopingDistance)
        {
            Debug.Log("siguiendo");
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
       
	}
}
