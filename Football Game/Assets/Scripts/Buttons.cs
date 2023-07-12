using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void CloseGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

    public void MainMenu()
    {
        Debug.Log("Going to Main Menu");
        SceneManager.LoadScene("Main Menu");
    }

    public void Play()
    {
        SceneManager.LoadScene("2Player Scene");
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }
}
