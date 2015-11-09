using UnityEngine;
using System.Collections;

public class hookfire : MonoBehaviour {

    public Transform player;
    public GameObject hook;
    private GameObject spawnPt;
   
    

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
        if(Input.GetMouseButtonDown(0))
        {
            //inAir = true;
            RaycastHit hit;

            //Vector3 clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //We don't want that Z pos because this is in 2D
            //clickedPosition.z = 0;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit))
			{
                
                
                if(spawnPt = null)
                {
                    spawnPt = GameObject.Find("grappleSpawn");
                }
                //GameObject hookClone = (GameObject)Instantiate(hook, spawnPt.transform.position, Quaternion.identity);
                //hookClone.transform.LookAt(hit.point);

				Vector3 tempHit = hit.point;
				tempHit.z = 0.0f;

				hook.transform.LookAt(tempHit);
				//Vector3 tempRotation = hook.transform.rotation.eulerAngles;
				//tempRotation.z = 0.0f;
				//hook.transform.rotation = Quaternion.Euler (tempRotation);

                //hookClone.rigidbody.velocity = hookClone.transform.forward * 5;
				//hook.GetComponent<Rigidbody>().useGravity = false;
				hook.GetComponent<Rigidbody>().isKinematic = false;

                hook.SendMessage("inTheAir", "1.0f");
                hook.GetComponent<Rigidbody>().velocity = hook.transform.forward * 10;

                //hookClone.rigidbody.velocity = hookClone.transform.forward * 5;
			}
            
        }

	}

	void OnCollisionEnter(Collision collision)
    {
       
     }
}
