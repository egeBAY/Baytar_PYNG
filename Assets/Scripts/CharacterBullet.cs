using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBullet : MonoBehaviour
{

    public Vector2 bulletVelocity = new Vector2(0f,0f);


    private void Update()
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 newPosition = currentPosition + bulletVelocity * Time.deltaTime;

        transform.position = newPosition;
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
