using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Vector3 newPosition;
    Renderer rend;
    bool canTeleport;

    public int colorStatus;

    void Start()
    {

        newPosition = transform.position;
        rend = gameObject.GetComponent<Renderer>();
        canTeleport = true;
        colorStatus = 0;
    }

    void Update()
    {
        Controls();
    }

    public void PlayerDeath()
    {
        Destroy(gameObject);
    }

    private void Controls()
    {
        if (Input.GetMouseButtonDown(0) && canTeleport == true)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                newPosition = hit.point;
                canTeleport = false;
                rend.enabled = false;
                StartCoroutine("Teleport");
            }
        }
        if (Input.GetKeyDown("space"))
        {
            if (colorStatus == 0)
            {
                colorStatus = 1;
                gameObject.GetComponent<Renderer>().material.color = Color.red;
            }

            else if (colorStatus == 1)
            {
                colorStatus = 2;
                gameObject.GetComponent<Renderer>().material.color = Color.green;
            }

            else if (colorStatus == 2)
            {
                colorStatus = 0;
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
            }
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(0.5f);
        transform.position = newPosition;
        rend.enabled = true;
        canTeleport = true;
    }
}
