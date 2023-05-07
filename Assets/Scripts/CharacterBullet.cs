using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.TryGetComponent<EnemyController>(out EnemyController enemy))
        {
            enemy.TakeDamage(1);
        }

        Destroy(gameObject);
    }
}
