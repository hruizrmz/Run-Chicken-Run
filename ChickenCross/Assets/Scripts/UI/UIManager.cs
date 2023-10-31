using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pauseScreen, gameOverScreen, youWonScreen;
    public static bool gameIsPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }
    public void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
        }
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        StartCoroutine(CutsceneTimer(20f));
    }

    public void YouWon()
    {
        youWonScreen.SetActive(true);
        Time.timeScale = 0;
    }

    IEnumerator CutsceneTimer(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
