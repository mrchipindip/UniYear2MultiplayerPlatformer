using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour {

    public float moveSpeed = 10.0f;
    public float lookSpeed = 4.0f;
    public double hitDist = 0.0;
    public float jumpHeight = 8.0f;
    public float healthAmount = 1.0f;
    public GameObject healthBar;

    private bool isSlamming = false;
    private bool isFalling = false;
    private Rigidbody rb;
    private float translation = 0.0f;

    public bool againstObject = false;
    private bool canMoveLeft = true;
    private bool canMoveRight = true;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        //Check if the player is currently in a slam (prevents him from moving while using "Slam"
        if (isSlamming == false)
        {
            //Check if it is getting an axis input from the user & check If the player is allowed to move in that direction
            if (Input.GetAxis("Horizontal2") > 0 && canMoveRight == true)
            {
                //Move The player using the input from the controller
                translation = Input.GetAxis("Horizontal2") * moveSpeed * -1;
                transform.Translate(0, 0, translation);
            }
            else if (Input.GetAxis("Horizontal2") < 0 && canMoveLeft == true)
            {
                translation = Input.GetAxis("Horizontal2") * moveSpeed;
                transform.Translate(0, 0, translation);
            }
        }

        //if the input for jump is given and the player is not already jumping
        if (Input.GetAxis("Fire1") != 0 && isFalling == false)
        {
            //if not jumping, Jump the value of JumpHeight
            rb.velocity = new Vector3(0, jumpHeight, 0);
        }
        //Reset the value of isFalling
        isFalling = true;


    }

    //method that changes the value of slamming, talked to by the Slam script
    void SlammingChanged(bool changeState)
    {
        Debug.Log("MessageRecived Correctly");
        if (isSlamming != true)
        {
            isSlamming = true;
            Debug.Log("Slam Set to in prog");
        }
        else
        {
            isSlamming = false;
            Debug.Log("reset value, freed mov");
        }
    }

    void FixedUpdate()
    {
        //Check if the player is against an object
        CheckIfAgainstObject();
        //if not currently slamming
        if (isSlamming == false)
        {
            //if moving left 
            if (Input.GetAxis("Horizontal2") > 0)
            {
                //If not already facing left
                if (transform.rotation.eulerAngles.y != -90)
                {
                    //face left
                    transform.eulerAngles = new Vector3(0, -90, 0);
                }
            }
                //if moving right
            else if (Input.GetAxis("Horizontal2") < 0)
            {
                //if not already facing right
                if (transform.rotation.eulerAngles.y != 90)
                {
                    //face right
                    transform.eulerAngles = new Vector3(0, 90, 0);
                }
            }
        }
    }

    void OnCollisionStay()
    {
        //if on ground, set is falling to false allowing a jump
        isFalling = false;
    }

    //Method that changes the players health. Called by the Gameobjects/Scripts that damage the player
    void TakeDamage(float damage)
    {
        //Take the passed damage from the health
        healthAmount -= damage;

        //If statement for adding health with health packs, preventing it form being over the maximum value
        if (healthAmount > 1)
        {
            healthAmount = 1;
        }
        //Assign the size of the health bar to the amount of health the player has
        healthBar.transform.localScale = new Vector3(healthAmount, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        //If the health amount is 0 or less restart level
        if (healthAmount <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    //Checks if the player is against an object and which side it is on
    void CheckIfAgainstObject()
    {
        if (againstObject == true)
        {
            //If the player is facing left
            if (transform.rotation.eulerAngles.y >= 89 && transform.rotation.eulerAngles.y <= 91)
            {
                //stop it being able to move left
                canMoveLeft = false;
            }
            else
            {
                //stop it being able to move right
                canMoveRight = false;
            }
        }
        else
        {
            //reset values
            canMoveLeft = true;
            canMoveRight = true;
        }
    }

}
