/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: June 2024
 * Description: Controls the transition to another scene when triggered
 */

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Entrance : MonoBehaviour
{
    /// <summary>
    /// The scene number to load when the entrance triggers.
    /// </summary>
    [Header("Scene Picker")]
    public int entranceNum;

    /// <summary>
    /// Indicates if the entrance is currently opening.
    /// </summary>
    [HideInInspector]
    public bool opening;

    /// <summary>
    /// Coroutine to initiate the scene transition after a delay.
    /// </summary>
    /// <returns>An IEnumerator for coroutine handling.</returns>
    public IEnumerator Move()
    {
        opening = true; // Set opening flag to true.
        yield return new WaitForSeconds(1f); // Wait for 1 second.
        SceneManager.LoadScene(entranceNum); // Load the specified scene.
    }

    /// <summary>
    /// Initiates the scene transition coroutine.
    /// </summary>
    public void MoveScene()
    {
        StartCoroutine(Move());
    }
}
