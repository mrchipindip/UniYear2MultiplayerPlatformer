using UnityEngine;
using System.Collections;

public class LevelFinished : MonoBehaviour {

    public int nextLevel;
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
        Debug.Log("Booty");
        if (col.gameObject.tag == "Player")
        {
            Application.LoadLevel(nextLevel);
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
