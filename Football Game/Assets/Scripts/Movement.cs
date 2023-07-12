using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 7;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if(gameObject.name == "Player1")
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            float movebyX = x * speed;
            float movebyY = y * speed;
            rb.velocity = new Vector2(movebyX, movebyY);
        }
        else if(gameObject.name == "Player2")
        {
            float p2x = Input.GetAxis("Player2Horizontal");
            float p2y = Input.GetAxis("Player2Vertical");
            float moveP2byX = p2x * speed;
            float moveP2byY = p2y * speed;
            rb.velocity = new Vector2(moveP2byX, moveP2byY);
        }
    }

    void ResetPlayerPosition()
    {
        if(transform.name == "Player1")
        {
            transform.position = new Vector3(-5, 0, 0);
        }
        else if (transform.name == "Player2")
        {
            transform.position = new Vector3(5, 0, 0);
        }
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        speed = 7;
    }

    void PowerUpPlayer(string powerUp, string playername)
    {
        if(playername == gameObject.name)
        {
            StartCoroutine(giveBoost(powerUp));
        }
    }

    void OnEnable()
    {
        GoalScored.OnReset += ResetPlayerPosition;
        PowerUp.OnPowerUp += PowerUpPlayer;
    }


    void OnDisable()
    {
        GoalScored.OnReset -= ResetPlayerPosition;
        PowerUp.OnPowerUp -= PowerUpPlayer;
    }

    IEnumerator giveBoost(string powerUpType)
    {
        if(powerUpType == "Speed Boost")
        {
            speed = 10;
            yield return new WaitForSeconds(10);
            speed = 7;
        }
        else if (powerUpType == "Increase Size")
        {
            gameObject.transform.localScale = new Vector3(2, 2, 2);
            yield return new WaitForSeconds(10);
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
