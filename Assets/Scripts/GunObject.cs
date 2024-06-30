using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunObject : MonoBehaviour
{
    [SerializeField] WeaponSwitching weaponSwitch;

    [Header("GunNumber")]
    public int GunNum;

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
