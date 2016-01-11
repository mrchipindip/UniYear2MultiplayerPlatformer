using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
    public float force = 100;
    public float bulletDestroyTime = 4.0f;
    private Rigidbody bulletRigidbody;
    private Transform bulletTransform;

	// Use this for initialization
	void Start () 
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletTransform = GetComponent<Transform>();
        bulletRigidbody.AddForce(bulletTransform.forward * force * -1.0f, ForceMode.Impulse);

        Destroy(gameObject, bulletDestroyTime);
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.SendMessage("TakeDamage", 0.2f);
        }
        else if (col.gameObject.tag == "Trigger" || col.gameObject.tag == "StopTrigger")
        {
            //Do Nothing
            //this is so it passes through triggers invisible to the player
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
