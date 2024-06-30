using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
    [Header("Stats")]
    public float maxHealth;

    [Header("References")]
    [SerializeField] FloatingHealthBar healthBar;

    [HideInInspector]
    public float health;

    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    public void Start()
    {
        health = maxHealth;
    }
    public void Damage(float damage)
    {
        health -= damage;
        healthBar.UpdateHealthBar(health, maxHealth);
        Debug.Log("Damage");
        if (health <= 0)
            Destroy(gameObject);
    }
}
 