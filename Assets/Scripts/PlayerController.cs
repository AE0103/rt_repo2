using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int lives;
    private float playerSpeed;
    public int shield = 0;

    private GameManager gameManager;

    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 9.5f;
    private float verticalScreenLimitPositive = 0.5f;
    private float verticalScreenLimitNegative = -3.5f;

    public GameObject explosionPrefab;
    public GameObject bulletPrefab;

    //This function is called at the start of the game
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerSpeed = 6f;
        lives = 3;
        gameManager.ChangeLivesText(lives);
    }

    public void LoseALife()
    {
        //lives --
        //lives = lives -1
        //lives -= -1;


        lives--;
        gameManager.ChangeLivesText(lives);
        gameManager.PlaySound(5);
        if (lives == 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        //This function is called every frame; 60 frames/second
        Movement();
        Shooting();

    }

    void Shooting()
    {
        //if the player presses the SPACE key, create a projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    void Movement()
    {
        //Read the input from the player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //Move the player
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);
        //Player leaves the screen horizontally
        if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
        //Player leaves the screen vertically (positive)
        if (transform.position.y > verticalScreenLimitPositive)
        {
            transform.position = new Vector3(transform.position.x, verticalScreenLimitPositive, 0);
        }
        //Player leaves the screen vertically (negative)
        if (transform.position.y <= verticalScreenLimitNegative)
        {
            transform.position = new Vector3(transform.position.x, verticalScreenLimitNegative, 0);
        }
    }

    public void GainLives()
    {
        if (lives < 3)
        {
            lives ++ ;
            gameManager.ChangeLivesText(lives);
            gameManager.PlaySound(4);
        }
        else
        {
            gameManager.AddScore(3);
            Debug.Log("Fulllives");
            gameManager.PlaySound(3);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "Coin")
        {
            gameManager.AddScore(1);
            Destroy(whatDidIHit.gameObject);
            gameManager.PlaySound(3);
        }
    }

    public void LoseShield()
    {
        shield--;
        gameManager.PlaySound(2);
    }

    public void GainShield()
    {
        if (shield == 0)
        {
            shield++;
        }
        else
        {
            gameManager.AddScore(1);
            gameManager.PlaySound(3);
        }
    }
}
