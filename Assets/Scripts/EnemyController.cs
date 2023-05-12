using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    public float maxHealth = 3f;
    public float health;
    public float damage = 10f;
    public float attackRange = 10f;
    
    private Transform player;

    private float distanceThreshold = 0.1f;
    private int currentIndex = 0;
    private GameObject waypoints;
    
    private GameObject baseObject;    
    private void Start()
    {
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        baseObject = GameObject.FindGameObjectWithTag("Base");
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
                // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        // Move towards the base if the object has the "Enemy" tag
        if (gameObject.CompareTag("Enemy"))
        {
            Vector2 direction = (baseObject.transform.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }

        // Attack the player if within range and the object has the "Player" tag
        if (gameObject.CompareTag("Player") && distanceToPlayer <= attackRange)
        {
            AttackPlayer();
        }
    } 
    private void AttackPlayer()
    {
        // Inflict damage to the player
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }     
}
