using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI healthText;


    [Header("Player Stats")]
    public float maxHealth;

    [Header("Scripts")]
    GameManager GM;

    private void Start()
    {
        Debug.Log(GM.currentHealth);
        //health bar setup
        healthText.text = $"{GM.currentHealth.ToString()}/{maxHealth.ToString()}";
    }
    private void Update()
    {
        healthText.text = $"{GM.currentHealth.ToString()}/{maxHealth.ToString()}";
    }
}
