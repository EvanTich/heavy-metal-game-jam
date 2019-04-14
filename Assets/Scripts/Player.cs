using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody rb;
    CharacterController characterController;

    public float strengthOfAttraction = 3f;

    public static float constSpeed = 15f;
    public float minSpeed = 5f;
    public float verticalVelocity;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    public float speed = 15f;
    public float rotSpeed = 90f;
    public float jumpSpeed = 20f;
    public float gravity = 40f;
    public int num;

    public bool insidePlayer = true;
    GameObject other;

    static int total = 0;



    public int Ore { get; set; }

    // Start is called before the first frame update
    void Start() {
        characterController = GetComponent<CharacterController>();
        total++;
        num = total;
    
    }

    // Update is called once per frame
    void Update() {

        //with characterController

        // rotate character with horizontal keys:
        transform.Rotate(0, Input.GetAxis("Horizontal" + num) * 90f * Time.deltaTime, 0);
        if (characterController.isGrounded)
        {
      
            moveDirection = Vector3.forward * Input.GetAxis("Vertical" + num);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump" + num))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;
        // convert velocity to displacement and move character:
        characterController.Move(moveDirection * Time.deltaTime);

        if (insidePlayer)
        {
            if (other != null)
            {
                Vector3 direction = transform.position - other.transform.position;
                Debug.Log("pull here");
                other.gameObject.GetComponent<Rigidbody>().AddForce(strengthOfAttraction * direction);
                //Debug.Log(strengthOfAttraction + " " + direction);

                /*Vector3 direction2 = other.transform.position - transform.position;
                gameObject.GetComponent<Rigidbody>().AddForce(strengthOfAttraction * direction2);*/
            }

        }


    }


   
    /*void OnCollisionEnter(Collision col)
    {
        //destroy it when it hits
        if (col.gameObject.tag == "PickUp")
        {
            //add max iron count
            if (speed > minSpeed)
            {
                Destroy(col.gameObject);
                speed -= speed *.05f;
                jumpSpeed -= jumpSpeed * .05f;
                Ore++;
                Debug.Log(Ore);
            }
            else
            {
                Debug.Log("ore at max");
            }
        }
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("HIT A PLAYER IN PLAYER CLASS!!!");
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {

        //destroy it when it hits
        if (other.gameObject.tag == "PickUp")
        {
            //add max iron count
            if (speed > minSpeed)
            {
                Destroy(other.gameObject);
                speed -= speed * .05f;
                jumpSpeed -= jumpSpeed * .05f;
                Ore++;
                Debug.Log(Ore);
            }
            else
            {
                Debug.Log("ore at max");
            }
        }
        if (other.gameObject.tag == "Player")
        {
            //make them stick together
            // Debug.Log("debug");
            Debug.Log("NEXT TO A PLAYER!!");
            insidePlayer = true;
            this.other = other.gameObject;
        }

        //ebug.Log(other.gameObject.name);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            insidePlayer = false;
            this.other = null;
        }
    }


    /*private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "PickUp")
        {
            Vector3 direction = transform.position - other.transform.position;
            other.gameObject.GetComponent<Rigidbody>().AddForce(strengthOfAttraction * direction);
            Debug.Log(strengthOfAttraction + " " + direction);
        }
    }*/
}
