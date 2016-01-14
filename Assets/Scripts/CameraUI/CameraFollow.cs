using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform followTarget;
    private float distance = -10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(followTarget.position.x, followTarget.position.y, distance);
    }
}
