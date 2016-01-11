﻿using UnityEngine;
using System.Collections;

public class SendTakeDamage : MonoBehaviour {

    public float damageGiven = 0.2f;


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.SendMessage("TakeDamage", damageGiven);
        }
    }

}
