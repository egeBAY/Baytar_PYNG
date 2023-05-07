using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    public float maxHealth = 3f;
    public float health;

    private float distanceThreshold = 0.1f;
    private int currentIndex = 0;
    private GameObject waypoints;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
