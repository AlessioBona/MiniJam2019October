using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private float openHeight = 3.0f;
    [SerializeField]
    private float closedHeight = 0.0f;

    private bool isOpen = false;
    public void UpdateStatus (bool open) { isOpen = open;
        if (isOpen)
            GetComponent<AudioSource>().PlayOneShot(openAudio);
        else
            GetComponent<AudioSource>().PlayOneShot(closeAudio);
    }

    private float mvtVelocity;
    [SerializeField]
    private float mvtSmoothTime = 0.3f;

    [SerializeField]
    private AudioClip openAudio = null;
    [SerializeField]
    private AudioClip closeAudio = null;

    private void FixedUpdate()
    {
        Vector3 currPosition = transform.position;
        currPosition.y = Mathf.SmoothDamp(currPosition.y, isOpen ? openHeight : closedHeight, ref mvtVelocity, mvtSmoothTime);
        transform.position = currPosition;
    }
}
