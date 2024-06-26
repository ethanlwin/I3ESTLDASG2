using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GunData gunData;
    [SerializeField] private Transform cam;
    [SerializeField] float shakeIntensity;
    [SerializeField] float shakeFrequency;
    [SerializeField] float shakeTimer;


    [Header("Audio")]
    [SerializeField] private AudioClip shot;
    [SerializeField] private AudioClip reload;
    [SerializeField] private AudioClip emptyShot;

    [Header("UI")]
    public TextMeshProUGUI ammoText;
    float timeSinceLastShot;

    [HideInInspector]
    private float shakeTimerStart;

    //public GameObject muzzleFlash;
    public Transform muzzle;
    public ParticleSystem muzzleFlash;

    private void Start()
    {
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReload;
    }
    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        Debug.DrawRay(cam.position, cam.forward);

        ammoText.text = $"{gunData.currentAmmo.ToString()}/{gunData.maxAmmo.ToString()}";

        if(shakeTimerStart > 0)
        {
            shakeTimerStart -= Time.deltaTime;
            if(shakeTimerStart <= 0f)
            {
                GameManager.Instance.ShakeCamera(0f, 0f);
            }
        }
    }

    private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);

    private void OnGunShot()
    {
        muzzleFlash.Play();
        //GameObject Flash = Instantiate(muzzleFlash, muzzle);
        //Destroy(Flash, 0.1f);
        AudioSource.PlayClipAtPoint(shot, muzzle.position, 1f);

        GameManager.Instance.ShakeCamera(shakeIntensity, shakeFrequency);
    }


    private void OnDisable()
    {
       gunData.reloading = false;
    }
   
    /// <summary>
    /// to reload the gun
    /// </summary>
    public void StartReload()
    {
        if (!gunData.reloading && this.gameObject.activeSelf)
        {
            StartCoroutine(Reload());
            AudioSource.PlayClipAtPoint(reload, transform.position, 1.5f);
        }
    }

    private IEnumerator Reload()
    {
        gunData.reloading = true;

        yield return new WaitForSeconds(gunData.reloadTime);

        gunData.currentAmmo = gunData.magSize;

        gunData.reloading = false;
    }
    public void Shoot()
    {
        if (gunData.currentAmmo > 0)
        {
            if (CanShoot())
            {
                if (Physics.Raycast(cam.position, transform.forward, out RaycastHit hitInfo, gunData.maxDistance))
                {
                    Debug.Log("Shoot");
                    Debug.Log(hitInfo.transform.name);
                    IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                    damageable?.Damage(gunData.damage);
                }

                gunData.currentAmmo--;
                timeSinceLastShot = 0;
                OnGunShot();
            }

        }
        else
        {
            if(CanShoot())
            {
                AudioSource.PlayClipAtPoint(emptyShot, muzzle.position, 1f);
                timeSinceLastShot = 0;
            }
        }
    }

}
