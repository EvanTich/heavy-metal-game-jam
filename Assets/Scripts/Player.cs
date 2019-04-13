using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody rb;
    CharacterController characterController;


    public float speed = 6f;
    public float jumpForce = 10f;

    private float gravity = 14f;
    private float verticalVelocity;

    public int Ore { get; set; }

    // Start is called before the first frame update
    void Start() {

        /*rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;*/


        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update() {

        //with rigidbody

        /*float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        rb.AddForce(new Vector3(moveHorizontal, 0.0f, moveVertical) * speed);


        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotation, 0);
        transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * speed);*/



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


    //destroys anything that collides with it for now
    void OnCollisionEnter(Collision col)
    {
        Destroy(col.gameObject);
    }
}
