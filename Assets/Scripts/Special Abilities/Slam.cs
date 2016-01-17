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
        
        if (doRotate == true)
        {
            transform.Rotate(rotateSpeed * Time.deltaTime, 0, 0, Space.Self);
        }

        if (transform.rotation.eulerAngles.x >= 355)
        {
            numRotations += 1;
        }

        if (transform.rotation.eulerAngles.x >= 355 && numRotations == 2)
        {
            Rigidbody rb;
            rb = GetComponent<Rigidbody>();
            doRotate = false;
            rb.velocity = new Vector3(0.0f, -10.0f, 0.0f);
            onGround = true;
            thePlayer.gameObject.SendMessage("SlammingChanged", true);
            resetRotation();
        }
        if (onGround == true)
        {
            if (Input.GetAxis("Fire2") != 0)
            {
                if (Input.GetAxis("Fire1") == 0)
                {
                    thePlayer.gameObject.SendMessage("SlammingChanged", true);
                    SlamGround();

                }
            }
        }
	}

    void SlamGround()
    {
        previousRotaion = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        Rigidbody rb;
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.velocity = new Vector3(0.0f, slamHeight, 0.0f);
        onGround = false;

        //while (transform.rotation.eulerAngles.z <= 180)
        //{
        //    doRotate = true;
        //}
        doRotate = true;
        

    }

    void resetRotation()
    {
        transform.eulerAngles = previousRotaion;
        numRotations = 0;
        gameObject.tag = "Slamming";
        Debug.Log(gameObject.tag);
        StartCoroutine(waitToReset());
        
        
    }

    IEnumerator waitToReset()
    {
        yield return new WaitForSeconds(1);
        gameObject.tag = "Player";
        Debug.Log(gameObject.tag);
    }
}
