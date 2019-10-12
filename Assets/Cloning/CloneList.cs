using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CloneList : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager = null;
    [SerializeField] public static CloneList Instance;

    [SerializeField] private List<Transform> cloneTransfromListX = new List<Transform>();
    //[SerializeField] private List<Transform> cloneTransfromListY = new List<Transform>();

    public List<Transform> CloneTransfromListX { get => cloneTransfromListX; set => cloneTransfromListX = value; }
    //public List<Transform> CloneTransfromListY { get => cloneTransfromListY; set => cloneTransfromListY = value; }

    private void Awake()
    {
        Instance = this;
    }

    public void AddClone(Transform _transform)
    {
        CloneTransfromListX.Add(_transform);
        //CloneTransfromListY.Add(_transform);

        SortedList();
    }

    public void RemoveClone(Transform _transform)
    {
        CloneTransfromListX.Remove(_transform);
        //CloneTransfromListY.Remove(_transform);

        SortedList();

        if (CloneTransfromListX.Count == 0) //no more clones in scene, reload
            levelManager.ReloadLevel();
    }

    private void SortedList()
    {
        cloneTransfromListX.OrderBy(x => x.position.x);
        //cloneTransfromListY.OrderBy(x => x.position.y);
    }
}
