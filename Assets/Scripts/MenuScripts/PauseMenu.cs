/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: June 2024
 * Description: Manages the pause menu functionality including pausing, resuming,
 * and navigating to main menu or quitting the game
 */

using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    /// <summary>
    /// Reference to the pause menu GameObject.
    /// </summary>
    public GameObject pauseMenu;

    /// <summary>
    /// Indicates whether the game is currently paused.
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
    /// Activates the pause menu and freezes the game.
    /// </summary>
    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        GameManager.Instance.player.GetComponent<FirstPersonController>().enabled = false;
        GameManager.Instance.player.GetComponent<PlayerInput>().enabled = false;
    }

    /// <summary>
    /// Deactivates the pause menu and resumes the game.
    /// </summary>
    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        GameManager.Instance.player.GetComponent<FirstPersonController>().enabled = true;
        GameManager.Instance.player.GetComponent<PlayerInput>().enabled = true;
    }

    /// <summary>
    /// Sends the player to the main menu.
    /// </summary>
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        Destroy(GameManager.Instance.gameObject);
    }

    /// <summary>
    /// Restarts the current level.
    /// </summary>
    public void Restart()
    {
        Destroy(GameManager.Instance.gameObject);
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Quits the application.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}

