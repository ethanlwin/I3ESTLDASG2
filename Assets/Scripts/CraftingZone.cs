using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingZone : MonoBehaviour
{
    [Header("Audio Ref")]
    [SerializeField] AudioClip craftedSound;

    //[HideInInspector]
    public bool InCraftingZone;
    public Player player;



    public void Awake()
    {
        player = GameObject.Find("PlayerCapsule").GetComponent<Player>();
    }
    public IEnumerator Craft()
    {
        AudioSource.PlayClipAtPoint(craftedSound, transform.position);
        yield return new WaitForSeconds(3f);
        GameManager.Instance.HasEngine = true;
    }
    public void CraftEngine()
    {
        if (GameManager.Instance.AllEnginePartsCollected && InCraftingZone)
        {
            Craft();
        }
    }

    /// <summary>
    /// checks if the player has enterd the triggerzone of the game object
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //checks if its the player in the triggerzone
        if (other.gameObject.tag == "Player")
        {

            // upodate the player on which zone it is infront of
            Debug.Log("Entered");
            InCraftingZone = true;
            player.interactionText.gameObject.SetActive(true);
            other.gameObject.GetComponent<Player>().UpdateCraftingZone(this);
        }
    }
    /// <summary>
    /// checks if the player has exited the triggerzone of the game object
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        //checks if its the player who exited the triggerzone
        if (other.gameObject.tag == "Player")
        {
            //update the player that it has left the zone 
            InCraftingZone = false;
            player.interactionText.gameObject.SetActive(false);
            other.gameObject.GetComponent<Player>().UpdateCraftingZone(null);
        }
    }
    public void Update()
    {
        
    }
}
