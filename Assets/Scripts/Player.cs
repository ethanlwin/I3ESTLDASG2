/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: June 2024
 * Description: Controls player interactions, including detection of interactable objects and handling various game mechanics
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Player : MonoBehaviour
{
    /// <summary>
    /// Maximum health of the player.
    /// </summary>
    [Header("Player Stats")]
    public float maxHealth;

    /// <summary>
    /// Reference to the WeaponSwitching script.
    /// </summary>
    [Header("Scripts")]
    [SerializeField] WeaponSwitching weaponSwitch;

    /// <summary>
    /// Audio clip for when items are picked up.
    /// </summary>
    [Header("Audio")]
    [SerializeField] AudioClip pickup;

    /// <summary>
    /// Audio clip for door interactions.
    /// </summary>
    [SerializeField] AudioClip door;

    /// <summary>
    /// Audio clip for using a medkit.
    /// </summary>
    [SerializeField] AudioClip useMK;

    /// <summary>
    /// Reference to the player's camera transform.
    /// </summary>
    [Header("References")]
    [SerializeField] Transform playerCamera;

    /// <summary>
    /// Distance for interaction detection.
    /// </summary>
    [SerializeField] float interactionDistance;

    /// <summary>
    /// Text displayed for interactions.
    /// </summary>
    [SerializeField] public TextMeshProUGUI interactionText;

    /// <summary>
    /// Text displayed for interactions in crafting zones.
    /// </summary>
    [SerializeField] public TextMeshProUGUI interactionTextZone;

    /// <summary>
    /// Text displayed for non-door interactions.
    /// </summary>
    [SerializeField] TextMeshProUGUI NotADoorText;

    /// <summary>
    /// Animator for fade transitions.
    /// </summary>
    [SerializeField] Animator fadeTransitionAnim;

    [HideInInspector]
    Interactable currentInteractable;

    [HideInInspector]
    ShipPartsMetal currentPartMetal;

    [HideInInspector]
    ShipPartsEngineParts currentPartEngineParts;

    [HideInInspector]
    ShipPartsFuel currentPartFuel;

    [HideInInspector]
    ShipPartsCore currentPartCore;

    [HideInInspector]
    Key currentKey;

    [HideInInspector]
    Medkit currentMK;

    [HideInInspector]
    NotADoor currentNotADoor;

    [HideInInspector]
    Entrance currentEntrance;

    [HideInInspector]
    GunObject currentGunObject;

    [HideInInspector]
    CraftingZone currentCraftingZone;

    [HideInInspector]
    PlacebleObjects currentPlacebleObjects;

    [HideInInspector]
    Controller currentController;

    /// <summary>
    /// manages what the player is looking at, if it is a interactable or not
    /// </summary>
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
            { }
            else
            {
                currentPartMetal = null;
            }

            if (hitInfo.transform.TryGetComponent<ShipPartsEngineParts>(out currentPartEngineParts))
            { }
            else
            {
                currentPartEngineParts = null;
            }

            if (hitInfo.transform.TryGetComponent<ShipPartsFuel>(out currentPartFuel))
            { }
            else
            {
                currentPartFuel = null;
            }

            if (hitInfo.transform.TryGetComponent<ShipPartsCore>(out currentPartCore))
            { }
            else
            {
                currentPartCore = null;
            }

            if (hitInfo.transform.TryGetComponent<Key>(out currentKey))
            { }
            else
            {
                currentKey = null;
            }

            if (hitInfo.transform.TryGetComponent<Medkit>(out currentMK))
            { }
            else
            {
                currentMK = null;
            }

            if (hitInfo.transform.TryGetComponent<PlacebleObjects>(out currentPlacebleObjects))
            { }
            else
            {
                currentPlacebleObjects = null;
            }

            if (hitInfo.transform.TryGetComponent<Entrance>(out currentEntrance))
            { }
            else
            {
                currentEntrance = null;
            }

            if (hitInfo.transform.TryGetComponent<GunObject>(out currentGunObject))
            { }
            else
            {
                currentGunObject = null;
            }

            if (hitInfo.transform.TryGetComponent<Controller>(out currentController))
            { }
            else
            {
                currentController = null;
            }
        }
        else
        {
            interactionText.gameObject.SetActive(false);
            NotADoorText.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Coroutine for fade transition animation.
    /// </summary>
    public IEnumerator FadeTransition()
    {
        fadeTransitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1f);
        fadeTransitionAnim.SetTrigger("Start");
    }

    /// <summary>
    /// Coroutine for displaying locked door sequence.
    /// </summary>
    public IEnumerator doorLockedSeq()
    {
        GameManager.Instance.doorLocked.SetActive(true);
        yield return new WaitForSeconds(2f);
        GameManager.Instance.doorLocked.SetActive(false);
    }

    /// <summary>
    /// Handles interactions based on the currently detected interactable object.
    /// </summary>
    public void OnInteract()
    {
        if (currentPartMetal != null)
        {
            currentPartMetal.Collected();
            interactionText.gameObject.SetActive(false);
            if (GameManager.Instance.ScrapMetal == 2)
            {
                GameManager.Instance.metalTick.SetActive(true);
            }
        }

        if (currentPartEngineParts != null)
        {
            currentPartEngineParts.Collected();
            interactionText.gameObject.SetActive(false);
            if (GameManager.Instance.EngineParts == 2)
            {
                GameManager.Instance.enginePartTick.SetActive(true);
            }
        }

        if (currentPartFuel != null)
        {
            currentPartFuel.Collected();
            interactionText.gameObject.SetActive(false);
            GameManager.Instance.fuelTick.SetActive(true);
        }

        if (currentPartCore != null)
        {
            currentPartCore.Collected();
            interactionText.gameObject.SetActive(false);
            GameManager.Instance.coreTick.SetActive(true);
        }

        if (currentMK != null)
        {
            currentMK.Collected();
            interactionText.gameObject.SetActive(false);
        }

        if (currentKey != null)
        {
            currentKey.Collected();
            interactionText.gameObject.SetActive(false);
        }

        if (currentController != null)
        {
            currentController.ActivateController();
            interactionText.gameObject.SetActive(false);
        }

        if (currentPlacebleObjects != null)
        {
            if (GameManager.Instance.HasEngine && currentPlacebleObjects.Object == 0)
            {
                GameManager.Instance.EnginePlaced = true;
                currentPlacebleObjects.Placed();
            }
            else if (GameManager.Instance.HasEnergyCore && currentPlacebleObjects.Object == 1)
            {
                GameManager.Instance.CorePlaced = true;
                currentPlacebleObjects.Placed();
            }
            else if (GameManager.Instance.HasFuel && currentPlacebleObjects.Object == 2)
            {
                GameManager.Instance.FuelPlaced = true;
                currentPlacebleObjects.Placed();
            }
            else if (GameManager.Instance.ScrapMetal == 2 && currentPlacebleObjects.Object == 3)
            {
                GameManager.Instance.ScrapMetalPlaced = true;
                currentPlacebleObjects.Placed();
            }
        }

        if (currentEntrance != null)
        {
            if (currentEntrance.entranceNum == 7)
            {
                if (GameManager.Instance.BossRoomKey)
                {
                    AudioSource.PlayClipAtPoint(door, transform.position, 2f);
                    StartCoroutine(FadeTransition());
                    currentEntrance.MoveScene();
                }
                else
                {
                    StartCoroutine(doorLockedSeq());
                }
            }
            else
            {
                AudioSource.PlayClipAtPoint(door, transform.position, 2f);
                StartCoroutine(FadeTransition());
                currentEntrance.MoveScene();
            }
        }

        if (currentGunObject != null)
        {
            if (currentGunObject.GunNum == 1)
            {
                weaponSwitch.primaryWeaponFound = true;
                Debug.Log("PrimaryWeaponFound");
                AudioSource.PlayClipAtPoint(pickup, transform.position);
            }
            else
            {
                weaponSwitch.secondaryWeaponFound = true;
                Debug.Log("SecondaryWeaponFound");
                AudioSource.PlayClipAtPoint(pickup, transform.position);
            }
        }

        if (currentCraftingZone != null)
        {
            currentCraftingZone.CraftEngine();
            Debug.Log(currentCraftingZone);
        }
    }

    /// <summary>
    /// Handles using a medkit and plays the appropriate audio.
    /// </summary>
    public void OnHeal()
    {
        GameManager.Instance.UseMedkit();
        if (GameManager.Instance.MedKitCount > 0)
        {
            AudioSource.PlayClipAtPoint(useMK, transform.position);
        }
    }

    /// <summary>
    /// Updates the current crafting zone reference.
    /// </summary>
    public void UpdateCraftingZone(CraftingZone newCraftingZone)
    {
        currentCraftingZone = newCraftingZone;
    }
}