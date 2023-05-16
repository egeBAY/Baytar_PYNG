using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    [Header("Bullet Attributes")]
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public bool canFire;
    public float bulletLifetime = 4f;
    public float timeBetweenFiring;
    private float timer;
    
    [Header("Character Attributes")]
    private Rigidbody2D rb;
    private Transform aimPos;
    private Vector3 mousePos;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
<<<<<<< Updated upstream
        aimPos = transform.Find("GrabPoint");
        charSprite = GetComponent<SpriteRenderer>();
=======
        aimPos = transform.Find("GunSprite");
        animator = GetComponent<Animator>();
>>>>>>> Stashed changes
    }

    private void Update()
    {
        Aim();
        Shoot();
    }

    private void Shoot()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        
        if (Input.GetButtonDown("Fire1") && canFire)
        {   
            canFire = false;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

            // Destroy the bullet after a set amount of time
            Destroy(bullet, bulletLifetime);
        }
    }

    private void Aim()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        aimPos.eulerAngles = new Vector3(0, 0, angle);
        // transform.rotation = Quaternion.Euler(0, angle, 0);

        if (angle < 30 && angle > -30)
        {
            
        }
        else if(angle >30 && angle < 130)
        {
            charSprite.sprite = upCharSprite;
        }
        else if (angle > 150)
        {
            
        }
        else if(angle > -130 && angle < -50)
        {
            charSprite.sprite = downCharSprite;
        }
        
    }
}
