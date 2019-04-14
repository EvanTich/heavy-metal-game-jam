using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Camera cam1;
    public Canvas numberCanvas;
    public Canvas nameCanvasPrefab;
    public Canvas hudPrefab;
    public Camera camPrefab;
    public string p1Name;
    public string p2Name;
    public string p3Name;
    public string p4Name;
    public Player p1;
    public Player p2;
    public Player p3;
    public Player p4;
    private static byte numPlayers;
    private byte players;

    private bool gameStarted;

    private void Start() {
        DontDestroyOnLoad(this);
    }

    public void OnClickedNumber1() {
        Destroy(numberCanvas.gameObject);
        Canvas canvas1 = Instantiate(nameCanvasPrefab);
        canvas1.gameObject.name = "Canvas1";
        canvas1.worldCamera = cam1;
        canvas1.planeDistance = 1;
        canvas1.GetComponentInChildren<Button>().onClick.AddListener(ClickedName1);
        numPlayers = 1;
        players = 1;
    }

    public void OnClickedNumber2() {
        Destroy(numberCanvas.gameObject);
        cam1.rect = new Rect(0, 0.5f, 1f, 0.5f);
        Canvas canvas1 = Instantiate(nameCanvasPrefab);
        canvas1.gameObject.name = "Canvas1";
        canvas1.worldCamera = cam1;
        canvas1.planeDistance = 1;
        canvas1.GetComponentInChildren<Button>().onClick.AddListener(ClickedName1);
        Camera cam2 = Instantiate(camPrefab, cam1.transform);
        cam2.gameObject.name = "Camera2";
        cam2.rect = new Rect(0, 0, 1f, 0.5f);
        Canvas canvas2 = Instantiate(nameCanvasPrefab);
        canvas2.gameObject.name = "Canvas2";
        canvas2.worldCamera = cam2;
        canvas2.planeDistance = 1;
        canvas2.GetComponentInChildren<Button>().onClick.AddListener(ClickedName2);
        numPlayers = 2;
        players = 2;
    }

    public void OnClickedNumber3() {
        Destroy(numberCanvas.gameObject);
        cam1.rect = new Rect(0, 0.5f, 1f, 0.5f);
        Canvas canvas1 = Instantiate(nameCanvasPrefab);
        canvas1.gameObject.name = "Canvas1";
        canvas1.worldCamera = cam1;
        canvas1.planeDistance = 1;
        canvas1.GetComponentInChildren<Button>().onClick.AddListener(ClickedName1);
        Camera cam2 = Instantiate(camPrefab, cam1.transform);
        cam2.gameObject.name = "Camera2";
        cam2.rect = new Rect(0, 0, 0.5f, 0.5f);
        Canvas canvas2 = Instantiate(nameCanvasPrefab);
        canvas2.gameObject.name = "Canvas2";
        canvas2.worldCamera = cam2;
        canvas2.planeDistance = 1;
        canvas2.GetComponentInChildren<Button>().onClick.AddListener(ClickedName2);
        Camera cam3 = Instantiate(camPrefab, cam1.transform);
        cam3.gameObject.name = "Camera3";
        cam3.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
        Canvas canvas3 = Instantiate(nameCanvasPrefab);
        canvas3.gameObject.name = "Canvas3";
        canvas3.worldCamera = cam3;
        canvas3.planeDistance = 1;
        canvas3.GetComponentInChildren<Button>().onClick.AddListener(ClickedName3);
        numPlayers = 3;
        players = 3;
    }

    public void OnClickedNumber4() {
        Destroy(numberCanvas.gameObject);
        cam1.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
        Canvas canvas1 = Instantiate(nameCanvasPrefab);
        canvas1.gameObject.name = "Canvas1";
        canvas1.worldCamera = cam1;
        canvas1.planeDistance = 1;
        canvas1.GetComponentInChildren<Button>().onClick.AddListener(ClickedName1);
        Camera cam2 = Instantiate(camPrefab, cam1.transform);
        cam2.gameObject.name = "Camera2";
        cam2.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
        Canvas canvas2 = Instantiate(nameCanvasPrefab);
        canvas2.gameObject.name = "Canvas2";
        canvas2.worldCamera = cam2;
        canvas2.planeDistance = 1;
        canvas2.GetComponentInChildren<Button>().onClick.AddListener(ClickedName2);
        Camera cam3 = Instantiate(camPrefab , cam1.transform);
        cam3.gameObject.name = "Camera3";
        cam3.rect = new Rect(0, 0, 0.5f, 0.5f);
        Canvas canvas3 = Instantiate(nameCanvasPrefab);
        canvas3.gameObject.name = "Canvas3";
        canvas3.worldCamera = cam3;
        canvas3.planeDistance = 1;
        canvas3.GetComponentInChildren<Button>().onClick.AddListener(ClickedName3);
        Camera cam4 = Instantiate(camPrefab, cam1.transform);
        cam4.gameObject.name = "Camera4";
        cam4.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
        Canvas canvas4 = Instantiate(nameCanvasPrefab);
        canvas4.gameObject.name = "Canvas4";
        canvas4.worldCamera = cam4;
        canvas4.planeDistance = 1;
        canvas4.GetComponentInChildren<Button>().onClick.AddListener(ClickedName4);
        numPlayers = 4;
        players = 4;
    }

    private void NamesDone() {
        LevelController.StartGame(p1Name, p2Name, p3Name, p4Name);
        gameStarted = true;
        switch(players) {
            case 4:
                Camera cam4 = GameObject.Find("Camera4").GetComponent<Camera>();
                Canvas canvas4 = Instantiate(hudPrefab);
                canvas4.gameObject.name = "Canvas4";
                canvas4.worldCamera = cam4;
                canvas4.planeDistance = 1;
                canvas4.GetComponentInChildren<Text>().text = "Player Name: " + p4Name;
                p4 = GameObject.Find(p4Name).GetComponent<Player>();
                goto case 3;
            case 3:
                Camera cam3 = GameObject.Find("Camera3").GetComponent<Camera>();
                Canvas canvas3 = Instantiate(hudPrefab);
                canvas3.gameObject.name = "Canvas3";
                canvas3.worldCamera = cam3;
                canvas3.planeDistance = 1;
                canvas3.GetComponentInChildren<Text>().text = "Player Name: " + p3Name;
                p3 = GameObject.Find(p3Name).GetComponent<Player>();
                goto case 2;
            case 2:
                Camera cam2 = GameObject.Find("Camera2").GetComponent<Camera>();
                Canvas canvas2 = Instantiate(hudPrefab);
                canvas2.gameObject.name = "Canvas2";
                canvas2.worldCamera = cam2;
                canvas2.planeDistance = 1;
                canvas2.GetComponentInChildren<Text>().text = "Player Name: " + p2Name;
                p2 = GameObject.Find(p2Name).GetComponent<Player>();
                goto case 1;
            case 1:
                Canvas canvas1 = Instantiate(hudPrefab);
                canvas1.gameObject.name = "Canvas1";
                canvas1.worldCamera = cam1;
                canvas1.planeDistance = 1;
                canvas1.GetComponentInChildren<Text>().text = "Player Name: " + p1Name;
                p1 = GameObject.Find(p1Name).GetComponent<Player>();
                break;
        }
    }

    public void ClickedName1() {
        numPlayers--;
        p1Name = GameObject.Find("Canvas1").GetComponentInChildren<InputField>().text;
        Destroy(GameObject.Find("Canvas1"));
        if (numPlayers == 0) {
            NamesDone();
        }
    }

    public void ClickedName2() {
        numPlayers--;
        p2Name = GameObject.Find("Canvas2").GetComponentInChildren<InputField>().text;
        Destroy(GameObject.Find("Canvas2"));
        if (numPlayers == 0) {
            NamesDone();
        }
    }

    public void ClickedName3() {
        numPlayers--;
        p3Name = GameObject.Find("Canvas3").GetComponentInChildren<InputField>().text;
        Destroy(GameObject.Find("Canvas3"));
        if (numPlayers == 0) {
            NamesDone();
        }
    }

    public void ClickedName4() {
        numPlayers--;
        p4Name = GameObject.Find("Canvas4").GetComponentInChildren<InputField>().text;
        Destroy(GameObject.Find("Canvas4"));
        if (numPlayers == 0) {
            NamesDone();
        }
    }

    private void Update() {
        if(!gameStarted)
            return;

        if (players == 1) {
            Text resources1 = GameObject.Find("Canvas1/Resources").GetComponent<Text>();
            Text timer1 = GameObject.Find("Canvas1/Timer").GetComponent<Text>();

            resources1.text = "Resource Count: " + p1.Ore;
            timer1.text = "Time Left: " + LevelController.Timer;
        }
        if (players == 2) {
            Text resources1 = GameObject.Find("Canvas1/Resources").GetComponent<Text>();
            Text resources2 = GameObject.Find("Canvas2/Resources").GetComponent<Text>();
            Text timer1 = GameObject.Find("Canvas1/Timer").GetComponent<Text>();
            Text timer2 = GameObject.Find("Canvas2/Timer").GetComponent<Text>();

            resources1.text = "Resource Count: " + p1.Ore;
            resources2.text = "Resource Count: " + p2.Ore;
            timer1.text = "Time Left: " + LevelController.Timer;
            timer2.text = "Time Left: " + LevelController.Timer;
        }
        if (players == 3) {
            Text resources1 = GameObject.Find("Canvas1/Resources").GetComponent<Text>();
            Text resources2 = GameObject.Find("Canvas2/Resources").GetComponent<Text>();
            Text resources3 = GameObject.Find("Canvas3/Resources").GetComponent<Text>();
            Text timer1 = GameObject.Find("Canvas1/Timer").GetComponent<Text>();
            Text timer2 = GameObject.Find("Canvas2/Timer").GetComponent<Text>();
            Text timer3 = GameObject.Find("Canvas3/Timer").GetComponent<Text>();
           
            resources1.text = "Resource Count: " + p1.Ore;
            resources2.text = "Resource Count: " + p2.Ore;
            resources3.text = "Resource Count: " + p3.Ore;
            timer1.text = "Time Left: " + LevelController.Timer;
            timer2.text = "Time Left: " + LevelController.Timer;
            timer3.text = "Time Left: " + LevelController.Timer;
        }
        if (players == 4) {
            Text resources1 = GameObject.Find("Canvas1/Resources").GetComponent<Text>();
            Text resources2 = GameObject.Find("Canvas2/Resources").GetComponent<Text>();
            Text resources3 = GameObject.Find("Canvas3/Resources").GetComponent<Text>();
            Text resources4 = GameObject.Find("Canvas4/Resources").GetComponent<Text>();
            Text timer1 = GameObject.Find("Canvas1/Timer").GetComponent<Text>();
            Text timer2 = GameObject.Find("Canvas2/Timer").GetComponent<Text>();
            Text timer3 = GameObject.Find("Canvas3/Timer").GetComponent<Text>();
            Text timer4 = GameObject.Find("Canvas4/Timer").GetComponent<Text>();

            resources1.text = "Resource Count: " + p1.Ore;
            resources2.text = "Resource Count: " + p2.Ore;
            resources3.text = "Resource Count: " + p3.Ore;
            resources4.text = "Resource Count: " + p4.Ore;
            timer1.text = "Time Left: " + LevelController.Timer;
            timer2.text = "Time Left: " + LevelController.Timer;
            timer3.text = "Time Left: " + LevelController.Timer;
            timer4.text = "Time Left: " + LevelController.Timer;
        }
    }
}
