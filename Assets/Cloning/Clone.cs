using System;
using UnityEngine;

public class Clone : MonoBehaviour
{
    [SerializeField] private Transform thisTransform;
    [SerializeField] private GameObject thisGameObject;

    [SerializeField] private Clone clonePrefab;

    [SerializeField] private float spawnCloneCoolDown;

    private float curTime;
    private float nextSpawnCloneTime;

    private Clone curClone;

    [SerializeField] private int dnaCount;

    public GameObject ThisGameObject { get => thisGameObject; set => thisGameObject = value; }

    private void Awake()
    {
        dnaCount = 0;
    }

    private void Update()
    {
        CheckButtonInput();
    }

    private void CheckButtonInput()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SpawnClone();
        }
    }

    private void SpawnClone()
    {
        if (dnaCount > 0)
        {
            curTime = Time.time;

            if (curTime > nextSpawnCloneTime)
            {
                nextSpawnCloneTime = curTime + spawnCloneCoolDown;

                dnaCount--;

                curClone = Instantiate(clonePrefab, thisTransform.position, thisTransform.rotation, null);

                curClone.ThisGameObject.SetActive(false);
            }
        }
    }

    public void ONDNACollection()
    {
        dnaCount++;
    }
}
