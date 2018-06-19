using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCursor : MonoBehaviour {
    Vector2 mousePos;
    Camera cam;

	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody2D>();
        cam = Camera.main;
	}

    public Rigidbody2D player;
    public Transform firePoint;

    private void UpdateAim()
    {
        Vector2 target = cam.ScreenToWorldPoint(Input.mousePosition);



        Vector2 center = player.position;
        Vector2 firepoint = firePoint.position;
        Vector2 fromFirepoint = center - firepoint;
        float radius = fromFirepoint.magnitude;

        Debug.DrawRay(center, -fromFirepoint);

        Debug.DrawRay(target, fromFirepoint, Color.yellow);

        Vector2 newTarget = FindCircleIntersection(center, radius, target, fromFirepoint);

        Debug.DrawLine(target, newTarget, Color.green);

        Debug.DrawLine(firepoint, target, Color.red);
        Debug.DrawRay(firepoint, player.transform.right * (target - firepoint).magnitude, Color.white);

        Vector2 toTarget = newTarget - center;

        float angle = Vector2.SignedAngle(Vector2.right, toTarget);

        float lerp = (newTarget - target).sqrMagnitude / fromFirepoint.sqrMagnitude;

        float alpha = Mathf.Lerp(Vector2.SignedAngle(player.transform.right, -fromFirepoint), 0F, lerp);

        player.transform.rotation = Quaternion.AngleAxis(angle - alpha, Vector3.forward);
    }

    private Vector2 FindCircleIntersection(Vector2 center, float radius, Vector2 origin, Vector2 direction)
    {
        Vector2 union = origin - center;

        float a = Vector2.Dot(direction, direction);
        float b = 2F * Vector2.Dot(union, direction);
        float c = Vector2.Dot(union, union) - radius * radius;
        float d = b * b - 4F * a * c;

        if (d >= 0F)
        {
            d = Mathf.Sqrt(d);

            float t1 = (-b - d) / (2F * a);

            if (t1 >= 0F && t1 <= 1F)
                return new Vector2(origin.x + t1 * direction.x, origin.y + t1 * direction.y);

            float t2 = (-b + d) / (2F * a);

            if (t1 < 0F && t2 >= 0F)
                return origin;
        }

        return origin + direction;
    }

    // Update is called once per frame
    void Update () {
        UpdateAim();
		
	}
}
