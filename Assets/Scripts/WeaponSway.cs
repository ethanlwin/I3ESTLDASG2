/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: June 2024
 * Description: controls weapon sway based on mouse movement input
 */

using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [Header("Sway Settings")]
    /// <summary>
    /// smoothing factor for weapon sway
    /// </summary>
    [SerializeField] private float smooth;
    /// <summary>
    /// multiplier for mouse movement to affect sway
    /// </summary>
    [SerializeField] private float swayMultiplier;

    private void Update()
    {
        // Obtain mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * swayMultiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMultiplier;

        // Calculate the rotation of the target
        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(-mouseX, Vector3.up);

        Quaternion targetRotation = rotationX * rotationY;

        // Apply smooth rotation
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
    }
}

