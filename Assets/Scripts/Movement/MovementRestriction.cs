using UnityEngine;
using System.Collections;

public class MovementRestriction : MonoBehaviour {

    public GameObject Player;

    private PLayerMovement2 playerMovement;

    void Start () {
        //Gets the movement Script from teh passed player GameObject
        playerMovement = Player.GetComponent<PLayerMovement2>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        //Check that the collider is not against a Trigger (by comparing the tags that they have)
        if (col.gameObject.tag != "Trigger" && col.gameObject.tag != "StopTrigger")
        {
            //Change the variable in the passed player movement script to true, Tells it it is against an object
            playerMovement.againstObject = true;
        }
        else
        {
           //If its a Trigger do nothing
        }
        
    }

    void OnTriggerExit()
    {
        //when its no longer against the object reset the Variables
        playerMovement.againstObject = false;
    }
}
