using UnityEngine;
using System.Collections;

public class CameraTargetCaluclate : MonoBehaviour {

    public Transform player1;
    public Transform player2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(player1.transform.position, player2.transform.position, 0.5f);
    }
}
