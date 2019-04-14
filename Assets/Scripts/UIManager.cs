using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Camera cam1;
    public Canvas numberCanvas;
    public Canvas nameCanvasPrefab;
    public Camera camPrefab;
    public string p1Name;
    public string p2Name;
    public string p3Name;
    public string p4Name;
    private static byte numPlayers;

    public void OnClickedNumber1() {
        Destroy(numberCanvas.gameObject);
        Canvas canvas1 = Instantiate(nameCanvasPrefab);
        canvas1.gameObject.name = "Canvas1";
        canvas1.worldCamera = cam1;
        canvas1.GetComponentInChildren<Button>().onClick.AddListener(ClickedName1);
        numPlayers = 1;
    }

    public void OnClickedNumber2() {
        Destroy(numberCanvas.gameObject);
        cam1.rect = new Rect(0, 0.5f, 1f, 0.5f);
        Canvas canvas1 = Instantiate(nameCanvasPrefab);
        canvas1.gameObject.name = "Canvas1";
        canvas1.worldCamera = cam1;
        canvas1.GetComponentInChildren<Button>().onClick.AddListener(ClickedName1);
        Camera cam2 = Instantiate(camPrefab, cam1.transform);
        cam2.gameObject.name = "Camera2";
        cam2.rect = new Rect(0, 0, 1f, 0.5f);
        Canvas canvas2 = Instantiate(nameCanvasPrefab);
        canvas2.gameObject.name = "Canvas2";
        canvas2.worldCamera = cam2;
        canvas2.GetComponentInChildren<Button>().onClick.AddListener(ClickedName2);
        numPlayers = 2;
    }

    public void OnClickedNumber3() {
        Destroy(numberCanvas.gameObject);
        cam1.rect = new Rect(0, 0.5f, 1f, 0.5f);
        Canvas canvas1 = Instantiate(nameCanvasPrefab);
        canvas1.gameObject.name = "Canvas1";
        canvas1.worldCamera = cam1;
        canvas1.GetComponentInChildren<Button>().onClick.AddListener(ClickedName1);
        Camera cam2 = Instantiate(camPrefab, cam1.transform);
        cam2.gameObject.name = "Camera2";
        cam2.rect = new Rect(0, 0, 0.5f, 0.5f);
        Canvas canvas2 = Instantiate(nameCanvasPrefab);
        canvas2.gameObject.name = "Canvas2";
        canvas2.worldCamera = cam2;
        canvas2.GetComponentInChildren<Button>().onClick.AddListener(ClickedName2);
        Camera cam3 = Instantiate(camPrefab, cam1.transform);
        cam3.gameObject.name = "Camera3";
        cam3.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
        Canvas canvas3 = Instantiate(nameCanvasPrefab);
        canvas3.gameObject.name = "Canvas3";
        canvas3.worldCamera = cam3;
        canvas3.GetComponentInChildren<Button>().onClick.AddListener(ClickedName3);
        numPlayers = 3;
    }

    public void OnClickedNumber4() {
        Destroy(numberCanvas.gameObject);
        cam1.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
        Canvas canvas1 = Instantiate(nameCanvasPrefab);
        canvas1.gameObject.name = "Canvas1";
        canvas1.worldCamera = cam1;
        canvas1.GetComponentInChildren<Button>().onClick.AddListener(ClickedName1);
        Camera cam2 = Instantiate(camPrefab, cam1.transform);
        cam2.gameObject.name = "Camera2";
        cam2.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
        Canvas canvas2 = Instantiate(nameCanvasPrefab);
        canvas2.gameObject.name = "Canvas2";
        canvas2.worldCamera = cam2;
        canvas2.GetComponentInChildren<Button>().onClick.AddListener(ClickedName2);
        Camera cam3 = Instantiate(camPrefab , cam1.transform);
        cam3.gameObject.name = "Camera3";
        cam3.rect = new Rect(0, 0, 0.5f, 0.5f);
        Canvas canvas3 = Instantiate(nameCanvasPrefab);
        canvas3.gameObject.name = "Canvas3";
        canvas3.worldCamera = cam3;
        canvas3.GetComponentInChildren<Button>().onClick.AddListener(ClickedName3);
        Camera cam4 = Instantiate(camPrefab, cam1.transform);
        cam4.gameObject.name = "Camera4";
        cam4.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
        Canvas canvas4 = Instantiate(nameCanvasPrefab);
        canvas4.gameObject.name = "Canvas4";
        canvas4.worldCamera = cam4;
        canvas4.GetComponentInChildren<Button>().onClick.AddListener(ClickedName4);
        numPlayers = 4;
    }

    public void ClickedName1() {
        numPlayers--;
        p1Name = GameObject.Find("Canvas1").GetComponentInChildren<InputField>().text;
        Destroy(GameObject.Find("Canvas1"));
        if (numPlayers == 0) {
            LevelController.StartGame(p1Name, p2Name, p3Name, p4Name);
        }
    }

    public void ClickedName2() {
        numPlayers--;
        p2Name = GameObject.Find("Canvas2").GetComponentInChildren<InputField>().text;
        Destroy(GameObject.Find("Canvas2"));
        if (numPlayers == 0) {
            LevelController.StartGame(p1Name, p2Name, p3Name, p4Name);
        }
    }

    public void ClickedName3() {
        numPlayers--;
        p3Name = GameObject.Find("Canvas3").GetComponentInChildren<InputField>().text;
        Destroy(GameObject.Find("Canvas3"));
        if (numPlayers == 0) {
            LevelController.StartGame(p1Name, p2Name, p3Name, p4Name);
        }
    }

    public void ClickedName4() {
        numPlayers--;
        p4Name = GameObject.Find("Canvas4").GetComponentInChildren<InputField>().text;
        Destroy(GameObject.Find("Canvas4"));
        if (numPlayers == 0) {
            LevelController.StartGame(p1Name, p2Name, p3Name, p4Name);
        }
    }
}
