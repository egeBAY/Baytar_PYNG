using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBullet : MonoBehaviour
{

    public float bulletSpeed = 10f;

    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D bulletRb;

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        bulletRb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        bulletRb.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.TryGetComponent<EnemyController>(out EnemyController enemy))
        {
            enemy.TakeDamage(1);
        }

        Destroy(gameObject);
    }
}
