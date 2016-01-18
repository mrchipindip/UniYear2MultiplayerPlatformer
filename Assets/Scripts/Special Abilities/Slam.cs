using UnityEngine;
using System.Collections;

public class Slam : MonoBehaviour {

    public GameObject thePlayer;
    public float rotateSpeed = 80.0f;
    public float slamHeight = 7.0f;
    private Vector3 previousRotaion;
    private bool doRotate = false;
    private bool onGround = true;
    private int numRotations = 0;
	// Use this for initialization
	void Start () {
        
    }
	
    

	// Update is called once per frame
	void Update () {
        //if variable is true, begin rotating
        if (doRotate == true)
        {
            transform.Rotate(rotateSpeed * Time.deltaTime, 0, 0, Space.Self);
        }
        //if the rotation is >= 355 add 1 to the rotation num
        if (transform.rotation.eulerAngles.x >= 355)
        {
            numRotations += 1;
        }
        //Check if teh object has done the required rotation
        if (transform.rotation.eulerAngles.x >= 355 && numRotations == 2)
        {
            //get its rigidbody
            Rigidbody rb;
            rb = GetComponent<Rigidbody>();
            //stop the rotation
            doRotate = false;
            //fire it at the ground
            rb.velocity = new Vector3(0.0f, -10.0f, 0.0f);
            onGround = true;
            //reset the value of slamming
            thePlayer.gameObject.SendMessage("SlammingChanged", true);
            resetRotation();
        }
        //check that the player is already on the ground
        if (onGround == true)
        {
            //check that it is not currently
            if (Input.GetAxis("Fire2") != 0)
            {
                //if slam key pressed
                if (Input.GetAxis("Fire1") == 0)
                {
                    //tell teh player script that it is now slamming
                    thePlayer.gameObject.SendMessage("SlammingChanged", true);
                    //inititiate the slam
                    SlamGround();

                }
            }
        }
	}
    //Do the Slam
    void SlamGround()
    {
        //load the previous rotation of teh gameobject
        previousRotaion = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        Rigidbody rb;
        rb = GetComponent<Rigidbody>();
        //stop it
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        //fire it into the air
        rb.velocity = new Vector3(0.0f, slamHeight, 0.0f);
        onGround = false;

       //allow it to start rotating
        doRotate = true;
        

    }

    void resetRotation()
    {
        //resets the rotation of the object to its previous value
        transform.eulerAngles = previousRotaion;
        numRotations = 0;
        gameObject.tag = "Slamming";
        Debug.Log(gameObject.tag);
        StartCoroutine(waitToReset());
        
        
    }
    //used to garantee the rotation has been completed before the rotation has been reset
    IEnumerator waitToReset()
    {
        yield return new WaitForSeconds(1);
        gameObject.tag = "Player";
        Debug.Log(gameObject.tag);
    }
}
