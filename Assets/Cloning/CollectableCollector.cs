using UnityEngine;

public class CollectableCollector : MonoBehaviour
{
    [SerializeField] private Clone clone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collectable collectable = collision.GetComponent<Collectable>();

        if (collectable)
        {
            collectable.OnCollect(clone);
        }
    }
}