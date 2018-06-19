using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour {
    private bool activator;
    public GameObject enemyPrefab;
    private Rigidbody2D instantiatorRigid;
    public int quantity=1;
    [Tooltip("Segundos de Retraso entre Zombies")]
    public float delay=0f;
    [Tooltip("si marcas repeat se generaran mas zombies si se vuelve a activar 'trigger' una vez termina la primera ronda")]
    public bool repeat = false;
    private float currentTime;

    
    void Start () {
        instantiatorRigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        activator = Trigger.activate;
        if (activator==true)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= delay && quantity>0)
            {
                currentTime = 0f;
                Instantiate(enemyPrefab);
                quantity--;
            }else if (quantity == 0 && repeat==true)
            {
                Trigger.activate = false;
            }
        }

        
		
	}
}
