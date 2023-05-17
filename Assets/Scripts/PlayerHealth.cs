using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Player took " + damage + " damage.");
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died.");

        // Show game over screen (assuming you have a separate scene for the game over screen)
        //SceneManager.LoadScene("GameOverScene");

        // Alternatively, you can implement respawn logic instead of loading a game over scene
        // RespawnPlayer();
    }

    private void RespawnPlayer()
    {
        // Reset player position, health, or any other necessary state
        transform.position = Vector3.zero;
        currentHealth = maxHealth;
    }
}