/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: June 2024
 * Description: this script will update the player when they have entered the city, and when they leave the city based on a triggerzone
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CityZone : MonoBehaviour
{
    /// <summary>
    /// displays the city zone notification for 3 seconds.
    /// </summary>
    /// <returns>An IEnumerator for coroutine handling.</returns>
    public IEnumerator CityShow()
    {
        GameManager.Instance.CityText.SetActive(true);
        yield return new WaitForSeconds(3f);
        GameManager.Instance.CityText.SetActive(false);
    }

    /// <summary>
    /// displays the outskirts zone notification for 3 seconds.
    /// </summary>
    /// <returns>An IEnumerator for coroutine handling.</returns>
    public IEnumerator OutskirtsShow()
    {
        GameManager.Instance.OutskirtsText.SetActive(true);
        yield return new WaitForSeconds(3f);
        GameManager.Instance.OutskirtsText.SetActive(false);
    }

    /// <summary>
    /// triggered when an object enters the triggerzone.
    /// </summary>
    /// <param name="other">The collider that entered the trigger zone.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Checks if it's the player in the trigger zone
        if (other.gameObject.tag == "Player")
        {
            // Start displaying the city zone notification
            StartCoroutine(CityShow());
        }
    }

    /// <summary>
    /// triggered when an object exits the triggerzone.
    /// </summary>
    /// <param name="other">The collider that exited the trigger zone.</param>
    private void OnTriggerExit(Collider other)
    {
        // Checks if it's the player in the trigger zone
        if (other.gameObject.tag == "Player")
        {
            // Start displaying the outskirts zone notification
            StartCoroutine(OutskirtsShow());
        }
    }
}
