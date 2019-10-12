using UnityEngine;

public class CollectableCollector : MonoBehaviour
{
    [SerializeField] private EnterTriggerManager enterTriggerManager;

    [SerializeField] private Clone clone;

    [SerializeField] private AudioClip collectAudio;

    private void Awake()
    {
        enterTriggerManager.onTriggerEnter += DoOnTriggerEnter2D;
    }

    private void DoOnTriggerEnter2D(Collider2D collision)
    {
        Collectable collectable = collision.GetComponent<Collectable>();

        if (collectable)
        {
            collectable.OnCollect(clone);
            GetComponent<AudioSource>().PlayOneShot(collectAudio);
        }
    }
}