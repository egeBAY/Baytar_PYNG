using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyType1Obj;
    public GameObject enemyType2Obj;

    private List<GameObject> objectsToSpawn = new List<GameObject>();
    private int enemyType1Count = 10;
    private int enemyType2Count = 5;

    private void Start()
    {
        for (int i = 0; i < enemyType1Count; i++)
        {
            objectsToSpawn.Add(enemyType1Obj);
        }

        for (int i = 0; i < enemyType2Count; i++)
        {
            objectsToSpawn.Add(enemyType2Obj);
        }

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (objectsToSpawn.Count > 0)
        {
            yield return new WaitForSeconds(1);
            int randomSpawnIndex = Random.Range(0, objectsToSpawn.Count);
            GameObject enemyPrefab = objectsToSpawn[randomSpawnIndex];
            objectsToSpawn.RemoveAt(randomSpawnIndex);

            Instantiate(enemyPrefab, transform.position, transform.rotation);
        }
    }
}