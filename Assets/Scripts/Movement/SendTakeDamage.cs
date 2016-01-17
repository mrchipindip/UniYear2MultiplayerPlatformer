using UnityEngine;
using System.Collections;

public class SendTakeDamage : MonoBehaviour {

    public float damageGiven = 0.2f;


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("CollisionMadeDetected");
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Message was sent");
            col.gameObject.SendMessage("TakeDamage", damageGiven);
        }
    }

}
