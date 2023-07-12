using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreTally : MonoBehaviour
{
    private int p1Score;
    private int p2Score;

    public TextMeshProUGUI p1Text;
    public TextMeshProUGUI p2Text;
    // Start is called before the first frame update
    void Start()
    {
        p1Score = 0;
        p2Score = 0;
        p1Text.text = p1Score.ToString("");
        p2Text.text = p2Score.ToString("");
    }
    void AddScore(string teamName)
    {
        if(teamName == "Goalpost2")
        {
            p1Score++;
            p1Text.text = p1Score.ToString("");
        }
        else if (teamName == "Goalpost1")
        {
            p2Score++;
            p2Text.text = p2Score.ToString("");
        }
        string goalMessage;
        goalMessage = "Player 1 has scored " + p1Score + " goals, and Player 2 has scored " + p2Score + " goals.";
        Debug.Log(goalMessage);
        StartCoroutine(CheckScore());
    }

    void OnEnable()
    {
        GoalScored.OnUpdate += AddScore;
    }


    void OnDisable()
    {
        GoalScored.OnUpdate -= AddScore;
    }

    IEnumerator CheckScore()
    {
        yield return new WaitForSeconds(3);
        if(p1Score == 5)
        {
            Debug.Log("Player 1 has won!!!");
            SceneManager.LoadScene("P1 Wins");
        }
        else if (p2Score == 5)
        {
            Debug.Log("Player 2 has won!!!");
            SceneManager.LoadScene("P2 Wins");
        }
    }
}
