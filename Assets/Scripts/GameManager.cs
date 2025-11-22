using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float verticalScreenSize = 5f;
    public float horizontalScreenSize = 6.5f;
    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject enemyThreePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject cloudPrefab;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public int score;
    public GameObject heartPrefab;
    public GameObject coinPrefab;
    public GameObject shieldPrefab;
    private GameObject player;
    public GameObject audioPlayer;

    public AudioClip shieldGain;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        InvokeRepeating("CreateEnemyOne", 1, 2);
        InvokeRepeating("CreateEnemyThree", 3, 4);
        InvokeRepeating("CreateEnemyTwo", 1, 4.5f);
        score = 0;
        AddScore(0);
        CreateSky();
        InvokeRepeating("SpawnLife", 5, Random.Range(7f, 8f));
        StartCoroutine(SpawnCoin());
        InvokeRepeating("SpawnShield", 5, Random.Range(7f, 8f));
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

    void CreateCoin()
    {
        Instantiate(coinPrefab, new Vector3(Random.Range(-horizontalScreenSize * 0.8f, horizontalScreenSize * 0.8f), Random.Range(0.5f, -3.5f), 0), Quaternion.identity);
    }

    public void AddScore(int earnedScore)
    {
        score = score + earnedScore;
        scoreText.text = "Score: " + score;
    }

    public void ChangeLivesText(int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }

    void SpawnLife()
    {
        Instantiate(heartPrefab, new Vector3(Random.Range(-horizontalScreenSize + 1f, horizontalScreenSize - 1f), Random.Range(0.5f, -3.5f), 0), Quaternion.identity);
    }

    IEnumerator SpawnCoin()
    {
        float spawnTime = Random.Range(3, 5);
        yield return new WaitForSeconds(spawnTime);
        CreateCoin();
        StartCoroutine(SpawnCoin());
    }

    void SpawnShield()
    {
        Instantiate(shieldPrefab, new Vector3(Random.Range(-horizontalScreenSize + 1f, horizontalScreenSize - 1f), Random.Range(0.5f, -3.5f), 0), Quaternion.identity);
    }

    // A funtion that will play a sound depending on certain requirments (whats being hit mostly)
    public void PlaySound(int whichSound)
    {
        switch (whichSound)
        {
            case 1:
                audioPlayer.GetComponent<AudioSource>().PlayOneShot(shieldGain);
                break;
        }
    }
}
