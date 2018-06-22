using playershoots;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life_Munition : MonoBehaviour {
    public RectTransform rectTransform;
    public int life;
    public Text uiMunition;
    public Text uiMaxMunition;
    public GameObject objetMaxMunition;
    public GameObject symbol;



    // Use this for initialization
    void Start () {
        life=PlayerController.life;
        
	}
	
	void Update () {
        life = PlayerController.life;
        updateMunition();
        updateMaxMunition();
        float updateLife = Mathf.MoveTowards(rectTransform.rect.height, life, 5.0f);
        rectTransform.sizeDelta = new Vector2(100f, Mathf.Clamp(updateLife, 0.0f, 100f));
	}
    void updateMaxMunition()
    {
        uiMaxMunition.text = PlayerShoots.maxMunition.ToString();
        if (PlayerShoots.maxMunition==999)
        {
            objetMaxMunition.SetActive(false);
            symbol.SetActive(true);
        }
        else
        {
            objetMaxMunition.SetActive(true);
            symbol.SetActive(false);
        }
    }
    void updateMunition()
    {
        uiMunition.text = PlayerShoots.munition.ToString();
    }
}
