using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float verticalScreenSize = 5f;
    public float horizontalScreenSize = 6.5f;
    public GameObject enemyOnePrefab;
    public GameObject enemyThreePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject cloudPrefab;
    public GameObject heartPrefab;
    private int time;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemyOne", 1, 2);
        InvokeRepeating("CreateEnemyThree", 3, 4);
        InvokeRepeating("CreateEnemyTwo", 1, 4.5f);
        CreateSky();
        InvokeRepeating("SpawnLife", 5, Random.Range(7f, 10f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }

    void CreateEnemyThree()
    {
        Instantiate(enemyThreePrefab, new Vector3(Random.Range(-8f, 8f), 5.5f, 0), Quaternion.identity);
    }

    void CreateEnemyTwo()
    {
        Instantiate(enemyTwoPrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize), Random.Range(-verticalScreenSize, verticalScreenSize), 0), Quaternion.identity);
        }

    }

    void SpawnLife()
    {
        Instantiate(heartPrefab, new Vector3(Random.Range(-horizontalScreenSize + 1f, horizontalScreenSize - 1f), Random.Range(0.5f, -3.5f), 0), Quaternion.identity);
    }
}
