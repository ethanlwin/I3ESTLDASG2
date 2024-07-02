/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: June 2024
 * Description: Represents a target that can take damage and be destroyed
 */

using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
    /// <summary>
    /// Maximum health of the target.
    /// </summary>
    [Header("Stats")]
    public float maxHealth;

    /// <summary>
    /// Reference to the floating health bar associated with this target.
    /// </summary>
    [Header("References")]
    [SerializeField] FloatingHealthBar healthBar;

    /// <summary>
    /// Current health of the target.
    /// </summary>
    [HideInInspector]
    public float health;

    private void Awake()
    {
        // Find the floating health bar component in children
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    private void Start()
    {
        // Initialize health to maximum health
        health = maxHealth;
    }

    /// <summary>
    /// Inflicts damage on the target and updates the health bar.
    /// </summary>
    /// <param name="damage">Amount of damage to inflict.</param>
    public void Damage(float damage)
    {
        health -= damage;
        healthBar.UpdateHealthBar(health, maxHealth); // Update the health bar UI
        Debug.Log("Damage"); // Log damage event (for debugging)

        // Destroy the target if health drops to or below zero
        if (health <= 0)
            Destroy(gameObject);
    }
}

