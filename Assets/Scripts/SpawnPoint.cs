using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public GameObject[] objectsToSpawn;

    public GameObject tileObject;
    public enum TileToSpawn { Empty, Tiled };


    private void Start()
    {
        //TileToSpawn tile;

         
       // tile = TileToSpawn.Empty;
        int rand = Random.Range(0, objectsToSpawn.Length);
        GameObject instance = Instantiate(objectsToSpawn[rand], transform.position, Quaternion.identity);
        instance.transform.parent = transform;

       
    }
}
