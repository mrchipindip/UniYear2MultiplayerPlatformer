using UnityEngine;
using System.Collections;

public class Slide2 : MonoBehaviour {
    private bool isSliding = false;
    public float slideTimer = 0.0f;
    public float maxSlideTime = 2.5f;
    public float slideSpeed = 4.0f;
    private Vector3 slideDirection;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetAxis("Fire3") !=0 && !isSliding)
        {
            if (Input.GetAxis("Horizontal2") != 0)
            {
                slideTimer = 0.0f;
                isSliding = true;
                
                if (Input.GetAxis("Horizontal2") > 0)
                {
                    slideDirection = new Vector3(0, 0, Input.GetAxis("Horizontal2") * slideSpeed * -1);
                }
                else if (Input.GetAxis("Horizontal2") < 0)
                {
                    slideDirection = new Vector3(0, 0, Input.GetAxis("Horizontal2") * slideSpeed);
                }
            }
        }

        if (isSliding)
        {
            //animate something so you can see the slide
            transform.Translate(slideDirection);
            slideTimer += Time.deltaTime;

            if (slideTimer > maxSlideTime)
            {
                isSliding = false;
            }
        }
    }

}
