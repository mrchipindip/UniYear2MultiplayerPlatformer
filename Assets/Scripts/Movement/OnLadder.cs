using UnityEngine;
using System.Collections;

public class OnLadder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        //Check if the Object that is colliding with it is the player
        if (col.gameObject.tag == "Player")
        {
            //Send Message to the colliding player object that calls a method allowing the player to climb
            col.gameObject.SendMessage("OnLadder2", true);

        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //if teh playre leaves the ladder send new message telling its movement script 
            col.gameObject.SendMessage("OnLadder2", false);

        }
    }
}
