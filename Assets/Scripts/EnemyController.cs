using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    public float maxHealth = 3f;
    public float currentHealth;
    public float damage = 10f;

    [SerializeField] private float attackRange = 0.8f;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private float chaseRange = 3f;
    private float passedTimeFromLastAttack = 1f;

    private GameObject player;
    private PlayerHealth playerHealth;

    private float distanceThreshold = 0.1f;
    private int currentIndex = 0;
    private GameObject waypoints;
    


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    private void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        waypoints = GameObject.FindGameObjectWithTag("Waypoints");
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        EnemyLogic();
    } 
    
    private void FollowWaypoints()
    {
        if(currentIndex <= waypoints.transform.childCount - 1)
        {
            float distanceToNextWaypoint = Vector2.Distance(transform.position, waypoints.transform.GetChild(currentIndex).position);
            transform.position = Vector2.MoveTowards(transform.position, waypoints.transform.GetChild(currentIndex).position, speed * Time.deltaTime);

            if (distanceToNextWaypoint < distanceThreshold)
                currentIndex += 1;

        }
    }

    private void EnemyLogic()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if(distanceToPlayer < chaseRange)
        {
            if(distanceThreshold < attackRange)
            {
                Debug.Log("Attack to Player");
                Attack();
            }
            else
            {
                // Chase the Player
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }        
        }

        else
        {
            FollowWaypoints();
        }

    }

    private void Attack()
    {
        if (passedTimeFromLastAttack >= attackCooldown)
        {
            passedTimeFromLastAttack = 0f;
            playerHealth.TakeDamage(damage);
            // attack animation
        }
        else
        {
            passedTimeFromLastAttack += Time.deltaTime;
        }

        Debug.Log(passedTimeFromLastAttack);
    }

}
