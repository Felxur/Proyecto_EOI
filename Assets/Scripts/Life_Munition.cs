using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Munition : MonoBehaviour {
    public RectTransform rectTransform;
    public static int life { get; set; }

	// Use this for initialization
	void Start () {
        life = 100;
    
		
	}
	
	// Update is called once per frame
	void Update () {

        float updateLife = Mathf.MoveTowards(rectTransform.rect.height, life, 5.0f);
        rectTransform.sizeDelta = new Vector2(100f, Mathf.Clamp(updateLife, 0.0f, 100f));
	}
}
