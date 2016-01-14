using UnityEngine;
using System.Collections;

public class PLayerMovement2 : MonoBehaviour {
    
    public float moveSpeed = 10.0f;
    public float healthAmount = 1.0f;
    public float lookSpeed = 4.0f;
    public double hitDist = 0.0;
    public GameObject healthBar;

    private bool isFalling = false;
    private bool stayCheckOne = false;
    public float jumpHeight = 8.0f;
    public Rigidbody rb;
    private float translation = 0.0f;

    public bool againstObject = false;
    private bool canMoveLeft = true;
    private bool canMoveRight = true;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {

        // transform.position += transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        //transform.position += transform.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        if (Input.GetAxis("Horizontal") > 0 && canMoveRight == true)
        {
            Debug.Log("Can Move right :" + canMoveRight);
            translation = Input.GetAxis("Horizontal") * moveSpeed * -1;
            transform.Translate(0, 0, translation);
        }
        else if (Input.GetAxis("Horizontal") < 0 && canMoveLeft == true)
        {
            Debug.Log("Can Move right :" + canMoveRight);
            translation = Input.GetAxis("Horizontal") * moveSpeed;
            transform.Translate(0, 0, translation);
        }
        //transform.position += transform.forward * Input.GetAxis("Vertical2") * moveSpeed * Time.deltaTime;
        //transform.position += transform.right * Input.GetAxis("Horizontal2") * moveSpeed * Time.deltaTime;

        //jumping
        if (Input.GetKeyDown("space") && isFalling == false && stayCheckOne == false)
        {
            rb.velocity = new Vector3(0, jumpHeight, 0);
            stayCheckOne = true;
            StartCoroutine(JumpWait());
            //isFalling = true;
            //    transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime);
        }

      isFalling = true;


    }

    void FixedUpdate()
    {
        CheckIfAgainstObject();

        if (Input.GetAxis("Horizontal") > 0)
        {
            if (transform.rotation.eulerAngles.y != -90)
            {
                transform.eulerAngles = new Vector3(0, -90, 0);
            }
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            if (transform.rotation.eulerAngles.y != 90)
            {
                transform.eulerAngles = new Vector3(0, 90, 0);
            }
        }
    }

    void OnCollisionStay()
    {
        isFalling = false;
       // Debug.Log("CollsionStayyyyy");
    }

    void TakeDamage(float damage)
    {
        healthAmount -= damage;
        Debug.Log(healthAmount);

        if (healthAmount > 1)
        {
            healthAmount = 1;
        }

        healthBar.transform.localScale = new Vector3(healthAmount, healthBar.transform.localScale.y, healthBar.transform.localScale.z);

        if (healthAmount <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    IEnumerator JumpWait()
    {
        yield return new WaitForSeconds(0.5f);
        stayCheckOne = false;
    }

    void CheckIfAgainstObject()
    {
        if (againstObject == true)
        {
            //Debug.Log("Is against an object");

            if (transform.rotation.eulerAngles.y >= 89 && transform.rotation.eulerAngles.y <= 91)
            {
                canMoveLeft = false;
                Debug.Log("can move left changed");
            }
            else
            {
                canMoveRight = false;
               // Debug.Log("can move right changed");
            }
        }
        else
        {
            canMoveLeft = true;
            canMoveRight = true;
        }
    }

}
