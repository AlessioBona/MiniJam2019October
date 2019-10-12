using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CloneState { dead, active, frozen}

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 moveVector;
    [SerializeField] private float moveSpeed = 1;
    public void UpdateSpeed (float value) { moveSpeed += value; }
    private float playerVelocity;

    [SerializeField] private float jumpForce;
    public void UpdateJumpForce (float value) { jumpForce += value; }

    private int inversionValue = 1;
    public void Invert() { inversionValue *= -1; }

    [SerializeField] private GroundCheck groundCheck;

    private CloneState state;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        state = CloneState.active;
    }

    void Update()
    {
        switch (state)
        {
            case CloneState.active:

                //modify player's rigidbody velocity on the x-axis to move him right or left
                float velX = Input.GetAxis("Horizontal") * moveSpeed * inversionValue;
                this._rigidbody.velocity = new Vector2(velX, this._rigidbody.velocity.y);

                //check whether the player is on the ground and whether the jump key is pressed to update the player's velocity on the y-axis (= jump)
                if (Input.GetKeyDown(KeyCode.Space) && groundCheck.canJump)
                    this._rigidbody.velocity = new Vector2(this._rigidbody.velocity.x, jumpForce);

                break;
        }
    }

    public void UpdateState (CloneState newState)
    {
        state = newState;

        switch(state)
        {
            case CloneState.dead:
                _rigidbody.velocity = Vector2.zero;
                break;
        }
    }
}
