using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupController : MonoBehaviour
{

    [SerializeField] private Transform grabPoint;
    private bool isInterractKeyPressed;

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
        SetPositionOfObject(collectGameObject);
        collectGameObject.transform.SetParent(transform);
    }

    private void SetPositionOfObject(GameObject collectedObject)
    {
        Transform holdingPoint = collectedObject.transform.Find("HoldPoint");
        grabPoint.transform.position = holdingPoint.position;
    }
}
