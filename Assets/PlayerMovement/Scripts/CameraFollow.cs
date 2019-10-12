using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //the target transform component which the camera follows
    [SerializeField]
    private Transform target = null;

    [SerializeField]
    private Transform thisTransform;

    //the main camera component
    [SerializeField]
    private Camera cam = null;
    //camera movement:
    [SerializeField]
    private float mvtSmoothTime = 0.3f; //how smooth is the camera movement?
    private Vector3 mvtVelocity;

    private CloneList cloneList;

    private List<Transform> cloneTransforms = new List<Transform>();

    private float startZ;

    [SerializeField] private float[] zoomSteps;
    [SerializeField] private float[] distanceSteps;

    private float curDistance;

    private void Awake()
    {
        thisTransform = GetComponent<Transform>();
        startZ = thisTransform.position.z;
    }

    private void Start()
    {
        cloneList = CloneList.Instance;
    }

    [SerializeField] float distanceX;
    [SerializeField] float distanceY;
    private void FixedUpdate()
    {
        if (!cloneList)
        {
            return;
        }

        Vector3 centerPosition = Vector3.zero;

        float mostLeft = cloneList.CloneTransfromListX[0].position.x;
        float mostRight = cloneList.CloneTransfromListX[cloneList.CloneTransfromListX.Count - 1].position.x;

        //float mostTop = cloneList.CloneTransfromListY[0].position.y;
        //float mostBottom = cloneList.CloneTransfromListY[cloneList.CloneTransfromListX.Count - 1].position.y;

        distanceX = Mathf.Abs(mostLeft - mostRight);
        //distanceY = Mathf.Abs(mostTop - mostBottom);

        //curDistance = Mathf.Max(distanceX, distanceY);

        for (int i = 0; i < distanceSteps.Length; i++)
        {
            if (i == distanceSteps.Length - 2)
            {
                cam.orthographicSize = zoomSteps[i];
                break;
            }

            if (distanceX < distanceSteps[i + i])
            {
                cam.orthographicSize = zoomSteps[i];
                break;
            }

        }

        centerPosition.x = (mostLeft + mostRight) / 2;
        //centerPosition.y = (mostTop + mostBottom) / 2;

        centerPosition.z = startZ;

        Vector3 targetPosition = thisTransform.position;
        targetPosition = centerPosition; //the camera follows the target player on the x-axis only

        thisTransform.position = Vector3.SmoothDamp(
            thisTransform.position,
            targetPosition,
            ref mvtVelocity, mvtSmoothTime);
    }

    public void CalculateSize()
    {

    }
}
