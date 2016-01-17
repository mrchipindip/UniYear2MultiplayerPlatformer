using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

    public GameObject shieldObj;
    public GameObject shieldObj2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetAxis("Block") != 0)
        {
            shieldObj.SetActive(true);
            shieldObj2.SetActive(true);
        }
        if (Input.GetAxis("Block") == 0 && shieldObj.activeInHierarchy == true)
        {
            shieldObj.SetActive(false);
            shieldObj2.SetActive(false);
            //code changed
        }
    }
}
