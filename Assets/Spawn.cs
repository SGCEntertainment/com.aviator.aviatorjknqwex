using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] platformPrefab;

    void Start()
    {
        StartCoroutine(SpawnObj());
    }

    private IEnumerator SpawnObj()
    {
        yield return new WaitForSeconds(0.1f);
        Vector3 SpawnerPosition = new Vector3();

        SpawnerPosition.x = Random.Range(2f, 450f);
        SpawnerPosition.y += Random.Range(-20f, 0f);

        Instantiate(platformPrefab[Random.Range(0, platformPrefab.Length)], SpawnerPosition, Quaternion.identity);

        StartCoroutine(SpawnObj());

    }
}
