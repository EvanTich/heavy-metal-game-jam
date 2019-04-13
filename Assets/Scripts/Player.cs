using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody rb;
    CharacterController characterController;

<<<<<<< HEAD
    public Vector3 networkPos;
    Vector3 networkVel;
    float lastNetworkUpdate;
    public float speed = 6f;
=======
    public float strengthOfAttraction = 3f;

    public static float constSpeed = 15f;
    public float min = constSpeed * 0.10f;
    public float speed = 15f;
>>>>>>> c5fae7c2e9ee00a4a8ea63056e6a6c80ee9ec4f2
    public float jumpForce = 10f;

    private float gravity = 10f;
    private float verticalVelocity;

    public int Ore { get; set; }

    // Start is called before the first frame update
    void Start() {
<<<<<<< HEAD
=======

>>>>>>> c5fae7c2e9ee00a4a8ea63056e6a6c80ee9ec4f2
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update() {

<<<<<<< HEAD
=======

>>>>>>> c5fae7c2e9ee00a4a8ea63056e6a6c80ee9ec4f2
        //with characterController

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed); //limits speed

        if (characterController.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        movement.y = verticalVelocity; //applies gravity

        movement = transform.TransformDirection(movement);
        characterController.Move(movement * Time.deltaTime);

    }


   
    void OnCollisionEnter(Collision col)
    {
        //destroy it when it hits
        if(col.gameObject.tag == "PickUp")
        {
            //add max iron count
            if (speed >  min )
            {
                Destroy(col.gameObject);
                speed -= speed * .10f;
                gravity += 5;
            }
        }else if(col.gameObject.tag == "Player")
        {

        }
    }


    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "PickUp")
        {
            Vector3 direction = transform.position - other.transform.position;
            other.gameObject.GetComponent<Rigidbody>().AddForce(strengthOfAttraction * direction);
            Debug.Log(strengthOfAttraction + " " + direction);
        }
    }
}
