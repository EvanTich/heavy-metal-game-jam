using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class LevelController : MonoBehaviour {



    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        //
        if(other.gameObject.tag == "Player") {
            int ore = other.gameObject.GetComponent<Player>().Ore;
        }
    }
}
