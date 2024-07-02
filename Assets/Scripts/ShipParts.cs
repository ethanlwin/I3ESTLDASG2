/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: June 2024
 * Description: Handles the behavior of ship parts and some interactables, including collection and rotation(which for some reason does not work for some objects)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipParts : MonoBehaviour
{
    /// <summary>
    /// Reference to the collected audio clip.
    /// </summary>
    [Header("AudioRef")]
    [SerializeField] AudioClip collected;

    /// <summary>
    /// Called when the ship part is collected, playing an audio clip and destroying the game object.
    /// </summary>
    public virtual void Collected()
    {
        AudioSource.PlayClipAtPoint(collected, transform.position);
        Destroy(gameObject);
    }

    /// <summary>
    /// Updates the rotation of the ship part object.
    /// </summary>
    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }
}
