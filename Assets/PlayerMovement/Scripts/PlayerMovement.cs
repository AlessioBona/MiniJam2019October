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

        playerVelocity = Input.GetAxis("Horizontal") * moveSpeed;
        moveVector = new Vector2(playerVelocity, 0.0f);

        this._rigidbody.velocity = moveVector;

        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.canJump)
        {
            this._rigidbody.velocity += new Vector2(0f, jumpForce);
            //groundCheck.canJump = false;
        }

        //check if there is contact with the platform

    


    }
    
}
