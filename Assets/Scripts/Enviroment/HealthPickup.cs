using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.SendMessage("TakeDamage", -0.2f);

            Destroy(gameObject);
        }
    }

}
