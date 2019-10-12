using System.Collections.Generic;
using UnityEngine;

public class CloneList : MonoBehaviour
{
    [SerializeField] public static CloneList Instance;

    [SerializeField] private List<Transform> cloneTransfromList = new List<Transform>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddClone(Transform _transform)
    {
        cloneTransfromList.Add(_transform);
    }

    public void RemoveClone(Transform _transform)
    {
        cloneTransfromList.Remove(_transform);
    }
}
