using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    /// <summary>
    /// link to the pause menu
    /// </summary>
    public GameObject pauseMenu;
    /// <summary>
    /// bool to check if game is paused
    /// </summary>
    public static bool isPaused = false;
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        
    }

    void OnPause()
    {
        Debug.Log(isPaused);
        if (!isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    /// <summary>
    /// activates the pause menu and freezes the game
    /// </summary>
    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    /// <summary>
    /// deactivates the pause menu and unfreezes the game
    /// </summary>
    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    /// <summary>
    /// send the player to the main menu
    /// </summary>
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// quits the game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
