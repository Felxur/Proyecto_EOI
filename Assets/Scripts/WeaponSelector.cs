﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class WeaponSelector : MonoBehaviour
    {

        public GameObject playerPistol;
        public GameObject playerRifle;
        public GameObject playerShotgun;
        private Transform playerSelect;
        public static int state;
    //--------balas en cargador-->tamaño de cargador-->municion maxima
    public static int[,] munition = new int[,]{
            {15,15,99},//pistola municion maxima infinita
            {50, 50,0},
            {0,5,0}
        };





    // Use this for initialization
    void Awake()
        {

            state = 0;
            playerPistol.SetActive(true);
            playerSelect = playerPistol.transform;
            playerRifle.SetActive(false);
            //playerShotgun.SetActive(false);

        }

        // Update is called once per frame
        void Update()
        {


            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                state = 0;
                playerPistol.transform.position = playerSelect.position;
                playerSelect = playerPistol.transform;
                playerRifle.SetActive(false);
                //playerShotgun.SetActive(false);
                playerPistol.SetActive(true);

            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                state = 1;
                playerRifle.transform.position = playerSelect.position;
                playerSelect = playerRifle.transform;
                //playerShotgun.SetActive(false);
                playerPistol.SetActive(false);
                playerRifle.SetActive(true);
            }
            //if (Input.GetKeyDown(KeyCode.Alpha3)&& selection!=3)
            //{
            //    state = 2;
            //    playerPistol.SetActive(false);
            //    playerRifle.SetActive(false);
            //    playerShotgun.SetActive(true);
            //}
        }

    }
