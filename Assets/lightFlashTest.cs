using UnityEngine;
using System.Collections;

public class lightFlashTest : MonoBehaviour {

    private float maxDist = 30.0f;
    private float speed = 40.0f;
    public Light lt;
	// Use this for initialization
	void Start () {
        lt = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        lt.range = Mathf.PingPong(Time.time * speed, maxDist);
	}
}
