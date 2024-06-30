using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Player : MonoBehaviour
{


    [Header("Player Stats")]
    public float maxHealth;

    [Header("Scripts")]
    [SerializeField] WeaponSwitching weaponSwitch;

    [Header("References")]
    [SerializeField] Transform playerCamera;
    [SerializeField] float interactionDistance;
    [SerializeField] public TextMeshProUGUI interactionText;
    [SerializeField] TextMeshProUGUI NotADoorText;
    [SerializeField] Animator fadeTransitionAnim;

    [HideInInspector]
    Interactable currentInteractable;
    ShipPartsMetal currentPartMetal;
    NotADoor currentNotADoor;
    Entrance currentEntrance;
    GunObject currentGunObject;
    CraftingZone currentCraftingZone;


    private void Start()
    {

    }
    private void Update()
    {


        RaycastHit hitInfo;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hitInfo, interactionDistance))
        {
            if (hitInfo.transform.TryGetComponent<Interactable>(out currentInteractable))
            {
                interactionText.gameObject.SetActive(true);
            }
            else
            {
                interactionText.gameObject.SetActive(false);
                currentInteractable = null;
            }
            if (hitInfo.transform.TryGetComponent<NotADoor>(out currentNotADoor))
            {
                NotADoorText.gameObject.SetActive(true);
            }
            else
            {
                NotADoorText.gameObject.SetActive(false);
                currentNotADoor = null;
            }

            if (hitInfo.transform.TryGetComponent<ShipPartsMetal>(out currentPartMetal))
            {}
            else
            {
                currentPartMetal = null;
            }
            if (hitInfo.transform.TryGetComponent<Entrance>(out currentEntrance))
            {}
            else
            {
                currentEntrance = null;
            }
            if (hitInfo.transform.TryGetComponent<GunObject>(out currentGunObject))
            {}
            else
            {
                currentGunObject = null;
            }
        }
        else
        {
            interactionText.gameObject.SetActive(false);
            NotADoorText.gameObject.SetActive(false);
        }
    }

    public IEnumerator FadeTransition()
    {
        fadeTransitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1f);
        fadeTransitionAnim.SetTrigger("Start");
    }
    public void OnInteract()
    {
        if(currentPartMetal != null)
        {
            currentPartMetal.Collected();
            interactionText.gameObject.SetActive(false);
        }
        if(currentEntrance != null)
        {
            StartCoroutine(FadeTransition());
            currentEntrance.MoveScene();
        }
        if(currentGunObject != null)
        {
            if(currentGunObject.GunNum == 1)
            {
                weaponSwitch.primaryWeaponFound = true;
                Debug.Log("PrimaryWeaponFound");
            }
            else
            {
                weaponSwitch.secondaryWeaponFound = true;
                Debug.Log("SecondaryWeaponFound");
            }
        }
        if(currentCraftingZone != null)
        {
            currentCraftingZone.CraftEngine();
        }
    }
    public void UpdateCraftingZone(CraftingZone newCraftingZone)
    {
        currentCraftingZone = newCraftingZone;
    }
}
