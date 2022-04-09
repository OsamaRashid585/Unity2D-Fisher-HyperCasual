using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool IsGameOver;
    public GameObject GameOverPopup;

    private void Awake()
    {
        IsGameOver = false;
        GameOverPopup.SetActive(false);
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (IsGameOver)
        {
            Time.timeScale = 0f;
            GameOverPopup.SetActive(true);
        }
    }
    public void RetryGame()
    {
        SceneManager.LoadScene(0);
    }
}
