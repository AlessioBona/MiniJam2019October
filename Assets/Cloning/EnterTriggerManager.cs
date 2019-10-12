using System;
using UnityEngine;

public class EnterTriggerManager : MonoBehaviour
{
    public event Action<Collider2D> onTriggerEnter;
    public event Action<Collider2D> onTriggerExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onTriggerEnter?.Invoke(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onTriggerExit?.Invoke(collision);
    }
}
