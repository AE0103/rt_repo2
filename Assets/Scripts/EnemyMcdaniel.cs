using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMcdaniel : MonoBehaviour
{
    public GameObject explosionPrefab;
    private GameManager gameManager;

    private int speed_dir = 1;
    private Vector3 start_pos;
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        start_pos = transform.position;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= start_pos.x)
        {
            speed_dir = 1;
        }
        else if (transform.position.x >= start_pos.x + 2)
        {
            speed_dir = -1;
        }
        transform.Translate(new Vector3(0.4f * speed_dir, -0.7f, 0) * Time.deltaTime * 3f);
        if (transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "Player")
        {
            whatDidIHit.GetComponent<PlayerController>().LoseALife();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        else if (whatDidIHit.tag == "Weapons")
        {
            Destroy(whatDidIHit.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            gameManager.AddScore(5);
            Destroy(this.gameObject);
        }
    }
}
