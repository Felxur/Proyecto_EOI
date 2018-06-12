using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    public int moveSpeed=50;
    
	
	void Start () {
        
    }
	
	
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        
	}


}
