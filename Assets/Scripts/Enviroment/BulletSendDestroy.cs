using UnityEngine;
using System.Collections;

public class BulletSendDestroy : MonoBehaviour
{

    public GameObject toBeDestroyed;
    public GameObject toBeDestroyed2;
    public GameObject toBeDestroyed3;
    public GameObject toBeDestroyed4;
    public GameObject toBeDestroyed5;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

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

    void OnTriggerEnter(Collision col)
    {
        Debug.Log("Bullets hitting");
        if (col.gameObject.tag == "Button")
        {
            Debug.Log("Called the destroy");
            RunDestroy();
        }
    }
}
