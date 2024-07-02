/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: June 2024
 * Description: Handles main menu functionality including starting the game,
 * quitting the application, and toggling audio
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Loads the game scene when the play button is clicked.
    /// </summary>
    public void PlayGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Quits the application when the quit button is clicked.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Toggles the audio on or off based on the toggle state.
    /// </summary>
    /// <param name="tickOn">True if audio should be on, false if off.</param>
    public void OnToggleChange(bool tickOn)
    {
        if (tickOn)
        {
            AudioListener.volume = 1.0f;
        }
        else
        {
            AudioListener.volume = 0.0f;
        }
    }
}

