/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: June 2024
 * Description: this script will update the player when they have entered the crafting zone, and when they leave crafting zone with a triggerzone
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CraftingZone : MonoBehaviour
{
    /// <summary>
    /// Reference to the crafted sound audio clip.
    /// </summary>
    [Header("Audio Ref")]
    [SerializeField] AudioClip craftedSound;

    /// <summary>
    /// Indicates if the player is in the crafting zone.
    /// </summary>
    public bool InCraftingZone;

    /// <summary>
    /// Reference to the player object.
    /// </summary>
    public Player player;

    /// <summary>
    /// Called when the script instance is being loaded.
    /// </summary>
    public void Awake()
    {
        player = GameObject.Find("PlayerCapsule").GetComponent<Player>();
    }

    /// <summary>
    /// Plays the crafting sound and sets the engine status after a delay.
    /// </summary>
    /// <returns>An IEnumerator for coroutine handling.</returns>
    public IEnumerator Craft()
    {
        AudioSource.PlayClipAtPoint(craftedSound, transform.position);
        yield return new WaitForSeconds(3f);
        GameManager.Instance.HasEngine = true;
    }

    /// <summary>
    /// Initiates the crafting process if all engine parts are collected and the player is in the crafting zone.
    /// </summary>
    public void CraftEngine()
    {
        if (GameManager.Instance.AllEnginePartsCollected && InCraftingZone)
        {
            StartCoroutine(Craft());
            GameManager.Instance.engineTick.SetActive(true);
        }
    }

    /// <summary>
    /// Checks if the player has entered the trigger zone of the game object.
    /// </summary>
    /// <param name="other">The collider that entered the trigger zone.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Checks if it's the player in the trigger zone
        if (other.gameObject.tag == "Player")
        {
            // Update the player on which zone it is in front of
            Debug.Log("Entered");
            InCraftingZone = true;
            player.interactionTextZone.gameObject.SetActive(true);
            other.gameObject.GetComponent<Player>().UpdateCraftingZone(this);
        }
    }

    /// <summary>
    /// Checks if the player has exited the trigger zone of the game object.
    /// </summary>
    /// <param name="other">The collider that exited the trigger zone.</param>
    private void OnTriggerExit(Collider other)
    {
        // Checks if it's the player who exited the trigger zone
        if (other.gameObject.tag == "Player")
        {
            // Update the player that it has left the zone
            InCraftingZone = false;
            player.interactionTextZone.gameObject.SetActive(false);
            other.gameObject.GetComponent<Player>().UpdateCraftingZone(null);
        }
    }
}
