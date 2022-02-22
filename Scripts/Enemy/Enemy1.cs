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
    [SerializeField] private float fireDistance;

    private void Start()
    {
        StartCoroutine(Fire());
    }

    // private void Update() 
    // {
    //     if(transform.position.x - fireDistance < player.transform.position.x && transform.position.x + fireDistance > player.transform.position.x)
    //         readyToFire = true;
    // }

    public IEnumerator Fire()
    {
        while(player.GetComponent<PlayerStatus>().getCurrentHealth() > 0)
        {
            //enemy will fire player when player in enemy's area
            if(transform.position.x - fireDistance < player.transform.position.x &&
                transform.position.x + fireDistance > player.transform.position.x)
            {
                var spawnedBullet = Instantiate(enemyBullet, spawnPoint.position, Quaternion.identity);

                //caculate direction for bullet
                Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
                Vector2 thisPos = new Vector2(this.transform.position.x, this.transform.position.y);
                Vector2 bulletDir = playerPos - thisPos;
                spawnedBullet.GetComponent<Rigidbody2D>().AddForce(bulletDir * bulletForce, ForceMode2D.Impulse);
            }

            //wait for 2s to next fires
            yield return new WaitForSeconds(fireRate);
        }
    }
}
