using UnityEngine;
using System.Collections;

public class MovementRestrictionPlayer2 : MonoBehaviour {

    public GameObject Player;

    private Player2 playerMovement;

    void Start()
    {
        playerMovement = Player.GetComponent<Player2>();
    }

    // Update is called once per frame
    void Update()
    {

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
