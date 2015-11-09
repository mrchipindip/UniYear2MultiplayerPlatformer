using UnityEngine;
using System.Collections;

public class SwapPosition : MonoBehaviour {

    public GameObject player2;
    private bool vibrate = false;
    private bool rotateLeft = true;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey("e"))
        {
            
            swap();
        }
	}

    void swap()
    {
        Vector3 temp = transform.position;
        transform.position = player2.transform.position;
        player2.transform.position = temp;
    }

}
