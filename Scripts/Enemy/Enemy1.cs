using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyAbstract
{
    public GameObject enemyBullet;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float bulletForce;
    [SerializeField] private float fireDistance;
    private bool readyToFire;

    private void Start()
    {
        StartCoroutine(Fire());
        readyToFire = false;
    }

    private void Update() 
    {
        if(transform.position.x - fireDistance < PlayerStatus.Instance.transform.position.x && 
            transform.position.x + fireDistance > PlayerStatus.Instance.transform.position.x)
            readyToFire = true;
    }

    public IEnumerator Fire()
    {
        while(PlayerStatus.Instance.getCurrentHealth() > 0)
        {
            //enemy will fire player when player in enemy's area
            if(readyToFire)
            {
                //spawn the bullet
                var spawnedBullet = Instantiate(enemyBullet, spawnPoint.position, Quaternion.identity);

                spawnedBullet.GetComponent<EnemyBullet>().setDamage(damage);

                //caculate direction for bullet
                Vector2 playerPos = new Vector2(PlayerStatus.Instance.transform.position.x, PlayerStatus.Instance.transform.position.y);
                Vector2 thisPos = new Vector2(this.transform.position.x, this.transform.position.y);
                Vector2 bulletDir = playerPos - thisPos;
                spawnedBullet.GetComponent<Rigidbody2D>().AddForce(bulletDir * bulletForce, ForceMode2D.Impulse);
                
                readyToFire = false;
            }

            //wait for 2s to next fires
            yield return new WaitForSeconds(fireRate);
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        //hit the player
        if(other.CompareTag("player"))
        {
            PlayerStatus.Instance.TakeDamage(damage);
        }
    }
}
