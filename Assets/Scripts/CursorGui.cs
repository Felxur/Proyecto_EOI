using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorGui : MonoBehaviour {
    private SpriteRenderer rend;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 cursorpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorpos;
		
	}
}
