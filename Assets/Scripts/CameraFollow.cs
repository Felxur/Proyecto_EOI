﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    GameObject player;
    bool followPlayer=true;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1)|| Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) )
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (followPlayer==true)
        {
            camFollowPlayer();
        }
	}
    public void setFollowPlayer(bool val)
    {
        followPlayer = val;
    }

    void camFollowPlayer()
    {
        Vector3 newpos = new Vector3 (player.transform.position.x, player.transform.position.y, this.transform.position.z);
        this.transform.position = newpos;
    }
}
