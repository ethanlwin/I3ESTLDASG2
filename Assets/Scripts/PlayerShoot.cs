using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public static Action shootInput;
    public static Action reloadInput;

    [SerializeField] private KeyCode reloadKey;

    private void Update()
    {
        //if(Input.GetMouseButton(0))
        {
            //shootInput?.Invoke();
        }
        //if(Input.GetKeyDown(reloadKey))
        {
            //reloadInput?.Invoke();
        }
    }
    void OnReload()
    {
        reloadInput?.Invoke();
    }
    void OnShoot(InputValue value)
    {
        if(value.isPressed)
        {
            shootInput?.Invoke();
        }
    }

}
