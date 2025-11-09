using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 9.5f;
    private float verticalScreenLimitPositive = 2.5f;
    private float verticalScreenLimitNegative = -3.5f;

    public GameObject bulletPrefab;

    void Start()
    {
        playerSpeed = 6f;
        //This function is called at the start of the game
        
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
        if(Input.GetKeyDown(KeyCode.Space))
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
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, 0);
        }
        //Player leaves the screen vertically (negative)
        if (transform.position.y <= verticalScreenLimitNegative)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);
        }
    }
}
