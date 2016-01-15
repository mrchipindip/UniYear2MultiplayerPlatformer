using UnityEngine;
using System.Collections;

public class LevelFinished : MonoBehaviour {

    public string nextLevel = "";
    private int numPlayersAtFinish = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if(numPlayersAtFinish >= 2)
        {
            Application.LoadLevel(nextLevel); 
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            numPlayersAtFinish += 1;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            numPlayersAtFinish -= 1;
        }
    }

}
