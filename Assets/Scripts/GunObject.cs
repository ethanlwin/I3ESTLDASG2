/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: June 2024
 * Description: Destroys the gun object based on the availability of primary or secondary weapons
 */

using UnityEngine;

public class GunObject : MonoBehaviour
{
    /// <summary>
    /// Reference to the weapon switching script.
    /// </summary>
    [SerializeField] WeaponSwitching weaponSwitch;

    /// <summary>
    /// Specifies the gun number.
    /// </summary>
    [Header("GunNumber")]
    public int GunNum;

    /// <summary>
    /// Checks for primary or secondary weapon availability and destroys the gun object accordingly.
    /// </summary>
    private void Update()
    {
        if (weaponSwitch.primaryWeaponFound && GunNum == 1)
        {
            Destroy(gameObject);
        }
        if (weaponSwitch.secondaryWeaponFound && GunNum == 2)
        {
            Destroy(gameObject);
        }
    }

}

