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
                ore.gameObject.GetComponent<Rigidbody>().AddForce(strengthOfAttraction * direction);
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
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            inside = false;
            this.ore = null;
        }
       
    }

}