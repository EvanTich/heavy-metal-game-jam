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
    private GameObject[] players;

    static LevelController() {
        Timer = 6000;
        gameEnded = false;
    }

    public LevelController() {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        _instance = this;
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

    public static void StartGame(params string[] names) {
        _instance.StartGame_(names);
    }

    private void StartGame_(params string[] names) {
        int num = 0;
        foreach(var name in names) {
            if (name != "")
                num++;
        }
 

        Names = new string[num];

        float rotation = Mathf.Deg2Rad * 360 / num;
        float curr = 0;
        
        OreAmounts = new int[Names.Length];

        var cameras = GameObject.FindGameObjectsWithTag("Camera");

        for(int i = 0; i < Names.Length; i++) {
            Names[i] = names[i];

            var obj = GameObject.Instantiate(
                players[i], 
                new Vector3(3 * Mathf.Cos(curr) + transform.position.x, transform.position.y + 5, 3 * Mathf.Sin(curr) + transform.position.z), 
                Quaternion.Euler(0, curr, 0)
            );
            obj.name = names[i];

            cameras[i].GetComponent<Target>().target = obj.transform;

            curr += rotation;
        }

        Timer = 60;
    }

    public static void EndGame() {
        _instance.EndGame_();
    }

    private void EndGame_() {

    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            string name = other.gameObject.name;
            var plr = other.gameObject.GetComponent<Player>();
            int ore = plr.Ore;
            plr.Ore = 0;
            plr.speed = Player.maxSpeed;
            plr.jumpSpeed = Player.maxJumpSpeed;

            for(int i = 0; i < Names.Length; i++)
                if(Names[i] == name) { 
                    OreAmounts[i] += ore;
                    break;
                }
        }
    }
}
