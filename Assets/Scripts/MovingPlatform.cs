using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

    public bool isMoving = false;
    public float moveSpeed = 2.0f;
    public int moveToX = 5;
    public int startFromX = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
        if (isMoving == true)
        {
            transform.position = new Vector3(PingPong(Time.time * moveSpeed, startFromX, moveToX), transform.position.y, transform.position.z);
        }

	}

    float PingPong(float t, float minLength, float maxLength)
    {
        return Mathf.PingPong(t, maxLength - minLength) + minLength;
    }

    void startMove(float doMove)
    {
        if (doMove == 1.0f)
        {
            isMoving = true;
        }
        else if (doMove == 2.0f)
        {
            isMoving = false;
        }
    }
}
