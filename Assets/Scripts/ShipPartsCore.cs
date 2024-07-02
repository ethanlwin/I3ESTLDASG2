/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: June 2024
 * Description: Extends ShipParts class to implement specific behavior for collecting the ship core
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPartsCore : ShipParts
{
    /// <summary>
    /// Called when the ship core is collected. Sets the HasEnergyCore flag in GameManager and destroys the object.
    /// </summary>
    public override void Collected()
    {
        GameManager.Instance.HasEnergyCore = true;
        base.Collected();
    }

    /// <summary>
    /// Update is called once per frame. Destroys the core part object if HasEnergyCore is true.
    /// </summary>
    public void Update()
    {
        if (GameManager.Instance.HasEnergyCore)
        {
            Destroy(gameObject);
        }
    }
}

