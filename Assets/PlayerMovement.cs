using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 moveVector;
    [SerializeField] private float moveSpeed;
    private float playerVelocity;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {

        playerVelocity = Input.GetAxis("Horizontal") * moveSpeed;
        moveVector = new Vector2(playerVelocity, 0.0f);

        this._rigidbody.velocity = moveVector;


    }
}
