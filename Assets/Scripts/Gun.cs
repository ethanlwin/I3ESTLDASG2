/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: June 2024
 * Description: Controls the behavior of a gun, including shooting, reloading, and UI updates
 */

using System.Collections;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    /// <summary>
    /// Reference to the gun's data settings.
    /// </summary>
    [Header("References")]
    [SerializeField] private GunData gunData;

    /// <summary>
    /// Reference to the camera transform for raycasting.
    /// </summary>
    [SerializeField] private Transform cam;

    /// <summary>
    /// Intensity of camera shake when shooting.
    /// </summary>
    [SerializeField] float shakeIntensity;

    /// <summary>
    /// Frequency of camera shake when shooting.
    /// </summary>
    [SerializeField] float shakeFrequency;

    /// <summary>
    /// Timer for camera shake effect.
    /// </summary>
    [SerializeField] float shakeTimer;

    /// <summary>
    /// Audio clip for shooting sound.
    /// </summary>
    [Header("Audio")]
    [SerializeField] private AudioClip shot;

    /// <summary>
    /// Audio clip for reload sound.
    /// </summary>
    [SerializeField] private AudioClip reload;

    /// <summary>
    /// Audio clip for empty shot sound.
    /// </summary>
    [SerializeField] private AudioClip emptyShot;

    /// <summary>
    /// UI text for displaying ammo count.
    /// </summary>
    [Header("UI")]
    public TextMeshProUGUI ammoText;

    /// <summary>
    /// Time since the last shot was fired.
    /// </summary>
    float timeSinceLastShot;

    [HideInInspector]
    private float shakeTimerStart;

    /// <summary>
    /// Muzzle transform for spawning muzzle flash.
    /// </summary>
    public Transform muzzle;

    /// <summary>
    /// Particle system for muzzle flash effect.
    /// </summary>
    public ParticleSystem muzzleFlash;

    /// <summary>
    /// Initializes the gun's current ammo and subscribes to shoot and reload events.
    /// </summary>
    private void Start()
    {
        gunData.currentAmmo = gunData.maxAmmo;
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReload;
    }

    /// <summary>
    /// Updates the time since the last shot and displays ammo count.
    /// </summary>
    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        // Draw a debug ray from the camera to visualize shooting direction.
        Debug.DrawRay(cam.position, cam.forward);

        // Update the UI ammo text.
        ammoText.text = $"{gunData.currentAmmo.ToString()}/{gunData.maxAmmo.ToString()}";
    }

    /// <summary>
    /// Checks if the gun can shoot based on current conditions.
    /// </summary>
    /// <returns>True if the gun can shoot, false otherwise.</returns>
    private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f) && (this.gameObject.activeSelf);

    /// <summary>
    /// Plays effects when the gun is shot, including muzzle flash and sound.
    /// </summary>
    private void OnGunShot()
    {
        muzzleFlash.Play();
        AudioSource.PlayClipAtPoint(shot, muzzle.position, 1f);
    }

    /// <summary>
    /// Disables the reloading flag when the gun is disabled.
    /// </summary>
    private void OnDisable()
    {
        gunData.reloading = false;
    }

    /// <summary>
    /// Initiates the reload process for the gun.
    /// </summary>
    /// <remarks>
    /// Starts the reload coroutine and plays reload audio.
    /// </remarks>
    public void StartReload()
    {
        if (!gunData.reloading && this.gameObject.activeSelf)
        {
            StartCoroutine(Reload());
            AudioSource.PlayClipAtPoint(reload, transform.position, 1.5f);
        }
    }

    /// <summary>
    /// Coroutine for reloading the gun.
    /// </summary>
    /// <returns>An IEnumerator for coroutine handling.</returns>
    private IEnumerator Reload()
    {
        gunData.reloading = true;

        yield return new WaitForSeconds(gunData.reloadTime);

        gunData.currentAmmo = gunData.magSize;

        gunData.reloading = false;
    }

    /// <summary>
    /// Handles the shooting mechanics of the gun, including raycasting for damage and effects.
    /// </summary>
    public void Shoot()
    {
        if (gunData.currentAmmo > 0)
        {
            if (CanShoot())
            {
                if (Physics.Raycast(cam.position, transform.forward, out RaycastHit hitInfo, gunData.maxDistance))
                {
                    IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                    damageable?.Damage(gunData.damage); // Damage the hit object if it's damageable.
                }

                gunData.currentAmmo--;
                timeSinceLastShot = 0;
                OnGunShot();
            }

        }
        else
        {
            if (CanShoot())
            {
                AudioSource.PlayClipAtPoint(emptyShot, muzzle.position, 1f);
                timeSinceLastShot = 0;
            }
        }
    }

}

