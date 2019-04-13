using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody rb;
    CharacterController characterController;

    public Vector3 networkPos;
    Vector3 networkVel;
    float lastNetworkUpdate;
    public float speed = 6f;
    public float jumpForce = 10f;

    private float gravity = 14f;
    private float verticalVelocity;

    // Start is called before the first frame update
    void Start() {
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update() {

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
