using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class LevelController : MonoBehaviour {

    public static Dictionary<string, int> OreAmounts { get; private set; }

    static LevelController() {
        OreAmounts = new Dictionary<string, int>();
    }

    // Start is called before the first frame update
    void Start() {
        foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
            OreAmounts.Add(player.name, 0);
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            string name = other.gameObject.name;
            int ore = other.gameObject.GetComponent<Player>().Ore;
            other.gameObject.GetComponent<Player>().Ore = 0;

            if(OreAmounts.ContainsKey(name))
                OreAmounts[name] += ore;
        }
    }
}
