/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: June 2024
 * Description: Controls the animation of a ship door based on the state of an entrance
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDoor : MonoBehaviour
{
    /// <summary>
    /// Reference to the Animator component for controlling door animations.
    /// </summary>
    [Header("References")]
    public Animator anim;

    /// <summary>
    /// Reference to the entrance associated with this door.
    /// </summary>
    public Entrance entrance;

    void Update()
    {
        // Check if the associated entrance is opening
        if (entrance.opening)
        {
            anim.SetBool("Interacted", true);  // Set the Interacted parameter to true to open the door.
        }
        else
        {
            anim.SetBool("Interacted", false);  // Set the Interacted parameter to false to close the door.
        }
    }
}
