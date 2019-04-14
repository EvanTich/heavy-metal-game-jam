using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel : MonoBehaviour {

    [SerializeField]
    private Terrain level;
    private TerrainData terrain;
    
    [SerializeField]
    private GameObject[] ores;
    [SerializeField]
    private GameObject rock;
    [SerializeField]
    private GameObject boulder;
    
    [SerializeField]
    private GameObject stalagmite; // ground

    [SerializeField]
    private GameObject column; // ground to ceiling

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
        if(ores.Length == 0) {
            Debug.Log("Get your ore in the right place!");
            return;
        }

        terrain = level.terrainData;
        if(seed != -1)
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

        do {
            x = Random.Range(0, (int)terrain.size.x);
            y = Random.Range(0, (int)terrain.size.z);
        } while(Mathf.Abs(x - transform.position.x) <= 5 && Mathf.Abs(y - transform.position.z) <= 5);
        
        return level.SampleHeight(new Vector3(x, 0, y));
    }

    private void SpawnObj(GameObject obj) {
        int x = 0, y = 0;
        MakeXY(ref x, ref y);

        for(int i = 0; i < patchAmount; i++) {
            int newX = x + Random.Range(-5, 5), newY = y + Random.Range(-5, 5);
            float height = level.SampleHeight(new Vector3(newX, 0, newY)) + obj.GetComponent<Renderer>().bounds.size.y / 2;
            GameObject.Instantiate(obj, new Vector3(newX, height, newY), Quaternion.Euler(0, Random.Range(0, 359), 0));
        }
    }

    private GameObject GetRandomOre() {
        return ores[(int)(Random.value * ores.Length)];
    }

    private void SpawnOrePatch() {
        SpawnObj(GetRandomOre());
    }

    private void SpawnRocks() {
        SpawnObj(rock);
    }

    private GameObject SpawnSingleObj(GameObject obj, bool onlyY = true) {
        int x = 0, y = 0;
        float h = MakeXY(ref x, ref y) + obj.GetComponent<Renderer>().bounds.size.y / 2 -1;

        return GameObject.Instantiate(obj, new Vector3(x, h, y), onlyY ? Quaternion.Euler(0, Random.Range(0, 359), 0) : Random.rotation);
    }

    private void SpawnBoulders() {
        var obj = SpawnSingleObj(boulder);
        var mesh = obj.GetComponent<MeshFilter>().mesh;

        var ore = GetRandomOre();
        var vertices = mesh.vertices;
        for(var i = 0; i < vertices.Length; i++) {
            if(Random.value > .025)
                continue;

            var spawnPoint = obj.transform.TransformPoint(vertices[i]);
            var q = Random.Range(0, vertices.Length);
            spawnPoint = obj.transform.TransformPoint(vertices[q]);
            GameObject.Instantiate(ore, spawnPoint, Quaternion.identity);
        }

    }

    private void SpawnStalagmite() {
        SpawnSingleObj(stalagmite);
    }

    private void SpawnColumns() {
        SpawnSingleObj(column);
    }
}
