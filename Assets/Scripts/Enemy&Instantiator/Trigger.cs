using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {
    public GameObject instantiator;
    public static bool activate = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        activate = true;

    }
}
