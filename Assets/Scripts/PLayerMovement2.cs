using UnityEngine;
using System.Collections;

public class PLayerMovement2 : MonoBehaviour {

    public float moveSpeed = 10.0f;
    public float healthAmount = 10.0f;
    public float lookSpeed = 4.0f;
    public double hitDist = 0.0;

    private bool isFalling = false;
    public float jumpHeight = 8.0f;
    public Rigidbody rb;
    private float translation = 0.0f;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {

        // transform.position += transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        //transform.position += transform.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        if (Input.GetAxis("Horizontal") > 0)
        {
            translation = Input.GetAxis("Horizontal") * moveSpeed * -1;
            transform.Translate(0, 0, translation);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            translation = Input.GetAxis("Horizontal") * moveSpeed;
            transform.Translate(0, 0, translation);
        }
        //transform.position += transform.forward * Input.GetAxis("Vertical2") * moveSpeed * Time.deltaTime;
        //transform.position += transform.right * Input.GetAxis("Horizontal2") * moveSpeed * Time.deltaTime;

        //jumping
        if (Input.GetKeyDown("space") && isFalling == false)
        {
            rb.velocity = new Vector3(0, jumpHeight, 0);
            
            //    transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime);
        }

        isFalling = true;


    }

    void FixedUpdate()
    {
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
    }

    void TakeDamage(float damage)
    {
        healthAmount -= damage;

        if (healthAmount <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    // void FixedUpdate()
    //{
    //         // Generate a plane that intersects the transform's position with an upwards normal.
    //         Plane playerPlane = new Plane(Vector3.up, transform.position);

    //          // Generate a ray from the cursor position
    //          Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //           // Determine the point where the cursor ray intersects the plane.
    //     // This will be the point that the object must look towards to be looking at the mouse.
    //     // Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
    //     //   then find the point along that ray that meets that distance.  This will be the point
    //     //   to look at.
    //     float hitdist = 0.0f;
    //     // If the ray is parallel to the plane, Raycast will return false.
    //     if (playerPlane.Raycast(ray, out hitdist))
    //     {
    //         // Get the point along the ray that hits the calculated distance.
    //         Vector3 targetPoint = ray.GetPoint(hitdist);

    //         // Determine the target rotation.  This is the rotation if the transform looks at the target point.
    //         Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

    //         // Smoothly rotate towards the target point.
    //         transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookSpeed * Time.deltaTime);
    //     }
    //}
}
