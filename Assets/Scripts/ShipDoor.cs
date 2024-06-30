using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDoor : MonoBehaviour
{
    [Header("References")]
    public Animator anim;
    public Entrance entrance;

    public void Update()
    {
        if(entrance.opening)
        {
            anim.SetBool("Interacted", true);
        }
        else
        {
            anim.SetBool("Interacted", false);
        }
    }

}
