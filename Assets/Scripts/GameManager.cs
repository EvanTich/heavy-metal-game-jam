using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera cam1;
    public Canvas numberCanvas;
    public Canvas nameCanvasPrefab;
    public Camera camPrefab;
    private byte numPlayers;

    public void OnClickedNumber1() {
        numberCanvas.gameObject.SetActive(false);
        Canvas canvas1 = Instantiate(nameCanvasPrefab);
        canvas1.worldCamera = cam1;
    }

    public void OnClickedNumber2() {
        numberCanvas.gameObject.SetActive(false);
        cam1.rect = new Rect(0, 0.5f, 1f, 0.5f);
        Canvas canvas1 = Instantiate(nameCanvasPrefab);
        canvas1.worldCamera = cam1;
        Camera cam2 = Instantiate(camPrefab);
        cam2.gameObject.name = "Camera2";
        cam2.rect = new Rect(0, 0, 1f, 0.5f);
        Canvas canvas2 = Instantiate(nameCanvasPrefab);
        canvas2.worldCamera = cam2;
    }

    public void OnClickedNumber3() {
        numberCanvas.gameObject.SetActive(false);
        cam1.rect = new Rect(0, 0.5f, 1f, 0.5f);
        Canvas canvas1 = Instantiate(nameCanvasPrefab);
        canvas1.worldCamera = cam1;
        Camera cam2 = Instantiate(camPrefab);
        cam2.gameObject.name = "Camera2";
        cam2.rect = new Rect(0, 0, 0.5f, 0.5f);
        Canvas canvas2 = Instantiate(nameCanvasPrefab);
        canvas2.worldCamera = cam2;
        Camera cam3 = Instantiate(camPrefab);
        cam3.gameObject.name = "Camera3";
        cam3.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
        Canvas canvas3 = Instantiate(nameCanvasPrefab);
        canvas3.worldCamera = cam3;
    }

    public void OnClickedNumber4() {
        numberCanvas.gameObject.SetActive(false);
        cam1.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
        Canvas canvas1 = Instantiate(nameCanvasPrefab);
        canvas1.worldCamera = cam1;
        Camera cam2 = Instantiate(camPrefab);
        cam2.gameObject.name = "Camera2";
        cam2.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
        Canvas canvas2 = Instantiate(nameCanvasPrefab);
        canvas2.worldCamera = cam2;
        Camera cam3 = Instantiate(camPrefab);
        cam3.gameObject.name = "Camera3";
        cam3.rect = new Rect(0, 0, 0.5f, 0.5f);
        Canvas canvas3 = Instantiate(nameCanvasPrefab);
        canvas3.worldCamera = cam3;
        Camera cam4 = Instantiate(camPrefab);
        cam4.gameObject.name = "Camera4";
        cam4.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
        Canvas canvas4 = Instantiate(nameCanvasPrefab);
        canvas4.worldCamera = cam4;
    }

    public void ClickedName() {
        LevelController.StartGame();
    }
}