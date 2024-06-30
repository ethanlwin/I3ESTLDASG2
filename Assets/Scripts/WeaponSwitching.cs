using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    [Header("Weapons")]
    [SerializeField] GameObject primaryWeapon;
    [SerializeField] GameObject secondaryWeapon;

    [Header("UI")]
    public GameObject ammoPrimaryText;
    public GameObject ammoSecondaryText;
    public GameObject ammoIcon;

    [Header("Audio")]
    [SerializeField] private AudioClip switchSound;

    [HideInInspector]
    public bool primaryWeaponEQ;
    public bool secondaryWeaponEQ;
    public bool primaryWeaponFound;
    public bool secondaryWeaponFound;

    public void Start()
    {
        primaryWeapon.SetActive(false);
        secondaryWeapon.SetActive(false);
        ammoPrimaryText.SetActive(false);
        ammoSecondaryText.SetActive(false);
        ammoIcon.SetActive(false);
        primaryWeaponEQ = false;
        secondaryWeaponEQ = false;
    }
    public void Update()
    {
        if(primaryWeaponEQ || secondaryWeaponEQ)
        {
            ammoIcon.SetActive(true);
        }
    }

    void OnPrimary()
    {
        if (primaryWeaponFound && !primaryWeaponEQ)
        {
            primaryWeaponEQ = true;
            ammoPrimaryText.SetActive(true);
            primaryWeapon.SetActive(true);
            secondaryWeaponEQ = false;
            ammoSecondaryText.SetActive(false);
            secondaryWeapon.SetActive(false);
            AudioSource.PlayClipAtPoint(switchSound, transform.position, 0.5f);
        }
    }
    void OnSecondary()
    {
        if (secondaryWeaponFound && !secondaryWeaponEQ)
        {
            secondaryWeaponEQ = true;
            ammoSecondaryText.SetActive(true);
            secondaryWeapon.SetActive(true);
            primaryWeaponEQ = false;
            ammoPrimaryText.SetActive(false);
            primaryWeapon.SetActive(false);
            AudioSource.PlayClipAtPoint(switchSound, transform.position, 0.5f);
        }
    }

}
