using UnityEngine;
using System.Collections;

public class Slide : MonoBehaviour {

    private bool isSliding = false;
    public float slideTimer = 0.0f;
    public float maxSlideTime = 2.5f;
    public float slideSpeed = 4.0f;
    private Vector3 slideDirection;
	
	void Start () {
	
	}
	
	
	void Update () {
        if(Input.GetKeyDown("q") && !isSliding)
        {
            Debug.Log("Called");
            if (Input.GetAxis("Horizontal") != 0)
            {
                slideTimer = 0.0f;
                isSliding = true;
                if (Input.GetAxis("Horizontal") > 0)
                {
                    Debug.Log("Sliding");
                    slideDirection = new Vector3(0, 0, Input.GetAxis("Horizontal") * slideSpeed * -1);
                }
                else if (Input.GetAxis("Horizontal") < 0)
                {
                    Debug.Log("Sliding");
                    slideDirection = new Vector3(0, 0, Input.GetAxis("Horizontal") * slideSpeed);
                }
            }
        }

	    if(isSliding)
        {
            //animate something so you can see the slide
            transform.Translate(slideDirection);
            slideTimer += Time.deltaTime;

            if(slideTimer > maxSlideTime)
            {
                isSliding = false;
            }
        }
	}

}
