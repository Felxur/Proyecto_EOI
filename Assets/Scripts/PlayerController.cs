using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Animator animator;
    public float moveSpeed;
    bool isReloading=false;
    bool isRunning=false;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();

    }
    void SetIsReloadingFalse()
    {
        isReloading = false;
        animator.SetBool("IsReloading", false);
    }
    private void FixedUpdate()
    {
     
    }
    // Update is called once per frame
    void Update () {

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime, Space.World);
        }

    }
}
