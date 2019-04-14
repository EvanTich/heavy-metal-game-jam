using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractOre : MonoBehaviour {

    public float strengthOfAttraction = 3f;
    public bool inside = false;
    public bool insidePlayer = true;
    GameObject ore;
    GameObject other;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (inside)
        {
            if (ore != null)
            {
                Vector3 direction = transform.position - ore.transform.position;
                //Debug.Log(direction);
                ore.gameObject.GetComponent<Rigidbody>().AddForce(strengthOfAttraction * direction);
                //Debug.Log(strengthOfAttraction + " " + direction);
            }
        }
        if (insidePlayer)
        {
            if (other != null)
            {
                Vector3 direction = transform.position - other.transform.position;
                //Debug.Log("NEXT TO A PLAYER!!");
                other.gameObject.GetComponent<Rigidbody>().AddForce(strengthOfAttraction * direction);
                //Debug.Log(strengthOfAttraction + " " + direction);

                Vector3 direction2 = other.transform.position - transform.position;
                gameObject.GetComponent<Rigidbody>().AddForce(strengthOfAttraction * direction2);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            inside = true;
            this.ore = other.gameObject;
        }
        if(other.gameObject.tag == "Player")
        {
            //make them stick together
            // Debug.Log("debug");
            //Debug.Log("NEXT TO A PLAYER!!");
            insidePlayer = true;
            this.other = other.gameObject;
        }
 
       //ebug.Log(other.gameObject.name);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            inside = false;
            this.ore = null;
        }
        if (other.gameObject.tag == "Player")
        {
            insidePlayer = false;
            this.other = null;
        }
    }

/*    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("HIT A PLAYER!!!!!");
        }8/

        //Debug.Log("Test");
    }*/
}