/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: June 2024
 * Description: Handles player shooting and reloading input using events
 */

using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    /// <summary>
    /// Event invoked when the shoot input is triggered.
    /// </summary>
    public static Action shootInput;

    /// <summary>
    /// Event invoked when the reload input is triggered.
    /// </summary>
    public static Action reloadInput;

    [SerializeField] private KeyCode reloadKey; // Key to trigger reload (for demonstration purposes)

    private void Update()
    {
        // Example of how to handle shooting with a mouse button
        // if(Input.GetMouseButton(0))
        // {
        //     shootInput?.Invoke();
        // }

        // Example of how to handle reloading with a specific key
        // if(Input.GetKeyDown(reloadKey))
        // {
        //     reloadInput?.Invoke();
        // }
    }

    /// <summary>
    /// Callback for reload input from player input system.
    /// </summary>
    void OnReload()
    {
        reloadInput?.Invoke();
    }

    /// <summary>
    /// Callback for shoot input from player input system.
    /// </summary>
    /// <param name="value">Input value from player input system.</param>
    void OnShoot(InputValue value)
    {
        if (value.isPressed)
        {
            shootInput?.Invoke();
        }
    }
}

