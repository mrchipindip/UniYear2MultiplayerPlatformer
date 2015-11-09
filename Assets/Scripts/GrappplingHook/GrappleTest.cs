using UnityEngine;
using System.Collections;

public class GrappleTest : MonoBehaviour {

    public GameObject anchor;
    private HingeJoint joint;
    private HingeJoint anchorJoint;
    private LineRenderer lr;
    private float halfObjectToBeGrappledYAxis;

    // Use this for initialization
    void Start()
    {
        lr = this.GetComponent<LineRenderer>();
        lr.enabled = false;
    }

    // Use this for initialization
    void Update()
    {
        //On left Click
        if (Input.GetMouseButtonDown(0))
        {
            //Get the Clicked Position
            Vector3 clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //We don't want that Z pos because this is in 2D
            clickedPosition.z = 0;
            //Shoot a ray out towards that position
            LayerMask ignorePlayer = ~(1 << LayerMask.NameToLayer("Player"));
            RaycastHit hit;
            Physics.Raycast(transform.position, clickedPosition - transform.position, out hit, 1000, ignorePlayer);
            if (hit.collider)
            {
                print(hit.transform.lossyScale.y);
                halfObjectToBeGrappledYAxis = (hit.transform.lossyScale.y / 2);
                print(halfObjectToBeGrappledYAxis);
                //move the anchor to the correct position
                anchor.transform.position = new Vector3(hit.point.x, hit.point.y - halfObjectToBeGrappledYAxis, 0);
                //zero out any rotation
                anchor.transform.rotation = Quaternion.identity;

                //Create HingeJoints
                joint = gameObject.AddComponent<HingeJoint>();
                joint.axis = Vector3.back;
                joint.anchor = Vector3.zero;
                joint.connectedBody = anchor.GetComponent<Rigidbody>();
                anchorJoint = anchor.AddComponent<HingeJoint>();
                anchorJoint.axis = Vector3.back;
                anchorJoint.anchor = Vector3.zero;

                //show line
                lr.enabled = true;
            }
            //On left Click release
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //Destroy HingeJoints
            Destroy(joint);
            Destroy(anchorJoint);

            //Hide line
            lr.enabled = false;
        }

        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, anchor.transform.position);
    }
}
