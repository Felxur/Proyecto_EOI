using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour {

    public float speed = 1f;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direccion = new Vector3(horizontal, vertical, 0).normalized;

        //transform.position += direccion * Time.deltaTime * speed;
        //transform.Translate(direccion * speed * Time.deltaTime, Space.World);
        rb.velocity = direccion * speed;

        //Debug.LogFormat("Horizontal: {0} || Vertical: {1} ", direccion.x, direccion.y);

        Debug.LogFormat("Vector de movimiento que genero: {0}", horizontal * Vector3.right);
	}
}
