﻿using UnityEngine;
using System.Collections;

public class LadderClimbPlayer2 : MonoBehaviour
{

    public float climbSpeed = 0.3f;
    private bool canClimb = false;

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("collision made");
        if (col.gameObject.CompareTag("Ladder"))
        {
            Debug.Log("its a ladder");
            canClimb = true;
        }
    }

    void OnCollisionExit(Collision col)
    {

        if (col.gameObject.CompareTag("Ladder"))
        {
            Debug.Log("Called2");
            canClimb = false;
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canClimb == true)
        {
            Debug.Log("calledclimb");
            float translation = Input.GetAxis("Vertical2") * climbSpeed;
            transform.Translate(0, translation, 0);
        }
    }


}
