using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstract : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int damage;
    public int moveSpeed;
    public float fireRate;
    Rigidbody2D enemyRb;
1
    public virtual void Awake() 
    {
        currentHealth = maxHealth;   
        enemyRb = GetComponent<Rigidbody2D>();
    }

    public virtual void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("player"))
        {
            Destroy(this.gameObject);
        }    
    }

    public virtual void FixedUpdate() 
    {
        Move();    
    }

    public virtual void Move()
    {
        enemyRb.velocity = new Vector2(Mathf.PingPong(Time.time * moveSpeed, 3f) - 3f / 2, enemyRb.velocity.y);
    }
}
