using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCursor : MonoBehaviour {
    Vector2 mousePos;
    Camera cam;
    Rigidbody2D rigid;
    public Transform firePoint;

	// Use this for initialization
	void Start () {
        rigid = this.GetComponent<Rigidbody2D>();
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        rotateToCamera();
		
	}

    void rotateToCamera()
    {
        mousePos = cam.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        Vector2 center = rigid.position;
        Vector2 firepoint = firePoint.position;

        Vector2 toFirePoint = firepoint - center;
        Vector2 toTarget = mousePos - center;

        float radius = toFirePoint.magnitude;

        if (toTarget.magnitude < radius*2F)
            toTarget = toTarget.normalized * radius * 2F;

        mousePos = center + toTarget;

        mousePos -= toFirePoint;

        toTarget = mousePos - center;

        Debug.DrawLine(center, firepoint);
        Debug.DrawLine(center, mousePos);
        Debug.DrawLine(firepoint, mousePos);

        Debug.Log(Vector2.SignedAngle(Vector2.right, toTarget));

        rigid.rotation = Vector2.SignedAngle(Vector2.right, toTarget);

        //rigid.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((mousePos.y - transform.position.y), (mousePos.x - transform.position.x)) * Mathf.Rad2Deg);
    }
}
