using UnityEngine;
using System.Collections;

public class ButtonSendDestroy : MonoBehaviour {

    public GameObject toBeDestroyed;
    public GameObject toBeDestroyed2;
    public GameObject toBeDestroyed3;
    public GameObject toBeDestroyed4;
    public GameObject toBeDestroyed5;
    private GameObject buttonChild;
    private bool buttonActive = true;
    
	// Use this for initialization
	void Start () {
        buttonChild = this.gameObject.transform.GetChild(0).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void RunDestroy()
    {
        Debug.Log("Destroy Run");
        Destroy(toBeDestroyed);
        if (toBeDestroyed2 != null)
        {
            Destroy(toBeDestroyed2);
        }
        else if (toBeDestroyed3 != null)
        {
            Destroy(toBeDestroyed3);
        }
        else if (toBeDestroyed4 != null)
        {
            Destroy(toBeDestroyed4);
        }
        else if (toBeDestroyed5 != null)
        {
            Destroy(toBeDestroyed5);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Detected");
        if (col.gameObject.tag == "Slamming")
        {
            Debug.Log("CalledCollison");
            buttonChild.SetActive(false);
            RunDestroy();
        }

        if(col.gameObject.tag == "Bullet" && buttonActive == true)
        {
            buttonChild.SetActive(false);
            RunDestroy();
            buttonActive = false;
        }
    }

	void OnTriggerEnter(Collision col)
	{
		if(col.gameObject.tag == "Bullet" && buttonActive == true)
		{
			buttonChild.SetActive(false);
			RunDestroy();
			buttonActive = false;
		}
	}
}
