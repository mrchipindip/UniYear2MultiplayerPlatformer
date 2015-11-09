using UnityEngine;
using System.Collections;

public class TriggerActivated : MonoBehaviour {

    public GameObject gun;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("TriggerHappened");
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Its the player");
            if (gameObject.tag == "Trigger")
            {
                Debug.Log("message sent");
                gun.gameObject.SendMessage("StartFiring", 1.0f);
            }
            else if (gameObject.tag == "StopTrigger")
            {
                gun.gameObject.SendMessage("StartFiring", 2.0f);
            }
        }
    }

}
