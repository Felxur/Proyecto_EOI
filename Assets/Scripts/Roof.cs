using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roof : MonoBehaviour {
    public GameObject roof;

	// Use this for initialization
	void Awake () {
        roof.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            roof.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            roof.SetActive(true);
        }
        
    }

}
