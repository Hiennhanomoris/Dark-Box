using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool facingRinght;
    private bool isOnGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float checkRadius;
    public PlayerSO playerStatus;

    Rigidbody2D player_rb;

    private void Awake() 
    {
        player_rb = GetComponent<Rigidbody2D>();    
        facingRinght = true;

        playerStatus.currentHealth = playerStatus.maxHealth;
        playerStatus.currentJump = playerStatus.extraJump;
    }

    private void FixedUpdate() 
    {
        HandleMovement();
        CheckOnGround();
    }

    private void Update() 
    {
        HandleJumping();
    }

    private void HandleJumping()
    {
        if(isOnGround == true)
        {
            //reset current jump when player stand on the ground
            playerStatus.currentJump = playerStatus.extraJump;
        }

        //player jumping when press key
        if(Input.GetKeyDown(KeyCode.Space) && playerStatus.currentJump > 0)
        {
            player_rb.velocity = Vector2.up * playerStatus.jumpForce;
            playerStatus.currentJump -= 1;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && playerStatus.currentJump > 0 && isOnGround)
        {
            player_rb.velocity = Vector2.up * playerStatus.jumpForce;
        }
    }

    private void CheckOnGround()
    {
        isOnGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    private void HandleMovement()
    {
        //move player 
        float horizontal = Input.GetAxis("Horizontal");
        player_rb.velocity = new Vector2(horizontal * playerStatus.moveSpeed, player_rb.velocity.y);

        if((facingRinght == false && horizontal > 0) || (facingRinght == true && horizontal < 0))
        {
            Flip();
        }
    }

    private void Flip()
    {
        //change direction of this object
        facingRinght = !facingRinght;
        Vector3 scaler = this.transform.localScale;
        scaler.x *= -1;
        this.transform.localScale = scaler;
    }
}
