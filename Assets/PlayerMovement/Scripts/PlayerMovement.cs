using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 moveVector;
    [SerializeField] private float moveSpeed = 1;
    private float playerVelocity;

    [SerializeField] private float jumpForce;

    [SerializeField] private GroundCheck groundCheck;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //modify player's rigidbody velocity on the x-axis to move him right or left
        float velX = Input.GetAxis("Horizontal") * moveSpeed;
        this._rigidbody.velocity = new Vector2(velX, this._rigidbody.velocity.y);

        //check whether the player is on the ground and whether the jump key is pressed to update the player's velocity on the y-axis (= jump)
        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.canJump)
            this._rigidbody.velocity = new Vector2(this._rigidbody.velocity.x, jumpForce);
    }
}
