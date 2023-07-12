using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBall : MonoBehaviour
{
    GameObject obj;
    Rigidbody2D rb;
    Rigidbody2D parentRB;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        rb = GetComponent<Rigidbody2D>();
        parentRB = this.GetComponentInParent(typeof(Rigidbody2D)) as Rigidbody2D;
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetBallPosition()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector3(0, 0, 0);
    }

    void OnEnable()
    {
        GoalScored.OnReset += ResetBallPosition;
    }


    void OnDisable()
    {
        GoalScored.OnReset -= ResetBallPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            rb.AddForce(-rb.velocity * 5);
        }
    }
}
