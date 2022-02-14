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
}
