using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float move_speed;
    [SerializeField] private float force;
    private bool facingRinght;
    private bool checkJump = true;

    Rigidbody2D player_rb;

    private void Awake() 
    {
        player_rb = GetComponent<Rigidbody2D>();    
        facingRinght = true;
    }

    private void FixedUpdate() 
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontal, 0);
        player_rb.velocity = movement * move_speed;

        if((facingRinght == false && horizontal > 0) || (facingRinght == true && horizontal < 0))
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRinght = !facingRinght;
        Vector3 scaler = this.transform.localScale;
        scaler.x *= -1;
        this.transform.localScale = scaler;
    }
}
