using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Player Stats")]
    public Player player;
    public float currentHealth;

    [Header("UI")]
    public TextMeshProUGUI healthText;

    [HideInInspector]
    public bool BossRoomKey;
    public bool CraftRoomKey;
    public bool AllEnginePartsCollected;
    public bool HasEngine;
    public bool HasEnergyCore;
    public bool HasFuel;
    public bool HasScrapMetal;

    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        currentHealth = player.maxHealth;
        Debug.Log(currentHealth);
        AllEnginePartsCollected = true;
    }
    private void Update()
    {
        healthText.text = $"{currentHealth.ToString()}/{player.maxHealth.ToString()}";
    }

}