using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {
    public Transform instantiator;
    private  bool activate = true;

    public GameObject enemyPrefab;
    //public int quantity = 1;
    //[Tooltip("Segundos de Retraso entre Zombies")]
    //public float delay = 0f;
    //[Tooltip("si marcas repeat se generaran mas zombies si se vuelve a activar 'trigger' una vez termina la primera ronda")]
    //public bool repeat = false;
    //private float currentTime;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
   
            if (activate == true)
            {
                    Instantiate(enemyPrefab, instantiator.transform.position, Quaternion.identity);
                    activate = false;
             
            }
        }
    }
}
