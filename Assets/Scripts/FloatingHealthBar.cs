using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Slider slider;
    [SerializeField] private Camera camera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    private void Awake()
    {
        camera = Camera.main;
        if (camera != null )
        {
            Debug.Log("Cam Found");
        }
        else
        {
            Debug.Log("Cam Not Found");
        }
    }

    public void UpdateHealthBar(float currentHealth, float maxHealth )
    {
        slider.value = currentHealth/maxHealth;
    }
    
    void Update()
    {
        transform.rotation = camera.transform.rotation;
        transform.position = target.position + offset;
    }
}
