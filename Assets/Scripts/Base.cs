using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public int baseHealth;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        gameManager.UpdateBaseHealthTxt(baseHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            baseHealth--;
            gameManager.UpdateBaseHealthTxt(baseHealth);
            Debug.Log("Enemy has entered the base");
        }
    }


}
