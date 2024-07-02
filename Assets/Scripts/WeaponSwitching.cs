/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: June 2024
 * Description: Manages switching between primary and secondary weapons, including UI and audio feedback
 */

using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    /// <summary>
    /// Reference to the primary weapon GameObject.
    /// </summary>
    [Header("Weapons")]
    [SerializeField] GameObject primaryWeapon;

    /// <summary>
    /// Reference to the secondary weapon GameObject.
    /// </summary>
    [SerializeField] GameObject secondaryWeapon;

    /// <summary>
    /// Reference to the UI element displaying primary weapon ammo.
    /// </summary>
    [Header("UI")]
    public GameObject ammoPrimaryText;

    /// <summary>
    /// Reference to the UI element displaying secondary weapon ammo.
    /// </summary>
    public GameObject ammoSecondaryText;

    /// <summary>
    /// Reference to the UI element displaying the ammo icon.
    /// </summary>
    public GameObject ammoIcon;

    /// <summary>
    /// Sound clip for weapon switching.
    /// </summary>
    [Header("Audio")]
    [SerializeField] private AudioClip switchSound;

    /// <summary>
    /// Flag indicating if the primary weapon is equipped.
    /// </summary>
    [HideInInspector] public bool primaryWeaponEQ;

    /// <summary>
    /// Flag indicating if the secondary weapon is equipped.
    /// </summary>
    public bool secondaryWeaponEQ;

    /// <summary>
    /// Flag indicating if the primary weapon is available.
    /// </summary>
    public bool primaryWeaponFound;

    /// <summary>
    /// Flag indicating if the secondary weapon is available.
    /// </summary>
    public bool secondaryWeaponFound;

    /// <summary>
    /// Initializes weapon states and UI elements.
    /// </summary>
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

    /// <summary>
    /// Updates the UI to show the ammo icon when a weapon is equipped.
    /// </summary>
    public void Update()
    {
        if (primaryWeaponEQ || secondaryWeaponEQ)
        {
            ammoIcon.SetActive(true);
        }
    }

    /// <summary>
    /// Switches to the primary weapon if available and not already equipped.
    /// </summary>
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

    /// <summary>
    /// Switches to the secondary weapon if available and not already equipped.
    /// </summary>
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

