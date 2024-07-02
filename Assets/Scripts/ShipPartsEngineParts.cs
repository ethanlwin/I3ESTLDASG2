/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: June 2024
 * Description: Extends ShipParts class to implement specific behavior for collecting engine parts.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Extends ShipParts class to implement specific behavior for collecting engine parts
/// </summary>
public class ShipPartsEngineParts : ShipParts
{
    public override void Collected()
    {
        GameManager.Instance.EngineParts += 1;
        base.Collected();
    }

    /// <summary>
    /// Update is called once per frame. Destroys the engine part object if EngineParts count reaches 2.
    /// </summary>
    public void Update()
    {
        if (GameManager.Instance.EngineParts == 2)
        {
            Destroy(gameObject);
        }
    }
}
