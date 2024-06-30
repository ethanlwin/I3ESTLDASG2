using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipParts : MonoBehaviour
{
    [Header("AudioRef")]
    [SerializeField] AudioClip collected;


    /// <summary>
    /// collected function which will destroy the game object and play the audio sound for collected
    /// </summary>
    public virtual void Collected()
    {
        AudioSource.PlayClipAtPoint(collected,transform.position);
        Destroy(gameObject);
    }
    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }
}
