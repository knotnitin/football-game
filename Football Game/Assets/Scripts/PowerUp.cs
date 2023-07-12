using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private float randX = 5.4f; // for x pos
    private float randY = 4.7f; // for y pos

    public delegate void SendPowerUp(string powerUp, string player);
    public static event SendPowerUp OnPowerUp;
    SpriteRenderer sr;
    private bool powerUpTouched = false;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
        StartCoroutine(generate());
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Generate()
    {
        float xPos = Random.Range(-randX, randX);
        float yPos = Random.Range(-randY, randY);
        transform.position = new Vector2(xPos, yPos);
        sr.enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    IEnumerator generate()
    {
        yield return new WaitForSeconds(Random.Range(10, 15));
        Generate();
        yield return new WaitForSeconds(10);
        if(!powerUpTouched)
        {
            sr.enabled = false;
        }
        yield return new WaitForSeconds(Random.Range(10, 15));
        StartCoroutine(generate());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            powerUpTouched = true;
            sr.enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            StopCoroutine(generate());
            if (OnPowerUp != null)
            {
                OnPowerUp(gameObject.name, other.name);
            }
            StartCoroutine(generate());
        }
    }
}
