using System;
using UnityEngine;

public class Clone : MonoBehaviour
{
    [SerializeField] private Transform thisTransform;
    [SerializeField] private Rigidbody2D thisRigidbody2D;
    [SerializeField] private Collider2D collider2D;
    //[SerializeField] private GameObject thisGameObject;

    [SerializeField] private Clone clonePrefab;

    [SerializeField] private float spawnCloneCoolDown;

    private float curTime;
    private float nextSpawnCloneTime;

    private Clone curClone;

    [SerializeField] private int dnaCount;

    //public GameObject ThisGameObject { get => thisGameObject; set => thisGameObject = value; }

    [SerializeField] private EnterTriggerManager enterTriggerManager;
    [SerializeField] private int clonesInRadius;
    [SerializeField] private float cloneCheckRadius;

    [SerializeField] private bool isFirstPlayer;

    [SerializeField] private bool isDisabled;

    private void Awake()
    {
        dnaCount = 0;

        if (!isFirstPlayer)
        {
            isDisabled = true;

            thisRigidbody2D.bodyType = RigidbodyType2D.Static;
            collider2D.enabled = false;
        }
        else
        {
            isDisabled = false;

            thisRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            collider2D.enabled = true;
        }

        enterTriggerManager.onTriggerEnter += DoOnTriggerEnter;
        enterTriggerManager.onTriggerExit += DoOnTriggerExit;
    }

    private void OnEnable()
    {
        CloneList.Instance.AddClone(thisTransform);
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

                curClone.enabled = true;
            }
        }
    }

    public void ONDNACollection()
    {
        dnaCount++;
    }

    public void DoOnTriggerEnter(Collider2D collision)
    {
        Clone collisionClone = collision.GetComponent<Clone>();
        if (collisionClone)
        {
            clonesInRadius++;
        }
    }

    public void DoOnTriggerExit(Collider2D collision)
    {
        Clone collisionClone = collision.GetComponent<Clone>();
        if (collisionClone)
        {
            clonesInRadius--;

            if (clonesInRadius <= 0)
            {
                if (isDisabled)
                {
                    thisRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                    collider2D.enabled = true;
                    isDisabled = false;
                }
            }
        }
    }

    private void OnDisable()
    {
        CloneList.Instance.RemoveClone(thisTransform);
    }
}
