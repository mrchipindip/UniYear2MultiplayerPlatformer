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

    void OnTriggerEnter()
    {
        playerMovement.againstObject = true;
    }

    void OnTriggerExit()
    {
        playerMovement.againstObject = false;
    }
}
