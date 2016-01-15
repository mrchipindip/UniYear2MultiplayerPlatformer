using UnityEngine;
using System.Collections;

public class ActivateObject : MonoBehaviour {
    public GameObject itemToEnable;
    public GameObject itemToEnable2;
    public GameObject itemToEnable3;
	


	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            RunActivate();
        }
    }

    void RunActivate()
    {
        itemToEnable.SetActive(true);

        if (itemToEnable2 != null)
        {
            itemToEnable2.SetActive(true);
        }

        if (itemToEnable3 != null)
        {
            itemToEnable3.SetActive(true);
        }
    }
}
