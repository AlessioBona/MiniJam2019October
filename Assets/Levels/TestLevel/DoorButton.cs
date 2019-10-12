using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField]
    private Door door = null;

    private void OnTriggerEnter2D (Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>())

    }
}
