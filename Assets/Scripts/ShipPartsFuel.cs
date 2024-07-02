/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: June 2024
 * Description: Extends ShipParts class to implement specific behavior for collecting fuel
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShipPartsFuel : ShipParts
{
    /// <summary>
    /// Called when the fuel part is collected. Sets the HasFuel flag in GameManager and destroys the object.
    /// </summary>
    public override void Collected()
    {
        GameManager.Instance.HasFuel = true;
        base.Collected();
    }

    /// <summary>
    /// Update is called once per frame. Destroys the fuel part object if HasFuel is true.
    /// </summary>
    public void Update()
    {
        if (GameManager.Instance.HasFuel)
        {
            Destroy(gameObject);
        }
    }
}
