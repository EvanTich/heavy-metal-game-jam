using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractOre : MonoBehaviour {

    public float strengthOfAttraction = 3f;
    public bool inside = false;
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
            if (other != null)
            {
                Vector3 direction = transform.position - other.transform.position;
                other.gameObject.GetComponent<Rigidbody>().AddForce(strengthOfAttraction * direction);
                //Debug.Log(strengthOfAttraction + " " + direction);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            inside = true;
            this.other = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            inside = false;
            this.other = null;
        }
    }
}