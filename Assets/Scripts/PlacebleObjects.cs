/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: June 2024
 * Description: this script will alllow the player to place the ship parts to repair the ship using instantiate
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacebleObjects : MonoBehaviour
{
    /// <summary>
    /// The object to spawn when placed.
    /// </summary>
    [SerializeField] GameObject ObjectToSpawn;

    /// <summary>
    /// The identifier for the object
    /// </summary>
    public int Object;

    /// <summary>
    /// The audio clip to play when the object is placed
    /// </summary>
    [SerializeField] AudioClip placeaudio;

    /// <summary>
    /// Called when the object is placed, playing an audio clip, spawning the object, and destroying the original game object.
    /// </summary>
    public virtual void Placed()
    {
        AudioSource.PlayClipAtPoint(placeaudio, transform.position);
        Instantiate(ObjectToSpawn, transform.position, ObjectToSpawn.transform.rotation);
        Destroy(gameObject);
    }
}
