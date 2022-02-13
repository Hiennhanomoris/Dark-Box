using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float move_speed;
    [SerializeField] private float _force;
    private bool facingRinght;
    private bool _checkJump = true;

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
    }
}
