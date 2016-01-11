using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour {

    public float moveSpeed = 10.0f;
    public float lookSpeed = 4.0f;
    public double hitDist = 0.0;
    public float jumpHeight = 8.0f;
    public float healthAmount = 1.0f;
    public GameObject healthBar;

    private bool isFalling = false;
    private Rigidbody rb;
    private float translation = 0.0f;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        // transform.position += transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        //transform.position += transform.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if (Input.GetAxis("Horizontal2") > 0)
        {
            translation = Input.GetAxis("Horizontal2") * moveSpeed * -1;
            transform.Translate(0, 0, translation);
        }
        else if(Input.GetAxis("Horizontal2") < 0)
        {
            translation = Input.GetAxis("Horizontal2") * moveSpeed;
            transform.Translate(0, 0, translation);
        }

        //float translation = Input.GetAxis("Horizontal2") * moveSpeed * -1;
        //transform.Translate(0, 0, translation);
        //transform.position += transform.forward * Input.GetAxis("Vertical2") * moveSpeed * Time.deltaTime;
        //transform.position += transform.right * Input.GetAxis("Horizontal2") * moveSpeed * Time.deltaTime;

        //jumping
        if (Input.GetAxis("Fire1") != 0 && isFalling == false)
        {
            rb.velocity = new Vector3(0, jumpHeight, 0);

            //    transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime);
        }

        isFalling = true;


    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal2") > 0)
        {
            if (transform.rotation.eulerAngles.y != -90)
            {
                transform.eulerAngles = new Vector3(0, -90, 0);
            }
        }
        else if (Input.GetAxis("Horizontal2") < 0)
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
    }

    void TakeDamage(float damage)
    {
        healthAmount -= damage;

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

}
