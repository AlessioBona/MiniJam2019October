using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField]
    private Door door = null;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
            door.UpdateStatus(true);
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
            door.UpdateStatus(false);
    }
}
