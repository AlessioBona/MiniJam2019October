using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //the target transform component which the camera follows
    [SerializeField]
    private Transform target = null;

    //the main camera component
    [SerializeField]
    private Camera cam = null;
    //camera movement:
    [SerializeField]
    private float mvtSmoothTime = 0.3f; //how smooth is the camera movement?
    private Vector3 mvtVelocity; 

    private void FixedUpdate()
    {
        Vector3 targetPosition = cam.transform.position;
        targetPosition.x = target.position.x; //the camera follows the target player on the x-axis only

        cam.transform.position = Vector3.SmoothDamp(
            cam.transform.position,
            targetPosition,
            ref mvtVelocity, mvtSmoothTime);
    }
}
