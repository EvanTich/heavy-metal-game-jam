using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel : MonoBehaviour {

    [SerializeField]
    private Terrain level;
    private TerrainData terrain;

    [SerializeField]
    private GameObject ore;
    [SerializeField]
    private GameObject rock;
    [SerializeField]
    private GameObject boulder;

    //[SerializeField]
    //private GameObject stalagtite; // ceiling
    [SerializeField]
    private GameObject stalagmite; // ground

    [SerializeField]
    private GameObject column; // ground to ceiling

    private Random rand;

    [SerializeField]
    private int seed;

    [SerializeField]
    private int amountOfStuff;
    [SerializeField]
    private int patchAmount;

    /// <summary>
    /// Spawns the level.
    /// </summary>
    void Start() {
        terrain = level.terrainData;
        Random.InitState(seed);

        for(int i = 0; i < amountOfStuff; i++) {
            SpawnOrePatch();
            SpawnRocks();
            SpawnBoulders();
            SpawnStalagmite();
            SpawnColumns();
        }
    }
    
    void Update() {
        // nothing, probably
    }

    private float MakeXY(ref int x, ref int y) {
        x = Random.Range(0, (int) terrain.size.x);
        y = Random.Range(0, (int) terrain.size.y);
        return terrain.GetHeight(x, y);
    }

    private void SpawnObj(GameObject obj) {
        int x = 0, y = 0;
        MakeXY(ref x, ref y);

        for(int i = 0; i < patchAmount; i++) {
            int newX = x + Random.Range(-5, 5), newY = y + Random.Range(-5, 5);
            float height = terrain.GetHeight(newX, newY);
            GameObject.Instantiate(obj, new Vector3(newX, height, newY), Quaternion.identity);
        }
    }

    private void SpawnOrePatch() {
        SpawnObj(ore);
    }

    private void SpawnRocks() {
        SpawnObj(rock);
    }

    private void SpawnSingleObj(GameObject obj) {
        int x = 0, y = 0;
        float h = MakeXY(ref x, ref y);

        GameObject.Instantiate(obj, new Vector3(x, h, y), Quaternion.identity);
    }

    private void SpawnBoulders() {
        SpawnSingleObj(boulder);
    }

    private void SpawnStalagmite() {
        SpawnSingleObj(stalagmite);
    }

    private void SpawnColumns() {
        SpawnSingleObj(column);
    }
}
