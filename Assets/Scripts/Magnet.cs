using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour{

    public GameObject attractedTo;

    private float strengthOfAttraction = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = attractedTo.transform.position - transform.position;
        gameObject.GetComponent<Rigidbody>().AddForce(strengthOfAttraction * direction);

    }
}
