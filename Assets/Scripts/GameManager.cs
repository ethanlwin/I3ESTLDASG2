/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: June 2024
 * Description: Manages game state, player stats, UI elements, and game logic
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEngine.SceneManagement;
using StarterAssets;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Reference to the player's stats and configuration.
    /// </summary>
    [Header("Player Stats")]
    public Player player;

    /// <summary>
    /// Current health of the player.
    /// </summary>
    public float currentHealth;

    /// <summary>
    /// UI element displaying current player health.
    /// </summary>
    [Header("UI")]
    public TextMeshProUGUI healthText;

    /// <summary>
    /// UI element displaying the count of available medkits.
    /// </summary>
    public TextMeshProUGUI mKText;

    /// <summary>
    /// Game over screen object.
    /// </summary>
    public GameObject GOSCREEN;

    /// <summary>
    /// UI text for the city zone notification.
    /// </summary>
    public GameObject CityText;

    /// <summary>
    /// UI text for the outskirts zone notification.
    /// </summary>
    public GameObject OutskirtsText;

    /// <summary>
    /// UI element indicating engine part collected.
    /// </summary>
    public GameObject engineTick;

    /// <summary>
    /// UI element indicating energy core collected.
    /// </summary>
    public GameObject coreTick;

    /// <summary>
    /// UI element indicating scrap metal collected.
    /// </summary>
    public GameObject metalTick;

    /// <summary>
    /// UI element indicating fuel collected.
    /// </summary>
    public GameObject fuelTick;

    /// <summary>
    /// UI element indicating engine part collected.
    /// </summary>
    public GameObject enginePartTick;

    /// <summary>
    /// UI element indicating a locked door notification.
    /// </summary>
    public GameObject doorLocked;

    /// <summary>
    /// Audio source for player death sound effect.
    /// </summary>
    [Header("Audio")]
    [SerializeField] AudioSource playerDeath;

    /// <summary>
    /// Indicates if the boss room key is collected.
    /// </summary>
    [HideInInspector] public bool BossRoomKey;

    /// <summary>
    /// Indicates if the craft room key is collected.
    /// </summary>
    [HideInInspector] public bool CraftRoomKey;

    /// <summary>
    /// Indicates if all engine parts are collected.
    /// </summary>
    [HideInInspector] public bool AllEnginePartsCollected;

    /// <summary>
    /// Indicates if the engine part is collected.
    /// </summary>
    [HideInInspector] public bool HasEngine;

    /// <summary>
    /// Indicates if the energy core is collected.
    /// </summary>
    [HideInInspector] public bool HasEnergyCore;

    /// <summary>
    /// Indicates if the fuel is collected.
    /// </summary>
    [HideInInspector] public bool HasFuel;

    /// <summary>
    /// Count of scrap metal collected.
    /// </summary>
    [HideInInspector] public int ScrapMetal;

    /// <summary>
    /// Count of engine parts collected.
    /// </summary>
    [HideInInspector] public int EngineParts;

    /// <summary>
    /// Count of available medkits.
    /// </summary>
    [HideInInspector] public int MedKitCount;

    /// <summary>
    /// Indicates if scrap metal is placed in ship.
    /// </summary>
    [HideInInspector] public bool ScrapMetalPlaced;

    /// <summary>
    /// Indicates if engine part is placed in ship.
    /// </summary>
    [HideInInspector] public bool EnginePlaced;

    /// <summary>
    /// Indicates if energy core is placed in ship.
    /// </summary>
    [HideInInspector] public bool CorePlaced;

    /// <summary>
    /// Indicates if fuel is placed in ship.
    /// </summary>
    [HideInInspector] public bool FuelPlaced;

    /// <summary>
    /// Reference to the win screen object.
    /// </summary>
    [Header("References")]
    public GameObject winScreen;

    /// <summary>
    /// Singleton instance of GameManager.
    /// </summary>
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Persist GameManager across scenes.
        }
        else if (Instance != null && Instance != this)
        {
            Destroy(gameObject);            // Ensure only one instance of GameManager exists.
        }
    }

    private void Start()
    {
        currentHealth = player.maxHealth;   // Initialize current health to player's max health.
        winScreen.gameObject.SetActive(false);  // Deactivate win screen initially.
    }

    /// <summary>
    /// Updates UI elements and checks game conditions every frame.
    /// </summary>
    private void Update()
    {
        healthText.text = $"{currentHealth.ToString()}/{player.maxHealth.ToString()}";  // Update health UI text.
        mKText.text = $"Medkit: {MedKitCount.ToString()}";  // Update medkit UI text.

        if (EngineParts == 2)
        {
            AllEnginePartsCollected = true;  // Check if all engine parts are collected.
        }

        if (currentHealth <= 0)
        {
            // Activate game over screen and disable player controls on death.
            GOSCREEN.SetActive(true);
            playerDeath.Play();
            Cursor.lockState = CursorLockMode.None;
            GameManager.Instance.player.GetComponent<FirstPersonController>().enabled = false;
            GameManager.Instance.player.GetComponent<PlayerInput>().enabled = false;
        }
    }

    /// <summary>
    /// Uses a medkit to heal the player if medkits are available and player health is not full.
    /// </summary>
    public void UseMedkit()
    {
        if (MedKitCount > 0 && currentHealth < player.maxHealth)
        {
            currentHealth += 50f;  // Increase current health.
            MedKitCount -= 1;      // Decrease medkit count.
            if (currentHealth > player.maxHealth)
            {
                currentHealth = player.maxHealth;  // Cap health at max health.
            }
        }
    }
}