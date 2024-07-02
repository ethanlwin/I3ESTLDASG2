/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: June 2024
 * Description: Extends ShipParts class to implement specific behavior for collecting medkits
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : ShipParts
{
    /// <summary>
    /// Increases the medkit count in GameManager when collected and destroys the game object.
    /// </summary>
    public override void Collected()
    {
        GameManager.Instance.MedKitCount += 1;
        base.Collected();
    }
}
