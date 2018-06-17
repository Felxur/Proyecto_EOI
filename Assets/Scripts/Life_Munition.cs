using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life_Munition : MonoBehaviour {
    public RectTransform rectTransform;
    public static int life { get; set; }
    public int munition;
    public int maxMunition;
    public Text uiMunition;
    public Text uiMAxMunition;

    

    // Use this for initialization
    void Start () {
        life = 100;
        munition = PlayerShoots.munition;
        maxMunition = PlayerShoots.maxMunition;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("municion de ui es;" + munition);

        float updateLife = Mathf.MoveTowards(rectTransform.rect.height, life, 5.0f);
        rectTransform.sizeDelta = new Vector2(100f, Mathf.Clamp(updateLife, 0.0f, 100f));
	}
    void updateMunition()
    {

        uiMAxMunition.text = munition.ToString();
    }
}
