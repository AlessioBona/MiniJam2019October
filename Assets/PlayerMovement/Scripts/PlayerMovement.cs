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
    private float velX;

    [SerializeField] private float jumpForce;
    public void UpdateJumpForce (float value) { jumpForce += value; }

    private int inversionValue = 1;
    public void Invert() { inversionValue *= -1; }

    [SerializeField] private GroundCheck groundCheck;

    private CloneState state;

    //audio effects:
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip jumpAudio = null;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        state = CloneState.active;
    }

    void Update()
    {
        switch (state)
        {
            case CloneState.active:

                //modify player's rigidbody velocity on the x-axis to move him right or left
                velX = Input.GetAxis("Horizontal") * moveSpeed * inversionValue;

                //check whether the player is on the ground and whether the jump key is pressed to update the player's velocity on the y-axis (= jump)
                if (Input.GetKeyDown(KeyCode.Space) && groundCheck.canJump)
                {
                    this._rigidbody.velocity = new Vector2(this._rigidbody.velocity.x, jumpForce);
                    audioSource.PlayOneShot(jumpAudio);
                }
                    

                break;
        }
    }

    private void FixedUpdate()
    {
        this._rigidbody.velocity = new Vector2(velX, this._rigidbody.velocity.y);
        
    }

    public void UpdateState (CloneState newState)
    {
        state = newState;

        switch(state)
        {
            case CloneState.dead:
                velX = 0.0f;
                GetComponent<Clone>().enabled = false;
                GetComponent<ItemCollector>().enabled = false;
                enabled = false;
                break;
        }
    }
}
