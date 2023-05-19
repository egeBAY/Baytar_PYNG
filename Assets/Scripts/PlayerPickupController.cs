using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupController : MonoBehaviour
{

    [SerializeField] private Transform grabPoint;
    private bool isInterractKeyPressed;

    PlayerCombatController playerCombat;

    private void Awake()
    {
        playerCombat = GetComponent<PlayerCombatController>();
    }

    private void Update()
    {
        isInterractKeyPressed = Input.GetKey(KeyCode.E);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Collectible") && isInterractKeyPressed)
        {
            CollectItem(collision.gameObject);
        }
    }

    private void CollectItem(GameObject collectGameObject)
    {
        if(collectGameObject.gameObject.name == "Sword")
        {
            playerCombat.hasMeleeWeapon = true;
            playerCombat.hasRangedWeapon = false;
        }

        else
        {
            playerCombat.hasMeleeWeapon = false;
            playerCombat.hasRangedWeapon = true;
        }
            
            
        collectGameObject.transform.SetParent(transform);
        collectGameObject.transform.position = grabPoint.position;
    }
}
