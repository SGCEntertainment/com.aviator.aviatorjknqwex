using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] platformPrefab;      

    void Start()
    {
        Vector3 SpawnerPosition = new Vector3();    

        for (int i = 0; i < 100; i++)               
        {
            SpawnerPosition.x += Random.Range(10f, 20f);
            SpawnerPosition.y += Random.Range(-1.7f, 1.7f);      

            Instantiate(platformPrefab[Random.Range(0, platformPrefab.Length)], SpawnerPosition, Quaternion.identity);  
        }

    }
}
