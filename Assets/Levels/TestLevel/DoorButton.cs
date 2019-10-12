using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField]
    private Door door = null;

    [SerializeField]
    private AudioClip audioClip = null;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
            door.UpdateStatus(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
            GetComponent<AudioSource>().PlayOneShot(audioClip);
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
            door.UpdateStatus(false);
    }
}
