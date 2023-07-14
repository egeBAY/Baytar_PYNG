using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    private Transform healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar = transform.Find("HealthBar").transform.Find("Bar");
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        SetHealthBarSize(currentHealth / maxHealth);
        Debug.Log("Player took " + damage + " damage.");
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log("YOU HAVE DIED");
        }
    }

    public void SetHealthBarSize(float sizeNormalized)
    {
        healthBar.localScale = new Vector3(sizeNormalized, 1f);
    }
}