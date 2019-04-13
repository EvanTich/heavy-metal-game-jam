using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class LevelController : MonoBehaviour {

    public static float Timer { get; private set; }
    private static bool gameEnded;

    public static Dictionary<string, int> OreAmounts { get; private set; }

    static LevelController() {
        Timer = 60;
        gameEnded = false;
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
        if(!gameEnded) {
            Timer -= Time.deltaTime;
            if(Timer <= 0) {
                Timer = 0;
                gameEnded = true;
                EndGame();
            }
        }
    }

    public static void StartGame() {
        // start game

    }

    public static void EndGame() {
        // game end

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
