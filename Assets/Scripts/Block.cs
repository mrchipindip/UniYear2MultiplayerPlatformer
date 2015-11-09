using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

    public GameObject shieldObj;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetAxis("Block") != 0)
        {
            shieldObj.SetActive(true);
        }
        if (Input.GetAxis("Block") == 0 && shieldObj.activeInHierarchy == true)
        {
            shieldObj.SetActive(false);
            //code changed
        }
    }
}
