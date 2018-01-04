using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject[] lightSource;
    public GameObject[] redLight;
    public GameObject[] blueLight;
    public GameObject[] greenLight;


    // Use this for initialization
    void Start()
    {
        lightSource = GameObject.FindGameObjectsWithTag("Light Source");
    }

    // Update is called once per frame
    void Update()
    {
        redLight = GameObject.FindGameObjectsWithTag("Red Light");
        blueLight = GameObject.FindGameObjectsWithTag("Blue Light");
        greenLight = GameObject.FindGameObjectsWithTag("Green Light");
    }
}
