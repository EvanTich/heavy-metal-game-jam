using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class LevelController : MonoBehaviour {

    private static LevelController _instance;

    public static float Timer { get; private set; }
    private static bool gameEnded;

    public static string[] Names { get; private set; }
    public static int[] OreAmounts { get; private set; }

    [SerializeField]
    private GameObject collectionPoint;
    [SerializeField]
    private GameObject player;

    static LevelController() {
        Timer = 60;
        gameEnded = false;
    }

    public LevelController() {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start() {
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
        _instance.StartGame_();
    }

    private void StartGame_() {
        var playerNameObjects = GameObject.FindGameObjectsWithTag("PlayerNames");

        float rotation = Mathf.Deg2Rad * 360 / playerNameObjects.Length;
        float curr = 0;

        Names = new string[playerNameObjects.Length];
        OreAmounts = new int[Names.Length];

        for(int i = 0; i < playerNameObjects.Length; i++) {
            var name = playerNameObjects[i].GetComponent<InputField>().text;
            Names[i] = name;

            GameObject.Instantiate(
                player, 
                new Vector3(3 * Mathf.Cos(curr) + transform.position.x, transform.position.y, 3 * Mathf.Sin(curr) + transform.position.z), 
                Quaternion.Euler(0, curr, 0)
            ).name = name;
            curr += rotation;
        }
    }

    public static void EndGame() {
        _instance.EndGame_();
    }

    private void EndGame_() {

    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            string name = other.gameObject.name;
            int ore = other.gameObject.GetComponent<Player>().Ore;
            other.gameObject.GetComponent<Player>().Ore = 0;

            for(int i = 0; i < Names.Length; i++)
                if(Names[i] == name) { 
                    OreAmounts[i] += ore;
                    break;
                }
        }
    }
}
