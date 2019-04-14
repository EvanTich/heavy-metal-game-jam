using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractOre : MonoBehaviour {

    public float strengthOfAttraction = 3f;
    IList<GameObject> ores;
    GameObject other;

    // Start is called before the first frame update
    void Start()
    {
        ores = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var ore in ores) {
            if(ore.activeSelf) {
                Vector3 direction = transform.position - ore.transform.position;
                ore.gameObject.GetComponent<Rigidbody>().AddForce(strengthOfAttraction * direction);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            ores.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            ores.Remove(other.gameObject);
        }
       
    }

}