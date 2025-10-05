using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMobSpawning : MonoBehaviour
{
    public float min = 15f;
    public float max = 30f;
    public float subtractor = 0.2f;
    public float startingHeight = 0f;
    public float playAreaYcoord = 30;
    public float playAreaXcoord = 30;
    public GameObject Mage_Prefab;
    public GameObject Tank_Prefab;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("mobSpawning", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void mobSpawning() {
        int whoSpawn = Random.Range(1, 3);
        Vector3 spawnPoint = new Vector3(Random.Range(-playAreaXcoord, playAreaXcoord), startingHeight, Random.Range(-playAreaYcoord, playAreaYcoord));
        if (whoSpawn == 1)
        {
            Instantiate(Mage_Prefab, spawnPoint, Quaternion.identity);
        }
        else {
            Instantiate(Tank_Prefab, spawnPoint, Quaternion.identity);
        }
        min -= subtractor; max -= subtractor;
        float spawn = Random.Range(min, max);
        Invoke("mobSpawning", spawn);
    }

}
