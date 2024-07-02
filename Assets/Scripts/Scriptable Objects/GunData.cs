/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: June 2024
 * Description: Contains data for a gun, including its name, damage, shooting range, ammo capacity, fire rate, and reloading properties
 */

using UnityEngine;
public class GunData : ScriptableObject
{
    [Header("Info")]
    /// <summary>
    /// Name of the gun.
    /// </summary>
    public new string name;

    [Header("Shooting")]
    /// <summary>
    /// Amount of damage the gun can inflict.
    /// </summary>
    public float damage;
    /// <summary>
    /// Maximum distance bullets fired from this gun can travel.
    /// </summary>
    public float maxDistance;

    [Header("Reloading")]
    /// <summary>
    /// Maximum ammo capacity of the gun.
    /// </summary>
    public int maxAmmo;
    /// <summary>
    /// Current amount of ammo loaded in the gun.
    /// </summary>
    public int currentAmmo;
    /// <summary>
    /// Maximum ammo capacity the gun can hold in a magazine.
    /// </summary>
    public int magSize;
    /// <summary>
    /// Rate of fire of the gun (bullets per minute).
    /// </summary>
    public float fireRate;
    /// <summary>
    /// Time it takes for the gun to reload.
    /// </summary>
    public float reloadTime;
    /// <summary>
    /// Flag indicating if the gun is currently reloading.
    /// </summary>
    [HideInInspector]
    public bool reloading = false;
}

