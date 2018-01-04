using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePlayer : MonoBehaviour {

    public float rotation;
    public float scaleX;
    public float scaleY;
    public float scaleZ;

	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(new Vector3 (0, 0, rotation) * Time.deltaTime);
        transform.localScale = new Vector3(Mathf.PingPong(Time.time, scaleX), Mathf.PingPong(Time.time, scaleY), Mathf.PingPong(Time.time, scaleZ));
    }
}
