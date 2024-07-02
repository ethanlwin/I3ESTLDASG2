/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: June 2024
 * Description: Extends ShipParts class to implement specific behavior for collecting scrap metal parts
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPartsMetal : ShipParts
{
    /// <summary>
    /// Called when a scrap metal part is collected. Increases ScrapMetal count in GameManager and destroys the object.
    /// </summary>
    public override void Collected()
    {
        GameManager.Instance.ScrapMetal += 1;
        base.Collected();
    }

    /// <summary>
    /// Update is called once per frame. Destroys the scrap metal part object if ScrapMetal count reaches 2.
    /// </summary>
    public void Update()
    {
        if (GameManager.Instance.ScrapMetal == 2)
        {
            Destroy(gameObject);
        }
    }
}

