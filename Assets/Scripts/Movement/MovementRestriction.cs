using UnityEngine;
using System.Collections;

public class MovementRestriction : MonoBehaviour {

    public GameObject Player;

    private PLayerMovement2 playerMovement;

    void Start () {
        playerMovement = Player.GetComponent<PLayerMovement2>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag != "Trigger" && col.gameObject.tag != "StopTrigger")
        {
            playerMovement.againstObject = true;
        }
        else
        {
           
        }
        
    }

    void OnTriggerExit()
    {
        playerMovement.againstObject = false;
    }
}
