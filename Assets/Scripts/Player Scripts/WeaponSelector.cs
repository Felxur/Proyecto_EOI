using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using playershoots;

namespace selecWeapon
{

    public class WeaponSelector : MonoBehaviour
    {

        public GameObject playerPistol;
        public GameObject playerRifle;
        public GameObject playerShotgun;
        private Transform playerSelect;
        private int state=0;
        


        // Use this for initialization
        void Awake()
        {
            
            playerPistol.SetActive(true);
            playerSelect = playerPistol.transform;
            playerRifle.SetActive(false);
            playerShotgun.SetActive(false);

        }

        private void FixedUpdate()
        {
            if (PlayerShoots.isReloading == false && PlayerShoots.isShooting==false )
            {


                if (Input.GetKeyDown(KeyCode.Alpha1) && state != 0)
                {
                    state = 0;
                    playerPistol.transform.position = playerSelect.position;
                    playerSelect = playerPistol.transform;
                    playerRifle.SetActive(false);
                    playerShotgun.SetActive(false);
                    playerPistol.SetActive(true);

                }
                if (Input.GetKeyDown(KeyCode.Alpha2) && state != 1)
                {
                    state = 1;
                    playerRifle.transform.position = playerSelect.position;
                    playerSelect = playerRifle.transform;
                    playerShotgun.SetActive(false);
                    playerPistol.SetActive(false);
                    playerRifle.SetActive(true);
                }
                if (Input.GetKeyDown(KeyCode.Alpha3) && state != 2)
                {
                    state = 2;
                    playerShotgun.transform.position = playerSelect.position;
                    playerSelect = playerShotgun.transform;
                    playerPistol.SetActive(false);
                    playerRifle.SetActive(false);
                    playerShotgun.SetActive(true);
                }
            }
        }

        void Update()
        {

        }

       

    }
}
