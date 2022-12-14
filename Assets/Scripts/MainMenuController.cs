using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OpenAuthor()
    {
        Debug.Log("Created by Achmad Rionov");
    }
}
