using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour 
{
    public GameObject bullet;
    public Transform spawnPoint;
    public bool clickShoot = false;
    private bool fireGun = false;
    private bool canShoot = true;

	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetMouseButtonDown(0) && clickShoot == true)
        {
            Instantiate(bullet, spawnPoint.position, transform.rotation);
        }

        //used for inanimate objects like the wall guns
        if(fireGun == true && canShoot == true)
        {
            Debug.Log("Firing");
            canShoot = false;
            Instantiate(bullet, spawnPoint.position, spawnPoint.transform.rotation);
            StartCoroutine(autoFire());
        }
	}

    //used to recieve the messages from triggers and activate the guns
    void StartFiring(float doFire)
    {
        Debug.Log("Message Recived");
        if (doFire == 1.0f)
        {
            Debug.Log("Firing begun");
            fireGun = true;
        }
        else if (doFire == 2.0f)
        {
            fireGun = false;
        }
    }

    IEnumerator autoFire()
    {
        
        yield return new WaitForSeconds(1);
        canShoot = true;
        
    }
}
