using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    public float maxHealth = 3f;
    public float health;

    
    private Transform player;

    private float distanceThreshold = 0.1f;
    private int currentIndex = 0;
    private GameObject waypoints;

    private void Start()
    {
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (player != null)
        {
            Vector2 direction = player.position - transform.position;
            direction.Normalize();

            transform.Translate(direction * speed * Time.deltaTime);
        }
    }    
}
