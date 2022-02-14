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

    private void Awake() 
    {
        currentHealth = maxHealth;   
        enemyRb = GetComponent<Rigidbody2D>(); 
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("player"))
        {
            Destroy(this.gameObject);
        }    
    }
}
