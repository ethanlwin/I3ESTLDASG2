using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Player Stats")]
    public float currentHealth;




    private void Start()
    {
        currentHealth = 100f;
    }

    public static GameManager Instance;
    /// <summary>
    /// virtual camera link
    /// </summary>
    public CinemachineVirtualCamera virtualCamera;





    public virtual void ShakeCamera(float shakeIntensity, float shakeFrequency)
    {
        CinemachineBasicMultiChannelPerlin cinemachineComponent = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineComponent.m_AmplitudeGain = shakeIntensity;
        cinemachineComponent.m_FrequencyGain = shakeFrequency;
    }
}
