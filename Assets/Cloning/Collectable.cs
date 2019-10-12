using UnityEngine;

public class Collectable : MonoBehaviour, ICollectable
{
    [SerializeField] protected Transform thisTransform;
    [SerializeField] protected GameObject thisGameObject;

    public virtual void OnCollect(Clone _clone)
    {
        Destroy(thisGameObject);
    }
}
