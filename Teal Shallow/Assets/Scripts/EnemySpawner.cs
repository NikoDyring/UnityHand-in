using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public int amountOfEnemies;
    public GameObject[] waypoints;

    [Header("Enemy Settings")]
    public GameObject[] enemyType;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountOfEnemies; i++)
        {
            SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        Instantiate(enemyType[Random.Range(0,3)], waypoints[Random.Range(0, 15)].transform.position, Quaternion.identity);
    }
}
