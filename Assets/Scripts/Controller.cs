/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: June 2024
 * Description: this script contains the activate sequence for the final interact of the game
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    /// <summary>
    /// Reference to the AudioSource component for playing win audio.
    /// </summary>
    [SerializeField] AudioSource winAudio;

    /// <summary>
    /// Activates the controller if all required parts are placed, plays win audio, displays the win screen, and disables player controls.
    /// </summary>
    public void ActivateController()
    {
        if (GameManager.Instance.CorePlaced && GameManager.Instance.FuelPlaced && GameManager.Instance.EnginePlaced && GameManager.Instance.ScrapMetalPlaced)
        {
            winAudio.Play();
            GameManager.Instance.winScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            GameManager.Instance.player.GetComponent<FirstPersonController>().enabled = false;
            GameManager.Instance.player.GetComponent<PlayerInput>().enabled = false;
        }
    }
}
