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
    public void UpdateStatus (bool open) { isOpen = open; }

    private float mvtVelocity;
    [SerializeField]
    private float mvtSmoothTime = 0.3f;

    private void FixedUpdate()
    {
        Vector3 currPosition = transform.position;
        currPosition.y = Mathf.SmoothDamp(currPosition.y, isOpen ? openHeight : closedHeight, ref mvtVelocity, mvtSmoothTime);
        transform.position = currPosition;
    }
}
