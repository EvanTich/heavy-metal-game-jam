using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody rb;
    CharacterController characterController;


    public float speed = 30.0f;
    public float rotation = 200.0f;

    private Vector3 moveDirection = Vector3.zero;

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

        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = moveDirection * speed;
        }

        //Gravity
        moveDirection.y -= 10f * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);



    }
}
