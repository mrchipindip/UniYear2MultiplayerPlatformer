using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void onTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("CAlledLADLASDLASDAS");
            other.gameObject.SendMessage("OnLadder2", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.SendMessage("OnLadder2", false);
        }
    }
}
