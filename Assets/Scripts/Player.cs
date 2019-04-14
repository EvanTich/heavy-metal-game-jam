using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Animator animator;
    private CharacterController characterController;
    
    public float minSpeed = 5f;

    private Vector3 moveDirection = Vector3.zero;

    public const float maxSpeed = 15f;
    public const float maxJumpSpeed = 30f;

    public float speed = maxSpeed;
    public float rotSpeed = 90f;
    public float jumpSpeed = maxJumpSpeed;
    public float gravity = 40f;
    public string num;

    public bool insidePlayer = false;
    GameObject other;

    private bool stunned;
    private float stunnedTimer;

    public static int total = 0;

    public int Ore { get; set; }

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        num = "" + ++total;
    }

    // Update is called once per frame
    void Update() {

        //with characterController

        // rotate character with horizontal keys:
        if(!stunned) {
            transform.Rotate(0, Input.GetAxis("Horizontal" + num) * rotSpeed * Time.deltaTime, 0);
            if(characterController.isGrounded) {

                moveDirection = Vector3.left * Input.GetAxis("Vertical" + num);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                if(Input.GetButton("Jump" + num)) {
                    moveDirection.y = jumpSpeed;
                }
            }
        } else {
            stunnedTimer -= Time.deltaTime;
            if(stunnedTimer <= 0)
                stunned = false;
        }

        if(animator != null)
            animator.SetFloat("speed", characterController.velocity.magnitude); // maybe will work better

        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;
        // convert velocity to displacement and move character:
        characterController.Move(moveDirection * Time.deltaTime);

        if (insidePlayer && other != null)
        {
            Player plr = other.GetComponent<Player>();
            if (plr != null && Ore > plr.Ore)
            {
                //MAKE THEM NOTH DROP SOME ORE
                int dropped = Ore / 2;
                speed += dropped * speed * .05f;
                jumpSpeed += dropped * jumpSpeed * .05f;
                Ore -= dropped;
                plr.Ore += dropped;
                stunned = true;
                stunnedTimer = dropped / 2;
                insidePlayer = false;
            }

        }


    }

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
                //Debug.Log(Ore);
            }
        }
        if (other.gameObject.tag == "Player" && other.gameObject!= gameObject)
        {
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
    
}
