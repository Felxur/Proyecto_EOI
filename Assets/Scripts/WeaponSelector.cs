using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class WeaponSelector : MonoBehaviour
    {

        public GameObject playerPistol;
        public GameObject playerRifle;
        public GameObject playerShotgun;
        private Transform playerSelect;
        public static int state;



        // Use this for initialization
        void Awake()
        {
            state = 1;
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
                state = 1;
                playerPistol.transform.position = playerSelect.position;
                playerSelect = playerPistol.transform;
                playerRifle.SetActive(false);
                //playerShotgun.SetActive(false);
                playerPistol.SetActive(true);

            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                state = 2;
                playerRifle.transform.position = playerSelect.position;
                playerSelect = playerRifle.transform;
                //playerShotgun.SetActive(false);
                playerPistol.SetActive(false);
                playerRifle.SetActive(true);
            }
            //if (Input.GetKeyDown(KeyCode.Alpha3)&& selection!=3)
            //{
            //    state = 3;
            //    playerPistol.SetActive(false);
            //    playerRifle.SetActive(false);
            //    playerShotgun.SetActive(true);
            //}
        }

    }
