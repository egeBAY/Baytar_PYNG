using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;
    public float bulletLifetime = 4f;


    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        // bulletRb.velocity = transform.right * bulletSpeed;
        bulletRb.AddForce(bulletSpawnPoint.up * bulletSpeed, ForceMode2D.Impulse);
        // Destroy the bullet after a set amount of time
        Destroy(bullet, bulletLifetime);
    }

}
