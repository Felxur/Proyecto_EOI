using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour {

    public GameObject playerPistol;
    public GameObject playerRifle;
    public GameObject playerShotgun;
    private Transform playerSelect;



    // Use this for initialization
    void Awake () {

        playerPistol.SetActive(true);
        playerRifle.SetActive(false);
        //playerShotgun.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
        
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
  
            playerRifle.SetActive(false);
            //playerShotgun.SetActive(false);
            playerPistol.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            //playerShotgun.SetActive(false);
            playerPistol.SetActive(false);
            playerRifle.SetActive(true);
        }
        //if (Input.GetKeyDown(KeyCode.Alpha3)&& selection!=3)
        //{

        //    playerPistol.SetActive(false);
        //    playerRifle.SetActive(false);
        //    playerShotgun.SetActive(true);
        //}
    }
}
