/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: June 2024
 * Description: Extends ShipParts class to implement specific behavior for collecting keys
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : ShipParts
{
    /// <summary>
    /// Identifier for the key.
    /// </summary>
    public int keyNum;

    /// <summary>
    /// Called when the key is collected. Sets the corresponding key flag in GameManager and destroys the object.
    /// </summary>
    public override void Collected()
    {
        if (keyNum == 1)
        {
            GameManager.Instance.BossRoomKey = true;
        }
        else
        {
            GameManager.Instance.CraftRoomKey = true;
        }
        base.Collected();
    }

    /// <summary>
    /// Update is called once per frame. Destroys the key object if the BossRoomKey is true.
    /// </summary>
    public void Update()
    {
        if (GameManager.Instance.BossRoomKey)
        {
            Destroy(gameObject);
        }
    }
}
