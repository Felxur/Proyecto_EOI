﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour {
    private bool activator;
    public GameObject enemyPrefab;
    public int quantity=1;
    [Tooltip("Segundos de Retraso entre Zombies")]
    public float delay=0f;
    [Tooltip("si marcas repeat se generaran mas zombies si se vuelve a activar 'trigger' una vez termina la primera ronda")]
    public bool repeat = false;
    private float currentTime;

    
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        

        
		
	}
}
