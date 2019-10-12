using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private float openHeight = 3.0f;
    [SerializeField]
    private float cloesdHeight = 0.0f;

    private void FixedUpdate()
    {
        Vector3 currPosition = transform.position;
        currPosition.y = Mathf.Lerp(closedHeight, openHeight, )
    }
}
