using playershoots;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life_Munition : MonoBehaviour {
    public RectTransform rectTransform;
    public static int life { get; set; }
    private int munition;
    private int maxMunition;
    public Text uiMunition;
    public Text uiMaxMunition;

    

    // Use this for initialization
    void Start () {
        life = 100;

	}
	
	// Update is called once per frame
	void Update () {
        
        updateMunition();
        updateMaxMunition();
        float updateLife = Mathf.MoveTowards(rectTransform.rect.height, life, 5.0f);
        rectTransform.sizeDelta = new Vector2(100f, Mathf.Clamp(updateLife, 0.0f, 100f));
	}
    void updateMaxMunition()
    {
        uiMaxMunition.text = PlayerShoots.maxMunition.ToString();
    }
    void updateMunition()
    {
        uiMunition.text = PlayerShoots.munition.ToString();
    }
}
