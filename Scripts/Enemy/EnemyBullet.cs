using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Rigidbody2D enemyBulletRb;
    private int damage;

    public void setDamage(int amount)
    {
        this.damage = amount;
    }

    private void Awake()
    {
        enemyBulletRb = GetComponent<Rigidbody2D>();
    }


    /*private void FixedUpdate()
    {
        Vector2 playerPos = new Vector2(PlayerStatus.Instance.transform.position.x, PlayerStatus.Instance.transform.position.y);
        Vector2 thisPos = new Vector2(this.transform.position.x, this.transform.position.y);
        Vector2 bulletDir = playerPos - thisPos;
        this.GetComponent<Rigidbody2D>().AddForce(bulletDir * 3f, ForceMode2D.Impulse);
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("enemy"))
        {
            //get damage from Enemy to take damage for player
            PlayerStatus.Instance.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
