using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetect : MonoBehaviour
{

    GameManager gameManager;
    PlayerController playerController;


    Ray lightRay;


    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = gameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        CheckLightHit();
    }

    void CheckLightHit()
    {
        if (playerController.colorStatus == 0)
        {
            for (int i = 0; i < gameManager.blueLight.Length; i++)
            {
                LightSpot lightSpot = gameManager.blueLight[i].GetComponentInChildren<LightSpot>();

                if (lightSpot.hitPlayer == false)
                {
                    playerController.PlayerDeath();
                }
            }
        }

        else if (playerController.colorStatus == 1)
        {
            for (int i = 0; i < gameManager.redLight.Length; i++)
            {
                LightSpot lightSpot = gameManager.redLight[i].GetComponentInChildren<LightSpot>();

                if (lightSpot.hitPlayer == false)
                {
                    playerController.PlayerDeath();
                }
            }
        }
        else if (playerController.colorStatus == 2)
        {
            for (int i = 0; i < gameManager.greenLight.Length; i++)
            {
                LightSpot lightSpot = gameManager.greenLight[i].GetComponentInChildren<LightSpot>();

                if (lightSpot.hitPlayer == false)
                {
                    playerController.PlayerDeath();
                }
            }
        }
    }
}
