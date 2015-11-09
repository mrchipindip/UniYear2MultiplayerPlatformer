using UnityEngine;
using System.Collections;

public class INterpolate : MonoBehaviour {

    public Transform startObj;
    public Transform endObj;

    [SerializeField]
    private float interpValue = 0.0f;

    [Range(5.0f, 25.0f)]
    public float timeToInterpolate = 5.0f;

    private Transform m_transform;

    private bool isActivated = true;
	// Use this for initialization
	void Start () {
        m_transform = transform;
        //Loop();
        StartCoroutine("StartInterp");
	}
	
	// Update is called once per frame
	void Update () {
       // m_transform.position = Vector3.Lerp(startObj.position, endObj.position, interpValue);
       // interpValue += 0.01f;
	}

    void FixedUpdate()
    {
        //if (isActivated == true)
       // {
       //     StartCoroutine("StartInterp");
       // }
    }

    void Loop()
    {
        while (isActivated == true)
        {
            StartCoroutine("StartInterp");
            isActivated = false;
        }    
    
    }

    private IEnumerator StartInterp()
    {
        StopCoroutine("ReverseInterp");
        Debug.Log("CaLLED1");
        float timeToFinishMove = 0.0f;

        while (interpValue <= 1)
        {

            timeToFinishMove += Time.deltaTime;

            interpValue = timeToFinishMove / timeToInterpolate;
            m_transform.position = Vector3.Lerp(startObj.position, endObj.position, interpValue);
            
            yield return null;
        }
        call2();
    }

    void call2()
    {
        StopCoroutine("StartCoroutine");
        StartCoroutine("ReverseInterp");
    }

    void call3()
    {
        StopCoroutine("ReverseCoroutine");
        StartCoroutine("StartInterp");
    }

    private IEnumerator ReverseInterp()
    {
        Debug.Log("called");
        float timeToFinishMove = 0.0f;

        while (interpValue >= 0)
        {

            timeToFinishMove += Time.deltaTime;

            interpValue = timeToFinishMove / timeToInterpolate;
            m_transform.position = Vector3.Lerp(endObj.position, startObj.position, interpValue);
            yield return null;
        }
        call3();
    }
}
