using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpot : MonoBehaviour
{
    GameObject player;
    Light light;

    //PUBLIC
    public bool hitPlayer;
    public int mode;
    public float startTimer;
    float blinkTimer;

    void Start()
    {
        player = GameObject.Find("Player");
        light = gameObject.GetComponentInChildren<Light>();
        blinkTimer = startTimer;
    }
    void Update()
    {
        DetectPlayer();
        ColorCheck();
        if (mode == 1)
        {
            Blink();
        }
    }

    //DETECT IF PLAYER IS IN REACH
    void DetectPlayer()
    {
        if (light.enabled)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            Ray lightRay = new Ray(transform.position, direction);
            RaycastHit hit;

            if (Physics.Raycast(lightRay, out hit) && hit.collider.tag == "Player")
            {
                hitPlayer = true;
            }
            else
            {
                hitPlayer = false;
            }
        }
        else
        {
            hitPlayer = false;
        }
    }

    //DETECT SPOTLIGHT COLOR
    void ColorCheck()
    {
        Color currentColor = light.color;

        if (currentColor == Color.blue)
        {
            gameObject.tag = "Blue Light";
        }
        else if (currentColor == Color.red)
        {
            gameObject.tag = "Red Light";
        }
        else if (currentColor == Color.green)
        {
            gameObject.tag = "Green Light";
        }
    }

    //BLINK
    void Blink()
    {
        blinkTimer -= Time.deltaTime;

        if (blinkTimer < 0)
        {
            if (light.enabled)
            {
                light.enabled = false;
            }
            else if (!light.enabled)
            {
                light.enabled = true;
            }
            blinkTimer = startTimer;
        }
    }
}
