using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyAbstract
{
    public GameObject enemyBullet;
    private GameObject player;
    [SerializeField] private Transform spawnPoint;

    public override void FixedUpdate()
    {
        Move();
        StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        yield return new WaitForSeconds(fireRate);
        Instantiate(enemyBullet, spawnPoint.position, Quaternion.identity);

        enemyBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));
    }
}
