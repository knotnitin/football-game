using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScored : MonoBehaviour
{
    Transform parent;
    public GameObject otherPost;

    public delegate void ResetField();
    public static event ResetField OnReset;

    public delegate void UpdateScore(string teamName);
    public static event UpdateScore OnUpdate;

    AudioSource audioSound;

    // Start is called before the first frame update
    void Start()
    {
        parent = gameObject.transform.parent;
        audioSound = GetComponent<AudioSource>();
        GetComponent<BoxCollider2D>().enabled = true;
        otherPost.GetComponent<BoxCollider2D>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ball")
        {
            GetComponent<BoxCollider2D>().enabled = false;
            otherPost.GetComponent<BoxCollider2D>().enabled = false;
            audioSound.Play(0);
            if (parent.name == "Goalpost1")
            {
                Debug.Log("Player 2 scores a goal!!!");
                if (OnUpdate != null)
                {
                    OnUpdate(parent.name);
                }
                StartCoroutine(waiting());
            }
            else if (parent.name == "Goalpost2")
            {
                Debug.Log("Player 1 scores a goal!!!");
                if (OnUpdate != null)
                {
                    OnUpdate(parent.name);
                }
                StartCoroutine(waiting());
            }
        }
    }

    IEnumerator waiting()
    {
        yield return new WaitForSeconds(4);
        if (OnReset != null)
        {
            OnReset();
        }
        GetComponent<BoxCollider2D>().enabled = true;
        otherPost.GetComponent<BoxCollider2D>().enabled = true;
    }
}