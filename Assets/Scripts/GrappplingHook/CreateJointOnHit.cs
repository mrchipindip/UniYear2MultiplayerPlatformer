using UnityEngine;
using System.Collections;

public class CreateJointOnHit : MonoBehaviour {

    public GameObject player;

    private bool inAir = false;
    private HingeJoint grabHinge;
    private HingeJoint playerHinge;
    private SpringJoint swingJoint;
    private float distanceBetween;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void inTheAir(float answer)
    {
        if(answer == 1)
        {
            inAir = true;
        }
    }

    void OnCollisionEnter (Collision col)
    {
        Debug.Log("Collided");
        Debug.Log(inAir);
        distanceBetween = Vector3.Distance(transform.position, player.GetComponent<Transform>().position);
        //GetComponent<Rigidbody>().isKinematic = true;
        //if (inAir != false)
        //{
        GetComponent<Rigidbody>().mass = 100;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        //    Debug.Log("set");
        //    inAir = false;
            //grabHinge = gameObject.AddComponent<HingeJoint>();
            //Debug.Log(col.rigidbody);
            //grabHinge.axis = Vector3.back;
            //grabHinge.connectedBody = col.rigidbody;
            //ContactPoint contact = col.contacts[0];

            //grabHinge.anchor = Vector3.zero;

            playerHinge = player.AddComponent<HingeJoint>();
            playerHinge.anchor = transform.position;
            playerHinge.axis = Vector3.back;
            playerHinge.connectedBody = gameObject.GetComponent<Rigidbody>();

            //Debug.Log(transform.localPosition); 

            //swingJoint = player.AddComponent<SpringJoint>();
            //swingJoint.connectedBody = GetComponent<Rigidbody>();
            
            //swingJoint.anchor = transform.localPosition;
            //swingJoint.maxDistance = 0;
            //swingJoint.
            //Tstops the hook once it collides with something, and creates a HingeJoint to the object it collided with.
       // }
    }

}
