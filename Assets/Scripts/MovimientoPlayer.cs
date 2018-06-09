using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour {

    public float speed = 1f;
    Rigidbody2D rb;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        

    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 direccion = new Vector2(horizontal, vertical).normalized;

        rb.velocity = direccion * speed;//no es necesario que velocidad esta tambien regulada por time.deltatime?

        Debug.LogFormat("Vector de movimiento que genero: {0}", horizontal * Vector2.right);

    }


}
