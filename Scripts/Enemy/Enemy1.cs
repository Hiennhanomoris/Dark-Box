using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyAbstract
{
    public GameObject enemyBullet;
    [SerializeField] private Transform spawnPoint;
    public GameObject player;
    [SerializeField] private float bulletForce;

    private void Start()
    {
        StartCoroutine(Fire());
    }

    public IEnumerator Fire()
    {
        while(player.GetComponent<PlayerStatus>().getCurrentHealth() > 0)
        {
            Instantiate(enemyBullet, spawnPoint.position, Quaternion.identity);

            //caculate direction for bullet
            Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
            Vector2 thisPos = new Vector2(this.transform.position.x, this.transform.position.y);
            Vector2 bulletDir = playerPos - thisPos;
            enemyBullet.GetComponent<Rigidbody2D>().AddForce(bulletDir * bulletForce, ForceMode2D.Impulse);

            //wait for 2s to next fire
            yield return new WaitForSeconds(fireRate);
        }
    }
}
