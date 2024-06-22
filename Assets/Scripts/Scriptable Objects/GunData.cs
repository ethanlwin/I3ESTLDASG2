using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Gun", menuName ="Weapon/Gun")]
public class GunData : ScriptableObject
{
    [Header("Info")]
    //name of the gun//
    public new string name;

    [Header("Shooting")]
    //amount of damage gun can do//
    public float damage;
    //how far the bullets can travel//
    public float maxDistance;

    [Header("Reloading")]
    //current amount of ammo in the gun//
    public int currentAmmo;
    //how much ammo the gun can hold//
    public int magSize;
    //how fast the gun can shoot//
    public float fireRate;
    //how long it takes for the gun to reload//
    public float reloadTime;
    //if the gun is reloading//
    [HideInInspector]
    public bool reloading = false;


}
