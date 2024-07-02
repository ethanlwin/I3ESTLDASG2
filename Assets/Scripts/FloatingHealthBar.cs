/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: June 2024
 * Description: Controls the floating health bar UI above a target object
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    /// <summary>
    /// Reference to the slider component of the health bar.
    /// </summary>
    [Header("References")]
    [SerializeField] private Slider slider;

    /// <summary>
    /// Reference to the main camera in the scene.
    /// </summary>
    [SerializeField] private new Camera camera;

    /// <summary>
    /// Transform of the target object whose health is being displayed.
    /// </summary>
    [SerializeField] private Transform target;

    /// <summary>
    /// Offset position from the target object to place the health bar.
    /// </summary>
    [SerializeField] private Vector3 offset;

    private void Awake()
    {
        camera = Camera.main;  // Assign the main camera.
        if (camera != null)
        {
            Debug.Log("Cam Found");  // Log message if camera is found.
        }
        else
        {
            Debug.Log("Cam Not Found");  // Log message if camera is not found.
        }
    }

    /// <summary>
    /// Updates the health bar based on current and maximum health values.
    /// </summary>
    /// <param name="currentHealth">Current health value of the target.</param>
    /// <param name="maxHealth">Maximum health value of the target.</param>
    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        slider.value = currentHealth / maxHealth;  // Update the slider value based on health ratio.
    }

    void Update()
    {
        transform.rotation = camera.transform.rotation;  // Align health bar rotation with camera.
        transform.position = target.position + offset;   // Position health bar above the target with offset.
    }
}

